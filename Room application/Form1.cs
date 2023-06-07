using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Room_application
{
    public partial class Form1 : Form
    {
        SqlConnection con=new SqlConnection("Data Source=ANNU-THEGREAT;Initial Catalog=hotels;Integrated Security=True");
        SqlCommand cmd=new SqlCommand();
        int i = 0;
        private object dataGridtxView1;
        private SqlDataAdapter adapt;

        public Form1()
        {
            InitializeComponent();
            DisplayData();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from rooms", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void clearData()
        {
          /*//throw new NotImplementedException();*/
          txtname.Text = string.Empty;
            txtfood.Text = string.Empty;
            txtin.Text = string.Empty;
            txtout.Text = string.Empty; 
            txtbill.Text = string.Empty; 
            
     

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtfood.Text != "" && txtin.Text != "" && txtout.Text != "" && txtbill.Text != "")
            {

                cmd=new SqlCommand("insert into rooms( Customer_name ,Customer_food, Customer_indate, Customer_outdate,total_bill) values (@Customer_name ,@Customer_food, @Customer_indate, @Customer_outdate,@total_bill)", con);
                cmd.Parameters.AddWithValue("@Customer_name", txtname.Text);
                cmd.Parameters.AddWithValue("@Customer_food", txtfood.Text);
                cmd.Parameters.AddWithValue("@Customer_indate", txtin.Text);
                cmd.Parameters.AddWithValue("@Customer_outdate", txtout.Text);
                cmd.Parameters.AddWithValue("@total_bill", txtbill.Text);
                con.Open();
                 
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
               DisplayData();
                clearData();


               DisplayData ();  
            }
            else
            {
                MessageBox.Show(" Insert correct value");
            }
        }
        

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtname.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtfood.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtin.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtout.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbill.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {


            {
                try
                {
                    if (txtname.Text != "" && txtfood.Text != "" && txtin.Text != "" && txtout.Text != "" && txtbill.Text != "")
                    {
                        cmd = new SqlCommand("update rooms set Customer_name=@Customer_name,Customer_food=@Customer_food,Customer_indate=@Customer_indate,Customer_outdate=@Customer_outdate,total_bill=@total_bill where room_id=@room_id\r\n", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@Customer_name", txtname.Text);
                        cmd.Parameters.AddWithValue("@Customer_fooo", txtfood.Text);
                        cmd.Parameters.AddWithValue("@Customer_indate", txtin.Text);
                        cmd.Parameters.AddWithValue("@Customer_outdate", txtout.Text);
                        cmd.Parameters.AddWithValue("@total_bill", txtbill.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Updated Successfully");
                        con.Close();
                        DisplayData();
                        //ClearData();

                        
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record to Update");
                    }
                }
                catch (Exception ex)
                {
              
                }
            }

        }        
    }
}
