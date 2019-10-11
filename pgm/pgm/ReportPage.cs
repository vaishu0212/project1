using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Configuration;

namespace pgm
{
    public partial class ReportPage : Form
    {
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-L0IUHAQ\\SQLEXPRESS;Initial Catalog=defectquest;Integrated Security=True;MultipleActiveResultSets=True");

        public ReportPage()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;

            DoubleBuffered = true;
            try
            {
                if (sql.State != ConnectionState.Closed)
                {
                    sql.Close();
                }
                comboBox1.Items.Clear();
                sql.Open();
                SqlCommand selectDef = new SqlCommand("select distinct ProjectId from defect_registration", sql);
                SqlDataReader sqdata = selectDef.ExecuteReader();
                while (sqdata.Read())
                {
                    
                    string projectID = sqdata["ProjectId"] as string;
                    comboBox1.Items.Add(projectID);

                }
                sql.Close();
            }
            catch (SqlException ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = app.Workbooks.Add(Type.Missing);
            Worksheet worksheet = null;
            worksheet = workbook.Sheets["Defects"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "DefectsReport";
            worksheet.Cells[1, 1] = "ID";
            worksheet.Cells[1, 2] = "PROJECT ID";
            worksheet.Cells[1, 3] = "DEFECT ID";
            worksheet.Cells[1, 4] = "DEFECT NAME";
            worksheet.Cells[1, 5] = "DESCRIPTION";
            worksheet.Cells[1, 6] = "SUBMITTED BY";
            worksheet.Cells[1, 7] = "OWNER";
            worksheet.Cells[1, 8] = "CREATE_DATE";
            worksheet.Cells[1, 9] = "EDIT_DATE";
            try
            {
                if (sql.State != ConnectionState.Closed)
                {
                    sql.Close();
                }
                comboBox2.Items.Clear();
                sql.Open();
                SqlCommand selectDef = new SqlCommand("select * from defect_registration where ProjectId = '" + comboBox1.Text + "'", sql);
                SqlDataReader sqdata = selectDef.ExecuteReader();
                while (sqdata.Read())
                {
                    worksheet.Cells[2, 2] = sqdata.GetString(1);
                    worksheet.Cells[2, 3] = sqdata.GetString(2);
                    worksheet.Cells[2, 4] = sqdata.GetString(3);
                    worksheet.Cells[2, 5] = sqdata.GetString(4);
                    worksheet.Cells[2, 6] = sqdata.GetString(5);
                    worksheet.Cells[2, 7] = sqdata.GetString(6);


                }
                sql.Close();
            }
            catch (SqlException ex) { }
            var saveDialogue = new SaveFileDialog();
            saveDialogue.FileName = "defectReport";
            saveDialogue.DefaultExt = ".xlsx";
            if(saveDialogue.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveDialogue.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();*/


            string data = null;
            int i = 0;
            int j = 0;

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            try
            {
                if (sql.State != ConnectionState.Closed)
                {
                    sql.Close();
                }
                sql.Open();
                SqlDataAdapter selectDef = new SqlDataAdapter("select distinct * from defect_registration where ProjectId = '" + comboBox1.Text + "'", sql);
                DataSet ds = new DataSet();
                selectDef.Fill(ds);
               
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
             
                        xlWorkSheet.Cells[i + 1, j + 1] = data;
                    }
                }
                sql.Close();
            }catch(SqlException ex) { }

            var saveDialogue = new SaveFileDialog();
            saveDialogue.FileName = "defectReport";
            saveDialogue.DefaultExt = ".xls";
            if (saveDialogue.ShowDialog() == DialogResult.OK)
            {
                xlWorkBook.SaveAs(saveDialogue.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

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

        private void report_key(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage home = new HomePage();
            home.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportPage report = new ReportPage();
            report.Show();
        }
    }
}
