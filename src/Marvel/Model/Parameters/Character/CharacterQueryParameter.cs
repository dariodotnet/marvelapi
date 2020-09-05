﻿namespace Marvel.Model
{
    using Refit;
    using System;
    using System.Linq;

    public class CharacterQueryParameter : CharacterByComicQueryParameter
    {
        public int[] ComicArray { get; set; }

        [AliasAs("comics")]
        public string Comics => ComicArray != null && ComicArray.Any()
            ? string.Join(",", ComicArray) : null;
    }

    public class CharacterByComicQueryParameter
    {
        [AliasAs("name")]
        public string Name { get; set; }

        [AliasAs("nameStartsWith")]
        public string NameStartsWith { get; set; }

        public DateTime? ModifiedSince { get; set; }

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