using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace _09._Strings_Mashup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var n = text.Length;

            var letters = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    letters.Add(text[i]);
                }
            }

            var m = letters.Count;

            //Console.WriteLine(m);

            //Console.WriteLine(string.Join("", letters));

            var arr = new int[m];

            Gen01(arr, 0, letters, text);

        }

        private static void Gen01(int[] arr, int idx, List<char> letters, string text)
        {
            if (idx >= arr.Length)
            {
                //Console.WriteLine(string.Join(string.Empty, arr));
                for (int i = 0; i < text.Length; i++)
                {
                    if (Char.IsDigit(text[i]))
                    {
                        letters.Insert(i, text[i]);
                    }
                }

                Console.WriteLine(string.Join(string.Empty, letters));

                for (int i = 0; i < letters.Count; i++)
                {
                    if (Char.IsDigit(letters[i]))
                    {
                        letters.RemoveAt(i);
                        i--;
                    }
                }

                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[idx] = i;
                if (i == 0)
                {
                    letters[idx] = Char.ToUpper(letters[idx]);
                }
                else
                {
                    letters[idx] = Char.ToLower(letters[idx]);
                }
                Gen01(arr, idx + 1, letters, text);
            }
        }
    }
}
