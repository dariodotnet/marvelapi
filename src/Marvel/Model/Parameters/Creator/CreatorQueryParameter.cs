namespace Marvel.Model
{
    using Refit;
    using System.Linq;

    public class CreatorQueryParameter : CreatorBaseQueryParameter
    {
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

        public int[] StoryArray { get; set; }

        [AliasAs("stories")]
        public string Stories => StoryArray != null && StoryArray.Any()
            ? string.Join(",", StoryArray) : null;
    }
}