namespace Marvel.Model
{
    using System;
    using Newtonsoft.Json;

    public class Story
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("creators")]
        public ItemList Creators { get; set; }

        [JsonProperty("characters")]
        public ItemList Characters { get; set; }

        [JsonProperty("series")]
        public ItemList Series { get; set; }

        [JsonProperty("comics")]
        public ItemList Comics { get; set; }

        [JsonProperty("events")]
        public ItemList Events { get; set; }

        [JsonProperty("originalIssue")]
        public Item OriginalIssue { get; set; }
    }
}