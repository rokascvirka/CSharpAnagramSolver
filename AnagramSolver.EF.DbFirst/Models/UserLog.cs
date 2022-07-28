using System;
using System.Collections.Generic;

namespace AnagramSolver.EF.DbFirst.Models
{
    public partial class UserLog
    {
        public string UserIp { get; set; } = null!;
        public DateTime SearchTime { get; set; }
        public string SearchWord { get; set; } = null!;
        public string Anagram { get; set; } = null!;
        public string Id { get; set; }
    }
}
