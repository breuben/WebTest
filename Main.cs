using System;
using System.IO;
using System.Net;
using System.Threading;
namespace WebTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com/");
			
			HttpWebResponse response;
			
			Console.Write("Waiting...");
			response = (HttpWebResponse)request.GetResponse();
			
			using (Stream responseStream = response.GetResponseStream())
			{
				using (TextReader reader = new StreamReader(responseStream))
				{
					Console.WriteLine(reader.ReadToEnd());
				}
			}
		}
	}
}

