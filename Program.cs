using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_HW2
{
    class Program
    {
        static string user1;
        static string user2;
        static string[] gameBoard = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        static string player;
        static int winner = 0;
        static int turnCount = 0;


        static void Main(string[] args)
        {
            GetUserNames();

            while (winner == 0)
            {
                DisplayBoard();
                PlayerTurn();
            }

            if (winner == 1 || winner == 2)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"{player} WINS!!!");
            }
            else
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("It's a draw!");
            }

        }

        /** Get user names, assign to X or O **/
        public static void GetUserNames()
        {
            Console.WriteLine("User 1, what is your name? ");
            user1 = Console.ReadLine().ToUpper();
            Console.WriteLine($"{user1} you will be Xs.");
            Console.WriteLine("");

            Console.WriteLine("User2, what is your name? ");
            user2 = Console.ReadLine().ToUpper();
            Console.WriteLine($"{user2} you will be Os.");
            Console.ReadLine();
            Console.Clear();

            player = user1;
        }

        /** Method for displaying Game Board **/
        public static void DisplayBoard()
        {
            int counter = 0;

            Console.WriteLine("\n");

            foreach (var space in gameBoard)
            {
                Console.Write("   | " + space + " |");
                if (counter == 2)
                {
                    Console.WriteLine("");
                    counter = 0;
                }
                else
                {
                    counter++;
                }
            }

            Console.WriteLine("\n");
        }

        /* Method for user turn */
        public static void PlayerTurn()
        {
            int userMove;
            bool valid;

            turnCount++;

            Console.WriteLine($"{player}, where would you like to move?");
            userMove = int.Parse(Console.ReadLine());

            valid = Validation(userMove);

            if (turnCount > 4)
            {
                WinConditions();
            }

            if (valid && winner == 0)
            {
                /* Switch player */
                player = player == user1 ? user2 : user1;
                Console.Clear();
            }
            else if (!valid && winner == 0)
            {
                Console.WriteLine("Sorry, that's not a valid choice.");
                Console.ReadLine();
                Console.Clear();
            }

        }

        /* Method for checking validity and assigning userMove to array */
        public static bool Validation(int userMove)
        {
            bool valid = true;
            string xo = player == user1 ? "X" : "O";

            //Need to check userMove data type

            if (userMove >= 0 && userMove <= 8)
            {
                if (gameBoard[userMove] != "X" && gameBoard[userMove] != "O")
                {
                    gameBoard[userMove] = xo;
                }
                else
                {
                    valid = false;
                };
            }
            else
            {
                valid = false;
            }

            return valid;
        }


        /** Method for checking win conditions **/
        public static void WinConditions()
        {
            bool keepChecking = true;

            while (keepChecking)
            {
                /* Check for horizontal wins */
                for (int i = 0; i < 9; i += 3)
                {
                    if (gameBoard[i] == gameBoard[i + 1] && gameBoard[i] == gameBoard[i + 2])
                    {
                        winner = player == user1 ? 1 : 2;
                        keepChecking = false;
                        break;
                    }
                }

                /* Check for vertical wins */
                for (int i = 0; i < 3; i += 1)
                {
                    if (gameBoard[i] == gameBoard[i + 3] && gameBoard[i] == gameBoard[i + 6])
                    {
                        winner = player == user1 ? 1 : 2;
                        keepChecking = false;
                        break;
                    }
                }

                /* Check for diagonal win L-R */
                if (gameBoard[0] == gameBoard[4] && gameBoard[0] == gameBoard[8])
                {
                    winner = player == user1 ? 1 : 2;
                    keepChecking = false;
                    break;
                }
                /* Check for diagonal win R-L */
                else if (gameBoard[2] == gameBoard[4] && gameBoard[2] == gameBoard[6])
                {
                    winner = player == user1 ? 1 : 2;
                    keepChecking = false;
                    break;
                }

                /* Check for a tie */
                if (turnCount == 9 && winner == 0)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (gameBoard[i] == "X" || gameBoard[i] == "O")
                        {
                            winner = 3;
                            keepChecking = false;
                            break;
                        }
                        else
                        {
                            winner = 0;
                            keepChecking = false;
                            break;
                        }
                    }
                }

                keepChecking = false;

            }
        }
    }

}

