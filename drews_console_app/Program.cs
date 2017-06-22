using System;

namespace drews_console_app
{
    class MainClass
    {
        // fields
        static Random rand = new Random();

		// properties
		static char AsciiCharacter
		{
			get
			{
				int t = rand.Next(10);
				if (t <= 2)
					// returns a number
					return (char)('0' + rand.Next(10));
				else if (t <= 4)
					// small letter
					return (char)('a' + rand.Next(27));
				else if (t <= 6)
					// capital letter
					return (char)('A' + rand.Next(27));
				else
					// any ascii character
					return (char)(rand.Next(32, 255));
			}
		}


        // Main
        public static void Main(string[] args)
        {
            Console.WriteLine("Console apps rock!");

			while (true) // Loop indefinitely
			{
				Console.WriteLine("What do you want to do? \n\n");
				Console.WriteLine("1 - Count to ten");
				Console.WriteLine("2 - Check the surf report");
				Console.WriteLine("3 - Enter the matrix");
				Console.WriteLine("4 - Exit");
				Console.WriteLine("Enter input:"); // Prompt
				string input = Console.ReadLine(); // Get string from user


                if (input == "1")
                {
                    CountToTen();
                }
                else if (input == "2"){
					PrintSurfReport();
				}
                else if (input == "3"){
                    EnterTheMatrix();
                }
                else if (input == "4")
                {
					Console.WriteLine("Exiting ...");
					break;
                }
                else
					Console.WriteLine("Sorry, that's not a valid option.");
			}
        }
    
    
        public static void CountToTen()
        {
			Console.WriteLine("Lets count to ten ... \n\n");
			for (int i = 0; i <= 10; i++)
			{
				Console.WriteLine("Counting ... {0}", i);
				System.Threading.Thread.Sleep(500);
			}
        }


		public static void PrintSurfReport()
		{
			Console.WriteLine("Thursday 6/22/17");
			Console.WriteLine("Fair - 3-5ft");
			Console.WriteLine("Waist to head high");
		}


		public static void EnterTheMatrix()
		{
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Hit Any Key To Continue");
            Console.ReadKey();
            Console.CursorVisible = false;

            int width, height;
            // setup array of starting y values
            int[] y;

            // width was 209, height was 81
            // setup the screen and initial conditions of y
            Initialize(out width, out height, out y);

            // do the Matrix effect
            // every loop all y's get incremented by 1
            while (true)
                UpdateAllColumns(width, height, y);
		}

		private static void UpdateAllColumns(int width, int height, int[] y)
		{
			int x;
			// draws 3 characters in each x column each time... 
			// a dark green, light green, and a space

			// y is the position on the screen
			// y[x] increments 1 each time so each loop does the same thing but down 1 y value
			for (x = 0; x < width; ++x)
			{
				// the bright green character
				Console.ForegroundColor = ConsoleColor.Green;
				Console.SetCursorPosition(x, y[x]);
				Console.Write(AsciiCharacter);

				// the dark green character -  2 positions above the bright green character
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				int temp = y[x] - 2;
				Console.SetCursorPosition(x, inScreenYPosition(temp, height));
				Console.Write(AsciiCharacter);

				// the 'space' - 20 positions above the bright green character
				int temp1 = y[x] - 20;
				Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
				Console.Write(' ');

				// increment y
				y[x] = inScreenYPosition(y[x] + 1, height);
			}

			// F5 to reset, F11 to pause and unpause
			if (Console.KeyAvailable)
			{
				if (Console.ReadKey().Key == ConsoleKey.F5)
					Initialize(out width, out height, out y);
				if (Console.ReadKey().Key == ConsoleKey.F11)
					System.Threading.Thread.Sleep(1);
			}

		}

		// Deals with what happens when y position is off screen
		public static int inScreenYPosition(int yPosition, int height)
		{
			if (yPosition < 0)
				return yPosition + height;
			else if (yPosition < height)
				return yPosition;
			else
				return 0;
		}

		// only called once at the start
		private static void Initialize(out int width, out int height, out int[] y)
		{
			height = Console.WindowHeight;
			width = Console.WindowWidth - 1;

			// 209 for me.. starting y positions of bright green characters
			y = new int[width];

			Console.Clear();
			// loops 209 times for me
			for (int x = 0; x < width; ++x)
			{
				// gets random number between 0 and 81
				y[x] = rand.Next(height);
			}
		}

    }
}








