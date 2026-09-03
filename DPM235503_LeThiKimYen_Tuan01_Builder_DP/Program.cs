using System;
using System.Collections.Generic;
using System.Text;

namespace DPM235503_LeThiKimYen_Tuan01_Builder_DP
{
    public class Product
    {
        private List<object> _parts = new List<object>();
        public void Add(string part) => _parts.Add(part);
        public string ListParts() => "Thành phần sản phẩm: " + string.Join(", ", _parts);
    }

    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();
        public ConcreteBuilder() => Reset();
        public void Reset() => _product = new Product();
        public void BuildPartA() => _product.Add("Thành phần A");
        public void BuildPartB() => _product.Add("Thành phần B");
        public void BuildPartC() => _product.Add("Thành phần C");

        public Product GetProduct()
        {
            Product result = _product;
            Reset();
            return result;
        }
    }

    public class Director
    {
        private IBuilder _builder;
        public IBuilder Builder { set => _builder = value; }

        public void BuildMinimalViableProduct() => _builder.BuildPartA();
        public void BuildFullFeaturedProduct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("--- BUILDER PATTERN (LÝ THUYẾT) ---");
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Sản phẩm cơ bản:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Sản phẩm đầy đủ:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());
            Console.ReadKey();
        }
    }
}