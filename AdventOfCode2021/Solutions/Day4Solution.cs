using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Solutions
{
    public class Day4Solution : ISolution
    {
        public void PrintSolution(string input)
        {
            var splitted = input.Split("\r\n");
            var drawnNumbers = splitted[0].Split(',').Select(w => Convert.ToInt32(w)).ToList();

            var boardLines = splitted.Skip(1).Where(w => w != "").Select(w => w.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => Convert.ToInt32(n))).ToArray();
            var board = new int[5, 5];
            var allBoards = new List<int[,]>();

            var winners = new List<int>();

            for (int i = 0; i < boardLines.Length; i++)
            {
                var line = boardLines[i].ToArray();
                for (int j = 0; j < line.Count(); j++)
                {
                    board[i % 5, j] = line[j];
                }
                if ((i + 1) % 5 == 0)
                {
                    allBoards.Add(board);
                    board = new int[5, 5];
                }
            }

            for (int i = 0; i < drawnNumbers.Count; i++)
            {
                for (int j = 0; j < allBoards.Count; j++)
                {
                    if (WinCondition(allBoards[j], drawnNumbers[i]))
                    {
                        winners.Add((GetBoardRestSum(allBoards[j]) * drawnNumbers[i]));
                        allBoards.RemoveAt(j);
                        i = 0;
                        j = 0;
                    }
                }
            }

            Console.WriteLine($"{winners[0]} and {winners[winners.Count -1]}");
        }

        private bool WinCondition(int[,] board, int number)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == number)
                    {
                        board[i, j] = -1;
                        if (GetRow(board, i).Sum() == -5)
                        {
                            return true;
                        }
                        if (GetColumn(board, j).Sum() == -5)
                        {
                            return true;
                        }

                    }
                }
            }

            return false;
        }

        private int GetBoardRestSum(int[,] board)
        {
            var sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] != -1)
                    {
                        sum += board[i, j];
                    }
                }
            }

            return sum;
        }
        private int[] GetColumn(int[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        private int[] GetRow(int[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}
