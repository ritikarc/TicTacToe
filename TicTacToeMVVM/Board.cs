namespace TicTacToeMVVM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;
    using TicTacToeMVVM.Resources;

    internal class Board : BindingBase
    {
        /// <summary>
        /// Odd number is X, Even number is O.
        /// </summary>
        private int turn;

        private ObservableCollection<Cell> boardarray;

        public Board()
        {
            this.Turn = 1;
            this.boardarray = new ObservableCollection<Cell>();
            for (int i = 0; i < 9; i++)
            {
                this.boardarray.Add(new Cell());
            }
        }

        public int Turn
        {
            get
            {
                return this.turn;
            }

            set
            {
                this.SetProperty(ref this.turn, value);
            }
        }

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

        /// <summary>
        /// Gets o's are 2, X's are 1, empty elements are 0;
        /// </summary>
        private int XOXO
        {
            get
            {
                if (this.Turn % 2 == 0)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
        }

        public Cell this[int row, int col]
        {
            get { return this.BoardArray[(row * 3) + col]; }
            set { this.BoardArray[(row * 3) + col].Value = value.Value; }
        }

        /// <summary>
        /// Processes the turn, calls WinCondition method.
        /// </summary>
        /// <param name="index"> The location of the cell on the board. </param>
        /// <returns> Returns 1 if there is a win, 0 if no win, and -1 if there is a draw. </returns>
        public int ProcessTurn(int index)
        {
            CellValue turnValue = (this.Turn % 2 == 0) ? CellValue.O : CellValue.X; // turnValue is either X or O enum
            this.boardarray[index].Value = turnValue;

            if (this.WinCondition(this.boardarray[index]) == 1)
            {
                return 1;
            }
            else
            {
                this.Turn++;
                if (this.Turn == 10)
                {
                    return -1;
                }

                return 0;
            }
        }

        /// <summary>
        /// Returns whether or not the given side has won the game.
        /// </summary>
        /// <param name="xOrO"> 1 indicates an X, 2 indicates an O </param>
        /// <returns> Returns 1 if there is a win for XorO, returns 0 if there is no win for XorO. </returns>
        public int WinCondition(Cell xOrO) // A value returned of 1 would entail a WIN, a value of 0 entails a CONTINUE.
        {
            if (this[0, 0].Value == xOrO.Value)
            {
                // Diagonal down
                if (this[1, 1].Value == xOrO.Value && this[2, 2].Value == xOrO.Value) 
                {
                    return 1;
                }

                // Horizontal Row 1
                if (this[0, 1].Value == xOrO.Value && this[0, 2].Value == xOrO.Value) 
                {
                    return 1;
                }

                // Vertical Row 1
                if (this[1, 0].Value == xOrO.Value && this[2, 0].Value == xOrO.Value) 
                {
                    return 1;
                }
            }

            // Vertical Row 2
            if (this[0, 1].Value == xOrO.Value && this[1, 1].Value == xOrO.Value && this[2, 1].Value == xOrO.Value)
            {
                return 1;
            }

            // Vertical Row 3
            if (this[0, 2].Value == xOrO.Value && this[1, 2].Value == xOrO.Value && this[2, 2].Value == xOrO.Value)
            {
                return 1;
            }

            // Horizontal Row 2
            if (this[1, 0].Value == xOrO.Value && this[1, 1].Value == xOrO.Value && this[1, 2].Value == xOrO.Value)
            {
                return 1;
            }

            if (this[2, 0].Value == xOrO.Value)
            {
                // Horizontal Row 3
                if (this[2, 1].Value == xOrO.Value && this[2, 2].Value == xOrO.Value)
                {
                    return 1;
                }

                // Diagonal Up
                if (this[1, 1].Value == xOrO.Value && this[0, 2].Value == xOrO.Value)
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
