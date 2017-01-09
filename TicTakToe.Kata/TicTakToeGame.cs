namespace TicTakToe.Kata
{
    public class TicTakToeGame
    {
        private Board _board;

        public TicTakToeGame()
        {
            _board = new Board();
        }

        public void PlayY(RowColumn rowColumn)
        {
            _board.Add(rowColumn, TicTakChar.Y);
        }

        public void PlayX(RowColumn rowColumn)
        {
            _board.Add(rowColumn, TicTakChar.X);
        }

        public GameStatus GetStatus()
        {
            return _board.GetGameStatus();
        }

        protected bool Equals(TicTakToeGame other)
        {
            return Equals(_board, other._board);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TicTakToeGame) obj);
        }

        public override int GetHashCode()
        {
            return (_board != null ? _board.GetHashCode() : 0);
        }

        public static bool operator ==(TicTakToeGame left, TicTakToeGame right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TicTakToeGame left, TicTakToeGame right)
        {
            return !Equals(left, right);
        }
    }
}
