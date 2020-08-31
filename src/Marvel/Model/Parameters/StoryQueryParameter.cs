namespace Marvel.Model
{
    using Refit;
    using System;
    using System.Linq;

    public class StoryQueryParameter
    {
        public DateTime ModifiedSinceDateTime { get; set; }

        [AliasAs("modifiedSince")]
        public string ModifiedSince => ModifiedSinceDateTime != default
            ? ModifiedSinceDateTime.ToString("YYYY-MM-DD") : null;

        public int[] ComicArray { get; set; }

        [AliasAs("comics")]
        public string Comics => ComicArray != null && ComicArray.Any()
            ? string.Join(",", ComicArray) : null;

        public int[] SerieArray { get; set; }

        [AliasAs("series")]
        public string Series => SerieArray != null && SerieArray.Any()
            ? string.Join(",", SerieArray) : null;

        public int[] EventArray { get; set; }

        [AliasAs("events")]
        public string Events => EventArray != null && EventArray.Any()
            ? string.Join(",", EventArray) : null;

        public int[] CreatorsArray { get; set; }

        [AliasAs("creators")]
        public string Creators => CreatorsArray != null && CreatorsArray.Any()
            ? string.Join(",", CreatorsArray) : null;

        public ParameterStoryOrder StoryOrder { get; set; }

        [AliasAs("orderBy")]
        public string OrderBy => SetOrder(StoryOrder);

        [AliasAs("limit")]
        public int Limit { get; set; } = 20;

        [AliasAs("offset")]
        public int Offset { get; set; }

        private string SetOrder(ParameterStoryOrder storyOrder)
        {
            switch (storyOrder)
            {
                case ParameterStoryOrder.ById:
                    return "id";
                case ParameterStoryOrder.ByModified:
                    return "modified";
                case ParameterStoryOrder.ByIdDescending:
                    return "-id";
                case ParameterStoryOrder.ByModifiedDescending:
                    return "-modified";
                default:
                    return null;
            }
        }
    }
}