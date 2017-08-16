using SimplyCrawl.Library.UsefullContentRetrievers;
using System.Linq;

namespace SimplyCrawl.Library
{
	public interface IContentRetriever
	{
		ContentGroup GetContent();
	}

	public class PacktContentRetriever : IContentRetriever
	{
		const string PacktDailyUrl = "https://www.packtpub.com/packt/offers/free-learning";
		ContentGroup IContentRetriever.GetContent()
		{
			var nodes = new PacktUsefullContentRetriever().GetUseFullContent(new WebSiteRetriever().GetContent(PacktDailyUrl));
			return new ContentGroup() { Name = "Packt-Free ebook deal", SubContent = nodes.ToList() }; 
		}
	}

	public class WebSiteRetriever
	{
        public string GetContent(string url)
        {
			System.Net.Http.HttpClient cli = new System.Net.Http.HttpClient();
			var cliDat = cli.GetAsync(url);
			cliDat.Wait();
			var data = cliDat.Result.Content.ReadAsStringAsync();
			data.Wait();
			return data.Result; 
        }
    }
}