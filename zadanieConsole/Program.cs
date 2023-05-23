using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace zadanieConsole
{
    internal class Program
    {
        //задание 1
        static bool Check1(string word)
        {
            bool check = false;
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (c >= 'а' && c <= 'я')
                {
                    check = true;
                }
                else
                {
                    check = false;
                    break;
                }
            }

            return check;
        }
        static string ReadingFile(string line)
        {
            StreamReader sr = File.OpenText("file.txt");

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
            }

            sr.Close();
            return line;
        }
        static int Search(string word, string line)
        {
            List<string> list = line.Split(' ').ToList();

            IEnumerable<string> counter =
                from words in list
                where words.Contains(word)
                select words;
            int count = 0;

            foreach (string words in counter)
            {
                count++;
            }

            return count;

        }
        // задание 2
        //A
        static void CheckNum(string text)
        {
            IEnumerable<char> str =
                from c in text
                where char.IsDigit(c)
                select c;

            Console.Write("Всего чисел в строке: " + str.Count());
        }
        //B
        static void OutputTo(string text)
        {
            IEnumerable<char> str = text.TakeWhile(c => c != '/');

            foreach (char c in str)
            {
                Console.Write(c);
            }
        }
        //C
        static void OutputAfter(string text)
        {
            IEnumerable<char> str = text.SkipWhile(c => c != '/');

            string outtext = "";

            foreach (char c in str)
            {
                if (c == '/')
                    continue;
                else
                {
                    if (c >= 'а' && c <= 'я' || c >= 'a' && c <= 'z')
                        outtext += c.ToString().ToUpper();
                    else
                        if (c >= 'А' && c <= 'Я' || c >= 'A' && c <= 'Z')
                        outtext += c.ToString().ToLower();
                }
            }

            Console.WriteLine(outtext);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите какое задание хотите проверить 1 задание(1), 2 задание(2): ");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("\nВведите слово которое будете искать в файле: ");
                            string word = Console.ReadLine();
                            if (Check1(word))
                            {
                                string line = "";
                                line = ReadingFile(line);
                                int count = Search(word.ToLower(), line.ToLower());
                                Console.WriteLine($"Были найдены {count} вхождения(ий) поискового запроса {word}\n");
                            }
                            else
                            {
                                Console.WriteLine("Слово должно быть написано на русском языке.");
                            }

                            break;
                        case 2:
                            Console.WriteLine("Введите строку");
                            string text = Console.ReadLine();
                            Console.WriteLine("\n");
                            CheckNum(text);
                            Console.WriteLine("\n");
                            OutputTo(text);
                            Console.WriteLine("\n");
                            OutputAfter(text);
                            Console.WriteLine("\n");
                            break;
                        default:
                            Console.WriteLine("Введите 1 или 2");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введи число");
                }
            }
        }
    }
}
