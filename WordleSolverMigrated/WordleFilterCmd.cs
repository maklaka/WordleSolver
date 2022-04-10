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
    internal interface IExecutableCmd
    {
        bool RunCommand(string Word, char Letter, int Pos);
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
    internal class WordleFilterCmd
    {
        int Position;
        char Letter;
        IExecutableCmd Command;
        string cmdString;

        public WordleFilterCmd(string InputCommand)
        {
            cmdString = InputCommand;
            this.Letter = (char)(InputCommand[0]);

            if (InputCommand[1] == 'r')
            {
                this.Command = new WCmdRed();
            }
            else if (InputCommand[1] == 'y')
            {
                this.Command = new WCmdYellow();
                this.Position = int.Parse(InputCommand[2].ToString());
            }
            else
            {
                this.Command = new WCmdGreen();
                this.Position = int.Parse(InputCommand[2].ToString());
            }
        }

        public string CmdString { get => cmdString; }

        public bool RunFilterTest(string Word)
        {
            return this.Command.RunCommand(Word, this.Letter, this.Position);
        }
    }
}
