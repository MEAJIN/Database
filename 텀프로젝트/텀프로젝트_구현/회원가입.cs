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
    public partial class 회원가입 : Form
    {
        public Event_Two_Data data2마이페이지;
        OleDbConnection conn;
        string connectionString, confirmname;
        bool check, confirm;
        public 회원가입()
        {
            InitializeComponent();
            check = false;
            confirm = false;
            id.Text ="";
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//확인
        {
            if (check) check = false;
            else check = true;
        }

        private void Confirm_ch_Click(object sender, EventArgs e)//중복확인
        {
            if (!id.Text.Equals(""))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select 회원번호 from 회원 where 회원번호 = '" + id.Text + "'"; //member 테이블
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                if (!read.Read())
                {
                    MessageBox.Show(id.Text + "는 사용 가능한 아이디 입니다.");
                    confirmname = id.Text;
                    confirm = true;
                }
                else
                {
                    MessageBox.Show("아이디가 중복되었습니다.");
                    confirm = false;
                }
            }
            else
            {
                    MessageBox.Show("사용할 아이디를 입력해주세요.");
            }
        }

        private void button3_Click(object sender, EventArgs e)//확인
        {
            if (!passwd.Text.Equals("") && check)
            {
                if (!confirm)
                {
                    MessageBox.Show("아이디 중복검사를 수행해주세요.");
                }
                else if (id.Text != confirmname)
                {
                    MessageBox.Show("중복검사 당시 아이디와 다릅니다.");
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "INSERT INTO 회원 VALUES('" + id.Text + "','" + passwd.Text + "','" + name.Text + "','"+ email1.Text+"','"+phone.Text+"')"; //회원 테이블
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("회원가입을 환영합니다.");
                    data2마이페이지(id.Text, name.Text);
                    //conn.Close();
                    this.Hide();
                }
            }
            else
            {
                if (!check)
                {
                    MessageBox.Show("개인정보 수집 및 이용안내 약관을 확인해주세요.");
                }
                else if (!id.Text.Equals(""))
                {
                    MessageBox.Show("비밀번호를 입력해주세요.");
                }
            }
        }

        private void 회원가입_Load(object sender, EventArgs e)
        {
                    }

        private void passwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)//취소
        {
            this.Hide();
            conn.Close();
        }

        private void 회원가입_Leave(object sender, EventArgs e)
        {
            conn.Close();
        }
    }
}
