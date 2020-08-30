namespace Marvel
{
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

        public IMarvel Initialize(string publicKey, string privateKey, bool bypassCertificate = false) =>
             InitializeApi(publicKey, privateKey, bypassCertificate);
        
        public Task<string> GetCharacters(CancellationToken token) => _api.GetCharacters(token);

        private Marvel InitializeApi(string publicKey, string privateKey, bool bypassCertificate = false)
        {
            HttpClientHandler innerHandler = null;
            
            if(bypassCertificate)
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
            return this;
        }
    }
}