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

        Task<string> GetCharacterEventsJson(int characterId, CancellationToken token, EventQueryParameter parameter = null);
        Task<MarvelResponse<Event>> GetCharacterEvents(int characterId, CancellationToken token, EventQueryParameter parameter = null);

        Task<string> GetCharacterSeriesJson(int characterId, CancellationToken token, SerieQueryParameter parameters = null);
        Task<MarvelResponse<Serie>> GetCharacterSeries(int characterId, CancellationToken token, SerieQueryParameter parameters = null);

        Task<string> GetCharacterStoriesJson(int characterId, CancellationToken token, StoryQueryParameter parameters = null);
        Task<MarvelResponse<Story>> GetCharacterStories(int characterId, CancellationToken token, StoryQueryParameter parameters = null);

        Task<string> GetComicsJson(CancellationToken token, ComicQueryParameter parameters = null);
        Task<MarvelResponse<Comic>> GetComics(CancellationToken token, ComicQueryParameter parameters = null);

        Task<string> GetComicJson(int comicId, CancellationToken token);
        Task<MarvelResponse<Comic>> GetComic(int comicId, CancellationToken token);

        Task<string> GetComicCharactersJson(int comicId, CancellationToken token, CharacterByComicQueryParameter parameter = null);
        Task<MarvelResponse<Character>> GetComicCharacters(int comicId, CancellationToken token, CharacterByComicQueryParameter parameter = null);

        Task<string> GetComicCreatorsJson(int comicId, CancellationToken token, CreatorQueryParameter parameter = null);
        Task<MarvelResponse<Creator>> GetComicCreators(int comicId, CancellationToken token, CreatorQueryParameter parameter = null);
    }
}