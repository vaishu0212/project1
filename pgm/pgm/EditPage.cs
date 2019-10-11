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

namespace pgm
{
    public partial class EditPage : Form
    {
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-L0IUHAQ\\SQLEXPRESS;Initial Catalog=defectquest;Integrated Security=True;MultipleActiveResultSets=True");

        public EditPage()
        {
            InitializeComponent();
        }

        private void EditPage_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

            DoubleBuffered = true;
            label9.Text = DateTime.Now.ToString(" M/d/yyyy ");
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
        private void EditPage_key(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sql.State != ConnectionState.Closed)
                {
                    sql.Close();
                }
                comboBox2.Items.Clear();
                sql.Open();
                SqlCommand selectDef = new SqlCommand("select * from defect_registration where ProjectId = '"+comboBox1.Text+"'", sql);
                SqlDataReader sqdata = selectDef.ExecuteReader();
                while (sqdata.Read())
                {
                    string defectId = sqdata.GetString(2);
                    comboBox2.Items.Add(defectId);

                }
                sql.Close();
            }
            catch(SqlException ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sql.State != ConnectionState.Closed)
                {
                    sql.Close();
                }
                sql.Open();
                SqlCommand selectDef = new SqlCommand("select * from defect_registration where DefectID = '" + comboBox2.Text + "'", sql);
                SqlDataReader sqdata = selectDef.ExecuteReader();
                while (sqdata.Read())
                {
                    textBox2.Text = sqdata.GetString(2);
                    textBox3.Text = sqdata.GetString(3);
                    textBox4.Text = sqdata.GetString(4);
                    textBox5.Text = sqdata.GetString(5);
                    textBox6.Text = sqdata.GetString(6);
                }
                sql.Close();
            }
            catch (SqlException ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "-------Select------" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != "")
            {
                try
                {
                    if (sql.State != ConnectionState.Closed)
                    {
                        sql.Close();
                    }
                    sql.Open();
                    SqlCommand insertDefReg = new SqlCommand("update defect_registration set DefectID = '"+textBox2.Text+ "', Defectname = '" + textBox3.Text + "',Description = '" + textBox4.Text + "',Submittedby = '" + textBox5.Text + "', Owner = '" + textBox6.Text + "',Edit_date = '" + label9.Text + "'  where DefectID = '" + comboBox2.Text + "'",sql);
                    insertDefReg.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

       /* private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "-------Select------")
            {
                try
                {
                    if (sql.State != ConnectionState.Closed)
                    {
                        sql.Close();
                    }
                    sql.Open();
                    SqlCommand deleteDef = new SqlCommand("delete from defect_registration where DefectID = '" + comboBox2.Text + "'", sql);
                    deleteDef.ExecuteNonQuery();
                    MessageBox.Show("Deleted successfully", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    sql.Close();
                    comboBox2.Text = "-------Select------";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
                catch (SqlException ex) { }
            }
            else
            {
                MessageBox.Show(" Please choose the ProjectID and DefectID !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/

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
            if (comboBox2.Text != "-------Select------" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != "")
            {
                try
                {
                    if (sql.State != ConnectionState.Closed)
                    {
                        sql.Close();
                    }
                    sql.Open();
                    SqlCommand insertDefReg = new SqlCommand("update defect_registration set DefectID = '" + textBox2.Text + "', Defectname = '" + textBox3.Text + "',Description = '" + textBox4.Text + "',Submittedby = '" + textBox5.Text + "', Owner = '" + textBox6.Text + "',Edit_date = '" + label9.Text + "'  where DefectID = '" + comboBox2.Text + "'", sql);
                    insertDefReg.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            HomePage form1 = new HomePage();
            form1.Show();
        }
    }
}
