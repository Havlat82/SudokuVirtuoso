using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVirtuoso.Sandbox.ConsoleUI
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var pa = Position.GetPositionsInSubGrid(0); 

            for (int i = 0; i < pa.Count; i++)
                System.Console.WriteLine(pa[i].ToString());
            System.Console.ReadLine();
        }
    }


    

}
