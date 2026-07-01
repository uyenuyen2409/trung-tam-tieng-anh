namespace QL_trung_tam_tieng_anh.Forms
{
    partial class frmDangKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangKy));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbHocVien = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKhoaHoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayDangKy = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblStatsTitle = new System.Windows.Forms.Label();
            this.lblStatsValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng ký học";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Học viên:";
            // 
            // cmbHocVien
            // 
            this.cmbHocVien.FormattingEnabled = true;
            this.cmbHocVien.Location = new System.Drawing.Point(30, 95);
            this.cmbHocVien.Name = "cmbHocVien";
            this.cmbHocVien.Size = new System.Drawing.Size(250, 24);
            this.cmbHocVien.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Khóa học:";
            // 
            // cmbKhoaHoc
            // 
            this.cmbKhoaHoc.FormattingEnabled = true;
            this.cmbKhoaHoc.Location = new System.Drawing.Point(30, 165);
            this.cmbKhoaHoc.Name = "cmbKhoaHoc";
            this.cmbKhoaHoc.Size = new System.Drawing.Size(250, 24);
            this.cmbKhoaHoc.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Thời gian đăng ký:";
            // 
            // dtpNgayDangKy
            // 
            this.dtpNgayDangKy.Location = new System.Drawing.Point(450, 95);
            this.dtpNgayDangKy.Name = "dtpNgayDangKy";
            this.dtpNgayDangKy.Size = new System.Drawing.Size(250, 22);
            this.dtpNgayDangKy.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Trạng thái:";
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Location = new System.Drawing.Point(450, 165);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(250, 24);
            this.cmbTrangThai.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(30, 235);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 17;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(140, 235);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 19;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(250, 235);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 20;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(400, 345);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 21;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(290, 345);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 27;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKy.Location = new System.Drawing.Point(30, 410);
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.RowHeadersWidth = 51;
            this.dgvDangKy.RowTemplate.Height = 24;
            this.dgvDangKy.Size = new System.Drawing.Size(1666, 329);
            this.dgvDangKy.TabIndex = 28;
            this.dgvDangKy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDangKy_CellContentClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(30, 345);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(265, 22);
            this.txtTimKiem.TabIndex = 30;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(813, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(217, 169);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 31;
            this.picLogo.TabStop = false;
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.lblStatsValue);
            this.pnlStats.Controls.Add(this.lblStatsTitle);
            this.pnlStats.Location = new System.Drawing.Point(1250, 70);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(350, 120);
            this.pnlStats.TabIndex = 32;
            // 
            // lblStatsTitle
            // 
            this.lblStatsTitle.AutoSize = true;
            this.lblStatsTitle.Location = new System.Drawing.Point(3, 4);
            this.lblStatsTitle.Name = "lblStatsTitle";
            this.lblStatsTitle.Size = new System.Drawing.Size(108, 16);
            this.lblStatsTitle.TabIndex = 0;
            this.lblStatsTitle.Text = "Tổng số đăng ký";
            // 
            // lblStatsValue
            // 
            this.lblStatsValue.AutoSize = true;
            this.lblStatsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsValue.Location = new System.Drawing.Point(165, 54);
            this.lblStatsValue.Name = "lblStatsValue";
            this.lblStatsValue.Size = new System.Drawing.Size(21, 22);
            this.lblStatsValue.TabIndex = 2;
            this.lblStatsValue.Text = "0";
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1662, 776);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvDangKy);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cmbTrangThai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpNgayDangKy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKhoaHoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbHocVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDangKy";
            this.Text = "frmDangKy";
            this.Load += new System.EventHandler(this.frmDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbHocVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKhoaHoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvDangKy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Label lblStatsValue;
    }
}