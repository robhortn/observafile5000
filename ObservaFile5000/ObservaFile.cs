using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace ObservaFile5000
{
    public class ObservaFile
    {
        readonly string _monitoredDirectory;
        readonly string _monitoredExtension;
        private FileInfo[] _lastScanned;

        public ObservaFile(string dir, string ext)
        {
            _monitoredDirectory = dir;
            _monitoredExtension = ext;
            Begin();
        }

        private void Begin() {
            Console.WriteLine($"Application starting at {Helpers.GetNowWithDate()}");
            var logPeekWhere = $"Scanning {_monitoredDirectory} for changes in files of type {_monitoredExtension} {Environment.NewLine}";
            Console.WriteLine(logPeekWhere);

            BuildInitialFileList();

            Thread t = new Thread(new ParameterizedThreadStart(ThreadLoop));
            t.Start((Action)PerformPeekNow);
        }

        private void PerformPeekNow() {
            var peekNowMsg = $"{Helpers.GetNow()} scanning for changes ...";
            Console.WriteLine(peekNowMsg);
        }

        private void ThreadLoop(object callback)
        {
            while (true)
            {
                ((Delegate)callback).DynamicInvoke(null);
                Thread.Sleep(10000);
            }
        }

        private void BuildInitialFileList() {
            Console.Write("Building initial file list for scan.  ");

            DirectoryInfo info = new DirectoryInfo(_monitoredDirectory);
            _lastScanned = info.GetFiles(_monitoredExtension);
            if (_lastScanned.Count() == 0) Console.WriteLine("No files currently match pattern");
        }
    }
}
