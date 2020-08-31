namespace Marvel.Model
{
    using Newtonsoft.Json;

    public class Comic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("digitalId")]
        public int DigitalId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("issueNumber")]
        public int IssueNumber { get; set; }

        [JsonProperty("variantDescription")]
        public string VariantDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public object Modified { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("diamondCode")]
        public string DiamondCode { get; set; }

        [JsonProperty("ean")]
        public string Ean { get; set; }

        [JsonProperty("issn")]
        public string Issn { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("textObjects")]
        public TextObject[] TextObjects { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("urls")]
        public Url[] Urls { get; set; }

        [JsonProperty("series")]
        public ItemList series { get; set; }

        [JsonProperty("variants")]
        public Variant[] Variants { get; set; }

        public object[] collections { get; set; }
        public object[] collectedIssues { get; set; }

        [JsonProperty("dates")]
        public Date[] Dates { get; set; }

        [JsonProperty("prices")]
        public Price[] Prices { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("creators")]
        public ItemList Creators { get; set; }

        [JsonProperty("characters")]
        public ItemList Characters { get; set; }

        [JsonProperty("stories")]
        public ItemList Stories { get; set; }

        [JsonProperty("events")]
        public ItemList Events { get; set; }
    }
}