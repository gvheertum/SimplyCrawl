 using System.Collections.Generic;
 namespace SimplyCrawl.Library
{
 public interface IUsefullContentRetriever
    {
		IEnumerable<UsefullContent> GetUseFullContent(string content);
    }
}