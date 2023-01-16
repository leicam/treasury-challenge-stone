using System;
using System.Diagnostics;

namespace TC.Stone.Apresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var generator = new Generator())
                {
                    var stopwatch = new Stopwatch();

                    Console.WriteLine("Tell me the number of lines do you need and press enter.");
                    var lines = uint.Parse(Console.ReadLine());

                    stopwatch.Start();
                    generator.WriteFile(generator.GetLines(lines));
                    Console.WriteLine($"A file with {generator.GetLinesOfFile()} lines was generated.");
                    stopwatch.Stop();

                    Console.WriteLine(stopwatch.ElapsedMilliseconds);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Press a key to continue.\n");
                Console.ReadKey();
            }
        }
    }
}