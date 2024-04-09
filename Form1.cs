using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 100)
            {
                Random rnd = new Random();
                progressBar1.Value += 5;
                label1.ForeColor = Color.FromArgb(rnd.Next(0, 256), 
                    rnd.Next(0, 256), rnd.Next(0, 256));
            }
            else
            {
                timer1.Stop();
                panel1.Hide();
                panel2.Show();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                long i = long.Parse(textBox1.Text);

                if (i <= 0)
                    MessageBox.Show("Please enter a number greater than 0", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    while (i != 1)
                    {
                        long j = i;
                        if (i % 2 == 0)
                        {
                            i /= 2;
                            listBox1.Items.Add(j.ToString() + "/2=" + i.ToString());
                        }
                        else
                        {
                            i = (i * 3) + 1;
                            listBox1.Items.Add(j.ToString() + "*3+1=" + i.ToString());
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ooops an error occurred!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Collatz_conjecture");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}

