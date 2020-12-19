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
    public partial class ChargeSlip : Form
    {
        public int chargeslip;
        public string staffname;
        Random random = new System.Random();
        public ChargeSlip(string a)
        {
            InitializeComponent();
            chargeslip = random.Next(10000,50000);
            info_ChargeSlip.Text = Convert.ToString(chargeslip);
            info_Staff.Text = a;
            staffname = a;
        }

        SqlConnection con = new SqlConnection(@"Data Source=GHOSTWIREZ\SQLEXPRESS;Initial Catalog=HospitalRecords;Integrated Security=True");
        string imgLoc = "";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CharsChecker(info_FName.Text) && !CharsChecker(info_LName.Text) && !CharsChecker(info_Address.Text))
            {
                MessageBox.Show("Please fill-up the required patient information.");
            }
            else if (info_Gender.SelectedIndex == -1 || info_Age.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill-up the required patient information.");
            }
            else if (!NumsChecker(info_RoomNum.Text))
            {
                MessageBox.Show("Please enter a valid Room Number.");
            }
            else if (info_PatientImage.Image == null)
            {
                MessageBox.Show("Please insert Patient's photo.");
            }
            else
            {
                if(MessageBox.Show("Have you verified all information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);

                    string query = "INSERT INTO tbl_patientinfo (ChargeSlipNum,FirstName,LastName,Address,RoomNum,Gender,Age,Birthdate,TransactionDate,Prepared,Profile) VALUES('" + info_ChargeSlip.Text + "','" + info_FName.Text + "','" + info_LName.Text + "','" + info_Address.Text + "','" + info_RoomNum.Text + "','" + info_Gender.Text + "','" + info_Age.Text + "','" + info_Birthdate.Text + "','" + info_TransacDate.Text + "','" + info_Staff.Text + "', @img)";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.Parameters.AddWithValue("@img", img);
                    SDA.SelectCommand.ExecuteNonQuery();



                    //SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    //SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    this.Hide();
                    Procedure f2 = new Procedure(chargeslip);
                    f2.ShowDialog();
                    this.Close();
                }
            }
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

        private bool CharsChecker(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (!(x[i] >= 'A' && x[i] <= 'Z') && !(x[i] >= 'a' && x[i] <= 'z')) return false;
            }
            return true;
        }

        private void info_RoomNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
                open.Title = "Select Patient Image";
                if(open.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = open.FileName.ToString();
                    info_PatientImage.ImageLocation = imgLoc;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Admin admin = new Admin(staffname);
                admin.ShowDialog();
                this.Close();
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
    }
}
