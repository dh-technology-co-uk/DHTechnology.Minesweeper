namespace DHTechnology.Minesweeper.Tests;

public class MineSweeperTests
{
    [Fact]
    public void InitializeMineSweeper_SetsBoardAndLives()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        var mineSweeper = new MineSweeper();

        // Act
        mineSweeper.InitializeMineSweeper(boardMock.Object, 3);

        // Assert
        boardMock.Verify(b => b.SetPlayerPosition(0, 0), Times.Once);
    }
}