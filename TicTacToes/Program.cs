using System;
using System.Threading;

namespace TicTacToes
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static int player = 1;
        static int flag = 1;
        static int choice;
        static bool inputCorrect = true;

        static void Main(string[] args)
        {
            // bool done = ;

            do
            {
                TicTac();

                Console.WriteLine("Press any key to reset or Press Esc to Quit Game\n");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
                Console.ReadKey();
                ResetTable();

            } while (true);





        }

        public static void TicTac()
        {
            do
            {
                Console.WriteLine(Environment.NewLine);
                CreateTable();

                Console.WriteLine('\n');


                do
                {
                    Console.WriteLine("Player 1: X, Player 2: O");

                    if (player % 2 == 0)
                    {
                        Console.WriteLine("Player 2 turn");
                    }
                    else
                    {
                        Console.WriteLine("Player 1 turn");
                    }


                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        if (arr[choice] != 'X' && arr[choice] != 'O')
                        {
                            if (player % 2 == 0)
                            {
                                arr[choice] = 'O';
                                inputCorrect = true;

                            }
                            else
                            {
                                arr[choice] = 'X';
                                inputCorrect = true;

                            }
                            player++;
                        }
                        else
                        {
                            Console.WriteLine("Sorry , box {0} is already marked with {1}. \nPlease use another field.", choice, arr[choice]);
                            inputCorrect = false;
                            Thread.Sleep(2000);
                            break;

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid number");
                        inputCorrect = false;
                        Thread.Sleep(2000);
                        break;
                    }



                } while (!inputCorrect);






                flag = CheckWin();

            } while (flag != 1 && flag != -1);

            Console.Clear();
            CreateTable();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);



            }
            else
            {
                Console.WriteLine("Draw");
            }




        }


        public static void CreateTable()
        {
            Console.Clear();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    {0}    |    {1}    |    {2}    |", arr[1], arr[2], arr[3]);
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    {0}    |    {1}    |    {2}    |", arr[4], arr[5], arr[6]);
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    {0}    |    {1}    |    {2}    |", arr[7], arr[8], arr[9]);
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("-------------------------------");
        }

        public static void ResetTable()
        {
            char[] arr2 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            arr = arr2;
            CreateTable();

        }

        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Vertical Winning Condtion
            if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }

            #endregion

            #region Diagonal Winning Condtion
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Draw Condition
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' &&
            arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            #endregion
            else
            {
                return 0;
            }
        }
    }
}

