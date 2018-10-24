using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice015
{
    class Employee
    {
        // Int array reference at class level.
        // 정수 자료형 배열 선언
        int[] _teams;

        // Create new employee.
        // 호출시 teams를 파라메터로 받는 메서드 Employee를 선언
        public Employee(int[] teams){
            _teams = teams;
        }

        // Get array of teams.
        // 호출시 _teams를 반환하는 메서드 Teams를 선언
        public int[] Teams{
            get{
                return _teams;
            }
        }
    }

    class Program
    {
        static void Main(){
            // 정수형 배열을 선언한 후 초기화
            int[] teams = new int[3];
            teams[0] = 1;
            teams[1] = 2;
            teams[2] = 3;
            
            // 정수형 배열의 참조 주소를 저장하는 새 객체 생성
            Employee employee = new Employee(teams);
            
            // 반복문(foreach)을 사용하여 생성된 새 객체 내의 정수형 자료 출력
            foreach (int team in employee.Teams)
            {
                Console.WriteLine(team);
            }
        }
    }
}
