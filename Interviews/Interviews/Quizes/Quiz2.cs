using MultiValueDictionaryChallenge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Xml;

namespace Interviews.Quizes
{

    public class Quiz2
    {

        public class MinimalHeaviestSet
        {
            /*Given an array of integers, find the minimum number of values needed from this array whose sum is larger than
             * the sum of the rest of the integers in the array.
             * Complete the 'minimalHeaviestSetA' function below.
             *
             * The function is expected to return an INTEGER_ARRAY.
             * The function accepts INTEGER_ARRAY arr as parameter.
             */

            public static List<int> minimalHeaviestSetA(List<int> arr)
            {
                arr = sortArray(arr);
                int halfSum = Quiz2.MinimalHeaviestSet.halfSum(arr);
                List<int> arr2 = new List<int>();
                int arr2Sum = 0;
                int arr2StartIndex = arr.Count - 1;
                while (halfSum > arr2Sum)
                {
                    arr2 = new List<int>();
                    for (int i = arr2StartIndex; i < arr.Count; i++)
                    {
                        arr2.Add(arr[i]);
                    }
                    arr2Sum = arr2.Aggregate((r, c) => r + c);
                    arr2StartIndex--;
                }

                return arr2;
            }

            public static int halfSum(List<int> arr)
            {
                return arr.Aggregate((result, next) => result + next) / 2;
            }

            public static List<int> sortArray(List<int> arr)
            {
                int currentLastIndex = arr.Count - 1;

                while (currentLastIndex > 0)
                {
                    int maxIndex = findMaxIndex(arr, currentLastIndex);
                    arr = swap(arr, maxIndex, currentLastIndex);
                    //Print(arr, $"SortArray {currentLastIndex}");
                    currentLastIndex--;
                }

                Print(arr, $"SortArray {currentLastIndex}");
                return arr;
            }

            public static int findMaxIndex(List<int> arr, int currentLastIndex)
            {
                int maxIndex = 0;
                for (int i = 0; i <= currentLastIndex; i++)
                {
                    if (arr[i] > arr[maxIndex]) { maxIndex = i; }
                }
                return maxIndex;
            }

            public static List<int> swap(List<int> arr, int i, int j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                return arr;
            }

            public static void Print(List<int> arr, string caller)
            {
                arr.ForEach((a) => Console.Write(a + ", "));
                Console.WriteLine($"Calling from {caller}");
            }
            public static void Run()
            {
                List<int> arr = new List<int>() { 4, 12, 3, 5, 1, 6 };
                List<int> result = Quiz2.MinimalHeaviestSet.minimalHeaviestSetA(arr);
                Print(result, "Main Run call");
            }
        }

        public class AppendAndDelete
        {

            public static void Run()
            {
                string s = "HackerHappy";
                string t = "HackerRank";
                string result = Quiz2.AppendAndDelete.appendAndDelete(s, t, 9);
                Console.WriteLine("Append and Delete success>>" + result);
            }

            /*Given two strings, replace the first string with characters that are in the 2nd string but not in the first.
             * Deletion can be done one character at a time starting from the last character and each char delete counts as one step.
             * Each append action counts as one step.
             * The total number of steps should be less than or equal to? the passed in k.
             * Delete on an empty string will count as one step.
             * */
            private static string appendAndDelete(string s, string t, int k)
            {
                bool yes = false;
                int totalActionCount = 0;
                int matchingCount = 0;

                if (k > s.Length + t.Length) { return "Yes"; }
                if (s.Equals(t)) { return "Yes"; }

                int i;
                for (i = 0; i < s.Length && i < t.Length; i++)
                {
                    if (s[i] != t[i]) { break; }
                    else { matchingCount++; }
                }
                //Additional delete action count
                totalActionCount += s.Length - i;
                //Additional append action count
                totalActionCount += t.Length - matchingCount;

                //Console.WriteLine("Count" + totalActionCount);
                //Console.WriteLine("MatchingCount" + matchingCount);
                if (totalActionCount > k || (matchingCount > 0 && s.Length > matchingCount + k)) { yes = false; }
                else { yes = true; }
                if (yes) return "Yes";
                return "No";
            }
        }

        public class MalwareAnalysis
        {

            /*Write a piece of malware code that accepts an integer array and has a sliding window over the array of numbers
             If the number 3 spots behind or 4 spots in front of the the sliding window index is larger, then replace that number with 0
            If the sliding window index is near the start or end of the array and the the spots in question are out of the index, do not take action.
            Find all the qualifying positions and then set them to 0 as a final step.*/
            public static int[] Simulate(int[] entries)
            {
                List<int> replaceIndexes = new List<int>();
                for (int i = 0; i < entries.Length; i++)
                {
                    if (i - 3 > 0 && entries[i - 3] > entries[i]) { replaceIndexes.Add(i - 3); }
                    if (i + 4 < entries.Length && entries[i + 4] > entries[i]) { replaceIndexes.Add(i + 4); }

                }

                for (int i = 0; i < entries.Length; i++)
                {
                    if (replaceIndexes.Any(f => f.Equals(i))) { entries[i] = 0; }
                }
                return entries;
            }

