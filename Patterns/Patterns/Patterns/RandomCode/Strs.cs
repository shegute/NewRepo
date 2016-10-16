using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.RandomCode
{
    public class Strs
    {
        public static void Run()
        {
            Strs str = new Strs();
            str.StrArray();
            str.RemoveUnsupportedCharactersFromString("\r\r\r\r\rt\r\nhis is the story of a string \r that had fo\rrbidde\nn characters\n\r\t\r.\r");
            str.RemoveUnsupportedCharactersFromString2("\r\r\r\r\rt\nhis is the story of a string \r that had fo\rrbidde\nn characters\n\r\t\r.\r");
            string text = System.IO.File.ReadAllText(@"C:\Users\nathal\Documents\Visual Studio 2013\Projects\Test\Test\TextFile1.txt");
             str.RemoveUnsupportedCharactersFromString2(text); 
        }

        public void StrArray()
        {
            List<string> strList = new List<string>() { "one","two","tre"};
            string str = string.Join(",", strList);
            Console.WriteLine(str);

            string str2 = string.Join(",", strList.ToArray());
            Console.WriteLine(str2);
        }

        public void RemoveUnsupportedCharactersFromString(string input)
        {

            char[] allowedCharacters = new char[] { '\t', '\n' };
            //Horizontal Tab, Line feed, Carriage return

            char spaceCharacter = ' ';

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            List<int> unallowedCharactersIndexes = new List<int>();

            StringBuilder sbResult = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (
                    !allowedCharacters.Contains(c) &&
                    c < spaceCharacter
                    )
                {
                    unallowedCharactersIndexes.Add(i);
                }
            }
            int currentIndex = 0;
            foreach (int index in unallowedCharactersIndexes)
            {
                sbResult.Append(input.Substring(currentIndex, index - currentIndex));
                currentIndex = index+1;
            }
            Console.WriteLine("Input is :{0}", input);
            Console.WriteLine("Output is :{0}",sbResult.ToString());
        }

        public void RemoveUnsupportedCharactersFromString2(string input)
        {

            //int[] allowedCharacters = new int[] { 9,10};
            HashSet<int> allowedCharacters = new HashSet<int> { 9, 10,13 };
            //Horizontal Tab, Line feed, Carriage return

            int spaceCharacter = 32;

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            List<int> unallowedCharactersIndexes = new List<int>();

            StringBuilder sbResult = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (
                    !allowedCharacters.Contains(c) &&
                    c < spaceCharacter
                    )
                {
                    unallowedCharactersIndexes.Add(i);
                }
            }

            if (unallowedCharactersIndexes.Count == 0)
            {
                Console.WriteLine("Input is :{0}", input);
                Console.WriteLine("Output is :{0}", input);
                return ;
            }

            int currentIndex = 0;
            foreach (int index in unallowedCharactersIndexes)
            {
                sbResult.Append(input.Substring(currentIndex, index - currentIndex));
                currentIndex = index + 1;
            }
            Console.WriteLine("Input is :{0}", input);
            Console.WriteLine("Output is :{0}", sbResult.ToString());
        }
    }
}
