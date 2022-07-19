using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class UserLogModel
    {
        public string UserIP { get; set; }
        public DateTime SearchTime { get; set; }

        public string SearchWord { get; set; }
        public string Anagram { get; set; }
    }
}
