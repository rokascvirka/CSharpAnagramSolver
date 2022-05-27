using System;
using System.Collections.Generic;
using Contracts;
using System.Linq;


namespace BuisnessLogic
{
    public class AnagramGenerator : IAnagramGenerator
    {
        public AnagramGenerator()
        {

        }

        public string AnagramGeneratorMethod(string inputWord, IWordSorter wordSorter, Dictionary<string, List<string>> wordsInDictionary)
        {
            // From list to dictionary 
            var anagramWord = inputWord;

            var sortedMainWordForAnagram = wordSorter.SortRandomWord(anagramWord);
            if (!wordsInDictionary.ContainsKey(sortedMainWordForAnagram))
            {
                var result = String.Format("There is no word like this in dict and it doesn't have any anagrams");
                return result;
            }
            else
            {

                var randomValueInList = GetRandomAnagram(sortedMainWordForAnagram, wordsInDictionary);
                var validation = ValidateAnagram(randomValueInList, anagramWord, sortedMainWordForAnagram, wordsInDictionary);
                if (validation == 2)
                {
                    while (anagramWord == randomValueInList)
                    {
                        var newRandom = GetRandomAnagram(sortedMainWordForAnagram, wordsInDictionary);
                        if (anagramWord != newRandom)
                        {
                            randomValueInList = newRandom;
                            var result = String.Format("This word: {0} anagram: {1} (After a while loop)", anagramWord, randomValueInList);
                            return result;
                        }
                    }
                }
                else
                {
                    var result = String.Format(ShowAnagram(validation, anagramWord, randomValueInList));
                    return result;
                }
                return String.Format("Something");
            }
        }

        private string GetRandomAnagram(string sortedMainWordForAnagram, Dictionary<string, List<string>> wordsInDictionary)
        {

            var random = new Random();
            var valueListLength = wordsInDictionary[sortedMainWordForAnagram].Count;
            var randomValueInList = wordsInDictionary[sortedMainWordForAnagram][random.Next(0, valueListLength)];

            return randomValueInList;
        }

        public int ValidateAnagram(string randomValueInList, string anagramWord, string sortedMainWordForAnagram, Dictionary<string, List<string>> wordsInDictionary)
        {

            if (wordsInDictionary[sortedMainWordForAnagram].Count == 1)
            {
                if (anagramWord != randomValueInList)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (anagramWord != randomValueInList)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public string ShowAnagram(int answer, string anagramWord, string randomValueInList)
        {
            if (answer == 1)
            {
                String message = String.Format("This word: {0} anagram: {1}", anagramWord, randomValueInList);
                return message;
            }
            else
            {
                String negativeMessage = String.Format("This word: {0} doesn't have anagram in our dictionary", anagramWord);
                return negativeMessage;
            }
        }
    }
}