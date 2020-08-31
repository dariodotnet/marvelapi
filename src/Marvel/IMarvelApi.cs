namespace Marvel
{
    using Model;
    using Refit;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IMarvelApi
    {
        [Get("/characters")]
        Task<HttpResponseMessage> GetCharacters(CharacterQueryParameter parameters, CancellationToken token);

        [Get("/characters/{characterId}")]
        Task<HttpResponseMessage> GetCharacter(int characterId, CancellationToken token);
    }
}