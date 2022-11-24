using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearcher
{
    public class Searcher : ISearcher
    {
        private readonly List<List<char>> _characterBoard;
        public Searcher(List<List<char>> characterBoard)
        {
            _characterBoard = characterBoard;
        }
        public bool Exist(string searchWord)
        {
            if (searchWord == "")
                return false;

            
            for (int i = 0; i < _characterBoard.Count; i++)
            {
                for (int j = 0; j < _characterBoard[i].Count; j++)
                {
                    
                    if (DoesCharacterExist(i, j, 0, searchWord))
                        return true;
                }
            }
            return false;
        }

        private bool DoesCharacterExist(int i, int j, int searchIndex, string searchWord)
        {
            
            if (i < 0 || i >= _characterBoard.Count || j < 0 || j >= _characterBoard[i].Count)
                return false;

            
            if (_characterBoard[i][j] != searchWord[searchIndex])
                return false;

           
            if (searchIndex == searchWord.Length - 1)
                return true;

            
            _characterBoard[i][j] = '#';

            
            bool found = DoesCharacterExist(i, j - 1, searchIndex + 1, searchWord) ||
                DoesCharacterExist(i, j + 1, searchIndex + 1, searchWord) ||
                DoesCharacterExist(i - 1, j, searchIndex + 1, searchWord) ||
                DoesCharacterExist(i + 1, j, searchIndex + 1, searchWord);

            // unmark the current character  
            _characterBoard[i][j] = searchWord[searchIndex];
            return found;
        }

        public void PrintSearchedWord()
        {
            throw new NotImplementedException();
        }
    }
}
