using System;
using System.Collections.Generic;
using System.Linq;

namespace DevOpsGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> playBoard = new List<int> { 1, 2, 3,4,5,6,7,8,9 };
            List<int[]> winingCombo = new List<int[]>();
            SetupWiningCombos(ref winingCombo);
            CreateBoard(playBoard);
            bool gameIsGoing = true;
            int roundCount = 1;
            while(gameIsGoing)
            {
                if (roundCount%2==0)
                {
                    Console.Write($"Igracu O, upisi broj na koji zelis postaviti reprezentirajuci simbol: ");
                }
                else
                {
                    Console.Write($"Igracu X, upisi broj na koji zelis postaviti reprezentirajuci simbol: ");
                }
                int odabir = int.Parse(Console.ReadLine());
                if (odabir<1||odabir>9)
                {
                    Console.WriteLine("Wrong input!");
                }
                else
                {
                    if (roundCount%2==0)
                    {
                        Console.WriteLine($"O goint to {odabir}");
                        WritePlayerInputIntoBoard(odabir, "O", ref playBoard);
                        //Write O on odabir place
                    }
                    else
                    {
                        Console.WriteLine($"X goint to {odabir}");
                        WritePlayerInputIntoBoard(odabir, "X", ref playBoard);
                        //Write X on odabir place
                    }
                    RewriteBoard(playBoard);
                    if (roundCount >= 5)
                    {
                        string status = CheckForBoardState(playBoard,winingCombo);
                        if (status == "X" || status == "O")
                        {
                            Console.WriteLine($"Congratulations player {status} WON!");
                            wouldYouLikeMore(ref gameIsGoing, ref playBoard, ref roundCount);
                        }
                        else if (status == "draw") 
                        {
                            Console.WriteLine("Great game, its DRAW!");
                            wouldYouLikeMore(ref gameIsGoing,ref playBoard,ref roundCount);
                        }
                    }
                    roundCount++;
                }
            }
            Environment.Exit(0);
        }

        private static void wouldYouLikeMore(ref bool gameIsGoing, ref List<int> playBoard, ref int roundCount)
        {
            Console.Write("Would you like to play more?(Y/N)");
            string response = Console.ReadLine();
            if (response == "N")
            {
                gameIsGoing = false;
            }
            else
            {
                playBoard = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                roundCount = 1;
                RewriteBoard(playBoard);
            }
        }

        private static void SetupWiningCombos(ref List<int[]> winingCombo)
        {
            int[] comb1 = new int[3] { 1, 2, 3 };
            int[] comb2 = new int[3] { 4, 5, 6 };
            int[] comb3 = new int[3] { 7, 8, 9 };
            int[] comb4 = new int[3] { 1, 4, 7 };
            int[] comb5 = new int[3] { 2, 5, 8 };
            int[] comb6 = new int[3] { 3, 6, 9 };
            int[] comb7 = new int[3] { 1, 5, 9 };
            int[] comb8 = new int[3] { 3, 5, 7 };
            winingCombo.Add(comb1);
            winingCombo.Add(comb2);
            winingCombo.Add(comb3);
            winingCombo.Add(comb4);
            winingCombo.Add(comb5);
            winingCombo.Add(comb6);
            winingCombo.Add(comb7);
            winingCombo.Add(comb8);
        }

        public static string CheckForBoardState(List<int> playBoard, List<int[]> winingCombo)
        {
            //Check if player won
            //Check if all board peaces are filled, if so its a draw
            //Stop the game if any of above arguments are true
            string status="continue";
            List<int> tempIndexForX = new List<int>();
            List<int> tempIndexForO = new List<int>();
            for (int i = 0; i < playBoard.Count; i++)
            {
                if (playBoard[i] == 0)
                {
                    tempIndexForO.Add(i + 1);
                }
                else if (playBoard[i] == 10) 
                {
                    tempIndexForX.Add(i + 1);
                }
            }
            tempIndexForX.Sort();
            tempIndexForO.Sort();
            if (tempIndexForX.Count >= 3)
            {
                int[] tempArrayX = new int[] { tempIndexForX[tempIndexForX.Count - 3], tempIndexForX[tempIndexForX.Count - 2], tempIndexForX[tempIndexForX.Count - 1] };
                int[] tempArrayX2 = new int[] { tempIndexForX[0], tempIndexForX[1], tempIndexForX[2] };
                foreach (var combo in winingCombo)
                {
                    if(tempArrayX.SequenceEqual(combo)||tempArrayX2.SequenceEqual(combo))
                    {
                        status = "X";
                    }
                }
            }
            if (tempIndexForO.Count >= 3)
            {
                int[] tempArrayO = new int[] { tempIndexForO[tempIndexForO.Count - 3], tempIndexForO[tempIndexForO.Count - 2], tempIndexForO[tempIndexForO.Count - 1] };
                int[] tempArrayO2 = new int[] { tempIndexForO[0], tempIndexForO[1], tempIndexForO[2] };
                foreach (var combo in winingCombo)
                {
                    if (tempArrayO.SequenceEqual(combo) || tempArrayO2.SequenceEqual(combo))
                    {
                        status = "O";
                    }
                }
            }
            if (tempIndexForO.Count+tempIndexForX.Count==9)
            {
                status = "draw";
            }
            return status;
        }

        private static void RewriteBoard(List<int> playBoard)
        {
            Console.Clear();
            Console.WriteLine("Welcome to criss cross!");
            Console.WriteLine();
            for (int i = 1; i <= 9; ++i)
            {
                if (i % 3 != 0)
                {
                    if (playBoard[i - 1]==0)
                    {
                        Console.Write("O");
                    }
                    else if(playBoard[i - 1]==10)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(playBoard[i - 1]);
                    }
                }
                else
                {
                    if (playBoard[i - 1] == 0)
                    {
                        Console.Write("O");
                    }
                    else if (playBoard[i - 1] == 10)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(playBoard[i - 1]);
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void WritePlayerInputIntoBoard(int odabir, string player, ref List<int> playBoard)
        {
            if (player == "O")
            {
                playBoard[odabir - 1] = 0;
            }
            else if (player == "X") 
            {
                playBoard[odabir - 1] = 10;
            }
        }

        private static void CreateBoard(List<int> list)
        {
            Console.WriteLine("Welcome to criss cross!");
            Console.WriteLine();
            for (int i = 1; i <= 9; ++i)
            {
                if (i%3!=0)
                {
                    Console.Write(list[i-1]);
                }
                else
                {
                    Console.Write(list[i-1]);
                    Console.WriteLine();
                }
            }
        }
    }
}
