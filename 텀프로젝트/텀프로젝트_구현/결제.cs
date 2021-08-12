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
    public partial class 결제 : Form
    {
        OleDbConnection conn;
        public Event_Multy_object data2array;
        public Event_Multy_Book bookInfo;
        string connectionString;
        object[] dat = new object[7];
        string userid;
        string addr, card, order_num;
        public DataGridViewRow[] dr;
        int dr_num,sum;
        public 결제()
        {
            InitializeComponent();
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
            
        }
        public void bokk()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "도서번호";
            dataGridView1.Columns[1].Name = "도서명";
            dataGridView1.Columns[2].Name = "재고량";
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
        public void sumV()
        {
            sum = 0;
            for (int i = 0; i < dr_num; i++)
            {          
                sum += Int32.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());              
            }
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 결제_Load(object sender, EventArgs e)
        {
            bokk();
            textBox2.Text = card;
            sumV();
            textBox7.Text = sum.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select 유효기간,카드종류,우편번호,기본주소,상세주소 from (select 유효기간,카드종류 from 카드 where 회원번호 = '" + userid + "' and 카드번호= '" + card + "') ,(select 우편번호,기본주소,상세주소 from 주소록 where 회원번호 = '" + userid + "' and 배송지='" + addr + "')"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                cmd.CommandText = "insert into 주문 values(to_char(sysdate,'yyyymmdd')|| to_char(e_n.nextval, 'FM000'),sysdate," + sum + ",'신청','" + card + "','"+ read.GetDateTime(0).ToString().Substring(0, 10) + "','"+ read.GetString(1) + "','" + read.GetString(2) + "','" + read.GetString(3) + "','" + read.GetString(4) + "','"+userid+"')"; 
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
            }
            read.Close();
            read = cmd.ExecuteReader();

            cmd.CommandText = "select max(주문번호) from 주문";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            read.Close();
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                dat[0] = new object();
                order_num = read.GetString(0);
                dat[0] = read.GetString(0);
            }
            cmd.CommandText = "select * from 주문 where 주문번호 ='"+ dat[0].ToString()+ "'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            read.Close();
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                dat[1] = new object();
                dat[1] = read.GetDateTime(1).ToString();
                dat[2] = new object();
                dat[2] = read.GetString(4) + read.GetString(6);
                dat[3] = new object();
                dat[3] = read.GetString(7) + read.GetString(8);
                dat[4] = new object();
                dat[4] = read.GetDecimal(2).ToString();
                dat[5] = new object();
                dat[5] = read.GetString(3);
            }
            for (int i = 0; i < dr_num; i++)
            {
                cmd.CommandText = "insert into 주문_선택 values('"+order_num+"','"+dr[i].Cells[0].Value.ToString()+ "'," + Int32.Parse(dr[i].Cells[2].Value.ToString()) + "," + Int32.Parse(dr[i].Cells[3].Value.ToString()) + ")";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                read.Close();
                read = cmd.ExecuteReader();
            }
            결제완료 D = new 결제완료();
            this.data2array += new Event_Multy_object(D.GetOb);
            this.bookInfo += new Event_Multy_Book(D.Getbook);
            data2array(dat,6);
            bookInfo(dr, dr_num);
            D.Show();
            this.Hide();
        }

        public void GetCA(string C, string A)
        {
            card = C;
            addr = A;
        }
    }
}
