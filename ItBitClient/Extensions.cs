using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Metaco.ItBit 
{
	public static partial class Extensions
	{
		public static Task<T> ReadAsAsync<T>(this Task<HttpResponseMessage> task, params MediaTypeFormatter[] formatters)
		{
			return task.Result.Content.ReadAsAsync<T>(formatters);
		}
	}
}
