using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
namespace PacktScreener.Library.UsefullContentRetrievers
{
	public class PacktUsefullContentRetriever : IUsefullContentRetriever
	{
		public IEnumerable<UsefullContent> GetUseFullContent(string content)
		{
			var d = new HtmlAgilityPack.HtmlDocument();
			d.LoadHtml(content);
			yield return GetTitle(d);
			yield return GetCountDown(d);
			yield return GetDescription(d);
		}

		const string TitleClass = "dotd-title";
		const string TickerClass = "packt-js-countdown";
		const string DescriptionClass = "eighteen-days-countdown-bar";

		private UsefullContent GetTitle(HtmlAgilityPack.HtmlDocument doc)
		{
			return new UsefullContent() { Name = "Title", Identifier ="title",  Content = GetNodeContentWithClass(doc, TitleClass) };
		}

		private UsefullContent GetCountDown(HtmlAgilityPack.HtmlDocument doc)
		{
			return new UsefullContent() { Name = "Countdown", Identifier = "timeleft", Content = GetNodeContentWithClass(doc, TickerClass) };
		}

		private UsefullContent GetDescription(HtmlAgilityPack.HtmlDocument doc)
		{
			return new UsefullContent() { Name = "Description", Identifier = "description", Content = GetNodeContentWithClass(doc, DescriptionClass) };
		}

		private string GetNodeContentWithClass(HtmlAgilityPack.HtmlDocument doc, string value)
		{
			HtmlNode n = doc.DocumentNode.Descendants("div").Where(dn => dn.Attributes.Any(a => a.Value == value)).FirstOrDefault();
			return TrimGarbageFromHtml(n?.InnerText);
		}

		private string TrimGarbageFromHtml(string html)
		{
			return html?.Replace("\r", "")?.Replace("\n", "")?.Replace("\t", "");
		}
	}
}