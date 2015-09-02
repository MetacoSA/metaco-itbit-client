using System;

namespace Metaco.ItBit
{
	public class ItBitApiException : Exception
	{
		public Error Error { get; private set; }

		public ItBitApiException(Error error)
			:base(error.Description)
		{
			Error = error;
		}
	}
}