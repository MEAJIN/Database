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
    public partial class 개인정보_수정_비번확인 : Form
    {
        OleDbConnection conn;
        public Event_One_Data data2where,data2my;
        string connectionString;
        string userid;
        public 개인정보_수정_비번확인()
        {
            InitializeComponent();
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
        }

   
        public void Getid(string id)
        {
            userid = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select 회원번호 from 회원 where 회원번호 = '" + userid + "'and 비밀번호='" + passwd.Text + "'"; //member 테이블
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                개인정보_수정 M = new 개인정보_수정();
                this.data2where = new Event_One_Data(M.Getid);
                M.data2마이 = new Event_One_Data(this.gomain);
                data2where(userid);
                M.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("비밀번호를 올바르게 입력해 주세요.");
            }
        }
        public void gomain(string data)
        {
            data2my(data);
        }
    }
}
