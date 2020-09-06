namespace Marvel.Model
{
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SeriesBaseQueryParameters
    {
        [AliasAs("title")]
        public string Title { get; set; }

        [AliasAs("titleStartsWith")]
        public string TitleStartsWith { get; set; }

        [AliasAs("startYear")]
        public int? StartYear { get; set; }

        public DateTime ModifiedSinceDateTime { get; set; }

        [AliasAs("modifiedSince")]
        public string ModifiedSince => ModifiedSinceDateTime != default
            ? ModifiedSinceDateTime.ToString("YYYY-MM-DD") : null;

        public ParameterSeriesType SeriesType { get; set; }

        [AliasAs("seriesType")]
        public string SerieType => SetSeriesType(SeriesType);

        public ParameterComicFormat[] FormatArray { get; set; }

        [AliasAs("contains")]
        public string Contain => FormatArray != null && FormatArray.Any()
            ? string.Join(",", GetFormat(FormatArray))
            : null;

        public ParameterSeriesOrder SeriesOrder { get; set; }

        [AliasAs("orderBy")]
        public string OrderBy => SetOrder(SeriesOrder);

        [AliasAs("limit")]
        public int Limit { get; set; } = 20;

        [AliasAs("offset")]
        public int Offset { get; set; }

        private string SetSeriesType(ParameterSeriesType seriesType)
        {
            switch (seriesType)
            {
                case ParameterSeriesType.Collection:
                    return "collection";
                case ParameterSeriesType.OneShot:
                    return "one shot";
                case ParameterSeriesType.Limited:
                    return "limited";
                case ParameterSeriesType.OnGoing:
                    return "ongoing";
                default:
                    return null;
            }
        }

        private IEnumerable<string> GetFormat(ParameterComicFormat[] formatArray)
        {
            var result = new List<string>();

            foreach (var format in formatArray)
            {
                switch (format)
                {
                    case ParameterComicFormat.Comic:
                        result.Add("comic");
                        break;
                    case ParameterComicFormat.Magazine:
                        result.Add("magazine");
                        break;
                    case ParameterComicFormat.TradePaperback:
                        result.Add("trade paperback");
                        break;
                    case ParameterComicFormat.HardCover:
                        result.Add("hardcover");
                        break;
                    case ParameterComicFormat.Digest:
                        result.Add("digest");
                        break;
                    case ParameterComicFormat.GraphicNovel:
                        result.Add("graphic novel");
                        break;
                    case ParameterComicFormat.DigitalComic:
                        result.Add("digital comic");
                        break;
                    case ParameterComicFormat.InfiniteComic:
                        result.Add("infinite comic");
                        break;
                }
            }

            return result;
        }

        private string SetOrder(ParameterSeriesOrder seriesOrder)
        {
            switch (seriesOrder)
            {
                case ParameterSeriesOrder.ByTitle:
                    return "title";
                case ParameterSeriesOrder.ByModified:
                    return "modified";
                case ParameterSeriesOrder.ByStartYear:
                    return "startYear";
                case ParameterSeriesOrder.ByTitleDescending:
                    return "-title";
                case ParameterSeriesOrder.ByModifiedDescending:
                    return "-modified";
                case ParameterSeriesOrder.ByStartYearDescending:
                    return "-startYear";
                default:
                    return null;
            }
        }
    }
}