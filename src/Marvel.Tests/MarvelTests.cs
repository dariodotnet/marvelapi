namespace Marvel.Tests
{
    using Model;
    using NUnit.Framework;
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

            Assert.AreNotEqual(characters, null);
        }

        [Test]
        public async Task Api_Should_Connect_And_Get_Characters()
        {
            ApiDataWrapper characters = await _marvel.GetCharacters(new CancellationToken());

            Assert.AreNotEqual(characters, null);
        }

        [TestCase("", "")]
        [TestCase("FORCEERROR", "PRIVATEFORCEERROR")]
        [TestCase("e8d935593f01ada9059e3c8f32b03", "5cb13e19d0cf94e8f26e9ad912507af76f7f9c")]
        public async Task Api_Should_Throw_MarvelError_Invalid_Key(string publicKey, string privateKey)
        {
            var marvel = new Marvel(publicKey, privateKey);

            var exceptionJson = Assert
                .ThrowsAsync<MarvelError>(async () => await marvel.GetCharactersJson(new CancellationToken()));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exceptionJson.message.Equals(ErrorConstants.Message.ApiKeyInvalid));

            var exception = Assert
                .ThrowsAsync<MarvelError>(async () => await marvel.GetCharacters(new CancellationToken()));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exception.message.Equals(ErrorConstants.Message.ApiKeyInvalid));
        }

        [TestCase("e8d935593f01ada9059e3c8f32b03cb0", "5cb13e19d0cf94e8f26e9ad912507af76f7f9c")]
        public async Task Api_Should_Throw_MarvelError_Invalid_Hash(string publicKey, string privateKey)
        {
            var marvel = new Marvel(publicKey, privateKey);

            var exceptionJson = Assert
                .ThrowsAsync<MarvelError>(async () => await marvel.GetCharactersJson(new CancellationToken()));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exceptionJson.message.Equals(ErrorConstants.Message.ApiInvalidHash));

            var exception = Assert
                .ThrowsAsync<MarvelError>(async () => await marvel.GetCharacters(new CancellationToken()));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exception.message.Equals(ErrorConstants.Message.ApiInvalidHash));
        }

        [Test]
        public async Task Api_Should_Throw_MarvelError_LimitError()
        {
            var parameter = new CharacterQueryParameter { Limit = 250 };

            var exceptionJson = Assert
                .ThrowsAsync<MarvelError>(async () => await _marvel.GetCharactersJson(new CancellationToken(), parameter));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.InvalidParameter));
            Assert.That(exceptionJson.status.Equals(ErrorConstants.Reason.InvalidLimit));

            var exception = Assert
                .ThrowsAsync<MarvelError>(async () => await _marvel.GetCharacters(new CancellationToken(), parameter));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidParameter));
            Assert.That(exception.status.Equals(ErrorConstants.Reason.InvalidLimit));
        }

        [Test]
        public async Task Api_Should_Throw_MarvelError_LimitZeroError()
        {
            var parameter = new CharacterQueryParameter { Limit = 0 };

            var exceptionJson = Assert
                .ThrowsAsync<MarvelError>(async () => await _marvel.GetCharactersJson(new CancellationToken(), parameter));

            Assert.That(exceptionJson.code.Equals(ErrorConstants.Code.InvalidParameter));
            Assert.That(exceptionJson.status.Equals(ErrorConstants.Reason.InvalidZeroLimit));

            var exception = Assert
                .ThrowsAsync<MarvelError>(async () => await _marvel.GetCharacters(new CancellationToken(), parameter));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidParameter));
            Assert.That(exception.status.Equals(ErrorConstants.Reason.InvalidZeroLimit));
        }
    }
}