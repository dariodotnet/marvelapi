namespace Marvel.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MarvelCreatorsTests
    {
        private IMarvel _marvel;

        [SetUp]
        public void Setup()
        {
            _marvel = new Marvel("e8d935593f01ada9059e3c8f32b03cb0", "5cb13e19d0cf94e8f26e9ad912507af76f7f9cec", true);
        }

        [Test]
        public async Task Api_Should_Connect_And_Get_Creators()
        {
            var json = await _marvel.GetCreatorsJson(new CancellationToken());

            Assert.NotNull(json);

            var creators = await _marvel.GetCreators(new CancellationToken());

            Assert.NotNull(creators);
        }

        [Test]
        public async Task Api_Should_Get_First_Creator()
        {
            var creators = await _marvel.GetCreators(new CancellationToken());
            Assert.NotNull(creators);
            var creator = creators.Container.Results.FirstOrDefault();
            Assert.NotNull(creator);
            var json = await _marvel.GetCreatorJson(creator.Id, new CancellationToken());
            Assert.NotNull(json);
            var model = await _marvel.GetCreator(creator.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Comics_For_First_Creator()
        {
            var creators = await _marvel.GetCreators(new CancellationToken());
            Assert.NotNull(creators);
            var creator = creators.Container.Results.FirstOrDefault();
            Assert.NotNull(creator);
            var json = await _marvel.GetCreatorComicsJson(creator.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetCreatorComics(creator.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Events_For_First_Creator()
        {
            var creators = await _marvel.GetCreators(new CancellationToken());
            Assert.NotNull(creators);
            var creator = creators.Container.Results.FirstOrDefault();
            Assert.NotNull(creator);
            var json = await _marvel.GetCreatorEventsJson(creator.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetCreatorEvents(creator.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Series_For_First_Creator()
        {
            var creators = await _marvel.GetCreators(new CancellationToken());
            Assert.NotNull(creators);
            var creator = creators.Container.Results.FirstOrDefault();
            Assert.NotNull(creator);
            var json = await _marvel.GetCreatorSeriesJson(creator.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetCreatorSeries(creator.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Stories_For_First_Creator()
        {
            var creators = await _marvel.GetCreators(new CancellationToken());
            Assert.NotNull(creators);
            var creator = creators.Container.Results.FirstOrDefault();
            Assert.NotNull(creator);
            var json = await _marvel.GetCreatorStoriesJson(creator.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetCreatorStories(creator.Id, new CancellationToken());
            Assert.NotNull(model);
        }
    }
}