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

namespace DDD_ASM_2
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;");
            button1.Text = "Show";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string query = "select * from Users where username =@username and u_password =@password";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;
            cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar);
            cmd.Parameters["@password"].Value = password;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string role = reader["u_role"].ToString();
                if (role.Equals("admin"))
                {
                    MessageBox.Show(this, "Login successful! ", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    Admin p = new Admin(username);
                    p.ShowDialog();
                    this.Dispose();
                }
                else if (role.Equals("student"))
                {
                    MessageBox.Show(this, "Login successful! ", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    Students vp = new Students(username);
                    vp.ShowDialog();
                    this.Dispose();
                }
                else if (role.Equals("teacher"))
                {
                    MessageBox.Show(this, "Login successful", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    Teachers p = new Teachers(username);
                    p.ShowDialog();
                    this.Dispose();
                }
                else
                    lblError.Text = "You are not allowed to access";
            }
            else
            {
                lblError.Text = "Wrong username or password";
            }
            connection.Close();

        }

        private bool isPasswordVisible = false;
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.UseSystemPasswordChar = !isPasswordVisible;

            if (isPasswordVisible)
            {
                button1.Text = "Hide";
            }
            else
            {
                button1.Text = "Show";
            }
        }
    }
}
