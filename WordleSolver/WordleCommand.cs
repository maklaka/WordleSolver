using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver
{
    internal interface IExecutableCmd
    {
        bool RunCommand(string Word,char Letter,int Pos);
    }

    internal class WCmdRed : IExecutableCmd
    {
        public bool RunCommand(string Word, char Letter, int Pos)
        {
            bool ret = true;

            if (Word.Contains(Letter))  
                ret = false;

            return ret;
        }
    }

    internal class WCmdGreen : IExecutableCmd
    {
        public bool RunCommand(string Word, char Letter, int Pos)
        {
            bool ret = true;

            if (Word[Pos] != Letter)
                ret = false;

            return ret;
        }
    }

    internal class WCmdYellow : IExecutableCmd
    {
        public bool RunCommand(string Word, char Letter, int Pos)
        {
            bool ret = true;

            if (!Word.Contains(Letter) || Word[Pos] == Letter)
                ret = false;

            return ret;
        }
    }
    internal class WordleCommand
    {
        int Position;
        char Letter;
        IExecutableCmd Command;

        public WordleCommand(string InputCommand)
        {
            this.Letter = (char)(InputCommand[0] + 32);

            if (InputCommand[1] == 'R')
                this.Command = new WCmdRed();
            else if (InputCommand[1] == 'Y')
            {
                this.Command = new WCmdYellow();
                this.Position = InputCommand[2] - 48;
            }
            else 
            {
                this.Command = new WCmdGreen();
                this.Position = InputCommand[2] - 48;
            }
        }

        public bool RunCommand(string Word)
        {
            return this.Command.RunCommand(Word, this.Letter, this.Position);
        }

    
    }
}
