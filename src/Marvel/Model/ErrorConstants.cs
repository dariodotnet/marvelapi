namespace Marvel.Model
{
    public static class ErrorConstants
    {
        public static class Code
        {
            public static string InvalidCredentials = "InvalidCredentials";
        }

        public static class Message
        {
            public static string ApiKeyInvalid = "The passed API key is invalid.";
            public static string ApiInvalidHash = "That hash, timestamp and key combination is invalid.";
        }
    }
}