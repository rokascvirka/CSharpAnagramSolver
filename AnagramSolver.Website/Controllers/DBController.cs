using Contracts;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AnagramSolver.Website.Controllers
{
    [Route("cotroller/DBView/")]
    public class DBController : Controller
    {
        private readonly IWordRepository _repository;

        public DBController(IWordRepository repository)
        {
            _repository = repository;
        }

        public IActionResult DBView()
        {
            var wordsList = _repository.GetWords();
            return View(wordsList);
        }

        [HttpGet]

        public async Task<IActionResult> DbView (string WordSearch, string sortingemp)
        {
            ViewData["GetWord"] = WordSearch;
            ViewData["Pronoun"] = string.IsNullOrEmpty(sortingemp) ? "Pronoun" : "";

            var detailsquery = from x in _repository.GetWords() select x;

            if (!String.IsNullOrEmpty(WordSearch))
            {
                detailsquery = detailsquery.Where(x => x.Word.Contains(WordSearch));
                return View(detailsquery);
            }

            switch (sortingemp)
            {
                case "Pronoun":
                    detailsquery = detailsquery.OrderBy(x => x.Pronoun);
                    break;
                default:
                    detailsquery = detailsquery.OrderByDescending(x => x.Pronoun);
                    break;
            }

            return View(await detailsquery.ToListAsync());
        }
    }
}