            public static void Run()
            {
                int[] records = new int[] { 1, 2, 0, 5, 0, 2, 4, 3, 3, 3 };
                var result = Simulate(records);
                Console.WriteLine(string.Join(", ", result));
            }
        }
        public class MergeNames
        {
            /*Given two arrays of names, copy all values from both array if they are unique or exisit in both but only copy it once. No duplicates in final result.
             */
            public static string[] UniqueNames(string[] names1, string[] names2)
            {
                List<string> unq = new List<string>();
                foreach (string s in names1)
                {
                    if (!unq.Any(a => a.Equals(s))) { unq.Add(s); }
                }

                foreach (string s in names2)
                {
                    if (!unq.Any(a => a.Equals(s))) { unq.Add(s); }
                }
                return unq.ToArray<string>();
            }

            public static void Run()
            {
                string[] names1 = new string[] { "Ava", "Ava", "Emma", "Olivia" };
                string[] names2 = new string[] { "Olivia", "Ava", "Emma" };
                Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
            }
        }

        public class XmlFolderNames
        {
            public static IEnumerable<string> FolderNames(string xml, char startingLetter)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                string xpath = "folder";
                var nodes = xmlDoc.SelectNodes(xpath);
                List<string> folderNames = new List<string>();
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes != null && node.Attributes["name"] != null
                        && node.Attributes["name"].Value[0] == startingLetter)
                    {
                        folderNames.Add(node.Attributes["name"].Value);
                    }
                }

