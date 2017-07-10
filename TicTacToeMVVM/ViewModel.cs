using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;
using TicTacToeMVVM.Resources;
using System.Collections.ObjectModel;

namespace TicTacToeMVVM
{
    /// <summary>
    /// The ViewModel (lol)
    /// </summary>
    class ViewModel : BindingBase
    {

        public TurnCommand Turn { get; set; }

        public ObservableCollection<Cell> ViewBoard
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
            this.Turn = new TurnCommand(this.process);


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
        private void process(object obj)
        {

            //int col = i % 3;
            //int row = (i - col) / 3;

            Cell cell = obj as Cell;
            //cell.indexOf?

            int index = ViewBoard.IndexOf(cell);

            if (Mainboard.ProcessTurn(index) == 1)
            {
                win();
            }
            else if (Mainboard.ProcessTurn(index) == 0)
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
        private Action<object> action;

        bool canExec;
        public TurnCommand(Action<object> act, bool exec)
        {
            action = act;
            canExec = exec;

        }

        public TurnCommand(Action<object> act)
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
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);

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