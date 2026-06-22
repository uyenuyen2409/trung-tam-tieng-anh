namespace QL_trung_tam_tieng_anh
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnKhoaHoc = new System.Windows.Forms.Button();
            this.btnGiangVien = new System.Windows.Forms.Button();
            this.btnHocVien = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.btnTongQuan);
            this.pnlSidebar.Controls.Add(this.btnDangKy);
            this.pnlSidebar.Controls.Add(this.btnKhoaHoc);
            this.pnlSidebar.Controls.Add(this.btnGiangVien);
            this.pnlSidebar.Controls.Add(this.btnHocVien);
            this.pnlSidebar.Controls.Add(this.lblBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(213, 811);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(12, 336);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(172, 45);
            this.btnDangKy.TabIndex = 4;
            this.btnDangKy.Text = "Đăng ký học";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnKhoaHoc
            // 
            this.btnKhoaHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.btnKhoaHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhoaHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoaHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoaHoc.ForeColor = System.Drawing.Color.White;
            this.btnKhoaHoc.Location = new System.Drawing.Point(12, 273);
            this.btnKhoaHoc.Name = "btnKhoaHoc";
            this.btnKhoaHoc.Size = new System.Drawing.Size(172, 45);
            this.btnKhoaHoc.TabIndex = 3;
            this.btnKhoaHoc.Text = "Khóa học";
            this.btnKhoaHoc.UseVisualStyleBackColor = false;
            this.btnKhoaHoc.Click += new System.EventHandler(this.btnKhoaHoc_Click);
            // 
            // btnGiangVien
            // 
            this.btnGiangVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.btnGiangVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiangVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiangVien.ForeColor = System.Drawing.Color.White;
            this.btnGiangVien.Location = new System.Drawing.Point(12, 206);
            this.btnGiangVien.Name = "btnGiangVien";
            this.btnGiangVien.Size = new System.Drawing.Size(172, 45);
            this.btnGiangVien.TabIndex = 2;
            this.btnGiangVien.Text = "Giảng viên";
            this.btnGiangVien.UseVisualStyleBackColor = false;
            this.btnGiangVien.Click += new System.EventHandler(this.btnGiangVien_Click);
            // 
            // btnHocVien
            // 
            this.btnHocVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.btnHocVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHocVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHocVien.ForeColor = System.Drawing.Color.White;
            this.btnHocVien.Location = new System.Drawing.Point(12, 126);
            this.btnHocVien.Name = "btnHocVien";
            this.btnHocVien.Size = new System.Drawing.Size(172, 45);
            this.btnHocVien.TabIndex = 1;
            this.btnHocVien.Text = "Học viên";
            this.btnHocVien.UseVisualStyleBackColor = false;
            this.btnHocVien.Click += new System.EventHandler(this.btnHocVien_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Lucida Sans Unicode", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.Transparent;
            this.lblBrand.Location = new System.Drawing.Point(3, 9);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(205, 31);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "English Center";
            // 
            // btnTongQuan
            // 
            this.btnTongQuan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.btnTongQuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTongQuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTongQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongQuan.ForeColor = System.Drawing.Color.White;
            this.btnTongQuan.Location = new System.Drawing.Point(12, 58);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Size = new System.Drawing.Size(172, 45);
            this.btnTongQuan.TabIndex = 5;
            this.btnTongQuan.Text = "Tổng quan";
            this.btnTongQuan.UseVisualStyleBackColor = false;
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1327, 811);
            this.Controls.Add(this.pnlSidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trung Tâm Anh Ngữ - Hệ thống quản lý";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnKhoaHoc;
        private System.Windows.Forms.Button btnGiangVien;
        private System.Windows.Forms.Button btnHocVien;
        private System.Windows.Forms.Button btnTongQuan;
    }
}

