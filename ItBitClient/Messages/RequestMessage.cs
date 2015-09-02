using System;
using System.Net.Http;

namespace Metaco.ItBit
{
	internal class RequestMessage
	{
		public HttpMethod Method { get; set; }
		public Uri RequestUri { get; set; }
		public object Content { get; set; }

		public bool RequireAuthentication { get; set; }
	}
}