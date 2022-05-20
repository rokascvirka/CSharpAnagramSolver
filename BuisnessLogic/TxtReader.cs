using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using System.IO;

namespace BuisnessLogic
{
    public class TxtReader : ITxtReader
    {
        public List<string> TxtFileReader(string txtFilePath)
        {
           Console.WriteLine("LOADING...");


            List<string> txtFile = new List<string>();

            using ( var streamReader = new StreamReader(txtFilePath))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    txtFile.Add(line);
                }
            }

            var listDictionary = new List<string>();

            foreach (var line in txtFile)
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
