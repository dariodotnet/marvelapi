﻿namespace Marvel.Model
{
    using Refit;
    using System.Linq;

    public class ComicQueryParameter : ComicBaseQueryParameter
    {
        public int[] CreatorsArray { get; set; }

        [AliasAs("creators")]
        public string Creators => CreatorsArray != null && CreatorsArray.Any()
            ? string.Join(",", CreatorsArray) : null;
    }
}