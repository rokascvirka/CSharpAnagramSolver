using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ITxtReader
    {
        List<Word> TxtFileReader(string txtFilePath);
    }
}
