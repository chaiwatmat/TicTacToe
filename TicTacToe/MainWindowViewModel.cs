using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TicTacToe
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool player1 = true;
        private readonly Referee referee;

        public MainWindowViewModel()
        {
            OnTicTac = new ViewCommand(HandleTicTac, param => string.IsNullOrWhiteSpace(Winner));
            OnReset = new ViewCommand(HandleReset);

            referee = new Referee(this);
        }

        public ICommand OnTicTac { get; set; }
        public ICommand OnReset { get; set; }

        private void HandleTicTac(object param)
        {
            var index = int.Parse(param.ToString());
            var currentValue = Values[index];

            if (!string.IsNullOrWhiteSpace(currentValue))
            {
                return;
            }

            Values[index] = player1 ? "X" : "O";
            Winner = referee.GetWinner(Values);
            player1 = !player1;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Winner)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Values)));

            if (!string.IsNullOrEmpty(Winner))
            {
                MessageBox.Show(Winner, "GAME IS OVER");
            }
        }

        private void HandleReset()
        {
            player1 = true;
            Winner = null;
            Values = new string[9] { "", "", "", "", "", "", "", "", "" };


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Winner)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Values)));
        }

        public string Winner { get; set; }
        public string[] Values { get; set; } = new string[9] { "", "", "", "", "", "", "", "", "" };
    }
}
