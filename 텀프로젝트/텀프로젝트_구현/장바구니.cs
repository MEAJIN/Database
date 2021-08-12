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
    public partial class 장바구니 : Form

    {
        public Event_One_Data 장바구니에서;
        public Event_Multy_Book bookInfo;
        public Event_One_Data data2where;
        string userid;
        string username;
        string jangnum;
        public DataGridViewRow[] dr;
        int dr_num;
        OleDbConnection conn;
        string connectionString;
        public 장바구니()
        {
            InitializeComponent();
            jangnum = "";
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
        }
        public void getidname(string id, string name)
        {
            userid = id;
            username = name;
            bakk();
            bakl();

        }
        public void bakl()
        {
            dataGridView2.Rows.Clear();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from 장바구니_담기 where 바구니번호 ='" + jangnum + "'"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
            dataGridView2.ColumnCount = 3;
      
            for (int i = 0; i < 3; i++)
            {
                dataGridView2.Columns[i].Name = read.GetName(i);
            }
            //행 단위로 반복
            while (read.Read())
            {
                object[] obj = new object[3]; // 필드수만큼 오브젝트 배열

                for (int i = 0; i < 3; i++) // 필드 수만큼 반복
                {
                    obj[i] = new object();
                    obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                }
                dataGridView2.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가               
            }

            read.Close();

        }
        public void bakk()
        {
            dataGridView3.Rows.Clear();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from 장바구니 where 회원번호 ='" + userid + "'"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
            dataGridView3.ColumnCount = 2;
            for (int i = 0; i < 2; i++)
            {
                dataGridView3.Columns[i].Name = read.GetName(i);
            }
            //행 단위로 반복
            while (read.Read())
            {
                object[] obj = new object[2]; // 필드수만큼 오브젝트 배열

                for (int i = 0; i < 2; i++) // 필드 수만큼 반복
                {
                    obj[i] = new object();
                    obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                }
                dataGridView3.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                if (jangnum.Equals(""))
                {
                    jangnum = dataGridView3.Rows[0].Cells[0].Value.ToString();
                }

            }
            read.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into 장바구니 values(to_char(B_N.nextval,'FM000'),sysdate,'" + userid + "')";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            bakk();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE FROM 장바구니 WHERE  회원번호 = '" + userid + "' and 바구니번호 =" + Int32.Parse(jangnum);
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            bakk();
            bakl();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            jangnum = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            bakl();
            bakk();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                comboBox1.Items.Clear();
                for (int i = 1; i <= Int32.Parse(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString()); i++)
                {
                    comboBox1.Items.Add(i.ToString());
                }
                comboBox1.Text = "1";

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {           
            dataGridView2.SelectedRows[0].Cells[2].Value = comboBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dr = new DataGridViewRow[dataGridView2.Rows.Count];
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dr[i] = dataGridView2.Rows[i];
            }
            주문 O = new 주문();
            this.장바구니에서 += new Event_One_Data(O.장바구니);
            this.bookInfo = new Event_Multy_Book(O.Getbook);
            this.data2where = new Event_One_Data(O.Getid);
            장바구니에서(jangnum);
            data2where(userid);
            bookInfo(dr, dataGridView2.Rows.Count-1);
            O.Show();
            this.Hide();
        }
    }
  
}
 
