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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Clients = new Form5();
            Clients.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Trainers = new Form6();
            Trainers.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Workout = new Form7();
            Workout.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form Subscription = new Form8();
            Subscription.Show();
        }
    }
}
