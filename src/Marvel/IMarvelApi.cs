namespace Marvel
{
    using Refit;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IMarvelApi
    {
        [Get("/characters")]
        Task<string> GetCharacters(CancellationToken token);
    }
}