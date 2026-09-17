using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Prototype_DP
{
    public class ConcretePrototype
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ConcretePrototype Clone() => (ConcretePrototype)this.MemberwiseClone();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== PROTOTYPE PATTERN (LÝ THUYẾT) ===");
            ConcretePrototype p1 = new ConcretePrototype { Id = 1, Name = "Mẫu gốc" };
            ConcretePrototype p2 = p1.Clone();

            Console.WriteLine($"P1: {p1.Id} - {p1.Name}");
            Console.WriteLine($"P2 (Clone): {p2.Id} - {p2.Name}");
            Console.ReadKey();
        }
    }
}
