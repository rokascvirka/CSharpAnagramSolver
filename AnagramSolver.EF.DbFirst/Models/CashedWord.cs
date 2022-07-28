using System;
using System.Collections.Generic;

namespace AnagramSolver.EF.DbFirst.Models
{
    public partial class CashedWord
    {
        public string? Words { get; set; }
        public string? Anagram { get; set; }
        public string Id { get; set; }
    }
}
