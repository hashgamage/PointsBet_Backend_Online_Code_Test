using System.Text;
using System.Linq;

namespace PointsBet_Backend_Online_Code_Test
{

    /// <summary>
    /// Convert an array of strings into a comma seperated string with optional quoting
    /// 
    /// Note: Despite the method name suggesting a List return type, but this method return string.
    /// The method does more than a simple split operation which the name implies. 
    /// "ToCommaSeparatedList" method with quote param as generic delimiter formatter with quoting.
    /// 
    /// In a greenfield project, better names might be: 
    /// -ToCommaSeparatedString() for clear idea about return type.
    /// -FormatDelimiter() for generic delimiter formatting.
    /// </summary>
    public static class StringFormatter
    {

        public static string ToCommaSeparatedList(string[] items, string quote)
        {
            //input validation
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            //Handle Empty Array
            if (items.Length == 0)
                return string.Empty;

            //Handle null quote parameter
            quote ??= string.Empty;

            return string.Join(", ", items.Select(item => FormatItem(item, quote)));
        }

        private static string FormatItem(string item, string quote)
        {
            item ??= string.Empty;

            if (string.IsNullOrEmpty(quote))
                return item;

            if (item.Contains(quote))
            {
                item = item.Replace(quote, quote + quote);
            }

            return $"{quote}{item}{quote}";
        }
    }
}
