﻿namespace Marvel.Model
{
    using Newtonsoft.Json;
    using System;

    public class Serie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("urls")]
        public Url[] Urls { get; set; }

        [JsonProperty("startYear")]
        public int StartYear { get; set; }

        [JsonProperty("endYear")]
        public int EndYear { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("modified")]
        public string ModifiedString { get; set; }

        public DateTime Modified => GetModified(ModifiedString);

        private DateTime GetModified(string modifiedString)
        {
            DateTime result;
            DateTime.TryParse(modifiedString, out result);
            return result;
        }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("creators")]
        public ItemList Creators { get; set; }

        [JsonProperty("characters")]
        public ItemList Characters { get; set; }

        [JsonProperty("stories")]
        public ItemList Stories { get; set; }

        [JsonProperty("comics")]
        public ItemList Comics { get; set; }

        [JsonProperty("events")]
        public ItemList Events { get; set; }

        [JsonProperty("next")]
        public Item Next { get; set; }

        [JsonProperty("previous")]
        public Item Previous { get; set; }
    }
}