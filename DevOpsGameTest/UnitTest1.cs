using DevOpsGame;
using System;
using System.Collections.Generic;
using Xunit;

namespace DevOpsGameTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Win combo, its program constant
            List<int[]> winingCombo = new List<int[]>();
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
            //List of board state which im testing
            List<int> boardState = new List<int>() { 10, 0, 10, 4, 0, 10, 0, 8, 10 };
            string result = Program.CheckForBoardState(boardState, winingCombo);
            Assert.Equal("X", result);
            Assert.NotEqual("O", result);
        }
    }
}
