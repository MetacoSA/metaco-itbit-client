using Newtonsoft.Json;

namespace Metaco.ItBit
{
	public class Balance
	{
		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("availableBalance")]
		public decimal AvailableBalance { get; set; }

		[JsonProperty("totalBalance")]
		public decimal TotalBalance { get; set; }
	}
}