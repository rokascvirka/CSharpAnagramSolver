using AnagramSolver.EF.DbFirst.Data;
using AnagramSolver.EF.DbFirst.Models;
using Contracts;
using Contracts.Models;

namespace AnagramSolver.EF.DbFirst
{
    public class WordDbFirstRepository : IWordRepository
    {
        private readonly WordsContext _context = new WordsContext();

        public List<UserLogModel> GetUserLogInfo()
        {
            var wordlist = new List<UserLogModel>();

            var logs = _context.UserLogs;

            // 1
            wordlist = logs.Select(log => new UserLogModel
            {
                UserIP = log.UserIp,
                SearchTime = log.SearchTime,
                SearchWord = log.SearchWord,
                Anagram = log.Anagram
            }).ToList();

            // 2
            wordlist = logs.Select(log => MapUserModel(log)).ToList();


            return wordlist;
        }

        private static UserLogModel MapUserModel(UserLog log)
        {
            return new UserLogModel
            {
                UserIP = log.UserIp,
                SearchTime = log.SearchTime,
                SearchWord = log.SearchWord,
                Anagram = log.Anagram
            };
        }
    }
}
