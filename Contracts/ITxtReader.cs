using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ITxtReader
    {
        List<string> TxtFileReader(List<string> TxtFile);
    }
}
