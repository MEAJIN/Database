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
    public partial class 회원탈퇴 : Form
    {
        public Event_One_Data data탈퇴2;
        string userid; //username;
        OleDbConnection conn;
        string connectionString;
        public 회원탈퇴()
        {
            InitializeComponent();
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
        }


        private void button1_Click(object sender, EventArgs e)//탈퇴
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select 회원번호 from 회원 where 회원번호 = '" + userid + "'and 비밀번호='" + textBox5.Text + "'"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();
           
            if (read.Read())
            {

                if (read.GetString(0).Equals(userid))
                {
                    read.Close();
                    cmd.CommandText = "DELETE FROM 회원 WHERE 회원번호 = '" + userid + "'and 비밀번호 ='" + textBox5.Text + "'"; //member 테이블
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("회원탈퇴가 완료 되었습니다.");
                    data탈퇴2("goout");
                    conn.Close();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다");
            }

   
        }
        public void Getid(string id)
        {
            userid = id;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            data탈퇴2("goout");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            회원가입 R = new 회원가입();
            R.data2마이페이지 += new Event_Two_Data(this.notthing);
            R.Show();
        }
        public void notthing(string d1,string d2){}

        private void label34_Click(object sender, EventArgs e)
        {
            this.Hide();
            conn.Close();
        }

        private void 회원탈퇴_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)//home
        {
            data탈퇴2("go");
            this.Hide();
            conn.Close();
        }
    }
}
