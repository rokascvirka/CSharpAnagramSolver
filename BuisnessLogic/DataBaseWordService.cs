using Contracts;
using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class DataBaseWordService : IDataBaseWordService

    {
        private readonly IWordRepository _wordRepository;

        public DataBaseWordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public List<UserLogModel> GetUserLogInfo()
        {
           return _wordRepository.GetUserLogInfo();
        }
    }
}
