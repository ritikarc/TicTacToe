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
using System.Collections.ObjectModel;

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

        private ObservableCollection<Cell> boardarray;
        public ObservableCollection<Cell> BoardArray
        {
            get
            {
                return this.boardarray;
            }
            set
            {
                this.SetProperty(ref this.boardarray, value);
            }
        }


        public Board()
        {
            this.boardarray = new ObservableCollection<Cell>();
            for (int i = 0; i < 9; i++)
            {
                this.boardarray.Add(new Cell());
            }
        }

        public Cell this[int row, int col]
        {
            get { return this.BoardArray[row * 3 + col]; }
            set { this.BoardArray[row * 3 + col].Value = value.Value; }
        }


        /// <summary>
        /// Processes the turn, calls WinCondition, returns 1 if there is a win, returns 0 if no win, returns -1 if draw
        /// </summary>
        /// <param name="row">The row of the board</param>
        /// <param name="col">The col of the board</param>
        /// <returns></returns>
        public int ProcessTurn(int index)
        {
            CellValue turnValue = Turn % 2 == 0 ? CellValue.O : CellValue.X; //turnValue is either X or O enum
            this.boardarray[index].Value = turnValue;

            if (WinCondition(this.boardarray[index]) == 1)
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
            if (this[0, 0].Value == XorO.Value)
            {
                if (this[1, 1].Value == XorO.Value && this[2, 2].Value == XorO.Value) //Diagonal down
                {
                    return 1;
                }
                if (this[0, 1].Value == XorO.Value && this[0, 2].Value == XorO.Value) //Horizontal Row 1
                {
                    return 1;
                }
                if (this[1, 0].Value == XorO.Value && this[2, 0].Value == XorO.Value) //Vertical Row 1
                {
                    return 1;
                }
            }
            if (this[0, 1].Value == XorO.Value && this[1, 1].Value == XorO.Value && this[2, 1].Value == XorO.Value) //Vertical Row 2
            {
                return 1;
            }
            if (this[0, 2].Value == XorO.Value && this[1, 2].Value == XorO.Value && this[2, 2].Value == XorO.Value) // Vertical Row 3
            {
                return 1;
            }
            if (this[1, 0].Value == XorO.Value && this[1, 1].Value == XorO.Value && this[1, 2].Value == XorO.Value) //Horizontal Row 2
            {
                return 1;
            }
            if (this[2, 0].Value == XorO.Value)
            {
                if (this[2, 1].Value == XorO.Value && this[2, 2].Value == XorO.Value) //Horizontal Row 3
                {
                    return 1;
                }
                if (this[1, 1].Value == XorO.Value && this[0, 2].Value == XorO.Value) //Diagonal Up
                {
                    return 1;
                }
            }


            return 0;
        }


        public void Clear()
        {
            this.BoardArray.Clear();
        }

    }
}
