using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservaFile5000
{
    static class Helpers
    {
        public static string ArgumentsMissing() {
            var returnVal = new StringBuilder();
            returnVal.Append("--------------------------------------------------------------------------" + Environment.NewLine);
            returnVal.Append("Parameters are missing or invalid.  Unable to continue." + Environment.NewLine);
            returnVal.Append("--------------------------------------------------------------------------" + Environment.NewLine);
            returnVal.Append("USAGE: Observafile5000 %1 %2" + Environment.NewLine);
            returnVal.Append("WHERE %1 is the directory that contains the files you want to watch" + Environment.NewLine);
            returnVal.Append("AND %2 is the filename extension you want to monitor.");
            return returnVal.ToString();
        }
    }
}
