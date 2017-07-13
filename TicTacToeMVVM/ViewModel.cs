namespace TicTacToeMVVM
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using TicTacToeMVVM.Resources;

    /// <summary>
    /// The ViewModel (lol)
    /// </summary>
    internal class ViewModel : BindingBase
    {
        private bool isMessageVisible;
        private string winMessage;
        private bool isGameOver;
        private bool isXTurn;
        private bool isYTurn;

        public ViewModel()
        {
            this.isYTurn = false;
            this.isXTurn = true;
            this.Mainboard = new Board();
            this.Turn = new TurnCommand(this.Process, this.CanProcess);
            this.isMessageVisible = false;

        }

        public TurnCommand Turn { get; set; }

        public bool IsXTurn
        {
            get
            {
                return this.isXTurn;
            }

            set
            {
                this.SetProperty(ref this.isXTurn, value);
            }
        }

        public bool IsYTurn
        {
            get
            {
                return this.isYTurn;
            }

            set
            {
                this.SetProperty(ref this.isYTurn, value);
            }
        }

        public bool IsGameOver
        {
            get
            {
                return this.isGameOver;
            }

            set
            {
                this.SetProperty(ref this.isGameOver, value);
            }
        }


        public ObservableCollection<Cell> ViewBoard
        {
            get
            {
                return this.Mainboard.BoardArray;
            }
        }

        public bool IsMessageVisible
        {
            get
            {
                return this.isMessageVisible;
            }

            set
            {
                this.SetProperty(ref this.isMessageVisible, value);
            }
        }

        public string WinMessage
        {
            get
            {
                return this.winMessage;
            }

            set
            {
                this.SetProperty(ref this.winMessage, value);
            }
        }

        private Board Mainboard
        {
            get; set;
        }

        public void DrawCondition()
        {
            this.IsGameOver = true;
            this.ShowEndCondition("It's a draw!");
        }

        public void Win()
        {
            this.IsGameOver = true;

            if ((this.Mainboard.Turn % 2) == 1)
            {
                this.ShowEndCondition("X Wins!");
            }
            else
            {
                this.ShowEndCondition("O Wins!");
            }
        }

        public void ShowEndCondition(string message)
        {
            this.WinMessage = message;
            this.IsMessageVisible = true;
        }

        /// <summary>
        /// Basically the main method.
        /// </summary>
        /// <param name="obj">The parameter value (0 to 8)</param>
        private void Process(object obj)
        {
            Cell cell = obj as Cell;

            int index = this.ViewBoard.IndexOf(cell);
            int processturnvalue = this.Mainboard.ProcessTurn(index);

            if (processturnvalue == 1)
            {
                this.Win();
            }
            else if (processturnvalue == 0)
            {
                if (this.Mainboard.Turn % 2 == 1)
                {
                    this.IsXTurn = true;
                    this.IsYTurn = false;
                } else
                {
                    this.IsXTurn = false;
                    this.IsYTurn = true;
                }
            }
            else
            {
                this.DrawCondition(); 
            }
        }

        private bool CanProcess(object obj)
        { 
            Cell cell = obj as Cell;
            if (cell == null)
            {
                return false;
            }

            if (cell.Value == CellValue.X)
            {
                return false;
            }
            else if (cell.Value == CellValue.O)
            {
                return false;
            }
            else
            {
                return !this.IsGameOver;
            }
        }
    }
}