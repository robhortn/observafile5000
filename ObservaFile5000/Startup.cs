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

            var directory = args[0];
            var extension = args[1];

            if (Helpers.IsDirectoryValid(directory) == false) {
                Console.WriteLine(Helpers.InvalidFileDirectory());
                return;
            }

            var app = new ObservaFile(directory, extension);
        }
    }
}
