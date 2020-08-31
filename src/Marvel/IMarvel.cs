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
    }
}