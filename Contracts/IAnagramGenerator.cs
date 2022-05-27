using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAnagramGenerator

    {
        public string AnagramGeneratorMethod(string inputWord, IWordSorter wordSorter, Dictionary<string, List<string>> wordsInDictionary);
    }
}