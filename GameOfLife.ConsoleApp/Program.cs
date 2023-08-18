namespace GameOfLife.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = System.Text.Encoding.Unicode;

        string input = """
                       ........
                       ........
                       ..xxx...
                       ...xxx..
                       ........
                       ........
                       """;

        bool[,] board = Engine.ParseBoard(input);

        while (true)
        {
            ShowBoard(board);
            Console.ReadLine();
            board = Engine.Tick(board);
        }

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
}