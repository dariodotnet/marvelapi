namespace Marvel.Model
{
    using Refit;
    using System;

    public class EventBaseQueryParameter
    {
        [AliasAs("name")]
        public string Name { get; set; }

        [AliasAs("nameStartsWith")]
        public string NameStartsWith { get; set; }

        public DateTime ModifiedSinceDateTime { get; set; }

        [AliasAs("modifiedSince")]
        public string ModifiedSince => ModifiedSinceDateTime != default
            ? ModifiedSinceDateTime.ToString("YYYY-MM-DD") : null;

        public ParameterEventOrder EventOrder { get; set; }

        [AliasAs("orderBy")]
        public string OrderBy => SetOrder(EventOrder);

        [AliasAs("limit")]
        public int Limit { get; set; } = 20;

        [AliasAs("offset")]
        public int Offset { get; set; }

        private string SetOrder(ParameterEventOrder eventOrder)
        {
            switch (eventOrder)
            {
                case ParameterEventOrder.ByName:
                    return "name";
                case ParameterEventOrder.ByStartDate:
                    return "startDate";
                case ParameterEventOrder.ByModified:
                    return "modified";
                case ParameterEventOrder.ByNameDescending:
                    return "-name";
                case ParameterEventOrder.ByStartDateDescending:
                    return "-startDate";
                case ParameterEventOrder.ByModifiedDescending:
                    return "-modified";
                default:
                    return null;
            }
        }
    }
}