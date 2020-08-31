namespace Marvel.Model
{
    using Newtonsoft.Json;

    public class Variant
    {
        [JsonProperty("resourceURI")]
        public string resourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}