using System;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Abstract_DP
{
    public interface IAbstractProductA { string UsefulFunctionA(); }
    public class ConcreteProductA1 : IAbstractProductA { public string UsefulFunctionA() => "Kết quả Sản phẩm A1"; }
    public class ConcreteProductA2 : IAbstractProductA { public string UsefulFunctionA() => "Kết quả Sản phẩm A2"; }

    public interface IAbstractProductB { string UsefulFunctionB(); }
    public class ConcreteProductB1 : IAbstractProductB { public string UsefulFunctionB() => "Kết quả Sản phẩm B1"; }
    public class ConcreteProductB2 : IAbstractProductB { public string UsefulFunctionB() => "Kết quả Sản phẩm B2"; }

    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA() => new ConcreteProductA1();
        public IAbstractProductB CreateProductB() => new ConcreteProductB1();
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA() => new ConcreteProductA2();
        public IAbstractProductB CreateProductB() => new ConcreteProductB2();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== ABSTRACT FACTORY PATTERN (LÝ THUYẾT) ===");
            IAbstractFactory factory = new ConcreteFactory1();
            Console.WriteLine(factory.CreateProductA().UsefulFunctionA());
            Console.WriteLine(factory.CreateProductB().UsefulFunctionB());
            Console.ReadKey();
        }
    }
}
