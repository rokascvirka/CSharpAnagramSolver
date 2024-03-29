﻿using AnagramSolver.Website.Models;
using BuisnessLogic;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;




namespace AnagramSolverWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnagramGenerator _anagramGenerator;
        private readonly ITxtReader _txtReader;
        private readonly IDictGenerator _dictionaryGenerator;
        private readonly IWordSorter _wordSorter;
        private readonly IInputControler _inputControler;
        private readonly ICachedWordService _cashedWordService;
        private readonly IUserLogService _userLogService;
       

        public HomeController(ILogger<HomeController> logger, IAnagramGenerator anagramGenerator, ITxtReader txtReader,
            IDictGenerator dictionaryGenerator, IWordSorter wordSorter, IInputControler inputControler, 
            ICachedWordService cashedWordService, IUserLogService userLogService) 
        {
            _logger = logger;
            _anagramGenerator = anagramGenerator;
            _txtReader = txtReader;
            _dictionaryGenerator = dictionaryGenerator;
            _wordSorter = wordSorter;
            _inputControler = inputControler;
            _cashedWordService = cashedWordService;
            _userLogService = userLogService;
        }

        public IActionResult Index(string id)
        {
            var textFilePath = "C:\\Users\\rokas.cvirka\\Documents\\" + "zodynas" + ".txt";
            var txtfile = _txtReader.TxtFileReader(textFilePath);
            var words = _txtReader.FirstWordReader(txtfile);
            
            var wordsInDictionary = _dictionaryGenerator.DictGenerator(words);
            if (id != null)
            {
                var validation = _inputControler.InputVerifyer(id);

                if (validation == "valid")
                {
                    id = id.ToLower();
                    
                    if(_cashedWordService.ReturnWordIfInCasheWords(id) == "No values")
                    {
                        var anagram = _anagramGenerator.AnagramGeneratorMethod(id, _wordSorter, wordsInDictionary);
                        _cashedWordService.AddCacheToServer(id, anagram);
                        ViewData["Message"] = anagram;

                        _userLogService.AddUserLogToDB(id, anagram);
                    }
                    else
                    {
                        var cachedAnagram = _cashedWordService.ReturnWordIfInCasheWords(id);
                        ViewData["Message"] = cachedAnagram;
                        _userLogService.AddUserLogToDB(id, cachedAnagram);

                    }

                    WriteCookie(id);

                }
                else
                {
                    ViewData["Message"] = validation;
                    _cashedWordService.AddCacheToServer(id, validation);
                    WriteCookie(id);
                }
                
            }

            return View();
        }

        public IActionResult AddNewWordInFile(string AddString)
        {
            var textFilePath = "C:\\Users\\rokas.cvirka\\Documents\\" + "zodynas" + ".txt";
            var txtfile = _txtReader.TxtFileReader(textFilePath);
            var words = _txtReader.FirstWordReader(txtfile);


            if (AddString != null)
            {
                var validation = _inputControler.InputVerifyer(AddString);

                if (validation == "valid")
                {
                    AddString = AddString.ToLower();


                    if (words.Any(x => x.word == AddString))
                    {
                        ViewData["Message"] = AddString + " is already in list";
                    }
                    else
                    {
                        _txtReader.AddWordToFile(textFilePath, AddString);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