                return folderNames;
            }

            public static void Run()
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<folder name=\"c\">" +
                        "<folder name=\"program files\">" +
                            "<folder name=\"uninstall information\" />" +
                        "</folder>" +
                        "<folder name=\"users\" />" +
                    "</folder>";

                foreach (string name in XmlFolderNames.FolderNames(xml, 'u'))
                    Console.WriteLine(name);
            }
        }

        public class RoutePlanner
        {
            public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                              bool[,] mapMatrix)
            {
                int value;
                bool parsed = int.TryParse("1", out value);

                //using (Stream i = File.OpenRead("inputname"))
                //{ long it= i.Position; }
                int a = 1;
                {
                    int b = 2;
                    a = b;
                }
                string f = null;
                Console.WriteLine("F is null");
                try
                {
                    Console.WriteLine(f.Length);
                    Console.WriteLine("F is null2");
                }
                catch (NullReferenceException) { Console.WriteLine("hi"); }
                finally { Console.WriteLine("bye"); }
                int rowCount = mapMatrix.Length;
                //int colCount = mapMatrix[0].Length;

                for (int i = fromRow; i < toRow; i++)
                {

                }


                return false;
            }

            public static void Run()
            {
                bool[,] mapMatrix = {
                    {true, false, false},
                    {true, true, false},
                    {false, true, true}
                };

                Console.WriteLine(RouteExists(0, 0, 2, 2, mapMatrix));
            }
        }

        public class IslandGraph
        {
            int[,] islandMatrix;
            bool[,] VISITED;
            public int ROW, COL;
            public IslandGraph()
            {
                islandMatrix = new int[,] {
                    { 0,0,1,1},
                    { 0,1,0,0},
                    { 0,1,0,0},
                    { 1,0,0,1}
                };
                ROW = islandMatrix.GetLength(0);
                COL = islandMatrix.GetLength(1);
                VISITED = new bool[ROW, COL];
            }
            public bool IsSafeAndNewLand(int r, int c)
            {
                return (r >= 0 && r < ROW && c >= 0 && c < COL && islandMatrix[r, c] == 1 && !VISITED[r, c]);
            }

            public void DFS(int r, int c)
            {
                int[] rowId = { -1, -1, -1, 0, 0, 1, 1, 1 };
                int[] colId = { -1, 0, 1, -1, 1, -1, 0, 1 };
                VISITED[r, c] = true;

                for (int i = 0; i < 8; i++)
                {
                    int currentRow = r + rowId[i];
                    int currentCol = c + colId[i];
                    if (IsSafeAndNewLand(currentRow, currentCol))
                    {
                        DFS(currentRow, currentCol);
                    }
                }
            }

            public int islandCounter()
            {
                int counter = 0;
                for (int i = 0; i < ROW; i++)
                {
                    for (int j = 0; j < COL; j++)
                    {
                        //if (islandMatrix[i, j] == 1 && !VISITED[i, j])
                        if (IsSafeAndNewLand(i, j))
                        {
                            counter++;
                            DFS(i, j);
                        }
                    }
                }
                return counter;
            }

            public static void Run()
            {
                Console.WriteLine($"The current map has {new IslandGraph().islandCounter()} islands");
            }


        }

        public class PerfectNumber
        {
            public List<int> CheckNumber(int x, int y)
            {
                // write your solution here
                List<int> result = new List<int>();
                List<int> currentDigits = new List<int>();
                for (int i = x; i <= y; i++)
                {
                    currentDigits = GetDigits(i);
                    bool areCurrentDigitsPerfect = true;
                    foreach (int j in currentDigits)
                    {
                        if (j != 0 && i % j != 0) { areCurrentDigitsPerfect = false; }
                    }
                    if (areCurrentDigitsPerfect)
                    {
                        result.Add(i);
                    }

                }

                return result;
            }

            public List<int> GetDigits(int value)
            {
                List<int> digits = new List<int>();
                if (value == 0) { return digits; }
                if (value == 1) { digits.Add(value); return digits; }
                //for (int i = value; i > 0; i /= value)
                //{
                //    int digit = i % 10;
                //    if (digit > 0)
                //    { digits.Add(digit); }
                //}
                int i = value;
                while (i > 1)
                {
                    int digit = i % 10;
                    i /= value;
                    digits.Add(digit);
                }
                return digits;
            }
            public static void Print(List<int> arr, string caller)
            {
                arr.ForEach((a) => Console.Write(a + ", "));
                Console.WriteLine($"Calling from {caller}");
            }
            public static void Run()
            {
                Console.WriteLine($"Is PerfectNumber?: (1,22)");
                var perfectNumberList = new PerfectNumber().CheckNumber(1, 22);
                PerfectNumber.Print(perfectNumberList, "Run");
            }

        }
        //public async static int EventLogException() { return string.getw; }
        //private static string chec(int A) { if (A == null || A==1) throw new ArgumentException(); }
        Int32 A() { return 4; }
        public static class VersionComparer
        {
            public static int VersionCompare(string version1, string version2)
            {
                var V1 = version1.Split('.').Select(s => int.Parse(s)).ToArray();
                var V2 = version2.Split('.').Select(s => int.Parse(s)).ToArray();
                int result = 0;
                int i = 0, j = 0;
                for (; i < V1.Length && j < V2.Length; i++)
                {
                    if (V1[i] > V2[j])
                    {
                        result = 1; break;
                    }
                    else if (V1[i] < V2[j])
                    {
                        result = -1; break;
                    }

                    j++;
                }

                if (result == 0 && V1.Length > V2.Length && V1.Skip(i).Any(v => v > 0)) { result = 1; }
                if (result == 0 && V2.Length > V1.Length && V2.Skip(j).Any(v => v > 0)) { result = -1; }

                return result;
            }
            public static void Run()
            {
                //string version1 = "2.0.1.0.111.0.0.0.12";
                //string version2 = "2.0.1.0.111";
                string version1 = "2";
                string version2 = "2.1";
                Console.WriteLine("*** VersionComparer ***");
                Console.WriteLine($"VersionComparer: ( {version1},{version2})");
                var versionComparerResult = VersionComparer.VersionCompare(version1, version2);
                Console.WriteLine($"VersionComparer result: {versionComparerResult}");
            }


        }

        public static void Run2()
        {
            string s = "\\My Test\\\\";
            char[] chars = { '\\' };
            int i = s.LastIndexOfAny(chars);
            try
            {
                //chec(1); 
                //await EventLogException();
                string f = null;
                Console.Write($"tat {f.Length}");
            }
            catch (NullReferenceException)
            {
                Console.Write("null ref");
            }
            catch (Exception)
            {

                Console.Write("ex  ");
            }
            catch
            {

                Console.Write("empty ex  ");
            }
            finally
            {

                Console.Write("final  ");
            }

            var list1 = new List<int>() { 1, 2, 3, 4, 5 };
            var list2 = new List<int>() { 6, 7, 8, 9, 0 };
            var result = list1.Select((x, y) => new { x, y })
                .Join(list2.Select((x, y) => new { x, y }), x => x.y % 2, x => x.y,
            (x, y) => x.y == y.y ? x : y).Select(x => x.x).ToList();
            int value;
            bool parsed = int.TryParse("hello world", out value);


            using (Stream input = File.OpenRead("not"))
            {
                Console.WriteLine(input.Length);
            }

        }

        public async static void Run()
        {
            Console.WriteLine("*** Random code for quick checks ***");
            //Run2();

            Console.WriteLine("*** Minamal Heaviest Set ***");
            MinimalHeaviestSet.Run();
            Console.WriteLine("*** Append And Delete ***");
            AppendAndDelete.Run();
            Console.WriteLine("*** Malware Analysis ***");
            MalwareAnalysis.Run();
            Console.WriteLine("*** Merge Names ***");
            MergeNames.Run();
            Console.WriteLine("*** Xml Folder  Names ***");
            XmlFolderNames.Run();
            //Console.WriteLine("*** Route Planner ***");
            //RoutePlanner.Run();
            Console.WriteLine("*** Island Graph counter ***");
            IslandGraph.Run();
            Console.WriteLine("*** MultiValue Dictionary ***");
            MultiValueDictionaryChallenge.MultiValueDictionaryTests.Run();
            Console.WriteLine("*** Perfect Number? ***");
            PerfectNumber.Run();
            VersionComparer.Run();
            Console.WriteLine("*** MathExpression Evaluator   ***");
            MathExpressionEvaluator.SimpleMathEvaluator.Run();
            Console.WriteLine("*** Threading Options ***");
            await ThreadingOptions.ThreadingOptions.Run();
            Console.WriteLine("*** First Missing Positive ***");
              FirstMissingPositive.FirstMissingPositive.Run();
        }

    }
}



