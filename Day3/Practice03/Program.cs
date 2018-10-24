using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice03
{
    interface IEquatable<T>
    {
        bool Equals(T obj);
    }

    // IEquatable 인터페이스 구현
    public class Emp : IEquatable<Emp>
    {
        public string name { get; set; }
        public int sabun { get; set; }
        // name, sabun이 같을 경우 true 리턴
        public bool Equals(Emp e)
        {
            return (this.name.Equals(e.name) && this.sabun == e.sabun);
        }
    }

    public class Car : IEquatable<Car>
    {
        public string Maker { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        // Implementation of IEquatable<T> interface
        //Maker, Model, Year가 같을 경우 true 리턴
        public bool Equals(Car car)
        {
            return (this.Maker.Equals(car.Maker) &&
                    this.Model.Equals(car.Model) &&
                    this.Year.Equals(car.Year));
        }
    }

    public class Test
    {
        static void Main()
        {
            Car c1 = new Car()
            {
                Maker = "현대",
                Model = "그랜저",
                Year = "2016"
            };

            Car c2 = new Car()
            {
                Maker = "현대",
                Model = "그랜저",
                Year = "2015"
            };

            if (c1.Equals(c2))
            {
                Console.WriteLine("c1와 c2는 같다.");
            }
            else
            {
                Console.WriteLine("c1와 c2는 다르다.");
            }

            Emp e1 = new Emp()
            {
                name = "홍길이",
                sabun = 1004
            };

            Emp e2 = new Emp()
            {
                name = "홍길이",
                sabun = 1004
            };

            if (e1.Equals(e2))
            {
                Console.WriteLine("e1와 e2는 같다.");
            }

            else
            {
                Console.WriteLine("e1와 e2는 다르다.");
            }
        }
    }
}
