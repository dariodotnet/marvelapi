namespace Marvel.Model
{
    using System;
    using Refit;

    public class CreatorBaseQueryParameter
    {
        [AliasAs("firstName")]
        public string FirstName { get; set; }

        [AliasAs("middleName")]
        public string MiddleName { get; set; }

        [AliasAs("lastName")]
        public string LastName { get; set; }

        [AliasAs("suffix")]
        public string Suffix { get; set; }

        [AliasAs("nameStartsWith")]
        public string nameStartsWith { get; set; }

        [AliasAs("firstNameStartsWith")]
        public string FirstNameStartsWith { get; set; }

        [AliasAs("middleNameStartsWith")]
        public string MiddleNameStartsWith { get; set; }

        [AliasAs("lastNameStartsWith")]
        public string LastNameStartsWith { get; set; }

        public DateTime ModifiedSinceDateTime { get; set; }

        [AliasAs("modifiedSince")]
        public string ModifiedSince => ModifiedSinceDateTime != default
            ? ModifiedSinceDateTime.ToString("YYYY-MM-DD") : null;

        public ParameterCreatorOrder CreatorOrder { get; set; }

        [AliasAs("orderBy")]
        public string OrderBy => SetOrder(CreatorOrder);

        [AliasAs("limit")]
        public int Limit { get; set; } = 20;

        [AliasAs("offset")]
        public int Offset { get; set; }

        private string SetOrder(ParameterCreatorOrder creatorOrder)
        {
            switch (creatorOrder)
            {
                case ParameterCreatorOrder.ByLastName:
                    return "lastName";
                case ParameterCreatorOrder.ByFirstName:
                    return "firstName";
                case ParameterCreatorOrder.ByMiddleName:
                    return "middleName";
                case ParameterCreatorOrder.BySuffix:
                    return "suffix";
                case ParameterCreatorOrder.ByModified:
                    return "modified";
                case ParameterCreatorOrder.ByLastNameDescending:
                    return "-lastName";
                case ParameterCreatorOrder.ByFirstNameDescending:
                    return "-firstName";
                case ParameterCreatorOrder.ByMiddleNameDescending:
                    return "-middleName";
                case ParameterCreatorOrder.BySuffixDescending:
                    return "-suffix";
                case ParameterCreatorOrder.ByModifiedDescending:
                    return "-modified";
                default:
                    return null;
            }
        }
    }
}