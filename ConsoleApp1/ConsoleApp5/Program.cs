using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Triangle1
    {
        // 멤버변수 선언
        private int width;
        private int height;
        private int area;

        // 멤버변수를 다룰 속성 선언
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Area // set이 없으므로 읽기 전용 속성이 된다.
        {
            get { return width * height / 2; }
        }

    }

    class Triangle2
    {
        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Area
        {
            get { return Width * Height / 2; }
        }
    }

    public class Test
    {
        static void Main()
        {
            Triangle1 t1 = new Triangle1();
            t1.Width = 6;
            t1.Height = 6;

            Console.WriteLine("밑변은 {0} ", t1.Width);
            Console.WriteLine("높이는 {0} ", t1.Height);
            Console.WriteLine("면적은 {0} ", t1.Area);

            Triangle2 t2 = new Triangle2();
            t2.Width = 8;
            t2.Height = 8;

            Console.WriteLine("밑변은 {0} ", t2.Width);
            Console.WriteLine("높이는 {0} ", t2.Height);
            Console.WriteLine("면적은 {0} ", t2.Area);
        }
    }
}
