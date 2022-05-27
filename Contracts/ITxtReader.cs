using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ITxtReader
    {
        List<string> TxtFileReader(string txtFilePath);
        List<Word> FirstWordReader(List<string> txtFile);
    }
}