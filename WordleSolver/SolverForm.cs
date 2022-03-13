
namespace WordleSolver
{
    public partial class SolverForm : Form
    {
        List<Label> UIAlphabetStates = new List<Label>();
        List<Label> UITargetLetterStates = new List<Label>();
        SolverSession Session;
        public SolverForm()
        {
            InitializeComponent();
        }

        void SortAndShowWords()
        {
            List<string> SortedWords;
            
            if (radWordPopularity.Checked == true)
            {
                SortedWords = Session.GetSortedTargetsByPopularity();

                lsbTargetPopularity.Items.Clear();
                foreach (string Word in SortedWords)
                {
                    lsbTargetPopularity.Items.Add(Word);
                }

                lsbTargetPopularity.Visible = true;
                lsbLetterFrequency.Visible = false;
                lsbDeductivity.Visible = false;
                lblRemain.Text = SortedWords.Count.ToString();
            }
            else if (radDeductivity.Checked == true) 
            {
                lsbLetterFrequency.Visible = false;
                lsbDeductivity.Visible = true;
                lsbTargetPopularity.Visible = false;
                
            }
            else if (radLetterFrequency.Checked == true)
            {
                lsbLetterFrequency.Items.Clear();
                SortedWords = Session.GetSortedBestGuessesByLetterFrequency();
                foreach (string Word in SortedWords)
                {
                    lsbLetterFrequency.Items.Add(Word);
                }

                lsbTargetPopularity.Visible = false;
                lsbDeductivity.Visible = false;
                lsbLetterFrequency.Visible = true;
            }
        }

       // public LoadLetterStatuses(List<char> Alphabet, List<char>)
        private void Form1_Load(object sender, EventArgs e)
        {
            
            foreach (Label label in this.Controls.OfType<Label>()
                .Where(lbl => (lbl.Tag != null) && (lbl.Tag.ToString() == "Alpha")))
                UIAlphabetStates.Add(label);

            foreach (Label label in this.Controls.OfType<Label>()
                .Where(lbl => (lbl.Tag != null) && (lbl.Tag.ToString() == "TargetLetter")))
                UITargetLetterStates.Add(label);

            
            Session = new SolverSession(UIAlphabetStates, UITargetLetterStates);

            SortAndShowWords(); 
        }


        private void letterClickEvent(object sender, MouseEventArgs e)
        {
            Label Clicked_Letter = (Label)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Clicked_Letter.BackColor == Color.LightCyan ||
                    Clicked_Letter.BackColor == Color.Yellow)
                {
                    Clicked_Letter.BackColor = Color.Green;
                }
                else if (Clicked_Letter.BackColor == Color.Green)
                {
                    Clicked_Letter.BackColor = Color.Yellow;
                }
                else if (Clicked_Letter.BackColor == Color.Red)
                {
                    //TODO a red is being cancelled! clear shit as necessary
                    Clicked_Letter.BackColor = Color.Green;
                }
            }
            else //right mouse click. red letter requested
            {
                Clicked_Letter.BackColor = Color.Red;
                Session.PerformAndLogCommand(Clicked_Letter.Text.ToLower() + "r");
                SortAndShowWords();
                lblRemain.Text = Session.GetBestGuessByDeductivity();
            }
        }

        private void ltr_MouseMove(object sender, MouseEventArgs e)
        {
            string cmd = "";
            Label Grabbed_Letter = (Label)sender;

            if (Grabbed_Letter.BackColor == Color.Green)
                cmd = "g";
            else if (Grabbed_Letter.BackColor == Color.Yellow)
                cmd = "y";

            //the letter has been grabbed by the left mouse button
            if (e.Button == MouseButtons.Left)
            {
                Grabbed_Letter.DoDragDrop(Grabbed_Letter.Text.ToLower() + cmd, DragDropEffects.Copy | DragDropEffects.Move);
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

                if (cmd == 'g')
                {
                    TargetLabel.BackColor = Color.Green;
                    TargetLabel.Text = letter.ToString();
                    Session.PerformAndLogCommand(ComboData + TargetLabel.Name[3].ToString());
                }
                else if (cmd == 'y')
                {
                    TargetLabel.BackColor = Color.Yellow;
                    TargetLabel.Text += letter.ToString();
                    Session.PerformAndLogCommand(ComboData + TargetLabel.Name[3].ToString());
                }

                SortAndShowWords();
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

        private void Help_MouseClick(object sender, MouseEventArgs e)
        {

        }

    }
}