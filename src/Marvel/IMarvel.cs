namespace Marvel
{
    using Model;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMarvel
    {
        Task<string> GetCharactersJson(CancellationToken token, CharacterQueryParameter parameter = null);
        Task<ApiDataWrapper> GetCharacters(CancellationToken token, CharacterQueryParameter parameter = null);
    }
}