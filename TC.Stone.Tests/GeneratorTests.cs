using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.IO;
using System.Linq;
using TC.Stone.Apresentation;

namespace TC.Stone.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        private const string C_OWNER = "Juliano Ribeiro de Souza Maciel";
        private const string C_CATEGORY = "Implmentar Aqui";

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public void GetLines_Validate_ExpectedLengthSeven()
        {
            var generator = new Generator();
            var line = generator.GetLines(1).FirstOrDefault();

            Assert.IsNotNull(line);
            Assert.AreEqual(7, line.Length);
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public void GetLines_Validate_ExpectedNonRepeatingCharacter()
        {
            var generator = new Generator();
            var line = generator.GetLines(1).FirstOrDefault();
            var hashtable = new Hashtable();

            Assert.IsNotNull(line);
            Assert.AreEqual(7, line.Length);

            foreach(var character in line)
            {
                if (hashtable.ContainsKey(character))
                    Assert.Fail("Repeating character");
                else
                    hashtable.Add(character, character);
            }
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("10")]
        [DataRow("100")]
        [DataRow("1000")]
        [DataRow("10000")]
        [DataRow("100000")]
        [DataRow("1000000")]
        [DataRow("10000000")]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        [Timeout(240000)]
        public void GetLines_Validate_ExpectedSatisfactoryRuntime(string value)
        {
            var generator = new Generator();
            var lines = generator.GetLines(uint.Parse(value));

            Assert.IsNotNull(lines);
            Assert.AreEqual(int.Parse(value), lines.Count);
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public void GetLines_Validate_ExpectedNonRepeatingLine()
        {
            var generator = new Generator();
            var lines = generator.GetLines(100000);

            var hashtable = new Hashtable();

            Assert.IsNotNull(lines);
            Assert.AreEqual(100000, lines.Count);

            foreach (var line in lines)
            {
                if (hashtable.ContainsKey(line))
                    Assert.Fail("Repeating line");
                else
                    hashtable.Add(line, line);
            }
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public void WriteFile_Validate_ExpectedSatisfactoryData()
        {
            var fileDirectoryAndName = $"{Directory.GetCurrentDirectory()}\\aleatory-file.txt";
            var generator = new Generator();
            var lines = generator.GetLines(10);

            generator.WriteFile(lines);
            var file = File.ReadAllLines(fileDirectoryAndName);

            Assert.IsNotNull(file);
            Assert.AreEqual(10, file.Count());
        }

        [TestMethod]
        [Owner(C_OWNER)]
        [TestCategory(C_CATEGORY)]
        public void GetLinesOfFile_Validate_ExpectedSatisfactoryData()
        {
            var fileDirectoryAndName = $"{Directory.GetCurrentDirectory()}\\aleatory-file.txt";
            var generator = new Generator();
            var lines = generator.GetLines(10);

            generator.WriteFile(lines);
            var file = File.ReadAllLines(fileDirectoryAndName);

            Assert.IsNotNull(file);
            Assert.AreEqual(generator.GetLinesOfFile(), file.Count());
        }
    }
}