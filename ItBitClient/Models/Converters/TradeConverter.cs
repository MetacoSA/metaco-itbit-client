﻿using Newtonsoft.Json;
using System;
using System.Collections;

namespace Metaco.ItBit.Models.Converters
{
	public sealed class TradeConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			var type = typeof (Trade);
			return type.IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;
			var list = (decimal[])serializer.Deserialize(reader, typeof(decimal[]));
			return Activator.CreateInstance(objectType, list[0], list[1]);
		}

		public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
		{
		}
	}
}