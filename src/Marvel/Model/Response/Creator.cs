namespace Marvel.Model
{
    using Newtonsoft.Json;
    using System;

    public class Creator
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("comics")]
        public ItemList Comics { get; set; }

        [JsonProperty("series")]
        public ItemList Series { get; set; }

        [JsonProperty("stories")]
        public ItemList Stories { get; set; }

        [JsonProperty("events")]
        public ItemList Events { get; set; }

        [JsonProperty("urls")]
        public Url[] Urls { get; set; }
    }
}