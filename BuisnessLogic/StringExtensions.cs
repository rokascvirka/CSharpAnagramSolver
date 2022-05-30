using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogic
{
    public static class StringExtensions
    {
        public static string RemoveSpaces(this string word) 
        {
            word =  word.Replace("\t", string.Empty);
            word = word.Replace(" ", string.Empty);

            return word;
        }
    }
}
