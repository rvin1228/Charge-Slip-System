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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=GHOSTWIREZ\SQLEXPRESS;Initial Catalog=HospitalRecords;Integrated Security=True");
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbl_adminlogin WHERE username = '" + login_user.Text.Trim() + "' AND password = '" + login_pass.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(login_user.Text == "" && login_pass.Text == "")
            {
                MessageBox.Show("Please input username and password.");
            }
            else if(dt.Rows.Count == 1)
            {
                query = "SELECT first_name, last_name FROM tbl_adminlogin WHERE username = '" + login_user.Text.Trim() + "' AND password = '" + login_pass.Text.Trim() + "'";
                SqlDataAdapter sda2 = new SqlDataAdapter(query, con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                string fname = Convert.ToString(dt.Rows[0]["first_name"]);
                string lname = Convert.ToString(dt.Rows[0]["last_name"]);
                string staffname = lname + "," + " " + fname;
                this.Hide();
                Admin admin = new Admin(staffname);
                admin.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username and/or Password. Please try again.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.ShowDialog();
            this.Close();
        }

        private void btn_Portal_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbl_patientinfo WHERE ChargeSlipNum = '" + info_ChargeSlipNum.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count == 1)
            {
                int authenticate = 0;
                int chargeslipnum = Convert.ToInt32(info_ChargeSlipNum.Text);
                this.Hide();
                Receipt receipt = new Receipt(chargeslipnum, authenticate);
                receipt.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Patient Charge Slip Number. Please try again.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
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
