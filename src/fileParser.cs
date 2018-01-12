using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using archiver.src.windows;

namespace archiver.src
{
    class FileParser
    {
        private bool url_;
        private bool file_;
        private string path_;
        private string savePath_;

        public FileParser(string path, string savePath = "./")
        {

            path_ = path;
            savePath_ = savePath;

            if (Path.GetExtension(path) == ".txt")
                file_ = true;
            else
            {
                Uri uriResult;
                bool result = Uri.TryCreate(path, UriKind.Absolute, out uriResult) &&
                              (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (result)
                    url_ = true;
            }
        }

        private static string getTimeStamp()
        {
            DateTime date = DateTime.Now;
            return date.ToString("_MM-dd-yyyy_HH-mm");
        }

        private void writeFile(string url)
        {
            string save = savePath_;
            Uri uri = new Uri(url);
            save += uri.Host;
            save += getTimeStamp();
            save += ".html";
            System.IO.File.WriteAllText(save, Request.get(url));
        }

        public void archive()
        {
            if (url_)
            {
                writeFile(path_);
            }

            else if (file_)
            {
                string[] lines = File.ReadAllLines(path_);
                //Thread[] threads;
                List<Thread> threads = new List<Thread>();

                foreach (string line in lines)
                {
                    threads.Add(new Thread(() =>
                    {
                        writeFile(line);
                    }));

                }

                // start each thread
                foreach (var thread in threads)
                {
                    thread.Start();
                }
            }
            else
            {
                error errorWin = new error();
                errorWin.Show();
            }


        }
    }
}
