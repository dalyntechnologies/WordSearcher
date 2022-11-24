using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WordSearcher
{
    internal class Program
    {


        static void Main(string[] args)
        {
            var wordText = string.Empty;
            var strContent=new List<string>();
            var testGrid = new List<List<char>>{
        new List<char>{'A', 'B', 'C', 'E','G'},
        new List<char>{'S', 'F', 'C', 'S','P'},
        new List<char>{'A', 'D', 'E', 'E','J' },
        new List<char>{'A', 'C', 'B', 'D','H'},
        new List<char>{'V', 'U', 'S', 'T','R'}
    };


            ISearcher searcher = new Searcher(testGrid);//for test
            var result1 = searcher.Exist("ABCCED"); // true  
            var result2 = searcher.Exist("SEE"); // true  
            var result3 = searcher.Exist("ABCB"); // false 

            char[,] array = new char[5, 5];
            List<char> Row = new List<char>();
            List<char> COL = new List<char>();

            var length = 6;

            for (int row = 1; row < length; row++)
            {
                for (int col = 1; col < length; col++)
                {
                    var letter = GetRandomLetter();

                    Row.Add(letter);
                    Console.Write(" " + letter);

                }

                Console.WriteLine();
            }
            COL.AddRange(Row);//Generate GRID
            var multi = COL.ToList();

            List<List<char>> myList = new List<List<char>>
            {
                COL
            };
            


            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "WordSearcher.words.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {

                while (!reader.EndOfStream)
                {
                    strContent.Add(reader.ReadLine());
                }

            }

            ISearcher searcher2 = new Searcher(myList);
            foreach (var word in strContent)
            {
                var  result=searcher2.Exist(word.ToUpper());
                if (result)
                {
                    Console.WriteLine($"Word FOUND: {word}");
                    
                }
            }
            Console.ReadLine();
            //todo Highlight the found text
        }


        private static char GetRandomLetter()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length);
            return chars[num];
        }
    }
}
