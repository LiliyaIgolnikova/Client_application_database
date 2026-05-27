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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            if (login == "root")
            {
                Form Start_admin = new Form2();
                Start_admin.Show();
            }
            else
            {
                if (login == "trainer1")
                {
                    Form Start_trainer = new Form3();
                    Start_trainer.Show();
                }
                else
                {
                    if (login == "client1")
                    {
                        Form Start_client = new Form4();
                        Start_client.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
        }
    }
}
