namespace TicTakToe.Kata
{
    internal struct HistoryPlay
    {
        RowColumn RowColumn;
        TicTakChar TicTakChar;

        public HistoryPlay(RowColumn rowColumn, TicTakChar ticTakChar)
        {
            this.RowColumn = rowColumn;
            this.TicTakChar = ticTakChar;
        }
    }
}