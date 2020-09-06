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

        Task<string> GetCharactersJson(CancellationToken token, CharacterQueryParameter parameter = null);
        Task<MarvelResponse<Character>> GetCharacters(CancellationToken token, CharacterQueryParameter parameter = null);

        Task<string> GetCharacterJson(int characterId, CancellationToken token);
        Task<MarvelResponse<Character>> GetCharacter(int characterId, CancellationToken token);

        Task<string> GetCharacterComicsJson(int characterId, CancellationToken token, ComicByCharacterQueryParameter parameter = null);
        Task<MarvelResponse<Comic>> GetCharacterComics(int characterId, CancellationToken token, ComicByCharacterQueryParameter parameter = null);

        Task<string> GetCharacterEventsJson(int characterId, CancellationToken token, EventByCharacterQueryParameter parameter = null);
        Task<MarvelResponse<Event>> GetCharacterEvents(int characterId, CancellationToken token, EventByCharacterQueryParameter parameter = null);

        Task<string> GetCharacterSeriesJson(int characterId, CancellationToken token, SerieByCharacterQueryParameter parameters = null);
        Task<MarvelResponse<Serie>> GetCharacterSeries(int characterId, CancellationToken token, SerieByCharacterQueryParameter parameters = null);

        Task<string> GetCharacterStoriesJson(int characterId, CancellationToken token, StoryByCharacterQueryParameter parameters = null);
        Task<MarvelResponse<Story>> GetCharacterStories(int characterId, CancellationToken token, StoryByCharacterQueryParameter parameters = null);

        Task<string> GetComicsJson(CancellationToken token, ComicQueryParameter parameters = null);
        Task<MarvelResponse<Comic>> GetComics(CancellationToken token, ComicQueryParameter parameters = null);

        Task<string> GetComicJson(int comicId, CancellationToken token);
        Task<MarvelResponse<Comic>> GetComic(int comicId, CancellationToken token);

        Task<string> GetComicCharactersJson(int comicId, CancellationToken token, CharacterByComicQueryParameter parameter = null);
        Task<MarvelResponse<Character>> GetComicCharacters(int comicId, CancellationToken token, CharacterByComicQueryParameter parameter = null);

        Task<string> GetComicCreatorsJson(int comicId, CancellationToken token, CreatorByComicQueryParameter parameter = null);
        Task<MarvelResponse<Creator>> GetComicCreators(int comicId, CancellationToken token, CreatorByComicQueryParameter parameter = null);

        Task<string> GetComicEventsJson(int comicId, CancellationToken token, EventByComicQueryParameter parameter = null);
        Task<MarvelResponse<Event>> GetComicEvents(int comicId, CancellationToken token, EventByComicQueryParameter parameter = null);

        Task<string> GetComicStoriesJson(int comicId, CancellationToken token, StoryByComicQueryParameter parameter = null);
        Task<MarvelResponse<Story>> GetComicStories(int comicId, CancellationToken token, StoryByComicQueryParameter parameter = null);

        Task<string> GetCreatorsJson(CancellationToken token, CreatorQueryParameter parameters = null);
        Task<MarvelResponse<Creator>> GetCreators(CancellationToken token, CreatorQueryParameter parameters = null);

        Task<string> GetCreatorJson(int creatorId, CancellationToken token);
        Task<MarvelResponse<Creator>> GetCreator(int creatorId, CancellationToken token);

        Task<string> GetCreatorComicsJson(int creatorId, CancellationToken token, ComicByCreatorQueryParameter parameters = null);
        Task<MarvelResponse<Comic>> GetCreatorComics(int creatorId, CancellationToken token, ComicByCreatorQueryParameter parameters = null);

        Task<string> GetCreatorEventsJson(int creatorId, CancellationToken token, EventByComicQueryParameter parameters = null);
        Task<MarvelResponse<Event>> GetCreatorEvents(int creatorId, CancellationToken token, EventByComicQueryParameter parameters = null);

        Task<string> GetCreatorSeriesJson(int creatorId, CancellationToken token, SerieByCreatorQueryParameter parameters = null);
        Task<MarvelResponse<Serie>> GetCreatorSeries(int creatorId, CancellationToken token, SerieByCreatorQueryParameter parameters = null);

        Task<string> GetCreatorStoriesJson(int creatorId, CancellationToken token, StoryByCreatorQueryParameter parameters = null);
        Task<MarvelResponse<Story>> GetCreatorStories(int creatorId, CancellationToken token, StoryByCreatorQueryParameter parameters = null);

        Task<string> GetEventsJson(CancellationToken token, EventQueryParameter parameters = null);
        Task<MarvelResponse<Event>> GetEvents(CancellationToken token, EventQueryParameter parameters = null);

        Task<string> GetEventJson(int eventId, CancellationToken token);
        Task<MarvelResponse<Event>> GetEvent(int eventId, CancellationToken token);

        Task<string> GetEventCharactersJson(int eventId, CancellationToken token, CharacterByEventQueryParameter parameters = null);
        Task<MarvelResponse<Character>> GetEventCharacters(int eventId, CancellationToken token, CharacterByEventQueryParameter parameters = null);

        Task<string> GetEventComicsJson(int eventId, CancellationToken token, ComicByEventQueryParameter parameters = null);
        Task<MarvelResponse<Comic>> GetEventComics(int eventId, CancellationToken token, ComicByEventQueryParameter parameters = null);

        Task<string> GetEventCreatorsJson(int eventId, CancellationToken token, CreatorByEventQueryParameter parameters = null);
        Task<MarvelResponse<Creator>> GetEventCreators(int eventId, CancellationToken token, CreatorByEventQueryParameter parameters = null);

        Task<string> GetEventSeriesJson(int eventId, CancellationToken token, SerieByEventQueryParameter parameters = null);
        Task<MarvelResponse<Serie>> GetEventSeries(int eventId, CancellationToken token, SerieByEventQueryParameter parameters = null);

        Task<string> GetEventStoriesJson(int eventId, CancellationToken token, StoryByEventQueryParameter parameters = null);
        Task<MarvelResponse<Story>> GetEventStories(int eventId, CancellationToken token, StoryByEventQueryParameter parameters = null);

        Task<string> GetSeriesJson(CancellationToken token, SerieQueryParameter parameters = null);
        Task<MarvelResponse<Serie>> GetSeries(CancellationToken token, SerieQueryParameter parameters = null);

        Task<string> GetSerieJson(int serieId, CancellationToken token);
        Task<MarvelResponse<Serie>> GetSerie(int serieId, CancellationToken token);

        Task<string> GetSerieCharactersJson(int serieId, CancellationToken token, CharacterBySerieQueryParameter parameters = null);
        Task<MarvelResponse<Character>> GetSerieCharacters(int serieId, CancellationToken token, CharacterBySerieQueryParameter parameters = null);

        Task<string> GetSerieComicsJson(int serieId, CancellationToken token, ComicBySerieQueryParameter parameters = null);
        Task<MarvelResponse<Comic>> GetSerieComics(int serieId, CancellationToken token, ComicBySerieQueryParameter parameters = null);

        Task<string> GetSerieCreatorsJson(int serieId, CancellationToken token, CreatorBySerieQueryParameter parameters = null);
        Task<MarvelResponse<Creator>> GetSerieCreators(int serieId, CancellationToken token, CreatorBySerieQueryParameter parameters = null);

        Task<string> GetSerieEventsJson(int serieId, CancellationToken token, EventsBySerieQueryParameter parameters = null);
        Task<MarvelResponse<Event>> GetSerieEvents(int serieId, CancellationToken token, EventsBySerieQueryParameter parameters = null);

        Task<string> GetSerieStoriesJson(int serieId, CancellationToken token, StoryBySerieQueryParameter parameters = null);
        Task<MarvelResponse<Story>> GetSerieStories(int serieId, CancellationToken token, StoryBySerieQueryParameter parameters = null);
    }
}