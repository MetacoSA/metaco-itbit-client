using System;
using System.Net.Http;

namespace Metaco.ItBit
{
	internal class GetOrderBookMessageBuilder : IMessageBuilder
	{
		private readonly string _symbol;

		public GetOrderBookMessageBuilder(string symbol)
		{
			_symbol = symbol;
		}

		public RequestMessage Build()
		{
			return new RequestMessage {
				Method = HttpMethod.Get,
				RequestUri = new Uri("/v1/markets/{0}/order_book".Uri(_symbol), UriKind.Relative)
			};
		}
	}
}