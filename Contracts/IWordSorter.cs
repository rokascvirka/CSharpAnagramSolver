﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IWordSorter
    {
        string SortRandomWord(string mainWordForAnagram);
    }
}