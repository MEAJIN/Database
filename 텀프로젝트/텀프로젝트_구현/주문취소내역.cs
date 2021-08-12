using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
namespace hyejin_DB
{
    public partial class 주문취소내역 : Form
    {
        OleDbConnection conn;
        string connectionString;
        string userid = "", username;
        public 주문취소내역()
        {
            InitializeComponent();
            connectionString = "Provider=OraOLEDB.Oracle;Password=a454545;User ID=hyejin";
            conn = new OleDbConnection(connectionString);
            conn.Open();
        }
        public void getidname(string id, string name)
        {
            userid = id;
            username = name;
            dataGridView1Update();
        }
        private void dataGridView1Update()
        {
            try
            {
                dataGridView1.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select * from 주문   where 회원번호  ='" + userid + "' and 주문상태 = '취소'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    dataGridView2.Rows.Clear();
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbCommand cmd2 = new OleDbCommand();
                    cmd.CommandText = "select * from 주문_선택  where 주문번호   ='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    OleDbDataReader read = cmd.ExecuteReader();
                    OleDbDataReader read2;
                    dataGridView2.ColumnCount = 4;
                    for (int i = 0; i < 4; i++)
                    {
                        dataGridView2.Columns[i].Name = read.GetName(i);
                    }

                    //행 단위로 반복
                    while (read.Read())
                    {
                        cmd2.CommandText = "select * from 도서 where 도서번호    ='" + read.GetValue(1).ToString() + "'";
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Connection = conn;
                        read2 = cmd2.ExecuteReader();

                        object[] obj = new object[4];
                        read2.Read();
                        obj[0] = new object();
                        obj[1] = new object();
                        obj[2] = new object();
                        obj[3] = new object();
                        obj[0] = read2.GetValue(0);
                        obj[1] = read2.GetValue(1);
                        obj[2] = read.GetValue(2);
                        obj[3] = read.GetValue(0);

                        dataGridView2.Rows.Add(obj);
                        read2.Close();
                    }
                    read.Close();

                    cmd.CommandText = "select * from 주문 where 주문번호   ='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    read = cmd.ExecuteReader();
                    textBox10.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    if (read.Read())
                    {
                        textBox4.Text = read.GetValue(1).ToString();
                        textBox2.Text = read.GetValue(4).ToString() + " " + read.GetValue(5).ToString().Substring(0, 10) + " " + read.GetValue(6).ToString();
                        textBox5.Text = read.GetValue(7).ToString() + " " + read.GetValue(8).ToString() + " " + read.GetValue(9).ToString();
                        textBox3.Text = read.GetValue(2).ToString();
                        textBox6.Text = read.GetValue(3).ToString();
                    }
                    read.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void 주문취소내역_Load(object sender, EventArgs e)
        {

        }
    }
}
