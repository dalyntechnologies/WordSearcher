using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearcher
{
    public interface ISearcher
    {
        bool Exist(string searchWord);
        void PrintSearchedWord();

    }
}
