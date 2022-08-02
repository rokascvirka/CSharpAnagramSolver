using AnagramSolver.EF.DbFirst.Data;
using AnagramSolver.EF.DbFirst.Models;
using Contracts;

namespace AnagramSolver.EF.DbFirst
{
    public class CachedWordDbFirstRepository : ICachedWordRepository
    {
        private readonly WordsContext _context = new ();
        public void AddCacheToServer(string input, string anagram)
        {
            
            var cached = new CashedWord
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
            return _context.CashedWords.Any(x => x.Words == input);
        }

        public string ReturnWordIfInCasheWords(string input)
        {
            var result = _context.CashedWords.Where(x => x.Words == input).Select(x => x.Anagram).FirstOrDefault();
            
            if(result == null)
            {
                return "No values";
            }

            return result;
        }
    }


}
