using System.Windows;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
