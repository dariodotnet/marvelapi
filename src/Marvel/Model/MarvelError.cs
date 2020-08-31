namespace Marvel.Model
{
    using System;

    public class MarvelError : Exception
    {
        public MarvelError(string message, string code) : base(message)
        {
            this.message = message;
            this.code = code;
        }

        public string code { get; set; }

        public string message { get; set; }

        public string status { get; set; }
    }
}