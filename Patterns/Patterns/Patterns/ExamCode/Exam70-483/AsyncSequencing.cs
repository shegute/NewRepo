using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.ExamCode.Exam70_483
{
    public class AsyncSequencing
    {

        public static void Run()
        {
            AsyncSequencing ex = new AsyncSequencing();
            Console.WriteLine("**************");
            Console.WriteLine("1");
            Task<int> i = ex.SumPageSizesAsync("http://msdn.microsoft.com");
            Console.WriteLine("4");
            i.Wait();
            //Console.WriteLine("Value:{0}", i.Result);
            Console.WriteLine("10");
        }

        private async Task<int> SumPageSizesAsync(string url)
        {
            Console.WriteLine("2");
            // GetURLContents returns the contents of url as a byte array.  
            byte[] urlContents = await GetURLContentsAsync(url);

            Console.WriteLine("7");
            var total = 0;
            DisplayResults(url, urlContents);

            Console.WriteLine("9");
            // Update the total.  
            total = urlContents.Length;
            return total;

        }


        private async Task<byte[]> GetURLContentsAsync(string url)
        {
            // The downloaded resource ends up in the variable named content.  
            var content = new MemoryStream();
            Console.WriteLine("3");
            // Initialize an HttpWebRequest for the current URL.  
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for  
            // the response.  
            // Note: you can't use HttpWebRequest.GetResponse in a Windows Store app.  
            Task<WebResponse> webResponse = webReq.GetResponseAsync();
            using (WebResponse response = await webResponse)
            {
                // Get the data stream that is associated with the specified URL.  
                using (Stream responseStream = response.GetResponseStream())
                {
                    Console.WriteLine("5");
                    // Read the bytes in responseStream and copy them to content.    
                    await responseStream.CopyToAsync(content);
                }
            }

            Console.WriteLine("6");
            // Return the result as a byte array.  
            return content.ToArray();
        }

        private void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format   
            // is designed to be used with a monospaced font, such as  
            // Lucida Console or Global Monospace.  
            var bytes = content.Length;
            // Strip off the "http://".  
            var displayURL = url.Replace("http://", "");

            Console.WriteLine("8 displayURL:{0} , bytes:{1}", displayURL, bytes);
        }
    }
}
