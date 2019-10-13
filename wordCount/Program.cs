using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordCount
{
    class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "";
            string outputPath = "";
            int m = 1;
            int n = 0;
            if (args.Length == 4)
            {
                inputPath = args[1];
                outputPath = args[3];
            }
            else
            {

                for (int i = 0; i < args.Length; i++)
                {
                    if (string.Equals(args[i], "-i"))//获取-i参数
                        inputPath = args[i + 1];
                    if (string.Equals(args[i], "-o"))//获取-o参数
                        outputPath = args[i + 1];
                    if (string.Equals(args[i], "-m"))//获取-m参数
                        m = int.Parse(args[i + 1]);
                    if (string.Equals(args[i], "-n"))//获取-n参数
                        n = int.Parse(args[i + 1]);
                }
            }



            string content = File.ReadAllText(inputPath);
            Dictionary<string, int> words = new Dictionary<string, int>();
            Dictionary<string, int> wordsGroup = new Dictionary<string, int>();
            ICore core = new Core(content);
            IDataIO io = new DataIO();
            int charNum = core.GetCharNum();
            int wordNum = core.GetWordNum(words);
            words = core.SortAndGetWord(words);
            wordsGroup=GetWordGroup(((Core)core).Lists,m);
            string wordsGroupContent = "";
            foreach (KeyValuePair<string, int> wordsPair in wordsGroup)
            {
                wordsGroupContent += wordsPair.Key + ": " + wordsPair.Value + "\n";
            }
            string wordsCountContent = io.Print(words, n);

            string fullContent = "characters: " + charNum + "\n" +
                "words: " + wordNum + "\n" +
                "lines: " + ((Core)core).LineCount + "\n\n" +
                wordsGroupContent + "\n"+
                wordsCountContent;

            
            io.WriteToFile(outputPath, fullContent);

            Console.ReadKey();
        }

        /// <summary>
        /// 获得指定长度的词组
        /// </summary>
        /// <param name="words"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetWordGroup(List<string> words, int len = 3)
        {
            Dictionary<string, int> wordsGroup = new Dictionary<string, int>();
            for (int j = 0; j<words.Count;j++)
            {
                string wordsRelation = "";
                if (j <= words.Count - len )
                {
                    for (int i = j; i < j+len; i++)
                    {
                        wordsRelation += words[i] + " ";
                    }

                    if (wordsGroup.ContainsKey(wordsRelation))
                    {
                        wordsGroup[wordsRelation]++;
                    }
                    else
                    {
                        wordsGroup.Add(wordsRelation, 1);
                    }
                }
                

            }
            return wordsGroup;
        }
    }
}
