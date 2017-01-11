using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_HW2
{
    class Program
    {
        /*static string user1;
        static string user2;
        static string player;*/

        static void Main(string[] args)
        {

            /** Get user names, assign to X or O **/
            Console.WriteLine("User 1, what is your name? ");
            string user1 = Console.ReadLine().ToUpper();
            Console.WriteLine($"{user1} you will be Xs.");
            Console.WriteLine("");

            Console.WriteLine("User2, what is your name? ");
            string user2 = Console.ReadLine().ToUpper();
            Console.WriteLine($"{user2} you will be Os.");
            Console.ReadLine();
            Console.Clear();

            /** Create Game Board Array **/
            string[] gameBoard = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

            bool winner = false;
            string player = user1;

            /** Play Game **/
            while (!winner)
            {
                DisplayBoard(gameBoard);
                winner = PlayerTurn(player, user1, user2, gameBoard);
            }

        }

        /** Method for displaying Game Board **/
        public static void DisplayBoard(string[] gameBoard)
        {

            int counter = 0;

            Console.WriteLine("");

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

            Console.WriteLine("");
            Console.WriteLine("");
        }

        /* Method for user turn */
        public static bool PlayerTurn(string player, string user1, string user2, string[] gameBoard)
        {
            int userMove;
            bool valid;
            bool winner = false;
            int turnCount = 0;

            Console.WriteLine($"{player}, where would you like to move?");
            userMove = int.Parse(Console.ReadLine());

            valid = Validation(userMove, gameBoard, player, user1);

            if (turnCount >= 5)
            {
                winner = WinConditions(gameBoard);
            }

            if (valid && !winner)
            {
                /* Switch player */
                player = player == user1 ? user2 : user1;
                Console.Clear();
            }
            else if (!valid && !winner)
            {
                Console.WriteLine("Sorry, that's not a valid choice.");
                Console.ReadLine();
                Console.Clear();
            }

            return winner;

        }

        /* Method for checking validity and assigning userMove to array */
        public static bool Validation(int userMove, string[] gameBoard,
            string user1, string player)
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
        public static bool WinConditions(string[] gameBoard)
        {
            int i;
            bool keepChecking = true;
            bool winner = false;

            while (keepChecking)
            {
                /* Check for vertical wins */
                for (i = 0; i < 3; i++)
                {
                    if (gameBoard[i] == gameBoard[i + 3] && gameBoard[i] == gameBoard[i + 6])
                    {
                        winner = true;
                        keepChecking = false;
                        i = 3;
                    }
                }
            }

            while (keepChecking)
            {
                /* Check for horizontal wins */
                for (i = 0; i < 3; i++)
                {
                    if (gameBoard[i] == gameBoard[i + 1] && gameBoard[i] == gameBoard[i + 1])
                    {
                        winner = true;
                        keepChecking = false;
                        i = 3;
                    }
                }
            }

            while (keepChecking)
            {
                /* Check for diagonal wins */
                for (i = 0; i < 3; i++)
                {
                    if (gameBoard[i] == gameBoard[i + 4] && gameBoard[i] == gameBoard[i + 8])
                    {
                        winner = true;
                        keepChecking = false;
                    }
                    else if (gameBoard[i + 2] == gameBoard[i + 4] && gameBoard[i] == gameBoard[i + 6])
                    {
                        winner = true;
                        keepChecking = false;
                    }
                }
            }
            
            return winner;

        }



    }

}

