using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace GooglePageSpeedConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			string json = GetJsonFromGoogle(args[0], args[1]);
			Result result = JsonConvert.DeserializeObject<Result>(json);
			Console.WriteLine(result.Score);
		}
		
		private static string GetJsonFromGoogle(string apiKey, string siteUrl)
		{
			string pageSpeedRequestUrl = string.Format("https://www.googleapis.com/pagespeedonline/v1/runPagespeed?url={0}/&key={1}", siteUrl, apiKey);
			WebClient webClient = new WebClient();
			Byte[] pageData = webClient.DownloadData(pageSpeedRequestUrl);
			string json = Encoding.ASCII.GetString(pageData);
			return json;
		}
	}
}