using Contracts;
using Microsoft.AspNetCore.Mvc;

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
    }
}
