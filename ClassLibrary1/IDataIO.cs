using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IDataIO
    {
        /// <summary>
        /// 从文件中读取全部字符
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string ReadFromFile(string path);

        /// <summary>
        /// 打印前maxline个排序后的单词。为0则全部打印
        /// </summary>
        /// <param name="sortedWord"></param>
        /// <param name="maxline"></param>
        string Print(Dictionary<string,int> sortedWord, int maxline=0, bool show = false);

        void WriteToFile(string path, string content);
    }
}
