namespace Marvel.Model
{
    using Newtonsoft.Json;

    public class Thumbnail
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonIgnore]
        public string ImageUrl => $"{Path}{Extension}";
    }
}