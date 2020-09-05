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
        Task<HttpResponseMessage> GetCharacterComics(int characterId, ComicByCharacterQueryParameter parameters, CancellationToken token);

        [Get("/characters/{characterId}/events")]
        Task<HttpResponseMessage> GetCharacterEvents(int characterId, EventByCharacterQueryParameter parameters, CancellationToken token);

        [Get("/characters/{characterId}/series")]
        Task<HttpResponseMessage> GetCharacterSeries(int characterId, SerieByCharacterQueryParameter parameters, CancellationToken token);

        [Get("/characters/{characterId}/stories")]
        Task<HttpResponseMessage> GetCharacterStories(int characterId, StoryByCharacterQueryParameter parameters, CancellationToken token);


        [Get("/comics")]
        Task<HttpResponseMessage> GetComics(ComicQueryParameter parameters, CancellationToken token);

        [Get("/comics/{comicId}")]
        Task<HttpResponseMessage> GetComic(int comicId, CancellationToken token);

        [Get("/comics/{comicId}/characters")]
        Task<HttpResponseMessage> GetComicCharacters(int comicId, CharacterByComicQueryParameter parameter, CancellationToken token);

        [Get("/comics/{comicId}/creators")]
        Task<HttpResponseMessage> GetComicCreators(int comicId, CreatorQueryParameter parameter, CancellationToken token);

        [Get("/comics/{comicId}/events")]
        Task<HttpResponseMessage> GetComicEvents(int comicId, EventByComicQueryParameter parameter, CancellationToken token);

        [Get("/comics/{comicId}/stories")]
        Task<HttpResponseMessage> GetComicStories(int comicId, StoryByComicQueryParameter parameter, CancellationToken token);


        [Get("/creators")]
        Task<HttpResponseMessage> GetCreators(CreatorQueryParameter parameters, CancellationToken token);

        [Get("/creators/{creatorId}")]
        Task<HttpResponseMessage> GetCreator(int creatorId, CancellationToken token);

        [Get("/creators/{creatorId}/comics")]
        Task<HttpResponseMessage> GetCreatorComics(int creatorId, ComicByCreatorQueryParameter parameters, CancellationToken token);

        [Get("/creators/{creatorId}/events")]
        Task<HttpResponseMessage> GetCreatorEvents(int creatorId, EventByComicQueryParameter parameters, CancellationToken token);

        [Get("/creators/{creatorId}/series")]
        Task<HttpResponseMessage> GetCreatorSeries(int creatorId, SerieByCreatorQueryParameter parameters, CancellationToken token);

        [Get("/creators/{creatorId}/stories")]
        Task<HttpResponseMessage> GetCreatorStories(int creatorId, StoryByCreatorQueryParameter parameters, CancellationToken token);


        [Get("/events")]
        Task<HttpResponseMessage> GetEvents(EventQueryParameter parameters, CancellationToken token);

        [Get("/events/{eventId}")]
        Task<HttpResponseMessage> GetEvent(int eventId, CancellationToken token);
    }
}