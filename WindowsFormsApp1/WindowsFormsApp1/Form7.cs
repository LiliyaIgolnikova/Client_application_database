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
    public partial class Form7 : Form
    {
        DataSet ds;
        MySqlDataAdapter adapter;
        public Form7()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            adapter = new MySqlDataAdapter("select * from Занятия", con);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "Занятия");
            con.Close();
            DataTable table = ds.Tables["Занятия"];
            dataGridView1.DataSource = ds.Tables["Занятия"];
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
            ds.Tables["Занятия"].Rows.Add();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            try
            {
                con.Open();
                adapter.Update(ds.Tables["Занятия"]);
                con.Close();
                MessageBox.Show("Данные сохранены", "Успех");
            }
            catch (MySqlException ex)
            {
                con.Close();
                if (ex.Message.Contains("Уникальное_время_тренера"))
                {
                    MessageBox.Show("Ошибка: Тренер уже занят в это время!");
                }
                else if (ex.Message.Contains("Уникальное_время_клиента"))
                {
                    MessageBox.Show("Ошибка: Клиент уже записан на тренировку в это время!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ds.Tables["Занятия"].Rows[dataGridView1.SelectedRows[0].Index].Delete();
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }
    }
}
