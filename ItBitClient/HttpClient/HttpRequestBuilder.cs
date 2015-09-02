using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace Metaco.ItBit
{
	class HttpRequestBuilder
	{
		private readonly string _clientKey;
		private static uint _nonce;
		private readonly HttpRequestMessageSigner _signer;
		private static readonly DateTime JanuryFirst1970 = new DateTime(1970, 1, 1);

		private string Nonce
		{
			get
			{
				return Convert.ToString(_nonce++);
			}
		}

		private string Timestamp
		{
			get
			{
				var time = DateTime.UtcNow - JanuryFirst1970;
				var timestamp = (long)time.TotalMilliseconds;
				return Convert.ToString(timestamp);
			}
		}

		public HttpRequestBuilder(string clientKey)
		{
			_clientKey = clientKey;
			_signer = new HttpRequestMessageSigner();
		}

		public HttpRequestMessage Build(IMessageBuilder messageBuilder)
		{
			var message = messageBuilder.Build();
			var request = new HttpRequestMessage(message.Method, message.RequestUri);

			if (message.RequireAuthentication)
			{
				var timestamp = Timestamp;
				var nonce = Nonce;

				var signature = _signer.Sign(request.Method.Method, request.RequestUri.ToString(), timestamp, nonce, "body");

				request.Headers.Add("Authorization", _clientKey + ':' + signature);
				request.Headers.Add("X-Auth-Timestamp", timestamp);
				request.Headers.Add("X-Auth-Nonce", nonce);
			}
			return request;
		}
	}

	class HttpRequestMessageSigner
	{
		public string Sign(string verb, string url, string timestamp, string nonce, string body)
		{
			var msg = string.Format("'[\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
					verb,
					url,
					body,
					nonce,
					timestamp);
			var noncedMsg = Encoding.UTF8.GetBytes(nonce + msg);

			var sha256 = new SHA256Managed();
			var hashedNoncedMessage = sha256.ComputeHash(noncedMsg);

			var toSign = Encoding.UTF8.GetBytes(url).Concat(hashedNoncedMessage);
			var hmac = new HMACSHA512(hashedNoncedMessage);
			var hmacDigest = hmac.ComputeHash(toSign.ToArray());
			return Convert.ToBase64String(hmacDigest);
		}
	}

}
