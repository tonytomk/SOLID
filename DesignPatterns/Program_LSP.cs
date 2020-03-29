using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class Program_LSP
    {
        public class Rectangle
        {
            //public int Width { get; set; }
            //public int Height { get; set; }
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }
            public Rectangle()
            {

            }

            public Rectangle(int width, int height)
            {
                Width = width;
                Height = height;
            }

            public override string ToString()
            {
                return $"{nameof(Width)} : {Width} , {nameof(Height)} : {Height}  ";
            }
        }

        public class Square: Rectangle
        {
            //public new int Width
            //{
            //    set { base.Width = base.Height = value; }
            //}

            //public new int Height
            //{
            //    set { base.Width = base.Height = value; }
            //}
            public override int Width
            {
                set { base.Width = base.Height = value; }
            }

            public override int Height
            {
                set { base.Width = base.Height = value; }
            }
        }

        //public static void Main(string[] args)
        //{
        //    static int Area(Rectangle r) => r.Width * r.Height;

        //    Rectangle rc = new Rectangle(2,3);
        //    Console.WriteLine($"{rc} has Area {Area(rc)}");

        //    Square sq = new Square();
        //    sq.Width = 4;
        //    Console.WriteLine($"{sq} has Area {Area(sq)}");

        //    Rectangle sq1 = new Square();
        //    sq1.Width = 4;
        //    Console.WriteLine($"{sq1} has Area {Area(sq1)}");
        //}
    }
}
