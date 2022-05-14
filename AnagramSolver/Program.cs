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
            IMainWordPicker mainWordPicker = new WordPicker();

            IWordSorter wordSorter = new WordSorter();

            IDictGenerator dictionaryGenerator = new DictionaryGenerator();

            IAnagramGenerator anagramGenerator = new AnagramGenerator();

            ITxtReader TxtFilerReader = new TxtReader();
            List<string> txtFile = System.IO.File.ReadLines(@"C:\Users\rokas.cvirka\Documents\zodynas1.txt").ToList();
            var words = TxtFilerReader.TxtFileReader(txtFile);

            var wordsInDictionary = dictionaryGenerator.DictGenerator(words);

            while (true)
            {

                var inputWord = MainWord();

                if (inputWord == "quit")
                {
                    break;
                }

                Console.WriteLine(anagramGenerator.AnagramGeneratorMethod(inputWord, wordSorter, wordsInDictionary));
            }
        }
        public static string MainWord()
        {
            IMainWordPicker mainWordPicker = new WordPicker();

            Console.WriteLine("Enter a word and get anagram, if you want to quit write 'quit': ");

            var mainWordForAnagram = Console.ReadLine().ToLower();
            var inputWord = mainWordPicker.RemoveSpaces(mainWordForAnagram);

            if (mainWordPicker.InputVerifyer(inputWord) == "valid")
            {
                return inputWord;
            }
        
            else
            {
                var error = mainWordPicker.InputVerifyer(inputWord);
                Console.WriteLine(error);
                Console.WriteLine("Try again noob...");
            }
            return MainWord();
        }
    }
}


