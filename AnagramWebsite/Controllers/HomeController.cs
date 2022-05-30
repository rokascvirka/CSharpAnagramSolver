using AnagramWebsite.Models;
using Contracts;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            var txtfile = txtReader.TxtFileReader(textFilePath);
            var words = txtReader.FirstWordReader(txtfile);

            var wordsInDictionary = dictionaryGenerator.DictGenerator(words);
            if (id != null)
            {
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
            }

            return View();
        }

        public IActionResult WordsList(string searchString, int? page)
        {
            var textFilePath = "C:\\Users\\rokas.cvirka\\Documents\\" + "zodynas" + ".txt";
            var txtfile = txtReader.TxtFileReader(textFilePath);
            var words = txtReader.FirstWordReader(txtfile);

            var pageNumber = page ?? 1;
            int pageSize = 100;

            if (!String.IsNullOrEmpty(searchString))
            {
                var foundwords = words.Where(w => w.word.Contains(searchString)).ToList();

                var foundWordsPageOfWords = foundwords.ToPagedList(pageNumber, pageSize);

                return View(foundWordsPageOfWords);
            }
            else
            {
                var onePageOfWords = words.ToPagedList(pageNumber, pageSize);
                return View(onePageOfWords);
            }
        }

        public IActionResult AddNewWordInFile(string AddString)
        {
            var textFilePath = "C:\\Users\\rokas.cvirka\\Documents\\" + "zodynas" + ".txt";
            var txtfile = txtReader.TxtFileReader(textFilePath);
            var words = txtReader.FirstWordReader(txtfile);

            if (AddString != null)
            {
                var validation = inputControler.InputVerifyer(AddString);

                if (validation == "valid")
                {
                    AddString = AddString.ToLower();
                    var entity = new Word
                    {
                        word = AddString
                    };

                    if (words.Contains(entity))
                    {
                        ViewData["Message"] = entity.ToString() + " is already in list";
                    }
                    else
                    {
                        words.Insert(0, entity);
                        ViewData["Message"] = entity.ToString() + " added";
                    }
                }
                else
                {
                    ViewData["Message"] = validation;
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
