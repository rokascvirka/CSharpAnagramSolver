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
            IWordSorter wordSorter = new WordSorter();

            IDictGenerator dictionaryGenerator = new DictionaryGenerator();

            IAnagramGenerator anagramGenerator = new AnagramGenerator();

            ITxtReader TxtFilerReader = new TxtReader();

            Console.WriteLine("Enter the dictionary file path: ");
            var textFilePath = Console.ReadLine();

         // @"C:\Users\rokas.cvirka\Documents\zodynas1.txt"

         var words = TxtFilerReader.TxtFileReader(textFilePath);

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

            var inputWord = Console.ReadLine().ToLower().RemoveSpaces();

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


