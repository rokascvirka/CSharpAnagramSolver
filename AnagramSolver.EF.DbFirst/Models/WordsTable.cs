using System;
using System.Collections.Generic;

namespace AnagramSolver.EF.DbFirst.Models
{
    public partial class WordsTable
    {
        public string Word { get; set; } = null!;
        public string? Pronoun { get; set; }
        public int Id { get; set; }
    }
}
