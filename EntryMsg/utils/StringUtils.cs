using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utils
{
    internal class StringUtils
    {
        public static string Join(string[] array, string delimiter, int startIndex, int endIndex)
        {
            if (array == null) return null;
            if (endIndex - startIndex <= 0) return "";
            var list = new List<string>();
            for (int i = startIndex; i < endIndex; i++) list.Add(array[i]);
            return string.Join(delimiter, list.ToArray());
        }
    }
}
