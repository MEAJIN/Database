using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace hyejin_DB
{
    public partial class 결제확인 : Form
    {
        OleDbConnection conn;
        string connectionString;
        string userid;
        string addr, card;
        int sum;
        public Event_Multy_Book bookInfo;
        public Event_One_Data data2one;
        public Event_Two_Data data2two;
        public DataGridViewRow[] dr;
        int dr_num;
        public 결제확인()
        {
            InitializeComponent();
            checkBox4.Checked = true;
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
        }
        public void Getbook(DataGridViewRow[] dr, int dr_num)
        {
            this.dr = dr;
            this.dr_num = dr_num;
        }
        public void Getid(string id)
        {
            userid = id;
        }
        public void bokk()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "도서번호";
            dataGridView1.Columns[1].Name = "도서명";
            dataGridView1.Columns[2].Name = "구매량";
            dataGridView1.Columns[3].Name = "가격";
            sum = 0;
            for (int i = 0; i < dr_num; i++)
            {
                object[] tmp = new object[dataGridView1.ColumnCount];
                tmp[0] = new object();
                tmp[0] = dr[i].Cells[0].Value.ToString();
                tmp[1] = new object();
                tmp[1] = dr[i].Cells[1].Value.ToString();
                tmp[2] = new object();
                tmp[2] = dr[i].Cells[4].Value.ToString();
                tmp[3] = new object();
                tmp[3] = dr[i].Cells[3].Value.ToString();



                sum += Int32.Parse(tmp[2].ToString())* Int32.Parse(tmp[3].ToString());
                dataGridView1.Rows.Add(tmp);
            }
            textBox7.Text = sum.ToString();
            textBox14.Text = userid;

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select 메일,핸드폰번호 from 회원 where 회원번호 = '" + userid + "'"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                textBox15.Text = read.GetString(0);
                textBox13.Text = read.GetString(1);

            }
            read.Close();
            cmd.CommandText = "select 기본주소 ,상세주소 from 주소록 where 회원번호='" + userid + "'and 배송지  ='"+ addr +"'"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            read = cmd.ExecuteReader(); //select 
            if (read.Read())
            {
                textBox1.Text = read.GetString(0);
                textBox1.Text += read.GetString(1);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 결제확인_Load(object sender, EventArgs e)
        {
            bokk();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox4.Checked = false;
            }
            else checkBox4.Checked = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox3.Checked = false;
            }
            else checkBox3.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            주문 O = new 주문();
            this.bookInfo = new Event_Multy_Book(O.Getbook);
            this.data2one = new Event_One_Data(O.Getid);
            data2one(userid);
            bookInfo(dr, dr_num);
            O.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)//결제
        {
            for (int i = 0; i < dr_num; i++)
            {
                dr[i] = dataGridView1.Rows[i];
            }
            결제 P = new 결제();
            this.bookInfo = new Event_Multy_Book(P.Getbook);
            this.data2one = new Event_One_Data(P.Getid);
            this.data2two = new Event_Two_Data(P.GetCA);
            data2one(userid);
            bookInfo(dr, dr_num);
            data2two(card, addr);
            P.Show();
            this.Hide();
        }

        public void GetCA(string C,string A)
        {
            card = C;
            addr = A;
        }
    }
}
