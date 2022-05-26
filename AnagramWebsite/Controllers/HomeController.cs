using AnagramWebsite.Models;
using Contracts;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using X.PagedList;


namespace AnagramWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnagramGenerator anagramGenerator;
        private readonly ITxtReader txtReader;
        private readonly IDictGenerator dictionaryGenerator;
        private readonly IWordSorter wordSorter;
        private readonly IInputControler inputControler;

        public HomeController(ILogger<HomeController> logger, IAnagramGenerator anagramGenerator, ITxtReader txtReader, IDictGenerator dictionaryGenerator, IWordSorter wordSorter, IInputControler inputControler)
        {
            _logger = logger;
            this.anagramGenerator = anagramGenerator;
            this.txtReader = txtReader;
            this.dictionaryGenerator = dictionaryGenerator;
            this.wordSorter = wordSorter;
            this.inputControler = inputControler;
        }

        public IActionResult Index(string id)
        {
            var textFilePath = "C:\\Users\\rokas.cvirka\\Documents\\" + "zodynas" + ".txt";
            var words = txtReader.TxtFileReader(textFilePath);
            var wordsInDictionary = dictionaryGenerator.DictGenerator(words);

            var validation = inputControler.InputVerifyer(id);
            if (validation == "valid")
            {
                id = id.ToLower();
                var anagram = anagramGenerator.AnagramGeneratorMethod(id, wordSorter, wordsInDictionary);

                ViewData["Message"] = anagram;
                
            }
            else
            {
                ViewData["Message"] = validation;
            }

            return View();
        }

        public IActionResult WordsList(string searching, int? page)
        {
            var textFilePath = "C:\\Users\\rokas.cvirka\\Documents\\" + "zodynas" + ".txt";
            var words = txtReader.TxtFileReader(textFilePath);

            var pageNumber = page ?? 1;
            int pageSize = 100;
            var onePageOfWords = words.ToPagedList(pageNumber, pageSize);

            return View(onePageOfWords);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
