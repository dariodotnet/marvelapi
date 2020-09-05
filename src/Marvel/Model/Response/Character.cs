namespace Marvel.Model
{
    using Newtonsoft.Json;
    using System;

    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

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