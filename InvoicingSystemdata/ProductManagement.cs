using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sudarshan_Project.InvoicingSystemdata
{
    
    public partial class frmproduct : Form
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter sda = new SqlDataAdapter();
        public DataTable dtadd=new DataTable();
        public DataTable dtproduct = new DataTable();
        public DataTable dtcategory = new DataTable();
        public String datapath = "";

        class ProjectConnection
        {
            public string connection;
            public void connectionSQL()
            {

                con = new SqlConnection(connection); //  public static SqlConnection con = null;
                con.Open();
            }
        }
        ProjectConnection connect = new ProjectConnection();
        public frmproduct()
        {
            InitializeComponent();
        }

      

        public void Addproduct()
        {
            try
            {
              


             
                    dgvproduct.Rows.Add(cmbproduct.Text, textBox1.Text, textBox2.Text, 1);
     
                foreach(DataGridViewRow row in dgvproduct.Rows)
                {
                    row.Cells[4].Value = (Convert.ToDouble(row.Cells[2].Value) * Convert.ToDouble(row.Cells[3].Value));
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

        }

        public void updateproduct()
            
        {  
                bool found = false;
                if (dgvproduct.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvproduct.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == cmbproduct.Text && row.Cells[1].Value.ToString() == textBox1.Text && row.Cells[2].Value.ToString() == textBox2.Text)
                        {
                            row.Cells[3].Value = Convert.ToString(1 + Convert.ToInt32(row.Cells[3].Value));
                            found = true;
                        }

                    }
                }
        }
        public int deleterecord(int i)
        {
            dgvproduct.Rows.RemoveAt(i);
            return i;

        }




        

        private void dgvproduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6)
            {
                 deleterecord(e.RowIndex);   
            }
        

        }


        private void button1_Click(object sender, EventArgs e)
        {
         
                Addproduct();
                updateproduct();
        
        }

        private void frmproduct_Load(object sender, EventArgs e)
        {
            connect.connection = datapath;
            connect.connectionSQL();
            cmd = new SqlCommand("Select id,Categoryname from [InvoiceSystem].[dbo].[Category] with(nolock) order by Categoryname ",con);
            cmd.ExecuteNonQuery();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dtcategory);
            Category.ValueMember = "id";
            Category.DisplayMember = "Categoryname";
            Category.DataSource = dtcategory;
        }

        private void BTNgeninvoice_Click(object sender, EventArgs e)
        {
            try
            {
                connect.connectionSQL();
                string cmdinsert = "";
                String invoicenumber = GenerateInvoice.Generateinvoice(Txtinvoicenumber.Text);
                foreach (DataGridViewRow row in dgvproduct.Rows)
                {
                    cmdinsert = cmdinsert + "INSERT INTO [InvoiceSystem].[dbo].[Product]([Name],[Description],[Price],[Quantity],[CategoryId],TotalAmount,InvoiceNumber)values('" + row.Cells[0].Value + "','" + row.Cells[1].Value + "','" + row.Cells[2].Value + "','" + row.Cells[3].Value + "','" + row.Cells[5].Value + "','" + row.Cells[4].Value + "','" + invoicenumber + "')";
                }
                cmd.CommandText = cmdinsert;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Invoice Generated Successfully With Invoice Number:" + invoicenumber);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
