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
            string content = File.ReadAllText(args[0]);
            Dictionary<string, int> words = new Dictionary<string, int>();
            ICore core = new Core(content);
            core.GetCharNum();
            Console.WriteLine(core.GetWordNum(words));
            new DataIO().Print(core.SortAndGetWord(words), 10);

        }
    }
}
