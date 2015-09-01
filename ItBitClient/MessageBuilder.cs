using System;
using System.Net.Http;

namespace Metaco.ItBit
{
	class RequestMessage
	{
		public HttpMethod Method { get; set; }
		public Uri RequestUri { get; set; }
		public object Content { get; set; }
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
				Method = HttpMethod.Get,
				RequestUri = new Uri("/markets/{0}/ticker".Uri(_symbol), UriKind.Relative)
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
