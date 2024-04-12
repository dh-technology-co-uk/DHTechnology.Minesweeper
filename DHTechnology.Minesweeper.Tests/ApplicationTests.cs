namespace DHTechnology.Minesweeper.Tests;

public class ApplicationTests
{
    [Fact]
    public void InitializeGame_BeginsWithBeginnerDifficulty_InitializesBoardAndMineSweeper()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        var mineSweeperMock = new Mock<IMineSweeper>();
        var application = new Application(boardMock.Object, mineSweeperMock.Object);

        // Act
        application.InitializeGame("beginner");

        // Assert
        boardMock.Verify(b => b.InitializeBoard(8, 8, 6), Times.Once);
        mineSweeperMock.Verify(m => m.InitializeMineSweeper(boardMock.Object, 3), Times.Once);
    }

    [Fact]
    public void InitializeGame_BeginsWithAdvancedDifficulty_InitializesBoardAndMineSweeper()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        var mineSweeperMock = new Mock<IMineSweeper>();
        var application = new Application(boardMock.Object, mineSweeperMock.Object);

        // Act
        application.InitializeGame("advanced");

        // Assert
        boardMock.Verify(b => b.InitializeBoard(8, 8, 12), Times.Once);
        mineSweeperMock.Verify(m => m.InitializeMineSweeper(boardMock.Object, 3), Times.Once);
    }

    [Fact]
    public void InitializeGame_BeginsWithExpertDifficulty_InitializesBoardAndMineSweeper()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        var mineSweeperMock = new Mock<IMineSweeper>();
        var application = new Application(boardMock.Object, mineSweeperMock.Object);

        // Act
        application.InitializeGame("expert");

        // Assert
        boardMock.Verify(b => b.InitializeBoard(8, 8, 20), Times.Once);
        mineSweeperMock.Verify(m => m.InitializeMineSweeper(boardMock.Object, 3), Times.Once);
    }

    [Fact]
    public void InitializeGame_InvalidDifficulty_ThrowsArgumentException()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        var mineSweeperMock = new Mock<IMineSweeper>();
        var application = new Application(boardMock.Object, mineSweeperMock.Object);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => application.InitializeGame("invalid"));
    }
}