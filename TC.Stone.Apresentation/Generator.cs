using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TC.Stone.Apresentation
{
    public sealed class Generator : IDisposable
    {
        #region private variables

        private readonly string _fileDirectoryAndName = $"{Directory.GetCurrentDirectory()}\\aleatory-file.txt";
        private readonly Random _random = new Random();
        
        private Hashtable _hashtable = new Hashtable();

        #endregion private variables

        #region public methods

        public List<string> GetLines(uint lines)
        {
            _hashtable = new Hashtable();
            var list = new List<string>();

            for (int i = 0; i < lines; i++)
                list.Add(GetLine());

            return list;
        }

        public void WriteFile(List<string> list) => File.WriteAllLines(_fileDirectoryAndName, list);
        public int GetLinesOfFile() => File.ReadLines(_fileDirectoryAndName).Count();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion public methods

        #region private methods

        private string GetLine(string line = "")
        {
            var character = string.Empty;

            if (line.Length == 7)
                return _hashtable.ContainsKey(line) ? GetLine() : ReturnLine(line);

            do
            {
                character = GetChar();
            } while (line.Contains(character));

            return GetLine(line + character);
        }

        private string GetChar() 
            => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26)[_random.Next(25)].ToString();

        private string ReturnLine(string line)
        {
            _hashtable.Add(line, line);
            return line;
        }

        #endregion private methods
    }
}