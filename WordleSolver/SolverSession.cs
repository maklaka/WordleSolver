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
    internal class SolverSession
    {
        HashSet<WordData> LoadedWords = new HashSet<WordData>();
        HashSet<WordData> RemainingTargetWords = new HashSet<WordData>();
        HashSet<WordleFilter> LoggedCommands = new HashSet<WordleFilter>();
        List<Label> UIAlphaStates = new List<Label>();
        List<char> WorkingAlphabet = new List<char>();
        List<string> SortedWordsByPopularity = new List<string>();
        List<string> SortedWordsByLetterFrequency = new List<string>();
        Dictionary<char, int[]> PositionQuotients = new Dictionary<char, int[]>();

        public SolverSession(List<Label> Alpha)
        {
            string line;
            string[] args;
            string[] EnglishDictionary = Properties.Resources.EnglishDictionary.Split('\n');
            WordData NewWord;
            UIAlphaStates = Alpha;

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

            foreach (Label lbl in Alpha)
            {
                PositionQuotients.Add(lbl.Text.ToLower()[0], new int[5]);
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
            foreach (WordData word in SortedWords)
                 SortedWordsByPopularity.Add(word.Text);

            return SortedWordsByPopularity;

        }
        public string GetBestGuessByDeductivity()
        {
            List<KeyValuePair<char, int>> ListofFreqs;
            List<char> LetterKeys = new List<char>();
            List<string> BestWords = new List<string>();
            Dictionary<char,int> LettCounts = new Dictionary<char, int>();            
            Facet.Combinatorics.Combinations<char> Combos;
            int[] CharPosScores;
            int SubSetSize = 5;
            int RunningPositionScore = 0;
            int BestPositionScore = 0;
            int PosIdx, PosCount = 5;
            char ExamineChar = '\0';
            string BestGuess = "";


            foreach(WordData Word in RemainingTargetWords)
            {
                //Get the raw letter counts across every word using only uniques
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

                //Tabulate letter frequency for each position of the remaining guess words
                for (PosIdx = 0; PosIdx < PosCount; PosIdx++)
                {
                    ExamineChar = Word.Text[PosIdx];
                    CharPosScores = PositionQuotients[ExamineChar];
                    CharPosScores[PosIdx]++;
                }
            }

            //Remove guess target letters that are in every remaining word.
            //we know those already and want the set of other letters that
            //covers the most words
            foreach(KeyValuePair<char,int> KeyVal in LettCounts)
            {
                if (KeyVal.Value == RemainingTargetWords.Count)
                {
                    LettCounts.Remove(KeyVal.Key);
                }
            }

            //Sort the frequency list from most common to least common letters
            //and copy it into a list of just the characters.
            ListofFreqs = LettCounts.ToList();
            ListofFreqs.Sort((x, y) => (y.Value.CompareTo(x.Value)));
            foreach( KeyValuePair<char,int> keyval in ListofFreqs)
            {
                LetterKeys.Add(keyval.Key);
            }

            //Starting with the biggest/best subset, loop through all subset combinations of the frequent letters
            //and catalog all of the words in the entire dictionary that contain each letter of the first
            //subset that successfully finds a word. (i.e. arise and raise contain the same subset of 5 letters) 
            while (SubSetSize > 0  && BestWords.Count == 0)
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
                            BestWords.Add(Word.Text);                            
                        }
                    }

                    if (BestWords.Count > 0)  break;
                }

                SubSetSize--;
            }

            //For each best word that satisfied the biggest/best set, find the single guess word
            //that also has those guess letters in their most frequent positions that will yield the most greens
            foreach (string BestWord in BestWords)
            {
                RunningPositionScore = 0;
                for (PosIdx = 0; PosIdx < PosCount; PosIdx++)
                {
                    ExamineChar = BestWord[PosIdx];
                    CharPosScores = PositionQuotients[ExamineChar];
                    RunningPositionScore += CharPosScores[PosIdx];
                }

                if(RunningPositionScore > BestPositionScore)
                {
                    BestPositionScore = RunningPositionScore;
                    BestGuess = BestWord;
                }
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
