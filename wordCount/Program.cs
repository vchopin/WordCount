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
                    {
                        try
                        {
                            m = int.Parse(args[i + 1]);
                        }
                        catch
                        {
                            Console.WriteLine("-m后应输入数字");
                        }
                    }
                        
                    if (string.Equals(args[i], "-n"))//获取-n参数
                    {
                        try
                        {
                            n = int.Parse(args[i + 1]);
                        }
                        catch
                        {
                            Console.WriteLine("-n后应输入数字");
                        }
                    }
                }
            }



            string content = File.ReadAllText("Sophies World.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            Dictionary<string, int> wordsGroup = new Dictionary<string, int>();
            ICore core = new Core(content);
            IDataIO io = new DataIO();
            int charNum = core.GetCharNum();
            int wordNum = core.GetWordNum(words);
            words = core.SortAndGetWord(words);
            wordsGroup=GetWordGroup(((Core)core).Lists,m);
            StringBuilder wordsGroupContent = new StringBuilder();
            foreach (KeyValuePair<string, int> wordsPair in wordsGroup)
            {
                wordsGroupContent.AppendFormat("{0} : {1} \n", wordsPair.Key, wordsPair.Value); 
            }
            string wordsCountContent = io.Print(words, n);

            string fullContent = "characters: " + charNum + "\n" +
                "words: " + wordNum + "\n" +
                "lines: " + ((Core)core).LineCount + "\n\n" +
                wordsGroupContent + "\n"+
                wordsCountContent;

            
            io.WriteToFile("output.txt", fullContent);

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