namespace MultiValueDictionaryChallenge
{
    public interface IMultiValueDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        /// <summary>
        /// Adds a value to either existing key or creates a new key and adds the value to it if the key value pair does not already exist
        /// </summary>
        /// <param name="key">Key to add value to</param>
        /// <param name="value">Value to add</param>
        /// <returns>true if the underlying collection has changed; false otherwise</returns>
        bool Add(K key, V value);

        /// <summary>
        /// Returns a sequence of values for the given key. throws KeyNotFoundException if the key is not present
        /// </summary>
        /// <param name="key">key to retrieve the sequence of values for</param>
        /// <returns>sequence of values for the given key</returns>
        IEnumerable<V> Get(K key);

        /// <summary>
        /// Returns a sequence of values for the given key. returns empty sequence if the key is not present
        /// </summary>
        /// <param name="key">key to retrieve the sequence of values for</param>
        /// <returns>sequence of values for the given key</returns>
        IEnumerable<V> GetOrDefault(K key);

        /// <summary>
        /// Removes the value from the values associated with the given key. throws KeyNotFoundException if the key is not present
        /// </summary>
        /// <param name="key">key which values need to be adjusted</param>
        /// <param name="value">value to remove from the values for the given key</param>
        void Remove(K key, V value);

        /// <summary>
        /// Removes the given key from the dictionary with all the values associated with it
        /// </summary>
        /// <param name="key">key to remove from the dictionary</param>
        void Clear(K key);

