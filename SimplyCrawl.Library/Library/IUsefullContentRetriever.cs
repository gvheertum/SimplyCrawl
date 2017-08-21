 using System.Collections.Generic;
 namespace SimplyCrawl.Library
{
 public interface IContentCrawler
    {
		IEnumerable<UsefullContent> GetUseFullContent(string content);
    }
}