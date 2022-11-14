using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mod.ActivityPub.UI
{
    public class StringArrayEnumConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        public override JsonConverter CreateConverter(
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(StringArrayEnumConverterInner<>).MakeGenericType(typeToConvert),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null)!;

            return converter;
        }

        private class StringArrayEnumConverterInner<T> :
            JsonConverter<T> where T : Enum
        {
            private readonly JsonConverter<T> _converter;
            private readonly Type _type;

            public StringArrayEnumConverterInner(JsonSerializerOptions options)
            {
                // for performance, use the existing converter if available
                if (options != null)
                {
                    _converter = (JsonConverter<T>)options.GetConverter(typeof(T));
                }

                // cache the underlying type
                _type = typeof(T);
            }

            public override T Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartArray)
                {
                    throw new JsonException();
                }

                var strlist = new List<string>();


                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    var s = JsonSerializer.Deserialize<string>(ref reader, options);
                    if (s != null)
                    {
                        strlist.Add(s);
                    }
                }

                var iarray = strlist.Where(x => Enum.IsDefined(_type, x.Replace(".", "_")))
                                .Select(x => (int)Enum.Parse(_type, x.Replace(".", "_"))).ToArray();

                T result = (T)(object)iarray.Aggregate((i, t) => i | t);

                return result;
            }

            public override void Write(
                Utf8JsonWriter writer,
                T flags,
                JsonSerializerOptions options)
            {
                writer.WriteStartArray();

                var type = flags.GetType();
                var names = Enum.GetNames(type);

                foreach (var name in names.Where(x => x != "none"))
                {
                    var item = (T)Enum.Parse(type, name);

                    if (flags.HasFlag(item))
                    {
                        writer.WriteStringValue(name.Replace("_", "."));
                    }
                }

                writer.WriteEndArray();
            }
        }
    }
}