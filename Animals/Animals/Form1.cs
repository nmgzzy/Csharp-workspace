using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animals
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            Cat cat = new Cat("咪咪");
            cat.ShoutNum = 15;
            MessageBox.Show(cat.Shout());
        }

        private void btnDog_Click(object sender, EventArgs e)
        {
            Dog dog = new Dog("旺财");
            MessageBox.Show(dog.Shout());
        }
        private Animal[] animalArray;
        private void btnSign_Click(object sender, EventArgs e)
        {
            animalArray = new Animal[5];
            animalArray[0] = new Cat("小花");
            animalArray[1] = new Dog("小黑");
            animalArray[2] = new Sheep("小羊");
            animalArray[3] = new Dog("小黄");
            animalArray[4] = new Cat("咪咪");
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            foreach(Animal item in animalArray)
            {
                MessageBox.Show(item.Shout());
            }
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            Cat cat = new Cat("小花");
            Dog dog = new Dog("小黑");
            Sheep sheep = new Sheep("小羊");
            IJump[] jumpArr = new IJump[3];
            jumpArr[0] = cat;
            jumpArr[1] = dog;
            jumpArr[2] = sheep;
            IRun[] myrun = new IRun[1];
            myrun[0] = sheep;
            MessageBox.Show(jumpArr[0].Jump("5"));
            MessageBox.Show(jumpArr[1].Jump("3"));
            MessageBox.Show(jumpArr[2].Jump("8"));
            MessageBox.Show(myrun[0].Run("100"));
        }
    }

    abstract class Animal
    {
        protected string name = "";
        public Animal(string name)
        {
            this.name = name;
        }
        public Animal()
        {
            this.name = "无名";
        }
        protected int shoutNum = 3;
        public int ShoutNum
        {
            get
            {
                return shoutNum;
            }
            set
            {
                shoutNum = value <= 10 ? value : 10;
                shoutNum = shoutNum > 0 ? shoutNum : 1;
            }
        }
        public string Shout()
        {
            string result = "";
            for (int i = 0; i < shoutNum; i++)
            {
                result += GetShoutSound();
            }
            return "我叫" + name + "  " + result;
        }
        protected abstract string GetShoutSound();
    }
    class Cat : Animal, IJump
    {
        public Cat() : base()
        { }
        public Cat(string name) : base(name)
        { }
        protected override string GetShoutSound()
        {
            return "喵 ";
        }
        public string Jump(string distance)
        {
            return base.Shout() + ", 我能跳" + distance + "米。";
        }
    }
    class Dog : Animal, IJump
    {
        public Dog() : base()
        { }
        public Dog(string name) : base(name)
        { }
        protected override string GetShoutSound()
        {
            return "汪 ";
        }
        public string Jump(string distance)
        {
            return base.Shout() + ", 我能跳" + distance + "米。";
        }
    }
    class Sheep : Animal, IJump, IRun
    {
        public Sheep() : base()
        { }
        public Sheep(string name) : base(name)
        { }
        protected override string GetShoutSound()
        {
            return "咩 ";
        }
        public string Jump(string distance) 
        {
            return base.Shout() + ", 我能跳" + distance + "米。";
        }
        public string Run(string distance)
        {
            return base.Shout() + ", 我能跑" + distance + "米。";
        }
        public string Walk(string distance)
        {
            return base.Shout() + ", 我能走" + distance + "米。";
        }
    }
    interface IJump
    {
        string Jump(string distance);
    }
    interface IRun
    {
        string Run(string distance);
    }
}
