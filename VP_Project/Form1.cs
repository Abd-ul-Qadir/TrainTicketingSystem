using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            comboBox1.Items.Insert(0, "Select Gender");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Insert(0, "Day");
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Insert(0, "Month");
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.Insert(0, "Year");
            comboBox4.SelectedIndex = 0;

            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {}

        private void button4_Click(object sender, EventArgs e)
        {
            if (loginValidation())
            {
                DashBoard dashBoard = new DashBoard();
                dashBoard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Email Password!!!!!!!!!!!!! ");
            }            
        }
        //Registration
        private void button3_Click(object sender, EventArgs e)
        {
            if (registrationValidation())
            {
                string gender = comboBox1.Text;

                DateTime dateobj = DateTime.Parse($"{comboBox4.Text}-{comboBox3.Text}-{comboBox2.Text}");

                SqlConnection con = new SqlConnection(@"Data Source=ABDUL-QADIR\SQLEXPRESS;Initial Catalog=TrainTicketingSystem;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO uzers VALUES(@firstname, @lastname, @contactnumber, @cnic, @emailaddress, @gender, @password, @birthdate)", con);

                cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                cmd.Parameters.AddWithValue("@contactnumber", Convert.ToDecimal(textBox3.Text));
                cmd.Parameters.AddWithValue("@cnic", Convert.ToDecimal(textBox4.Text));
                cmd.Parameters.AddWithValue("@emailaddress", textBox5.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@password", textBox6.Text);
                cmd.Parameters.AddWithValue("@birthdate",dateobj );

                int status = cmd.ExecuteNonQuery();
                con.Close();
               if (status > 0)
                {
                    MessageBox.Show("Registration Successfull!!!!!! Please LOGIN to continue");
                    
                    panel1.Visible = false;
                    panel2.Visible = true;
                }                
            }            
        }
        private bool registrationValidation()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("First name is required.");
                return false;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Last name is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Phone Number is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("CNIC is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Email Address is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Password is required.");
                return false;
            }
            if (textBox6.Text != textBox7.Text)
            {
                MessageBox.Show("Passwords doesnt match. Please put same passwords in both fields");
                return false;
            }
            if (comboBox1.SelectedIndex == 0 )
            {
                MessageBox.Show("Gender is required.");
                return false;
            }

            if (comboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("Birth Date is required.");
                return false;
            }
            if (comboBox3.SelectedIndex == 0)
            {
                MessageBox.Show("Birth Month is required.");
                return false;
            }
            if (comboBox4.SelectedIndex == 0)
            {
                MessageBox.Show("Birth Year is required.");
                return false;
            }
            if(!checkBox1.Checked)
            {
                MessageBox.Show("Please Agree to Terms and Conditions");
                return false;
            }
            return true;
        }
        private bool loginValidation()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ABDUL-QADIR\SQLEXPRESS;Initial Catalog=TrainTicketingSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Uzers WHERE EmailAddress = @email AND Password = @password", con);
            
            cmd.Parameters.AddWithValue("@email", textBox8.Text);
            cmd.Parameters.AddWithValue("@password", textBox9.Text);
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            return count > 0; 
            
        }
        
    }
}
