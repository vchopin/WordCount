﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary1
{
    public class DataIO:IDataIO
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
            string printWord = "";
            if (maxline != 0)
            {
                int i = 0;
                
                foreach (KeyValuePair<string, int> item in sortedWord)
                {
                    printWord += item.Key + " " + item.Value+"\r\n";
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
                    printWord += item.Key + " " + item.Value+"\r\n";
                    if(show)
                        Console.WriteLine(printWord);
                }
            }
            return printWord;
        }

        public void WriteToFile(string path,string content)
        {
            StreamWriter file = null;
            try
            {
                file = new StreamWriter(path);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("文件名不正确，请重新输入");
                return;
            }
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
