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
    public partial class 메인 : Form
    {
        public Event_Multy_Book bookInfo;
        public Event_Two_Data go마이;
        public Event_One_Data data2탈퇴, data2where;
        public DataGridViewRow[] dr;

        int dr_num;
        OleDbConnection conn;
        string connectionString;
        string userid = "", username;
        public 메인()
        {
            InitializeComponent();
            LogoutState();
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
            updatedb();
            dataGridView6Update();
           // debug();
        }
        public void debug()
        {
            userid = "test";
            username = "t";
            LoginState();
        }
        public void dataGridView6Update()
        {
            try
            {
                dataGridView6.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from(select sum(수량) 합, 도서번호 from 주문_선택 group by 도서번호) order by 합 desc";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                OleDbCommand cmd2 = new OleDbCommand();

                dataGridView6.ColumnCount = 5;
                while (read.Read())
                {
                    object[] obj = new object[5];
                    cmd2.CommandText = "select * from 도서 where 도서번호 ='" + read.GetValue(1).ToString() + "'";
                    cmd2.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd2.Connection = conn;
                    OleDbDataReader read2 = cmd2.ExecuteReader();
                    for (int i = 0; i < 4; i++)
                    {
                        dataGridView6.Columns[i].Name = read2.GetName(i);
                    }
                    dataGridView6.Columns[4].Name = "판매량";




                    while (read2.Read())
                        for (int i = 0; i < 4; i++) // 필드 수만큼 반복
                        {
                            obj[i] = new object();
                            obj[i] = read2.GetValue(i); // 오브젝트배열에 데이터 저장
                        }
                    obj[4] = new object();
                    obj[4] = read.GetValue(0);
                    dataGridView6.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                    read2.Close();
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }
        private void updatedb()
        {
            try
            {
                dataGridView1.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 도서"; //member 테이블
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
        public void LoginState()
        {
            label4.Hide();
            label1.Show();
        }
        public void BackData(string data1, string data2)
        {
            userid = data1;
            username = data2;
            LoginState();
        }
        public void getidname(string id, string name)
        {
            userid = id;
            username = name;
            if (userid.Equals(""))
            {
                LogoutState();
            }
            else
            {
                LoginState();
            }
        }

        private void label34_Click(object sender, EventArgs e)//마이
        {
            if(userid != "") 
            { 
            마이페이지 My = new 마이페이지();
            this.go마이 = new Event_Two_Data(My.getidname);
            go마이(userid, username);
            My.Show();
            this.Hide();
            }
        }

        private void label4_Click(object sender, EventArgs e)//로그인
        {
            로그인 L = new 로그인();
            L.data로그인2마이페이지 += new Event_Two_Data(this.BackData);
            L.Show();
        }

        private void label5_Click(object sender, EventArgs e)//회원
        {
            회원가입 R = new 회원가입();
            R.data2마이페이지 += new Event_Two_Data(this.BackData);
            R.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LogoutState();
            userid = "";
            username = "";
        }

        private void 메인_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!userid.Equals(""))
            {
                bool test = true;
                dataGridView1.ColumnCount = 5;
                dr_num = dataGridView1.SelectedRows.Count;
                dr = new DataGridViewRow[dr_num];
                for (int i = 0; i < dr_num; i++)
                {
                    if (Int32.Parse(dataGridView1.SelectedRows[i].Cells[2].Value.ToString()) == 0)
                    {
                        MessageBox.Show("재고가 없는 책은 바로 구매하실 수 없으십니다.\n다시 선택해 주세요!", "재고확인");
                        test = false;
                        break;
                    }
                    dr[i] = dataGridView1.SelectedRows[i];
                }
                if (test)
                {
                    장바구니담기 B = new 장바구니담기();
                    this.bookInfo = new Event_Multy_Book(B.Getbook);
                    this.data2where = new Event_One_Data(B.Getid);
                    data2where(userid);
                    bookInfo(dr, dr_num);
                    dataGridView1.ColumnCount = 4;
                    B.Show();
                }
            }
            else MessageBox.Show("장바구니 담기는 로그인 이후 가능 합니다.");
        }

        private void pictureBox2_Click(object sender, EventArgs e)//검색 select * from 도서 where lower(도서명) like '%the%';
        {
            dataGridView6Update();
            try
            {
                dataGridView1.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                if (comboBox1.Text.Equals("도서명"))
                {
                    cmd.CommandText = "select * from 도서 where lower(도서명) like '%" + textBox1.Text.ToString().ToLower() + "%'"; //member 테이블
                }
                else if(comboBox1.Text.Equals("도서번호"))
                {
                    cmd.CommandText = "select * from 도서 where lower(도서번호) like '%" + textBox1.Text.ToString().ToLower() + "%'"; //member 테이블
                }
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

        private void label3_Click(object sender, EventArgs e)//장바구니
        {
            장바구니 jang = new 장바구니();
            this.go마이 = new Event_Two_Data(jang.getidname);
            go마이(userid, username);
            jang.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            updatedb();
            dataGridView6Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!userid.Equals(""))
            {
                bool test = true;
                dataGridView1.ColumnCount = 5;
                dr_num = dataGridView1.SelectedRows.Count;
                dr = new DataGridViewRow[dr_num];
                for (int i = 0; i < dr_num; i++)
                {
                    if (Int32.Parse(dataGridView1.SelectedRows[i].Cells[2].Value.ToString()) == 0)
                    {
                        MessageBox.Show("재고가 없는 책은 바로 구매하실 수 없으십니다.\n다시 선택해 주세요!", "재고확인");
                        test = false;
                        break;
                    }
                    dr[i] = dataGridView1.SelectedRows[i];
                }
                if (test)
                {
                    주문 O = new 주문();
                    this.bookInfo = new Event_Multy_Book(O.Getbook);
                    this.data2where = new Event_One_Data(O.Getid);
                    data2where(userid);
                    bookInfo(dr, dr_num);
                    dataGridView1.ColumnCount = 4;
                    O.Show();
                }
            }
            else MessageBox.Show("주문은 로그인 이후 가능 합니다.");

        }

        public void LogoutState()
        {
            label4.Show();
            label1.Hide();
        }

    }
}

