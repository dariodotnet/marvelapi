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

        public Task<string> GetCharacterComicsJson(int characterId, CancellationToken token, ComicQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetCharacterComics(characterId, parameter, token));

        public Task<MarvelResponse<Comic>> GetCharacterComics(int characterId, CancellationToken token, ComicQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetCharacterComics(characterId, parameter, token));

        public Task<string> GetCharacterEventsJson(int characterId, CancellationToken token, EventQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetCharacterEvents(characterId, parameter, token));

        public Task<MarvelResponse<Event>> GetCharacterEvents(int characterId, CancellationToken token, EventQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetCharacterEvents(characterId, parameter, token));

        public Task<string> GetCharacterSeriesJson(int characterId, CancellationToken token, SerieQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacterSeries(characterId, parameters, token));

        public Task<MarvelResponse<Serie>> GetCharacterSeries(int characterId, CancellationToken token, SerieQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetCharacterSeries(characterId, parameters, token));

        public Task<string> GetCharacterStoriesJson(int characterId, CancellationToken token, StoryQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacterStories(characterId, parameters, token));

        public Task<MarvelResponse<Story>> GetCharacterStories(int characterId, CancellationToken token, StoryQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetCharacterStories(characterId, parameters, token));

        public Task<string> GetComicsJson(CancellationToken token, ComicQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetComics(parameters, token));

        public Task<MarvelResponse<Comic>> GetComics(CancellationToken token, ComicQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetComics(parameters, token));

        public Task<string> GetComicJson(int comicId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetComic(comicId, token));

        public Task<MarvelResponse<Comic>> GetComic(int comicId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetComic(comicId, token));

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