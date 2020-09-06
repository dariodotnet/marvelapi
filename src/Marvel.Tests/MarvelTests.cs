namespace Marvel.Tests
{
    using Model;
    using NUnit.Framework;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MarvelTests
    {
        private IMarvel _marvel;

        [SetUp]
        public void Setup()
        {
            _marvel = new Marvel("e8d935593f01ada9059e3c8f32b03cb0", "5cb13e19d0cf94e8f26e9ad912507af76f7f9cec", true);
        }

        [Test]
        public async Task Api_Should_Connect_And_Get_Characters_Json()
        {
            var characters = await _marvel.GetCharactersJson(new CancellationToken());

            Assert.NotNull(characters);
        }

        [Test]
        public async Task Api_Should_Connect_And_Get_Characters()
        {
            var characters = await _marvel.GetCharacters(new CancellationToken());

            Assert.NotNull(characters);
        }

        [Test]
        public async Task Api_Should_Get_FirstCharacter()
        {
            var characters = await _marvel.GetCharacters(new CancellationToken());

            Assert.AreNotEqual(characters, null);

            var first = characters.Container.Results.FirstOrDefault();

            var json = await _marvel.GetCharacterJson(first.Id, new CancellationToken());

            Assert.NotNull(json);

            var character = await _marvel.GetCharacter(first.Id, new CancellationToken());
            Assert.NotNull(json);
        }

        [Test]
        public async Task Api_Should_Get_ComicList_For_First_Character()
        {
            var characters = await _marvel.GetCharacters(new CancellationToken());
            Assert.AreNotEqual(characters, null);
            var first = characters.Container.Results.FirstOrDefault();
            var json = await _marvel.GetCharacterComicsJson(first.Id, new CancellationToken());

            Assert.NotNull(json);

            var comics = await _marvel.GetCharacterComics(first.Id, new CancellationToken());

            Assert.NotNull(comics);
        }

        [Test]
        public async Task Api_Should_Get_EventList_For_First_Character()
        {
            var characters = await _marvel.GetCharacters(new CancellationToken());
            Assert.AreNotEqual(characters, null);
            var first = characters.Container.Results.FirstOrDefault();
            var json = await _marvel.GetCharacterEventsJson(first.Id, new CancellationToken());

            Assert.NotNull(json);

            var events = await _marvel.GetCharacterEvents(first.Id, new CancellationToken());
            Assert.NotNull(events);
        }

        [Test]
        public async Task Api_Should_Get_SerieList_For_First_Character()
        {
            var characters = await _marvel.GetCharacters(new CancellationToken());
            Assert.AreNotEqual(characters, null);
            var first = characters.Container.Results.FirstOrDefault();
            var json = await _marvel.GetCharacterSeriesJson(first.Id, new CancellationToken());

            Assert.NotNull(json);

            var series = await _marvel.GetCharacterSeries(first.Id, new CancellationToken());
            Assert.NotNull(series);
        }

        [Test]
        public async Task Api_Should_Get_StoryList_For_First_Character()
        {
            var characters = await _marvel.GetCharacters(new CancellationToken());
            Assert.AreNotEqual(characters, null);
            var first = characters.Container.Results.FirstOrDefault();
            var json = await _marvel.GetCharacterStoriesJson(first.Id, new CancellationToken());

            Assert.NotNull(json);

            var stories = await _marvel.GetCharacterStories(first.Id, new CancellationToken());
            Assert.NotNull(stories);
        }

        [Test]
        public async Task Api_Should_Get_Comics()
        {
            var json = await _marvel.GetComicsJson(new CancellationToken());
            Assert.NotNull(json);
            var comics = await _marvel.GetComics(new CancellationToken());
            Assert.NotNull(comics);
        }

        [Test]
        public async Task Api_Should_Get_FirstComic()
        {
            var comics = await _marvel.GetComics(new CancellationToken());
            Assert.NotNull(comics);

            var first = comics.Container.Results.FirstOrDefault();

            Assert.NotNull(first);

            var json = await _marvel.GetComic(first.Id, new CancellationToken());

            Assert.NotNull(json);

            var comic = await _marvel.GetComic(first.Id, new CancellationToken());

            Assert.NotNull(comic);
        }

        [Test]
        public async Task Api_Should_Get_Characters_For_FirstComic()
        {
            var comics = await _marvel.GetComics(new CancellationToken());
            Assert.NotNull(comics);

            var first = comics.Container.Results.FirstOrDefault();
            Assert.NotNull(first);

            var json = await _marvel.GetComicCharactersJson(first.Id, new CancellationToken());
            Assert.NotNull(json);

            var character = await _marvel.GetComicCharacters(first.Id, new CancellationToken());
            Assert.NotNull(character);
        }

        [Test]
        public async Task Api_Should_Get_Creators_For_FirstComic()
        {
            var comics = await _marvel.GetComics(new CancellationToken());
            Assert.NotNull(comics);

            var first = comics.Container.Results.FirstOrDefault();
            Assert.NotNull(first);

            var json = await _marvel.GetComicCreatorsJson(first.Id, new CancellationToken());
            Assert.NotNull(json);

            var creators = await _marvel.GetComicCreators(first.Id, new CancellationToken());
            Assert.NotNull(creators);
        }

        [Test]
        public async Task Api_Should_Get_Events_For_FirstComic()
        {
            var comics = await _marvel.GetComics(new CancellationToken());
            Assert.NotNull(comics);

            var first = comics.Container.Results.FirstOrDefault();
            Assert.NotNull(first);

            var json = await _marvel.GetComicEventsJson(first.Id, new CancellationToken());
            Assert.NotNull(json);

            var creators = await _marvel.GetComicEvents(first.Id, new CancellationToken());
            Assert.NotNull(creators);
        }

        [Test]
        public async Task Api_Should_Get_Stories_For_FirstComic()
        {
            var comics = await _marvel.GetComics(new CancellationToken());
            Assert.NotNull(comics);

            var first = comics.Container.Results.FirstOrDefault();
            Assert.NotNull(first);

            var json = await _marvel.GetComicStoriesJson(first.Id, new CancellationToken());
            Assert.NotNull(json);

            var creators = await _marvel.GetComicStories(first.Id, new CancellationToken());
            Assert.NotNull(creators);
        }

        [TestCase("", "")]
        [TestCase("FORCEERROR", "PRIVATEFORCEERROR")]
        [TestCase("e8d935593f01ada9059e3c8f32b03", "5cb13e19d0cf94e8f26e9ad912507af76f7f9c")]
        public async Task Api_Should_Throw_MarvelError_Invalid_Key(string publicKey, string privateKey)
        {
            var marvel = new Marvel(publicKey, privateKey);

            var exceptionJson = Assert
                .ThrowsAsync<MarvelException>(async () => await marvel.GetCharactersJson(new CancellationToken()));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exceptionJson.message.Equals(ErrorConstants.Message.ApiKeyInvalid));

            var exception = Assert
                .ThrowsAsync<MarvelException>(async () => await marvel.GetCharacters(new CancellationToken()));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exception.message.Equals(ErrorConstants.Message.ApiKeyInvalid));
        }

        [TestCase("e8d935593f01ada9059e3c8f32b03cb0", "5cb13e19d0cf94e8f26e9ad912507af76f7f9c")]
        public async Task Api_Should_Throw_MarvelError_Invalid_Hash(string publicKey, string privateKey)
        {
            var marvel = new Marvel(publicKey, privateKey);

            var exceptionJson = Assert
                .ThrowsAsync<MarvelException>(async () => await marvel.GetCharactersJson(new CancellationToken()));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exceptionJson.message.Equals(ErrorConstants.Message.ApiInvalidHash));

            var exception = Assert
                .ThrowsAsync<MarvelException>(async () => await marvel.GetCharacters(new CancellationToken()));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exception.message.Equals(ErrorConstants.Message.ApiInvalidHash));
        }

        [Test]
        public async Task Api_Should_Throw_MarvelError_LimitError()
        {
            var parameter = new CharactersQueryParameters { Limit = 250 };

            var exceptionJson = Assert
                .ThrowsAsync<MarvelException>(async () => await _marvel.GetCharactersJson(new CancellationToken(), parameter));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.InvalidParameter));
            Assert.That(exceptionJson.status.Equals(ErrorConstants.Reason.InvalidLimit));

            var exception = Assert
                .ThrowsAsync<MarvelException>(async () => await _marvel.GetCharacters(new CancellationToken(), parameter));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidParameter));
            Assert.That(exception.status.Equals(ErrorConstants.Reason.InvalidLimit));
        }

        [Test]
        public async Task Api_Should_Throw_MarvelError_LimitZeroError()
        {
            var parameter = new CharactersQueryParameters { Limit = 0 };

            var exceptionJson = Assert
                .ThrowsAsync<MarvelException>(async () => await _marvel.GetCharactersJson(new CancellationToken(), parameter));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.InvalidParameter));
            Assert.That(exceptionJson.status.Equals(ErrorConstants.Reason.InvalidZeroLimit));

            var exception = Assert
                .ThrowsAsync<MarvelException>(async () => await _marvel.GetCharacters(new CancellationToken(), parameter));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidParameter));
            Assert.That(exception.status.Equals(ErrorConstants.Reason.InvalidZeroLimit));
        }

        [Test]
        public async Task Api_Should_Throw_MarvelError_CharacterNotFound()
        {
            var exceptionJson = Assert
                .ThrowsAsync<MarvelException>(async () => await _marvel.GetCharacter(10, new CancellationToken()));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.NotFound));
            Assert.That(exceptionJson.status.Equals(ErrorConstants.Reason.CharacterNotFound));
        }
    }
}