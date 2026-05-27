using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        DataSet ds;
        MySqlDataAdapter adapter;
        public Form8()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            adapter = new MySqlDataAdapter("select * from Абонементы", con);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "Абонементы");
            con.Close();
            DataTable table = ds.Tables["Абонементы"];
            dataGridView1.DataSource = ds.Tables["Абонементы"];
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
            ds.Tables["Абонементы"].Rows.Add();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            adapter.Update(ds.Tables["Абонементы"]);
            con.Close();
            MessageBox.Show("Данные сохранены", "Успех");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ds.Tables["Абонементы"].Rows[dataGridView1.SelectedRows[0].Index].Delete();
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            MySqlCommand command = new MySqlCommand("select Клиенты.ФИО, Клиенты.Номер_телефона, Клиенты.e_mail, Абонементы.Начало_действия, Абонементы.Окончание_действия from Абонементы join Клиенты on Абонементы.id_клиента = Клиенты.id where Абонементы.Статус_активности = 1 and Абонементы.Окончание_действия >= curdate()", con);
            adapter = new MySqlDataAdapter(command);
            DataTable dataTable= new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            dataGridView1.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Активные абонементы не найдены");
            }
        }
    }
}
