using Newtonsoft.Json;
using System;

namespace Metaco.ItBit.Models 
{
	public class Error
	{
		[JsonProperty("code")]
		public int Code { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("requestId")]
		public Guid RequestId { get; set; }

		// lowest ask price
		[JsonProperty("ask")]
		public decimal Ask { get; set; }
	}
}
