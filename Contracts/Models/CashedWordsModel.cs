using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class CashedWordsModel
    {
        public int Id { get; set; }
        public string Words { get; set; }
        public string Anagram { get; set; }    
    }
}
