﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObservaFile5000
{
    public class ObservaFile
    {
        readonly string _monitoredDirectory;
        readonly string _monitoredExtension;

        public ObservaFile(string dir, string ext)
        {
            _monitoredDirectory = dir;
            _monitoredExtension = ext;

            Thread t = new Thread(new ParameterizedThreadStart(ThreadLoop));
            Console.WriteLine($"Application starting at {Helpers.GetNowWithDate()}");
            var logPeekWhere = $"Scanning {_monitoredDirectory} for changes in files of type {_monitoredExtension} {Environment.NewLine}";
            Console.WriteLine(logPeekWhere);

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
    }
}
