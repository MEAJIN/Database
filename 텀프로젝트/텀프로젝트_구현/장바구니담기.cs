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
    public partial class 장바구니담기 : Form
    {
        public Event_Multy_Book bookInfo;
        public Event_One_Data data2one;
        public Event_Two_Data data2two;
        string jangnum;
        OleDbConnection conn;
        string connectionString, userid;
        public DataGridViewRow[] dr;
        int dr_num;
        public 장바구니담기()
        {
            InitializeComponent();
         
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            jangnum = "";
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
                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "도서번호";
                dataGridView1.Columns[1].Name = "도서명";
                dataGridView1.Columns[2].Name = "재고량";
                dataGridView1.Columns[3].Name = "가격";
                dataGridView1.Columns[4].Name = "구매량";

                for (int i = 0; i < dr_num; i++)
                {
                    object[] tmp = new object[dataGridView1.ColumnCount];
                    for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    {
                        try
                        {
                            tmp[j] = dr[i].Cells[j].Value.ToString();
                        }
                        catch (Exception e) { }
                    }

                    dataGridView1.Rows.Add(tmp);
                dataGridView1.Rows[i].Cells[4].Value = "1";
                }       
        }
        public void bakk()
        {
            dataGridView3.Rows.Clear();
            comboBox2.Items.Clear();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from 장바구니 where 회원번호 ='"+userid+"'"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
            dataGridView3.ColumnCount = 2;
            int j = 0;  
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
                comboBox2.Items.Add(dataGridView3.Rows[j++].Cells[0].Value.ToString());
                if (jangnum.Equals(""))
                {
                    jangnum = dataGridView3.Rows[0].Cells[0].Value.ToString();
                }
                
            }
            read.Close();
        
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
   

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)//장생
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into 장바구니 values(to_char(B_N.nextval,'FM000'),sysdate,'"+userid+"')";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            bakk();
        }

        private void 장바구니담기_Load(object sender, EventArgs e)
        {
            bokk();
            bakk();
            bakl();
            comboBox1.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            for (int i = 1; i <= Int32.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString()); i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE FROM 장바구니 WHERE  회원번호 = '" + userid + "' and 바구니번호 =" +Int32.Parse(jangnum) ;
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("장바구니를 삭제 했습니다.");
            bakk();
            bakl();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                comboBox1.Items.Clear();
                for (int i = 1; i <= Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()); i++)
                {
                    comboBox1.Items.Add(i.ToString());
                }             
                 comboBox1.Text = "1";              
            
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//장바구니 선택창
        {

        }

        private void button8_Click(object sender, EventArgs e)//수량 선택창
        {
            dataGridView1.SelectedRows[0].Cells[4].Value = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (Int32.Parse(comboBox1.Text.ToString()) > 0 && !comboBox2.Text.Equals(""))
            {
                jangnum = comboBox2.Text.ToString();
                OleDbCommand cmd = new OleDbCommand();
                for (int i = 0; i < dr_num; i++)
                {
                    cmd.CommandText = "insert into 장바구니_담기 values('" + jangnum + "','" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'," + Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())+")";
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
            }
            bakl();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            jangnum = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            bakl();
            bakk();

        }
    }
}
