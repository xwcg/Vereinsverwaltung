using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerWalterClient.Data
{
    class DBBoolean : JsonConverter
    {
        public override bool CanWrite { get { return true; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if ((bool)value)
                writer.WriteValue("1");
            else
                writer.WriteValue("0");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;

            if (value == null || String.IsNullOrWhiteSpace(value.ToString()))
            {
                return false;
            }

            if ((string)value == "1") return true; 

            return false;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(String) || objectType == typeof(Boolean))
            {
                return true;
            }
            return false;
        }
    }

}
