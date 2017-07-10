using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;
using TicTacToeMVVM.Resources;

namespace TicTacToeMVVM
{
    /// <summary>
    /// The ViewModel (lol)
    /// </summary>
    class ViewModel : BindingBase
    {

        public TurnCommand Turn { get; set; }


        public Cell[] ViewBoard
        {
            get
            {
                return this.Mainboard.BoardArray;
            }
        }

        private Board Mainboard
        {
            get; set;
        }
        //public int XOXO = Mainboard.XOXO();

        public ViewModel()
        {

            Mainboard = new Board();
            int TurnLim = this.Mainboard.Turn;
            this.Turn = new TurnCommand((i => this.Process(i)));


        }

        //Temporary
        private bool canProcess()
        {
            return true;
        }

        public void drawCondition()
        {
            disableAll();
            //disable all the boxes
            //show MessageBox saying the game is a draw
        }

        public void win()
        {
            //disableAll();
            //if (XOXO == 1)
            //{
            //    //show X Wins messagebox
            //    
            //} else
            //{
            //    //show O Wins messagebox
            //}
        }

        public void disableAll()
        {
            //disable all boxes
        }

        /// <summary>
        /// Basically the main method.
        /// </summary>
        /// <param name="i">The parameter value (0 to 8)</param>
        private void Process(int i)
        {
            int col = i % 3;
            int row = (i - col) / 3;

            if (Mainboard.ProcessTurn(row, col) == 1)
            {
                win();
            }
            else if (Mainboard.ProcessTurn(row, col) == 0)
            {
                //disable the button
            }
            else
            {
                drawCondition();
            }

        }

    }

    public class TurnCommand : ICommand
    {
        private Action<int> action;

        bool canExec;
        public TurnCommand(Action<int> act, bool exec)
        {
            action = act;
            canExec = exec;

        }

        public TurnCommand(Action<int> act)
        {
            action = act;
        }


        public event EventHandler CanExecuteChanged;
        //{
        //    add { this.CanExecuteChanged += value; }
        //    remove { this.CanExecuteChanged -= value; }
        //}

        public bool CanExecute(object param)
        {
            return param != null;
        }

        public void Execute(object parameter)
        {
            int.TryParse((string)parameter, out int i);

            action(i);

        }
    }

    /// <summary>
    /// An attempt to make the X and O on the board change colors.
    /// </summary>
    //public class XColorConverter : IValueConverter
    //{
    //    public Color NoTurnColor
    //    {
    //        get; set;
    //    }
    //    public Color TurnColor
    //    {
    //        get; set;
    //    }

    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if ((int)value % 2 == 1)
    //        {
    //            return TurnColor;
    //        }
    //        else
    //        {
    //            return NoTurnColor;
    //        }
    //    }
    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}