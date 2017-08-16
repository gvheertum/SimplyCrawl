 using System.Collections.Generic;
 namespace PacktScreener.Library
{
 public interface IUsefullContentRetriever
    {
		IEnumerable<UsefullContent> GetUseFullContent(string content);
    }
}