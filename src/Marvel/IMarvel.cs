namespace Marvel
{
    using Model;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMarvel
    {
        IMarvel Initialize(string publicKey, string privateKey, bool bypassCertificate = false);

        Task<string> GetCharacters(CancellationToken token);
        Task<ApiDataWrapper> GetCharactersDto(CancellationToken token);
    }
}