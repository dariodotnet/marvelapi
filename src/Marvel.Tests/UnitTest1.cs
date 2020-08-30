namespace Marvel.Tests
{
    using Model;
    using NUnit.Framework;
    using System.Threading;
    using System.Threading.Tasks;

    public class Tests
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
            var characters = await _marvel.GetCharacters(new CancellationToken());

            Assert.AreNotEqual(characters, null);
        }

        [Test]
        public async Task Api_Should_Connect_And_Get_Characters()
        {
            ApiDataWrapper characters = await _marvel.GetCharactersDto(new CancellationToken());

            Assert.AreNotEqual(characters, null);
        }
    }
}