using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogic
{
    public static class StringExtensions
    {
        public static string RemoveSpaces(this string word) 
        {
            var inputWord = word.ToCharArray();
            var correctInput = "";

            foreach (char letter in inputWord)
            {
                if (!Char.IsWhiteSpace(letter))
                {
                    correctInput += letter;
                }
            }
            return correctInput;
        }
    }
}
