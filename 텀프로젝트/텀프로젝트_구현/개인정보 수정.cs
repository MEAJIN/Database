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
    public partial class 개인정보_수정 : Form
    {
        OleDbConnection conn;
        public Event_One_Data data2마이;
        string connectionString;
        string userid;
        public 개인정보_수정()
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
                //conn.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 회원 where 회원번호 = '"+userid+"'";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
            
                if(read.Read())
                {
                    id.Text = userid;
                    textBox4.Text = read.GetString(1);
                    textBox1.Text = read.GetString(2);
                    textBox2.Text = read.GetString(3);
                    textBox3.Text = read.GetString(4);
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

        private void label6_Click(object sender, EventArgs e)//회원
        {
            회원가입 R = new 회원가입();
            R.data2마이페이지 += new Event_Two_Data(this.notthing);
            R.Show();
        }
        public void notthing(string d1, string d2) { }

        private void label5_Click(object sender, EventArgs e)//로그아웃
        {
            data2마이("goout");
            this.Hide();
        }

        private void label34_Click(object sender, EventArgs e)//마이
        {
            data2마이("");
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)//메인
        {
            data2마이("go");
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)//수정
        {
            if (id.Text.Equals(userid))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "UPDATE 회원 set 회원번호 = '" + userid + "',비밀번호='" + textBox4.Text + "',이름='" + textBox1.Text + "',메일='" + textBox2.Text + "',핸드폰번호='" + textBox3.Text + "'where 회원번호 = '" + userid + "'";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("개인정보가 수정되었습니다.");
                updatedb();
            }
            else
            {
                MessageBox.Show("아이디는 변경할 수 없습니다.");
                id.Text = userid;
            }
        }

        private void 개인정보_수정_Load(object sender, EventArgs e)
        {
            updatedb();
        }
    }
}
