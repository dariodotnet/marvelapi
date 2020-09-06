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

        public Task<string> GetCharactersJson(CancellationToken token, CharactersQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacters(parameters, token));

        public Task<MarvelResponse<Character>> GetCharacters(CancellationToken token, CharactersQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetCharacters(parameters, token));

        public Task<string> GetCharacterJson(int characterId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetCharacter(characterId, token));

        public Task<MarvelResponse<Character>> GetCharacter(int characterId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetCharacter(characterId, token));

        public Task<string> GetCharacterComicsJson(int characterId, CancellationToken token, ComicsByCharacterQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacterComics(characterId, parameters, token));

        public Task<MarvelResponse<Comic>> GetCharacterComics(int characterId, CancellationToken token, ComicsByCharacterQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetCharacterComics(characterId, parameters, token));

        public Task<string> GetCharacterEventsJson(int characterId, CancellationToken token, EventsByCharacterQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacterEvents(characterId, parameters, token));

        public Task<MarvelResponse<Event>> GetCharacterEvents(int characterId, CancellationToken token, EventsByCharacterQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetCharacterEvents(characterId, parameters, token));

        public Task<string> GetCharacterSeriesJson(int characterId, CancellationToken token, SeriesByCharacterQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacterSeries(characterId, parameters, token));

        public Task<MarvelResponse<Serie>> GetCharacterSeries(int characterId, CancellationToken token, SeriesByCharacterQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetCharacterSeries(characterId, parameters, token));

        public Task<string> GetCharacterStoriesJson(int characterId, CancellationToken token, StoriesByCharacterQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCharacterStories(characterId, parameters, token));

        public Task<MarvelResponse<Story>> GetCharacterStories(int characterId, CancellationToken token, StoriesByCharacterQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetCharacterStories(characterId, parameters, token));

        #endregion

        #region COMICS

        public Task<string> GetComicsJson(CancellationToken token, ComicsQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetComics(parameters, token));

        public Task<MarvelResponse<Comic>> GetComics(CancellationToken token, ComicsQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetComics(parameters, token));

        public Task<string> GetComicJson(int comicId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetComic(comicId, token));

        public Task<MarvelResponse<Comic>> GetComic(int comicId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetComic(comicId, token));

        public Task<string> GetComicCharactersJson(int comicId, CancellationToken token, CharactersByComicQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetComicCharacters(comicId, parameters, token));

        public Task<MarvelResponse<Character>> GetComicCharacters(int comicId, CancellationToken token, CharactersByComicQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetComicCharacters(comicId, parameters, token));

        public Task<string> GetComicCreatorsJson(int comicId, CancellationToken token, CreatorsByComicQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetComicCreators(comicId, parameters, token));

        public Task<MarvelResponse<Creator>> GetComicCreators(int comicId, CancellationToken token, CreatorsByComicQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetComicCreators(comicId, parameters, token));

        public Task<string> GetComicEventsJson(int comicId, CancellationToken token, EventsByComicQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetComicEvents(comicId, parameters, token));

        public Task<MarvelResponse<Event>> GetComicEvents(int comicId, CancellationToken token, EventsByComicQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetComicEvents(comicId, parameters, token));

        public Task<string> GetComicStoriesJson(int comicId, CancellationToken token, StoriesByComicQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetComicStories(comicId, parameters, token));

        public Task<MarvelResponse<Story>> GetComicStories(int comicId, CancellationToken token, StoriesByComicQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetComicStories(comicId, parameters, token));

        #endregion

        #region CREATORS

        public Task<string> GetCreatorsJson(CancellationToken token, CreatorsQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCreators(parameters, token));

        public Task<MarvelResponse<Creator>> GetCreators(CancellationToken token, CreatorsQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetCreators(parameters, token));

        public Task<string> GetCreatorJson(int creatorId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetCreator(creatorId, token));

        public Task<MarvelResponse<Creator>> GetCreator(int creatorId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetCreator(creatorId, token));

        public Task<string> GetCreatorComicsJson(int creatorId, CancellationToken token, ComicsByCreatorQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCreatorComics(creatorId, parameters, token));

        public Task<MarvelResponse<Comic>> GetCreatorComics(int creatorId, CancellationToken token, ComicsByCreatorQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetCreatorComics(creatorId, parameters, token));

        public Task<string> GetCreatorEventsJson(int creatorId, CancellationToken token, EventsByComicQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCreatorEvents(creatorId, parameters, token));

        public Task<MarvelResponse<Event>> GetCreatorEvents(int creatorId, CancellationToken token, EventsByComicQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetCreatorEvents(creatorId, parameters, token));

        public Task<string> GetCreatorSeriesJson(int creatorId, CancellationToken token, SeriesByCreatorQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCreatorSeries(creatorId, parameters, token));

        public Task<MarvelResponse<Serie>> GetCreatorSeries(int creatorId, CancellationToken token, SeriesByCreatorQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetCreatorSeries(creatorId, parameters, token));

        public Task<string> GetCreatorStoriesJson(int creatorId, CancellationToken token, StoriesByCreatorQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetCreatorStories(creatorId, parameters, token));

        public Task<MarvelResponse<Story>> GetCreatorStories(int creatorId, CancellationToken token, StoriesByCreatorQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetCreatorStories(creatorId, parameters, token));

        public Task<string> GetEventCreatorsJson(int eventId, CancellationToken token, CreatorsByEventQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetEventCreators(eventId, parameters, token));

        public Task<MarvelResponse<Creator>> GetEventCreators(int eventId, CancellationToken token, CreatorsByEventQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetEventCreators(eventId, parameters, token));

        public Task<string> GetEventSeriesJson(int eventId, CancellationToken token, SeriesByEventQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetEventSeries(eventId, parameters, token));

        public Task<MarvelResponse<Serie>> GetEventSeries(int eventId, CancellationToken token, SeriesByEventQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetEventSeries(eventId, parameters, token));

        public Task<string> GetEventStoriesJson(int eventId, CancellationToken token, StoriesByEventQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetEventStories(eventId, parameters, token));

        public Task<MarvelResponse<Story>> GetEventStories(int eventId, CancellationToken token, StoriesByEventQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetEventStories(eventId, parameters, token));

        #endregion

        #region EVENTS

        public Task<string> GetEventsJson(CancellationToken token, EventsQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetEvents(parameters, token));

        public Task<MarvelResponse<Event>> GetEvents(CancellationToken token, EventsQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetEvents(parameters, token));

        public Task<string> GetEventJson(int eventId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetEvent(eventId, token));

        public Task<MarvelResponse<Event>> GetEvent(int eventId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetEvent(eventId, token));

        public Task<string> GetEventCharactersJson(int eventId, CancellationToken token, CharactersByEventQueryParameters parameterses = null) =>
            ExecuteApiJson(() => _api.GetEventCharacters(eventId, parameterses, token));

        public Task<MarvelResponse<Character>> GetEventCharacters(int eventId, CancellationToken token, CharactersByEventQueryParameters parameterses = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetEventCharacters(eventId, parameterses, token));

        public Task<string> GetEventComicsJson(int eventId, CancellationToken token, ComicsByEventQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetEventComics(eventId, parameters, token));

        public Task<MarvelResponse<Comic>> GetEventComics(int eventId, CancellationToken token, ComicsByEventQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetEventComics(eventId, parameters, token));

        #endregion

        #region SERIES

        public Task<string> GetSeriesJson(CancellationToken token, SeriesQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetSeries(parameters, token));

        public Task<MarvelResponse<Serie>> GetSeries(CancellationToken token, SeriesQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetSeries(parameters, token));

        public Task<string> GetSerieJson(int serieId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetSerie(serieId, token));

        public Task<MarvelResponse<Serie>> GetSerie(int serieId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetSerie(serieId, token));

        public Task<string> GetSerieCharactersJson(int serieId, CancellationToken token, CharactersBySerieQueryParameters parameterses = null) =>
            ExecuteApiJson(() => _api.GetSerieCharacters(serieId, parameterses, token));

        public Task<MarvelResponse<Character>> GetSerieCharacters(int serieId, CancellationToken token, CharactersBySerieQueryParameters parameterses = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetSerieCharacters(serieId, parameterses, token));

        public Task<string> GetSerieComicsJson(int serieId, CancellationToken token, ComicsBySerieQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetSerieComics(serieId, parameters, token));

        public Task<MarvelResponse<Comic>> GetSerieComics(int serieId, CancellationToken token, ComicsBySerieQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetSerieComics(serieId, parameters, token));

        public Task<string> GetSerieCreatorsJson(int serieId, CancellationToken token, CreatorsBySerieQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetSerieCreators(serieId, parameters, token));

        public Task<MarvelResponse<Creator>> GetSerieCreators(int serieId, CancellationToken token, CreatorsBySerieQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetSerieCreators(serieId, parameters, token));

        public Task<string> GetSerieEventsJson(int serieId, CancellationToken token, EventsesBySerieQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetSerieEvents(serieId, parameters, token));

        public Task<MarvelResponse<Event>> GetSerieEvents(int serieId, CancellationToken token, EventsesBySerieQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetSerieEvents(serieId, parameters, token));

        public Task<string> GetSerieStoriesJson(int serieId, CancellationToken token, StoriesBySerieQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetSerieStories(serieId, parameters, token));

        public Task<MarvelResponse<Story>> GetSerieStories(int serieId, CancellationToken token, StoriesBySerieQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetSerieStories(serieId, parameters, token));

        #endregion

        #region STORIES

        public Task<string> GetStoriesJson(CancellationToken token, StoriesQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetStories(parameters, token));

        public Task<MarvelResponse<Story>> GetStories(CancellationToken token, StoriesQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetStories(parameters, token));

        public Task<string> GetStoryJson(int storyId, CancellationToken token) =>
            ExecuteApiJson(() => _api.GetStory(storyId, token));

        public Task<MarvelResponse<Story>> GetStory(int storyId, CancellationToken token) =>
            ExecuteApiCall<MarvelResponse<Story>>(() => _api.GetStory(storyId, token));

        public Task<string> GetStoryCharactersJson(int storyId, CancellationToken token, CharactersesByStoryQueryParameterses parameterses = null) =>
            ExecuteApiJson(() => _api.GetStoryCharacters(storyId, parameterses, token));

        public Task<MarvelResponse<Character>> GetStoryCharacters(int storyId, CancellationToken token, CharactersesByStoryQueryParameterses parameterses = null) =>
            ExecuteApiCall<MarvelResponse<Character>>(() => _api.GetStoryCharacters(storyId, parameterses, token));

        public Task<string> GetStoryComicsJson(int storyId, CancellationToken token, ComicsByStoryQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetStoryComics(storyId, parameters, token));

        public Task<MarvelResponse<Comic>> GetStoryComics(int storyId, CancellationToken token, ComicsByStoryQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Comic>>(() => _api.GetStoryComics(storyId, parameters, token));

        public Task<string> GetStoryCreatorsJson(int storyId, CancellationToken token, CreatorsByStoryQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetStoryCreators(storyId, parameters, token));

        public Task<MarvelResponse<Creator>> GetStoryCreators(int storyId, CancellationToken token, CreatorsByStoryQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Creator>>(() => _api.GetStoryCreators(storyId, parameters, token));

        public Task<string> GetStoryEventsJson(int storyId, CancellationToken token, EventsByStoryQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetStoryEvents(storyId, parameters, token));

        public Task<MarvelResponse<Event>> GetStoryEvents(int storyId, CancellationToken token, EventsByStoryQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Event>>(() => _api.GetStoryEvents(storyId, parameters, token));

        public Task<string> GetStorySeriesJson(int storyId, CancellationToken token, SeriesByStoryQueryParameters parameters = null) =>
            ExecuteApiJson(() => _api.GetStorySeries(storyId, parameters, token));

        public Task<MarvelResponse<Serie>> GetStorySeries(int storyId, CancellationToken token, SeriesByStoryQueryParameters parameters = null) =>
            ExecuteApiCall<MarvelResponse<Serie>>(() => _api.GetStorySeries(storyId, parameters, token));

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