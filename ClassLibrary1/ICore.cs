using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ICore
    {
        /// <summary>
        /// 获得全部字母数量
        /// </summary>
        /// <returns></returns>
        int GetCharNum();

        /// <summary>
        /// 获得全部单词数量
        /// </summary>
        /// <param name="wordsCount"></param>
        /// <returns></returns>
        int GetWordNum(Dictionary<string, int> wordsCount);

        /// <summary>
        /// 获取排序后的单词集
        /// </summary>
        /// <param name="wordsCount"></param>
        /// <returns></returns>
        Dictionary<string, int> SortAndGetWord(Dictionary<string, int> wordsCount);
    }
}
