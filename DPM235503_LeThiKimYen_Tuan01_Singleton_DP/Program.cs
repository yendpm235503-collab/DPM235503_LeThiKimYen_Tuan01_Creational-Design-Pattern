using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Singleton_DP
{
    public sealed class Singleton
    {
        private Singleton() { }
        private static Singleton _instance;
        private static readonly object _lock = new object();

        public static Singleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        public string Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("--- SINGLETON PATTERN (LÝ THUYẾT) ---");
            Singleton s1 = Singleton.GetInstance("Giá trị 1");
            Singleton s2 = Singleton.GetInstance("Giá trị 2");

            Console.WriteLine($"s1 value: {s1.Value}");
            Console.WriteLine($"s2 value: {s2.Value}");
            Console.ReadKey();
        }
    }
}