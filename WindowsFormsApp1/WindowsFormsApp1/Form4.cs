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
    public partial class Form4 : Form
    {
        DataSet ds;
        MySqlDataAdapter adapter;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            MySqlConnection con = new MySqlConnection("server=localhost; user=client1; password=1234; database=Тренажерный_зал");
            con.Open();
            adapter = new MySqlDataAdapter("SELECT * FROM Клиенты", con);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            adapter.Update(dataTable);
            dataTable.AcceptChanges();
            con.Close();
            MessageBox.Show("Данные сохранены", "Успех");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=client1; password=1234; database=Тренажерный_зал");
            con.Open();
            MySqlCommand command = new MySqlCommand("select Занятия.Название, Занятия.Дата_и_время_проведения, Тренеры.ФИО as Тренеры from Занятия join Тренеры on Занятия.id_тренера = Тренеры.id where Занятия.id_клиента = 1 order by Занятия.Дата_и_время_проведения desc", con);
            adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=client1; password=1234; database=Тренажерный_зал");
            con.Open();
            MySqlCommand command = new MySqlCommand("select * from Клиент_Данные", con);
            adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DataSource = dataTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=client1; password=1234; database=Тренажерный_зал");
            con.Open();
            MySqlCommand command = new MySqlCommand("select * from Клиент_Абонементы", con);
            adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DataSource = dataTable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=client1; password=1234; database=Тренажерный_зал");
            con.Open();
            MySqlCommand command = new MySqlCommand("select * from Клиент_Занятия", con);
            adapter = new MySqlDataAdapter(command);
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
