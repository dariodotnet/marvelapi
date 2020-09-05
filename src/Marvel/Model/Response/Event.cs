namespace Marvel.Model
{
    using Newtonsoft.Json;
    using System;

    public class Event
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

        [JsonProperty("modified")]
        public string ModifiedString { get; set; }

        public DateTime Modified => GetModified(ModifiedString);

        private DateTime GetModified(string modifiedString)
        {
            DateTime result;
            DateTime.TryParse(modifiedString, out result);
            return result;
        }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

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

        [JsonProperty("series")]
        public ItemList Series { get; set; }

        [JsonProperty("next")]
        public Item Next { get; set; }

        [JsonProperty("previous")]
        public Item Previous { get; set; }
    }
}