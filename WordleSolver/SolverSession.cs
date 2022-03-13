using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{
    internal class SolverSession
    {
        HashSet<WordData> LoadedWords = new HashSet<WordData>();
        HashSet<WordData> RemainingTargetWords = new HashSet<WordData>();
        HashSet<WordleFilter> LoggedCommands = new HashSet<WordleFilter>();
        List<Label> UIAlphaStates = new List<Label>();
        List<Label> UITargetStates = new List<Label>();
        List<char> WorkingAlphabet = new List<char>();
        List<string> SortedWordsByPopularity = new List<string>();
        List<string> SortedWordsByLetterFrequency = new List<string>();

        public SolverSession(List<Label> Alpha, List<Label> Target)
        {
            string line;
            string[] args;
            string[] EnglishDictionary = Properties.Resources.EnglishDictionary.Split('\n');
            WordData NewWord;

            UIAlphaStates = Alpha;
            UITargetStates = Target;

            // Read the dictionary with popularity quotient line by line.  
            foreach (string DictEntry in EnglishDictionary)
            {
                args = DictEntry.Split(',');
                if (args[0].Length == 5)
                {
                    NewWord = new WordData(args[0], Int32.Parse(args[1]), WorkingAlphabet);
                    LoadedWords.Add(NewWord);
                    RemainingTargetWords.Add(NewWord);
                }
            } 
        }

        public void PerformAndLogCommand(string Command)
        {
            WordleFilter NewCmd = new WordleFilter(Command);
            foreach (WordData Word in RemainingTargetWords)
            {
                if (!NewCmd.RunFilterTest(Word.Text))
                {
                    RemainingTargetWords.Remove(Word);
                }
            }
            LoggedCommands.Add(NewCmd);

        }

        public List<string> GetSortedTargetsByPopularity()
        {
            List<WordData> SortedWords;
            
            SortedWords = RemainingTargetWords.ToList();
            SortedWords.Sort(WordData.SortByPopularity);

            SortedWordsByPopularity.Clear();
            foreach (WordData word in RemainingTargetWords)
                SortedWordsByPopularity.Add(word.Text);

            return SortedWordsByPopularity;

        }
        public string GetBestGuessByDeductivity()
        {
            List<KeyValuePair<char, int>> ListofFreqs;
            List<char> LetterKeys = new List<char>();
            Dictionary<char,int> LettCounts = new Dictionary<char, int>();
            Facet.Combinatorics.Combinations<char> Combos;
            int SubSetSize = 5;
            string BestGuess = "";
            foreach(WordData Word in RemainingTargetWords)
            {
                foreach(char letter in Word.UniqueLetters)
                {
                    if(LettCounts.ContainsKey(letter))
                    {
                        LettCounts[letter]++;
                    }
                    else
                    {
                        LettCounts.Add(letter,1);
                    }                    
                }
            }

            //remove letters common to all remaining words
            foreach(KeyValuePair<char,int> KeyVal in LettCounts)
            {
                if (KeyVal.Value == RemainingTargetWords.Count)
                {
                    LettCounts.Remove(KeyVal.Key);
                }
            }

            ListofFreqs = LettCounts.ToList();
            ListofFreqs.Sort((x, y) => (y.Value.CompareTo(x.Value)));
            foreach( KeyValuePair<char,int> keyval in ListofFreqs)
            {
                LetterKeys.Add(keyval.Key);
            }

            while (SubSetSize > 0  && BestGuess.Length == 0)
            {
                Combos = new Facet.Combinatorics.Combinations<char>(LetterKeys, SubSetSize);

                
                foreach (List<char> Set in Combos)
                {
                    foreach (WordData Word in LoadedWords)
                    {
                        bool AllFound = true;
                        foreach (char c in Set)
                        {
                            if(!Word.Text.Contains(c))
                            {
                                AllFound = false;
                                break;
                            }
                        }

                        if(AllFound)
                        {
                            BestGuess = Word.Text;
                            break;
                        }
                    }

                    if (BestGuess.Length > 0)  break;
                }

                SubSetSize--;
            }
            

            return BestGuess;
        }

        public List<string> GetSortedBestGuessesByLetterFrequency()
        {
            List<WordData> SortedWords;

            WorkingAlphabet.Clear();
            foreach (Label Lbl in UIAlphaStates)
            {
                if (Lbl.BackColor == Color.LightCyan)
                {
                    WorkingAlphabet.Add((Lbl.Text.ToLower()[0]));
                }
            }

            foreach (WordData Word in LoadedWords)
            {
                Word.CalculateScores();
            }

            SortedWords = LoadedWords.ToList();
            SortedWords.Sort(WordData.SortByLetterFrequency);
            SortedWords.RemoveRange(150, LoadedWords.Count - 150);

            SortedWordsByLetterFrequency.Clear();
            foreach (WordData Word in SortedWords)
            {
                SortedWordsByLetterFrequency.Add(Word.Text);
            }

            return SortedWordsByLetterFrequency;
        }
    }
}
