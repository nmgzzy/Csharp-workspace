using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                Operation op;
                op = OperationFactory.createOperation(comboBoxOp.SelectedItem.ToString());
                op.Num1 = double.Parse(textBoxNum1.Text);
                op.Num2 = double.Parse(textBoxNum2.Text);
                textBoxResult.Text = op.GetResult().ToString();
            }
            catch(Exception ex)
            {
                textBoxResult.Text = "Error:" + ex;
            }
        }
    }

    public class OperationFactory
    {

        public static Operation createOperation(string operate)
        {
            Operation op = null;
            switch(operate)
            {
                case "+":
                    op = new OperationAdd();
                    break;
                case "-":
                    op = new OperationSub();
                    break;
                case "*":
                    op = new OperationMul();
                    break;
                case "/":
                    op = new OperationDiv();
                    break;
                default:
                    throw new Exception("没有该运算符");
            }
            return op;
        }
    }
    public class Operation
    {
        private double num1 = 0;
        private double num2 = 0;
        public double Num1
        {
            get { return num1; }
            set { num1 = value; }
        }
        public double Num2
        {
            get { return num2; }
            set { num2 = value; }
        }

        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }
    public class OperationAdd : Operation
    {
        public override double GetResult()
        {
            double result;
            result = Num1 + Num2;
            return result;
        }
    }
    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            double result;
            result = Num1 - Num2;
            return result;
        }
    }
    public class OperationMul : Operation
    {
        public override double GetResult()
        {
            double result;
            result = Num1 * Num2;
            return result;
        }
    }
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result;
            if (Num2 == 0)
                throw new Exception("除数不能为0");
            result = Num1 / Num2;
            return result;
        }
    }
}
