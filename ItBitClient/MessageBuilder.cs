using System;
using System.Net.Http;

namespace Metaco.ItBit
{
	class RequestMessage
	{
		public HttpMethod Method { get; set; }
		public Uri RequestUri { get; set; }
		public object Content { get; set; }

		public bool RequireAuthentication { get; set; }
	}

	internal interface IMessageBuilder
	{
		RequestMessage Build();
	}

	internal class TickerMessageBuilder : IMessageBuilder
	{
		private readonly string _symbol;

		public TickerMessageBuilder(string symbol)
		{
			_symbol = symbol;
		}

		public RequestMessage Build()
		{
			return new RequestMessage {
				RequireAuthentication = false,
				Method = HttpMethod.Get,
				RequestUri = new Uri("/v1/markets/{0}/ticker".Uri(_symbol), UriKind.Relative)
			};
		}
	}

	internal class OrderBookMessageBuilder : IMessageBuilder
	{
		private readonly string _symbol;

		public OrderBookMessageBuilder(string symbol)
		{
			_symbol = symbol;
		}

		public RequestMessage Build()
		{
			return new RequestMessage {
				RequireAuthentication = false,
				Method = HttpMethod.Get,
				RequestUri = new Uri("/v1/markets/{0}/order_book".Uri(_symbol), UriKind.Relative)
			};
		}
	}

	internal class RecentTradesMessageBuilder : IMessageBuilder
	{
		private readonly string _symbol;
		private readonly int? _since;

		public RecentTradesMessageBuilder(string symbol, int? since)
		{
			_symbol = symbol;
			_since = since;
		}

		public RequestMessage Build()
		{
			var uri = _since.HasValue
				? "/v1/markets/{0}/trades?since={1}".Uri(_symbol, _since)
				: "/v1/markets/{0}/trades".Uri(_symbol);

			return new RequestMessage {
				RequireAuthentication = false,
				Method = HttpMethod.Get,
				RequestUri = new Uri(uri, UriKind.Relative)
			};
		}
	}

	static class StringExtensions
	{
		public static string Uri(this string str, params object[] args)
		{
			return string.Format(str, args);
		}
	}
}
