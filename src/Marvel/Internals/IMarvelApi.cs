namespace Marvel
{
    using Model;
    using Refit;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IMarvelApi
    {
        [Get("/characters")]
        Task<HttpResponseMessage> GetCharacters(CharactersQueryParameters parameters, CancellationToken token);

        [Get("/characters/{characterId}")]
        Task<HttpResponseMessage> GetCharacter(int characterId, CancellationToken token);

        [Get("/characters/{characterId}/comics")]
        Task<HttpResponseMessage> GetCharacterComics(int characterId, ComicsByCharacterQueryParameters parameters, CancellationToken token);

        [Get("/characters/{characterId}/events")]
        Task<HttpResponseMessage> GetCharacterEvents(int characterId, EventsByCharacterQueryParameters parameters, CancellationToken token);

        [Get("/characters/{characterId}/series")]
        Task<HttpResponseMessage> GetCharacterSeries(int characterId, SeriesByCharacterQueryParameters parameters, CancellationToken token);

        [Get("/characters/{characterId}/stories")]
        Task<HttpResponseMessage> GetCharacterStories(int characterId, StoriesByCharacterQueryParameters parameters, CancellationToken token);


        [Get("/comics")]
        Task<HttpResponseMessage> GetComics(ComicsQueryParameters parameters, CancellationToken token);

        [Get("/comics/{comicId}")]
        Task<HttpResponseMessage> GetComic(int comicId, CancellationToken token);

        [Get("/comics/{comicId}/characters")]
        Task<HttpResponseMessage> GetComicCharacters(int comicId, CharactersByComicQueryParameters parameters, CancellationToken token);

        [Get("/comics/{comicId}/creators")]
        Task<HttpResponseMessage> GetComicCreators(int comicId, CreatorsByComicQueryParameters parameters, CancellationToken token);

        [Get("/comics/{comicId}/events")]
        Task<HttpResponseMessage> GetComicEvents(int comicId, EventsByComicQueryParameters parameters, CancellationToken token);

        [Get("/comics/{comicId}/stories")]
        Task<HttpResponseMessage> GetComicStories(int comicId, StoriesByComicQueryParameters parameters, CancellationToken token);


        [Get("/creators")]
        Task<HttpResponseMessage> GetCreators(CreatorsQueryParameters parameters, CancellationToken token);

        [Get("/creators/{creatorId}")]
        Task<HttpResponseMessage> GetCreator(int creatorId, CancellationToken token);

        [Get("/creators/{creatorId}/comics")]
        Task<HttpResponseMessage> GetCreatorComics(int creatorId, ComicsByCreatorQueryParameters parameters, CancellationToken token);

        [Get("/creators/{creatorId}/events")]
        Task<HttpResponseMessage> GetCreatorEvents(int creatorId, EventsByComicQueryParameters parameters, CancellationToken token);

        [Get("/creators/{creatorId}/series")]
        Task<HttpResponseMessage> GetCreatorSeries(int creatorId, SeriesByCreatorQueryParameters parameters, CancellationToken token);

        [Get("/creators/{creatorId}/stories")]
        Task<HttpResponseMessage> GetCreatorStories(int creatorId, StoriesByCreatorQueryParameters parameters, CancellationToken token);


        [Get("/events")]
        Task<HttpResponseMessage> GetEvents(EventsQueryParameters parameters, CancellationToken token);

        [Get("/events/{eventId}")]
        Task<HttpResponseMessage> GetEvent(int eventId, CancellationToken token);

        [Get("/events/{eventId}/characters")]
        Task<HttpResponseMessage> GetEventCharacters(int eventId, CharactersByEventQueryParameters parameters, CancellationToken token);

        [Get("/events/{eventId}/comics")]
        Task<HttpResponseMessage> GetEventComics(int eventId, ComicsByEventQueryParameters parameters, CancellationToken token);

        [Get("/events/{eventId}/creators")]
        Task<HttpResponseMessage> GetEventCreators(int eventId, CreatorsByEventQueryParameters parameters, CancellationToken token);

        [Get("/events/{eventId}/series")]
        Task<HttpResponseMessage> GetEventSeries(int eventId, SeriesByEventQueryParameters parameters, CancellationToken token);

        [Get("/events/{eventId}/stories")]
        Task<HttpResponseMessage> GetEventStories(int eventId, StoriesByEventQueryParameters parameters, CancellationToken token);


        [Get("/series")]
        Task<HttpResponseMessage> GetSeries(SeriesQueryParameters parameters, CancellationToken token);

        [Get("/series/{serieId}")]
        Task<HttpResponseMessage> GetSerie(int serieId, CancellationToken token);

        [Get("/series/{serieId}/characters")]
        Task<HttpResponseMessage> GetSerieCharacters(int serieId, CharactersBySerieQueryParameters parameters, CancellationToken token);

        [Get("/series/{serieId}/comics")]
        Task<HttpResponseMessage> GetSerieComics(int serieId, ComicsBySerieQueryParameters parameters, CancellationToken token);

        [Get("/series/{serieId}/creators")]
        Task<HttpResponseMessage> GetSerieCreators(int serieId, CreatorsBySerieQueryParameters parameters, CancellationToken token);

        [Get("/series/{serieId}/events")]
        Task<HttpResponseMessage> GetSerieEvents(int serieId, EventsesBySerieQueryParameters parameters, CancellationToken token);

        [Get("/series/{serieId}/stories")]
        Task<HttpResponseMessage> GetSerieStories(int serieId, StoriesBySerieQueryParameters parameters, CancellationToken token);


        [Get("/stories")]
        Task<HttpResponseMessage> GetStories(StoriesQueryParameters parameters, CancellationToken token);

        [Get("/stories/{storyId}")]
        Task<HttpResponseMessage> GetStory(int storyId, CancellationToken token);

        [Get("/stories/{storyId}/characters")]
        Task<HttpResponseMessage> GetStoryCharacters(int storyId, CharactersesByStoryQueryParameterses parameters, CancellationToken token);

        [Get("/stories/{storyId}/comics")]
        Task<HttpResponseMessage> GetStoryComics(int storyId, ComicsByStoryQueryParameters parameters, CancellationToken token);

        [Get("/stories/{storyId}/creators")]
        Task<HttpResponseMessage> GetStoryCreators(int storyId, CreatorsByStoryQueryParameters parameters, CancellationToken token);

        [Get("/stories/{storyId}/events")]
        Task<HttpResponseMessage> GetStoryEvents(int storyId, EventsByStoryQueryParameters parameters, CancellationToken token);

        [Get("/stories/{storyId}/series")]
        Task<HttpResponseMessage> GetStorySeries(int storyId, SeriesByStoryQueryParameters parameters, CancellationToken token);
    }
}