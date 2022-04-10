using global::System;
using global::System.Collections.Generic;
using global::System.Drawing;
using global::System.IO;
using global::System.Linq;
using global::System.Net.Http;
using global::System.Threading;
using global::System.Threading.Tasks;
using global::System.Windows.Forms;
using Props = WordleSolverMigrated.Properties;

namespace WordleSolver
{
    internal class SolverSession
    {
        public static HashSet<WordData> LoadedWords = new HashSet<WordData>();
        public static HashSet<WordData> TargetWords = new HashSet<WordData>();

        static Dictionary<char, int[]> PositionQuotients = new Dictionary<char, int[]>();
        public List<WordData> RemainingTargetWords = new List<WordData>();
        HashSet<WordleFilter> LoggedCommands = new HashSet<WordleFilter>();
        List<string> SortedWordsByPopularity = new List<string>();

        public SolverSession()
        {
            foreach (WordData Word in TargetWords)
                RemainingTargetWords.Add(Word);
        }
        public SolverSession(List<Label> Alpha)
        {
            string[] args;
            string[] EnglishDictionary = Props.Resources.EnglishDictionary.Split('\n');
            WordData NewWord;

            // Read the dictionary with popularity quotient line by line.  
            foreach (string DictEntry in EnglishDictionary)
            {
                args = DictEntry.Split(',');
                if (args[0].Length == 5)
                {
                    NewWord = new WordData(args[0], Int32.Parse(args[1]));
                    LoadedWords.Add(NewWord);                    
                }
            }

            foreach (Label lbl in Alpha)
            {
                PositionQuotients.Add(lbl.Text.ToLower()[0], new int[5]);
            }

            List<WordData> Sorted = LoadedWords.ToList();
            Sorted.Sort((x, y) => y.Prevalance.CompareTo(x.Prevalance));
            Sorted.RemoveRange(2500, Sorted.Count - 2500);
            foreach (WordData Word in Sorted)
            {
                TargetWords.Add(Word);
                RemainingTargetWords.Add(Word);
            }   
        }

        public void PerformAndLogCommand(string Command)
        {
            WordleFilter NewCmd = new WordleFilter(Command);
            RemainingTargetWords.RemoveAll(Word => (!NewCmd.RunFilterTest(Word.Text)));
            LoggedCommands.Add(NewCmd);
        }

        public List<string> GetSortedTargetsByPopularity()
        {
            RemainingTargetWords.Sort(WordData.SortByPopularity);

            SortedWordsByPopularity.Clear();
            foreach (WordData word in RemainingTargetWords)
                 SortedWordsByPopularity.Add(word.Text);

            return SortedWordsByPopularity;
        }

        public string GetBestGuessByDeductivity()
        {
            List<KeyValuePair<char, int>> ListofFreqs;
            List<string> CheckWords = new List<string>(); 
            List<char> LetterKeys = new List<char>();
            List<string> BestWords = new List<string>();
            Dictionary<char,int> LettCounts = new Dictionary<char, int>();            
            Facet.Combinatorics.Combinations<char> Combos;
            int[] CharPosScores;
            int SubSetSize = 5;
            int RunningPositionScore = 0;
            int BestPositionScore = 0;
            int PosIdx, PosCount = 5;
            string BestGuess = "";

            //If all the few remaining words are permutations of the same letters
            //or there is just a single word left -- return the first word as a guess
            if (RemainingTargetWords.Count <= 5)
            {
                foreach (WordData Word in RemainingTargetWords)
                {
                    char[] chars = Word.Text.ToCharArray();
                    Array.Sort(chars);
                    CheckWords.Add(new string(chars));
                }

                if (RemainingTargetWords.Count == 1 ||
                    (CheckWords.Count > 1 && !CheckWords.Any(o => o != CheckWords[0])))
                {
                    RemainingTargetWords.Sort(WordData.SortByPopularity);
                    return RemainingTargetWords.ToArray()[0].Text;
                }
            }

            /*Loop through every remaining guess word */
            foreach (WordData Word in RemainingTargetWords)
            {
                //Get the raw letter counts across every word using only uniques
                foreach (char letter in Word.UniqueLetters)
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
                    CharPosScores = PositionQuotients[Word.Text[PosIdx]];
                    CharPosScores[PosIdx]++;
                }

            }

            //Remove guess target letters that are in every remaining word.
            //we know those already and want the set of other letters that
            //covers the most words
            var toRemove = LettCounts.Where(kvp => kvp.Value == RemainingTargetWords.Count).ToList();
            foreach (var KeyVal in toRemove)
            {
                LettCounts.Remove(KeyVal.Key);
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
                    CharPosScores = PositionQuotients[BestWord[PosIdx]];
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
    }
}
