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
    public partial class 카드관리 : Form
    {
        OleDbConnection conn;
        public Event_One_Data data2마이;
        string connectionString;
        string userid;
        string cardnumber;
        public 카드관리()
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
                cmd.CommandText = "select * from 카드 where 회원번호='" + userid + "'"; //member 테이블
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView1.ColumnCount = 4;

                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }
                //행 단위로 반복
                while (read.Read())
                {
                    object[] obj = new object[4]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < 4; i++) // 필드 수만큼 반복
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
        private void label1_Click(object sender, EventArgs e)//go
        {
            data2마이("go");
            this.Hide();
            conn.Close();
        }

        private void label34_Click(object sender, EventArgs e)//my
        {
            this.Hide();
            conn.Close();
        }

        private void label5_Click(object sender, EventArgs e)//out
        {
            data2마이("goout");
            this.Hide();
            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)//회원
        {
            회원가입 R = new 회원가입();
            R.data2마이페이지 += new Event_Two_Data(this.notthing);
            R.Show();
        }
        public void notthing(string d1, string d2) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
  
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cardnumber = textBox1.Text;
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)//추가
        {
            if (!userid.Equals("") && !textBox1.Text.Equals("") && !textBox5.Text.Equals(""))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO 카드 VALUES('" + userid + "','" + textBox1.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + textBox5.Text + "')";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("카드가 등록되었습니다.");
            }
            else { MessageBox.Show("빈 항목이 있습니다."); }
            updatedb();
        }

        private void button2_Click(object sender, EventArgs e)//수정
        {
            if (!userid.Equals("") && !textBox1.Text.Equals("") && !textBox5.Text.Equals(""))
            {
                if (textBox1.Text.Equals(cardnumber))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "UPDATE 카드 set 회원번호 = '" + userid + "',카드번호='" + textBox1.Text + "',유효기간='" + dateTimePicker1.Value.ToShortDateString() + "',카드종류='" + textBox5.Text + "'where 회원번호 = '" + userid + "' and 카드번호='" + textBox1.Text + "'";
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("카드가 수정되었습니다.");
                    updatedb();
                }
                else
                {
                    MessageBox.Show("카드번호는 수정할 수 없습니다.");
                    textBox1.Text = cardnumber;
                }
            }
            else { MessageBox.Show("빈 항목이 있습니다."); }
        }

        private void button3_Click(object sender, EventArgs e)//삭제
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE FROM 카드 WHERE 회원번호 = '" + userid + "'and 카드번호 ='" + textBox1.Text + "'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("카드를 삭제 했습니다.");
            textBox1.Text = "";
            textBox5.Text = "";
            updatedb();
        }

        private void 카드관리_Load(object sender, EventArgs e)
        {
            updatedb();
        }
    }
}
