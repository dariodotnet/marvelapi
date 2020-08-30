namespace Marvel.Tests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Model;
    using NUnit.Framework;

    public class MarvelFailedTests
    {
        [TestCase("", "")]
        [TestCase("FORCEERROR", "PRIVATEFORCEERROR")]
        [TestCase("e8d935593f01ada9059e3c8f32b03", "5cb13e19d0cf94e8f26e9ad912507af76f7f9c")]
        public async Task Api_Should_Fail_Invalid_Key(string publicKey, string privateKey)
        {
            var marvel = new Marvel(publicKey, privateKey);

            var exception = Assert
                .ThrowsAsync<MarvelError>(async () => await marvel.GetCharactersJson(new CancellationToken()));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exception.message.Equals(ErrorConstants.Message.ApiKeyInvalid));
        }

        [TestCase("e8d935593f01ada9059e3c8f32b03cb0", "5cb13e19d0cf94e8f26e9ad912507af76f7f9c")]
        public async Task Api_Should_Fail_Invalid_Hash(string publicKey, string privateKey)
        {
            var marvel = new Marvel(publicKey, privateKey);

            var exception = Assert
                .ThrowsAsync<MarvelError>(async () => await marvel.GetCharactersJson(new CancellationToken()));

            Assert.That(exception.code.Equals(ErrorConstants.Code.InvalidCredentials));
            Assert.That(exception.message.Equals(ErrorConstants.Message.ApiInvalidHash));
        }
    }
}