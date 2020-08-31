namespace Marvel.Model
{
    using Newtonsoft.Json;

    public class Date
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("date")]
        public object DateTime { get; set; }
    }
}