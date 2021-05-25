using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        /// <summary>
        /// 后者性能高于前者:
        /// Thread < ThreadPoll < Task < Async await
        /// </summary>
        static void Main()
        {
            //ThreadTest.TestThread();
            //ThreadJoin.TestJoin();
            //MatrixParallelCalculate.TestParCalMat();
            //ParallelCalculate.TestParCal();
            //ThreadTest.TestTask();
            AsyncAndAwait.TestAsyncAwait();
        }
    }
    /// <summary>
    /// 测试多线程基本用法
    /// Thread thread1 = new Thread(new ThreadStart(线程1函数));
    /// thread1.Start();
    /// </summary>
    public class ThreadTest
    {
        private int cnt = 0;
        private static Random sleepTimeRnd = new Random();
        private static int SleepTime()
        {
            return sleepTimeRnd.Next(100, 300);
        }
        public static void TestThread()
        {
            ThreadTest obj1 = new ThreadTest();
            Thread thread1 = new Thread(new ThreadStart(obj1.Count));
            thread1.Name = "线程1";
            ThreadTest obj2 = new ThreadTest();
            Thread thread2 = new Thread(new ThreadStart(obj2.Count));
            thread2.Name = "\t\t线程2";
            Thread thread3 = new Thread(new ThreadStart(obj2.Count));
            thread3.Name = "\t\t\t\t线程3";
            thread1.Start();
            thread2.Start();
            thread3.Start();

            //等待该线程执行完
            //thread.Join();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\t" + i);
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 使用线程池
        /// </summary>
        public static void TestTask()
        {
            ThreadTest obj1 = new ThreadTest();
            ThreadTest obj2 = new ThreadTest();
            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = Task.Run(() => obj1.Count(1));
            tasks[1] = Task.Run(() => obj2.Count(2));
            tasks[2] = Task.Run(() => obj2.Count(3));
            
            Task.WaitAll(tasks);
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine(tasks[i].Result);
            }
        }

        private void Count()
        {
            while (cnt < 10)
            {
                lock (this)
                {
                    cnt++;
                    Console.WriteLine(Thread.CurrentThread.Name + " 数到 " + cnt);
                }
                Thread.Sleep(SleepTime());
            }
        }
        private int Count(int num)
        {
            string t = new string('\t', num);
            while (cnt < 10)
            {
                lock (this)
                {
                    cnt++;
                    Console.WriteLine(t + "线程" + num + " 数到 " + cnt);
                }
                Thread.Sleep(SleepTime());
            }
            return num + 10;
        }
    }
    /// <summary>
    /// ThreadJoin测试
    /// Blocks the calling thread until the thread represented by this instance terminates,
    ///   while continuing to perform standard COM and SendMessage pumping.
    /// </summary>
    public class ThreadJoin
    {
        public static void TestJoin()
        {
            Runner r = new Runner();
            Thread thread = new Thread(r.run);
            thread.Start();
            thread.Join();//等待该线程执行完
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\t" + i);
                Thread.Sleep(100);
            }
        }
        public class Runner
        {
            public void run()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
            }
        }
    }

    /// <summary>
    /// 并行矩阵计算
    /// public static ParallelLoopResult For(int fromInclusive, int toExclusive, Action<int> body);
    /// </summary>
    public class MatrixParallelCalculate
    {
        public static void TestParCalMat()
        {
            int m = 100, n = 400, t = 1000;
            double[,] ma = new double[m, n];
            double[,] mb = new double[n, t];
            double[,] r1 = new double[m, t];
            double[,] r2 = new double[m, t];
            InitMatrix(ma);
            InitMatrix(mb);
            InitMatrix(r1);
            InitMatrix(r2);

            Console.WriteLine("矩阵乘法");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MultiMatrixNormal(ma, mb, r1);
            sw.Stop();
            Console.WriteLine("普通方法用时" + sw.ElapsedMilliseconds);

            sw.Restart();
            MultiMatrixParallel(ma, mb, r2);
            sw.Stop();
            Console.WriteLine("并行方法用时" + sw.ElapsedMilliseconds);

            bool ok = CompareMatrix(r1, r2);
            Console.WriteLine("结果相同" + ok);
        }
        static Random rnd = new Random();
        static void InitMatrix(double[,] matA)
        {
            int m = matA.GetLength(0);
            int n = matA.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matA[i, j] = rnd.Next();
                }
            }
        }
        static void MultiMatrixNormal(double[,] matA, double[,] matB, double[,] result)
        {
            int m = matA.GetLength(0);
            int n = matA.GetLength(1);
            int t = matB.GetLength(1);
            //Console.WriteLine(m+","+n+","+t);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < t; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < n; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] = temp;
                }
            }
        }
        static void MultiMatrixParallel(double[,] matA, double[,] matB, double[,] result)
        {
            int m = matA.GetLength(0);
            int n = matA.GetLength(1);
            int t = matB.GetLength(1);

            Parallel.For(0, m, i =>
            {
                for (int j = 0; j < t; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < n; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] = temp;
                }
            });
        }
        static bool CompareMatrix(double[,] matA, double[,] matB)
        {
            int m = matA.GetLength(0);
            int n = matA.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(matA[i, j] - matB[i, j]) > 0.1) return false;
                }
            }
            return true;
        }
    }
    /// <summary>
    /// 并行计算查询
    /// </summary>
    public class ParallelCalculate
    {
        const int count = 1000000;
        public static void TestParCal()
        {
            var dic = LoadData();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //串行运算
            var query1 = (from n in dic.Values
                          where n.Age > 20 && n.Age < 25
                          select n).ToList();
            watch.Stop();
            Console.WriteLine("串行计算耗费时间：{0}", watch.ElapsedMilliseconds);
            watch.Restart();
            //并行运算
            var query2 = (from n in dic.Values.AsParallel()
                          where n.Age > 20 && n.Age < 25
                          select n).ToList();
            
            watch.Stop();
            Console.WriteLine("并行计算耗费时间：{0}", watch.ElapsedMilliseconds);
            Console.Read();
        }
        public static ConcurrentDictionary<int, Student> LoadData()
        {
            ConcurrentDictionary<int, Student> dic =
                new ConcurrentDictionary<int, Student>();

            Parallel.For(0, count, (i) => {
                var single = new Student()
                {
                    ID = i,
                    Name = "n" + i,
                    Age = i % 151,
                    //CreateTime = DateTime.Now.AddSeconds(i)
                };
                dic.TryAdd(i, single);
            });
            return dic;
        }
        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime CreateTime { get; set; }
        }
    }
    /// <summary>
    /// 异步编程使用async和await
    /// 方法使用Async修饰符修饰.
    /// 返回类型仅有三种: void,Task,Task<T>
    /// 方法内部使用await关键字标明开始执行异步代码
    /// await标志前的代码是同步执行,await标志的方法是异步执行,
    /// await标志的方法后面的代码相当于"回调函数",
    /// 在await标志的异步方法后面执行.
    /// </summary>
    public class AsyncAndAwait
    {
        static Stopwatch sw = new Stopwatch();
        Task<double> FacAsync(int n)
        {
            return Task<double>.Run(() => {
                double s = 1;
                for (int i = 1; i < n; i++)
                {
                    s = s + i;
                    Thread.Sleep(100);
                }
                return s;
            });
        }
        public async void testAsync(int a)
        {
            // 调用异步方法
            double result = await FacAsync(a);
            Console.WriteLine(result); //想想这句在哪个线程
            Console.WriteLine(a + "用时" + sw.ElapsedMilliseconds);
        }
        public static void TestAsyncAwait()
        {
            sw.Start();
            new AsyncAndAwait().testAsync(10);
            new AsyncAndAwait().testAsync(30);
            Console.WriteLine("我在后面但是我先执行");
            Console.ReadKey();
            sw.Stop();
        }
    }
}