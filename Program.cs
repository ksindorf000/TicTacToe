﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_HW2
{
    class Program
    {
        /*static string user1;
        string user2;
        string player;*/

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

            bool continueGame = true;
            string player = user1;
            int turnCount = 0;

            /** Play Game **/
            while (continueGame)
            {
                DisplayBoard(gameBoard);
                player = PlayerTurn(player, user1, user2, gameBoard);

                turnCount++;

                if (turnCount <= 5)
                {
                    continueGame = WinConditions(gameBoard);
                }
            }

            /** Check to see if users still want to play **/
            Console.WriteLine("Would you like to continue? (Y/N)");
            string userYN = Console.ReadLine();
            if (userYN.ToLower() != "y")
            {
                continueGame = false;
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
        public static string PlayerTurn(string player, string user1, string user2, string[] gameBoard)
        {
            int userMove;
            bool valid = true;

            Console.WriteLine($"{player}, where would you like to move?");
            userMove = int.Parse(Console.ReadLine());

            valid = Validation(userMove, gameBoard, player, user1, valid);

            if (valid)
            {
                /* Switch player */
                player = player == user1 ? user2 : user1;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Sorry, that's not a valid choice.");
                Console.ReadLine();
                Console.Clear();
            }

            return player;

        }

        /* Method for checking validity and assigning userMove to array */
        public static bool Validation(int userMove, string[] gameBoard,
            string user1, string player, bool valid)
        {

            string xo = player == user1 ? "X" : "O";

            //Need to check userMove data type

            if (userMove > 0 && userMove <= 8)
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
            bool noWin = true;

            while (noWin)
            {
                /* Check for vertical wins */
                for (i = 0; i < 3; i++)
                {
                    if (gameBoard[i] == gameBoard[i + 3] && gameBoard[i] == gameBoard[i + 6])
                    {
                        noWin = false;
                    }
                }

                /* Check for a horizontal wins */
                for (i = 0; i < 3; i++)
                {
                    if (gameBoard[i] == gameBoard[i + 1] && gameBoard[i] == gameBoard[i + 1])
                    {
                        noWin = false;
                    }
                }

                /* Check for a diagonal wins */
                for (i = 0; i < 3; i++)
                {
                    if (gameBoard[i] == gameBoard[i + 4] && gameBoard[i] == gameBoard[i + 8])
                    {
                        noWin = false;
                    }
                    else if (gameBoard[i + 2] == gameBoard[i + 4] && gameBoard[i] == gameBoard[i + 6])
                    {
                        noWin = false;
                    }
                }
            }

            return noWin;

        }



    }

}

