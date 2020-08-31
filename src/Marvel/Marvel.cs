namespace Marvel
{
    using Model;
    using Polly;
    using Refit;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class Marvel : IMarvel
    {
        private const string BaseUri = "https://gateway.marvel.com/v1/public";
        private IMarvelApi _api;

        public Marvel(string publicKey, string privateKey, bool bypassCertificate = false)
        {
            InitializeApi(publicKey, privateKey, bypassCertificate);
        }

        public Task<string> GetCharactersJson(CancellationToken token, CharacterQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetCharacters(parameter, token));

        public Task<MarvelResponse<Character>> GetCharacters(CancellationToken token, CharacterQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetCharacters(parameter, token));

        public Task<string> GetCharacterJson(int characterId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetCharacter(characterId, token));

        public Task<MarvelResponse<Character>> GetCharacter(int characterId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetCharacter(characterId, token));

        internal void InitializeApi(string publicKey, string privateKey, bool bypassCertificate = false)
        {
            HttpClientHandler innerHandler = null;

            if (bypassCertificate)
                innerHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
                };

            var basicConnection = new HttpLoggingHandler(publicKey, privateKey, innerHandler);

            var basicClient = new HttpClient(basicConnection)
            {
                BaseAddress = new Uri(BaseUri)
            };

            _api = Refit.RestService.For<IMarvelApi>(basicClient);
        }

        internal Task<string> ExecuteApiJson(Func<Task<HttpResponseMessage>> method)
        {
            var retry = Policy.Handle<ApiException>()
                .RetryAsync(async (ex, retries) => await Task.Delay(300).ConfigureAwait(false));

            return retry.ExecuteAsync(async () =>
            {
                var response = await method();
                return await response.Resolve();
            });
        }

        internal Task<T> ExecuteApiCall<T>(Func<Task<HttpResponseMessage>> method)
        {
            var retry = Policy.Handle<ApiException>()
                .RetryAsync(async (ex, retries) => await Task.Delay(300).ConfigureAwait(false));

            return retry.ExecuteAsync(async () =>
            {
                var response = await method();

                return await response.Resolve<T>();
            });
        }
    }
}