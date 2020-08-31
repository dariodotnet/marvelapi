namespace Marvel.Model
{
    using Newtonsoft.Json;

    public class ItemList
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionUri { get; set; }

        [JsonProperty("items")]
        public Item[] items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }
}