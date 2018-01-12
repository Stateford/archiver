using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace archiver.src
{
    class Request
    {
        public static string get(string url)
        {

            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                WebRequest req = WebRequest.Create(url);
                Stream objStream = req.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string response = objReader.ReadToEnd();

                return response;
            }
        }

    }
}
