using System.Collections.Generic;

namespace Contracts
{
    public interface ICachedWordService
    {
        void AddCacheToServer(string input, string anagram);
        bool CheckForWordInCasheTable(string input);
        public string ReturnWordIfInCasheWords(string input);
    }
}
