using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice014
{
    class Program
    {
        // Returns an array of integers.
        // 길이가 5인 정수 자료형 배열을 반환하는 메서드를 선언하고 초기화
        static int[] GetEmployeeIds(){
            int[] employees = new int[5];
            employees[0] = 1;
            employees[1] = 3;
            employees[2] = 5;
            employees[3] = 7;
            employees[4] = 8;
            return employees;
        }

        static void Main(){
            // Loop over array of integers.
            // 반복문을 활용한 배열 출력 1 (foreach)
            foreach (int id in GetEmployeeIds())
            {
                Console.WriteLine(id);
            }

            // Loop over array of integers.
            // 반복문을 활용한 배열 출력 2 (for)
            int[] employees = GetEmployeeIds();
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }
    }
}
