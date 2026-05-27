using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        DataSet ds;
        MySqlDataAdapter adapter;
        public Form5()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            adapter = new MySqlDataAdapter("select * from Клиенты", con);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "Клиенты");
            con.Close();
            DataTable table = ds.Tables["Клиенты"];
            dataGridView1.DataSource = ds.Tables["Клиенты"];
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Tables["Клиенты"].Rows.Add();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            adapter.Update(ds.Tables["Клиенты"]);
            con.Close();
            MessageBox.Show("Данные сохранены", "Успех");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ds.Tables["Клиенты"].Rows[dataGridView1.SelectedRows[0].Index].Delete();
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text.ToString();
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Введите ФИО, номер телефона или e-mail клиента!");
                return;
            }
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            MySqlCommand command = new MySqlCommand("select * from Клиенты where ФИО = @search or Номер_телефона = @search or e_mail = @search", con);
            command.Parameters.AddWithValue("@search", search);
            DataTable dataTable = new DataTable();
            adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.DataSource = dataTable;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
