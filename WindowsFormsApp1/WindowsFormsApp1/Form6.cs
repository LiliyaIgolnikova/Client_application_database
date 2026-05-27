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
    public partial class Form6 : Form
    {
        DataSet ds;
        MySqlDataAdapter adapter;
        public Form6()
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            adapter = new MySqlDataAdapter("select * from Тренеры", con);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "Тренеры");
            con.Close();
            DataTable table = ds.Tables["Тренеры"];
            dataGridView1.DataSource = ds.Tables["Тренеры"];
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
            ds.Tables["Тренеры"].Rows.Add();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; password=0000; database=Тренажерный_зал;");
            con.Open();
            adapter.Update(ds.Tables["Тренеры"]);
            con.Close();
            MessageBox.Show("Данные сохранены", "Успех");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ds.Tables["Тренеры"].Rows[dataGridView1.SelectedRows[0].Index].Delete();
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }
    }
}
