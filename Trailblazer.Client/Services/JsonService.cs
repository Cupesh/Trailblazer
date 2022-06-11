using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Trailblazer.Services
{
    public class JsonService : IJsonService
    {

        /// <summary>
        /// De-serialise json string to specified object
        /// </summary>
        public T FromJson<T>(string json) => JsonSerializer.Deserialize<T>(json, Settings);
        public T FromJson<T>(string json, T anonymousTypeObject) => JsonSerializer.Deserialize<T>(json, Settings);


        /// <summary>
        /// Serialise a specified object to a json string
        /// </summary>
        public string ToJson<T>(T objectToSerialize) => JsonSerializer.Serialize(objectToSerialize, Settings);

        /// <summary>
        /// Serialize specified object to Json StringContent
        /// </summary>
        public StringContent ToJsonStringContent<T>(T objectToSerialize)
        {
            string jsonString = JsonSerializer.Serialize(objectToSerialize, Settings);
            StringContent content = new(jsonString, Encoding.UTF8, "application/json");
            return content;
        }

        /// <summary>
        /// Set up default values for the json serialiser
        /// </summary>
        private readonly JsonSerializerOptions Settings = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        };

    }
}
