using AnagramSolver.Website.Models;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System.Diagnostics;
using System.Linq;
using System.Text;
using X.PagedList;




namespace AnagramSolverWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnagramGenerator anagramGenerator;
        private readonly ITxtReader txtReader;
        private readonly IDictGenerator dictionaryGenerator;
        private readonly IWordSorter wordSorter;
        private readonly IInputControler inputControler;
        private readonly ICachedWord cachedWord;
       

        public HomeController(ILogger<HomeController> logger, IAnagramGenerator anagramGenerator, ITxtReader txtReader, IDictGenerator dictionaryGenerator, IWordSorter wordSorter, IInputControler inputControler, ICachedWord cachedWord)
        {
            _logger = logger;
            this.anagramGenerator = anagramGenerator;
            this.txtReader = txtReader;
            this.dictionaryGenerator = dictionaryGenerator;
            this.wordSorter = wordSorter;
            this.inputControler = inputControler;
            this.cachedWord = cachedWord;
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
                    if(cachedWord.ReturnWordIfInCasheWords(id) == "No values")
                    {
                        ViewData["Message"] = anagram;
                    }
                    else
                    {
                        ViewData["Message"] = cachedWord.ReturnWordIfInCasheWords(id);
                    }
                    
                    cachedWord.AddCacheToServer(id, anagram);
                    WriteCookie(id);
                }
                else
                {
                    ViewData["Message"] = validation;
                    cachedWord.AddCacheToServer(id, validation);
                    WriteCookie(id);
                }
            }

            return View();
        }
        public void WriteCookie(string cookievalue)
        {
            StringBuilder words = new StringBuilder();
            var cookies = new CookieOptions();
            DateTime now = DateTime.Now;
            cookies.Expires = DateTime.Now.AddDays(1);
            words.Append($"{Request.Cookies["name"]}, {cookievalue}, {now}");
            Response.Cookies.Append("name", words.ToString());
        }

        public IActionResult ReadCookie()
        {
            ViewBag.CookieValue = Request.Cookies["name"];
            return View();
        }
        public IActionResult RemoveCookie()
        {
            return RedirectToAction("Index");
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


                    if (words.Any(x => x.word == AddString))
                    {
                        ViewData["Message"] = AddString + " is already in list";
                    }
                    else
                    {
                        txtReader.AddWordToFile(textFilePath, AddString);
                        words.OrderBy(x => x.word);
                        ViewData["Message"] = AddString + " added";
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
