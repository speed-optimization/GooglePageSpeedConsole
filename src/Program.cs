using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace GooglePageSpeedConsole
{
	class Program
	{
		/** 
		<summary>Main entry point to the console app. Uses Google Page Speed's API to Console.Write the Page Speed score of a given URL.</summary>
		<param name="args[0]">String. Required. The API key to Google Page Speed.</param>
		<param name="args[1]">String. Required. The URL of the site to test.</param>
		<example><c>GooglePageSpeedConsole.exe 08234klfuiop093248jlKa http://www.hotmail.com</c></example>
		*/
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