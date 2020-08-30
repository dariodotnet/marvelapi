namespace Marvel
{
    using Model;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal static class ResponseExtension
    {
        internal static async Task<string> Resolve(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

            var serializer = new JsonSerializer();

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                var error = serializer.Deserialize<MarvelError>(json);
                if (error != null)
                    throw error;
            }

            throw new Exception("Oops! Something went wrong.");
        }

        internal static async Task<T> Resolve<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var serializer = new JsonSerializer();

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    return serializer.Deserialize<T>(json);
                }
            }

            throw new Exception("Oops! Something went wrong.");
        }
    }
}