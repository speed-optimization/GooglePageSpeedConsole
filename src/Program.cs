using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace GooglePageSpeedConsole
{
	class Program
	{
		/** 
		<summary>Uses Google Page Speed's API to write the Page Speed score of a given URL.</summary>
		<param name="args">The first param is a required String: the Google API key, and the second param is a required String: the URL of the site to test.</param>
		<example><c>GooglePageSpeedConsole.exe 08234klfuiop093248jlKa http://www.hotmail.com</c></example>
		*/
		static void Main(string[] args)
		{
			string json = GetJsonFromGoogle(args[0], args[1]);
			Result result = JsonConvert.DeserializeObject<Result>(json);
			Console.WriteLine("Google Page Speed Score: " + result.Score);
			if (args.Length > 2)
			{
				int minimumScore = Int32.Parse(args[2]);
				if (result.Score < minimumScore)
				{
					Environment.Exit(-1);
				}
			}
			Environment.Exit(0);
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