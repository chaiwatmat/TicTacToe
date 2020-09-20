using System.Linq;

namespace TicTacToe
{
    public class Referee
    {
        private readonly MainWindowViewModel viewModel;

        public Referee(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private static bool IsFill(string o1, string o2, string o3)
        {
            return !string.IsNullOrWhiteSpace(o1) && o1 == o2 && o1 == o3;
        }

        public string GetWinner(string[] values)
        {
            var row1 = IsFill(values[0], values[1], values[2]);
            var row2 = IsFill(values[3], values[4], values[5]);
            var row3 = IsFill(values[6], values[7], values[8]);
            var col1 = IsFill(values[0], values[3], values[6]);
            var col2 = IsFill(values[1], values[4], values[7]);
            var col3 = IsFill(values[2], values[5], values[8]);
            var cross1 = IsFill(values[0], values[4], values[8]);
            var cross2 = IsFill(values[2], values[4], values[6]);

            var finished = values.All(x => !string.IsNullOrEmpty(x));

            if (row1)
            {
                return $"Winner = {values[0]}";
            }
            else if (row2)
            {
                return $"Winner = {values[3]}";
            }
            else if (row3)
            {
                return $"Winner = {values[6]}";
            }
            else if (col1)
            {
                return $"Winner = {values[0]}";
            }
            else if (col2)
            {
                return $"Winner = {values[1]}";
            }
            else if (col3)
            {
                return $"Winner = {values[2]}";
            }
            else if (cross1)
            {
                return $"Winner = {values[0]}";
            }
            else if (cross2)
            {
                return $"Winner = {values[2]}";
            }
            else if (finished)
            {
                return "Result is draw";
            }

            return null;
        }

    }
}
