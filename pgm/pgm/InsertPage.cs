using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace pgm
{
    public partial class InsertPage : Form
    {
        //string connection = "Data Source=DESKTOP-L0IUHAQ\\SQLEXPRESS;Initial Catalog=defectquest;Integrated Security=True";
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-L0IUHAQ\\SQLEXPRESS;Initial Catalog=defectquest;Integrated Security=True;MultipleActiveResultSets=True");
         public InsertPage()
        {
            InitializeComponent();
        }

        private void Newinsert_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

            DoubleBuffered = true;
            label9.Text = DateTime.Now.ToString( " M/d/yyyy ");

            try
            {
                sql.Open();
                SqlCommand selectDef = new SqlCommand("select distinct * from Insert_projectid", sql);
                SqlDataReader sqdata = selectDef.ExecuteReader();
                while (sqdata.Read())
                {
                    string projectID = sqdata.GetString(1);
                    comboBox1.Items.Add(projectID);

                }
                    sql.Close();
            }
            catch(SqlException ex) { }


        }


        private void Newinsert_key(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2 .Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (comboBox1.Text != "---Select---" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != "")
                {

                    try
                    {
                        if (sql.State != ConnectionState.Closed)
                        {
                            sql.Close();
                        }
                        sql.Open();
                        SqlCommand insertDefReg = new SqlCommand("insert into defect_registration(ProjectId,DefectID,Defectname,Description,Submittedby,Owner,Creation_date) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + label9.Text + "')", sql);
                        insertDefReg.ExecuteNonQuery();

                        MessageBox.Show("Records added successfully", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        sql.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(" please check this \n" +
                            "**********************************************************************"
                                     + ex);

                    }
                }
                else
                {
                    MessageBox.Show(" Please fill the all require fileds !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
       
        }

     
        private void button3_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            textBox1.Enabled = true;
            button3.Visible = false;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    sql.Open();
                    SqlCommand insertDefReg = new SqlCommand("insert into Insert_projectid(ProjectID) values('" + textBox1.Text + "')", sql);
                    insertDefReg.ExecuteNonQuery();
                    MessageBox.Show("Inserted successfully", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    sql.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(" Project Id already exists !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button4.Visible = false;
                textBox1.Enabled = false;
                button3.Visible = true;
                try
                {
                    if (sql.State != ConnectionState.Closed)
                    {
                        sql.Close();
                    }
                    comboBox1.Items.Clear();
                    sql.Open();
                    SqlCommand selectDef = new SqlCommand("select distinct * from Insert_projectid", sql);
                    SqlDataReader sqdata = selectDef.ExecuteReader();
                    while (sqdata.Read())
                       
                    {
                        string projectID = sqdata.GetString(1);
                        comboBox1.Items.Add(projectID);

                    }
                    sql.Close();
                }
                catch (SqlException ex) { }
            
            }
            else
            {
                MessageBox.Show(" Please enter the projectID !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "---Select---" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != "")
            {

                try
                {
                    if (sql.State != ConnectionState.Closed)
                    {
                        sql.Close();
                    }
                    sql.Open();
                    SqlCommand insertDefReg = new SqlCommand("insert into defect_registration(ProjectId,DefectID,Defectname,Description,Submittedby,Owner,Creation_date) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + label9.Text + "')", sql);
                    insertDefReg.ExecuteNonQuery();

                    MessageBox.Show("Records added successfully", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    sql.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(" please check this \n" +
                        "**********************************************************************"
                                 + ex);

                }
            }
            else
            {
                MessageBox.Show(" Please fill the all require fileds !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            HomePage firstpage = new HomePage();
            firstpage.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportPage report = new ReportPage();
            report.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home = new HomePage();
            home.Show();
        }
    }

}
