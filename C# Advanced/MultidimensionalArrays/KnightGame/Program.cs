using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string items = Console.ReadLine();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = items[col];
                }
            }
            int removedKnights = 0;
            while (true)
            {
                int maxAttack=0;
               
                int knightRow = 0;
                int knightCol = 0;
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == '0')
                        {
                            continue;
                        }
                        int currAttacks = 0;

                        //upleft upright

                        if (IsInRange(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                        {
                            currAttacks++;
                        }

                        if (IsInRange(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                        {
                            currAttacks++;
                        }
                        //leftup leftdown

                        if (IsInRange(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                        {
                            currAttacks++;
                        }
                        if (IsInRange(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                        {
                            currAttacks++;
                        }
                        //downleft downright
                        if (IsInRange(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                        {
                            currAttacks++;
                        }
                        if (IsInRange(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                        {
                            currAttacks++;
                        }
                        //rightup rightdown
                        if (IsInRange(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                        {
                            currAttacks++;
                        }
                        if (IsInRange(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                        {
                            currAttacks++;
                        }

                        if (currAttacks>maxAttack)
                        {
                            maxAttack = currAttacks;
                            knightCol = col;
                            knightRow = row;
                        }
                    }
                }

                if (maxAttack>0)
                {
                    removedKnights++;
                    board[knightRow, knightCol] = '0';
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }

        }

        private static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}
