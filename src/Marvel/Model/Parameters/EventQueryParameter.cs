namespace Marvel.Model
{
    using Refit;
    using System;
    using System.Linq;

    public class EventQueryParameter
    {
        [AliasAs("name")]
        public string Name { get; set; }

        [AliasAs("nameStartsWith")]
        public string NameStartsWith { get; set; }

        public DateTime ModifiedSinceDateTime { get; set; }

        [AliasAs("modifiedSince")]
        public string ModifiedSince => ModifiedSinceDateTime != default
            ? ModifiedSinceDateTime.ToString("YYYY-MM-DD") : null;

        public int[] CreatorsArray { get; set; }

        [AliasAs("creators")]
        public string Creators => CreatorsArray != null && CreatorsArray.Any()
            ? string.Join(",", CreatorsArray) : null;

        public int[] SerieArray { get; set; }

        [AliasAs("series")]
        public string Series => SerieArray != null && SerieArray.Any()
            ? string.Join(",", SerieArray) : null;

        public int[] ComicArray { get; set; }

        [AliasAs("comics")]
        public string Comics => ComicArray != null && ComicArray.Any()
            ? string.Join(",", ComicArray) : null;

        public int[] StoryArray { get; set; }

        [AliasAs("stories")]
        public string Stories => StoryArray != null && StoryArray.Any()
            ? string.Join(",", StoryArray) : null;

        public ParameterEventOrder EventOrder { get; set; }

        [AliasAs("orderBy")]
        public string OrderBy => SetOrder(EventOrder);

        [AliasAs("limit")]
        public int Limit { get; set; } = 20;

        [AliasAs("offset")]
        public int Offset { get; set; }

        private string SetOrder(ParameterEventOrder eventOrder)
        {
            switch (eventOrder)
            {
                case ParameterEventOrder.ByName:
                    return "name";
                case ParameterEventOrder.ByStartDate:
                    return "startDate";
                case ParameterEventOrder.ByModified:
                    return "modified";
                case ParameterEventOrder.ByNameDescending:
                    return "-name";
                case ParameterEventOrder.ByStartDateDescending:
                    return "-startDate";
                case ParameterEventOrder.ByModifiedDescending:
                    return "-modified";
                default:
                    return null;
            }
        }
    }
}