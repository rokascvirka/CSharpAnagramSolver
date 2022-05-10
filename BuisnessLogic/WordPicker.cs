using Contracts;
using System;
using System.Collections.Generic;

namespace BuisnessLogic
{
    public class WordPicker : IMainWordPicker
    {
        public string MainWord()
        {
            Console.WriteLine("Enter a word and get anagram: ");

            var mainWordForAnagram = Console.ReadLine().Trim().ToLower();
            if (InputVerifyer(mainWordForAnagram) == "valid") 
            {
                return mainWordForAnagram;
            }
            else
            {
                var error = InputVerifyer(mainWordForAnagram);
                Console.WriteLine(error);
                Console.WriteLine("Try again noob...");
                MainWord();
            }

            return mainWordForAnagram;
        }

        public string InputVerifyer(string mainWordForAnagram)
        {
            if (string.IsNullOrEmpty(mainWordForAnagram) == true)
            {
                return "String can't be null or empty";
            } 
            var inputWord = mainWordForAnagram.Trim().ToLower();
            // Naujas metodas remove spaces
            foreach (char letter in inputWord)
            {
                if (!Char.IsLetter(letter))
                {
                    return "Every charracter supposed to be from a to z. You can't use any symbols or numbers.";
                }
            }
            return "valid";
        }
    }
}
