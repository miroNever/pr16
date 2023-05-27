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
        
        static void Main(string[] args)
        {
            while (true)
            {
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
            }
        }
    }
}
