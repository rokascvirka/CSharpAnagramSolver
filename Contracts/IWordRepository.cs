using Contracts.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IWordRepository
    {
        List<UserLogModel> GetUserLogInfo();
    }
}