        /// <summary>
        /// Returns a sequence of items of KeyValuePair<K, V> type, flattening the internal collection.
        /// </summary>
        /// 
        /// <example> 
        /// var creatures = new MultiValueDictionary<string, string>();
        /// creatures.Add("birds", "eagle");
        /// creatures.Add("birds", "dove");
        /// creatures.Add("animals", "tiger");
        /// 
        /// foreach (KeyValuePair<string, string> pair in creatures.Flatten()) {
        ///     Console.WriteLine($"<{pair.Key}, {pair.Value}>");
        /// }
        /// 
        /// This will print 3 pairs:        
        /// <birds, eagle>
        /// <birds, dove>
        /// <animals, tiger>
        /// 
        /// </example>
        /// <references>
        /// KeyValuePair<TKey, TValue>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2?view=netframework-4.7.2
        /// IEnumerable<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=netframework-4.7.2
        /// </references>
        IEnumerable<KeyValuePair<K, V>> Flatten();
    }

    public class MultiValueDictionary<K, V> : IMultiValueDictionary<K, V>
    {
        // Add your implementation here
        //List<V> values = new List<V>();
        Dictionary<K, List<V>> dictionary = new Dictionary<K, List<V>>();
        public bool Add(K key, V value)
        {
            if (dictionary.ContainsKey(key))
            {
                List<V> existingList = dictionary[key];
                existingList.Add(value);
                dictionary[key] = existingList;
            }
            else
            {
                dictionary.Add(key, new List<V>() { value });
            }
            return true;
        }

        public IEnumerable<V> Get(K key)
        {
            //Check if key exists first
            if (dictionary[key] == null)
            {
                throw new KeyNotFoundException();
            }
            return dictionary[key];
        }

        /// <summary>
        /// Returns a sequence of values for the given key. returns empty sequence if the key is not present
        /// </summary>
        /// <param name="key">key to retrieve the sequence of values for</param>
        /// <returns>sequence of values for the given key</returns>
        public IEnumerable<V> GetOrDefault(K key)
        {
            //Check if key exists first
            if (dictionary[key] == null)
            {
                new List<V>();
            }
            return dictionary[key];
        }

        /// <summary>
        /// Removes the value from the values associated with the given key. throws KeyNotFoundException if the key is not present
        /// </summary>
        /// <param name="key">key which values need to be adjusted</param>
        /// <param name="value">value to remove from the values for the given key</param>
        public void Remove(K key, V value)
        {
            //Check if key exists first
            if (dictionary[key] == null)
            {
                throw new KeyNotFoundException();
            }

            List<V> existingList = dictionary[key];
            if (existingList.Contains(value))
            {
                var itemToRemove = existingList.SingleOrDefault(e => e.Equals(value));
                if (itemToRemove != null)
                {

                    existingList.Remove(itemToRemove);
                }
            }
        }

        public void Clear(K key)
        {
            if (dictionary[key] != null)
            {
                dictionary.Remove(key);
            }
        }


        public IEnumerable<KeyValuePair<K, V>> Flatten()
        {
            List<KeyValuePair<K, V>> result = new List<KeyValuePair<K, V>>();

            foreach (var kvp in dictionary)
            {

                foreach (var value in kvp.Value)
                {
                    result.Add(new KeyValuePair<K, V>(kvp.Key, value));
                }
            }

            return result;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var kvp in dictionary)
            {
                var values = kvp.Value;
                foreach (var v in values)
                {
                    yield return new KeyValuePair<K, V>(kvp.Key, v);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }

    /*********************************************************************************************************
      *
      * Main Program / Test Cases
      *  
      **********************************************************************************************************/

    public class MultiValueDictionaryTests
    {
        private IMultiValueDictionary<string, string> items;
        public static void Run()
        {

            new MultiValueDictionaryTests().Runner();
        }

        public void Runner()
        {
            InvokeTest(Add_NewKeyNewItem_True);
            InvokeTest(Add_SameKeyDifferentItems_True);
            InvokeTest(Add_SameKeySameItem_False);

            InvokeTest(Remove_ExistingKeyExistingItem);
            InvokeTest(Remove_ExistingKeyNonexistingItem);
            InvokeTest(Remove_NonexistingKeyExistingItem_ThrowsKeyNotFoundException);
            InvokeTest(Remove_NonexistingKeyNonxistingItem_ThrowsKeyNotFoundException);

            InvokeTest(Get_OneKeyOneValue);
            InvokeTest(Get_OneKeyTwoValues);
            InvokeTest(Get_TwoKeysTwoValues);
            InvokeTest(Get_NonexistingKey_ThrowsKeyNotFoundException);

            InvokeTest(GetOrDefault_OneKeyOneValue);
            InvokeTest(GetOrDefault_OneKeyTwoValues);
            InvokeTest(GetOrDefault_TwoKeysTwoValues);
            InvokeTest(GetOrDefault_NonexistingKey);

            InvokeTest(Clear_ExistingKey);
            InvokeTest(Clear_NonexistingKey);

            InvokeTest(Flatten_OneKeyOneValue);
            InvokeTest(Flatten_TwoKeysTwoValues);

            InvokeTest(GetEnumerator_OneKeyOneValue);
            InvokeTest(GetEnumerator_TwoKeysTwoValues);
            InvokeTest(GetEnumeratorNonGeneric_TwoKeysTwoValues);
        }

        private void Add_NewKeyNewItem_True()
        {
            Assert(items.Add("animals", "tiger"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Add_SameKeyDifferentItems_True()
        {
            Assert(items.Add("animals", "tiger"));
            Assert(items.Add("animals", "lion"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 2);
            Assert(result.Contains("tiger"));
            Assert(result.Contains("lion"));
        }

        private void Add_SameKeySameItem_False()
        {
            Assert(items.Add("animals", "tiger"));
            Assert(!items.Add("animals", "tiger"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Remove_ExistingKeyExistingItem()
        {
            items.Add("animals", "tiger");
            items.Remove("animals", "tiger");

            var result = items.GetOrDefault("animals").ToList();

            Assert(result.Count == 0);
        }

        private void Remove_ExistingKeyNonexistingItem()
        {
            items.Add("animals", "tiger");
            items.Remove("animals", "lion");

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Remove_NonexistingKeyExistingItem_ThrowsKeyNotFoundException()
        {
            items.Add("animals", "tiger");
            AssertFails<KeyNotFoundException>(
                () => items.Remove("fish", "tiger"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Remove_NonexistingKeyNonxistingItem_ThrowsKeyNotFoundException()
        {
            items.Add("animals", "tiger");
            AssertFails<KeyNotFoundException>(
                () => items.Remove("fish", "shark"));

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Get_OneKeyOneValue()
        {
            items.Add("animals", "tiger");

            var values = items.Get("animals").ToList();

            Assert(values.Count == 1);
            Assert(values[0] == "tiger");
        }

        private void Get_OneKeyTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");

            var values = items.Get("animals").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));
        }

        private void Get_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var values = items.Get("animals").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));

            values = items.Get("birds").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "eagle"));
            Assert(values.Any(i => i == "dove"));
        }

        private void Get_NonexistingKey_ThrowsKeyNotFoundException()
        {
            AssertFails<KeyNotFoundException>(
                () => items.Get("animals"));
        }

        private void GetOrDefault_OneKeyOneValue()
        {
            items.Add("animals", "tiger");

            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 1);
            Assert(values[0] == "tiger");
        }

        private void GetOrDefault_OneKeyTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");

            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));
        }

        private void GetOrDefault_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));

            values = items.GetOrDefault("birds").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "eagle"));
            Assert(values.Any(i => i == "dove"));
        }

        private void GetOrDefault_NonexistingKey()
        {
            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 0);
        }

        private void Clear_ExistingKey()
        {
            items.Add("animals", "tiger");
            items.Clear("animals");

            var values = items.GetOrDefault("animals").ToList();

            Assert(values.Count == 0);
        }

        private void Clear_NonexistingKey()
        {
            items.Add("animals", "tiger");
            items.Clear("fish");

            var result = items.Get("animals").ToList();

            Assert(result.Count == 1);
            Assert(result[0] == "tiger");
        }

        private void Flatten_OneKeyOneValue()
        {
            items.Add("animals", "tiger");

            var result = items.Flatten().ToList();

            Assert(result.Count == 1);
            Assert(result[0].Key == "animals");
            Assert(result[0].Value == "tiger");
        }

        private void Flatten_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var result = items.Flatten().ToList();

            Assert(result.Count == 4);
            Assert(result.Any(i => i.Key == "animals" && i.Value == "tiger"));
            Assert(result.Any(i => i.Key == "animals" && i.Value == "lion"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "eagle"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "dove"));
        }

        private void GetEnumerator_OneKeyOneValue()
        {
            items.Add("animals", "tiger");

            var result = new List<KeyValuePair<string, string>>();
            foreach (var item in items)
                result.Add(item);

            Assert(result.Count == 1);
            Assert(result[0].Key == "animals");
            Assert(result[0].Value == "tiger");
        }

        private void GetEnumerator_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var result = new List<KeyValuePair<string, string>>();
            foreach (var item in items)
                result.Add(item);

            Assert(result.Count == 4);
            Assert(result.Any(i => i.Key == "animals" && i.Value == "tiger"));
            Assert(result.Any(i => i.Key == "animals" && i.Value == "lion"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "eagle"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "dove"));
        }

        private void GetEnumeratorNonGeneric_TwoKeysTwoValues()
        {
            items.Add("animals", "tiger");
            items.Add("animals", "lion");
            items.Add("birds", "eagle");
            items.Add("birds", "dove");

            var result = new List<KeyValuePair<string, string>>();
            foreach (var item in (IEnumerable)items)
                result.Add((KeyValuePair<string, string>)item);

            Assert(result.Count == 4);
            Assert(result.Any(i => i.Key == "animals" && i.Value == "tiger"));
            Assert(result.Any(i => i.Key == "animals" && i.Value == "lion"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "eagle"));
            Assert(result.Any(i => i.Key == "birds" && i.Value == "dove"));
        }



        // helpers

        private void InvokeTest(Action test)
        {
            items = new MultiValueDictionary<string, string>();
            var testName = test.Method.Name;

            try
            {
                test();
                Console.WriteLine($"> {testName}: OK");
            }
            catch (Exception e)
            {
                if (e is AggregateException)
                    e = e.InnerException;
                Console.WriteLine($"> {testName}: FAILED ({e.Message})");
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void Assert(bool result)
        {
            if (!result)
                throw new Exception("Assertion failed.");
        }

        private static void AssertFails<TException>(Action action)
            where TException : Exception
        {
            AssertFails(action, typeof(TException));
        }

        private static void AssertFails(Action action, Type exceptionType)
        {
            try
            {
                action();
                throw new Exception($"Assertion failed: {exceptionType} wasn't thrown.");
            }
            catch (Exception e)
            {
                Assert(exceptionType.IsInstanceOfType(e));
            }
        }
    }

}


