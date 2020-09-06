namespace Marvel.Model
{
    using Refit;
    using System;

    public class CharactersBaseQueryParameters
    {
        [AliasAs("name")]
        public string Name { get; set; }

        [AliasAs("nameStartsWith")]
        public string NameStartsWith { get; set; }

        public DateTime ModifiedSinceDateTime { get; set; }

        [AliasAs("modifiedSince")]
        public string ModifiedSince => ModifiedSinceDateTime != default
            ? ModifiedSinceDateTime.ToString("YYYY-MM-DD") : null;

        public ParameterCharacterOrder CharacterOrder { get; set; }

        [AliasAs("orderBy")]
        public string OrderBy => SetOrder(CharacterOrder);

        [AliasAs("limit")]
        public int Limit { get; set; } = 20;

        [AliasAs("offset")]
        public int Offset { get; set; }

        private string SetOrder(ParameterCharacterOrder characterOrder)
        {
            switch (characterOrder)
            {
                case ParameterCharacterOrder.ByName:
                    return "name";
                case ParameterCharacterOrder.ByModified:
                    return "modified";
                case ParameterCharacterOrder.ByNameDescending:
                    return "-name";
                case ParameterCharacterOrder.ByModifiedDescending:
                    return "-modified";
                default:
                    return null;
            }
        }
    }
}