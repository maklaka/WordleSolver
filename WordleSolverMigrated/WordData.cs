using global::System;
using global::System.Collections.Generic;
using global::System.Drawing;
using global::System.IO;
using global::System.Linq;
using global::System.Net.Http;
using global::System.Threading;
using global::System.Threading.Tasks;
using global::System.Windows.Forms;

namespace WordleSolver
{
    internal class WordData
    {
        private string text;
        private int prevalance;
        private HashSet<char> uniqueLetters;

        public WordData(string Word, int Pre)
        {
            text = Word;
            prevalance = Pre;
            uniqueLetters = new HashSet<char>(Word); //Get the set of unique letters, no repeats
        }

        public static int SortByPopularity(WordData a, WordData b)
        {
            if (a.Prevalance < b.Prevalance)
            {
                return 1;
            }
            else if (a.Prevalance > b.Prevalance)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public string Text { get => text;}
        public int Prevalance { get => prevalance;}
        public HashSet<char> UniqueLetters { get => uniqueLetters;}
    }
}
