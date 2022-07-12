using System.Collections.Generic;

namespace Contracts
{
    public interface ICachedWord
    {
        void AddCacheToServer(string input, string anagram);
        List<string> CheckForWordInCasheTable(string input);
    }
}
