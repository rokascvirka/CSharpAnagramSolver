using System.Collections.Generic;

namespace Contracts
{
    public interface ICachedWordRepository
    {
        void AddCacheToServer(string input, string anagram);
        bool CheckForWordInCasheTable(string input);
        public string ReturnWordIfInCasheWords(string input);
    }
}
