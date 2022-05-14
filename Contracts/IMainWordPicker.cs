using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IMainWordPicker
    {
        string RemoveSpaces(string mainWordForAnagram);
        object InputVerifyer(string inputWord);
    }
}
