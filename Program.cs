using System;
using System.Linq;
using System.Collections.Generic;
using PacktScreener.Library;
using PacktScreener.Library.UsefullContentRetrievers;
using packtscreener.Library;

namespace PacktScreener
{
	class Program
	{
		const string PacktUrl = "https://www.packtpub.com/packt/offers/free-learning";
		static void Main(string[] args)
		{
			Console.WriteLine("Simple webreader thingy");
			WriteDashLine();
			new ContentRetrieverFactory().GetRetrievers().ToList().ForEach(retriever =>
			{
				var content = retriever.GetContent();
				Console.WriteLine(content.Name);
				content.SubContent.ForEach(sc => 
				{
					Console.WriteLine($"{sc.Name}: {sc.Content}");
				});
				WriteDashLine();
			});
			Console.ReadLine();
		}

		private static void WriteDashLine()
		{
			Console.WriteLine("------------------------------------------------");
		}
	}
}