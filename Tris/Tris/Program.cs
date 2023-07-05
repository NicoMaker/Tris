using System;

namespace Tris
{
    public class TrisGame
    {
        private const int GridSize = 3;
        private char[,] grid;
        private char currentPlayer;

        public TrisGame()
        {
            grid = new char[GridSize, GridSize];
            currentPlayer = 'X';
        }

        public void StartGame()
        {
            Console.WriteLine("Benvenuto nel gioco del tris!");
            Console.WriteLine("Inserisci le coordinate della tua mossa utilizzando il formato 'riga,colonna' (es. 1,2)");

            bool gameOver = false;

            while (!gameOver)
            {
                DrawGrid();
                Console.WriteLine($"È il turno del giocatore {currentPlayer}");

                bool validMove = false;

                while (!validMove)
                {
                    Console.Write("Inserisci la tua mossa: ");
                    string input = Console.ReadLine();

                    if (TryParseMove(input, out int row, out int col))
                    {
                        if (IsValidMove(row, col))
                        {
                            MakeMove(row, col);
                            validMove = true;

                            if (CheckWin())
                            {
                                DrawGrid();
                                Console.WriteLine($"Il giocatore {currentPlayer} vince!");
                                gameOver = true;
                            }
                            else if (IsGridFull())
                            {
                                DrawGrid();
                                Console.WriteLine("Pareggio!");
                                gameOver = true;
                            }
                            else
                            {
                                SwitchPlayer();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Mossa non valida. Riprova.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input non valido. Riprova.");
                    }
                }
            }

            Console.WriteLine("Grazie per aver giocato! Premi un tasto per uscire.");
            Console.ReadKey();
        }

        private void DrawGrid()
        {
            Console.Clear();
            Console.WriteLine("Gioco del tris");
            Console.WriteLine();

            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    Console.Write($"{grid[row, col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private bool TryParseMove(string input, out int row, out int col)
        {
            row = -1;
            col = -1;

            string[] parts = input.Split(',');

            if (parts.Length == 2 && int.TryParse(parts[0], out row) && int.TryParse(parts[1], out col))
            {
                return true;
            }

            return false;
        }

        private bool IsValidMove(int row, int col)
        {
            if (row >= 0 && row < GridSize && col >= 0 && col < GridSize && grid[row, col] == '\0')
            {
                return true;
            }

            return false;
        }

        private void MakeMove(int row, int col)
        {
            grid[row, col] = currentPlayer;
        }

        private bool CheckWin()
        {
            // Check rows
            for (int row = 0; row < GridSize; row++)
            {
                if (grid[row, 0] == currentPlayer && grid[row, 1] == currentPlayer && grid[row, 2] == currentPlayer)
                    return true;
            }

            // Check columns
            for (int col = 0; col < GridSize; col++)
            {
                if (grid[0, col] == currentPlayer && grid[1, col] == currentPlayer && grid[2, col] == currentPlayer)
                    return true;
            }

            // Check diagonals
            if (grid[0, 0] == currentPlayer && grid[1, 1] == currentPlayer && grid[2, 2] == currentPlayer)
                return true;
            if (grid[0, 2] == currentPlayer && grid[1, 1] == currentPlayer && grid[2, 0] == currentPlayer)
                return true;

            return false;
        }

        private bool IsGridFull()
        {
            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    if (grid[row, col] == '\0')
                        return false;
                }
            }

            return true;
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            TrisGame game = new TrisGame();
            game.StartGame();
        }
    }
}
