using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Metaco.ItBit
{
	internal class MetacoHttpClient
	{
		private readonly string _clientKey;
		private readonly string _secretKey;
		private readonly string _userId;
		private readonly HttpRequestBuilder _requestBuilder;

		public MetacoHttpClient(string clientKey, string secretKey, string userId)
		{
			_clientKey = clientKey;
			_secretKey = secretKey;
			_userId = userId;
			_requestBuilder = new HttpRequestBuilder(clientKey);
		}

		private HttpClient CreateClient()
		{
			var client =  new HttpClient {
				BaseAddress = new Uri("https://api.itbit.com/v1", UriKind.RelativeOrAbsolute)
			};
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
			return client;
		}

		public async Task<HttpResponseMessage> SendAsync(IMessageBuilder messageBuilder)
		{
			var request = _requestBuilder.Build(messageBuilder);
			return await CreateClient().SendAsync(request).ConfigureAwait(false);
		}


		//public static void HandleInvalidResponse(HttpResponseMessage response)
		//{
		//	MetacoErrorResult metacoError;
		//	string content=null;
		//	Exception inner = null;
		//	try
		//	{
		//		content = response.Content.ReadAsStringAsync().Result;
		//		metacoError = JsonConvert.DeserializeObject<MetacoErrorResult>(content);
		//		if (string.IsNullOrEmpty(metacoError.MetacoError))
		//			throw new MetacoClientException(metacoError, ErrorType.UnknownError, content, (int) response.StatusCode, null);
		//	}
		//	catch (Exception e)
		//	{
		//		metacoError = new MetacoErrorResult {
		//			MetacoError = "", 
		//			Status = (int) response.StatusCode
		//		};
		//		inner = e;
		//	}
		//	var errorType = MetacoErrorsDefinitions.GetErrorType(metacoError);
		//	throw new MetacoClientException(metacoError, errorType, content, (int)response.StatusCode, inner);
		//}
	}


	/*
class MessageSigner(object):

    def make_message(self, verb, url, body, nonce, timestamp):
        # There should be no spaces after separators
        return json.dumps([verb, url, body, str(nonce), str(timestamp)], separators=(',', ':'))

    def sign_message(self, secret, verb, url, body, nonce, timestamp):
        message = self.make_message(verb, url, body, nonce, timestamp)
        sha256_hash = hashlib.sha256()
        nonced_message = str(nonce) + message
        sha256_hash.update(nonced_message.encode('utf8'))
        hash_digest = sha256_hash.digest()
        hmac_digest = hmac.new(secret    url.encode('utf8') + hash_digest, hashlib.sha512).digest()
        return base64.b64encode(hmac_digest)
	*/
}
