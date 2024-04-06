using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD_ASM_2
{
    public partial class Students : Form
    {
        SqlConnection connection;
        public Students()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;");
        }
        public Students(string username)
        {
            InitializeComponent();
            connection = new SqlConnection("Server=LAPTOP-3PKRMNSC;Database=AttendanceSystem;Integrated Security = true;");
            label1.Text = "User: " + username;
        }

        private void Students_Load(object sender, EventArgs e)
        {
            FillDataAttendanceStudent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
            this.Dispose();
        }
        public void FillDataAttendanceStudent()
        {
            string query = "select * from Attendance";
            DataTable tbl = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tbl);
            dgvAttendanceStudent.DataSource = tbl;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            bool found = false;

            foreach (DataGridViewRow row in dgvAttendanceStudent.Rows)
            {
                // Kiểm tra giá trị của cột cụ thể (ví dụ: cột StudentID hoặc StudentName)
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        // Tìm thấy giá trị tương ứng với từ khóa tìm kiếm
                        row.Selected = true;
                        dgvAttendanceStudent.CurrentCell = cell;
                        found = true;
                        break; // Thoát khỏi vòng lặp trong trường hợp tìm thấy
                    }
                }

                if (found)
                {
                    break; // Thoát khỏi vòng lặp ngoài cùng nếu tìm thấy
                }
            }

            if (!found)
            {
                MessageBox.Show("Can't find this ID", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
