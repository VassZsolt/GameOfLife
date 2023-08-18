namespace GameOfLife.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = System.Text.Encoding.Unicode;
        bool[,] board = new bool[20, 21];

        string input = """
                       ........
                       ........
                       ..xxx...
                       ...xxx..
                       ........
                       ........
                       """;

        board = ParseBoard(input);

        while (true)
        {
            ShowBoard(board);
            Console.ReadLine();
            board = Tick(board);
        }

    }

    private static bool[,] Tick(bool[,] previousGeneration)
    {
        bool[,] nextGeneration = new bool[previousGeneration.GetLength(0), previousGeneration.GetLength(1)];

        // Rule 2: Any live cell with two or three live neighbours survives.
        // Rule 4: Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        for (int row = 0; row < previousGeneration.GetLength(0); row++)
        {
            for (int col = 0; col < previousGeneration.GetLength(1); col++)
            {
                int numOfLivingNeighbors = NumberOfLivingNeighbors(previousGeneration, row, col);
                if (previousGeneration[row, col] && (numOfLivingNeighbors is 2 or 3))
                {
                    nextGeneration[row, col] = true;
                }
                if (!previousGeneration[row, col] && numOfLivingNeighbors == 3)
                {
                    nextGeneration[row, col] = true;
                }
            }
        }

        return nextGeneration;
    }

    private static int NumberOfLivingNeighbors(bool[,] board, int row, int col)
    {
        int count = 0;

        if (row > 0 && col > 0 && board[row - 1, col - 1])
            count++;
        if (row > 0 && board[row - 1, col])
            count++;
        if (row > 0 && col < board.GetLength(1) - 1 && board[row - 1, col + 1])
            count++;
        if (col > 0 && board[row, col - 1])
            count++;
        if (col < board.GetLength(1) - 1 && board[row, col + 1])
            count++;
        if (row < board.GetLength(0) - 1 && col > 0 && board[row + 1, col - 1])
            count++;
        if (row < board.GetLength(0) - 1 && board[row + 1, col])
            count++;
        if (row < board.GetLength(0) - 1 && col < board.GetLength(1) - 1 && board[row + 1, col + 1])
            count++;

        return count;
    }

    private static void ShowBoard(bool[,] board)
    {
        Console.Clear();
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col])
                {
                    Console.Write("×");
                }
                else
                {
                    Console.Write('.');
                    //Console.Write('⦁'); TODO: Megoldani hogy megjelenjen
                }

            }
            Console.WriteLine();
        }
    }

    private static bool[,] ParseBoard(string input)
    {
        string[] rows = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        bool[,] board = new bool[rows.Length, rows.Max(x => x.Length)];

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (rows[row][col] == 'x')
                {
                    board[row, col] = true;
                }
            }
        }

        return board;
    }
}