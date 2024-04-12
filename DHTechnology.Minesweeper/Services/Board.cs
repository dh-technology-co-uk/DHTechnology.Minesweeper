namespace DHTechnology.Minesweeper.Services;

public class Board : IBoard
{
    private char[,] _board;
    private int boardCols;
    private int boardMines;
    private int boardRows;
    private int playerCol;
    private int playerRow;

    public int GetRows()
    {
        return boardRows;
    }

    public int GetCols()
    {
        return boardCols;
    }

    public void InitializeBoard(int rows, int cols, int mines)
    {
        boardRows = rows;
        boardCols = cols;
        boardMines = mines;

        _board = new char[boardRows, boardCols];


        for (var i = 0; i < boardRows; i++)
        for (var j = 0; j < boardCols; j++)
            _board[i, j] = ' ';

        PlaceMines();
    }

    public void PlaceMines()
    {
        var random = new Random();
        for (var i = 0; i < boardMines; i++)
        {
            var row = random.Next(0, boardRows);
            var col = random.Next(0, boardCols);
            _board[row, col] = 'X';
        }
    }

    public bool IsMine(int row, int col)
    {
        return _board[row, col] == 'X';
    }

    public void SetPlayerPosition(int row, int col)
    {
        playerRow = row;
        playerCol = col;
    }


    public int GetPlayerColumn()
    {
        return playerCol;
    }

    public int GetPlayerRow()
    {
        return playerRow;
    }

    public string GetChessTerminology(int row, int col)
    {
        var letter = col switch
        {
            0 => "A",
            >= 1 and <= 26 => Convert.ToChar('A' + col).ToString(),
            _ => null
        };

        return letter + (row + 1);
    }

    public bool MovePlayer(string direction)
    {
        var newRow = playerRow;
        var newCol = playerCol;

        switch (direction)
        {
            case "up":
                newRow = Math.Max(0, playerRow - 1);
                break;
            case "down":
                newRow = Math.Min(boardRows - 1, playerRow + 1);
                break;
            case "left":
                newCol = Math.Max(0, playerCol - 1);
                break;
            case "right":
                newCol = Math.Min(boardCols - 1, playerCol + 1);
                break;
            default:
                return false;
        }


        SetPlayerPosition(newRow, newCol);
        return true;
    }
}