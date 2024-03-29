﻿using System;
using System.Collections.Generic;
using Contracts;

namespace BuisnessLogic
{
    public class DictionaryGenerator : IDictGenerator
    {
        public Dictionary<string, List<string>> DictGenerator(List<Word> firstItemWordsList)
        {
            var dictionary = new Dictionary<string, List<string>>();

            foreach (var word in firstItemWordsList)
            {
                var sortedArray = word.word.ToCharArray();
                Array.Sort(sortedArray);
                var sortedWord = string.Join("", sortedArray);

                if (dictionary.ContainsKey(sortedWord))
                {
                    dictionary[sortedWord].Add(word.word);
                }
                else
                {
                    dictionary.Add(sortedWord, new List<string>());
                    dictionary[sortedWord].Add(word.word);
                }
            }
            return dictionary;
        }
    }
}