namespace MathExpressionEvaluator
{

    using System;
    using System.Collections.Generic;

    class SimpleMathEvaluator
    {
        public static double Evaluate(string expression)
        {
            try
            {
                var tokens = Tokenize(expression);
                var result = EvaluateTokens(tokens);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return double.NaN; // Return NaN for invalid expressions
            }
        }

        private static List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            var currentToken = "";

            foreach (var character in expression)
            {
                if (char.IsDigit(character) || character == '.')
                {
                    currentToken += character;
                }
                else if (IsOperator(character) || character == '(' || character == ')')
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = "";
                    }

                    tokens.Add(character.ToString());
                }
                else if (!char.IsWhiteSpace(character))
                {
                    throw new ArgumentException($"Invalid character in input: {character}");
                }
            }

            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens;
        }

        private static double EvaluateTokens(List<string> tokens)
        {
            var stack = new Stack<double>();
            var operatorStack = new Stack<char>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out var operand))
                {
                    stack.Push(operand);
                }
                else if (IsOperator(token[0]))
                {
                    while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(token[0]))
                    {
                        ApplyOperator(stack, operatorStack.Pop());
                    }

                    operatorStack.Push(token[0]);
                }
                else if (token == "(")
                {
                    operatorStack.Push('(');
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                    {
                        ApplyOperator(stack, operatorStack.Pop());
                    }

                    if (operatorStack.Count == 0 || operatorStack.Pop() != '(')
                    {
                        throw new ArgumentException("Mismatched parentheses");
                    }
                }
            }

            while (operatorStack.Count > 0)
            {
                ApplyOperator(stack, operatorStack.Pop());
            }

            if (stack.Count != 1)
            {
                throw new ArgumentException("Invalid expression");
            }

            return stack.Pop();
        }

        private static void ApplyOperator(Stack<double> stack, char op)
        {
            if (stack.Count < 2)
            {
                throw new ArgumentException("Invalid expression");
            }

            var operand2 = stack.Pop();
            var operand1 = stack.Pop();

            switch (op)
            {
                case '+':
                    stack.Push(operand1 + operand2);
                    break;
                case '-':
                    stack.Push(operand1 - operand2);
                    break;
                case '*':
                    stack.Push(operand1 * operand2);
                    break;
                case '/':
                    stack.Push(operand1 / operand2);
                    break;
                default:
                    throw new ArgumentException($"Unsupported operator: {op}");
            }
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private static int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0; // Lower precedence for non-operators
            }
        }

        public static void Run()
        {
            //Console.Write("Enter a math expression: ");
            //var input = Console.ReadLine();
            var input = "2 * (3 + 4) / 5";

            var result = Evaluate(input);
            if (!double.IsNaN(result))
            {
                Console.WriteLine($"Result: {result}");
            }
        }
    }

}

