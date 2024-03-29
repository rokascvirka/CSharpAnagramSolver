﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using RestSharp;

namespace AnagramSolver.Website.Controllers
{

    [Route("api/{controller}/{action}/{id?}")] //api/{controller}/{action} 
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IAnagramGenerator anagramGenerator;
        private readonly ITxtReader txtReader;
        private readonly IDictGenerator dictionaryGenerator;
        private readonly IWordSorter wordSorter;
        private readonly IInputControler inputControler;

        public ValuesController(IAnagramGenerator anagramGenerator, ITxtReader txtReader, IDictGenerator dictionaryGenerator, IWordSorter wordSorter, IInputControler inputControler)
        {
            this.anagramGenerator = anagramGenerator;
            this.txtReader = txtReader;
            this.dictionaryGenerator = dictionaryGenerator;
            this.wordSorter = wordSorter;
            this.inputControler = inputControler;
        }
        public string GenerateAnagram(string id)
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

                    return "{id : " + '"'+ anagram +'"' + "}";

                }
                else
                {
                    return "{id : " + '"' + validation + '"' + "}";
                }
            }

            return string.Empty;
        }
    }
}

