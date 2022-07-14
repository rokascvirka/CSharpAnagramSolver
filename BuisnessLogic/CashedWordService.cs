using Contracts;

namespace Buisnesslogic
{
    public class CashedWordService : ICachedWordService
    {
        private readonly ICachedWordRepository _cashedWordRepository;
        public CashedWordService(ICachedWordRepository cachedWordRepository)
        {
            _cashedWordRepository = cachedWordRepository;
        }
        public void AddCacheToServer(string input, string anagram)
        {
            if (input != null)
            {
                _cashedWordRepository.AddCacheToServer(input, anagram);
            }
        }
        public bool CheckForWordInCasheTable(string input)
        {
            return _cashedWordRepository.CheckForWordInCasheTable(input);
        }
        public string ReturnWordIfInCasheWords(string input)
        {
            return _cashedWordRepository.ReturnWordIfInCasheWords(input);
        }

    }

}
