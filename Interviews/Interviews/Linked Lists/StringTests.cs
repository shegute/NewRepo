using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Linked_Lists.StringTests
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
            //char? targetCharacter = null;
            foreach (DictionaryEntry item in table) {
                Console.WriteLine($"Character:{item.Key}, count:{item.Value}");
                //if (!targetCharacter.HasValue && (int)item.Value ==1) { targetCharacter =(char) item.Key; }
            }

            foreach (char c in word) { if (table.ContainsKey(c) && (int)table[c] == 1) { return c; } }

            // return targetCharacter.HasValue? targetCharacter.Value: ' ';
            return ' ';
        }

        public static void Run()
        {
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"############StringTests.Run()");
            string word = "this his ata teest to find first word.";
            Console.WriteLine($"############FindFirstNonRepeatedCharacter({word})");
            Console.WriteLine(  StringTests.FindFirstNonRepeatedCharacter(word));
        }
    }
}
