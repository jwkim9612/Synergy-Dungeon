using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.NetworkProtocol
{
    public static class JsonService
    {
        public static string SerializeToDB<T>(T source)
        {
            try
            {
                var value = JsonConvert.SerializeObject(source, DBSerializeSetting);
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"JsonSerializationError:{source}:{ex}");
                throw;
            }
        }

        public static T DeserializeFromDB<T>(string text) where T : class
        {
            try
            {
                text = text.Replace("Assembly-CSharp", "MXShared");
                T obj = JsonConvert.DeserializeObject<T>(text, DBSerializeSetting);
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"JsonDeserializationError:{text}:{ex}");
                throw;
            }
        }

        public static readonly JsonSerializerSettings DBSerializeSetting = new JsonSerializerSettings()
        {
            Formatting = Newtonsoft.Json.Formatting.None,
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            //Converters = { new Newtonsoft.Json.Converters.VectorConverter() }
        };
    }
}
