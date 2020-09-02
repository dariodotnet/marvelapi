namespace Marvel.Model
{
    using Refit;
    using System.Linq;

    public class StoryByComicQueryParameter : StoryBaseQueryParameter
    {
        public int[] CharacterArray { get; set; }

        [AliasAs("characters")]
        public string Characters => CharacterArray != null && CharacterArray.Any()
            ? string.Join(",", CharacterArray) : null;
    }
}