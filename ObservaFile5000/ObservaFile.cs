using System;
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
        private int _counter = 0;

        public ObservaFile(string dir, string ext)
        {
            _monitoredDirectory = dir;
            _monitoredExtension = ext;

            Thread t = new Thread(new ParameterizedThreadStart(ThreadLoop));

            t.Start((Action)PerformPeekNow);
        }

        private void PerformPeekNow() {
            _counter += 1;
            Console.WriteLine($"_counter says {_counter}");
            Console.WriteLine($"_monitoredDirectory says {_monitoredDirectory}");
            Console.WriteLine($"_monitoredExtension says {_monitoredExtension}");
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
