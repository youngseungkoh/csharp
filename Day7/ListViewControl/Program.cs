using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ListViewControl
{
    // 배우들의 정보를 나타탤 Actress 클래스 선언
    public class Actress
    {
        // 배우들의 이름을 담을 string 자료형 변수 name을 선언
        public string name;
        // 배우들의 출생년도를 담을 int 자료형 변수 year를 선언
        public int year;

        // Actress 클래스의 생성자 선언
        public Actress(string name, int year)
        {
            // 인스턴스화 시점에 받는 string 자료형 파라메터 name을 클래스의 멤버변수 this에 할당 
            this.name = name;

            // 인스턴스화 시점에 받는 int 자료형 파라메터 year를 클래스의 멤버변수 year에 할당
            this.year = year;
        }
    }

    // Form 클래스를 상속해서 UI를 보여줄 MForm 클래스를 선언
    class MForm : Form
    {
        // StatusBar 자료형 변수 sb를 선언
        private StatusBar sb;

        // MForm 클래스의 생성자 선언
        public MForm()
        {
            // 상속받은 Form 클래스가 가진 Text 변수에 "ListView"를 할당하여 폼 이름을 초기화
            Text = "ListView";

            // 상속받은 Form 클래스가 가진 Size 클래스를 인스턴스화 하고, Size 변수에 할당하여 폼 크기를 초기화
            Size = new Size(350, 300);

            // Actress 자료형 객체를 담기 위한 제네릭 배열 actresses를 인스턴스화
            List<Actress> actresses = new List<Actress>();

            // Actress 클래스를 인스턴스화 해서 제네릭 배열 actresses에 추가
            actresses.Add(new Actress("Jessica Alba", 1981));
            actresses.Add(new Actress("Angelina Jolie", 1975));
            actresses.Add(new Actress("Natalie Portman", 1981));
            actresses.Add(new Actress("Rachel Weiss", 1971));
            actresses.Add(new Actress("Scarlett Johansson", 1984));

            // namespace Windows.Forms의 ColumnHeader 클래스를 name이라는 이름으로 인스턴스화 
            ColumnHeader name = new ColumnHeader();

            // 객체 name의 Text 변수에 "Name" 할당
            name.Text = "Name";

            // 객체 name의 Width 변수에 -1 할당
            name.Width = -1;

            // namespace Windows.Forms의 ColumnHeader 클래스를 year라는 이름으로 인스턴스화 
            ColumnHeader year = new ColumnHeader();

            // 객체 year의 Text 변수에 "Year" 할당
            year.Text = "Year";

            // Control 클래스가 가진 자원 (역할: ???)
            SuspendLayout();

            // namespace Windows.Forms의 ListView 클래스를 lv라는 이름으로 인스턴스화
            ListView lv = new ListView();

            // 객체 lv의 속성을 설정
            lv.Parent = this;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            // 열의 위치를 드래그해서 옮길 수 있음
            lv.AllowColumnReorder = true;
            // lv.Sorting = SortOrder.Ascending;
            lv.Columns.AddRange(new ColumnHeader[] { name, year });
            lv.ColumnClick += new ColumnClickEventHandler(ColumnClick);

            // 배열 actresses 내부의 모든 Actress 자료형 요소 act에 대해 같은 처리 반복
            foreach(Actress act in actresses)
            {
                // Windows.Forms namespace 내의 ListViewItem 클래스를 item 이라는 이름으로 인스턴스화
                ListViewItem item = new ListViewItem();

                // Actress 자료형 객체 act의 name 속성을 ListViewItem 자료형 객체 item의 Text에 할당
                item.Text = act.name;

                // 객체 act의 변수 year를 문자열로 바꿔서 객체 item의 SubItems에 추가
                item.SubItems.Add(act.year.ToString());

                // 객체 lv 의 변수 Items에 객체 item을 추가 
                lv.Items.Add(item);
            }
            // lv가 윈도우 창 사방면에 딱 붙게 됨 (어디다가 붙일지를 결정)
            lv.Dock = DockStyle.Fill;
            lv.Click += new EventHandler(OnChanged);

            sb = new StatusBar();
            sb.Parent = this;
            lv.View = View.Details;

            ResumeLayout();

            CenterToScreen();
        }

        void OnChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string name = lv.SelectedItems[0].SubItems[0].Text;
            string born = lv.SelectedItems[0].SubItems[1].Text;
            sb.Text = name + ", " + born;
        }

        void ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = (ListView)sender;

            if(lv.Sorting == SortOrder.Ascending)
            {
                lv.Sorting = SortOrder.Descending;
            }
            else { lv.Sorting = SortOrder.Ascending; }
        }
    }

    // 기동 클래스 선언
    class MApplication
    {
        // 기동 메서드 선언
        public static void Main()
        {
            // MForm 클래스를 인스턴스화 하고, Run 메서드를 이용해 바로 실행
            Application.Run(new MForm());
        }
    }
}
