using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Metaco.ItBit 
{
	public static partial class Extensions
	{
		public static Task<T> ReadAsAsync<T>(this HttpResponseMessage response, params MediaTypeFormatter[] formatters)
		{
			return response.Content.ReadAsAsync<T>(formatters);
		}
	}
}
