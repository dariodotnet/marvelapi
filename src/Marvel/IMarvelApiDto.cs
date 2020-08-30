namespace Marvel
{
    using Model;
    using Refit;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IMarvelApiDto
    {
        [Get("/characters")]
        Task<ApiDataWrapper> GetCharacters(CancellationToken token);
    }
}