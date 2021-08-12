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
    public partial class 로그인 : Form
    {
        public Event_Two_Data data로그인2마이페이지;
        OleDbConnection conn;
        string connectionString;
        string userid, username;
        public 로그인()
        {
            InitializeComponent();
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
        }

        private void button3_Click(object sender, EventArgs e) //로그인
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select 회원번호,이름 from 회원 where 회원번호 = '" + id.Text + "'and 비밀번호='" + passwd.Text + "'"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                userid = read.GetString(0);
                username = read.GetString(1);
                data로그인2마이페이지(userid, username);
                if (userid.Equals("admin"))
                {
                    관리자 ad = new 관리자();
                    ad.Show();
                }
                conn.Close();
                this.Hide();

            }
            else
            {
                MessageBox.Show("회원정보를 다시 확인해주세요");
            }
        }    

        private void 로그인_Load(object sender, EventArgs e)
        {

        }

        private void passwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {
            회원가입 R = new 회원가입();
            R.data2마이페이지 += new Event_Two_Data(this.back2마이페이지);
            R.Show();
        }

        public void back2마이페이지(string data1, string data2)
        {
            data로그인2마이페이지(data1, data2);
            conn.Close();
            this.Hide();
        }
    }
}
