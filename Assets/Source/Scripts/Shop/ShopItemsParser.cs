using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class ShopItemsParser : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(Item));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject item = JObject.Load(reader);
        if (item["Damage"] != null)
        {
            return item.ToObject<Weapon>(serializer);
        }
        else if (item["Amount"] != null)
        {
            return item.ToObject<Currency>(serializer);
        }
        throw new InvalidOperationException("Unrecognized item type.");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
