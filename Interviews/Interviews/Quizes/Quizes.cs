using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Quizes
{
    public class CellCompete
    {
        public static void Run()
        {
            Console.WriteLine("");
            Console.WriteLine(" *(*(*(*(*(*(*(*)()*)*)CellCompete*(*(*(*(*)*)(*)(*()*)(*)(*)(*) ");
            CellCompete cellCompete = new CellCompete();

            int[] sample = new int[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            Console.WriteLine($"Array before change");
            cellCompete.Print(sample);
            Console.WriteLine($"###Calling cellCompete() on array:");
            cellCompete.Print(cellCompete.cellCompete(sample, 1));

            Console.WriteLine($"Result of call to MaxInterest(): {cellCompete.maxInterest()}");

            Console.WriteLine($"Result of call to diagonalDifference(): {cellCompete.diagonalDifference()}");
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
                    oldValue = (int)hashtable[hashedKey];
                    hashtable[hashedKey] = ++oldValue;
                }
                else
                {
                    hashtable.Add(hashedKey, 1);
                }


            }

            int maxInterest = 0;
            int maxValue = 0;
            foreach (DictionaryEntry item in hashtable)
            {
                if ((int)item.Value >= maxValue)
                {
                    maxValue = (int)item.Value;

                }
            }

            foreach (DictionaryEntry item in hashtable)
            {
                if ((int)item.Value >= maxValue)
                    if ((int)item.Key > maxInterest)
                    {
                        maxInterest = (int)item.Key;
                    }
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
                    if (newValue > maxInterest)
                    { maxInterest = newValue; }
                }
                else
                {
                    hash.Add(hashedKey, fw[i]);
                    if (fw[i] > maxInterest)
                    { maxInterest = fw[i]; }
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
            int[][] arr = new int[3][] { new int[] { 11, 2, 4 }, new int[] { 4,5,6}, new int[] { 10,8,-12} };
            int diff = 0; int sum1 = 0; int sum2 = 0; int len = arr.GetLength(0);
            for (int i = 0; i < len; i++) { sum1 += arr[i][i]; }
            for (int j = 0; j < len; j++) { sum2 += arr[len - j - 1][j]; }
            diff = sum1 - sum2;
            return diff >= 0 ? diff : diff * -1;
        }
    }
}

