using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Factory_DP
{
    public interface IProduct { string Operation(); }
    public class ConcreteProductA : IProduct { public string Operation() => "Sản phẩm A"; }
    public class ConcreteProductB : IProduct { public string Operation() => "Sản phẩm B"; }

    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();
        public string AnOperation() => "Creator thực thi: " + FactoryMethod().Operation();
    }

    public class ConcreteCreatorA : Creator { public override IProduct FactoryMethod() => new ConcreteProductA(); }
    public class ConcreteCreatorB : Creator { public override IProduct FactoryMethod() => new ConcreteProductB(); }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== FACTORY METHOD PATTERN (LÝ THUYẾT) ===");
            Creator creator = new ConcreteCreatorA();
            Console.WriteLine(creator.AnOperation());
            Console.ReadKey();
        }
    }
}
