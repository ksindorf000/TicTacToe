﻿using System;
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

            /** Get user names, assign to X or O **/
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

            /** Play Game **/
            while (winner == 0)
            {
                DisplayBoard();
                winner = PlayerTurn();
            }

            if (winner != 3)
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

        /** Method for displaying Game Board **/
        public static void DisplayBoard()
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
        public static int PlayerTurn()
        {
            int userMove;
            bool valid;

            turnCount++;

            Console.WriteLine($"{player}, where would you like to move?");
            userMove = int.Parse(Console.ReadLine());

            valid = Validation(userMove);
            Console.WriteLine(gameBoard[2] + gameBoard[4] + gameBoard[6]);
            
            winner = WinConditions();

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

            return winner;

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
        public static int WinConditions()
        {
            int i = 0;
            bool keepChecking = true;

            while (keepChecking)
            {
                /* Check for vertical wins */

                if (gameBoard[i] == gameBoard[i + 3] && gameBoard[i] == gameBoard[i + 6])
                {
                    winner = player == user1 ? 1 : 2;
                    keepChecking = false;
                }

                /* Check for horizontal wins */

                else if (gameBoard[i] == gameBoard[i + 1] && gameBoard[i] == gameBoard[i + 1])
                {
                    winner = player == user1 ? 1 : 2;
                    keepChecking = false;
                }

                /* Check for diagonal wins */

                else if (gameBoard[i] == gameBoard[i + 4] && gameBoard[i] == gameBoard[i + 8])
                {
                    winner = player == user1 ? 1 : 2;
                    keepChecking = false;
                }
                else if (gameBoard[i + 2] == gameBoard[i + 4] && gameBoard[i] == gameBoard[i + 6])
                {
                    winner = player == user1 ? 1 : 2;
                    keepChecking = false;
                }

                /* Check for a tie */
                else if (turnCount == 9)
                {
                    for (i = 0; i < 9; i++)
                    {
                        if (gameBoard[i] == "X" || gameBoard[i] == "O")
                        {
                            winner = 3;
                            keepChecking = false;
                        }
                        else
                        {
                            winner = 0;
                            keepChecking = false;
                        }
                    }
                }

                keepChecking = false;

            }

            return winner;

        }



    }

}