namespace ThreadingOptions
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    class ThreadingOptions
    {
        public static async Task Run()
        {
            // List of URLs to download
            List<string> urls = new List<string>
            {
             "https://www.example.com",
             "https://www.example.org",
             "https://www.example.net",
             // Add more URLs as needed
            };

            Console.WriteLine("Sequential Download:");

            // Sequential download using async/await
            await DownloadUrlsSequentiallyAsync(urls);

            Console.WriteLine("\nParallel Download using TPL:");

            // Parallel download using Task Parallel Library (TPL)
            await DownloadUrlsParallelAsync(urls);

            Console.WriteLine("\nParallel Download using Parallel Class:");

            // Parallel download using Parallel class
            DownloadUrlsParallel(urls);

            Console.WriteLine("\nAsync Download using async/await:");

            // Async download using async/await
            await DownloadUrlsAsync(urls);
        }

        static async Task DownloadUrlsSequentiallyAsync(List<string> urls)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var url in urls)
                {
                    var response = await httpClient.GetStringAsync(url);
                    Console.WriteLine($"Downloaded {url} ({response.Length} bytes)");
                }
            }
        }

        static async Task DownloadUrlsParallelAsync(List<string> urls)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                List<Task> downloadTasks = new List<Task>();

                foreach (var url in urls)
                {
                    downloadTasks.Add(Task.Run(async () =>
                    {
                        var response = await httpClient.GetStringAsync(url);
                        Console.WriteLine($"Downloaded {url} ({response.Length} bytes)");
                    }));
                }

                await Task.WhenAll(downloadTasks);
            }
        }

        static void DownloadUrlsParallel(List<string> urls)
        {
            Parallel.ForEach(urls, url =>
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(url).Result;
                    Console.WriteLine($"Downloaded {url} ({response.Length} bytes)");
                }
            });
        }

        static async Task DownloadUrlsAsync(List<string> urls)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                List<Task<string>> downloadTasks = new List<Task<string>>();

                foreach (var url in urls)
                {
                    downloadTasks.Add(httpClient.GetStringAsync(url));
                }

                var responses = await Task.WhenAll(downloadTasks);

                for (int i = 0; i < urls.Count; i++)
                {
                    Console.WriteLine($"Downloaded {urls[i]} ({responses[i].Length} bytes)");
                }
            }
        }
    }

}

namespace FirstMissingPositive
{
    class FirstMissingPositive
    {
        public static void Run()
        {
            int[] nums = { 3, 4, -1, 1 };
            int result = FindMissingPositive(nums);
            Console.WriteLine(result);
        }

