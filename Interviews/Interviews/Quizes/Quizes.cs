using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interviews.Quizes.Randos
{
    public class Quizes
    {
        public static void Run()
        {
            Console.WriteLine("");
            Console.WriteLine(" *(*(*(*(*(*(*(*)()*)*)Quizes*(*(*(*(*)*)(*)(*()*)(*)(*)(*) ");
            Quizes quizes = new Quizes();

            int[] sample = new int[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            Console.WriteLine($"Array before change");
            quizes.Print(sample);
            Console.WriteLine($"###Calling cellCompete() on array:");
            quizes.Print(quizes.cellCompete(sample, 1));

            //Console.WriteLine($"Result of call to MaxInterest(): {quizes.maxInterest()}");

            Console.WriteLine($"Result of call to diagonalDifference(): {quizes.diagonalDifference()}");

            int boardSize = 4; int numberOfObstacles = 2; int queenRow = 2; int queenColumn = 3;
            int[][] obstaclesArray = new int[2][] { new int[] { 2, 1 }, new int[] { 3, 3 } };
            //quizes.PrintBoardPositions(quizes.QueensAttack(boardSize, numberOfObstacles, queenRow, queenColumn, obstaclesArray));
            //Console.WriteLine($"Result of call to QueensAttack(boardsize:{boardSize}, queenrow:{queenRow}, queenColumn:{queenColumn})");
            quizes.PrintBoardPositions(quizes.QueensAttack2(boardSize, numberOfObstacles, queenRow, queenColumn, obstaclesArray));
            Console.WriteLine($"Result of call to QueensAttack2(boardsize:{boardSize}, queenrow:{queenRow}, queenColumn:{queenColumn})");

            boardSize = 7; numberOfObstacles = 5; queenRow = 4; queenColumn = 3;
            obstaclesArray = new int[6][] {
                  new int[] { 2, 1 }, new int[] { 4, 2 },
                  new int[] { 5, 2 }, new int[] { 5, 4 },
              new int[] { 2, 5 }, new int[] { 6, 5 } };
            //quizes.PrintBoardPositions(quizes.QueensAttack(boardSize, numberOfObstacles, queenRow, queenColumn, obstaclesArray));
            //Console.WriteLine($"Result of call to QueensAttack(boardsize:{boardSize}, queenrow:{queenRow}, queenColumn:{queenColumn})");
            quizes.PrintBoardPositions(quizes.QueensAttack2(boardSize, numberOfObstacles, queenRow, queenColumn, obstaclesArray));
            Console.WriteLine($"Result of call to QueensAttack2(boardsize:{boardSize}, queenrow:{queenRow}, queenColumn:{queenColumn})");

            //obstaclesArray = new int[3][] { new int[] { 3,2}, new int[] { 2, 3 }, new int[] { 5,2 } };
            //Console.WriteLine($"Result of call to QueensAttack(boardsize:{boardSize}, queenrow:{queenRow}, queenColumn:{queenColumn})");
            //quizes.PrintBoardPositions(quizes.QueensAttack(boardSize, numberOfObstacles, queenRow, queenColumn, obstaclesArray));

            Console.WriteLine($"Result of call to minimumTime({quizes.minimumTime(4, new int[] { 1, 2, 5, 10, 35, 89 })})");

            Console.WriteLine($"Result of call to find phone bill");
            string s = "00:01:07,400-234-090@00:05:07,400-234-091@00:01:07,400-234-092@00:10:07,400-234-090@00:10:07,400-234-093";
            s = s.Replace("@", "@" + System.Environment.NewLine);
            Console.WriteLine(quizes.CellPhoneBill(s));

            Console.WriteLine($"Result of call to PowersOf2");
            PowersOf2.Run();
            Console.WriteLine($"Result of call to ShowGalaxies");
            GalaxyClass.ShowGalaxies();
            Console.WriteLine($"Result of call to StackOfPlates");
            StackOfPlatesClass.Run();
        }

        public void Print(int[] n)
        {
            Console.WriteLine($"Print array:");

            for (int i = 0; i < n.Length; i++)
            {
                Console.Write($"{n[i]},");
            }
            Console.WriteLine($"");
        }

        public void PrintBoardPositions(List<Tuple<int, int>> n)
        {
            Console.WriteLine($"Print Board Positions:");
            Console.WriteLine($"Number of Board Positions:{n.Count}");
            foreach (Tuple<int, int> t in n)
            { Console.WriteLine($"{t.Item1},{t.Item2}"); }
            Console.WriteLine($"");
        }

        //Amazon question: An array of 1s and 0s that changes state everyday is given. 
        // The logic for switching the state is, if both neighbouring elements of the current element are equal, 
        // then the element is going to be set to inactive, if the neighbours are different, the element will be set to active.
        // For the first and last element assume the bracket elements are equal to 0.
        public int[] cellCompete(int[] states, int days)
        {
            int[] currentStates = new int[states.Length];
            states.CopyTo(currentStates, 0);
            int count = 0;
            int len = states.Length;
            while (count < days)
            {
                count++;
                for (int i = 0; i < len; i++)
                {
                    if (i == 0)
                    {
                        if (states[i + 1] == 0) { currentStates[i] = 0; }
                        else { currentStates[i] = 1; }

                    }
                    else if (i + 1 == len)
                    {
                        if (states[i - 1] == 0) { currentStates[i] = 0; }
                        else { currentStates[i] = 1; }
                    }
                    else
                    {
                        if (states[i - 1] == states[i + 1]) { currentStates[i] = 0; }
                        else { currentStates[i] = 1; }
                    }
                }
            }

            return currentStates;
        }

        // HackerRank question: Graph depicting friends and their number of shares interests are specified.
        // Aim is to find the max interest node.
        public int maxInterest()
        {
            //List<int> friendsFrom = new List<int>() { 1, 1, 2, 2, 2 };
            //List<int> friendsTo = new List<int>() { 2, 2, 3, 3, 4 };
            //List<int> friendsWeight = new List<int>() { 2, 3, 1, 3, 32 };

            List<int> friendsFrom = new List<int>() { 1, 1, 2 };
            List<int> friendsTo = new List<int>() { 3, 3, 3 };
            List<int> friendsWeight = new List<int>() { 1, 2, 2 };
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < friendsFrom.Count && i < friendsTo.Count && i < friendsWeight.Count; i++)
            {
                int hashedKey = (friendsFrom[i] * friendsTo[i]).GetHashCode();
                int oldValue = 0;
                if (hashtable.ContainsKey(hashedKey))
                {
                    oldValue = (int)hashtable[hashedKey]; hashtable[hashedKey] = ++oldValue;
                }
                else { hashtable.Add(hashedKey, 1); }
            }

            int maxInterest = 0; int maxValue = 0;
            foreach (DictionaryEntry item in hashtable)
            {
                if ((int)item.Value >= maxValue) { maxValue = (int)item.Value; }
            }

            foreach (DictionaryEntry item in hashtable)
            {
                if ((int)item.Value >= maxValue)
                { if ((int)item.Key > maxInterest) { maxInterest = (int)item.Key; } }
            }

            return maxInterest;
        }

        public int maxInterest2()
        {
            int maxInterest = 0;
            List<int> ff = new List<int>() { 1, 1, 2, 2, 2 };
            List<int> ft = new List<int>() { 2, 2, 3, 3, 4 };
            List<int> fw = new List<int>() { 2, 3, 1, 3, 32 };
            Hashtable hash = new Hashtable();
            for (int i = 0; i < ff.Count; i++)
            {
                int hashedKey = (ff[i] * ft[i]).GetHashCode();
                int oldValue = 0; int newValue = 0;
                if (hash.ContainsKey(hashedKey))
                {
                    oldValue = (int)hash[hashedKey];
                    newValue = oldValue * fw[i];
                    hash[hashedKey] = newValue;
                    if (newValue > maxInterest) { maxInterest = newValue; }
                }
                else
                {
                    hash.Add(hashedKey, fw[i]);
                    if (fw[i] > maxInterest) { maxInterest = fw[i]; }
                }
            }

            return maxInterest;
        }

        public int maxInterest3()
        {

            List<int> friendsFrom = new List<int>() { 1, 1, 2, 2, 2 };
            List<int> friendsTo = new List<int>() { 2, 2, 3, 3, 4 };
            List<int> friendsWeight = new List<int>() { 2, 3, 1, 3, 32 };
            int maxInterest = 0;
            int maxInterestCount = 0;
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < friendsFrom.Count && i < friendsTo.Count && i < friendsWeight.Count; i++)
            {
                int hashedKey = (friendsFrom[i] * friendsTo[i]).GetHashCode();
                int oldValue = 0;
                //int newValue = 0;
                if (hashtable.ContainsKey(hashedKey))
                {
                    oldValue = (int)hashtable[hashedKey];
                    //newValue = oldValue * friendsWeight[i];
                    //hashtable[hashedKey] = newValue;
                    hashtable[hashedKey] = ++oldValue;
                    // if(oldValue > maxInterest)
                    //{
                    //maxInterest = oldValue;
                    //maxInterest=hashedKey;
                    //}
                }
                else
                {
                    //hashtable.Add(hashedKey, friendsWeight[i]);
                    hashtable.Add(hashedKey, 1);
                    //if(friendsWeight[i] > maxInterest)
                    //{
                    //    maxInterest = friendsWeight[i];
                    //}
                }


            }

            int maxValue = 0;
            foreach (DictionaryEntry item in hashtable)
            {
                if ((int)item.Value >= maxValue && (int)item.Key > maxInterest)
                {
                    maxInterest = (int)item.Key;
                    maxValue = (int)item.Value;
                }
            }
            return maxInterest;

        }

        // HackerRank Question: Given a square array matric,
        // sum up the values in the two diagonal paths and find their difference.
        public int diagonalDifference()
        {
            int[][] arr = new int[3][] { new int[] { 11, 2, 4 }, new int[] { 4, 5, 6 }, new int[] { 10, 8, -12 } };
            int diff = 0; int sum1 = 0; int sum2 = 0; int len = arr.GetLength(0);
            for (int i = 0; i < len; i++) { sum1 += arr[i][i]; }
            for (int j = 0; j < len; j++) { sum2 += arr[len - j - 1][j]; }
            diff = sum1 - sum2;
            return diff >= 0 ? diff : diff * -1;
        }

        // HackerRank question: Given a chessboard, the queen pieces position and any obstacles in the path, calculate 
        // how many positions the queen piece can move to.
        public List<Tuple<int, int>> QueensAttack(int boardSize, int numberOfObstacles, int queenRow, int queenColumn, int[][] obstacles)
        {
            int sumOfAttackableSpotsVertical = 0;
            int sumOfAttackableSpotsHorizontal = 0;
            int sumOfAttackableSpotsRightToLeftDiagonal = 0;
            int sumOfAttackableSpotsLeftToRightDiagonal = 0;
            List<Tuple<int, int>> attackableSpots = new List<Tuple<int, int>>();
            List<Tuple<int, int>> attackableSpots1 = new List<Tuple<int, int>>();
            List<Tuple<int, int>> attackableSpots2 = new List<Tuple<int, int>>();
            List<Tuple<int, int>> attackableSpots3 = new List<Tuple<int, int>>();
            List<Tuple<int, int>> attackableSpots4 = new List<Tuple<int, int>>();

            //Calculate Vertical attackable spots
            for (int i = 1; i <= boardSize; i++)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, queenColumn });
                if (isSpotAnObstacle == false && (queenRow != i))
                {
                    sumOfAttackableSpotsVertical++;
                    attackableSpots1.Add(new Tuple<int, int>(i, queenColumn));
                }
                else { if (queenColumn > i) { sumOfAttackableSpotsVertical = 0; attackableSpots1 = new List<Tuple<int, int>>(); } }
                if (isSpotAnObstacle && queenRow < i) { break; }
            }

            //Calculate Horizonatal attackable spots
            for (int i = 1; i <= boardSize; i++)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { queenRow, i });
                if (isSpotAnObstacle == false && (queenColumn != i))
                {
                    sumOfAttackableSpotsHorizontal++;
                    attackableSpots2.Add(new Tuple<int, int>(queenRow, i));
                }
                else { if (queenRow > i) { sumOfAttackableSpotsLeftToRightDiagonal = 0; attackableSpots2 = new List<Tuple<int, int>>(); } }
                if (isSpotAnObstacle && queenColumn < i) { break; }
            }

            //Calculate RightToLeft attackable spots
            if (queenRow <= queenColumn)
            {
                int startingColumn = queenColumn + queenRow - 1;
                for (int i = 1, j = startingColumn; i <= boardSize && j > 0; i++, j--)
                {
                    bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
                    if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
                    {
                        sumOfAttackableSpotsRightToLeftDiagonal++;
                        attackableSpots3.Add(new Tuple<int, int>(i, j));
                    }
                    else { if (queenColumn > i) { sumOfAttackableSpotsRightToLeftDiagonal = 0; attackableSpots3 = new List<Tuple<int, int>>(); } }
                    if (isSpotAnObstacle && queenColumn > j) { break; }
                }
            }
            else
            {
                int startingRow = queenRow - (queenColumn - 1);
                for (int i = startingRow, j = 1; i <= boardSize && j < boardSize; i++, j++)
                {
                    bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
                    if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
                    {
                        sumOfAttackableSpotsRightToLeftDiagonal++;
                        attackableSpots3.Add(new Tuple<int, int>(i, j));
                    }
                    else { if (queenColumn > i) { sumOfAttackableSpotsRightToLeftDiagonal = 0; attackableSpots3 = new List<Tuple<int, int>>(); } }
                    if (isSpotAnObstacle && queenColumn > j) { break; }
                }
            }

            //Calculate LeftToRight attackable spots
            if (queenRow >= queenColumn)
            {
                int startingRow = queenRow - queenColumn + 1;
                for (int i = startingRow, j = 1; i <= boardSize && j <= boardSize; i++, j++)
                {
                    bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
                    if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
                    {
                        sumOfAttackableSpotsLeftToRightDiagonal++;
                        attackableSpots4.Add(new Tuple<int, int>(i, j));
                    }
                    else { if (queenColumn > i) { sumOfAttackableSpotsLeftToRightDiagonal = 0; attackableSpots4 = new List<Tuple<int, int>>(); } }
                    if (isSpotAnObstacle && queenRow < i) { break; }
                }
            }
            else
            {
                int startingColumn = queenColumn - queenRow + 1;
                for (int i = 1, j = startingColumn; i <= boardSize && j <= boardSize; i++, j++)
                {
                    bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
                    if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
                    {
                        sumOfAttackableSpotsLeftToRightDiagonal++;
                        attackableSpots4.Add(new Tuple<int, int>(i, j));
                    }
                    else { if (queenColumn > i) { sumOfAttackableSpotsLeftToRightDiagonal = 0; attackableSpots4 = new List<Tuple<int, int>>(); } }
                    if (isSpotAnObstacle && queenRow < i) { break; }
                }
            }

            ////Calculate LeftToRight attackable spots
            //if (queenRow <= queenColumn)
            //{
            //    int startingColumn = queenColumn + queenRow - 1;
            //    for (int i = 1, j = startingColumn; i < boardSize && j > 0; i++, j--)
            //    {
            //        bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
            //        if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
            //        {
            //            sumOfAttackableSpots++;
            //            attackableSpots.Add(new Tuple<int, int>(i, j));
            //        }
            //        if (isSpotAnObstacle && queenColumn < i) { break; }
            //    }
            //}
            //else
            //{
            //    int startingRow = queenRow - (queenColumn - 1);
            //    for (int i = startingRow, j = 1; i < boardSize && j < boardSize; i++, j++)
            //    {
            //        bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
            //        if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
            //        {
            //            sumOfAttackableSpots++;
            //            attackableSpots.Add(new Tuple<int, int>(i, j));
            //        }
            //        if (isSpotAnObstacle && queenColumn < i) { break; }
            //    }
            //}

            ////Calculate RightToLeft attackable spots
            //if (queenRow < queenColumn)
            //{
            //    int startingRow = queenColumn - 1 + queenRow;
            //    for (int i = startingRow, j = 1; i < boardSize && j < boardSize; i++, j++)
            //    {
            //        bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
            //        if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
            //        {
            //            sumOfAttackableSpots++;
            //            attackableSpots.Add(new Tuple<int, int>(i, j));
            //        }
            //        if (isSpotAnObstacle && queenRow > j) { break; }
            //    }
            //}
            //else
            //{
            //    int startingColumn = queenRow + queenColumn - boardSize;
            //    for (int i = startingColumn, j = boardSize; i < boardSize && j < boardSize; i++, j--)
            //    {
            //        bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
            //        if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
            //        {
            //            sumOfAttackableSpots++;
            //            attackableSpots.Add(new Tuple<int, int>(i, j));
            //        }
            //        if (isSpotAnObstacle && queenRow > j) { break; }
            //    }
            //}
            attackableSpots.AddRange(attackableSpots1);
            attackableSpots.AddRange(attackableSpots2);
            attackableSpots.AddRange(attackableSpots3);
            attackableSpots.AddRange(attackableSpots4);
            int sumOfAttackableSpots =
                sumOfAttackableSpotsVertical + sumOfAttackableSpotsHorizontal +
                sumOfAttackableSpotsLeftToRightDiagonal + sumOfAttackableSpotsRightToLeftDiagonal;
            return attackableSpots;
        }

        public List<Tuple<int, int>> QueensAttack2(int boardSize, int numberOfObstacles, int queenRow, int queenColumn, int[][] obstacles)
        {
            int sumOfAttackableSpotsVertical = 0;
            int sumOfAttackableSpotsHorizontal = 0;
            int sumOfAttackableSpotsRightToLeftDiagonal = 0;
            int sumOfAttackableSpotsLeftToRightDiagonal = 0;
            List<Tuple<int, int>> attackableSpots = new List<Tuple<int, int>>();
            List<Tuple<int, int>> attackableSpots1 = new List<Tuple<int, int>>();
            List<Tuple<int, int>> attackableSpots2 = new List<Tuple<int, int>>();
            List<Tuple<int, int>> attackableSpots3 = new List<Tuple<int, int>>();
            List<Tuple<int, int>> attackableSpots4 = new List<Tuple<int, int>>();

            //Calculate Vertical attackable spots
            for (int i = queenRow - 1; i >= 1; i--)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, queenColumn });
                if (isSpotAnObstacle == false && (queenRow != i))
                {
                    sumOfAttackableSpotsVertical++;
                    attackableSpots1.Add(new Tuple<int, int>(i, queenColumn));
                }
                else { break; }
            }
            for (int i = queenRow + 1; i <= boardSize; i++)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, queenColumn });
                if (isSpotAnObstacle == false && (queenRow != i))
                {
                    sumOfAttackableSpotsVertical++;
                    attackableSpots1.Add(new Tuple<int, int>(i, queenColumn));
                }
                else { break; }
            }

            //Calculate Horizonatal attackable spots
            for (int i = queenColumn - 1; i >= 1; i--)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { queenRow, i });
                if (isSpotAnObstacle == false && (queenColumn != i))
                {
                    sumOfAttackableSpotsHorizontal++;
                    attackableSpots2.Add(new Tuple<int, int>(queenRow, i));
                }
                else { break; }
            }
            for (int i = queenColumn + 1; i <= boardSize; i++)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { queenRow, i });
                if (isSpotAnObstacle == false && (queenColumn != i))
                {
                    sumOfAttackableSpotsHorizontal++;
                    attackableSpots2.Add(new Tuple<int, int>(queenRow, i));
                }
                else { break; }
            }

            //Calculate RightToLeft attackable spots
            for (int i = queenRow - 1, j = queenColumn - 1; i >= 1 && j >= 1; i--, j--)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
                if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
                {
                    sumOfAttackableSpotsRightToLeftDiagonal++;
                    attackableSpots3.Add(new Tuple<int, int>(i, j));
                }
                else { break; }
            }
            for (int i = queenRow + 1, j = queenColumn + 1; i <= boardSize && j <= boardSize; i++, j++)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
                if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
                {
                    sumOfAttackableSpotsRightToLeftDiagonal++;
                    attackableSpots3.Add(new Tuple<int, int>(i, j));
                }
                else { break; }
            }

            //Calculate LeftToRight attackable spots
            for (int i = queenRow + 1, j = queenColumn - 1; i <= boardSize && j >= 1; i++, j--)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
                if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
                {
                    sumOfAttackableSpotsLeftToRightDiagonal++;
                    attackableSpots4.Add(new Tuple<int, int>(i, j));
                }
                else { break; }
            }
            for (int i = queenRow - 1, j = queenColumn + 1; i >= 1 && j <= boardSize; i--, j++)
            {
                bool isSpotAnObstacle = this.SpotIsAnObstacle(obstacles, new int[] { i, j });
                if (isSpotAnObstacle == false && (queenRow != i && queenColumn != j))
                {
                    sumOfAttackableSpotsLeftToRightDiagonal++;
                    attackableSpots4.Add(new Tuple<int, int>(i, j));
                }
                else { break; }
            }

            attackableSpots.AddRange(attackableSpots1);
            attackableSpots.AddRange(attackableSpots2);
            attackableSpots.AddRange(attackableSpots3);
            attackableSpots.AddRange(attackableSpots4);
            int sumOfAttackableSpots =
                sumOfAttackableSpotsVertical + sumOfAttackableSpotsHorizontal +
                sumOfAttackableSpotsLeftToRightDiagonal + sumOfAttackableSpotsRightToLeftDiagonal;
            return attackableSpots;
        }


        private bool SpotIsAnObstacle(int[][] array, int[] value)
        {
            foreach (int[] a in array)
            { if (a[0].Equals(value[0]) && a[1].Equals(value[1])) { return true; }; }
            return false;
        }

        public int minimumTime(int numOfParts, int[] parts)
        {
            List<int> partsList = new List<int>();
            //Sort the array first
            for (int i = 0; i < parts.Length; i++)
            {
                int minIndex = i;
                for (int j = i; j < parts.Length; j++)
                {
                    if (parts[minIndex] > parts[j]) { minIndex = j; }
                }

                if (minIndex != i)
                {
                    int temp = parts[i];
                    parts[i] = parts[minIndex]; parts[minIndex] = temp;
                }
                partsList.Add(parts[i]);
            }
            int sum = 0;
            while (partsList.Count > 2)
            {
                sum = partsList[0];
                List<int> joinedPartsList = new List<int>();
                for (int i = 1; i < partsList.Count; i++)
                {
                    sum += partsList[i];
                    joinedPartsList.Add(sum);
                }
                partsList = joinedPartsList;
            }
            return sum;
            //Then sum up

            // WRITE YOUR CODE HERE
        }


        //BlueWater Consulting group. Calculate phone bill. less than 5 mins>> 3 cents per sec. 5Mins and above>> 150 per minute. Most called phone, free.
        public int CellPhoneBill(string s)
        {
            string[] rawCalls = s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<CallDetails> callDetails = new List<CallDetails>();
            foreach (string call in rawCalls)
            {
                string[] rawCallDetail = call.Split(','); 
                TimeSpan callDuration;
                if (TimeSpan.TryParse(rawCallDetail[0], out callDuration))
                {
                    callDetails.Add(new CallDetails(callDuration, rawCallDetail[1]));
                }
            }

            string freeCallPhoneNumber = this.FindFreeCallPhoneNumber(callDetails);


            int totalCallExpense = 0;
            foreach (CallDetails callDetail in callDetails)
            {
                if (!callDetail.phoneNumber.Equals(freeCallPhoneNumber))
                {
                    totalCallExpense += this.CalculateCallBilling(callDetail.callDuration);
                }
            }

            return totalCallExpense;
        }

        public int CalculateCallBilling(TimeSpan callDuration)
        {
            int callExpense = 0;

            if (callDuration.TotalMinutes >= 5) { callExpense += (int)callDuration.TotalMinutes * 150; if (callDuration.Seconds > 0) { callExpense += 150; } }
            else { callExpense += (int)callDuration.TotalSeconds * 3; }

            return callExpense;

        }

        public string FindFreeCallPhoneNumber(List<CallDetails> calls)
        {
            string freeCallNumber = string.Empty;
            Dictionary<string, TimeSpan> callDetails = new Dictionary<string, TimeSpan>();
            foreach (CallDetails call in calls)
            {
                if (callDetails.ContainsKey(call.phoneNumber))
                { callDetails[call.phoneNumber] = callDetails[call.phoneNumber] + call.callDuration; }
                else
                { callDetails.Add(call.phoneNumber, call.callDuration); }


                TimeSpan maxDuration = new TimeSpan(0);
                foreach (KeyValuePair<string, TimeSpan> kvp in callDetails)
                {
                    if (kvp.Value > maxDuration) { maxDuration = kvp.Value; freeCallNumber = kvp.Key; }
                }
            }

            return freeCallNumber;
        }
    }

    public class CallDetails
    {
        public TimeSpan callDuration;
        public string phoneNumber;
        public CallDetails(TimeSpan duration, string number)
        {
            this.callDuration = duration;
            this.phoneNumber = number;
        }
    }

    #region StackOfPlates
    public static class StackOfPlatesClass
    {
        public static void Run()
        {
            StackOfPlates stack = new StackOfPlates();
            stack.AddPlates(1);
            stack.AddPlates(3);
            stack.AddPlates(5);
            stack.AddPlates(7);
            stack.AddPlates(4);

            //stack.Print("original Stack");
            StackOfPlates newStack = stack.Split(2);
            newStack.Print("New Stack");
            stack.Print("Old Stack");
        }
    }

    public class StackOfPlates
    {
        Stack<int> plates;

        public StackOfPlates()
        {
            plates = new Stack<int>();
        }

        public void AddPlates(int p)
        {
            List<int> tempPlates = new List<int>();
            while (plates.Count > 0 && plates.Peek() > p)
            {
                tempPlates.Add(plates.Pop());
            }

            plates.Push(p);
            for (int i = 0; i < tempPlates.Count; i++)
            {
                plates.Push(tempPlates[tempPlates.Count - 1 - i]);
            }

        }

        public StackOfPlates Split(int stackSize)
        {
            StackOfPlates newPlates = new StackOfPlates();

            if (stackSize > plates.Count)
            {
                return newPlates;
            }

            int reminingPlatesCountSize = plates.Count - stackSize;
            int[] tempPlates = new int[reminingPlatesCountSize];
            int[] tempPlates2 = new int[stackSize];
            for (int i = 0; i < reminingPlatesCountSize; i++)
            {
                tempPlates[i] = plates.Pop();
            }
            Array.Reverse(tempPlates);

            for (int i = 0; i < stackSize; i++)
            {
                tempPlates2[i] = plates.Pop();
            }
            Array.Reverse(tempPlates2);


            foreach (int p in tempPlates2)
            {
                newPlates.AddPlates(p);
            }
            foreach (int p in tempPlates)
            {
                plates.Push(p);
            }
            return newPlates;
        }



        public void Print(string name)
        {
            Console.WriteLine($"##########PRINT PLATES:{name} ################");
            Stack<int> tempPlates = plates;
            while (tempPlates.Count > 0)
            {
                Console.WriteLine(tempPlates.Pop());
            }
        }

    }
    #endregion StackOfPlates

    # region PowersOf2
    public class PowersOf2
    {
        public static void Run()
        {
            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
                //return new List<int> { result };
            }
            // return new List<int> { 1 };
        }

        // Output: 2 4 8 16 32 64 128 256
    }
    #endregion PowersOf2

    #region Galaxies
    public static class GalaxyClass
    {
        public static void ShowGalaxies()
        {
            var theGalaxies = new Galaxies();
            Stopwatch s = new Stopwatch();
            s.Start();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
            s.Stop();
            Console.WriteLine(s.Elapsed);
            Stopwatch s2 = new Stopwatch();
            s2.Start();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy2)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
            s2.Stop();
            Console.WriteLine(s2.Elapsed);
        }

        public class Galaxies
        {

            public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
            {
                get
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }
            public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy2
            {
                get
                {
                    IEnumerable<Galaxy> galaxies = new List<Galaxy> {
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 },
                    new Galaxy { Name = "Tadpole", MegaLightYears = 400 },
                    new Galaxy { Name = "Pinwheel", MegaLightYears = 25 },
                     new Galaxy { Name = "Milky Way", MegaLightYears = 0 },
                     new Galaxy { Name = "Andromeda", MegaLightYears = 3 }
                    };
                    return galaxies;
                }
            }

        }

        public class Galaxy
        {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }
    }
    #endregion Galaxies


}

