namespace DHTechnology.Minesweeper.Tests;

public class BoardTests
{
    [Fact]
    public void InitializeBoard_InitializesBoardWithGivenDimensionsAndMines()
    {
        // Arrange
        var board = new Board();

        // Act
        board.InitializeBoard(8, 8, 10);

        // Assert
        Assert.Equal(8, board.GetRows());
        Assert.Equal(8, board.GetCols());
    }

    [Fact]
    public void IsMine_ReturnsTrueForMine()
    {
        // Arrange
        var board = new Board();
        board.InitializeBoard(8, 8, 64);

        // Act & Assert
        Assert.True(board.IsMine(0, 0));
    }

    [Fact]
    public void IsMine_ReturnsFalseForNonMine()
    {
        // Arrange
        var board = new Board();
        board.InitializeBoard(8, 8, 10);

        // Act & Assert
        Assert.False(board.IsMine(0, 1));
    }

    [Fact]
    public void SetPlayerPosition_SetsPlayerPosition()
    {
        // Arrange
        var board = new Board();

        // Act
        board.SetPlayerPosition(3, 4);

        // Assert
        Assert.Equal(3, board.GetPlayerRow());
        Assert.Equal(4, board.GetPlayerColumn());
    }

    [Fact]
    public void GetChessTerminology_ReturnsCorrectChessTerminology()
    {
        // Arrange
        var board = new Board();

        // Act & Assert
        Assert.Equal("A1", board.GetChessTerminology(0, 0));
        Assert.Equal("B2", board.GetChessTerminology(1, 1));
        Assert.Equal("C3", board.GetChessTerminology(2, 2));
    }

    [Fact]
    public void MovePlayer_UpdatesPlayerPosition()
    {
        // Arrange
        var board = new Board();
        board.InitializeBoard(8, 8, 10);
        board.SetPlayerPosition(3, 3);

        // Act
        board.MovePlayer("up");

        // Assert
        Assert.Equal(2, board.GetPlayerRow());
        Assert.Equal(3, board.GetPlayerColumn());
    }

    [Fact]
    public void MovePlayer_DoesNotMovePlayerOutOfBounds()
    {
        // Arrange
        var board = new Board();
        board.InitializeBoard(8, 8, 10);
        board.SetPlayerPosition(0, 0);

        // Act
        board.MovePlayer("up");

        // Assert
        Assert.Equal(0, board.GetPlayerRow());
        Assert.Equal(0, board.GetPlayerColumn());
    }
}