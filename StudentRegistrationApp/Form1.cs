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
using MySql.Data.MySqlClient;



namespace StudentRegistrationApp
{
    public partial class Form1 : Form
    {
        //connection
        /*
        1. Create Connection String
        2.Create MysqlConnection object
        3. Open the Connection
        4. Close the Connection
        */
        static string constr = "SERVER = localhost; DATABASE = college; USERNAME =root; PASSWORD = '';";

        MySqlConnection conn = new MySqlConnection(constr);
        int rollno = 0;

        public Form1()
        {
            InitializeComponent();
        }
        public void DisplayData()
        {
            conn.Open();
            string query = "SELECT * FROM student";
            MySqlDataAdapter adr = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                /*
                1. Create the sql string

                2. Create the MySqlCommand object
                3. ExecuteNonQuery()
                */

                int rollno = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                string address = textBox3.Text;
                string query = "INSERT INTO student VALUES("+rollno+", '"+name+"', '"+address+"')";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Data Insert Successful");
                else
                    MessageBox.Show("Error in Insertion");
                conn.Close();
                DisplayData();
            }
            else
            {
                MessageBox.Show("Data no fill");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                string name = textBox2.Text;
                string address = textBox3.Text;
                string query = "UPDATE student SET name = '" + name + "' , address ='"+address+"' WHERE rollno = "+rollno+"";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Update Successful");
                else
                    MessageBox.Show("Error in Updation");
                conn.Close();
                DisplayData();
            }
            else
            {
                MessageBox.Show("Data not fill");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rollno != 0)
            {
                conn.Open();
                string query = "DELETE FROM student WHERE rollno = " + rollno + "";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Delete Successful!");
                else
                    MessageBox.Show("Error in Deletion");
                conn.Close();
                DisplayData();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rollno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string address = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = rollno.ToString();
            textBox2.Text = name;
            textBox3.Text = address;

        }
        /* public Form1()
{
InitializeComponent();
}*/

    }
}
