using FluentAssertions;
using NUnit.Framework;

namespace TicTakToe.Kata.UnitTests
{
    [TestFixture]
    public class TicTakToeGameShould
    {
        [Test]
        public void BeTheSameAsOtherGame_GivenBothHaveNotStarted()
        {
            var game = new TicTakToeGame();
            var otherGame = new TicTakToeGame();

            game.Should().Be(otherGame);
        }

        [Test]
        public void NotBeTheSameAsOtherGame_GivenOneHasBeenPlayed()
        {
            var game = new TicTakToeGame();
            var otherGame = new TicTakToeGame();
            otherGame.PlayX(RowColumn.TopLeft);

            game.Should().NotBe(otherGame);
        }

        [Test]
        public void NotBeTheSameAsOtherGame_GivenOtherGameHasBeenPlayedOneMoreTime()
        {
            var game = new TicTakToeGame();
            var otherGame = new TicTakToeGame();

            game.PlayX(RowColumn.TopLeft);
            otherGame.PlayX(RowColumn.TopLeft);
            otherGame.PlayY(RowColumn.TopRight);

            game.Should().NotBe(otherGame);
        }

        [Test]
        public void NotBeTheSameAsOtherGame_GivenDifferentPlays()
        {
            var otherGame = new TicTakToeGame();
            var game = new TicTakToeGame();

            game.PlayX(RowColumn.TopLeft);
            game.PlayX(RowColumn.TopMiddle);

            game.Should().NotBe(otherGame);
        }


        [Test]
        public void BeInPlay()
        {
            var game = new TicTakToeGame();

            var gameStatus = game.GetStatus();

            gameStatus.Should().Be(GameStatus.InPlay);
        }

        [Test]
        public void ConsiderHorizontalWinningX()
        {
            var game = new TicTakToeGame();
            game.PlayX(RowColumn.TopLeft);
            game.PlayY(RowColumn.BottomLeft);
            game.PlayX(RowColumn.TopMiddle);
            game.PlayY(RowColumn.BottomRight);
            game.PlayX(RowColumn.TopRight);

            var gameStatus = game.GetStatus();

            gameStatus.Should().Be(GameStatus.XWins);
        }

        [Test]
        public void ConsiderVerticalWinningX()
        {
            var game = new TicTakToeGame();
            game.PlayX(RowColumn.TopLeft);
            game.PlayY(RowColumn.BottomRight);
            game.PlayX(RowColumn.CenterLeft);
            game.PlayY(RowColumn.BottomMiddle);
            game.PlayX(RowColumn.BottomLeft);

            var gameStatus = game.GetStatus();

            gameStatus.Should().Be(GameStatus.XWins);
        }

        [Test]
        public void ConsiderDiagonalWinningX()
        {
            var game = new TicTakToeGame();
            game.PlayX(RowColumn.TopLeft);
            game.PlayY(RowColumn.CenterLeft);
            game.PlayX(RowColumn.CenterMiddle);
            game.PlayY(RowColumn.BottomMiddle);
            game.PlayX(RowColumn.BottomRight);

            var gameStatus = game.GetStatus();

            gameStatus.Should().Be(GameStatus.XWins);
        }


        [Test]
        public void ConsiderVerticalWinningY()
        {
            var game = new TicTakToeGame();
            game.PlayX(RowColumn.BottomRight);
            game.PlayY(RowColumn.TopLeft);
            game.PlayX(RowColumn.CenterMiddle);
            game.PlayY(RowColumn.CenterLeft);
            game.PlayX(RowColumn.CenterRight);
            game.PlayY(RowColumn.BottomLeft);

            var gameStatus = game.GetStatus();

            gameStatus.Should().Be(GameStatus.YWins);
        }


        [Test]
        public void BecomeADrawWhenAllPositionsFilled()
        {
            var game = new TicTakToeGame();
            game.PlayX(RowColumn.TopLeft);
            game.PlayY(RowColumn.TopMiddle);
            game.PlayX(RowColumn.TopRight);
            game.PlayY(RowColumn.CenterMiddle);
            game.PlayX(RowColumn.BottomMiddle);
            game.PlayY(RowColumn.CenterLeft);
            game.PlayX(RowColumn.BottomLeft);
            game.PlayY(RowColumn.CenterRight);
            game.PlayY(RowColumn.BottomRight);

            var gameStatus = game.GetStatus();

            gameStatus.Should().Be(GameStatus.Draw);
        }
    }

    
}
