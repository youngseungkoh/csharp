using System;
using System.Windows.Forms; // '솔루션 탐색기 - 프로젝트에서 우클릭 - 추가 - 참조'에서 System.Windows.Forms를 체크
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice017
{
    class Program
    {
        static void Main()
        {
            char[] array = new char[5];
            array[0] = 'A';
            array[1] = 'B';
            array[2] = 'C';
            array[3] = 'D';
            array[4] = 'E';
            
            for (int i = 0; i < array.Length; i++){
                MessageBox.Show(array[i].ToString());
                // 결과: A, B, C, D, E 에 대해 MessageBox 출력
            }
            
            Array.Resize(ref array, 3);
            for (int i = 0; i < array.Length; i++)
            {
                MessageBox.Show(array[i].ToString());
                // 결과: A, B, C 에 대해 MessageBox 출력
            }
        }
    }
}
