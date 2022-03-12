
namespace WordleSolver
{
    public partial class Form1 : Form
    {
        HashSet<WordData> LoadedWords;
        HashSet<WordData> RemainingWords;
        HashSet<WordleCommand> LoggedCommands;
        List<Label> Alphabet;
        List<char> RemainingLetters;
        public Form1()
        {
            InitializeComponent();
        }

        void SortAndShowWords()
        {
            List<WordData> SortedByKill;
            List<WordData> SortedByPrevalence;
            int idx;

            if (radWordPrev.Checked == true)
            {
                lsbVocabWords.Items.Clear();

                SortedByPrevalence = RemainingWords.ToList();
                SortedByPrevalence.Sort(WordData.SortByPrevalence);

                foreach (WordData word in SortedByPrevalence)
                    lsbVocabWords.Items.Add(word.WordText);

                lsbLetterKillWords.Visible = false;
                lsbVocabWords.Visible = true;
                lblRemain.Text = RemainingWords.Count.ToString();
            }
            else //Arrange by number of letters killable
            {
                lsbLetterKillWords.Items.Clear();
                RemainingLetters.Clear();
                foreach (Label Lbl in Alphabet)
                {
                    if (Lbl.BackColor == Color.LightCyan)
                    {
                        RemainingLetters.Add((char)((int)Lbl.Text[0] + 32));
                    }
                }

                foreach (WordData Word in LoadedWords)
                {
                    Word.CalculateScores();
                }

                SortedByKill = LoadedWords.ToList();
                SortedByKill.Sort(WordData.SortByKillableLetters);
                
                for(idx = 0; idx < 150; idx++)
                {
                    lsbLetterKillWords.Items.Add(SortedByKill.ElementAt(idx).WordText);
                }

                lsbLetterKillWords.Visible = true;
                lsbVocabWords.Visible = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string line;
            string[] args;
            WordData NewWord;
            LoadedWords = new HashSet<WordData>();
            RemainingWords = new HashSet<WordData>();
            LoggedCommands = new HashSet<WordleCommand>();
            Alphabet = new List<Label>();
            RemainingLetters = new List<char>();

            foreach (Label label in this.Controls.OfType<Label>()
                    .Where(lbl => (lbl.Tag != null) && (lbl.Tag.ToString() == "Alpha")))
                Alphabet.Add(label);

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"DictPrev.csv");
            while ((line = file.ReadLine()) != null)
            {
                args = line.Split(',');
                if (args[0].Length == 5)
                {
                    NewWord = new WordData(args[0], Int32.Parse(args[1]), RemainingLetters);
                    LoadedWords.Add(NewWord);
                    lsbVocabWords.Items.Add(NewWord.WordText);
                }
            }

            foreach (WordData Word in LoadedWords)
                RemainingWords.Add(Word);

            SortAndShowWords();

            file.Close();
        }

        private void PerformAndLogCommand(string Command)
        {
            WordleCommand NewCmd = new WordleCommand(Command);
            foreach(WordData Word in RemainingWords)
            {
                if (!NewCmd.RunCommand(Word.WordText))
                {
                    RemainingWords.Remove(Word);
                }
            }
            LoggedCommands.Add(NewCmd);

            SortAndShowWords();
        }


        private void letterClickEvent(object sender, MouseEventArgs e)
        {
            Label Clicked_Letter = (Label)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Clicked_Letter.BackColor == Color.LightCyan ||
                    Clicked_Letter.BackColor == Color.Red ||
                    Clicked_Letter.BackColor == Color.Yellow)
                {
                    Clicked_Letter.BackColor = Color.Green;
                }
                else if (Clicked_Letter.BackColor == Color.Green)
                {
                    Clicked_Letter.BackColor = Color.Yellow;
                }
            }
            else
            {
                Clicked_Letter.BackColor = Color.Red;
                PerformAndLogCommand(Clicked_Letter.Text + 'R');
            }
        }

        private void ltr_MouseMove(object sender, MouseEventArgs e)
        {
            string cmd = "";
            Label Clicked_Letter = (Label)sender;

            if (Clicked_Letter.BackColor == Color.Green)
                cmd = "G";
            else if (Clicked_Letter.BackColor == Color.Yellow)
                cmd = "Y";

            if (e.Button == MouseButtons.Left)
            {
                Clicked_Letter.DoDragDrop(Clicked_Letter.Text + cmd, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
        private void lbl_DragDrop(object sender, DragEventArgs e)
        {
            Label TargetLabel = (Label)sender;
            string ComboData = e.Data.GetData(DataFormats.Text).ToString();
            char letter = ComboData[0];
            char cmd = 'n';

            if (ComboData.Length == 2)
            {
                cmd = ComboData[1];

                if (cmd == 'G')
                {
                    TargetLabel.BackColor = Color.Green;
                    TargetLabel.Text = letter.ToString();
                    PerformAndLogCommand(ComboData + TargetLabel.Name[3].ToString());
                }
                else if (cmd == 'Y')
                {
                    TargetLabel.BackColor = Color.Yellow;
                    TargetLabel.Text += letter.ToString();
                    PerformAndLogCommand(ComboData + TargetLabel.Name[3].ToString());
                }
            }
  
        }

        private void lbl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void radClicked(object sender, EventArgs e)
        {
            SortAndShowWords();
        }

    }
}