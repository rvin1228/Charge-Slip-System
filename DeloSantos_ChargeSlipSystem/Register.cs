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
    public partial class Register : Form
    {
        Random random = new System.Random();
        public int id;
        public Register()
        {
            InitializeComponent();
            id = random.Next(500, 10000);
            reg_ID.Text = Convert.ToString(id);
        }
        SqlConnection con = new SqlConnection(@"Data Source=GHOSTWIREZ\SQLEXPRESS;Initial Catalog=HospitalRecords;Integrated Security=True");
        private void btn_Register_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbl_adminlogin WHERE username = '" + reg_Username.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Username has already been used.");
            }
            else if (reg_FName.Text == "" || reg_LName.Text == "" || reg_Email.Text == "" || reg_Username.Text == "" || reg_Password.Text == "")
            {
                MessageBox.Show("Please fill-up the required patient information.");
            }
            else
            {
                con.Open();
                query = "INSERT INTO tbl_adminlogin (loginid, username, password, first_name, last_name, email) VALUES('" + reg_ID.Text + "','" + reg_Username.Text + "','" + reg_Password.Text + "','" + reg_FName.Text + "','" + reg_LName.Text + "','" + reg_Email.Text + "')";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("You have successfully registered.");
                this.Hide();
                Login log = new Login();
                log.ShowDialog();
                this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.ShowDialog();
            this.Close();
        }

        private bool CharsChecker(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (!(x[i] >= 'A' && x[i] <= 'Z') && !(x[i] >= 'a' && x[i] <= 'z')) return false;
            }
            return true;
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
