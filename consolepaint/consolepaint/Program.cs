using System.ComponentModel;

namespace consolepaint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, e) =>
            {

                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            };
            Console.WriteLine("Console Paint");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Controls:");
            Console.WriteLine("Moving between cells: ArrowKeys");
            Console.WriteLine("Color: 1,2,3,4");
            Console.WriteLine("Enter: SpaceBar");
            Console.WriteLine("Press ESC to Exit");
            Console.WriteLine($"Current cell: 0;0");

            var taskKeys = new Task(ReadKeys);

            taskKeys.Start();

            var tasks = new[] { taskKeys };
            Task.WaitAll(tasks);
        }
        private static void ReadKeys()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            string[,] table = new string[10, 10];
            int row = 0;
            int col = 0;
            int wrow = 0;
            int wcol = 0;
            int i = 0;
            int j = 0;
            string write = " ";
            int writenum = 0;

            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (row == 0)
                        {

                        }
                        else
                        {
                            row--;
                        }
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        break;
                    case ConsoleKey.DownArrow:
                        if (row == 10)
                        {

                        }
                        else
                        {
                            row++;
                        }
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        break;

                    case ConsoleKey.RightArrow:
                        if (col == 10)
                        {

                        }
                        else
                        {
                            col++;
                        }
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        break;

                    case ConsoleKey.LeftArrow:
                        if (col == 0)
                        {

                        }
                        else
                        {
                            col--;
                        }
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        break;

                    case ConsoleKey.D1:
                        write = "█";
                        writenum = 1;
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        break;

                    case ConsoleKey.D2:
                        write = "▓";
                        writenum = 2;
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        break;

                    case ConsoleKey.D3:
                        write = "▒";
                        writenum = 3;
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        break;

                    case ConsoleKey.D4:
                        write = "░";
                        writenum = 4;
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        break;

                    case ConsoleKey.Spacebar:
                        MenuWrite();
                        Console.WriteLine($"Current cell: {col};{row}");
                        Console.WriteLine($"Current color: {writenum}  {write}");
                        table[row, col] = write;
                        j++;
                        break;

                    case ConsoleKey.Escape:
                        break;
                }
                if (j != 0)
                {
                    while (i < table.Length)
                    {
                        if (wcol != 10)
                        {
                            if (table[wrow, wcol] == "█" | table[wrow, wcol] == "▓" | table[wrow, wcol] == "▒" | table[wrow, wcol] == "░")
                            {
                                Console.Write(table[wrow, wcol]);
                                wcol++;
                                i++;
                            }
                            else
                            {
                                Console.Write(" ");
                                wcol++;
                                i++;
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            wcol = 0;
                            wrow++;
                        }
                    }
                }
                i = 0;
                j = 0;
                wcol = 0;
                wrow = 0;
            }
        }
        private static void MenuWrite()
        {
            Console.Clear();
            Console.WriteLine("Console Paint");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Controls:");
            Console.WriteLine("Moving between cells: ArrowKeys");
            Console.WriteLine("Color: 1,2,3,4");
            Console.WriteLine("Enter: SpaceBar");
            Console.WriteLine("Press ESC to Exit");

        }
    }
}