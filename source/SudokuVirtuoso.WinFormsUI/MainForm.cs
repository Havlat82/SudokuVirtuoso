using SudokuVirtuoso.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuVirtuoso.WinFormsUI
{
    public partial class MainForm : Form
    {
        ISudokuSolver _sudokuSolver;

        public MainForm()
        {
            InitializeComponent();
            InitPuzzle();
        }

        private void InitPuzzle()
        {
            var validValues = new ValidValues(1, 9);
            var rules = Rules.Create("Classic9x9Easy", validValues);
            _sudokuSolver = new BacktrackingSolver(rules);
        }
    }
}
