namespace Marvel.Model
{
    using System;

    public class MarvelException : Exception
    {
        public MarvelException(string message, string code) : base(message)
        {
            this.message = message;
            this.code = code;
        }

        public string code { get; set; }

        public string message { get; set; }

        public string status { get; set; }
    }
}