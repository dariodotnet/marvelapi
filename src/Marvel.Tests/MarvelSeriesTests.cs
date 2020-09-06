namespace Marvel.Tests
{
    using NUnit.Framework;
    using System.Threading;
    using System.Threading.Tasks;

    public class MarvelSeriesTests
    {
        private IMarvel _marvel;

        [SetUp]
        public void Setup()
        {
            _marvel = new Marvel("e8d935593f01ada9059e3c8f32b03cb0", "5cb13e19d0cf94e8f26e9ad912507af76f7f9cec", true);
        }

        [Test]
        public async Task Api_Should_Connect_And_Get_Series()
        {
            var json = await _marvel.GetSeriesJson(new CancellationToken());

            Assert.NotNull(json);

            var series = await _marvel.GetSeries(new CancellationToken());

            Assert.NotNull(series);
        }

        //[Test]
        //public async Task Api_Should_Get_First_Event()
        //{
        //    var events = await _marvel.GetEvents(new CancellationToken());
        //    Assert.NotNull(events);
        //    var creator = events.Container.Results.FirstOrDefault();
        //    Assert.NotNull(creator);
        //    var json = await _marvel.GetEventJson(creator.Id, new CancellationToken());
        //    Assert.NotNull(json);
        //    var model = await _marvel.GetEvent(creator.Id, new CancellationToken());
        //    Assert.NotNull(model);
        //}

        //[Test]
        //public async Task Api_Should_Get_Characters_For_First_Event()
        //{
        //    var events = await _marvel.GetEvents(new CancellationToken());
        //    Assert.NotNull(events);
        //    var firstEvent = events.Container.Results.FirstOrDefault();
        //    Assert.NotNull(firstEvent);

        //    var json = await _marvel.GetEventCharactersJson(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(json);

        //    var model = await _marvel.GetEventCharacters(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(model);
        //}

        //[Test]
        //public async Task Api_Should_Get_Comics_For_First_Event()
        //{
        //    var events = await _marvel.GetEvents(new CancellationToken());
        //    Assert.NotNull(events);
        //    var firstEvent = events.Container.Results.FirstOrDefault();
        //    Assert.NotNull(firstEvent);

        //    var json = await _marvel.GetEventComicsJson(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(json);

        //    var model = await _marvel.GetEventComics(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(model);
        //}

        //[Test]
        //public async Task Api_Should_Get_Creators_For_First_Event()
        //{
        //    var events = await _marvel.GetEvents(new CancellationToken());
        //    Assert.NotNull(events);
        //    var firstEvent = events.Container.Results.FirstOrDefault();
        //    Assert.NotNull(firstEvent);

        //    var json = await _marvel.GetEventCreatorsJson(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(json);

        //    var model = await _marvel.GetEventCreators(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(model);
        //}

        //[Test]
        //public async Task Api_Should_Get_Series_For_First_Event()
        //{
        //    var events = await _marvel.GetEvents(new CancellationToken());
        //    Assert.NotNull(events);
        //    var firstEvent = events.Container.Results.FirstOrDefault();
        //    Assert.NotNull(firstEvent);

        //    var json = await _marvel.GetEventSeriesJson(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(json);

        //    var model = await _marvel.GetEventSeries(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(model);
        //}

        //[Test]
        //public async Task Api_Should_Get_Stories_For_First_Event()
        //{
        //    var events = await _marvel.GetEvents(new CancellationToken());
        //    Assert.NotNull(events);
        //    var firstEvent = events.Container.Results.FirstOrDefault();
        //    Assert.NotNull(firstEvent);

        //    var json = await _marvel.GetEventStoriesJson(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(json);

        //    var model = await _marvel.GetEventStories(firstEvent.Id, new CancellationToken());
        //    Assert.NotNull(model);
        //}
    }
}