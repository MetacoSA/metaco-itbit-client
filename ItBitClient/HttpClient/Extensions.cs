using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Metaco.ItBit
{
	public static partial class Extensions
	{
		internal static async Task<T> ReadAsAsync<T>(this Task<HttpResponseMessage> task)
		{
			var response = await task;
			return await response.ReadAsAsync<T>(new MediaTypeFormatter[] {new JsonMediaTypeFormatter()});
		}

		internal static async Task<TResult> ReadAsAsync<TResult, TMediaTypeFormatter>(this Task<HttpResponseMessage> task) where TMediaTypeFormatter : MediaTypeFormatter, new()
		{
			var response = await task;
			return await response.ReadAsAsync<TResult>(new MediaTypeFormatter[] {new TMediaTypeFormatter()});
		}
	}
}
