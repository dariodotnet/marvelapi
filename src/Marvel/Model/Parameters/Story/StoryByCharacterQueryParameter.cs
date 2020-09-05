namespace Marvel.Model
{
    using Refit;
    using System.Linq;

    public class StoryByCharacterQueryParameter : StoryBaseQueryParameter
    {
        public int[] ComicArray { get; set; }

        [AliasAs("comics")]
        public string Comics => ComicArray != null && ComicArray.Any()
            ? string.Join(",", ComicArray) : null;
    }
}