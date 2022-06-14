using BuisnessLogic;
using System;
using System.Collections.Generic;
using Contracts;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnagramSolver
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.GetAnagramFromApi();

        }

        private async Task GetAnagramFromApi()
        {
            Console.WriteLine("Enter the word: ");
            var id = Console.ReadLine();
            string response = await client.GetStringAsync("id: " + $"https://localhost:7208/api/Values/GenerateAnagram/{id}");

            Console.WriteLine(response);
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