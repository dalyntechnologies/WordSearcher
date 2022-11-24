using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearcher
{
    public interface ISearcher
    {
        bool WordExist(string searchWord);
        void PrintSearchedWord();

    }
}
