using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IDictGenerator
    {
        Dictionary<string, List<string>> DictGenerator(List<Word> words);
    }
}