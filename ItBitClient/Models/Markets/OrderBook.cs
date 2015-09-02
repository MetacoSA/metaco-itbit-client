using Newtonsoft.Json;

namespace Metaco.ItBit.Models 
{
	public class OrderBook
	{
		// currency pair for market. e.g. XBTUSD for USD Bitcoin market.
		[JsonProperty("asks")]
		public Trade[] Asks { get; set; }

		// highest bid price
		[JsonProperty("bids")]
		public Trade[] Bids { get; set; }
	}

	public class Trade
	{
		public Trade(decimal price, decimal amount)
		{
			Price = price;
			Amount = amount;
		}

		public decimal Price { get; set; }
		public decimal Amount { get; set; }
	}
}
