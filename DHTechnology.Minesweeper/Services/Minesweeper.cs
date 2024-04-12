using DHTechnology.Minesweeper.Interfaces;

namespace DHTechnology.Minesweeper.Services;

public class MineSweeper : IMineSweeper
{
    private IBoard _board;
    private int _lives;
    private int _moves;

    public void InitializeMineSweeper(IBoard board, int lives)
    {
        _board = board;
        _lives = lives;
        _moves = 0;
        board.SetPlayerPosition(0, 0);
    }

    public void Play()
    {
        Console.WriteLine("Board Size: Columns: {0}, Rows: {1}", _board.GetCols(), _board.GetRows());

        while (_board.GetCols() - 1 > _board.GetPlayerColumn())
        {
            Console.WriteLine("Lives: {0}, Moves: {1}, Current Position: {2}", _lives, _moves,
                _board.GetChessTerminology(_board.GetPlayerRow(), _board.GetPlayerColumn()));
            Console.WriteLine("Enter your move direction (up, down, left, right): ");

            var direction = Console.ReadLine();
            if (_board.MovePlayer(direction))
            {
                _moves++;
                if (_board.IsMine(_board.GetPlayerRow(), _board.GetPlayerColumn()))
                {
                    _lives--;
                    Console.WriteLine("Oops! You hit a mine!");
                    if (_lives == 0)
                    {
                        Console.WriteLine("Game over!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Safe move!");
                }
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }

            Console.WriteLine("      ");
        }

        Console.WriteLine("Congratulations! You reached the other side of the board!");
    }
}