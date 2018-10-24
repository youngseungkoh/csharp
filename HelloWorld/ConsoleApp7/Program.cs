using System;

namespace ConsoleApp5

{

    class Program

    {

        static void Main(string[] args)

        {

            int[] a = new int[5] { 10, 20, 30, 40, 50 };

            unsafe

            {

                fixed (int* p = &a[0])

                {

                    // p is pinned as well as object, so create another pointer to show incrementing it.

                    int* p2 = p;

                    Console.WriteLine(*p2);

                    // Incrementing p2 bumps the pointer by four bytes due to its type ...

                    p2 += 1;

                    Console.WriteLine(*p2);

                    p2 += 1;

                    Console.WriteLine(*p2);

                    Console.WriteLine("--------");

                    Console.WriteLine(*p);

                    // Dereferencing p and incrementing changes the value of a[0] ...

                    *p += 1;

                    Console.WriteLine(*p);

                    *p += 1;

                    Console.WriteLine(*p);

                }

            }

        }

    }

}