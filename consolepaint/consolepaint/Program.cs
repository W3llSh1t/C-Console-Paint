using System.ComponentModel;

namespace consolepaint
{
    internal class Program
    {
        const int startRow = 11;
        const int startCol = 1;
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, e) =>
            {

                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            };

            int winwidth = Console.WindowWidth;
            int winheight = Console.WindowHeight;
            int row = 0;
            int col = 0;
            

            Console.WriteLine("Console Paint");
            for (int i = 0; i < winwidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("Controls:");
            Console.WriteLine("Moving between cells: ArrowKeys");
            Console.WriteLine("Color: 1,2,3,4");
            Console.WriteLine("Enter: SpaceBar");
            Console.WriteLine("Press ESC to Exit");
            
            for (int i = 0; i < winwidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("Current Color: Red");
            Console.WriteLine("Current saturation: █");

            Console.Write("+");

            for (int i = 0; i < (winwidth - 2); i++)
            {
                Console.Write("-");
                col++;
            }
            Console.Write("+");



            for (int i = 0; i < winheight - 9; i++)
            {
                Console.Write("|");
                for (int j = 0; j < winwidth - 2; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.WriteLine();
                row++;

            }
            Console.Write("+");
            for (int i = 0; i < (winwidth - 2); i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.SetCursorPosition(startCol, startRow);

            var taskKeys = new Task(ReadKeys);

            taskKeys.Start();

            var tasks = new[] { taskKeys };
            Task.WaitAll(tasks);
        }
        public static void ReadKeys()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            int currentRow = startRow;
            int currentCol = startCol;
            int color = 1;
            int saturation = 1;

            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);

                if(color == 1)
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if(color == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if(color == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if(color == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentRow > startRow)
                        {
                            currentRow--;
                            Console.SetCursorPosition(currentCol, currentRow);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentRow < Console.WindowHeight - 2)
                        {
                            currentRow++;
                            Console.SetCursorPosition(currentCol, currentRow);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (currentCol < Console.WindowWidth - 2)
                        {
                            currentCol++;
                            Console.SetCursorPosition(currentCol, currentRow);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (currentCol > startCol)
                        {
                            currentCol--;
                            Console.SetCursorPosition(currentCol, currentRow);
                        }
                        break;

                    case ConsoleKey.D1:
                        Console.ResetColor();
                        Console.SetCursorPosition(startCol - 1,startRow - 3);
                        Console.WriteLine("Current color: Red   ");
                        Console.SetCursorPosition(currentCol, currentRow);
                        color = 1;
                        break;

                    case ConsoleKey.D2:
                        Console.ResetColor();
                        Console.SetCursorPosition(startCol - 1, startRow - 3);
                        Console.WriteLine("Current color: Blue  ");
                        Console.SetCursorPosition(currentCol, currentRow);
                        color = 2;
                        break;

                    case ConsoleKey.D3:
                        Console.ResetColor();
                        Console.SetCursorPosition(startCol - 1, startRow - 3);
                        Console.WriteLine("Current color: Green ");
                        Console.SetCursorPosition(currentCol, currentRow);
                        color = 3;
                        break;

                    case ConsoleKey.D4:
                        Console.ResetColor();
                        Console.SetCursorPosition(startCol - 1, startRow - 3);
                        Console.WriteLine("Current color: Yellow");
                        Console.SetCursorPosition(currentCol, currentRow);
                        color = 4;
                        break;
                    
                    case ConsoleKey.Q:
                        Console.ResetColor();
                        Console.SetCursorPosition(startCol - 1, startRow - 2);
                        Console.WriteLine("Current saturation: █");
                        Console.SetCursorPosition(currentCol, currentRow);
                        saturation = 1;
                        break;

                    case ConsoleKey.W:
                        Console.ResetColor();
                        Console.SetCursorPosition(startCol - 1, startRow - 2);
                        Console.WriteLine("Current saturation: ▓");
                        Console.SetCursorPosition(currentCol, currentRow);
                        saturation = 2;
                        break;

                    case ConsoleKey.E:
                        Console.ResetColor();
                        Console.SetCursorPosition(startCol - 1, startRow - 2);
                        Console.WriteLine("Current saturation: ▒");
                        Console.SetCursorPosition(currentCol, currentRow);
                        saturation = 3;
                        break;

                    case ConsoleKey.R:
                        Console.ResetColor();
                        Console.SetCursorPosition(startCol - 1, startRow - 2);
                        Console.WriteLine("Current saturation: ░");
                        Console.SetCursorPosition(currentCol, currentRow);
                        saturation = 4;
                        break;

                    case ConsoleKey.Spacebar:
                        if(saturation == 1)
                        {
                            Console.Write("█");
                        }
                        else if(saturation == 2)
                        {
                            Console.Write("▓");
                        }
                        else if(saturation == 3)
                        {
                            Console.Write("▒");
                        }
                        else if(saturation == 4)
                        {
                            Console.Write("░");
                        }
                        Console.SetCursorPosition(currentCol, currentRow);
                        break;

                    case ConsoleKey.Escape:
                        Console.ResetColor();
                        Console.SetCursorPosition(0, Console.WindowHeight + 3);
                        break;
                }
            }
        }
    }
}