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
    public partial class Admin : Form
    {
        public string staffname;
        public string ChargeSlip, ReferenceNum;

        public Admin(string a)
        {
            InitializeComponent();
            staffname = a;
        }
        SqlConnection con = new SqlConnection(@"Data Source=GHOSTWIREZ\SQLEXPRESS;Initial Catalog=HospitalRecords;Integrated Security=True");
        private void Admin_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT tbl_patientinfo.ChargeSlipNum, FirstName, LastName, Address, RoomNum, Gender, Age, Birthdate, TransactionDate, ReferenceNum, Description, Quantity, TotalPrice, Prepared FROM tbl_patientinfo INNER JOIN tbl_patientrecord ON  tbl_patientinfo.ChargeSlipNum = tbl_patientrecord.ChargeSlipNum";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btn_Charge_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChargeSlip f1 = new ChargeSlip(staffname);
            f1.ShowDialog();
            this.Close();
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT tbl_patientinfo.ChargeSlipNum, FirstName, LastName, Address, RoomNum, Gender, Age, Birthdate, TransactionDate, ReferenceNum, Description, Quantity, TotalPrice, Prepared FROM tbl_patientinfo INNER JOIN tbl_patientrecord ON  tbl_patientinfo.ChargeSlipNum = tbl_patientrecord.ChargeSlipNum";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            info_ChargeSlipNum.Text = "";
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if(info_ChargeSlipNum.Text == "")
            {
                MessageBox.Show("Please input a Charge Slip Number");
            }
            else
            {
                con.Open();
                string query = "SELECT tbl_patientinfo.ChargeSlipNum, FirstName, LastName, Address, RoomNum, Gender, Age, Birthdate, TransactionDate, ReferenceNum, Description, Quantity, TotalPrice, Prepared FROM tbl_patientinfo INNER JOIN tbl_patientrecord ON  tbl_patientinfo.ChargeSlipNum = tbl_patientrecord.ChargeSlipNum WHERE tbl_patientinfo.ChargeSlipNum = '" + info_ChargeSlipNum.Text + "' ";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChargeSlip = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ReferenceNum = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void btn_DeleteAll_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "DELETE FROM tbl_patientrecord WHERE ChargeSlipNum = '" + ChargeSlip + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            query = "SELECT tbl_patientinfo.ChargeSlipNum, FirstName, LastName, Address, RoomNum, Gender, Age, Birthdate, TransactionDate, ReferenceNum, Description, Quantity, TotalPrice, Prepared FROM tbl_patientinfo INNER JOIN tbl_patientrecord ON  tbl_patientinfo.ChargeSlipNum = tbl_patientrecord.ChargeSlipNum";
            SqlDataAdapter SDA2 = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA2.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Would you like to sign out?", "Signing Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "DELETE FROM tbl_patientrecord WHERE ReferenceNum = '" + ReferenceNum + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            query = "SELECT tbl_patientinfo.ChargeSlipNum, FirstName, LastName, Address, RoomNum, Gender, Age, Birthdate, TransactionDate, ReferenceNum, Description, Quantity, TotalPrice, Prepared FROM tbl_patientinfo INNER JOIN tbl_patientrecord ON  tbl_patientinfo.ChargeSlipNum = tbl_patientrecord.ChargeSlipNum";
            SqlDataAdapter SDA2 = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA2.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
