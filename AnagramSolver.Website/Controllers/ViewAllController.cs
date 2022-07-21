using AnagramSolver.Website.Models;
using Contracts;
using Microsoft.AspNetCore.Mvc;


namespace AnagramSolver.Website.Controllers
{
    [Route("controller/{action}/{pageNumber?}")]
    public class ViewAllController : Controller
    {
        private readonly ITxtReader _txtReader;

        public ViewAllController(ITxtReader txtReader)
        {
            _txtReader = txtReader;
        }

        public IActionResult ViewAll(string searchText, int? page)
        {
            var textFilePath = "C:\\Users\\rokas.cvirka\\Documents\\" + "zodynas" + ".txt";
            var txtfile = _txtReader.TxtFileReader(textFilePath);
            var words = _txtReader.FirstWordReader(txtfile);

            var pageNumber = page ?? 1;
            int pageSize = 100;

            if (!string.IsNullOrEmpty(searchText))
            {
                var foundwords = words.Where(w => w.word.Contains(searchText)).ToList();

                var foundWordsPageOfWords = PaginatedList<Word>.ToPageList(foundwords, pageNumber, pageSize);

                ViewAllModel model = new ViewAllModel();

                model.WordList = foundWordsPageOfWords;
                model.Search = searchText;

                return View(model);
            }
            else
            {
                var onePageOfWords = PaginatedList<Word>.ToPageList(words, pageNumber, pageSize);
                ViewAllModel model = new ViewAllModel();

                model.WordList = onePageOfWords;

                return View(model);
                
            }
        }
    }
}
