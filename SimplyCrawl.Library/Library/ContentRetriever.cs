using System.Linq;

namespace SimplyCrawl.Library
{
	public interface IContentRetriever
	{
		ContentGroup GetContent();
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