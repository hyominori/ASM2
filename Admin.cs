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
    public partial class Admin : Form
    {
        SqlConnection connection;
        public Admin()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;");
        }
        public Admin(string username)
        {
            InitializeComponent();
            connection = new SqlConnection("Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;");
            label1.Text = "User: " + username;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            connection.Open();
            FillData();
            FillDataTeacher();
            FillDataCourse();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Dispose();
        }
        private void btnLogoutTeacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Dispose();
        }
        private void btnLogoutCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Dispose();
        }
        public void FillData()
        {
            string query = "select * from Students";
            DataTable tbl = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tbl);
            dvgStudent.DataSource = tbl;
            connection.Close();
        }
        public void FillDataTeacher()
        {
            string query = "select * from Teachers";
            DataTable tbl = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tbl);
            dgvTeacher.DataSource = tbl;
            connection.Close();
        }
        public void FillDataCourse()
        {
            string query = "select * from Courses";
            DataTable tbl = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tbl);
            dgvCourses.DataSource = tbl;
            connection.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int error = 0;
            string studentID = txtStudentID.Text;
            if (studentID.Equals(""))
            {
                error++;
                lblIDError.Text = "Student ID can't be blank";
            }
            else
                lblIDError.Text = "";
            string studentName = txtStudentName.Text;
            if (studentName.Equals(""))
            {
                error++;
                lblNameError.Text = "Student Name can't be blank";
            }
            else
                lblDOBError.Text = "";
            string dateOfBirth = txtDateOfBirth.Text;
            if (dateOfBirth.Equals(""))
            {
                error++;
                lblDOBError.Text = "Date Of Birth can't be blank";
            }
            else
            {
                string query = "select * from Students where StudentID = @StudentID";
                connection.Open();
                SqlCommand cmdcheck = new SqlCommand(query, connection);
                cmdcheck.Parameters.Add("@StudentID", SqlDbType.VarChar);
                cmdcheck.Parameters["@StudentID"].Value = studentID;
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lblIDError.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lblDOBError.Text = "";
                }
                connection.Close();

                if (error == 0)
                {
                    string insert = "insert into Students values (@StudentID, @StudentName, @DateOfBirth)";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(insert, connection);
                    cmd.Parameters.Add("@StudentID", SqlDbType.VarChar);
                    cmd.Parameters["@StudentID"].Value = studentID;
                    cmd.Parameters.Add("@StudentName", SqlDbType.NChar);
                    cmd.Parameters["@StudentName"].Value = studentName;
                    cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date);
                    cmd.Parameters["@DateOfBirth"].Value = dateOfBirth;
                    cmd.ExecuteNonQuery();
                    FillData();
                    MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "";
            txtStudentName.Text = "";
            txtDateOfBirth.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string update = "update Students set StudentName =@StudentName, DateOfBirth =@DateOfBirth"
                    + " where StudentID = @StudentID";
                connection.Open();
                SqlCommand cmd = new SqlCommand(update, connection);
                cmd.Parameters.Add("@StudentName", SqlDbType.NChar);
                cmd.Parameters["@StudentName"].Value = txtStudentName.Text;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date);
                cmd.Parameters["@DateOfBirth"].Value = txtDateOfBirth.Text;
                cmd.Parameters.Add("@StudentID", SqlDbType.VarChar);
                cmd.Parameters["@StudentID"].Value = txtStudentID.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    FillData();
                    MessageBox.Show(this, "Updated successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string studentIDToDelete = txtStudentID.Text;

            // Xóa dữ liệu từ bảng Attendance của cơ sở dữ liệu
            string connectionString = "Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteAttendanceQuery = "DELETE FROM Attendance WHERE StudentID = @StudentID";
                using (SqlCommand commandAttendance = new SqlCommand(deleteAttendanceQuery, connection))
                {
                    commandAttendance.Parameters.AddWithValue("@StudentID", studentIDToDelete);
                    commandAttendance.ExecuteNonQuery();
                }
            }

            // Xóa dữ liệu từ bảng Students của cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteStudentQuery = "DELETE FROM Students WHERE StudentID = @StudentID";
                using (SqlCommand commandStudent = new SqlCommand(deleteStudentQuery, connection))
                {
                    commandStudent.Parameters.AddWithValue("@StudentID", studentIDToDelete);
                    commandStudent.ExecuteNonQuery();
                }
            }

            // Tạo một thể hiện mới của lớp Teachers
            Teachers teachersForm = Application.OpenForms.OfType<Teachers>().FirstOrDefault();
            if (teachersForm != null)
            {
                // Gọi phương thức DeleteRowByStudentID từ form Teachers để xóa dòng trong DataGridView
                teachersForm.DeleteRowByStudentID(studentIDToDelete);
            }

            // Xóa dòng từ DataGridView của form Admin
            foreach (DataGridViewRow row in dvgStudent.Rows)
            {
                if (row.Cells["StudentID"].Value != null && row.Cells["StudentID"].Value.ToString() == studentIDToDelete)
                {
                    dvgStudent.Rows.Remove(row);
                    break;
                }
            }

            MessageBox.Show(this, "Student deleted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dvgStudent.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dvgStudent.Rows[dvgStudent.SelectedCells[0].RowIndex];

                // Retrieve data from each cell and populate text boxes
                txtStudentID.Text = selectedRow.Cells["StudentID"].Value.ToString();
                txtStudentName.Text = selectedRow.Cells["StudentName"].Value.ToString();
                txtDateOfBirth.Text = selectedRow.Cells["DateOfBirth"].Value.ToString();
            }
        }
        private void btnInsert1_Click(object sender, EventArgs e)
        {
            int error = 0;
            string teacherID = txtTeacherID.Text;
            if (teacherID.Equals(""))
            {
                error++;
                lblTeacherIDError.Text = "Teacher ID can't be blank";
            }
            else
                lblTeacherIDError.Text = "";
            string teacherName = txtTeacherName.Text;
            if (teacherName.Equals(""))
            {
                error++;
                lblTeacherNameError.Text = "Teacher Name can't be blank";
            }
            else
                lblTeacherNameError.Text = "";
            string email = txtEmail.Text;
            if (email.Equals(""))
            {
                error++;
                lblEmailError.Text = "Email can't be blank";
            }
            else
                lblEmailError.Text = "";
            string phone = txtPhone.Text;
            if (phone.Equals(""))
            {
                error++;
                lblPhoneError.Text = "Phone can't be blank";
            }
            else
            {
                string query = "select * from Teachers where TeacherID = @TeacherID";
                connection.Open();
                SqlCommand cmdcheck = new SqlCommand(query, connection);
                cmdcheck.Parameters.Add("@TeacherID", SqlDbType.VarChar);
                cmdcheck.Parameters["@TeacherID"].Value = teacherID;
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lblTeacherIDError.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lblPhoneError.Text = "";
                }
                connection.Close();

                if (error == 0)
                {
                    string insert = "insert into Teachers values (@TeacherID, @TeacherName, @Email, @Phone)";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(insert, connection);
                    cmd.Parameters.Add("@TeacherID", SqlDbType.VarChar);
                    cmd.Parameters["@TeacherID"].Value = teacherID;
                    cmd.Parameters.Add("@TeacherName", SqlDbType.NChar);
                    cmd.Parameters["@TeacherName"].Value = teacherName;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                    cmd.Parameters["@Email"].Value = email;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
                    cmd.Parameters["@Phone"].Value = phone;
                    cmd.ExecuteNonQuery();
                    FillDataTeacher();
                    MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancelTeacher_Click(object sender, EventArgs e)
        {
            txtTeacherID.Text = "";
            txtTeacherName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
        private void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string update = "update Teachers set TeacherName =@TeacherName, Email =@Email, Phone =@Phone"
                    + " where TeacherID = @TeacherID";
                connection.Open();
                SqlCommand cmd = new SqlCommand(update, connection);
                cmd.Parameters.Add("@TeacherName", SqlDbType.NChar);
                cmd.Parameters["@TeacherName"].Value = txtTeacherName.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters["@Email"].Value = txtEmail.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
                cmd.Parameters["@Phone"].Value = txtPhone.Text;
                cmd.Parameters.Add("@TeacherID", SqlDbType.Int);
                cmd.Parameters["@TeacherID"].Value = txtTeacherID.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    FillDataTeacher();
                    MessageBox.Show(this, "Updated successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                connection.Open();
                string delete = "delete from Teachers where TeacherID = @TeacherID";
                SqlCommand cmd = new SqlCommand(delete, connection);
                cmd.Parameters.Add("@TeacherID", SqlDbType.VarChar);
                cmd.Parameters["@TeacherID"].Value = txtTeacherID.Text;
                cmd.ExecuteNonQuery();
                FillDataTeacher();
                MessageBox.Show(this, "Deleted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnChooseTeacher_Click(object sender, EventArgs e)
        {
            if (dgvTeacher.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTeacher.Rows[dgvTeacher.SelectedCells[0].RowIndex];

                // Retrieve data from each cell and populate text boxes
                txtTeacherID.Text = selectedRow.Cells["TeacherID"].Value.ToString();
                txtTeacherName.Text = selectedRow.Cells["TeacherName"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtPhone.Text = selectedRow.Cells["Phone"].Value.ToString();
            }
        }

        private void btnInsertCourse_Click(object sender, EventArgs e)
        {
            int error = 0;
            string courseID = txtCourseID.Text;
            if (courseID.Equals(""))
            {
                error++;
                lblCourseIDError.Text = "Course ID can't be blank";
            }
            else
                lblCourseIDError.Text = "";
            string courseName = txtCourseName.Text;
            if (courseName.Equals(""))
            {
                error++;
                lblCourseNameError.Text = "Course Name can't be blank";
            }
            else
                lblCourseNameError.Text = "";
            string startDate = txtStartDate.Text;
            if (startDate.Equals(""))
            {
                error++;
                lblStartDateError.Text = "Start Date can't be blank";
            }
            else
                lblStartDateError.Text = "";
            string endDate = txtEndDate.Text;
            if (endDate.Equals(""))
            {
                error++;
                lblEndDateError.Text = "End Date can't be blank";   
            }
            else
            {
                string query = "select * from Courses where CourseID = @CourseID";
                connection.Open();
                SqlCommand cmdcheck = new SqlCommand(query, connection);
                cmdcheck.Parameters.Add("@CourseID", SqlDbType.Int);
                cmdcheck.Parameters["@CourseID"].Value = courseID;
                SqlDataReader reader = cmdcheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lblCourseIDError.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lblEndDateError.Text = "";
                }
                connection.Close();
                if (error == 0)
                {
                    string insert = "insert into Courses values (@CourseID, @CourseName, @StartDate, @EndDate)";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(insert, connection);
                    cmd.Parameters.Add("@CourseID", SqlDbType.Int);
                    cmd.Parameters["@CourseID"].Value = courseID;
                    cmd.Parameters.Add("@CourseName", SqlDbType.VarChar);
                    cmd.Parameters["@CourseName"].Value = courseName;
                    cmd.Parameters.Add("@StartDate", SqlDbType.Date);
                    cmd.Parameters["@StartDate"].Value = startDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.Date);
                    cmd.Parameters["@EndDate"].Value = endDate;
                    cmd.ExecuteNonQuery();
                    FillDataCourse();
                    MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancelCourse_Click(object sender, EventArgs e)
        {
            txtCourseID.Text = "";
            txtCourseName.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string update = "update Courses set CourseName =@CourseName, StartDate =@StartDate, EndDate =@EndDate"
                    + " where CourseID = @CourseID";
                connection.Open();
                SqlCommand cmd = new SqlCommand(update, connection);
                cmd.Parameters.Add("@CourseName", SqlDbType.VarChar);
                cmd.Parameters["@CourseName"].Value = txtCourseName.Text;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date);
                cmd.Parameters["@StartDate"].Value = txtStartDate.Text;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date);
                cmd.Parameters["@EndDate"].Value = txtEndDate.Text;
                cmd.Parameters.Add("@CourseID", SqlDbType.Int);
                cmd.Parameters["@CourseID"].Value = txtCourseID.Text;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    FillDataCourse();
                    MessageBox.Show(this, "Updated successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnChooseCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCourses.Rows[dgvCourses.SelectedCells[0].RowIndex];

                // Retrieve data from each cell and populate text boxes
                txtCourseID.Text = selectedRow.Cells["CourseID"].Value.ToString();
                txtCourseName.Text = selectedRow.Cells["CourseName"].Value.ToString();
                txtStartDate.Text = selectedRow.Cells["StartDate"].Value.ToString();
                txtEndDate.Text = selectedRow.Cells["EndDate"].Value.ToString();
            }
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                connection.Open();
                string delete = "delete from Courses where CourseID = @CourseID";
                SqlCommand cmd = new SqlCommand(delete, connection);
                cmd.Parameters.Add("@CourseID", SqlDbType.Int);
                cmd.Parameters["@CourseID"].Value = txtCourseID.Text;
                cmd.ExecuteNonQuery();
                FillDataCourse();
                MessageBox.Show(this, "Deleted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
