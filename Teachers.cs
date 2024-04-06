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
using System.Xml.Linq;

namespace DDD_ASM_2
{
    public partial class Teachers : Form
    {
        private string studentIDToDelete;
        SqlConnection connection;
        public Teachers()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;");
        }
        public Teachers(string username)
        {
            InitializeComponent();
            connection = new SqlConnection("Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;");
            label1.Text = "User: " + username;
        }
        public void DeleteRowByStudentID(string studentID)
        {
            // Xóa dòng từ DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["StudentID"].Value != null && row.Cells["StudentID"].Value.ToString() == studentID)
                {
                    dataGridView1.Rows.Remove(row);
                    break;
                }
            }

            // Xóa dữ liệu từ cơ sở dữ liệu
            string connectionString = "Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Attendance WHERE StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            connection.Open();
            FillDataAttendanceTeacher();
            GetAbsenceReason();
            GetCourses();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Dispose();
        }

        private void FillDataAttendanceTeacher()
        {
            string query = "Select * from Attendance";
            DataTable tbl = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tbl);
            dataGridView1.DataSource = tbl;
            connection.Close();
        }
        public void GetAbsenceReason()
        {
            string query = "select AbsenceReasonID, Reason from AbsenceReason";
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);
            cbReason.DataSource = table;
            cbReason.DisplayMember = "Reason";
            cbReason.ValueMember = "AbsenceReasonID";
        }
        public void GetCourses()
        {
            string query = "select CourseID, CourseName from Courses";
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(table);
            cbCourseID.DataSource = table;
            cbCourseID.DisplayMember = "CourseName";
            cbCourseID.ValueMember = "CourseID";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "";
            cbCourseID.Text = "";
            txtIsPresent.Text = "";
            txtAttendanceDate.Text = "";
            cbReason.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string update = "update Attendance set AttendanceDate =@AttendanceDate, IsPresent =@IsPresent, " +
                    "AbsenceReasonID =@AbsenceReasonID, CourseID =@CourseID" + " where StudentID = @StudentID";
                connection.Open();
                SqlCommand cmd = new SqlCommand(update, connection);
                cmd.Parameters.Add("@AttendanceDate", SqlDbType.Date).Value = txtAttendanceDate.Text;
                cmd.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = txtStudentID.Text;

                int isPresentValue;
                if (int.TryParse(txtIsPresent.Text, out isPresentValue))
                {
                    cmd.Parameters.Add("@IsPresent", SqlDbType.Int).Value = isPresentValue;
                }
                else
                {
                    // Handle the case where the text cannot be converted to an integer
                    // For example, display an error message to the user.
                    MessageBox.Show(this, "Invalid value for IsPresent. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return;
                }
                cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = cbCourseID.SelectedValue;
                cmd.Parameters.Add("@AbsenceReasonID", SqlDbType.Int).Value = cbReason.SelectedValue;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    FillDataAttendanceTeacher();
                    MessageBox.Show(this, "Updated successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

                // Retrieve data from each cell and populate text boxes
                txtStudentID.Text = selectedRow.Cells["StudentID"].Value.ToString();
                cbCourseID.Text = selectedRow.Cells["CourseID"].Value.ToString();
                txtIsPresent.Text = selectedRow.Cells["IsPresent"].Value.ToString();
                txtAttendanceDate.Text = selectedRow.Cells["AttendanceDate"].Value.ToString();
                cbReason.Text = selectedRow.Cells["AbsenceReasonID"].Value.ToString();
            }
        }
    }
}   
