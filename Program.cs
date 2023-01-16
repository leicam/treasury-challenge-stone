using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TreasuryChallenge
{
    class Program
    {
        static List<string> Lines;
        static string AllLines = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Tell me the number of lines do you need and press enter.");

            Lines = new List<string>();

            int l = int.Parse(Console.ReadLine());

            var t = Stopwatch.StartNew();
            
            Write(l);
            
            t.Stop();

            System.Console.WriteLine(t.ElapsedMilliseconds);
        }

        static string GetChar()
        {
            Random random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26);

            return chars[random.Next(25)].ToString();
        }

        static void Write(int l)
        {
            for (int i = 0; i < l; i++)
            {
                Lines.Add(GetLine() + "\n");
            }
            var partialLines = new List<string>();
            foreach(var line in Lines)             
            {
                AllLines += line;
                
                partialLines.Add(AllLines);
            }
            
            System.Console.WriteLine($"A file with {partialLines.Count} lines was generated.");

            File.WriteAllText("aleatory-file.txt", AllLines);
        }

        static string GetLine(string l = "")
        {
            if (l.Length == 7) return l;

            var c = GetChar();

            int totalL = l.Length;
            int count = 0;
            bool found = false;
            while (totalL != count)
            {
                for (int i = 0; i < totalL; i++)
                {
                    if (l[i].ToString() == c)
                    {
                        found = true;
                        break;
                    }

                    count++;
                }

                if (found)
                {
                    c = GetChar();
                    count = 0;
                    found = false;
                }
            }

            return GetLine(l + c);
        }
    }
}