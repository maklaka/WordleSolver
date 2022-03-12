using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{

    internal class WordData
    {
        private Dictionary<char, int> LetterFrequencies;
        string wordText;
        int prevalance;
        List<char> RemainingLetters;
        HashSet<char> UniqueLetters;
        int uniqueCharsInAlphabet;
        int letterFreqScore;

        public WordData(string Word, int Pre, List<char> Alpha)
        {
            wordText = Word;
            prevalance = Pre;
            UniqueLetters = new HashSet<char>(Word);
            RemainingLetters = Alpha;

            LetterFrequencies = new Dictionary<char, int>()
            {
                { 'e', 1160 }, { 'A', 849 }, { 'r', 758 }, { 'i', 754 }, { 'o', 716 }, { 't', 695 },
                { 'n', 665 }, { 's', 573 }, { 'l', 549 }, { 'c', 454 }, { 'u', 363 }, { 'd', 384 },
                { 'p', 317 }, { 'm', 301 }, { 'h', 300 }, { 'g', 247 }, { 'b', 207 }, { 'f', 181 },
                { 'y', 177 }, { 'w', 129 }, { 'k', 110 }, { 'v', 100 }, { 'x', 29 }, { 'z', 27 },
                { 'j', 19 }, { 'q', 19 }
            };
        }

        public void CalculateScores()
        {
            int mult = 0;
            uniqueCharsInAlphabet = 0;
            letterFreqScore = 0;
            foreach (char SlimAlphaChar in RemainingLetters)
            {
                if (UniqueLetters.Contains(SlimAlphaChar))
                {
                    uniqueCharsInAlphabet++;
                    LetterFrequencies.TryGetValue(SlimAlphaChar, out mult);
                    letterFreqScore += mult;                    
                }
            }


        }
        public static int SortByKillableLetters(WordData a, WordData b)
        {
            if (a.uniqueCharsInAlphabet < b.uniqueCharsInAlphabet)
            {
                return 1;
            }
            else if (a.uniqueCharsInAlphabet > b.uniqueCharsInAlphabet)
            {
                return -1;
            }
            else
            {
                if (a.letterFreqScore < b.letterFreqScore)
                {
                    return 1;
                }
                else if(a.letterFreqScore > b.letterFreqScore)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }

        public static int SortByPrevalence(WordData a, WordData b)
        {
            if (a.prevalance < b.prevalance)
            {
                return 1;
            }
            else if (a.prevalance > b.prevalance)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public string WordText { get => wordText;}

    }
}
