using System;
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
            if (IsXInPosition(RowColumn.TopLeft) && IsXInPosition(RowColumn.TopMiddle) && IsXInPosition(RowColumn.TopRight))
            {
                return GameStatus.XWins;
            }

            if (IsYInPosition(RowColumn.TopLeft) && IsYInPosition(RowColumn.CenterLeft) && IsYInPosition(RowColumn.BottomLeft))
                return GameStatus.YWins;

            if (Plays.Count == 9)
                return GameStatus.Draw;


            return GameStatus.InPlay;
        }

        private bool IsYInPosition(RowColumn rowColumn)
        {
            return Plays.ContainsKey(rowColumn) && Plays[rowColumn] == TicTakChar.Y;
        }

        private bool IsXInPosition(RowColumn rowColumn)
        {
            return Plays.ContainsKey(rowColumn) && Plays[rowColumn] == TicTakChar.X;
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