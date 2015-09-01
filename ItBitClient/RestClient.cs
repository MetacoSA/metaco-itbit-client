using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Metaco.ItBit.Models;

namespace Metaco.ItBit
{
	public partial class RestClient
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
	}

	public static partial class Extensions
	{
		internal static Task<T> ReadAsAsync<T>(this Task<HttpResponseMessage> self, MediaTypeFormatter formatter)
		{
			return self.ReadAsAsync<T>(new MediaTypeFormatter[] {formatter});
		}

		internal static Task<TResult> ReadAsAsync<TResult, TMediaTypeFormatter>(this Task<HttpResponseMessage> self) where TMediaTypeFormatter : MediaTypeFormatter, new()
		{
			return self.ReadAsAsync<TResult>(new MediaTypeFormatter[] {new TMediaTypeFormatter()});
		}
	}
}