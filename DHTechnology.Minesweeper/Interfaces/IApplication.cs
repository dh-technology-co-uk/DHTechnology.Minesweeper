namespace DHTechnology.Minesweeper.Interfaces;

public interface IApplication
{
    IMineSweeper InitializeGame(string difficulty);
}