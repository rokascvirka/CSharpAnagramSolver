using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using System.IO;
using Entity;

namespace BuisnessLogic
{
    public class TxtReader : ITxtReader
    {
        public List<Word> TxtFileReader(string txtFilePath)
        {
           Console.WriteLine("LOADING...");


            List<string> txtFile = new List<string>();
            var wordList = new HashSet<string>();

            using ( var streamReader = new StreamReader(txtFilePath))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    txtFile.Add(line);
                }
            }

            var listDictionary = new List<Word>();

            foreach (var line in txtFile)
            {
                var sentence = line.Replace(" ", "").Split();

                var info = sentence[0];
                for (int i = 0; i < 2; i++)
                {


                    if (!wordList.Contains(info.ToLower()))
                    {
                        var entity = new Word
                        {
                            word = info.ToLower()
                        };
                        listDictionary.Add(entity);
                        wordList.Add(info.ToLower());
                    }
                }
            }
            return listDictionary;
        }
    }
}
