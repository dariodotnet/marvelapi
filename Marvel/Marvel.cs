namespace Marvel
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class Marvel
    {
        private readonly IMarvelApi _api;

        public Marvel(string publicKey, string privateKey)
        {
            var innerHandler = new HttpClientHandler();
            var basicConnection = new HttpLoggingHandler("e8d935593f01ada9059e3c8f32b03cb0", "5cb13e19d0cf94e8f26e9ad912507af76f7f9cec", innerHandler);

            var basicClient = new HttpClient(basicConnection)
            {
                BaseAddress = new Uri("https://gateway.marvel.com/v1/public")
            };

            _api = Refit.RestService.For<IMarvelApi>(basicClient);
        }

        public Task<string> GetCharacters(CancellationToken token) => _api.GetCharacters(token);
    }
}