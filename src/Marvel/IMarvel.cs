namespace Marvel
{
    using Model;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMarvel
    {
        Task<string> GetCharactersJson(CancellationToken token, CharacterQueryParameter parameter = null);
        Task<MarvelResponse<Character>> GetCharacters(CancellationToken token, CharacterQueryParameter parameter = null);

        Task<string> GetCharacterJson(int characterId, CancellationToken token);
        Task<MarvelResponse<Character>> GetCharacter(int characterId, CancellationToken token);

        Task<string> GetCharacterComicsJson(int characterId, CancellationToken token, ComicQueryParameter parameter = null);
        Task<MarvelResponse<Comic>> GetCharacterComics(int characterId, CancellationToken token, ComicQueryParameter parameter = null);

        Task<string> GetCharacterEventsJson(int characterId, CancellationToken token, EventQueryParameter parameter = null);
        Task<MarvelResponse<Event>> GetCharacterEvents(int characterId, CancellationToken token, EventQueryParameter parameter = null);

        Task<string> GetCharacterSeriesJson(int characterId, CancellationToken token, SerieQueryParameter parameters = null);
        Task<MarvelResponse<Serie>> GetCharacterSeries(int characterId, CancellationToken token, SerieQueryParameter parameters = null);

        Task<string> GetCharacterStoriesJson(int characterId, CancellationToken token, StoryQueryParameter parameters = null);
        Task<MarvelResponse<Story>> GetCharacterStories(int characterId, CancellationToken token, StoryQueryParameter parameters = null);
    }
}