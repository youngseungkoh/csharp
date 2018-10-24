using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    // 상품 클래스
    class Goods
    {
        public int goodsno { get; set; }
        public string gname { get; set; }
        public int danga { get; set; }

        public Goods(int goodsno, string gname, int danga) // 생성자 (클래스 이름이랑 똑같은데 리턴이 없다)
        {
            this.goodsno = goodsno;
            this.gname = gname;
            this.danga = danga;
        }
        public override String ToString()
        {
            return "Goods [상품번호 = " + goodsno + ", 상품명 = " + gname + ", 단가 = " + danga + "]";
        }
    }

    // 카트 클래스
    class Cart
    {
        public Goods goods { get; set; }
        public int count { get; set; }
        public int sum { get { return count * goods.danga; } set { } }

        public Cart(Goods goods, int count) // 생성자 (클래스 이름이랑 똑같은데 리턴이 없다)
        {
            this.goods = goods;
            this.count = count;
            sum = count * goods.danga;
        }

        public override String ToString()
        {
            return "Cart [Goods = " + goods + ",count = " + count + ",sum = " + sum + "]";
        }
    }


    // 실행 클래스
    class CartTest{
        static void Main(string[] args)
        {
            // 상품코드, 상품명, 단가를 파라메터로 받아서 Goods 클래스를 인스턴스화
            Goods g1 = new Goods(1001, "볼펜", 1000);
            Goods g2 = new Goods(1002, "연필 ", 500);
            Goods g3 = new Goods(1003, "딸기", 6000);
            // Console.WriteLine(g1); // Goods [상품번호 = 1001, 상품명 = 볼펜, 단가 = 1000]

            // 인스턴스화 된 Goods 클래스 객체들을 파라메터로 받아서 Cart 클래스를 인스턴스화
            Cart c1 = new Cart(g1, 2);
            Cart c2 = new Cart(g2, 3);
            Cart c3 = new Cart(g3, 2);
            // Console.WriteLine(c1); // Cart [Goods = Goods [상품번호 = 1001, 상품명 = 볼펜, 단가 = 1000],count = 2,sum = 2000]

            // 해시테이블에 Key,Value로 짝 맞추어 넣음 (이 때 Value 는 c1, c2, c3 같은 인스턴스화 된 object)
            Dictionary<int, Cart> cart = new Dictionary<int, Cart>();
            cart.Add(1, c1);
            cart.Add(2, c2);
            cart.Add(3, c3);

            // 해시테이블 상단의 테이블명을 출력
            Console.WriteLine("CartNo  상품코드  상품명  단가  수량  합계금액");
            Console.WriteLine("----------------------------------------------");

            // 해시테이블에 넣은 값들을 꺼냄
            foreach (KeyValuePair<int, Cart> a in cart)
            {
                Console.WriteLine("{0}       {1}      {2}    {3}   {4}   {5}",
                    a.Key,
                    a.Value.goods.goodsno,
                    a.Value.goods.gname,
                    a.Value.goods.danga,
                    a.Value.count,
                    a.Value.sum
                );
            }
        }
    }
}
