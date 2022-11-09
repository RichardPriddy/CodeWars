using System;
using System.Linq;

namespace CodeWars.App.Challenges
{

    public class Sudoku
    {
        public static bool ValidateSolution(int[][] board)
        {
            var required = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // If there are any 0s then it's not valid.
            if (board.Any(i => i.Any(i => i == 0))) return false;

            // Check rows
            foreach (var row in board)
            {
                if (!row.OrderBy(i => i).SequenceEqual(required)) return false;
            }

            // Check columns
            for (int i = 0; i < 9; i++)
            {
                if (!board.Select(r => r[i]).OrderBy(c => c).SequenceEqual(required)) return false;
            }

            // Check squares
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Build an array based on the square
                    var square = new int[] { board[i * 3][j * 3], board[i * 3][j * 3 + 1], board[i * 3][j * 3 + 2],
                                            board[i * 3 + 1][j * 3], board[i * 3 + 1][j * 3 + 1], board[i * 3 + 1][j * 3 + 2],
                                            board[i * 3 + 2][j * 3], board[i * 3 + 2][j * 3 + 1], board[i * 3 + 2][j * 3 + 2]};

                    if (!square.OrderBy(c => c).SequenceEqual(required)) return false;
                }
            }

            return true;
        }
    }
}
