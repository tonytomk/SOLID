using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPatterns
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
            Color = color;
            Size = size;
        }

    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);

    }

    interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecifications : ISpecification<Product>
    {
        private Color color;
        public ColorSpecifications(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
           return t.Color == color;
        }
    }


    public class SizeSpecification: ISpecification<Product>
    {
        private Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class AndSpecification<T>: ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first , ISpecification<T> second)
        {
            this.first = first ??  throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(first));
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }



    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                    yield return p;
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Color color,
            Size size)
        {
            foreach (var p in products)
            {
                if (p.Color == color && p.Size == size)
                    yield return p;
            }

        }
    }


    public class BetterFilter: IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach(var p in items)
            {
                if (spec.IsSatisfied(p))
                    yield return p;
            }
        }

    }


        class Program_OCP
        {

        //    static void Main(string[] args)
        //    {
        //        var apple = new Product("Apple", Color.Green, Size.Small);
        //        var tree = new Product("Tree", Color.Green, Size.Large);
        //        var house = new Product("House", Color.Blue, Size.Large);

        //        Product[] products = { apple, tree, house };

        //        var pf = new ProductFilter();
        //        Console.WriteLine("Green produst (old) :");
        //        foreach (var p in pf.FilterByColor(products, Color.Green))
        //        {
        //            Console.WriteLine($" - {p.Name} is green");
        //        }

        //        var bf = new BetterFilter();
        //        Console.WriteLine("Green produst (new) :");
        //        foreach (var p in bf.Filter(products, new ColorSpecifications(Color.Green)))
        //        {
        //        Console.WriteLine($" - {p.Name} is green");
        //        }

        //        Console.WriteLine("Large blue items");
        //        foreach (var p in bf.Filter(products, new AndSpecification<Product>(
        //            new ColorSpecifications(Color.Blue),
        //            new SizeSpecification(Size.Large))))
        //        {
        //            Console.WriteLine($" - {p.Name} is big and blue");
        //        }
        //}


        }
    }

