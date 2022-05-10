using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAnagramGenerator

    {
        void AnagramGeneratorMethod(ITxtReader TxtFilerReader, IMainWordPicker MainWordPicker, IWordSorter wordSorter, Dictionary<string, List<string>> wordsInDictionary);
    }
}
