
using System.Text.RegularExpressions;

namespace ObservaFile5000
{
    public static class StringExtensions
    {
        public static string TrimAndReduce(this string str)
        {
            return ConvertWhitespacesToSingleSpaces(str).Trim();
        }

        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }

        public static string FormatAsPhoneNumber(this string value) {
            if (value == null || value.Length < 10) return "(###) ###-####";
            var converted = ConvertToNumbersOnly(value);
            var totalLength = converted.Length;

            string phone = string.Empty, prefix = string.Empty;

            if (totalLength > 10) {
                phone = converted.Substring(totalLength - 10, 10);
                prefix = $"+{converted.Substring(0, totalLength - phone.Length)} ";  
            }

            var result = $"{prefix}({converted.Substring(0, 3)}) {converted.Substring(3, 3)}-{converted.Substring(6, 4)}";
            return result;
        }

        public static string ConvertToNumbersOnly(this string value) {
            if (value == null) return string.Empty;
            return Regex.Replace(value, @"[^\d]", "");
        }
        
        private static string FormatPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return phone;

            var numeric = new string(phone.Where(c => char.IsDigit(c)).ToArray());
            if (numeric.Length != 10)
                return phone;

            var reformatted = String.Format("{0:(###) ###-####}", numeric);
            return reformatted;
        }
    }
}
