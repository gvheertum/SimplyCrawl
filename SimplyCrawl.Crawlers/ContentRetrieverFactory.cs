using SimplyCrawl.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyCrawl.Crawlers
{
	public enum ContentRetrieverType
	{
		Unknown,
		PacktEbook,
	}

	public class ContentRetrieverFactory
	{
		private Dictionary<ContentRetrieverType, IContentRetriever> GetContentRetrievers()
		{
			return new Dictionary<ContentRetrieverType, IContentRetriever>()
			{
				{ ContentRetrieverType.PacktEbook, new PacktFreeEbookContentCrawler() }
			};
		}

		public IContentRetriever GetRetriever(ContentRetrieverType type)
		{
			var types = GetContentRetrievers();
			return types.ContainsKey(type) ? types[type] : throw new Exception($"Type {type} not in collection");
		}

		public IEnumerable<IContentRetriever> GetRetrievers()
		{
			var _types = GetContentRetrievers();
			foreach(var k in _types.Keys)
			{
				yield return _types[k];
			}
		}
	}
}
