using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Metaco.ItBit
{
	public class RestClient
	{
		private readonly MetacoHttpClient _client;

		public RestClient()
		{
			_client = new MetacoHttpClient(null, null, null);
		}

		public Task<Ticker> GetTickerAsync(string symbol)
		{
			var request = new TickerMessageBuilder(symbol);
			return _client.SendAsync(request).ReadAsAsync<Ticker>();
		}

		public Task<OrderBook> GetOrderBookAsync(string symbol)
		{
			var request = new OrderBookMessageBuilder(symbol);
			return _client.SendAsync(request).ReadAsAsync<OrderBook, OrderBookMediaTypeFormatter>();
		}

		public Task<RecentTrades> GetRecentTradesAsync(string symbol, int? since=null)
		{
			var request = new RecentTradesMessageBuilder(symbol, since);
			return _client.SendAsync(request).ReadAsAsync<RecentTrades>();
		}

		public Task<Wallet> GetAllWalletsAsync(Guid userId, Page page)
		{
			var request = new WalletMessageBuilder(userId, page);
			return _client.SendAsync(request).ReadAsAsync<Wallet>();
		}
	}

	public static partial class Extensions
	{
		public static async Task<T> ReadAsAsync<T>(this HttpResponseMessage response, params MediaTypeFormatter[] formatters)
		{
			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadAsAsync<Error>(new MediaTypeFormatter[] { new JsonMediaTypeFormatter() });
				throw new ItBitApiException(error);
			}

			return await response.Content.ReadAsAsync<T>(formatters);
		}
	}
}