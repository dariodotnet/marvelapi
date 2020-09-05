namespace Marvel.Model
{
    using System.Linq;
    using Refit;

    public class SerieByCreatorQueryParameter : SerieBaseQueryParameter
    {
        public int[] ComicArray { get; set; }

        [AliasAs("comics")]
        public string Comics => ComicArray != null && ComicArray.Any()
            ? string.Join(",", ComicArray) : null;

        public int[] StoryArray { get; set; }

        [AliasAs("stories")]
        public string Stories => StoryArray != null && StoryArray.Any()
            ? string.Join(",", StoryArray) : null;

        public int[] EventArray { get; set; }

        [AliasAs("events")]
        public string Events => EventArray != null && EventArray.Any()
            ? string.Join(",", EventArray) : null;

        public int[] CharacterArray { get; set; }

        [AliasAs("characters")]
        public string Characters => CharacterArray != null && CharacterArray.Any()
            ? string.Join(",", CharacterArray) : null;
    }
}