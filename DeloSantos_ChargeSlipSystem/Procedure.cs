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

namespace DeloSantos_ChargeSlipSystem
{
    public partial class Procedure : Form
    {
        public int chargeslip;
        public int referencenum;
        Random random = new System.Random();
        public Procedure(int chargeslipF1)
        {
            InitializeComponent();
            chargeslip = chargeslipF1;
            record_Quantity.Enabled = false;

            referencenum = random.Next(10000, 50000);
            record_ReferenceNum.Text = Convert.ToString(referencenum);
        }
        SqlConnection con = new SqlConnection(@"Data Source=GHOSTWIREZ\SQLEXPRESS;Initial Catalog=HospitalRecords;Integrated Security=True");

        private void btn_Add_Click_1(object sender, EventArgs e)
        {
                if (!NumsChecker(record_Quantity.Text))
            {
                MessageBox.Show("Please enter a valid amount.");
            }
            else
            {
                con.Open();
                string query = "INSERT INTO tbl_patientrecord (ChargeSlipNum,ReferenceNum,Description,Quantity,TotalPrice) VALUES('" + chargeslip + "','"+ record_ReferenceNum.Text + "','" + record_Descrip.Text + "','" + record_Quantity.Text + "','" + record_TotalPrice.Text + "')";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                query = "SELECT * FROM tbl_patientrecord WHERE ChargeSlipNum = '"+ chargeslip +"'"; //For displaying the specified chargeslip
                SqlDataAdapter SDA2 = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                SDA2.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                record_Descrip.Text = "";
                record_Quantity.Text = "";
                record_UnitPrice.Text = "0";
                referencenum = random.Next(10000, 50000);  
                record_ReferenceNum.Text = Convert.ToString(referencenum);
            }
        }

        private void record_Descrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(record_Descrip.SelectedIndex == 0)
            {
                record_UnitPrice.Text = "8000";
                record_Quantity.Enabled = true;
                pictureBox1.Show();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if(record_Descrip.SelectedIndex == 1)
            {
                record_UnitPrice.Text = "2300";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Show();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 2)
            {
                record_UnitPrice.Text = "4200";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Show();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 3)
            {
                record_UnitPrice.Text = "2300";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Show();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 4)
            {
                record_UnitPrice.Text = "3500";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Show();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 5)
            {
                record_UnitPrice.Text = "5600";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Show();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 6)
            {
                record_UnitPrice.Text = "850";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Show();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 7)
            {
                record_UnitPrice.Text = "1200";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Show();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 8)
            {
                record_UnitPrice.Text = "2200";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Show();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 9)
            {
                record_UnitPrice.Text = "2200";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Show();
                pictureBox11.Hide();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 10)
            {
                record_UnitPrice.Text = "2550";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Show();
                pictureBox12.Hide();
            }
            else if (record_Descrip.SelectedIndex == 11)
            {
                record_UnitPrice.Text = "450";
                record_Quantity.Enabled = true;
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
                pictureBox11.Hide();
                pictureBox12.Show();
            }
        }

        private void record_Quantity_TextChanged(object sender, EventArgs e)
        {
            int amount;
            Int32.TryParse(record_Quantity.Text, out amount);
            amount = amount * Convert.ToInt32(record_UnitPrice.Text);
            record_TotalPrice.Text = Convert.ToString(amount);
        }

        private bool NumsChecker(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (x[i] < '0' || x[i] > '9') return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "DELETE FROM tbl_patientrecord WHERE ReferenceNum = '" + record_ReferenceNum.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            query = "SELECT * FROM tbl_patientrecord WHERE ChargeSlipNum = '" + chargeslip + "'"; //For displaying the specified chargeslip
            SqlDataAdapter SDA2 = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA2.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            record_ReferenceNum.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            record_Descrip.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            record_Quantity.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            record_TotalPrice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            record_Descrip.Text = "";
            record_Quantity.Text = "";
            record_UnitPrice.Text = "0";
            referencenum = random.Next(10000, 50000);
            record_ReferenceNum.Text = Convert.ToString(referencenum);
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbl_patientrecord WHERE ChargeSlipNum = '" + chargeslip + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                int authenticate = 1;
                this.Hide();
                Receipt receipt = new Receipt(chargeslip, authenticate);
                receipt.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please add a procedure before printing receipt.");
            }



        }

        private void Procedure_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
            pictureBox7.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            pictureBox10.Hide();
            pictureBox11.Hide();
            pictureBox12.Hide();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Chocolate;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
    }
}