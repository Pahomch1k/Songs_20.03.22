using System;
using static System.Console;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;

namespace Dop_2_Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            Songs s = new Songs();

            int flag = 0;
            int ch = 0;

            while (flag == 0)
            {
                WriteLine("1. Добавить песню\n2. Вывести все песни\n3. Выход");
                ch = Convert.ToInt32(ReadLine());

                switch (ch)
                {
                    case 1: s.InIt(); break;
                    case 2: s.Print();  break;
                    case 3: flag++; break;
                    default: WriteLine("Try again"); break;
                }
            }  
        }
    }

    class Songs
    {
        int Count = 1;
        string[,] ListSongs = new string[100, 3];
        string[] s = new string[] { "Name", "Creator", "Year" };
        string line; 

        public void Print()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i + 1 == Count) break;
                Write(i + 1 + ". ");
                for (int j = 0; j < s.Length; j++)
                {
                    Write(s[j] + " - " + ListSongs[i, j] + " ");
                }
                WriteLine();
            }
        }
         

        public void InIt()
        {
            WriteLine("Сколько добавить? ");
            int n = 0;
            n = Convert.ToInt32(ReadLine());
            Count += n;


            for (int i = 0; i < n; i++)
            {
                WriteLine(i + 1 + ".");
                line = $"{i + 1}. ";
                for (int j = 0; j < s.Length; j++)
                {
                    Write(s[j] + "? ");
                    ListSongs[i, j] = ReadLine();
                    line += $"{s[j]} - {ListSongs[i, j]} ";
                }
                WriteLine();
                SaveInFile(line);
            }
        }

        virtual public void SaveInFile(string line)
        {
            StreamWriter sw = new StreamWriter("Songs.txt", true);
            sw.WriteLine(line);
            sw.Close();
        }   
    }

}
