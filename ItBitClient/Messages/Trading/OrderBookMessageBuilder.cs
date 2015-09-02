using System;
using System.Net.Http;

namespace Metaco.ItBit
{
	internal class WalletMessageBuilder : IMessageBuilder
	{
		private readonly Guid _userId;
		private readonly Page _page;

		public WalletMessageBuilder(Guid userId)
			: this(userId, Page.NoPagination)
		{
		}

		public WalletMessageBuilder(Guid userId, Page page)
		{
			_userId = userId;
			_page = page;
		}

		public RequestMessage Build()
		{
			return new RequestMessage {
				RequireAuthentication = false,
				Method = HttpMethod.Get,
				RequestUri = new Uri("/v1/wallets?userId={0}&page={1}&perPage={2}"
					.Uri(_userId, _page.Number, _page.Size), UriKind.Relative)
			};
		}
	}

	public class Page
	{
		public int Number { get; private set; }
		public int Size { get; private set; }

		public static Page NoPagination = new Page(1, 50);

		public static Page Create(int number, int size)
		{
			if (number < 0 )
				throw new ArgumentOutOfRangeException("number", "page number must be greater or equal to 1");
			if(size < 1 || size > 50)
				throw new ArgumentOutOfRangeException("size", "page size must be beetwen 1 and 50");

			return new Page(number, size);
		}

		private Page(int number, int size)
		{
			Number = number;
			Size = size;
		}
	}
}