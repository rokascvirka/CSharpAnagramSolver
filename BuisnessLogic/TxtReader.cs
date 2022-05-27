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
        public List<string> TxtFileReader(string txtFilePath)
        {
            Console.WriteLine("LOADING...");


            List<string> txtFile = new List<string>();


            using (var streamReader = new StreamReader(txtFilePath))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    txtFile.Add(line);
                }
            }

            return txtFile;
        }
        public List<Word> FirstWordReader(List<string> txtFile)
        {

            var wordList = new HashSet<string>();
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
