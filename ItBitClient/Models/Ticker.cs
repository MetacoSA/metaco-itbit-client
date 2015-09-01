using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Metaco.ItBit.Models 
{
	[DebuggerDisplay("{ToString()}")]
	public class Ticker
	{
		#region Response Body Example
		/*
		{
			"pair": "XBTUSD",
			"bid": "622",
			"bidAmt": "0.0006",
			"ask": "641.29",
			"askAmt": "0.5",
			"lastPrice": "618.00000000",
			"lastAmt": "0.00040000",
			"volume24h": "0.00040000",
			"volumeToday": "0.00040000",
			"high24h": "618.00000000",
			"low24h": "618.00000000",
			"highToday": "618.00000000",
			"lowToday": "618.00000000",
			"openToday": "618.00000000",
			"vwapToday": "618.00000000",
			"vwap24h": "618.00000000",
			"serverTimeUTC": "2014-06-24T20:42:35.6160000Z"
		}
		 * */
		#endregion
		// currency pair for market. e.g. XBTUSD for USD Bitcoin market.
		[JsonProperty("pair")]
		public string Pair { get; set; }

		// highest bid price
		[JsonProperty("bid")]
		public decimal Bid { get; set; }

		// highest bid amount
		[JsonProperty("bidAmt")]
		public decimal BidAmount { get; set; }

		// lowest ask price
		[JsonProperty("ask")]
		public decimal Ask { get; set; }

		// lowest ask amount
		[JsonProperty("askAmt")]
		public decimal AskAmount { get; set; }

		// last traded price
		[JsonProperty("lastPrice")]
		public decimal LastPrice { get; set; }

		// last traded amount
		[JsonProperty("lastAmt")]
		public decimal LastAmount { get; set; }

		// total traded volume in the last 24 hours
		[JsonProperty("volume24h")]
		public decimal Volume24Hs { get; set; }

		// total traded volume since midnight UTC
		[JsonProperty("volumeToday")]
		public decimal VolumeToday { get; set; }

		// highest traded price in the last 24 hours
		[JsonProperty("high24h")]
		public decimal HighestPrice24Hs { get; set; }

		// lowest traded price in the last 24 hours
		[JsonProperty("low24h")]
		public decimal LowestPrice24Hs { get; set; }

		// highest traded price since midnight UTC
		[JsonProperty("highToday")]
		public decimal HighestPriceToday { get; set; }

		// lowest traded price since midnight UTC
		[JsonProperty("lowToday")]
		public decimal LowestPriceToday { get; set; }

		// first traded price since midnight UTC
		[JsonProperty("openToday")]
		public decimal OpenToday { get; set; }

		// volume weighted average price traded since midnight UTC
		[JsonProperty("vwapToday")]
		public string vwapToday { get; set; }

		// volume weighted average price traded in the last 24 hours
		[JsonProperty("vwap24h")]
		public string vwap24h { get; set; }

		// server time in UTC
		[JsonProperty("serverTimeUTC")]
		public DateTime ServerTimeUtc { get; set; }
	}
}
