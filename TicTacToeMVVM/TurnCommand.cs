namespace TicTacToeMVVM
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using TicTacToeMVVM.Resources;

    public class TurnCommand : ICommand
    {
        private Action<object> action;

        private Predicate<object> predicate;

        public TurnCommand(Action<object> act, Predicate<object> predicate)
        {
            this.action = act;
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.predicate(parameter);
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }

    /// <summary>
    /// An attempt to make the X and O on the board change colors.
    /// </summary>
    // public class XColorConverter : IValueConverter
    // {
    //    public Color NoTurnColor
    //    {
    //        get; set;
    //    }
    //    public Color TurnColor
    //    {
    //        get; set;
    //    }

    // public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
    // }
}