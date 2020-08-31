namespace Marvel.Model
{
    using Newtonsoft.Json;

    public class Price
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public float Amount { get; set; }
    }
}