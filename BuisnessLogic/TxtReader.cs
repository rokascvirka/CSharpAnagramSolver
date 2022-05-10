using System;
using System.Collections.Generic;
using Contracts;

namespace BuisnessLogic
{
    public class TxtReader : ITxtReader
    {
        public List<string> TxtFileReader(List<string> TxtFile)
        {
            var listDictionary = new List<string>();

            foreach (var line in TxtFile)
            {
                var sentence = line.Replace(" ", "").Split();

                var info = sentence[0];
                for (int i = 0; i < 2; i++)
                {
                    if (!listDictionary.Contains(info.ToString().ToLower()))
                    {
                        listDictionary.Add(info.ToString().ToLower());
                    }
                }
            }

            return listDictionary;
        }
    }
}
