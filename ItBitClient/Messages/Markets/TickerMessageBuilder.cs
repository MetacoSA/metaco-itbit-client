using System;
using System.Net.Http;

namespace Metaco.ItBit
{
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
}