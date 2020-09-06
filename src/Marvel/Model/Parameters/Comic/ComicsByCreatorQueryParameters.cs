namespace Marvel.Model
{
    using System.Linq;
    using Refit;

    public class ComicsByCreatorQueryParameters : ComicsBaseQueryParameters
    {
        public int[] CharacterArray { get; set; }

        [AliasAs("characters")]
        public string Characters => CharacterArray != null && CharacterArray.Any()
            ? string.Join(",", CharacterArray) : null;
    }
}