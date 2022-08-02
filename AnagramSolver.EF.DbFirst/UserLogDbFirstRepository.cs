using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramSolver.EF.DbFirst.Data;
using AnagramSolver.EF.DbFirst.Models;
using Contracts;

namespace AnagramSolver.EF.DbFirst
{
    public class UserLogDbFirstRepository : IUserLogRepository
    {
        private readonly WordsContext _context = new WordsContext();
        public void AddUserLogToDB(string input, string anagram, string ip)
        {
            var logsList = _context.UserLogs.ToList();
            var userLog = new UserLog
            {
                UserIp = ip,
                SearchTime = DateTime.Now,
                SearchWord = input,
                Anagram = anagram,
                Id = Guid.NewGuid().ToString()

            };

            _context.UserLogs.Add(userLog);
            _context.SaveChanges();
        }
    }
}
