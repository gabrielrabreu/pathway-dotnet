using System.Collections.Generic;
using System.IO;

namespace Core.Domain.Common
{
    public static class StringExtensions
    {
        public static IEnumerable<string> ReadLines(this string content)
        {
            var lines = new List<string>();

            using (var reader = new StringReader(content))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        lines.Add(line);
                    }
                }
            }

            return lines;
        }
    }
}
