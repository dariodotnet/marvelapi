namespace Marvel.Model
{
    using Newtonsoft.Json;

    public class Url
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string UrlPath { get; set; }
    }
}