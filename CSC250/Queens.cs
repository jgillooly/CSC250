using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSC250
{
    public static class Queens
    {
        public static List<int[,]> solutions = new List<int[,]>();
        public static int currentn;

        public static void FindSolutions(int n, bool guardrails = true)
        {
            if (n > 14 && guardrails)
            {
                Console.WriteLine("Nice try chump. Not happening");
            }
            else
            {
                currentn = n;
                int[,] board = new int[n, n];
                Permutation(board, 0);
            }
        }

        public static void Permutation(int[,] board, int row)
        {
            for (int i = 0; i < currentn; i++)
            {
                if (CheckPosition(board, row, i))
                {
                    int[,] newBoard = new int[currentn,currentn];
                    CopyArray(board, ref newBoard);
                    newBoard[row, i] = 1;
                    if (row == currentn - 1)
                    {
                        solutions.Add(newBoard);
                        return;
                    }
                    Permutation(newBoard, row + 1);
                }
            }
            return;
        }

        public static bool CheckPosition(int[,] board, int row, int col) {
            //check if column is free
            for (int i = 0; i < currentn; i++)
            {
                if (board[i, col] == 1) return false;
            }

            //check diagonally left
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1) return false;
            }

            //check diagonally right
            for (int i = row - 1, j = col + 1; i >= 0 && j < currentn; i--, j++)
            {
                if (board[i,j] == 1) return false;
            }

            return true;
        }

        private static void CopyArray(int[,] source, ref int[,] destination) { 
            for(int i = 0;i < currentn;i++)
            {
                for(int j = 0;j < currentn;j++)
                {
                    destination[i,j] = source[i,j];
                }
            }
        }

        public static void PrintBoards(IEnumerable<int[,]> boards, bool verbose = true)
        {
            if (verbose)
            {
                int number = 1;
                foreach (var board in boards)
                {
                    Console.WriteLine("Solution Number " + number++);
                    for (int i = 0; i < currentn; i++)
                    {
                        for (int j = 0; j < currentn; j++)
                        {
                            Console.Write(board[i, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Total Solutions: " + boards.Count());
        }
    }
}
