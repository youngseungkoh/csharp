using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewControlWinForm
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();

            List<Actress> actresses = new List<Actress>();

            actresses.Add(new Actress("Jessica Alba", 1981));
            actresses.Add(new Actress("Angelina Jolie", 1975));
            actresses.Add(new Actress("Natalie Portman", 1981));
            actresses.Add(new Actress("Rachel Weiss", 1971));
            actresses.Add(new Actress("Scarlett Johansson", 1984));

            foreach (Actress act in actresses)
            {
                ListViewItem item = new ListViewItem();

                item.Text = act.name;
                item.SubItems.Add(act.year.ToString());
                lv.Items.Add(item);
            }
        }

        private void ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = (ListView)sender;

            if (lv.Sorting == SortOrder.Ascending)
            {
                lv.Sorting = SortOrder.Descending;
            }
            else { lv.Sorting = SortOrder.Ascending; }
        }

        private void OnChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string name = lv.SelectedItems[0].SubItems[0].Text;
            string year = lv.SelectedItems[0].SubItems[1].Text;
            sb.Text = name + ", " + year;
        }
    }

    public class Actress
    {
        public string name;
        public int year;

        public Actress(string name, int year)
        {
            this.name = name;
            this.year = year;
        }
    }
}
