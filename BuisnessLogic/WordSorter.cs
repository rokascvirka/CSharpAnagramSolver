using System;
using System.Collections.Generic;
using System.Text;
using Contracts;

namespace BuisnessLogic 
{
    public class WordSorter : IWordSorter
    {
        public string SortRandomWord(string mainWordForAnagram)
        {

            var sorted = mainWordForAnagram.ToCharArray();
            Array.Sort(sorted);
            var sortedMainWord = string.Join("", sorted);

            return sortedMainWord;
        }
    }
}
