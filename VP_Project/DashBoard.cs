using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Security.Cryptography;

namespace VP_Project
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();

            comboBox1.Items.Insert(0, "Select Number of Seats");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Insert(0, "Day");
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Insert(0, "Month");
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.Insert(0, "Year");
            comboBox4.SelectedIndex = 0;

            comboBox5.Items.Insert(0, "Select City");
            comboBox5.SelectedIndex = 0;

            comboBox6.Items.Insert(0, "Select City");
            comboBox6.SelectedIndex = 0;

            comboBox7.Items.Insert(0, "Select AM or PM");
            comboBox7.SelectedIndex = 0;

            comboBox8.Items.Insert(0, "Minutes");
            comboBox8.SelectedIndex = 0;

            comboBox9.Items.Insert(0, "Hour");
            comboBox9.SelectedIndex = 0;            

            comboBox17.Items.Insert(0, "Month");
            comboBox17.SelectedIndex = 0;           

            comboBox14.Items.Insert(0, "Select City");
            comboBox14.SelectedIndex = 0;

            comboBox15.Items.Insert(0, "Select City");
            comboBox15.SelectedIndex = 0;

            comboBox11.Items.Insert(0, "Select AM or PM");
            comboBox11.SelectedIndex = 0;

            comboBox12.Items.Insert(0, "Minutes");
            comboBox12.SelectedIndex = 0;

            comboBox13.Items.Insert(0, "Hour");
            comboBox13.SelectedIndex = 0;
        
            comboBox18.Items.Insert(0, "Day");
            comboBox18.SelectedIndex = 0;

            comboBox19.Items.Insert(0, "Select Number of Seats");
            comboBox19.SelectedIndex = 0;

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panelUpdateTckt.Visible = false;
            panel7.Visible = false;

            usersTable();
        }
        SqlConnection con = new SqlConnection(@"Data Source=ABDUL-QADIR\SQLEXPRESS;Initial Catalog=TrainTicketingSystem;Integrated Security=True");
        SqlCommand cmd;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //Print Passengers Table
        private void usersTable()
        {
            con.Open();
            cmd = new SqlCommand("SELECT * From uzers", con);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panelUpdateTckt.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panelUpdateTckt.Visible = false;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e){}

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panelUpdateTckt.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panelUpdateTckt.Visible = false;

            con.Open();

            cmd = new SqlCommand("SELECT * From trainz", con);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            dataGridView3.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usersTable();
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panelUpdateTckt.Visible = false;
        }
        //Find Ticket
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Ticket Number is required.");
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("SELECT * from passengerz where TicketNumber = @ticket ", con);
                cmd.Parameters.AddWithValue("@ticket", textBox7.Text);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dataAdapter.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {



                    string fname = dt.Rows[0]["FirstName"].ToString();
                    string lname = dt.Rows[0]["LastName"].ToString();
                    string cntctnum = dt.Rows[0]["ContactNumber"].ToString();
                    string cnic = dt.Rows[0]["CNIC"].ToString();
                    string tcktnum = dt.Rows[0]["TicketNumber"].ToString();
                    string departure = dt.Rows[0]["Departure"].ToString();
                    string arrival = dt.Rows[0]["Arrival"].ToString();
                    string time = dt.Rows[0]["Ticketdatetime"].ToString();
                    string seats = dt.Rows[0]["Seats"].ToString();

                    MessageBox.Show($"First Name : {fname} \n " +
                        $"Last Name : {lname}\n" +
                        $"Contact Number : {cntctnum}\n" +
                        $"CNIC : {cnic}\n" +
                        $"Ticket Number : {tcktnum}\n" +
                        $"Departure : {departure}\n" +
                        $"Arrival : {arrival}\n" +
                        $"Time : {time}\n" +
                        $"Seats : {seats}");
                }
                else
                {
                    MessageBox.Show("Ticket not Found");
                }
            }
        }
        //Print Passengerz Table
        private void button8_Click(object sender, EventArgs e)
        {
            
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            con.Open();

            cmd = new SqlCommand("SELECT * From passengerz", con);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panelUpdateTckt.Visible = true;
        }
        //Find and Update Ticket
        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Ticket Number is required.");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM passengerz WHERE ticketnumber = @ticket ", con);

                cmd.Parameters.AddWithValue("@ticket", textBox9.Text);

                int count = (int)cmd.ExecuteScalar();
                con.Close();
                if (count == 0)
                {
                    MessageBox.Show("Ticket Not Found.");
                }
                else
                {
                    con.Open();

                    cmd = new SqlCommand("SELECT FirstName, LastName, ContactNumber, CNIC, TicketNumber, Departure, Arrival, Ticketdatetime, Seats FROM passengerz WHERE TicketNumber = @TicketNumber", con);
                    cmd.Parameters.AddWithValue("@TicketNumber", textBox9.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fname = reader["FirstName"].ToString();
                        string lname = reader["LastName"].ToString();
                        string cntctnum = reader["ContactNumber"].ToString();
                        string cnic = reader["CNIC"].ToString();
                        string tcktnum = reader["TicketNumber"].ToString();
                        string departure = reader["Departure"].ToString();
                        string arrival = reader["Arrival"].ToString();

                        textBox13.Text = fname;
                        textBox11.Text = lname;
                        textBox12.Text = cntctnum;
                        textBox10.Text = cnic;
                    }
                    con.Close();
                }
            }
        }
        //Update Ticket
        private void button10_Click(object sender, EventArgs e)
        {
            if (updateTicketValidation())
            {
                int time = 0;
                time = Convert.ToInt32(comboBox13.Text);
                if (comboBox11.Text == "PM")
                {
                    if (time > 24)
                    {
                        time = 0;
                        time += 12;
                    }
                }

                DateTime datetime = DateTime.Parse($"2024-{comboBox17.Text}-{comboBox18.Text} {time.ToString()}:{comboBox12.Text}:00");
                //DateTime datetime = DateTime.Parse($"{comboBox4.Text}-{comboBox3.Text}-{comboBox2.Text} {time.ToString()}:{comboBox8.Text}:00");

                SqlConnection con = new SqlConnection(@"Data Source=ABDUL-QADIR\SQLEXPRESS;Initial Catalog=TrainTicketingSystem;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand("UPDATE passengerz SET FirstName = @firstname, LastName= @lastname, ContactNumber= @contactnumber, CNIC= @cnic, Departure= @departure, Arrival = @arrival, Ticketdatetime = @time, Seats= @seats WHERE ticketnumber= @tcktnum", con);

                cmd.Parameters.AddWithValue("@firstname", textBox13.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox11.Text);
                cmd.Parameters.AddWithValue("@tcktnum", textBox9.Text);
                cmd.Parameters.AddWithValue("@contactnumber", Convert.ToDecimal(textBox12.Text));
                cmd.Parameters.AddWithValue("@cnic", Convert.ToDecimal(textBox10.Text));
                cmd.Parameters.AddWithValue("@departure", comboBox15.Text);
                cmd.Parameters.AddWithValue("@arrival", comboBox14.Text);
                cmd.Parameters.AddWithValue("@time", datetime);
                cmd.Parameters.AddWithValue("@seats", Convert.ToInt16(comboBox19.Text));

                int status = cmd.ExecuteNonQuery();
                con.Close();
                if (status > 0)
                {
                    MessageBox.Show("Ticket Updated Successfully!!");

                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel6.Visible = true;
                    panel7.Visible = false;
                    panelUpdateTckt.Visible = false;
                }
            }
        }
        //Add passenger
        private void button1_Click(object sender, EventArgs e)
        {
            if (ticketValidation())
            {

                int time = 0;
                time = Convert.ToInt32(comboBox9.Text);
                if (comboBox7.Text == "PM")
                {
                    if(time > 24)
                    {
                        time = 0;
                        time += 12;
                    }    
                    
                }
                
                DateTime datetime = DateTime.Parse($"{comboBox4.Text}-{comboBox3.Text}-{comboBox2.Text} {time.ToString()}:{comboBox8.Text}:00");

                SqlConnection con = new SqlConnection(@"Data Source=ABDUL-QADIR\SQLEXPRESS;Initial Catalog=TrainTicketingSystem;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand("INSERT INTO passengerz VALUES(@firstname, @lastname, @contactnumber, @cnic, @ticketnumber, @departure, @arrival, @ticketdatetime, @seats)", con);

                cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox3.Text);
                cmd.Parameters.AddWithValue("@contactnumber", Convert.ToDecimal(textBox2.Text));
                cmd.Parameters.AddWithValue("@cnic", Convert.ToDecimal(textBox4.Text));
                cmd.Parameters.AddWithValue("@ticketnumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@departure", comboBox5.Text);
                cmd.Parameters.AddWithValue("@arrival", comboBox6.Text);
                cmd.Parameters.AddWithValue("@ticketdatetime", datetime);
                cmd.Parameters.AddWithValue("@seats", Convert.ToInt16(comboBox1.Text));

                int status = cmd.ExecuteNonQuery();
                con.Close();
                if (status > 0)
                {
                    MessageBox.Show("Passenger Added SuccessfullY!!");
                    panelUpdateTckt.Visible = false;
                    panel6.Visible = true;
                }
            }
        }
        //Cancel Ticket
        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Ticket Number is required.");
            }
            else
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("CNIC is required.");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE passengerz WHERE ticketnumber = @ticketnumber", con);
                cmd.Parameters.AddWithValue("@ticketnumber", textBox6.Text);                
                int status = cmd.ExecuteNonQuery();
                con.Close();
                if (status > 0)
                {
                    MessageBox.Show("Ticket Cancelled!!!!!!!.");
                }
            }
        }
        
        private void btnprntback_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panelUpdateTckt.Visible = false;
        }
        private bool ticketValidation()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("First name is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Last name is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
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
                MessageBox.Show("Ticket Number is required.");
                return false;
            }
            
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Number of Seats is required.");
                return false;
            }

            if (comboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Day is required.");
                return false;
            }
            if (comboBox3.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Month is required.");
                return false;
            }
            if (comboBox4.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Year is required.");
                return false;
            }
            if (comboBox5.SelectedIndex == 0)
            {
                MessageBox.Show("Departure is required.");
                return false;
            }
            if (comboBox6.SelectedIndex == 0)
            {
                MessageBox.Show("Arrival is required.");
                return false;
            }
            if (comboBox7.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Hour is required.");
                return false;
            }
            if (comboBox8.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Minute is required.");
                return false;
            }
            if (comboBox9.SelectedIndex == 0)
            {
                MessageBox.Show("Select AM or PM");
                return false;
            }
            if(comboBox5.Text == comboBox6.Text)
            {
                MessageBox.Show("The departure and arrival locations cannot be the same.");
                return false;
            }
            return true;
        }
        private bool updateTicketValidation()
        {
            if (string.IsNullOrEmpty(textBox13.Text))
            {
                MessageBox.Show("First name is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Last name is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox12.Text))
            {
                MessageBox.Show("Phone Number is required.");
                return false;
            }
            if (string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("CNIC is required.");
                return false;
            }
            if (comboBox19.SelectedIndex == 0)
            {
                MessageBox.Show("Number of Seats is required.");
                return false;
            }

            if (comboBox18.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Day is required.");
                return false;
            }
            if (comboBox17.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Month is required.");
                return false;
            }
            if (comboBox15.SelectedIndex == 0)
            {
                MessageBox.Show("Departure is required.");
                return false;
            }
            if (comboBox14.SelectedIndex == 0)
            {
                MessageBox.Show("Arrival is required.");
                return false;
            }
            if (comboBox13.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Hour is required.");
                return false;
            }
            if (comboBox12.SelectedIndex == 0)
            {
                MessageBox.Show("Ticket Minute is required.");
                return false;
            }
            if (comboBox11.SelectedIndex == 0)
            {
                MessageBox.Show("Select AM or PM");
                return false;
            }
            return true;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text == "Highest Price")
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM trainz ORDER BY TicketPrice DESC", con);
                DataTable data = new DataTable();
                SqlDataReader sdr = cmd.ExecuteReader();
                data.Load(sdr);
                dataGridView3.DataSource = data;
                con.Close();
            }
            if(comboBox10.Text == "Lowest Price")
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM trainz ORDER BY TicketPrice ASC", con);
                DataTable data = new DataTable();
                SqlDataReader sdr = cmd.ExecuteReader();
                data.Load(sdr);
                dataGridView3.DataSource = data;
                con.Close();
            }
        }

        private void panelUpdateTckt_Paint(object sender, PaintEventArgs e)
        {}

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}