namespace DHTechnology.Minesweeper.Interfaces;

public interface IMineSweeper
{
    void Play();

    void InitializeMineSweeper(IBoard board, int lives);
}