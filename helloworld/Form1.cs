using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helloworld
{
    public partial class Form1 : Form
    {
        Exam exam;
        public Form1()
        {
            InitializeComponent();
            exam = new Exam();
            this.question.Text = exam.getQuestion();
        }

        private void setNext()
        {
            this.answer.Focus();
            try
            {
                int answer = 9999;
                if (this.answer.Text != "")
                {
                    answer = int.Parse(this.answer.Text);
                }
                this.answer.Text = "";
                this.keyAnswer.Text = exam.getAnswer();
                if (exam.checkAnswer(answer))
                {
                    this.result.Text = "正确";
                    this.result.ForeColor = Color.Green;
                }
                else
                {
                    this.result.Text = "错误";
                    this.result.ForeColor = Color.Red;
                }
                this.question.Text = exam.getQuestion();
                this.rate.Text = exam.getRate();
            }
            catch
            {
                this.result.Text = "格式错误";
                this.result.ForeColor = Color.Orange;
            }
        }

        private void checkBoxNext_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxNext.Checked)
                this.timer1.Enabled = true;
            else
                this.timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            setNext();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            setNext();
        }

        private void btnFast_Click(object sender, EventArgs e)
        {
            if (this.timer1.Interval > 1000)
                this.timer1.Interval -= 1000;
        }

        private void btnSlow_Click(object sender, EventArgs e)
        {
            if (this.timer1.Interval < 15000)
                this.timer1.Interval += 1000;
        }

        private void rBtn10_CheckedChanged(object sender, EventArgs e)
        {
            exam.questionType = 1;
        }

        private void rBtn20_CheckedChanged(object sender, EventArgs e)
        {
            exam.questionType = 2;
        }

        private void rBtnM_CheckedChanged(object sender, EventArgs e)
        {
            exam.questionType = 3;
        }

        private void answer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                setNext();
                e.Handled = true;
            }
        }
    }

    public class Exam
    {
        public int questionType = 1;
        private int numA, numB, key, op, qCount = -1, rCount = 0;
        private Random rnd = new Random();
        private string s;

        public Exam()
        {

        }

        public string getQuestion()
        {
            qCount++;
            if (questionType <= 2)
            {
                numA = rnd.Next((questionType - 1) * 10, questionType * 10 + 1);
                numB = rnd.Next(questionType * 10 + 1);
                op = rnd.Next(2);
                if (op == 0)
                {
                    s = numA.ToString() + " + " + numB.ToString();
                    key = numA + numB;
                }
                else
                {
                    s = numA.ToString() + " - " + numB.ToString();
                    key = numA - numB;
                }
            }
            else if (questionType == 3)
            {
                numA = rnd.Next(11);
                numB = rnd.Next(21);
                s = numA.ToString() + " x " + numB.ToString();
                key = numA * numB;
            }
            else
                s = "请选择题型";
            return s;
        }

        public bool checkAnswer(int answer)
        {
            if (answer == key)
            {
                rCount++;
                return true;
            }
            else
                return false;
        }
        public string getAnswer()
        {
            return s + " = " + key;
        }
        public string getRate()
        {
            return rCount + " / " + qCount;
        }
    }
}
