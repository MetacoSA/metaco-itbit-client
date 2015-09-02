using System;
using System.Net.Http;

namespace Metaco.ItBit
{
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
}