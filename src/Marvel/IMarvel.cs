namespace Marvel
{
    using Model;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMarvel
    {
        Task<string> GetCharactersJson(CancellationToken token);
        Task<ApiDataWrapper> GetCharacters(CancellationToken token);
    }
}