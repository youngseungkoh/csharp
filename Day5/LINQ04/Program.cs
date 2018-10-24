using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ04
{
    class OnjProfile
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int[] Num { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OnjProfile[] onjProfile =
            {
                new OnjProfile() {Name = "ONJ01", Url = "URL01"}
            }
        }
    }
}
