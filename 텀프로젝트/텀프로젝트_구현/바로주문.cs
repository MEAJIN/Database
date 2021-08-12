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

    public partial class 주문 : Form
    {
        public Event_Multy_Book bookInfo;
        public Event_One_Data data2one;
        public Event_Two_Data data2two;
        OleDbConnection conn;
        string connectionString;
        public DataGridViewRow[] dr;
        int dr_num;
        int sum;
        int n;
        string userid, jangnum;
        string cardnumber;
        string location, locationT;
        bool 장;
        Boolean B, C, A;
        public 주문()
        {
            InitializeComponent();
            B = false;
            C = false;
            A = false;
            장 = false;
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();

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
            if (장)
            {
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader read;

                for (int i = 0; i < dr_num; i++)
                {
                    cmd.CommandText = "select * from 도서 where 도서번호  ='" + dr[i].Cells[1].Value.ToString() + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        object[] tmp = new object[dataGridView1.ColumnCount];
                        for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                        {
                            tmp[j] = new object();
                            tmp[j] = read.GetValue(j);
                        }
                        tmp[dataGridView1.ColumnCount - 1] = dr[i].Cells[2].Value.ToString();
                        dataGridView1.Rows.Add(tmp);
                    }
                    read.Close();
                }
               int sum = 0;
               for (int i = 0; i < dr_num; i++)
                {
                    if (!dataGridView1.Rows[i].Cells[4].Value.ToString().Equals(""))
                    {
                        sum += (Int32.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                    }
                }
                textBox9.Text = sum.ToString();
            }
            else
            {
                for (int i = 0; i < dr_num; i++)
                {
                    object[] tmp = new object[dataGridView1.ColumnCount];
                    for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                    {
                        tmp[j] = new object();
                        tmp[j] = dr[i].Cells[j].Value.ToString();

                    }
                    tmp[dataGridView1.ColumnCount - 1] = "선택";
                    dataGridView1.Rows.Add(tmp);
                }
            }
        }
        public void 장바구니 (string jangnum)
        {
            this.jangnum = jangnum;
            장 = true;
        }
        public void Getbook(DataGridViewRow[] dr,int dr_num)
        {
            this.dr = dr;
            this.dr_num = dr_num;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            for(int i=1; i <= Int32.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString()); i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
        }
        public void Getid(string id)
        {
            userid = id;
        }
        private void 바로주문_Load(object sender, EventArgs e)
        {
            bokk();
            updatedbA();
            updatedbC();
    
          //  comboBox1.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            //for (int i = 1; i <= Int32.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString()); i++)
            //{
            //    comboBox1.Items.Add(i.ToString());
            //}
        }

        private void textBox9_TextChanged(object sender, EventArgs e)//총가격
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    comboBox1.
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectedRows[0] .Cells[4].Value = comboBox1.Text;
            sum = 0;
            n = 0;
            for(int i = 0; i < dr_num; i++)
            {
                if (!dataGridView1.Rows[i].Cells[4].Value.ToString().Equals("선택"))
                {
                    try
                    {
                        sum += Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * Int32.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    }
                    catch(Exception ex)
                    {

                    }
                   
                }
                n++;
            }
            if (n == dr_num)
            {
                B = true;
            }
            textBox9.Text = sum.ToString();
        }
        private void updatedbC()
        {
            try
            {
                dataGridView2.Rows.Clear();
                //conn.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 카드 where 회원번호='" + userid + "'"; //member 테이블
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView2.ColumnCount = 4;

                for (int i = 0; i < 4; i++)
                {
                    dataGridView2.Columns[i].Name = read.GetName(i);
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
                    dataGridView2.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }
        private void updatedbA()
        {
            try
            {
                dataGridView3.Rows.Clear();
                //conn.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 주소록 where 회원번호='" + userid + "'"; //member 테이블
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView3.ColumnCount = 5;

                for (int i = 0; i < 5; i++)
                {
                    dataGridView3.Columns[i].Name = read.GetName(i);
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
                    dataGridView3.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//카드
        {
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            cardnumber = textBox1.Text;
            dateTimePicker1.Value = DateTime.Parse(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
            textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            C = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)//배송
        {
            if (dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("집"))
            {
                radioButton1.Checked = true;
                locationT = location = "집";
            }
            else
            {
                radioButton2.Checked = true;
                locationT = location = "회사";
            }
            textBox4.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            A = true;
        }

        private void button1_Click(object sender, EventArgs e)//카생
        {
            if (!userid.Equals("") && !textBox1.Text.Equals("") && !textBox5.Text.Equals(""))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO 카드 VALUES('" + userid + "','" + textBox1.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + textBox5.Text + "')";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("카드가 등록되었습니다.");
                C = true;
            }
            else { MessageBox.Show("빈 항목이 있습니다."); }
            updatedbC();
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
                    C = true;
                    updatedbC();
                }
                else
                {
                    MessageBox.Show("카드번호는 수정할 수 없습니다.");
                    textBox1.Text = cardnumber;
                }
            }
            else { MessageBox.Show("빈 항목이 있습니다."); }
        }

        private void button3_Click(object sender, EventArgs e)//카삭
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE FROM 카드 WHERE 회원번호 = '" + userid + "'and 카드번호 ='" + textBox1.Text + "'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("카드를 삭제 했습니다.");
            textBox1.Text = "";
            textBox5.Text = "";
            updatedbC();
            C = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)//홈
        {
            location = "집";
        }

        private void button6_Click(object sender, EventArgs e)//배추
        {
            if (!userid.Equals("") && !textBox5.Text.Equals("") && !textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO 주소록 VALUES('" + userid + "','" + location + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("배송지가 등록되었습니다.");
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                A = true;
            }
            else
            {
                MessageBox.Show("빈 항목이 있습니다.");
            }
            updatedbA();
        }

        private void button5_Click(object sender, EventArgs e)//배수
        {
            if (!userid.Equals("") && !textBox5.Text.Equals("") && !textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                if (location.Equals(locationT))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "UPDATE 주소록 set 회원번호 = '" + userid + "',배송지='" + location + "',우편번호='" + textBox4.Text + "',기본주소='" + textBox3.Text + "',상세주소='" + textBox2.Text + "'where 회원번호 = '" + userid + "'and 배송지 ='" + location + "'";
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("배송지가 수정되었습니다.");
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    A = true;

                    updatedbA();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)//배삭
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE FROM 주소록 WHERE 회원번호 = '" + userid + "' and 배송지 ='" + location + "'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("배송지를 삭제 했습니다.");
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            updatedbA();
            A = false;
        }

        private void button7_Click(object sender, EventArgs e)//결제
        {
            if (A && B && C)
            {
                결제확인 C = new 결제확인();
                this.bookInfo += new Event_Multy_Book(C.Getbook);
                this.data2one += new Event_One_Data(C.Getid);
                this.data2two += new Event_Two_Data(C.GetCA);

                for (int i = 0; i < dr_num; i++)
                {
                    dr[i] = dataGridView1.Rows[i];
                }
                data2one(userid);
                bookInfo(dr, dr_num);
                data2two(textBox1.Text, location);
                C.Show();
                this.Hide();
            }
            else
            {
                if (!A)
                {
                    MessageBox.Show("배송지를 선택해 주세요.");
                }
                if (!B)
                {
                    MessageBox.Show("선택한 도서에 대해 수량을 지정해 주세요");
                }
                if (!C)
                {
                    MessageBox.Show("카드를 선택해 주세요.");
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)//직
        {
            location = "회사";
        }
    }
}
