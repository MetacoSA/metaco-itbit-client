using System;
using System.Net.Http;

namespace Metaco.ItBit
{
	internal class GetRecentTradesMessageBuilder : IMessageBuilder
	{
		private readonly string _symbol;
		private readonly int? _since;

		public GetRecentTradesMessageBuilder(string symbol, int? since)
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
				Method = HttpMethod.Get,
				RequestUri = new Uri(uri, UriKind.Relative)
			};
		}
	}
}