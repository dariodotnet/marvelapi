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

        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }
        public bool BypassCertificate { get; private set; }

        public Marvel(string publicKey, string privateKey, bool bypassCertificate = false)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
            BypassCertificate = bypassCertificate;
            InitializeApi(PublicKey, PrivateKey, BypassCertificate);
        }

        public Marvel(IMarvel customInitialization)
        {
            InitializeApi(customInitialization.PublicKey, customInitialization.PrivateKey, customInitialization.BypassCertificate);
        }

        #region CHARACTERS

        public Task<string> GetCharactersJson(CancellationToken token, CharacterQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetCharacters(parameter, token));

        public Task<MarvelResponse<Character>> GetCharacters(CancellationToken token, CharacterQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetCharacters(parameter, token));

        public Task<string> GetCharacterJson(int characterId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetCharacter(characterId, token));

        public Task<MarvelResponse<Character>> GetCharacter(int characterId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetCharacter(characterId, token));

        public Task<string> GetCharacterComicsJson(int characterId, CancellationToken token, ComicByCharacterQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetCharacterComics(characterId, parameter, token));

        public Task<MarvelResponse<Comic>> GetCharacterComics(int characterId, CancellationToken token, ComicByCharacterQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetCharacterComics(characterId, parameter, token));

        public Task<string> GetCharacterEventsJson(int characterId, CancellationToken token, EventByCharacterQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetCharacterEvents(characterId, parameter, token));

        public Task<MarvelResponse<Event>> GetCharacterEvents(int characterId, CancellationToken token, EventByCharacterQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetCharacterEvents(characterId, parameter, token));

        public Task<string> GetCharacterSeriesJson(int characterId, CancellationToken token, SerieByCharacterQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacterSeries(characterId, parameters, token));

        public Task<MarvelResponse<Serie>> GetCharacterSeries(int characterId, CancellationToken token, SerieByCharacterQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetCharacterSeries(characterId, parameters, token));

        public Task<string> GetCharacterStoriesJson(int characterId, CancellationToken token, StoryByCharacterQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacterStories(characterId, parameters, token));

        public Task<MarvelResponse<Story>> GetCharacterStories(int characterId, CancellationToken token, StoryByCharacterQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetCharacterStories(characterId, parameters, token));

        #endregion

        #region COMICS

        public Task<string> GetComicsJson(CancellationToken token, ComicQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetComics(parameters, token));

        public Task<MarvelResponse<Comic>> GetComics(CancellationToken token, ComicQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetComics(parameters, token));

        public Task<string> GetComicJson(int comicId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetComic(comicId, token));

        public Task<MarvelResponse<Comic>> GetComic(int comicId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetComic(comicId, token));

        public Task<string> GetComicCharactersJson(int comicId, CancellationToken token, CharacterByComicQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetComicCharacters(comicId, parameter, token));

        public Task<MarvelResponse<Character>> GetComicCharacters(int comicId, CancellationToken token, CharacterByComicQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetComicCharacters(comicId, parameter, token));

        public Task<string> GetComicCreatorsJson(int comicId, CancellationToken token, CreatorByComicQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetComicCreators(comicId, parameter, token));

        public Task<MarvelResponse<Creator>> GetComicCreators(int comicId, CancellationToken token, CreatorByComicQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetComicCreators(comicId, parameter, token));

        public Task<string> GetComicEventsJson(int comicId, CancellationToken token, EventByComicQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetComicEvents(comicId, parameter, token));

        public Task<MarvelResponse<Event>> GetComicEvents(int comicId, CancellationToken token, EventByComicQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetComicEvents(comicId, parameter, token));

        public Task<string> GetComicStoriesJson(int comicId, CancellationToken token, StoryByComicQueryParameter parameter = null) =>
            ExecuteApiJson(() => _api.GetComicStories(comicId, parameter, token));

        public Task<MarvelResponse<Story>> GetComicStories(int comicId, CancellationToken token, StoryByComicQueryParameter parameter = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetComicStories(comicId, parameter, token));

        #endregion

        #region CREATORS

        public Task<string> GetCreatorsJson(CancellationToken token, CreatorByComicQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCreators(parameters, token));

        public Task<MarvelResponse<Creator>> GetCreators(CancellationToken token, CreatorByComicQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetCreators(parameters, token));

        public Task<string> GetCreatorJson(int creatorId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetCreator(creatorId, token));

        public Task<MarvelResponse<Creator>> GetCreator(int creatorId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetCreator(creatorId, token));

        public Task<string> GetCreatorComicsJson(int creatorId, CancellationToken token, ComicByCreatorQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCreatorComics(creatorId, parameters, token));

        public Task<MarvelResponse<Comic>> GetCreatorComics(int creatorId, CancellationToken token, ComicByCreatorQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetCreatorComics(creatorId, parameters, token));

        public Task<string> GetCreatorEventsJson(int creatorId, CancellationToken token, EventByComicQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCreatorEvents(creatorId, parameters, token));

        public Task<MarvelResponse<Event>> GetCreatorEvents(int creatorId, CancellationToken token, EventByComicQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetCreatorEvents(creatorId, parameters, token));

        public Task<string> GetCreatorSeriesJson(int creatorId, CancellationToken token, SerieByCreatorQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCreatorSeries(creatorId, parameters, token));

        public Task<MarvelResponse<Serie>> GetCreatorSeries(int creatorId, CancellationToken token, SerieByCreatorQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetCreatorSeries(creatorId, parameters, token));

        public Task<string> GetCreatorStoriesJson(int creatorId, CancellationToken token, StoryByCreatorQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetCreatorStories(creatorId, parameters, token));

        public Task<MarvelResponse<Story>> GetCreatorStories(int creatorId, CancellationToken token, StoryByCreatorQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetCreatorStories(creatorId, parameters, token));

        public Task<string> GetEventCreatorsJson(int eventId, CancellationToken token, CreatorByEventQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetEventCreators(eventId, parameters, token));

        public Task<MarvelResponse<Creator>> GetEventCreators(int eventId, CancellationToken token, CreatorByEventQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetEventCreators(eventId, parameters, token));

        public Task<string> GetEventSeriesJson(int eventId, CancellationToken token, SerieByEventQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetEventSeries(eventId, parameters, token));

        public Task<MarvelResponse<Serie>> GetEventSeries(int eventId, CancellationToken token, SerieByEventQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetEventSeries(eventId, parameters, token));

        #endregion

        #region EVENTS

        public Task<string> GetEventsJson(CancellationToken token, EventQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetEvents(parameters, token));

        public Task<MarvelResponse<Event>> GetEvents(CancellationToken token, EventQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetEvents(parameters, token));

        public Task<string> GetEventJson(int eventId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetEvent(eventId, token));

        public Task<MarvelResponse<Event>> GetEvent(int eventId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetEvent(eventId, token));

        public Task<string> GetEventCharactersJson(int eventId, CancellationToken token, CharacterByEventQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetEventCharacters(eventId, parameters, token));

        public Task<MarvelResponse<Character>> GetEventCharacters(int eventId, CancellationToken token, CharacterByEventQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetEventCharacters(eventId, parameters, token));

        public Task<string> GetEventComicsJson(int eventId, CancellationToken token, ComicByEventQueryParameter parameters = null) =>
            ExecuteApiJson(() => _api.GetEventComics(eventId, parameters, token));

        public Task<MarvelResponse<Comic>> GetEventComics(int eventId, CancellationToken token, ComicByEventQueryParameter parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetEventComics(eventId, parameters, token));

        #endregion

        #region INTERNALS

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

            _api = RestService.For<IMarvelApi>(basicClient);
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

        #endregion
    }
}