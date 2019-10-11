using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace wordCount
{
    class Program
    {
        static void Main(string[] args)
        {

            int charactersCount = 0;
            int lineCount = 0;
            int wordCount = 0;
            int lines = 0;
            string path = args[0];
            List<string> lists = new List<string>();  //存储过滤后单词的列表  

            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                
                string readLine="";
                while ((readLine = sr.ReadLine()) != null)
                {
                    lines++;
                    if (!string.IsNullOrWhiteSpace(readLine))
                    {
                        lineCount++;
                        string regexStr = Regex.Replace(readLine, @"[^a-zA-Z0-9]+", "#");//过滤
                        string[] wordsArr1 = regexStr.Split('#');  
                        charactersCount += readLine.Length;//统计每行的字符数 最后只需再加上每行就是总字符数

                        foreach (string newWord in wordsArr1)
                        {
                            if (newWord.Length != 0)
                            {
                                char[] temparr = newWord.ToCharArray();
                                if ((newWord.Length >= 4) && (char.IsLetter(temparr[0]) && char.IsLetter(temparr[1]) && char.IsLetter(temparr[2]) && char.IsLetter(temparr[3])))
                                {
                                    lists.Add(newWord.ToLower());
                                }
                            }
                        }  
                    }
                    
                }
                charactersCount += lines;
                sr.Close();
            }


            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            //单词出现频率统计
            foreach (string li in lists)
            {
                if (wordsCount.ContainsKey(li))
                {
                    wordsCount[li] ++;
                }
                else
                {
                    wordsCount.Add(li, 1);
                }

            }

            wordCount = wordsCount.Count;//获得全部单词

            Console.WriteLine("characters: " + charactersCount);
            Console.WriteLine("words: " + wordCount);
            Console.WriteLine("lines: " + lineCount);

            //开始排序 先按照频率排序，在按照字典序排序
            Dictionary<string, int> sortedWord = wordsCount.OrderByDescending(p => p.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
            int i = 0;
            foreach (KeyValuePair<string, int> item in sortedWord)
            {
                
                Console.WriteLine(item.Key+" "+item.Value);
                if (i == 9)
                    break;
                i++;
            }
            Console.ReadLine();
        }
    }
}
