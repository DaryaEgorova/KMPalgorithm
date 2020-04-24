using System;
using System.Diagnostics;
using System.IO;

namespace KMP_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            static int[] GetPrefix(string s) //создание префикс-функции
            {
                int[] result = new int[s.Length];
                result[0] = 0; //присваиваем первому элементу нулевое значение
                int index = 0;

                for (int i = 1; i < s.Length; i++)
                {
                    while (index >= 0 && s[index] != s[i]) { index--; }
                    index++;
                    result[i] = index;
                }
                return result;
            }

            static int FindSubstring(string pattern, string text) //поиск образца в строке
            {
                int res = -1;
                int[] pf = GetPrefix(pattern);
                int index = 0;
                

                for (int i = 0; i < text.Length; i++)
                {

                    while (index > 0 && pattern[index] != text[i]) { index = pf[index - 1]; }
                    if (pattern[index] == text[i]) index++;
                    if (index == pattern.Length)
                    {
                        return res = i - index + 1;
                    }
                }
                return res;
            }

            Stopwatch sWatch = new Stopwatch();
            
            
            StreamReader sr = new StreamReader("2500symbols.txt");
            string line = sr.ReadLine(); //считываем содержимое файла (строка S)
            string pattern = "Q6Y"; //вводим образец, который необходимо найти в строке (строка T)
            
            sWatch.Start();

            Console.WriteLine("Индекс, начиная с которого образец входит в строку: " + FindSubstring(pattern, line));

            sWatch.Stop();
            Console.WriteLine(sWatch.ElapsedMilliseconds.ToString()+" мс");
        }
    }
}
