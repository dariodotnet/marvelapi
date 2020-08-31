namespace Marvel.Model
{
    using Newtonsoft.Json;

    public class TextObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}