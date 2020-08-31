namespace Marvel.Model
{
    public static class ErrorConstants
    {
        public static class Code
        {
            public static string InvalidCredentials = "InvalidCredentials";
            public static string InvalidParameter = "409";
            public static string NotFound = "404";
        }

        public static class Message
        {
            public static string ApiKeyInvalid = "The passed API key is invalid.";
            public static string ApiInvalidHash = "That hash, timestamp and key combination is invalid.";
        }

        public static class Reason
        {
            public static string InvalidZeroLimit = "You must pass an integer limit greater than 0.";
            public static string InvalidLimit = "You may not request more than 100 items.";
            public static string CharacterNotFound = "We couldn't find that character";
        }
    }
}