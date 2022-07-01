

using Contracts.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IWordRepository
    {
        HashSet<WordModel> GetWords();
    }
}
