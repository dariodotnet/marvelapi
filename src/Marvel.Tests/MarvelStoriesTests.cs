namespace Marvel.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MarvelStoriesTests
    {
        private IMarvel _marvel;

        [SetUp]
        public void Setup()
        {
            _marvel = new Marvel("e8d935593f01ada9059e3c8f32b03cb0", "5cb13e19d0cf94e8f26e9ad912507af76f7f9cec", true);
        }

        [Test]
        public async Task Api_Should_Connect_And_Get_Stories()
        {
            var json = await _marvel.GetStoriesJson(new CancellationToken());

            Assert.NotNull(json);

            var stories = await _marvel.GetStories(new CancellationToken());

            Assert.NotNull(stories);
        }

        [Test]
        public async Task Api_Should_Get_First_Story()
        {
            var stories = await _marvel.GetStories(new CancellationToken());
            Assert.NotNull(stories);
            var story = stories.Container.Results.FirstOrDefault();
            Assert.NotNull(story);
            var json = await _marvel.GetStoryJson(story.Id, new CancellationToken());
            Assert.NotNull(json);
            var model = await _marvel.GetStory(story.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Characters_For_First_Story()
        {
            var stories = await _marvel.GetStories(new CancellationToken());
            Assert.NotNull(stories);
            var story = stories.Container.Results.FirstOrDefault();
            Assert.NotNull(story);

            var json = await _marvel.GetStoryCharactersJson(story.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetStoryCharacters(story.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Comics_For_First_Story()
        {
            var stories = await _marvel.GetStories(new CancellationToken());
            Assert.NotNull(stories);
            var story = stories.Container.Results.FirstOrDefault();
            Assert.NotNull(story);

            var json = await _marvel.GetStoryComicsJson(story.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetStoryComics(story.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Creators_For_First_Story()
        {
            var stories = await _marvel.GetStories(new CancellationToken());
            Assert.NotNull(stories);
            var story = stories.Container.Results.FirstOrDefault();
            Assert.NotNull(story);

            var json = await _marvel.GetStoryCreatorsJson(story.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetStoryCreators(story.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Events_For_First_Story()
        {
            var stories = await _marvel.GetStories(new CancellationToken());
            Assert.NotNull(stories);
            var story = stories.Container.Results.FirstOrDefault();
            Assert.NotNull(story);

            var json = await _marvel.GetStoryEventsJson(story.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetStoryEvents(story.Id, new CancellationToken());
            Assert.NotNull(model);
        }
    }
}