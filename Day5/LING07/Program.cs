using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ07
{
    class OnjProfile
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OnjProfile[] onjProfile =
            {
                new OnjProfile() { Name="ONJ01", Age = 8 },
                new OnjProfile() { Name="ONJ02", Age = 8 },
                new OnjProfile() { Name="ONJ03", Age = 8 },
                new OnjProfile() { Name="ONJ04", Age = 8 },
                new OnjProfile() { Name="ONJ05", Age = 8 },

            }
        }
    }
}

// LINQ(GROUP BY 02)