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
			
//			response = (HttpWebResponse)request.GetResponse();
			IAsyncResult asyncResult = request.BeginGetResponse(null, null);
			Console.Write("Waiting...");
			while (!asyncResult.IsCompleted)
			{
				Console.Write(".");
				Thread.Sleep(500);
			}
			Console.WriteLine();
			
			response = (HttpWebResponse)request.EndGetResponse(asyncResult);
			
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

