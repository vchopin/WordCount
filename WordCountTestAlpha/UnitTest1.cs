using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System.IO;
using System.Collections.Generic;

namespace WordCountTestAlpha
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string content = File.ReadAllText("test.txt");
            
            ICore core = new Core(content);
            Assert.AreEqual(93, core.GetCharNum());
        }

        [TestMethod]
        public void TestMethod2()
        {
            string content = File.ReadAllText("test.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            ICore core = new Core(content);
            core.GetCharNum();
            Assert.AreEqual(6, core.GetWordNum(words));
        }

        [TestMethod]
        public void TestMethod3()
        {
            string content = File.ReadAllText("test.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            ICore core = new Core(content);
            core.GetCharNum();
            core.GetWordNum(words);
            string test="file1234 2\ndsfdsfsd5421 1\nhello 1\nwindows2000 1\nwindows95 1\nwindows98 1\n";
            words = core.SortAndGetWord(words);
            string actual = "";
            foreach (KeyValuePair<string, int> pair in words)
            {
                actual += pair.Key + " " + pair.Value + "\n";
            }

            StringAssert.Equals(test, actual);
        }
    }
}
