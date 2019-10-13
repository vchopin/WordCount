using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace wordCount
{
    public class Core:ICore
    {
        string content;
        int lineCount = 0;
        int charactersCount = 0;
        List<string> lists = new List<string>();
        public List<string> Lists { get => lists; }
        public int LineCount { get => lineCount;}

        public Core(string content)
        {
            this.content = content;
        }

        

        

        public int GetCharNum()
        {
            using (StringReader sr = new StringReader(content))
            {
                string line;
                int lines = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    lines++;
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        lineCount++;
                        RegexAndAdd(line);
                    }
                }

                charactersCount += (lines-1);
            }

            return charactersCount;
        }

        private void RegexAndAdd(string line)
        {
            string regexStr1 = Regex.Replace(line, @"[^\u0000-\u007F]+", string.Empty);
            charactersCount += regexStr1.Length;//统计每行的字符数 最后只需再加上每行就是总字符数


            string regexStr2 = Regex.Replace(line, @"[^a-zA-Z0-9]+", "#");//过滤
            string[] wordsArr1 = regexStr2.Split('#');
            

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


        public Dictionary<string, int> SortAndGetWord(Dictionary<string, int> wordsCount)
        {
            Dictionary<string, int> sortedWord = wordsCount.OrderByDescending(p => p.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
            return sortedWord;
        }

        public int GetWordNum(Dictionary<string, int> wordsCount)
        {
            foreach (string li in lists)
            {
                if (wordsCount.ContainsKey(li))
                {
                    wordsCount[li]++;
                }
                else
                {
                    wordsCount.Add(li, 1);
                }

            }
            return wordsCount.Count;//获得全部单词
        }
    }
}
