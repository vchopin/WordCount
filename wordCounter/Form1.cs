using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using ClassLibrary1;
using System.Windows.Forms;

namespace wordCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "文本文件|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)  //如果点击的是打开文件
                {

                    this.textBox3.Text = File.ReadAllText(ofd.FileName);  //获取全路径文件名
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int m = 3;
            int n = 0;
            try
            {
                m = int.Parse(textBox1.Text);
                n = int.Parse(textBox2.Text);

                if (m < 1 || n < 1)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("词组长度和输出个数应该是大于0的整数");
            }

            Dictionary<string, int> words = new Dictionary<string, int>();
            Dictionary<string, int> wordsGroup = new Dictionary<string, int>();
            ICore core = new Core(textBox3.Text);
            IDataIO io = new DataIO();
            int charNum = core.GetCharNum();
            int wordNum = core.GetWordNum(words);
            words = core.SortAndGetWord(words);
            wordsGroup = ClassLibrary1.Program.GetWordGroup(((Core)core).Lists, m);
            string wordsGroupContent = "";
            foreach (KeyValuePair<string, int> wordsPair in wordsGroup)
            {
                wordsGroupContent += wordsPair.Key + ": " + wordsPair.Value + "\r\n";
            }
            string wordsCountContent = io.Print(words, n);

            string fullContent = "characters: " + charNum + "\r\n" +
                "words: " + wordNum + "\r\n" +
                "lines: " + ((Core)core).LineCount + "\r\n\r\n" +
                wordsGroupContent + "\r\n" +
                wordsCountContent;
            this.textBox4.Text = fullContent;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IDataIO io = new DataIO();
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.FileName = "output.txt";// in wpf is  sfd.FileName = "YourFileName";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                io.WriteToFile(localFilePath,textBox4.Text);
                MessageBox.Show("保存成功！");
            }
        }
    }
}
