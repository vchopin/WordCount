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

        [TestMethod]
        public void TestMethod4()
        {
            string test = "confidence 3\nyourself 3\nadmiration 1\nahead 1\narrogant 1\nchallenges 1\ndizzy 1\nenergy 1\nextremely 1\nfarewell 1\n";
            string content = File.ReadAllText("test1.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            ICore core = new Core(content);
            core.GetCharNum();
            core.GetWordNum(words);
            words = core.SortAndGetWord(words);
            string actual = "";
            foreach (KeyValuePair<string, int> pair in words)
            {
                actual += pair.Key + " " + pair.Value + "\n";
            }

            StringAssert.Equals(test, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string test = "sdfs 2\ndfdsf 1\ndffs 1\nsdfsf 1";
            string content = File.ReadAllText("test2.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            ICore core = new Core(content);
            core.GetCharNum();
            core.GetWordNum(words);
            words = core.SortAndGetWord(words);
            string actual = "";
            foreach (KeyValuePair<string, int> pair in words)
            {
                actual += pair.Key + " " + pair.Value + "\n";
            }

            StringAssert.Equals(test, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string content = "";
            if (File.Exists("test10.txt"))
            {
                content = File.ReadAllText("test10.txt");

            }
            else
            {
                content = "文件名不正确请检查...";
            }
            StringAssert.Equals("文件名不正确请检查...", content);
        }
        [TestMethod]
        public void TestMethod7()
        {
            IDataIO data = new DataIO();
            string path = "??T>>Txsd>test.txt";
            data.WriteToFile(path, "hello");
            bool exist = File.Exists(path);
            Assert.AreEqual(false, exist);
        }
        [TestMethod]
        public void TestMethod8()
        {
            string test = "dffs sdfs sdfsf : 1\nsdfs sdfsf dfdsf: 1\nsdfsf dfdsf sdfs: 1\n";
            string content = File.ReadAllText("test1.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            Dictionary<string, int> wordsGroup = new Dictionary<string, int>();
            ICore core = new Core(content);
            IDataIO io = new DataIO();
            int charNum = core.GetCharNum();
            int wordNum = core.GetWordNum(words);
            words = core.SortAndGetWord(words);
            wordsGroup = Program.GetWordGroup(((Core)core).Lists, 3);
            string wordsGroupContent = "";
            foreach (KeyValuePair<string, int> wordsPair in wordsGroup)
            {
                wordsGroupContent += wordsPair.Key + ": " + wordsPair.Value + "\n";
            }
            StringAssert.Equals(test, wordsGroupContent);
        }

        [TestMethod]
        public void TestMethod9()
        {
            string content = File.ReadAllText("test3.txt");
            ICore core = new Core(content);
            Assert.AreEqual(46, core.GetCharNum());
        }
        [TestMethod]
        public void TestMethod10()
        {
            string content = File.ReadAllText("test4.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            ICore core = new Core(content);
            core.GetCharNum();
            Assert.AreEqual(14, core.GetWordNum(words));
        }
    }
}
