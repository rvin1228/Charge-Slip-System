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
using System.IO;

namespace DeloSantos_ChargeSlipSystem
{
    public partial class Receipt : Form
    {
        public int chargeslip;
        public string staffname;
        public int verify;
        public Receipt(int a, int authenticate)
        {
            InitializeComponent();
            chargeslip = a;
            verify = authenticate;
        }
        SqlConnection con = new SqlConnection(@"Data Source=GHOSTWIREZ\SQLEXPRESS;Initial Catalog=HospitalRecords;Integrated Security=True");
        private void Receipt_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM tbl_patientinfo WHERE ChargeSlipNum = '"+ chargeslip + "' ";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            receipt_FName.Text = (string)dt.Rows[0]["FirstName"];
            receipt_LName.Text = (string)dt.Rows[0]["LastName"];
            receipt_Address.Text = (string)dt.Rows[0]["Address"];
            receipt_RoomNum.Text = Convert.ToString((int)dt.Rows[0]["RoomNum"]);
            receipt_Gender.Text = (string)dt.Rows[0]["Gender"];
            receipt_Age.Text = Convert.ToString((int)dt.Rows[0]["Age"]);
            receipt_Bdate.Text = ((DateTime)dt.Rows[0]["Birthdate"]).ToString("MM/dd/yyyy");
            receipt_Tdate.Text = ((DateTime)dt.Rows[0]["TransactionDate"]).ToString("MM/dd/yyyy");
            receipt_Staff.Text = Convert.ToString(dt.Rows[0]["Prepared"]);

            query = "SELECT Profile FROM tbl_patientinfo WHERE ChargeSlipNum = '" + chargeslip + "'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                byte[] img = (byte[])(reader[0]);
                if(img == null)
                {
                    receipt_ProfileImage.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img);
                    receipt_ProfileImage.Image = Image.FromStream(ms);
                }
            }
            con.Close();
            con.Open();
            query = "SELECT * FROM tbl_patientrecord WHERE ChargeSlipNum = '" + chargeslip + "' ";
            SqlDataAdapter sda2 = new SqlDataAdapter(query, con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();

            
            SqlDataAdapter sda3 = new SqlDataAdapter(query, con);
            SqlCommand cmd;
            query = "SELECT SUM(TotalPrice) FROM tbl_patientrecord WHERE ChargeSlipNum = '" + chargeslip + "'";
            con.Open();
            cmd = new SqlCommand(query, con);
            Int32 total = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            receipt_Total.Text = total.ToString() + " PHP";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (verify == 1)
            {
                this.Hide();
                Admin f1 = new Admin(staffname);
                f1.ShowDialog();
                this.Close();
            }
            else if (verify == 0)
            {
                this.Hide();
                Login log = new Login();
                log.ShowDialog();
                this.Close();
            }
        }

        private void receipt_RoomNum_Click(object sender, EventArgs e)
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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
