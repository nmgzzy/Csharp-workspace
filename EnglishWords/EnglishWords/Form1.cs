using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishWords
{
    public partial class Form1 : Form
    {
        private string ListFileName = "../../../resource/CET4.txt";
        private string DataFileName = "../../../resource/data.txt";
        private FileStream fileWords;
        private FileStream fileData;
        private StreamReader wordReader;
        private StreamReader dataReader;
        private StreamWriter dataWriter;
        private int fileCount = 0;
        private Queue<string> reviewUFM = new Queue<string>();
        private Queue<string> reviewDK = new Queue<string>();
        private string s;
        private Random rnd = new Random();
        private int status = 0;
        private string chinese;
        private bool finish = false;
        public Form1()
        {
            InitializeComponent();
            try
            {
                fileWords = new FileStream(ListFileName, FileMode.Open, FileAccess.Read);
                wordReader = new StreamReader(fileWords, System.Text.Encoding.UTF8);
                DialogResult result = MessageBox.Show("是否读取上次进度", "读取", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    fileData = new FileStream(DataFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    dataReader = new StreamReader(fileData, System.Text.Encoding.UTF8);
                    s = dataReader.ReadLine();
                    string[] ss = s.Split();
                    if (s != "" && ss.Length == 3)
                    {
                        fileCount = Convert.ToInt32(ss[0]);
                        int j = Convert.ToInt32(ss[1]);
                        int k = Convert.ToInt32(ss[2]);
                        for (int i = 0; i < fileCount-2; i++)
                        {
                            wordReader.ReadLine();
                        }
                        for (int i = 0; i < j; i++)
                        {
                            reviewUFM.Enqueue(dataReader.ReadLine());
                        }
                        for (int i = 0; i < k; i++)
                        {
                            reviewDK.Enqueue(dataReader.ReadLine());
                        }
                    }
                    dataReader.Close();
                    fileData.Close();
                }
                ReadWordsList();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found!");
            }
            catch (IOException e2)
            {
                MessageBox.Show(e2.ToString());
            }
        }
        ~Form1()
        {
            wordReader.Close();
            fileWords.Close();
        }

        private void ShowWord(string ss)
        {
            string[] slist = ss.Split("\t", StringSplitOptions.RemoveEmptyEntries);
            this.labelEn.Text = slist[0];
            chinese = slist[1];
        }
        private void ReadWordsList()
        {
            s = wordReader.ReadLine();
            if (s != null)
            {
                ShowWord(s);
                fileCount++;
            }
            else
            {
                finish = true;
            }
            
        }
        private void ReadReviewQueueUFM()
        {
            if (reviewUFM.Count>0)
            {
                s = reviewUFM.Dequeue();
            }
            else
            {
                ReadWordsList();
            }
            ShowWord(s);
        }
        private void ReadReviewQueueDK()
        {
            if (reviewDK.Count > 0)
            {
                s = reviewDK.Dequeue();
                reviewUFM.Enqueue(s);
            }
            else
            {
                ReadWordsList();
            }
            ShowWord(s);
        }
        private void ReadWord()
        {
            if (finish && reviewUFM.Count == 0 && reviewDK.Count == 0)
            {
                MessageBox.Show("所有单词都背完了");
                return;
            }
            status = rnd.Next(3);
            if (reviewDK.Count > 20)
            {
                status = 2;
            }
            else if (reviewUFM.Count > 30)
            {
                status = 1;
            }
            else if (finish)
            {
                if (reviewDK.Count > 0)
                {
                    status = 2;
                }
                else if (reviewUFM.Count > 0)
                {
                    status = 1;
                }
            }
            switch (status)
            {
                case 0:
                    ReadWordsList();
                    break;
                case 1:
                    ReadReviewQueueUFM();
                    break;
                case 2:
                    ReadReviewQueueDK();
                    break;
            }
            this.timer2.Enabled = true;
            this.textBoxCn.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否保存进度", "保存", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    fileData = new FileStream(DataFileName, FileMode.Truncate, FileAccess.ReadWrite);
                    dataWriter = new StreamWriter(fileData, System.Text.Encoding.UTF8);
                    dataWriter.WriteLine("{0} {1} {2}", fileCount-1, reviewUFM.Count, reviewDK.Count);
                    for (int i = reviewUFM.Count; i > 0; i--)
                    {
                        dataWriter.WriteLine(reviewUFM.Dequeue());
                    }
                    for (int i = reviewDK.Count; i > 0; i--)
                    {
                        dataWriter.WriteLine(reviewDK.Dequeue());
                    }
                    dataWriter.Close();
                    fileData.Close();
                }
                catch
                {
                    MessageBox.Show("保存失败！");
                }
            }
        }

        private void buttonFM_Click(object sender, EventArgs e)
        {
            ReadWord();
        }

        private void buttonUFM_Click(object sender, EventArgs e)
        {
            reviewUFM.Enqueue(s);
            ReadWord();
        }

        private void buttonDK_Click(object sender, EventArgs e)
        {
            reviewDK.Enqueue(s);
            ReadWord();
        }

        private void checkBoxAuto_CheckedChanged(object sender, EventArgs e)
        {
            this.timer1.Enabled = this.checkBoxAuto.Checked;
            trackBar1_Scroll(sender, e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.timer1.Interval = this.trackBar1.Value * 1000;
            if (this.checkBoxAuto.Checked == false)
            {
                this.timer2.Interval = 3000;
            }
            else
            {
                this.timer2.Interval = this.timer1.Interval / 2;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadWordsList();
            this.timer2.Enabled = true;
            this.textBoxCn.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.timer2.Enabled = false;
            this.textBoxCn.Text = chinese;
        }
    }
}
