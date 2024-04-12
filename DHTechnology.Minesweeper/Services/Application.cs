namespace DHTechnology.Minesweeper.Services;

public class Application : IApplication
{
    public readonly IBoard Board;
    public readonly IMineSweeper MineSweeper;

    public Application(IBoard board, IMineSweeper mineSweeper)
    {
        Board = board;
        MineSweeper = mineSweeper;
    }


    public IMineSweeper InitializeGame(string difficulty)
    {
        int rows, cols, mines;
        switch (difficulty.ToLower())
        {
            case "beginner":
                rows = 8;
                cols = 8;
                mines = 6;
                break;
            case "advanced":
                rows = 8;
                cols = 8;
                mines = 12;
                break;
            case "expert":
                rows = 8;
                cols = 8;
                mines = 20;
                break;
            default:
                throw new ArgumentException("Invalid difficulty level. Please restart game");
        }

        Board.InitializeBoard(rows, cols, mines);
        MineSweeper.InitializeMineSweeper(Board, 3);
        return MineSweeper;
    }
}