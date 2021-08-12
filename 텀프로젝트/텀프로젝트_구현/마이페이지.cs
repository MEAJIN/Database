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
    public delegate void Event_Zero_Data();
    public delegate void Event_One_Data(string data);
    public delegate void Event_Two_Data(string data1, string date2);
    public delegate void Event_Multy_Book(DataGridViewRow[] dr, int dr_num);
    public delegate void Event_Multy_object(object[] ob, int num);
    public partial class 마이페이지 : Form
    {
        public Event_Two_Data event_Two_Data;
        OleDbConnection conn;
        string connectionString;
        string userid ="", username;
        public Event_One_Data data2where;
        public Event_Two_Data go메인;
        public 마이페이지()
        {
            InitializeComponent();
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e) // 로그인
        {
            로그인 L = new 로그인();
            L.data로그인2마이페이지 += new Event_Two_Data(this.BackData);
            L.Show();
        }

        private void label5_Click(object sender, EventArgs e)//  회원가입
        {
            회원가입 R = new 회원가입();
            R.data2마이페이지 += new Event_Two_Data(this.BackData);
            R.Show();
        }

        public void BackData(string data1, string data2)
        {
            userid = data1;
            username = data2;
            
        }
        private void label1_Click(object sender, EventArgs e)//out
        {
            메인 M = new 메인();
            this.go메인 = new Event_Two_Data(M.getidname);
            go메인("","");
            this.Hide();
            M.Show();
        }
   
        public void go메인orlogout(string state)
        {
            if (state.Equals("go"))
            {
                메인 M = new 메인();
                this.go메인 = new Event_Two_Data(M.getidname);
                go메인(userid, username);
                this.Hide();
                M.Show();
            }
            else if(state.Equals("goout"))
            {
                메인 M = new 메인();
                this.go메인 = new Event_Two_Data(M.getidname);
                go메인("","");
                this.Hide();
                M.Show();
            }
            else
            {
                //LoginState();
            }
        }
        private void label9_Click(object sender, EventArgs e)//회원탈퇴
        {
            회원탈퇴 W = new 회원탈퇴();
            this.data2where += new Event_One_Data(W.Getid);
            W.data탈퇴2 += new Event_One_Data(this.go메인orlogout);
            data2where(userid);
            W.Show();
        }
        private void label7_Click(object sender, EventArgs e)//카드
        {
            카드관리 C = new 카드관리();
            this.data2where = new Event_One_Data(C.Getid);
            C.data2마이 = new Event_One_Data(this.go메인orlogout);
            data2where(userid);
            C.Show();
        }

        private void label2_Click(object sender, EventArgs e)//main
        {
            메인 M = new 메인();
            this.go메인 = new Event_Two_Data(M.getidname);
            go메인(userid, username);
            this.Hide();
            M.Show();
        }

        private void label6_Click(object sender, EventArgs e)//수정
        {
            개인정보_수정_비번확인 M = new 개인정보_수정_비번확인();
            this.data2where = new Event_One_Data(M.Getid);
            M.data2my = new Event_One_Data(this.go메인orlogout);
            data2where(userid);
            M.Show();
        }

        private void label8_Click(object sender, EventArgs e)//주소록
        {
            배송주소록 A = new 배송주소록();
            this.data2where = new Event_One_Data(A.Getid);
            A.data2마이 = new Event_One_Data(this.go메인orlogout);
            data2where(userid);
            A.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            회원탈퇴 W = new 회원탈퇴();
            this.data2where += new Event_One_Data(W.Getid);
            W.data탈퇴2 += new Event_One_Data(this.go메인orlogout);
            data2where(userid);
            W.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            배송주소록 A = new 배송주소록();
            this.data2where = new Event_One_Data(A.Getid);
            A.data2마이 = new Event_One_Data(this.go메인orlogout);
            data2where(userid);
            A.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            카드관리 C = new 카드관리();
            this.data2where = new Event_One_Data(C.Getid);
            C.data2마이 = new Event_One_Data(this.go메인orlogout);
            data2where(userid);
            C.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            개인정보_수정_비번확인 M = new 개인정보_수정_비번확인();
            this.data2where = new Event_One_Data(M.Getid);
            M.data2my = new Event_One_Data(this.go메인orlogout);
            data2where(userid);
            M.Show();
        }
        private void dataGridView1Update()
        {
            try
            {
                dataGridView1.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 주문   where 회원번호  ='" + userid + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                dataGridView1.ColumnCount = 6;


                for (int i = 0; i < 6; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }

                //행 단위로 반복
                while (read.Read())
                {
                    object[] obj = new object[6];

                    for (int i = 0; i < 6; i++)
                    {
                        obj[i] = new object();
                        if (i == 1) { obj[i] = read.GetValue(i).ToString().Substring(0, 10); }
                        else if (i == 5) { obj[i] = read.GetValue(7); }
                        else { obj[i] = read.GetValue(i); }
                    }
                    dataGridView1.Rows.Add(obj);
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
            private void label11_Click(object sender, EventArgs e)//주문조회취소
        {
            주문조회취소 주조취= new 주문조회취소();
            this.event_Two_Data = new Event_Two_Data(주조취.getidname);
            event_Two_Data(userid, username);
            주조취.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            주문취소내역 주취내 = new 주문취소내역();
            this.event_Two_Data = new Event_Two_Data(주취내.getidname);
            event_Two_Data(userid, username);
            주취내.Show();
        }

        public void getidname(string id, string name)
        {
            userid = id;
            username = name;
            dataGridView1Update();
        }
    }
}
