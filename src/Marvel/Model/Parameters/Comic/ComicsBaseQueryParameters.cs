namespace Marvel.Model
{
    using Refit;
    using System;
    using System.Linq;

    public class ComicsBaseQueryParameters
    {
        public ParameterComicFormat Format { get; set; }

        [AliasAs("format")]
        public string ComicFormat => SetFormat(Format);

        public ParameterComicFormatType FormatType { get; set; }

        [AliasAs("formatType")]
        public string ComicFormatType => SetFormatType(FormatType);

        [AliasAs("noVariants")]
        public bool? Variants { get; set; }

        public ParameterComicDateDescriptor DateDescriptor { get; set; }

        [AliasAs("dateDescriptor")]
        public string ComicDateDescriptor => SetDateDescriptor(DateDescriptor);

        public DateTime DateRangeStart { get; set; }
        public DateTime DateRangeEnd { get; set; }

        [AliasAs("dateRange")]
        public string DateRange => DateRangeStart != default && DateRangeEnd != default
            ? $"{DateRangeStart:YYYY-MM-DD},{DateRangeEnd:YYYY-MM-DD}"
            : null;

        [AliasAs("title")]
        public string Title { get; set; }

        [AliasAs("titleStartsWith")]
        public string TitleStartsWith { get; set; }

        [AliasAs("startYear")]
        public int? StartYear { get; set; }

        [AliasAs("issueNumber")]
        public int? IssueNumber { get; set; }

        [AliasAs("diamondCode")]
        public string DiamondCode { get; set; }

        [AliasAs("digitalId")]
        public int? DigitalId { get; set; }

        [AliasAs("upc")]
        public string Upc { get; set; }

        [AliasAs("isbn")]
        public string Isbn { get; set; }

        [AliasAs("ean")]
        public string Ean { get; set; }

        [AliasAs("issn")]
        public string Issn { get; set; }

        [AliasAs("hasDigitalIssue")]
        public bool? HasDigitalIssue { get; set; }

        public DateTime ModifiedSinceDateTime { get; set; }

        [AliasAs("modifiedSince")]
        public string ModifiedSince => ModifiedSinceDateTime != default
            ? ModifiedSinceDateTime.ToString("YYYY-MM-DD") : null;

        public int[] SerieArray { get; set; }

        [AliasAs("series")]
        public string Series => SerieArray != null && SerieArray.Any()
            ? string.Join(",", SerieArray) : null;

        public int[] EventArray { get; set; }

        [AliasAs("events")]
        public string Events => EventArray != null && EventArray.Any()
            ? string.Join(",", EventArray) : null;

        public int[] StoryArray { get; set; }

        [AliasAs("stories")]
        public string Stories => StoryArray != null && StoryArray.Any()
            ? string.Join(",", StoryArray) : null;

        public int[] SharedAppearanceArray { get; set; }

        [AliasAs("sharedAppearances")]
        public string sharedAppearances => SharedAppearanceArray != null && SharedAppearanceArray.Any()
            ? string.Join(",", SharedAppearanceArray) : null;

        public int[] CollaboratorArray { get; set; }

        [AliasAs("collaborators")]
        public string Collaborators => CollaboratorArray != null && CollaboratorArray.Any()
            ? string.Join(",", CollaboratorArray) : null;

        public ParameterComicOrder ComicOrder { get; set; }

        [AliasAs("orderBy")]
        public string OrderBy => SetOrder(ComicOrder);

        [AliasAs("limit")]
        public int Limit { get; set; } = 20;

        [AliasAs("offset")]
        public int Offset { get; set; }

        private string SetFormat(ParameterComicFormat format)
        {
            switch (format)
            {
                case ParameterComicFormat.Comic:
                    return "comic";
                case ParameterComicFormat.Magazine:
                    return "magazine";
                case ParameterComicFormat.TradePaperback:
                    return "trade paperback";
                case ParameterComicFormat.HardCover:
                    return "hardcover";
                case ParameterComicFormat.Digest:
                    return "digest";
                case ParameterComicFormat.GraphicNovel:
                    return "graphic novel";
                case ParameterComicFormat.DigitalComic:
                    return "digital comic";
                case ParameterComicFormat.InfiniteComic:
                    return "infinite comic";
                default:
                    return null;
            }
        }

        private string SetFormatType(ParameterComicFormatType formatType)
        {
            switch (formatType)
            {
                case ParameterComicFormatType.Comic:
                    return "comic";
                case ParameterComicFormatType.Collection:
                    return "collection";
                default:
                    return null;
            }
        }

        private string SetDateDescriptor(ParameterComicDateDescriptor dateDescriptor)
        {
            switch (dateDescriptor)
            {
                case ParameterComicDateDescriptor.LastWeek:
                    return "lastWeek";
                case ParameterComicDateDescriptor.ThisWeek:
                    return "thisWeek";
                case ParameterComicDateDescriptor.NextWeek:
                    return "nextWeek";
                case ParameterComicDateDescriptor.ThisMonth:
                    return "thisMonth";
                default:
                    return null;
            }
        }

        private string SetOrder(ParameterComicOrder comicOrder)
        {
            switch (comicOrder)
            {
                case ParameterComicOrder.ByFocDate:
                    return "focDate";
                case ParameterComicOrder.ByOnSaleDate:
                    return "onsaleDate";
                case ParameterComicOrder.ByTitle:
                    return "title";
                case ParameterComicOrder.ByIssueNumber:
                    return "issueNumber";
                case ParameterComicOrder.ByModified:
                    return "modified";
                case ParameterComicOrder.ByFocDateDescending:
                    return "-focDate";
                case ParameterComicOrder.ByOnSaleDateDescending:
                    return "-onsaleDate";
                case ParameterComicOrder.ByTitleDescending:
                    return "-title";
                case ParameterComicOrder.ByIssueNumberDescending:
                    return "-issueNumber";
                case ParameterComicOrder.ByModifiedDescending:
                    return "-modified";
                default:
                    return null;
            }
        }
    }
}