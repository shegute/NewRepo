using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Quizes.StringTests
{
   public class StringTests
    {
        public static char FindFirstNonRepeatedCharacter(string word) {

            Hashtable table = new Hashtable();
            foreach (char c in word)
            {
                if (!table.ContainsKey(c)) { table.Add(c, 1); }
                else { int i = (int)table[c];  table[c] = ++i;   }
            }

            foreach (DictionaryEntry item in table) {
                Console.WriteLine($"Character:{item.Key}, count:{item.Value}");
            }

            foreach (char c in word) { if (table.ContainsKey(c) && (int)table[c] == 1) { return c; } }
            
            return ' ';
        }
        public static string ReverseString(string word)
        {
            string reversedString = StringTests.ReverseWord(word);
            StringBuilder sb = new StringBuilder();
            string[] reversedStrings = reversedString.Split(' ');
            foreach (string s in reversedStrings) { sb.Append(ReverseWord(s)); sb.Append(' '); }
            return sb.ToString();
        }

        public static string ReverseWord(string word)
        {
            char[] sourcearray = word.ToCharArray();
            int wordLength = sourcearray.Length;
            char[] destArray = new char[wordLength]; for (int i = 0; i < wordLength; i++)
            {
                destArray[i] = sourcearray[wordLength - i-1];
            }
            return new string(destArray);
        }

        public static void Run()
        {
            Console.WriteLine(" &*&*&*&*&*&&*&*&*&*&*&*&*&*&StringTests*&*&*&*&*&**&*&*&*&*&*&*&* ");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"############StringTests.Run()");
            string word = "This is a test to find first word.";
            Console.WriteLine($"############FindFirstNonRepeatedCharacter({word})");
            Console.WriteLine(StringTests.FindFirstNonRepeatedCharacter(word));
            Console.WriteLine($"############ReverseString({word})");
            Console.WriteLine(StringTests.ReverseString(word));
        }
    }
}
