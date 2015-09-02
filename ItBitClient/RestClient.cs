using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Metaco.ItBit.Models;
using Metaco.ItBit.Models.Markets;
using Metaco.ItBit.Serialization;

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
			return _client.SendAsync(request).ReadAsAsync<Ticker, JsonMediaTypeFormatter>();
		}

		public Task<OrderBook> GetOrderBookAsync(string symbol)
		{
			var request = new OrderBookMessageBuilder(symbol);
			return _client.SendAsync(request).ReadAsAsync<OrderBook, OrderBookMediaTypeFormatter>();
		}

		public Task<RecentTrades> GetRecentTradesAsync(string symbol, int? since=null)
		{
			var request = new RecentTradesMessageBuilder(symbol, since);
			return _client.SendAsync(request).ReadAsAsync<RecentTrades, JsonMediaTypeFormatter>();
		}
	}

	public static partial class Extensions
	{
		internal static async Task<T> ReadAsAsync<T>(this Task<HttpResponseMessage> task, MediaTypeFormatter formatter)
		{
			var response = await task;
			return await response.ReadAsAsync<T>(new MediaTypeFormatter[] { formatter });
		}

		internal static async Task<TResult> ReadAsAsync<TResult, TMediaTypeFormatter>(this Task<HttpResponseMessage> task) where TMediaTypeFormatter : MediaTypeFormatter, new()
		{
			var response = await task;
			if (!response.IsSuccessStatusCode)
			{
				var error = await response.ReadAsAsync<Error>(new MediaTypeFormatter[] { new JsonMediaTypeFormatter() });
				throw new ItBitApiException(error);
			}
			return await response.ReadAsAsync<TResult>(new MediaTypeFormatter[] {new TMediaTypeFormatter()});
		}
	}

	public class ItBitApiException : Exception
	{
		public Error Error { get; private set; }

		public ItBitApiException(Error error)
			:base(error.Description)
		{
			Error = error;
		}
	}
}