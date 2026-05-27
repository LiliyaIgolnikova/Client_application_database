using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        DataSet ds;
        MySqlDataAdapter adapter;
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            MySqlConnection con = new MySqlConnection("server=localhost; user=trainer1; password=12345; database=Тренажерный_зал");
            con.Open();
            adapter = new MySqlDataAdapter("select * from Тренеры", con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            adapter.Update(dataTable);
            dataTable.AcceptChanges();
            con.Close();
            MessageBox.Show("Данные сохранены", "Успех");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=trainer1; password=12345; database=Тренажерный_зал");
            con.Open();
            MySqlCommand command = new MySqlCommand("select * from Тренер_Данные", con);
            adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=trainer1; password=12345; database=Тренажерный_зал");
            con.Open();
            MySqlCommand command = new MySqlCommand("select * from Тренер_Занятия", con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DataSource = dataTable;
        }
    }
}
