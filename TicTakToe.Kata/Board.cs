using System;
using System.Collections.Generic;
using System.Linq;

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

        private readonly IReadOnlyCollection<List<RowColumn>> WinCombinations = new List<List<RowColumn>>
        {
            new List<RowColumn> { RowColumn.TopLeft, RowColumn.CenterMiddle, RowColumn.BottomRight },
            new List<RowColumn> { RowColumn.TopLeft, RowColumn.CenterLeft, RowColumn.BottomLeft },
            new List<RowColumn> { RowColumn.TopLeft, RowColumn.TopMiddle, RowColumn.TopRight },
            new List<RowColumn> { RowColumn.CenterLeft, RowColumn.CenterMiddle, RowColumn.CenterRight },
            new List<RowColumn> { RowColumn.BottomLeft, RowColumn.BottomMiddle, RowColumn.BottomRight },
            new List<RowColumn> { RowColumn.TopMiddle, RowColumn.CenterMiddle, RowColumn.BottomMiddle },
            new List<RowColumn> { RowColumn.TopRight, RowColumn.CenterMiddle, RowColumn.BottomLeft },
        };

        public void Add(RowColumn column, TicTakChar ticTakChar)
        {
            Plays.Add(column, ticTakChar);
        }


        public GameStatus GetGameStatus()
        {
            if (AnyWinCondition())
            {
                return GameStatus.XWins;
            }

            if (IsYInPosition(RowColumn.TopLeft) && IsYInPosition(RowColumn.CenterLeft) && IsYInPosition(RowColumn.BottomLeft))
                return GameStatus.YWins;

            if (Plays.Count == 9)
                return GameStatus.Draw;


            return GameStatus.InPlay;
        }

        private bool AnyWinCondition()
        {
            return WinCombinations.Any(p => p.All(x => IsXInPosition(x, TicTakChar.X)));
        }

        private bool IsYInPosition(RowColumn rowColumn)
        {
            return Plays.ContainsKey(rowColumn) && Plays[rowColumn] == TicTakChar.Y;
        }

        private bool IsXInPosition(RowColumn rowColumn, TicTakChar ticTakCharX)
        {
            return Plays.ContainsKey(rowColumn) && Plays[rowColumn] == ticTakCharX;
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