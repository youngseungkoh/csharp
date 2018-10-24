using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Example
    {
        public static void Main()
        {
            Hashtable onj = new Hashtable();
            onj.Add("김길동", "서울");
            onj.Add("홍길동", "광주");
            onj.Add("박길동", "부산");

            try
            {
                onj.Add("김길동", "서울");
            }
            catch
            {
                Console.WriteLine("키 값이 중복되었습니다.");
            }
            Console.WriteLine("For key = \"name\", value = {0}.", onj["홍길동"]);
            onj["박길동"] = "제주";
            Console.WriteLine("For key = \"name\", value = {0}.", onj["박길동"]);
            
            if(!onj.ContainsKey("최길동"))
            {
                onj.Add("최길동", "하와이");
                Console.WriteLine("Value added for key = \"who\": {0}", onj["최길동"]);
            }
            Console.WriteLine();

            foreach(DictionaryEntry d in onj)
            {
                Console.WriteLine("Key = {0}, Value = {1}", d.Key, d.Value);
            }

            Console.WriteLine("\n===============================================\n");

            SortedList s = new SortedList(onj);

            foreach(DictionaryEntry d in s)
            {
                Console.WriteLine("Key = {0}, Value = {1}", d.Key, d.Value);
            }

            Console.WriteLine("\n===============================================\n");
        }
    }
}
