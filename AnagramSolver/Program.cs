using BuisnessLogic;
using System;
using System.Collections.Generic;
using Contracts;
using System.Linq;


namespace AnagramSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            IMainWordPicker MainWordPicker = new WordPicker();

            IWordSorter WordSorter = new WordSorter();

            IDictGenerator DictionaryGenerator = new DictionaryGenerator();

            IAnagramGenerator anagramGenerator = new AnagramGenerator();

            ITxtReader TxtFilerReader = new TxtReader();
            List<string> txtFile = System.IO.File.ReadLines(@"C:\Users\rokas.cvirka\Documents\zodynas1.txt").ToList();
            var words = TxtFilerReader.TxtFileReader(txtFile);

            var wordsInDictionary = DictionaryGenerator.DictGenerator(words);

            anagramGenerator.AnagramGeneratorMethod(TxtFilerReader, MainWordPicker, WordSorter, wordsInDictionary);

            

            // Unit tests
            //if (VerifyInput(null) == "valid")
            //{
            //    Console.WriteLine("Input can't be null");
            //}

            //if (VerifyInput("") == "valid")
            //{
            //    Console.WriteLine("Input can't be empty");
            //}

            //if (VerifyInput("Labas") != "valid")
            //{
            //    Console.WriteLine("Does't work ToLower()");
            //}

            //if (VerifyInput("      Labas") != "valid")
            //{
            //    Console.WriteLine("Does't work Trim() from beggining");
            //}

            //if (VerifyInput("      Labas  ") != "valid")
            //{
            //    Console.WriteLine("Does't work Trim() from end");
            //}
            //if (VerifyInput("123") == "valid")
            //{
            //    Console.WriteLine("Does't work IsLetter() - numbers case");
            //}
            //if (VerifyInput("!labas") == "valid")
            //{
            //    Console.WriteLine("Does't work IsLetter() - symbols case");
            //}
            //if (VerifyInput("la bas") == "not valid")
            //{
            //    Console.WriteLine("Space in the middle is not solved");
            //}

            //Console.WriteLine("All tests passed");
        }

        //private static string VerifyInput(string word)
        //{
        //    if (string.IsNullOrEmpty(word) == true)
        //    {
        //        return "Input can't be null or empty";
        //    }

        //    var inputWord = word.Trim().ToLower();

        //    foreach (char letter in inputWord)
        //    {
        //        if (!Char.IsLetter(letter))
        //        {
        //            return "not valid";
        //        }
        //    }
        //    return "valid";
        //}

        //private static 



    }
}


