using System.Collections.Generic;
namespace PacktScreener.Library
{

	public class UsefullContent
	{
		public string Identifier { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }
	}

	public class ContentGroup
	{
		public string Name { get; set; }
		public List<UsefullContent> SubContent { get; set; } = new List<UsefullContent>();
	}
}