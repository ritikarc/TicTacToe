using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;
using TicTacToeMVVM.Resources;

namespace TicTacToeMVVM
{
    class Board : BindingBase
    {
        /// <summary>
        ///O's are 2, X's are 1, empty elements are 0;
        /// </summary>
        private int XOXO
        {
            get
            {
                if (Turn % 2 == 0)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// Odd number is X, Even number is O.
        /// </summary>
        public int Turn = 1;

        public Cell[] BoardArray
        {
            get;
            set;
        }

        public Board()
        {
            //I just initialize the board's array in here?
            this.BoardArray = new Cell[9];
            for (int i = 0; i < 9; i++)
            {
                this.BoardArray[i] = new Cell();
            }
        }

        public Cell this[int row, int col]
        {
            get { return this.BoardArray[row * 3 + col]; }
            set { this.BoardArray[row * 3 + col] = value; }
        }


        /// <summary>
        /// Processes the turn, calls WinCondition, returns 1 if there is a win, returns 0 if no win, returns -1 if draw
        /// </summary>
        /// <param name="row">The row of the board</param>
        /// <param name="col">The col of the board</param>
        /// <returns></returns>
        public int ProcessTurn(int row, int col)
        {
            CellValue turnValue = Turn % 2 == 0 ? CellValue.O : CellValue.X; //turnValue is either X or O enum
            this[row, col].Value = turnValue;

            if (WinCondition(this[row, col]) == 1)
            {
                return 1;
            }
            else
            {
                Turn++;
                if (Turn == 10)
                {
                    return -1;
                }
                return 0;
            }
        }

        /// <summary>
        /// Returns a value of 1 if there is a win of XorO, returns a value of 0 if there is no win.
        /// </summary>
        /// <param name="XorO"> 1 indicates an X, 2 indicates an O </param>
        /// <returns></returns>
        public int WinCondition(Cell XorO) //A value returned of 1 would entail a WIN, a value of 0 entails a CONTINUE.
        {
            if (this[0, 0] == XorO)
            {
                if (this[1, 1] == XorO && this[2, 2] == XorO) //Diagonal down
                {
                    return 1;
                }
                if (this[0, 1] == XorO && this[0, 2] == XorO) //Horizontal Row 1
                {
                    return 1;
                }
                if (this[1, 0] == XorO && this[2, 0] == XorO) //Vertical Row 1
                {
                    return 1;
                }
            }
            if (this[0, 1] == XorO && this[1, 1] == XorO && this[2, 1] == XorO) //Vertical Row 2
            {
                return 1;
            }
            if (this[0, 2] == XorO && this[1, 2] == XorO && this[2, 2] == XorO) // Vertical Row 3
            {
                return 1;
            }
            if (this[1, 0] == XorO && this[1, 1] == XorO && this[1, 2] == XorO) //Horizontal Row 2
            {
                return 1;
            }
            if (this[2, 0] == XorO)
            {
                if (this[2, 1] == XorO && this[2, 2] == XorO) //Horizontal Row 3
                {
                    return 1;
                }
                if (this[1, 1] == XorO && this[0, 2] == XorO) //Diagonal Up
                {
                    return 1;
                }
            }


            return 0;
        }


        public void Clear()
        {
            Array.Clear(this.BoardArray, 0, 9);
        }

    }
}
