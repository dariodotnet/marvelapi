namespace Marvel
{
    using Model;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMarvel
    {
        string PublicKey { get; }
        string PrivateKey { get; }
        bool BypassCertificate { get; }

        Task<string> GetCharactersJson(CancellationToken token, CharactersQueryParameters parameters = null);
        Task<MarvelResponse<Character>> GetCharacters(CancellationToken token, CharactersQueryParameters parameters = null);

        Task<string> GetCharacterJson(int characterId, CancellationToken token);
        Task<MarvelResponse<Character>> GetCharacter(int characterId, CancellationToken token);

        Task<string> GetCharacterComicsJson(int characterId, CancellationToken token, ComicsByCharacterQueryParameters parameters = null);
        Task<MarvelResponse<Comic>> GetCharacterComics(int characterId, CancellationToken token, ComicsByCharacterQueryParameters parameters = null);

        Task<string> GetCharacterEventsJson(int characterId, CancellationToken token, EventsByCharacterQueryParameters parameters = null);
        Task<MarvelResponse<Event>> GetCharacterEvents(int characterId, CancellationToken token, EventsByCharacterQueryParameters parameters = null);

        Task<string> GetCharacterSeriesJson(int characterId, CancellationToken token, SeriesByCharacterQueryParameters parameters = null);
        Task<MarvelResponse<Serie>> GetCharacterSeries(int characterId, CancellationToken token, SeriesByCharacterQueryParameters parameters = null);

        Task<string> GetCharacterStoriesJson(int characterId, CancellationToken token, StoriesByCharacterQueryParameters parameters = null);
        Task<MarvelResponse<Story>> GetCharacterStories(int characterId, CancellationToken token, StoriesByCharacterQueryParameters parameters = null);

        Task<string> GetComicsJson(CancellationToken token, ComicsQueryParameters parameters = null);
        Task<MarvelResponse<Comic>> GetComics(CancellationToken token, ComicsQueryParameters parameters = null);

        Task<string> GetComicJson(int comicId, CancellationToken token);
        Task<MarvelResponse<Comic>> GetComic(int comicId, CancellationToken token);

        Task<string> GetComicCharactersJson(int comicId, CancellationToken token, CharactersByComicQueryParameters parameters = null);
        Task<MarvelResponse<Character>> GetComicCharacters(int comicId, CancellationToken token, CharactersByComicQueryParameters parameters = null);

        Task<string> GetComicCreatorsJson(int comicId, CancellationToken token, CreatorsByComicQueryParameters parameters = null);
        Task<MarvelResponse<Creator>> GetComicCreators(int comicId, CancellationToken token, CreatorsByComicQueryParameters parameters = null);

        Task<string> GetComicEventsJson(int comicId, CancellationToken token, EventsByComicQueryParameters parameters = null);
        Task<MarvelResponse<Event>> GetComicEvents(int comicId, CancellationToken token, EventsByComicQueryParameters parameters = null);

        Task<string> GetComicStoriesJson(int comicId, CancellationToken token, StoriesByComicQueryParameters parameters = null);
        Task<MarvelResponse<Story>> GetComicStories(int comicId, CancellationToken token, StoriesByComicQueryParameters parameters = null);

        Task<string> GetCreatorsJson(CancellationToken token, CreatorsQueryParameters parameters = null);
        Task<MarvelResponse<Creator>> GetCreators(CancellationToken token, CreatorsQueryParameters parameters = null);

        Task<string> GetCreatorJson(int creatorId, CancellationToken token);
        Task<MarvelResponse<Creator>> GetCreator(int creatorId, CancellationToken token);

        Task<string> GetCreatorComicsJson(int creatorId, CancellationToken token, ComicsByCreatorQueryParameters parameters = null);
        Task<MarvelResponse<Comic>> GetCreatorComics(int creatorId, CancellationToken token, ComicsByCreatorQueryParameters parameters = null);

        Task<string> GetCreatorEventsJson(int creatorId, CancellationToken token, EventsByComicQueryParameters parameters = null);
        Task<MarvelResponse<Event>> GetCreatorEvents(int creatorId, CancellationToken token, EventsByComicQueryParameters parameters = null);

        Task<string> GetCreatorSeriesJson(int creatorId, CancellationToken token, SeriesByCreatorQueryParameters parameters = null);
        Task<MarvelResponse<Serie>> GetCreatorSeries(int creatorId, CancellationToken token, SeriesByCreatorQueryParameters parameters = null);

        Task<string> GetCreatorStoriesJson(int creatorId, CancellationToken token, StoriesByCreatorQueryParameters parameters = null);
        Task<MarvelResponse<Story>> GetCreatorStories(int creatorId, CancellationToken token, StoriesByCreatorQueryParameters parameters = null);

        Task<string> GetEventsJson(CancellationToken token, EventsQueryParameters parameters = null);
        Task<MarvelResponse<Event>> GetEvents(CancellationToken token, EventsQueryParameters parameters = null);

        Task<string> GetEventJson(int eventId, CancellationToken token);
        Task<MarvelResponse<Event>> GetEvent(int eventId, CancellationToken token);

        Task<string> GetEventCharactersJson(int eventId, CancellationToken token, CharactersByEventQueryParameters parameterses = null);
        Task<MarvelResponse<Character>> GetEventCharacters(int eventId, CancellationToken token, CharactersByEventQueryParameters parameterses = null);

        Task<string> GetEventComicsJson(int eventId, CancellationToken token, ComicsByEventQueryParameters parameters = null);
        Task<MarvelResponse<Comic>> GetEventComics(int eventId, CancellationToken token, ComicsByEventQueryParameters parameters = null);

        Task<string> GetEventCreatorsJson(int eventId, CancellationToken token, CreatorsByEventQueryParameters parameters = null);
        Task<MarvelResponse<Creator>> GetEventCreators(int eventId, CancellationToken token, CreatorsByEventQueryParameters parameters = null);

        Task<string> GetEventSeriesJson(int eventId, CancellationToken token, SeriesByEventQueryParameters parameters = null);
        Task<MarvelResponse<Serie>> GetEventSeries(int eventId, CancellationToken token, SeriesByEventQueryParameters parameters = null);

        Task<string> GetEventStoriesJson(int eventId, CancellationToken token, StoriesByEventQueryParameters parameters = null);
        Task<MarvelResponse<Story>> GetEventStories(int eventId, CancellationToken token, StoriesByEventQueryParameters parameters = null);

        Task<string> GetSeriesJson(CancellationToken token, SeriesQueryParameters parameters = null);
        Task<MarvelResponse<Serie>> GetSeries(CancellationToken token, SeriesQueryParameters parameters = null);

        Task<string> GetSerieJson(int serieId, CancellationToken token);
        Task<MarvelResponse<Serie>> GetSerie(int serieId, CancellationToken token);

        Task<string> GetSerieCharactersJson(int serieId, CancellationToken token, CharactersBySerieQueryParameters parameterses = null);
        Task<MarvelResponse<Character>> GetSerieCharacters(int serieId, CancellationToken token, CharactersBySerieQueryParameters parameterses = null);

        Task<string> GetSerieComicsJson(int serieId, CancellationToken token, ComicsBySerieQueryParameters parameters = null);
        Task<MarvelResponse<Comic>> GetSerieComics(int serieId, CancellationToken token, ComicsBySerieQueryParameters parameters = null);

        Task<string> GetSerieCreatorsJson(int serieId, CancellationToken token, CreatorsBySerieQueryParameters parameters = null);
        Task<MarvelResponse<Creator>> GetSerieCreators(int serieId, CancellationToken token, CreatorsBySerieQueryParameters parameters = null);

        Task<string> GetSerieEventsJson(int serieId, CancellationToken token, EventsesBySerieQueryParameters parameters = null);
        Task<MarvelResponse<Event>> GetSerieEvents(int serieId, CancellationToken token, EventsesBySerieQueryParameters parameters = null);

        Task<string> GetSerieStoriesJson(int serieId, CancellationToken token, StoriesBySerieQueryParameters parameters = null);
        Task<MarvelResponse<Story>> GetSerieStories(int serieId, CancellationToken token, StoriesBySerieQueryParameters parameters = null);

        Task<string> GetStoriesJson(CancellationToken token, StoriesQueryParameters parameters = null);
        Task<MarvelResponse<Story>> GetStories(CancellationToken token, StoriesQueryParameters parameters = null);

        Task<string> GetStoryJson(int storyId, CancellationToken token);
        Task<MarvelResponse<Story>> GetStory(int storyId, CancellationToken token);

        Task<string> GetStoryCharactersJson(int storyId, CancellationToken token, CharactersesByStoryQueryParameterses parameterses = null);
        Task<MarvelResponse<Character>> GetStoryCharacters(int storyId, CancellationToken token, CharactersesByStoryQueryParameterses parameterses = null);

        Task<string> GetStoryComicsJson(int storyId, CancellationToken token, ComicsByStoryQueryParameters parameters = null);
        Task<MarvelResponse<Comic>> GetStoryComics(int storyId, CancellationToken token, ComicsByStoryQueryParameters parameters = null);

        Task<string> GetStoryCreatorsJson(int storyId, CancellationToken token, CreatorsByStoryQueryParameters parameters = null);
        Task<MarvelResponse<Creator>> GetStoryCreators(int storyId, CancellationToken token, CreatorsByStoryQueryParameters parameters = null);

        Task<string> GetStoryEventsJson(int storyId, CancellationToken token, EventsByStoryQueryParameters parameters = null);
        Task<MarvelResponse<Event>> GetStoryEvents(int storyId, CancellationToken token, EventsByStoryQueryParameters parameters = null);

        Task<string> GetStorySeriesJson(int storyId, CancellationToken token, SeriesByStoryQueryParameters parameters = null);
        Task<MarvelResponse<Serie>> GetStorySeries(int storyId, CancellationToken token, SeriesByStoryQueryParameters parameters = null);
    }
}