using System;
using Newtonsoft.Json;

namespace Metaco.ItBit.Models.Markets
{
	public class RecentTrades
	{
		[JsonProperty("recentTrades")]
		public RecentTrade[] Trades { get; set; }
	}

	public class RecentTrade
	{
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }

		[JsonProperty("mutchNumber")]
		public int MatchNumber { get; set; }
		
		[JsonProperty("price")]
		public decimal Price { get; set; }
		
		[JsonProperty("amount")]
		public decimal Amount { get; set; }
	}
}
