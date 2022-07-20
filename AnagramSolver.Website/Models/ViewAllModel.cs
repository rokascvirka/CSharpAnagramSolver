using Contracts;

namespace AnagramSolver.Website.Models
{
    public class ViewAllModel
    {
        public PaginatedList<Word> WordList {get; set; }
        public string Search { get; set; }
    }
}