        static int FindMissingPositive(int[] nums)
        {
            int length = nums.Length;
            int currentSmallest = 1;
            bool incrementCurrentSmallest = false;
            while (true)
            {
                incrementCurrentSmallest = false;
                foreach (int i in nums)
                {
                    if (i == currentSmallest)
                    {
                        currentSmallest++;
                        incrementCurrentSmallest = true;
                    }
                }

                if (!incrementCurrentSmallest)
                {
                    break;
                }
            }
            return currentSmallest;
        }

    }

    namespace Invoicing {


        using System;
        using System.Collections.Generic;
        using System.Linq;

        namespace InvoiceRepository.Tests
        {

            public class InvoiceRepository : IInvoiceRepository
            {
                IQueryable<Invoice> _invoices;

                public InvoiceRepository(IQueryable<Invoice> invoices)
                {
                    // Console.WriteLine("Sample debug output");
                    if (invoices == null)
                    {
                        throw new ArgumentNullException();
                    }

                    _invoices = invoices;
                }

                /// <summary>
                /// Should return a total value of an invoice with a given id. If an invoice does not exist null should be returned.
                /// </summary>
                /// <param name="invoiceId"></param>
                /// <returns></returns>
                public decimal? GetTotal(int invoiceId)
                {
                    Invoice invoice = _invoices.FirstOrDefault(i => i.Id == invoiceId);
                    if (invoice == null)
                    {
                        return null;
                    }
                    decimal totalValue = CalculateTotalValueOfInvoices(new List<Invoice>() { invoice });
                    // foreach(InvoiceItem item in invoice.InvoiceItems)
                    // {
                    //     var currentValue = item.Count* item.Price;
                    //     totalValue += currentValue;
                    // }

                    return totalValue;
                }

                /// <summary>
                /// Should return a total value of all unpaid invoices.
                /// </summary>
                /// <returns></returns>
                public decimal GetTotalOfUnpaid()
                {

                    decimal totalUnpaid;

                    List<Invoice> unpaidInvoices = _invoices.Where(i => !i.AcceptanceDate.HasValue).ToList();

                    decimal totalValue = CalculateTotalValueOfInvoices(unpaidInvoices);

                    return totalValue;

                }

                /// <summary>
                /// Should return a dictionary where the name of an invoice item is a key and the number of bought items is a value.
                /// The number of bought items should be summed within a given period of time (from, to). Both the from date and the end date can be null.
                /// </summary>
                /// <param name="from"></param>
                /// <param name="to"></param>
                /// <returns></returns>
                public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
                {
                    List<Invoice> invoices = _invoices.Where(i => i.CreationDate >= from && i.CreationDate <= to).ToList();
                    Dictionary<string, long> soldItemsCount = new Dictionary<string, long>();

                    foreach (Invoice invoice in invoices)
                    {
                        foreach (InvoiceItem item in invoice.InvoiceItems)
                        {
                            if (soldItemsCount.ContainsKey(item.Name))
                            {
                                soldItemsCount[item.Name] += item.Count;
                            }
                            else
                            {
                                soldItemsCount.Add(item.Name, item.Count);
                            }
                        }
                    }

                    return soldItemsCount;
                }

                private decimal CalculateTotalValueOfInvoices(List<Invoice> invoices)
                {
                    decimal totalValue = 0;
                    foreach (Invoice invoice in invoices)
                    {
                        foreach (InvoiceItem item in invoice.InvoiceItems)
                        {
                            var currentValue = item.Count * item.Price;
                            totalValue += currentValue;
                        }
                    }
                    return totalValue;
                }
            }

            public interface IInvoiceRepository
            {
            }
        }

        // Please do not uncomment the classes.

        public class Invoice
        {
            // A unique numerical identifier of an invoice (mandatory)
            public int Id { get; set; }
            // A short description of an invoice (optional).
            public string Description { get; set; }
            // A number of an invoice e.g. 134/10/2018 (mandatory).
            public string Number { get; set; }
            // An issuer of an invoice e.g. Metz-Anderson, 600  Hickman Street,Illinois (mandatory).
            public string Seller { get; set; }
            // A buyer of a service or a product e.g. John Smith, 4285  Deercove Drive, Dallas (mandatory).
            public string Buyer { get; set; }
            // A date when an invoice was issued (mandatory).
            public DateTime CreationDate { get; set; }
            // A date when an invoice was paid (optional).
            public DateTime? AcceptanceDate { get; set; }
            // A collection of invoice items for a given invoice (can be empty but is never null).
            public IList<InvoiceItem> InvoiceItems { get; }

            public Invoice()
            {
                InvoiceItems = new List<InvoiceItem>();
            }
        }
        public class InvoiceItem
        {
            // A name of an item e.g. eggs.
            public string Name { get; set; }
            // A number of bought items e.g. 10.
            public int Count { get; set; }
            // A price of an item e.g. 20.5.
            public decimal Price { get; set; }
        }
        
    
    }
}