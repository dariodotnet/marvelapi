namespace Marvel.Model
{
    using Refit;
    using System;

    public class StoryBaseQueryParameter
    {
        public DateTime ModifiedSinceDateTime { get; set; }

        [AliasAs("modifiedSince")]
        public string ModifiedSince => ModifiedSinceDateTime != default
            ? ModifiedSinceDateTime.ToString("YYYY-MM-DD") : null;

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