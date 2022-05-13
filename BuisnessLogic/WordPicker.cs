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

            var mainWordForAnagram = Console.ReadLine().ToLower();
            var inputWord = RemoveSpaces(mainWordForAnagram);

            if (InputVerifyer(inputWord) == "valid") 
            {
                return inputWord;
            }
            else
            {
                var error = InputVerifyer(inputWord);
                Console.WriteLine(error);
                Console.WriteLine("Try again noob...");
                return MainWord();
            }
        }

        public string RemoveSpaces(string mainWordForAnagram)
        {
            var inputWord = mainWordForAnagram.ToCharArray();
            var correctInput = "";

            foreach (char letter in inputWord)
            {
                if (!Char.IsWhiteSpace(letter))
                {
                    correctInput += letter;
                }
            }
            return correctInput;
        }

        public string InputVerifyer(string mainWordForAnagram)
        {
            if (string.IsNullOrEmpty(mainWordForAnagram) == true)
            {
                return "String can't be null or empty";
            }

            foreach (char letter in mainWordForAnagram)
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
  