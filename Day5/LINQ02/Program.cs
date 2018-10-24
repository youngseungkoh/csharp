using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ02
{
    class OnjProfile
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = { 70, 99, 59, 88, 81, 97 };

            int maxScore = (from score in scores select score).Max();
            Console.WriteLine("최고점수 : {0}", maxScore);

            IEnumerable<int> scoreQuery = from score in scores select score;
            int lowScore = scoreQuery.Min();
            Console.WriteLine("최소점수: {0}", lowScore);

            OnjProfile[] onjProfile =
            {
                new OnjProfile() {Name = "ONJ01", Url = "url01", Age = 7},
                new OnjProfile() {Name = "ONJ02", Url = "url02", Age = 6},
                new OnjProfile() {Name = "ONJ03", Url = "url03", Age = 16},
            };

            var onjs = from onj in onjProfile
                       where onj.Name.Contains("오")
                       orderby onj.Age
                       select new
                       {
                           Name = onj.Name,
                           Url = onj.Url,
                           Age = onj.Age
                       };
            foreach (var o in onjs) Console.WriteLine("{0},{1},{2}", o.Name, o.Url, o.Age);
        }
    }
}
