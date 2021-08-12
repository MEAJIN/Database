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
    public partial class 관리자 : Form
    {
        OleDbConnection conn;
        string connectionString;
        public 관리자()
        {
            InitializeComponent(); 
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
            updatedb();
            dataGridView5Update();
            dataGridView2Update();
            dataGridView3update();
            dataGridView6Update();
            getInfo();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//도서 수정
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from 도서  where 도서번호  ='" + id.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                read.Close();
                cmd.CommandText = "UPDATE 도서 set 도서명  ='" + textBox1.Text + "',판매가격   =" + Int32.Parse(textBox3.Text) + " ,재고량   =" + Int32.Parse(numericUpDown1.Value.ToString()) + " where 도서번호    = '" + id.Text + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                updatedb();
                read.Close();
                MessageBox.Show("수정되었습니다.");
            }
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void 관리자_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from 주문 where 주문번호  = '" + textBox5.Text + "'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            dataGridView2Update();
            
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectedRows[0].Cells[2].Value = numericUpDown1.Value;
        }

        private void pictureBox2_Click(object sender, EventArgs e)/////////////////////
        {
            try
            {
                string name= "";
                if (comboBox1.Text.Equals("회원아이디")) name = "회원번호";
                else name = "이름";

                dataGridView5.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 회원 where lower("+ name + ") like '%"+textBox22.Text.ToString().ToLower()+"%'";             
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                dataGridView5.ColumnCount = 5;
                while (read.Read())
                {
                    object[] obj = new object[5];

                    for (int i = 0; i < 5; i++)
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i);
                    }
                    dataGridView5.Rows.Add(obj);
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                if (comboBox4.Text.Equals("도서명"))
                {
                    cmd.CommandText = "select * from 도서 where lower(도서명) like '%" + textBox23.Text.ToString().ToLower() + "%'"; 
                }
                else if (comboBox4.Text.Equals("도서번호"))
                {
                    cmd.CommandText = "select * from 도서 where lower(도서번호) like '%" + textBox23.Text.ToString().ToLower() + "%'"; 
                }

                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView1.ColumnCount = 4;

                //행 단위로 반복
                while (read.Read())
                {
                    object[] obj = new object[4]; 

                    for (int i = 0; i < 4; i++) 
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); 
                    }
                    dataGridView1.Rows.Add(obj); 
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView5Update()
        {
            try
            {
                dataGridView5.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 회원";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                dataGridView5.ColumnCount = 5;
                dataGridView5.Columns[0].Name = "회원아이디";
                for (int i = 1; i < 5; i++)
                {
                    dataGridView5.Columns[i].Name = read.GetName(i);
                }
                while (read.Read())
                {
                    object[] obj = new object[5];

                    for (int i = 0; i < 5; i++)
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i);
                    }
                    dataGridView5.Rows.Add(obj);
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numericUpDown1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from 도서  where 도서번호  ='" + id.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                MessageBox.Show("도서번호가 중복됩니다.");
                read.Close();
            }
            else
            {
                if (!id.Equals("") && !textBox1.Text.Equals("") && !numericUpDown1.Value.ToString().Equals("") && !textBox3.Text.Equals(""))
                {
                    read.Close();
                    cmd.CommandText = "INSERT INTO 도서  VALUES('" + id.Text + "','" + textBox1.Text + "'," + Int32.Parse(numericUpDown1.Value.ToString()) + ",'" + textBox3.Text + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();                    
                }
                else { MessageBox.Show("누락한 정보를 확인해주세요"); updatedb(); }
            }
            updatedb();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE FROM 도서  WHERE 도서번호  = '" + id.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            updatedb();
            MessageBox.Show("도서를 삭제 했습니다.");
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox20.Text = dataGridView5.SelectedRows[0].Cells[2].Value.ToString();
            textBox19.Text = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            textBox18.Text = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();
            textBox17.Text = dataGridView5.SelectedRows[0].Cells[3].Value.ToString();
            textBox16.Text = dataGridView5.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "INSERT INTO 회원 VALUES('" + textBox19.Text + "','" + textBox18.Text + "','" + textBox20.Text + "','" + textBox17.Text + "','" + textBox16.Text + "')"; //회원 테이블
            cmd.CommandType = CommandType.Text; 
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            dataGridView5Update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();                               
            cmd.CommandText = "DELETE FROM 회원 WHERE 회원번호 = '" + textBox19.Text + "'";           
            cmd.CommandType = CommandType.Text; 
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            textBox20.Text = "";
            textBox19.Text = "";
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            dataGridView5Update();
        }
        private void dataGridView2Update()
        {
            try
            {
                dataGridView2.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 주문" ;//
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                dataGridView2.ColumnCount = 11;
                for (int i = 0; i < 10; i++)
                {
                    dataGridView2.Columns[i].Name = read.GetName(i);
                }
                dataGridView2.Columns[10].Name = "회원아이디";
                while (read.Read())
                {
                    object[] obj = new object[11];

                    for (int i = 0; i < 11; i++)
                    {
                        obj[i] = new object();
               
                        obj[i] = read.GetValue(i); 
                    }
                    dataGridView2.Rows.Add(obj);
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE 회원 set 비밀번호='" + textBox18.Text + "',이름='" + textBox20.Text + "',메일='" + textBox17.Text + "',핸드폰번호='" + textBox16.Text + "' where 회원번호 = '" + textBox19.Text + "'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            dataGridView5Update();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBox6.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            textBox7.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
        }
        public void dataGridView3update()
        {
            try
            {
                dataGridView3.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 주문"; //member 테이블
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView3.ColumnCount = 11;
                for (int i = 0; i < 11; i++)
                {
                    dataGridView3.Columns[i].Name = read.GetName(i);
                }

                while (read.Read())
                {
                    object[] obj = new object[11]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i <11; i++) 
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); 
                    }
                    dataGridView3.Rows.Add(obj); 
                }
                read.Close();

               
                
                read.Close();

            }
            catch (Exception ex)
            {
            }
        }
        public void getInfo()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select sum(주문총액  ) from 주문";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                textBox10.Text = read.GetValue(0).ToString();
            }
            read.Close();

            cmd = new OleDbCommand();
            cmd.CommandText = "select sum(수량) from (select 주문번호  from 주문) 주, 주문_선택 주선 where 주.주문번호   = 주선.주문번호  ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            read = cmd.ExecuteReader();

            if (read.Read())
            {
                textBox12.Text = read.GetValue(0).ToString();
            }
            read.Close();

            cmd = new OleDbCommand();
            cmd.CommandText = "select sum(수량) from (select 주문번호,주문일자  from 주문) 주, 주문_선택 주선 where 주.주문번호   = 주선.주문번호 and 주.주문일자 between '" + DateTime.Now.ToString("yyyy/MM/dd") + "' and '" + DateTime.Now.AddDays(1).ToString("yyyy/MM/dd") + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            read = cmd.ExecuteReader();

            if (read.Read())
            {
                textBox11.Text = read.GetValue(0).ToString();
            }
            read.Close();
            cmd = new OleDbCommand();
            cmd.CommandText = "select sum(주문총액  ) from 주문 where 주문일자 between '" + DateTime.Now.ToString("yyyy/MM/dd") + "' and '" + DateTime.Now.AddDays(1).ToString("yyyy/MM/dd") + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            read = cmd.ExecuteReader();

            if (read.Read())
            {
                textBox9.Text = read.GetValue(0).ToString();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE 주문 set 주문상태 ='" + comboBox2.Text + "'where 주문번호  = '" + textBox5.Text + "'";
            cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            dataGridView2Update();
        }

        private void button11_Click(object sender, EventArgs e)//검색
        {
             try
            {
                dataGridView4.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 주문   where 회원번호  like '%" + textBox25.Text + "%'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                dataGridView4.ColumnCount = 11;


                for (int i = 0; i < 11; i++)
                {
                    dataGridView4.Columns[i].Name = read.GetName(i);
                }

                //행 단위로 반복
                while (read.Read())
                {
                    object[] obj = new object[11];

                    for (int i = 0; i < 11; i++)
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i);                      
                    }
                    dataGridView4.Rows.Add(obj);
                }
                cmd = new OleDbCommand();
                cmd.CommandText = "select sum(수량) s,sum(주문총액) ss from(select 주문번호, 주문총액 from 주문 where 회원번호 = '"+ textBox25.Text + "') 주, 주문_선택 주선 where 주선.주문번호 = 주.주문번호";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    textBox13.Text = read.GetValue(1).ToString(); 
                    textBox14.Text = read.GetValue(0).ToString();
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
                    cmd2.CommandText = "select * from 도서 where 도서번호 ='"+ read.GetValue(1).ToString() + "'";
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter_1(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)//2
        {
            try
            {
                dataGridView2.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 주문 where 회원번호 like '%"+ textBox24.Text +"%'";//
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader read = cmd.ExecuteReader();
                dataGridView2.ColumnCount = 11;
                for (int i = 0; i < 11; i++)
                {
                    dataGridView2.Columns[i].Name = read.GetName(i);
                }

                while (read.Read())
                {
                    object[] obj = new object[11];

                    for (int i = 0; i < 11; i++)
                    {
                        obj[i] = new object();

                        obj[i] = read.GetValue(i);
                    }
                    dataGridView2.Rows.Add(obj);
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
