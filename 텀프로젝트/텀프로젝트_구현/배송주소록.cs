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
    public partial class 배송주소록 : Form
    {
        OleDbConnection conn;
        public Event_One_Data data2마이;
        string connectionString;
        string userid;
        string location, locationT;
        
        public 배송주소록()
        {
            InitializeComponent();
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open(); 
            updatedb();
        }

       
  
        private void updatedb()
        {
            try
            {
                dataGridView1.Rows.Clear();
                //conn.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 주소록 where 회원번호='" + userid + "'"; //member 테이블
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView1.ColumnCount = 5;

                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }
                //행 단위로 반복
                while (read.Read())
                {
                    object[] obj = new object[5]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < 5; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }
                    dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }
        public void Getid(string id)
        {
            userid = id;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("집"))
            {
                radioButton1.Checked = true;
                locationT=location = "집";
            }
            else
            {
                radioButton2.Checked = true;
                locationT=location = "회사";
            }
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)//추가
        {
            if (!userid.Equals("") && !textBox5.Text.Equals("") && !textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO 주소록 VALUES('" + userid + "','" + location + "','" + textBox5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("배송지가 등록되었습니다.");
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            else
            {
                MessageBox.Show("빈 항목이 있습니다.");
            }
            updatedb();
        }

        private void button2_Click(object sender, EventArgs e)//수정
        {
            if (!userid.Equals("") && !textBox5.Text.Equals("") && !textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                if (location.Equals(locationT))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "UPDATE 주소록 set 회원번호 = '" + userid + "',배송지='" + location + "',우편번호='" + textBox5.Text + "',기본주소='" + textBox1.Text + "',상세주소='" + textBox2.Text + "'where 회원번호 = '" + userid + "'and 배송지 ='" + location + "'";
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("배송지가 수정되었습니다.");
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    updatedb();
                }
                else
                {
                    MessageBox.Show("배송지 항목은 수정할 수 없습니다..");
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("빈 항목이 있습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)//삭제
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE FROM 주소록 WHERE 회원번호 = '" + userid + "' and 배송지 ='" + location + "'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("배송지를 삭제 했습니다.");
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            updatedb();
        }

        private void 배송주소록_Load(object sender, EventArgs e)
        {
            updatedb();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {      
             location = "집";            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            location = "회사";
        }

        private void label5_Click(object sender, EventArgs e)//로그아웃
        {
            data2마이("goout");
            this.Hide();
            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)//회원가입
        {            
            회원가입 R = new 회원가입();
            R.data2마이페이지 += new Event_Two_Data(this.notthing);
            R.Show();                       
        }
        public void notthing(string d1, string d2) { }

        private void label34_Click(object sender, EventArgs e)//마이
        {
            this.Hide();
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)//go
        {
            data2마이("go");
            this.Hide();
            conn.Close();
        }
    }
}
