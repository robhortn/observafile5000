using System;

namespace ObservaFile5000
{
    class Startup
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 2) {
                Console.WriteLine(Helpers.ArgumentsMissing());
                return;
            }

            var app = new ObservaFile(args[0], args[1]);
        }
    }
}
