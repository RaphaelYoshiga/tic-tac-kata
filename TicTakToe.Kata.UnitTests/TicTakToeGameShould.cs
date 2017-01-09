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
        public void ConsiderHorizontalWinning()
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
    }

    
}
