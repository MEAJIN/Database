using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hyejin_DB
{
    public partial class 결제완료 : Form
    {
        public DataGridViewRow[] dr;
        int dr_num;
        public 결제완료()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void bokk()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "도서번호";
            dataGridView1.Columns[1].Name = "도서명";
            dataGridView1.Columns[2].Name = "구매량";
            dataGridView1.Columns[3].Name = "가격";

            for (int i = 0; i < dr_num; i++)
            {
                object[] tmp = new object[dataGridView1.ColumnCount];
                for (int j = 0; j < dataGridView1.ColumnCount ; j++)
                {
                    tmp[j] = new object();
                    tmp[j] = dr[i].Cells[j].Value.ToString();

                }
                dataGridView1.Rows.Add(tmp);
            }
        }
        public void Getbook(DataGridViewRow[] dr, int dr_num)
        {
            this.dr = dr;
            this.dr_num = dr_num;
        }
        public void GetOb(object[] ob,int n)
        {
            textBox10.Text = ob[0].ToString();
            textBox4.Text = ob[1].ToString();
            textBox2.Text = ob[2].ToString();
            textBox5.Text = ob[3].ToString();
            textBox3.Text = ob[4].ToString();
            textBox6.Text = ob[5].ToString();
        }

        private void 결제완료_Load(object sender, EventArgs e)
        {
            bokk();
        }
    }
}
