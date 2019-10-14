using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace wordCount
{
    class DataIO:IDataIO
    {
        public static string ReadFromLittleFile(string path)
        {
            return File.ReadAllText(path, Encoding.ASCII);
        }
        public static string ReadFromLargeFile(string path)
        {
            return File.ReadAllText(path, Encoding.ASCII);
        }

        /// <summary>
        /// 将文件全部读成string类型进行传递
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadFromFile(string path)
        {
            return File.ReadAllText(path, Encoding.ASCII);
        }
        /// <summary>
        /// 打印前maxline个排序后的单词。为0则全部打印
        /// </summary>
        /// <param name="sortedWord"></param>
        /// <param name="maxline"></param>
        public string Print(Dictionary<string, int> sortedWord, int maxline = 0,bool show=false)
        {
            StringBuilder printWord = new StringBuilder();
            if (maxline != 0)
            {
                int i = 0;
                
                foreach (KeyValuePair<string, int> item in sortedWord)
                {
                    printWord.AppendFormat("{0} {1}\n", item.Key, item.Value);
                    if(show)
                        Console.WriteLine(printWord);
                    if (i == maxline - 1)
                        break;
                    i++;
                }
            }
            else
            {
                foreach (KeyValuePair<string, int> item in sortedWord)
                {
                    printWord.AppendFormat("{0} {1}\n", item.Key, item.Value);
                    if (show)
                        Console.WriteLine(printWord);
                }
            }
            return printWord.ToString();
        }

        public void WriteToFile(string path,string content)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                string line = "";
                using (StringReader sr = new StringReader(content))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        file.WriteLine(line);
                    }
                }
            }
        }
    }
}
