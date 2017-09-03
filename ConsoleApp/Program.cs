using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("熄灯问题");
            Guess();
        }
        public static bool Guess()
        {
            var puzzle = new int[6, 8];
            var press = new int[6, 8];
            int r = 1, c = 5;
            press[r + 1, c] = (puzzle[r, c] + press[r, c - 1] + press[r, c] + press[r, c + 1] + press[r - 1, c]) % 2;
            for (int i = 0; i < 5; i++)
            {
                for (c = 1; c < 7; c++)
                {
                    press[r + 1, c] = (puzzle[r, c] + press[r, c] + press[r - 1, c] + press[r, c - 1] + press[r, c + 1]) % 2;
                }
            }
            for (c = 1; c < 7; c++)
            {
                if ((press[5, c - 1] + press[5, c] + press[5, c + 1] + press[4, c]) % 2 != puzzle[5, c])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 进行判断
        /// </summary>
        void enumerate()
        {
            int c;
            //bool success1;
            var press = new int[1, 7];
            for (c = 1; c < 7; c++)
            {
                press[1, c] = 0;
                while (Guess())
                {
                    press[1, 1]++;
                    c = 1;
                    while (press[1, c] > 1)
                    {
                        press[1, c] = 0;
                        c++;//进位
                        press[1, c]++;
                    }
                }
                return;
            }
        }
    }
}
