namespace Marvel.Tests
{
    using NUnit.Framework;
    using System.Linq;
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

        [Test]
        public async Task Api_Should_Get_First_Event()
        {
            var events = await _marvel.GetSeries(new CancellationToken());
            Assert.NotNull(events);
            var serie = events.Container.Results.FirstOrDefault();
            Assert.NotNull(serie);
            var json = await _marvel.GetSerieJson(serie.Id, new CancellationToken());
            Assert.NotNull(json);
            var model = await _marvel.GetSerie(serie.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Characters_For_First_Event()
        {
            var series = await _marvel.GetSeries(new CancellationToken());
            Assert.NotNull(series);
            var serie = series.Container.Results.FirstOrDefault();
            Assert.NotNull(serie);

            var json = await _marvel.GetSerieCharactersJson(serie.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetSerieCharacters(serie.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Comics_For_First_Event()
        {
            var series = await _marvel.GetSeries(new CancellationToken());
            Assert.NotNull(series);
            var serie = series.Container.Results.FirstOrDefault();
            Assert.NotNull(serie);

            var json = await _marvel.GetSerieComicsJson(serie.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetSerieComics(serie.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Creators_For_First_Event()
        {
            var series = await _marvel.GetSeries(new CancellationToken());
            Assert.NotNull(series);
            var serie = series.Container.Results.FirstOrDefault();
            Assert.NotNull(serie);

            var json = await _marvel.GetSerieCreatorsJson(serie.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetSerieCreators(serie.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Events_For_First_Event()
        {
            var series = await _marvel.GetSeries(new CancellationToken());
            Assert.NotNull(series);
            var serie = series.Container.Results.FirstOrDefault();
            Assert.NotNull(serie);

            var json = await _marvel.GetSerieEventsJson(serie.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetSerieEvents(serie.Id, new CancellationToken());
            Assert.NotNull(model);
        }

        [Test]
        public async Task Api_Should_Get_Stories_For_First_Event()
        {
            var series = await _marvel.GetSeries(new CancellationToken());
            Assert.NotNull(series);
            var serie = series.Container.Results.FirstOrDefault();
            Assert.NotNull(serie);

            var json = await _marvel.GetSerieStoriesJson(serie.Id, new CancellationToken());
            Assert.NotNull(json);

            var model = await _marvel.GetSerieStories(serie.Id, new CancellationToken());
            Assert.NotNull(model);
        }
    }
}