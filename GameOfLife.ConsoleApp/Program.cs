namespace GameOfLife.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = System.Text.Encoding.Unicode;
        bool[,] board = new bool[20, 21];

        // sor, oszlop
        board[1, 0] = true;
        board[1, 1] = true;
        board[1, 2] = true;
        board[2, 1] = true;
        board[2, 2] = true;
        board[2, 3] = true;

        ShowBoard(board);
        Console.ReadLine();
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