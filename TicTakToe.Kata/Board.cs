using System.Collections.Generic;

namespace TicTakToe.Kata
{
    internal class Board
    {
        private Dictionary<RowColumn, TicTakChar> _plays;
        public Dictionary<RowColumn, TicTakChar> Plays
        {
            get
            {
                if (_plays == null)
                    _plays = new Dictionary<RowColumn, TicTakChar>();

                return _plays;
            }
        }

        public void Add(RowColumn column, TicTakChar ticTakChar)
        {
            Plays.Add(column, ticTakChar);
        }


        public GameStatus GetGameStatus()
        {
            if (Plays.ContainsKey(RowColumn.TopLeft) && Plays[RowColumn.TopLeft] == TicTakChar.X &&
                Plays.ContainsKey(RowColumn.TopMiddle) && Plays[RowColumn.TopMiddle] == TicTakChar.X &&
                Plays.ContainsKey(RowColumn.TopRight) && Plays[RowColumn.TopRight] == TicTakChar.X
                )
            {
                return GameStatus.XWins;
            }

            return GameStatus.InPlay;
        }

        protected bool Equals(Board other)
        {
            return Equals(_plays, other._plays);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Board)obj);
        }

        public override int GetHashCode()
        {
            return (_plays != null ? _plays.GetHashCode() : 0);
        }

        public static bool operator ==(Board left, Board right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Board left, Board right)
        {
            return !Equals(left, right);
        }

    }
}