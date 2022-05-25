using BuisnessLogic;
using System;
using System.Collections.Generic;
using Contracts;
using System.Linq;
using System.IO;

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

            var textFileNameInput = ChooseWordsDictionaryFile();

            if (textFileNameInput == "quit")
            {
                Environment.Exit(0);
            }

            var words = TxtFilerReader.TxtFileReader(textFileNameInput);

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
            IInputControler mainWordPicker = new InputControler();

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

        public static string ChooseWordsDictionaryFile()
        {
            while (true)
            {
                Console.WriteLine("Enter the dictionary file name: ");
                var textFileNameInput = Console.ReadLine().RemoveSpaces();
                var textFilePath = ("C:\\Users\\rokas.cvirka\\Documents\\" + textFileNameInput + ".txt");

                if (File.Exists(textFilePath))
                {
                    return textFilePath;
                }
                if (textFileNameInput == "quit")
                {
                    return textFileNameInput;
                }

                Console.WriteLine("There is no file named: '{0}'. Try again or write 'quit' to exit...", textFileNameInput);
            }
        }
    }
}


