using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserLogRepository
    {
        void AddUserLogToDB(string input, string anagram, string IP);
    }
}
