using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDataBaseWordService
    {
        List<UserLogModel> GetUserLogInfo();
    }
}
