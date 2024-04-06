namespace DDD_ASM_2
{
    partial class Teachers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teachers));
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPresent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AbsenceReasonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbReason = new System.Windows.Forms.ComboBox();
            this.txtAttendanceDate = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ProductID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIsPresent = new System.Windows.Forms.TextBox();
            this.lblIsPresentError = new System.Windows.Forms.Label();
            this.lblStudentIDError = new System.Windows.Forms.Label();
            this.lblCourseIDError = new System.Windows.Forms.Label();
            this.lblAttendanceDateError = new System.Windows.Forms.Label();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbCourseID = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(784, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(125, 43);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.CourseID,
            this.AttendanceDate,
            this.IsPresent,
            this.AbsenceReasonID});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 341);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(929, 400);
            this.dataGridView1.TabIndex = 5;
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "StudentID";
            this.StudentID.MinimumWidth = 6;
            this.StudentID.Name = "StudentID";
            // 
            // CourseID
            // 
            this.CourseID.DataPropertyName = "CourseID";
            this.CourseID.HeaderText = "CourseID";
            this.CourseID.MinimumWidth = 6;
            this.CourseID.Name = "CourseID";
            // 
            // AttendanceDate
            // 
            this.AttendanceDate.DataPropertyName = "AttendanceDate";
            this.AttendanceDate.HeaderText = "AttendanceDate";
            this.AttendanceDate.MinimumWidth = 6;
            this.AttendanceDate.Name = "AttendanceDate";
            // 
            // IsPresent
            // 
            this.IsPresent.DataPropertyName = "IsPresent";
            this.IsPresent.HeaderText = "IsPresent";
            this.IsPresent.MinimumWidth = 6;
            this.IsPresent.Name = "IsPresent";
            // 
            // AbsenceReasonID
            // 
            this.AbsenceReasonID.DataPropertyName = "AbsenceReasonID";
            this.AbsenceReasonID.HeaderText = "AbsenceReasonID";
            this.AbsenceReasonID.MinimumWidth = 6;
            this.AbsenceReasonID.Name = "AbsenceReasonID";
            // 
            // cbReason
            // 
            this.cbReason.FormattingEnabled = true;
            this.cbReason.Items.AddRange(new object[] {
            "None",
            "Sick",
            "Family problem",
            "Being late"});
            this.cbReason.Location = new System.Drawing.Point(625, 115);
            this.cbReason.Name = "cbReason";
            this.cbReason.Size = new System.Drawing.Size(188, 24);
            this.cbReason.TabIndex = 29;
            // 
            // txtAttendanceDate
            // 
            this.txtAttendanceDate.Location = new System.Drawing.Point(625, 62);
            this.txtAttendanceDate.Name = "txtAttendanceDate";
            this.txtAttendanceDate.Size = new System.Drawing.Size(188, 22);
            this.txtAttendanceDate.TabIndex = 28;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(266, 62);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(203, 22);
            this.txtStudentID.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "AbsenceReason";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "AttendanceDate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "CourseID";
            // 
            // ProductID
            // 
            this.ProductID.AutoSize = true;
            this.ProductID.Location = new System.Drawing.Point(161, 68);
            this.ProductID.Name = "ProductID";
            this.ProductID.Size = new System.Drawing.Size(65, 16);
            this.ProductID.TabIndex = 22;
            this.ProductID.Text = "StudentID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "IsPresent";
            // 
            // txtIsPresent
            // 
            this.txtIsPresent.Location = new System.Drawing.Point(266, 169);
            this.txtIsPresent.Name = "txtIsPresent";
            this.txtIsPresent.Size = new System.Drawing.Size(54, 22);
            this.txtIsPresent.TabIndex = 34;
            // 
            // lblIsPresentError
            // 
            this.lblIsPresentError.AutoSize = true;
            this.lblIsPresentError.Location = new System.Drawing.Point(266, 204);
            this.lblIsPresentError.Name = "lblIsPresentError";
            this.lblIsPresentError.Size = new System.Drawing.Size(0, 16);
            this.lblIsPresentError.TabIndex = 40;
            // 
            // lblStudentIDError
            // 
            this.lblStudentIDError.AutoSize = true;
            this.lblStudentIDError.Location = new System.Drawing.Point(266, 87);
            this.lblStudentIDError.Name = "lblStudentIDError";
            this.lblStudentIDError.Size = new System.Drawing.Size(0, 16);
            this.lblStudentIDError.TabIndex = 41;
            // 
            // lblCourseIDError
            // 
            this.lblCourseIDError.AutoSize = true;
            this.lblCourseIDError.Location = new System.Drawing.Point(266, 142);
            this.lblCourseIDError.Name = "lblCourseIDError";
            this.lblCourseIDError.Size = new System.Drawing.Size(0, 16);
            this.lblCourseIDError.TabIndex = 42;
            // 
            // lblAttendanceDateError
            // 
            this.lblAttendanceDateError.AutoSize = true;
            this.lblAttendanceDateError.Location = new System.Drawing.Point(624, 87);
            this.lblAttendanceDateError.Name = "lblAttendanceDateError";
            this.lblAttendanceDateError.Size = new System.Drawing.Size(0, 16);
            this.lblAttendanceDateError.TabIndex = 43;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(485, 278);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 47;
            this.btnChoose.Text = "Choose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(333, 278);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 45;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbCourseID
            // 
            this.cbCourseID.FormattingEnabled = true;
            this.cbCourseID.Items.AddRange(new object[] {
            "Database Design and Development",
            "Programing",
            "Professional"});
            this.cbCourseID.Location = new System.Drawing.Point(266, 115);
            this.cbCourseID.Name = "cbCourseID";
            this.cbCourseID.Size = new System.Drawing.Size(203, 24);
            this.cbCourseID.TabIndex = 48;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-2, -9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(929, 438);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // Teachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(921, 741);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbCourseID);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblAttendanceDateError);
            this.Controls.Add(this.lblCourseIDError);
            this.Controls.Add(this.lblStudentIDError);
            this.Controls.Add(this.lblIsPresentError);
            this.Controls.Add(this.txtIsPresent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbReason);
            this.Controls.Add(this.txtAttendanceDate);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProductID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Teachers";
            this.Text = "Teachers";
            this.Load += new System.EventHandler(this.Teachers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPresent;
        private System.Windows.Forms.DataGridViewTextBoxColumn AbsenceReasonID;
        private System.Windows.Forms.ComboBox cbReason;
        private System.Windows.Forms.TextBox txtAttendanceDate;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ProductID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIsPresent;
        private System.Windows.Forms.Label lblIsPresentError;
        private System.Windows.Forms.Label lblStudentIDError;
        private System.Windows.Forms.Label lblCourseIDError;
        private System.Windows.Forms.Label lblAttendanceDateError;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbCourseID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}