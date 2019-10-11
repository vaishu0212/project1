using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgm
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            timer1.Start();
            DoubleBuffered = true;

        }

      /*  private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = true;
            }
        }*/



        private void FirstForm_Key(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }


        private void file_backcolor_hover(object sender, EventArgs e)
        {
            fileToolStripMenuItem.BackColor = Color.Blue;
        }

        private void file_backcolor_leave(object sender, EventArgs e)
        {
            fileToolStripMenuItem.BackColor = Color.AliceBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertPage newForm = new InsertPage();
            newForm.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportToolStripMenuItem.BackColor = Color.Green;
            this.Hide();
            ReportPage repo = new ReportPage();
            repo.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertPage newpage = new InsertPage();
            newpage.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditPage editpage = new EditPage();
            editpage.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home = new HomePage();
            home.Show();
        }
    } 
}
