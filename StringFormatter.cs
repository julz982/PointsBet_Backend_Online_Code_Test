using System.Text;

namespace PointsBet_Backend_Online_Code_Test
{
    /*
    Improve a block of code as you see fit in C#.
    You may make any improvements you see fit, for example:
      - Cleaning up code
      - Removing redundancy
      - Refactoring / simplifying
      - Fixing typos
      - Any other light-weight optimisation
    */
    public static class StringFormatter
    {
        /*
        Method to separate a list provided as a string array, surrounded in the provided quotation punctuation, if any.
        */
        public static string ToCommaSeparatedList(string[] items, string quote)
        {
            // Safety checks on the inputs to the method.
            if (items == null) 
            {
                throw new ArgumentNullException(nameof(items));
            }
            if (items.Length == 0) 
            {
                throw new ArgumentException("Input array can not be empty", nameof(items));
            }
            if(items.Length == 1) 
            {
                // If the items string array only contains 1 item, return that directly to avoid unnecessary calculations.
                return $"{quote}{items[0] ?? string.Empty}{quote}";
            }

            // Calculate capacity.
            var capacity = StringBuilderCapacity(items, quote);
            var commaSeparatedList = new StringBuilder(capacity);

            // Build the output
            for (int i = 1; i < items.Length; i++)
            {
                commaSeparatedList.Append($", {quote}{items[i] ?? string.Empty}{quote}");
            }
            Console.Writeline();
            return commaSeparatedList.ToString();
        }

        /*
        Calculation to ensure the StringBuilder is not inefficient and only allocates the appropriate memory.
        */
        public static int StringBuilderCapacity(string[] items, string quote) 
        {
            var totalLength = items.Sum(items => items?.Length ?? 0);
            var quoteLength = quote.Length * 2 * items.Length;
            var separatorLength = 2 * (items.Length - 1);
            return totalLength + quoteLength + separatorLength;
        }
    }
}
