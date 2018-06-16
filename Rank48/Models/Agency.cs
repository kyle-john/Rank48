using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rank48.Models
{
    public partial class Agency
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("open")]
        public bool IsOpen { get; set; }

        [JsonProperty("mo")]
        public string MobileImageUrl { get; set; }

        [JsonProperty("pc")]
        public string PcImageUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }
    }

    public enum Country { Japan, Korea };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new CountryConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CountryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Country) || t == typeof(Country?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "JPN":
                    return Country.Japan;
                case "KOR":
                    return Country.Korea;
            }
            throw new Exception("Cannot unmarshal type Country");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Country)untypedValue;
            switch (value)
            {
                case Country.Japan:
                    serializer.Serialize(writer, "JPN"); return;
                case Country.Korea:
                    serializer.Serialize(writer, "KOR"); return;
            }
            throw new Exception("Cannot marshal type Country");
        }
    }
}
