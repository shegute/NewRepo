using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Patterns.ExamCode.Exam70_483
{
    public class AsyncRentrancy
    {

        public static void Run()
        {
            AsyncRentrancy ex = new AsyncRentrancy();
            Console.WriteLine("**************");
            CancellationTokenSource cts = new CancellationTokenSource();

            Console.WriteLine("Start code");
            bool notCancelled = true; int count = 0;

            //or after sometime
            //cts.CancelAfter(2000);
            Task<int> iti2 = ex.AccessTheWebAsync("http://www.google.com", cts);
            Task<int> iti = ex.AccessTheWebAsync("http://www.cnn.com", cts);
            Task.WaitAll(iti, iti2); 
            cts = new CancellationTokenSource();

            Console.WriteLine("End Code");
        }

        // ***Provide a parameter for the CancellationToken.  
        public async Task<int> AccessTheWebAsync(string url, CancellationTokenSource cts)
        {
            HttpClient client = new HttpClient();
            try
            {
                Console.WriteLine("AccessTheWebAsync started for :{0}", url);
                // GetAsync returns a Task<HttpResponseMessage>.   
                // ***The ct argument carries the message if the Cancel button is chosen.  
                int i = 0;
                HttpResponseMessage response = await client.GetAsync(url, cts.Token);
                cts.Cancel();
                Console.WriteLine("AccessTheWebAsync called client.GetAsync for :{0}", url);
                // Retrieve the website contents from the HttpResponseMessage.  
                byte[] urlContents = await response.Content.ReadAsByteArrayAsync();
                Console.WriteLine("AccessTheWebAsync called response.Content.ReadAsByteArrayAsync for :{0}", url);

                DisplayResults(url, urlContents);
                Console.WriteLine("AccessTheWebAsync complete for :{0}", url);
                // The result of the method is the length of the downloaded website.  
                return urlContents.Length;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\r\nDownload canceled with cancel token for :{0} \r\n", url);
            }
            catch (Exception)
            {
                Console.WriteLine("\r\nDownload failed.\r\n");
            }

            return 0;
        }

        private void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format   
            // is designed to be used with a monospaced font, such as  
            // Lucida Console or Global Monospace.  
            var bytes = content.Length;
            // Strip off the "http://".  
            var displayURL = url.Replace("http://", "");

            Console.WriteLine("DisplayResults URL:{0} , bytes:{1}", displayURL, bytes);
        }
    }
}
