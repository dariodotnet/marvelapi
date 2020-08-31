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

        [Get("/characters/{characterId}/comics")]
        Task<HttpResponseMessage> GetCharacterComics(int characterId, ComicQueryParameter parameters, CancellationToken token);

        [Get("/characters/{characterId}/events")]
        Task<HttpResponseMessage> GetCharacterEvents(int characterId, EventQueryParameter parameters, CancellationToken token);

        [Get("/characters/{characterId}/series")]
        Task<HttpResponseMessage> GetCharacterSeries(int characterId, SerieQueryParameter parameters, CancellationToken token);
    }
}