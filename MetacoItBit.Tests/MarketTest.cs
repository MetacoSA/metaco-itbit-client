using System.Linq;
using Metaco.ItBit;
using NUnit.Framework;

namespace MetacoItBit.Tests
{
	[TestFixture]
	public class MarketTest
	{
		[Test]
		public async void CanGetTickers()
		{
			var itBit = new RestClient();
			var ticker = await itBit.GetTickerAsync("XBTUSD");
			Assert.IsNotNull(ticker);
			Assert.AreEqual("XBTUSD", ticker.Pair);
		}

		[Test]
		public async void CanGetOrderBook()
		{
			var itBit = new RestClient();
			var orderBook = await itBit.GetOrderBookAsync("XBTUSD");
			Assert.IsNotNull(orderBook);
			Assert.IsTrue(orderBook.Asks.Any());
			Assert.IsTrue(orderBook.Bids.Any());
		}

		[Test]
		public async void CanGetRecentTrades()
		{
			var itBit = new RestClient();
			var trades = await itBit.GetRecentTradesAsync("XBTUSD");
			Assert.IsNotNull(trades);
			Assert.IsTrue(trades.Trades.Any());
		}

		[Test]
		public async void CanCaptureErrors()
		{
			var itBit = new RestClient();
			try
			{
				var trades = await itBit.GetRecentTradesAsync("NON-EXISTING");
				Assert.Fail("An itBitApiException was expected here");
			}
			catch (ItBitApiException)
			{
				Assert.Pass("Expected Exception thrown");
			}
		}
	}
}
