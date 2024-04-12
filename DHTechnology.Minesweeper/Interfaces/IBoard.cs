namespace DHTechnology.Minesweeper.Interfaces;

public interface IBoard
{
    int GetRows();
    int GetCols();
    void InitializeBoard(int rows, int cols, int numMines);
    void PlaceMines();
    bool IsMine(int row, int col);
    void SetPlayerPosition(int row, int col);
    bool MovePlayer(string direction);
    int GetPlayerColumn();
    int GetPlayerRow();
    string GetChessTerminology(int row, int col);
}