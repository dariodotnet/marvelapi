namespace Marvel.Model
{
    using Refit;
    using System.Linq;

    public class ComicsByStoryQueryParameters : ComicsBaseQueryParameters
    {
        public int[] CreatorsArray { get; set; }

        [AliasAs("creators")]
        public string Creators => CreatorsArray != null && CreatorsArray.Any()
            ? string.Join(",", CreatorsArray) : null;

        public int[] CharacterArray { get; set; }

        [AliasAs("characters")]
        public string Characters => CharacterArray != null && CharacterArray.Any()
            ? string.Join(",", CharacterArray) : null;

        public int[] SerieArray { get; set; }

        [AliasAs("series")]
        public string Series => SerieArray != null && SerieArray.Any()
            ? string.Join(",", SerieArray) : null;

        public int[] EventArray { get; set; }

        [AliasAs("events")]
        public string Events => EventArray != null && EventArray.Any()
            ? string.Join(",", EventArray) : null;
    }
}