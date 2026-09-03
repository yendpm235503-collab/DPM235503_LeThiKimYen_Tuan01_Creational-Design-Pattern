using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Prototype_DP
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person ShallowCopy() => (Person)this.MemberwiseClone();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("--- PROTOTYPE PATTERN (LÝ THUYẾT) ---");
            Person p1 = new Person { Age = 20, Name = "An Giang" };
            Person p2 = p1.ShallowCopy();

            Console.WriteLine($"P1: {p1.Name}, {p1.Age}");
            Console.WriteLine($"P2 (Sao chép): {p2.Name}, {p2.Age}");
            Console.ReadKey();
        }
    }
}