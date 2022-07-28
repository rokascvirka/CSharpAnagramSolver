using AnagramSolver.EF.DbFirst.Data;
using AnagramSolver.EF.DbFirst.Models;
using Contracts;

namespace AnagramSolver.EF.DbFirst
{
    public class CachedWordDbFirstRepository : ICachedWordRepository
    {
        private readonly WordsContext _context = new WordsContext();
        public void AddCacheToServer(string input, string anagram)
        {
            
            var cached = new CashedWord// EF model
            {

                Words = input,
                Anagram = anagram,
                Id = Guid.NewGuid().ToString()

            };

            _context.CashedWords.Add(cached);
            _context.SaveChanges();

        }

        public bool CheckForWordInCasheTable(string input)
        {

                var items = _context.CashedWords.ToList();
                bool result = items.Any(x => x.Words == input);

                return result;
        }

        public string ReturnWordIfInCasheWords(string input)
        {
            
            var items = _context.CashedWords.ToList();

            var result = items.Where(x => x.Words == input).Select(x => x.Anagram).FirstOrDefault();
            
            if(result == null)
            {
                return "No values";
            }

            return result;
        }
    }


}
