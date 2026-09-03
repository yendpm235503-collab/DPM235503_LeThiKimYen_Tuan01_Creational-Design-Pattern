using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Factory_DP
{
    public interface IProduct
    {
        string Operation();
    }

    public class ConcreteProduct1 : IProduct
    {
        public string Operation() => "{Kết quả từ ConcreteProduct1}";
    }

    public class ConcreteProduct2 : IProduct
    {
        public string Operation() => "{Kết quả từ ConcreteProduct2}";
    }

    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            var product = FactoryMethod();
            return "Creator: " + product.Operation();
        }
    }

    public class ConcreteCreator1 : Creator
    {
        public override IProduct FactoryMethod() => new ConcreteProduct1();
    }

    public class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod() => new ConcreteProduct2();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("--- FACTORY METHOD PATTERN (LÝ THUYẾT) ---");
            Creator creator1 = new ConcreteCreator1();
            Console.WriteLine(creator1.SomeOperation());

            Creator creator2 = new ConcreteCreator2();
            Console.WriteLine(creator2.SomeOperation());
            Console.ReadKey();
        }
    }
}