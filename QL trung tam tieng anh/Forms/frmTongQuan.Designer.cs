namespace QL_trung_tam_tieng_anh.Forms
{
    partial class frmTongQuan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTongQuan));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHocVien = new System.Windows.Forms.Panel();
            this.lblHVValue = new System.Windows.Forms.Label();
            this.lblHVTitle = new System.Windows.Forms.Label();
            this.pnlGiangVien = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGVTitle = new System.Windows.Forms.Label();
            this.pnlKhoaHoc = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblKHTitle = new System.Windows.Forms.Label();
            this.pnlDangKy = new System.Windows.Forms.Panel();
            this.lblDKTitle = new System.Windows.Forms.Label();
            this.lblGVValue = new System.Windows.Forms.Label();
            this.lblKHValue = new System.Windows.Forms.Label();
            this.lblDKValue = new System.Windows.Forms.Label();
            this.chartDangKy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlHocVien.SuspendLayout();
            this.pnlGiangVien.SuspendLayout();
            this.pnlKhoaHoc.SuspendLayout();
            this.pnlDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(24, 45);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tổng quan";
            // 
            // pnlHocVien
            // 
            this.pnlHocVien.Controls.Add(this.lblHVValue);
            this.pnlHocVien.Controls.Add(this.lblHVTitle);
            this.pnlHocVien.Location = new System.Drawing.Point(30, 90);
            this.pnlHocVien.Name = "pnlHocVien";
            this.pnlHocVien.Size = new System.Drawing.Size(250, 110);
            this.pnlHocVien.TabIndex = 1;
            // 
            // lblHVValue
            // 
            this.lblHVValue.AutoSize = true;
            this.lblHVValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHVValue.Location = new System.Drawing.Point(100, 47);
            this.lblHVValue.Name = "lblHVValue";
            this.lblHVValue.Size = new System.Drawing.Size(21, 22);
            this.lblHVValue.TabIndex = 1;
            this.lblHVValue.Text = "0";
            // 
            // lblHVTitle
            // 
            this.lblHVTitle.AutoSize = true;
            this.lblHVTitle.Location = new System.Drawing.Point(17, 9);
            this.lblHVTitle.Name = "lblHVTitle";
            this.lblHVTitle.Size = new System.Drawing.Size(70, 16);
            this.lblHVTitle.TabIndex = 0;
            this.lblHVTitle.Text = "HỌC VIÊN";
            // 
            // pnlGiangVien
            // 
            this.pnlGiangVien.Controls.Add(this.lblGVValue);
            this.pnlGiangVien.Controls.Add(this.label6);
            this.pnlGiangVien.Controls.Add(this.lblGVTitle);
            this.pnlGiangVien.Location = new System.Drawing.Point(300, 90);
            this.pnlGiangVien.Name = "pnlGiangVien";
            this.pnlGiangVien.Size = new System.Drawing.Size(250, 110);
            this.pnlGiangVien.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 16);
            this.label6.TabIndex = 2;
            // 
            // lblGVTitle
            // 
            this.lblGVTitle.AutoSize = true;
            this.lblGVTitle.Location = new System.Drawing.Point(3, 9);
            this.lblGVTitle.Name = "lblGVTitle";
            this.lblGVTitle.Size = new System.Drawing.Size(71, 16);
            this.lblGVTitle.TabIndex = 1;
            this.lblGVTitle.Text = "Giảng viên";
            // 
            // pnlKhoaHoc
            // 
            this.pnlKhoaHoc.Controls.Add(this.lblKHValue);
            this.pnlKhoaHoc.Controls.Add(this.label7);
            this.pnlKhoaHoc.Controls.Add(this.lblKHTitle);
            this.pnlKhoaHoc.Location = new System.Drawing.Point(570, 90);
            this.pnlKhoaHoc.Name = "pnlKhoaHoc";
            this.pnlKhoaHoc.Size = new System.Drawing.Size(250, 110);
            this.pnlKhoaHoc.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 16);
            this.label7.TabIndex = 2;
            // 
            // lblKHTitle
            // 
            this.lblKHTitle.AutoSize = true;
            this.lblKHTitle.Location = new System.Drawing.Point(3, 9);
            this.lblKHTitle.Name = "lblKHTitle";
            this.lblKHTitle.Size = new System.Drawing.Size(63, 16);
            this.lblKHTitle.TabIndex = 1;
            this.lblKHTitle.Text = "Khóa học";
            // 
            // pnlDangKy
            // 
            this.pnlDangKy.Controls.Add(this.lblDKValue);
            this.pnlDangKy.Controls.Add(this.lblDKTitle);
            this.pnlDangKy.Location = new System.Drawing.Point(840, 90);
            this.pnlDangKy.Name = "pnlDangKy";
            this.pnlDangKy.Size = new System.Drawing.Size(250, 110);
            this.pnlDangKy.TabIndex = 4;
            // 
            // lblDKTitle
            // 
            this.lblDKTitle.AutoSize = true;
            this.lblDKTitle.Location = new System.Drawing.Point(12, 9);
            this.lblDKTitle.Name = "lblDKTitle";
            this.lblDKTitle.Size = new System.Drawing.Size(81, 16);
            this.lblDKTitle.TabIndex = 1;
            this.lblDKTitle.Text = "Đăng ký học";
            // 
            // lblGVValue
            // 
            this.lblGVValue.AutoSize = true;
            this.lblGVValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGVValue.Location = new System.Drawing.Point(118, 47);
            this.lblGVValue.Name = "lblGVValue";
            this.lblGVValue.Size = new System.Drawing.Size(21, 22);
            this.lblGVValue.TabIndex = 3;
            this.lblGVValue.Text = "0";
            // 
            // lblKHValue
            // 
            this.lblKHValue.AutoSize = true;
            this.lblKHValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKHValue.Location = new System.Drawing.Point(118, 47);
            this.lblKHValue.Name = "lblKHValue";
            this.lblKHValue.Size = new System.Drawing.Size(21, 22);
            this.lblKHValue.TabIndex = 3;
            this.lblKHValue.Text = "0";
            // 
            // lblDKValue
            // 
            this.lblDKValue.AutoSize = true;
            this.lblDKValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDKValue.Location = new System.Drawing.Point(125, 47);
            this.lblDKValue.Name = "lblDKValue";
            this.lblDKValue.Size = new System.Drawing.Size(21, 22);
            this.lblDKValue.TabIndex = 2;
            this.lblDKValue.Text = "0";
            // 
            // chartDangKy
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDangKy.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDangKy.Legends.Add(legend1);
            this.chartDangKy.Location = new System.Drawing.Point(30, 230);
            this.chartDangKy.Name = "chartDangKy";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDangKy.Series.Add(series1);
            this.chartDangKy.Size = new System.Drawing.Size(1060, 400);
            this.chartDangKy.TabIndex = 5;
            this.chartDangKy.Text = "chart1";
            this.chartDangKy.Click += new System.EventHandler(this.chartDangKy_Click);
            // 
            // frmTongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 773);
            this.Controls.Add(this.chartDangKy);
            this.Controls.Add(this.pnlDangKy);
            this.Controls.Add(this.pnlKhoaHoc);
            this.Controls.Add(this.pnlGiangVien);
            this.Controls.Add(this.pnlHocVien);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTongQuan";
            this.Text = "frmTongQuan";
            this.Load += new System.EventHandler(this.frmTongQuan_Load);
            this.pnlHocVien.ResumeLayout(false);
            this.pnlHocVien.PerformLayout();
            this.pnlGiangVien.ResumeLayout(false);
            this.pnlGiangVien.PerformLayout();
            this.pnlKhoaHoc.ResumeLayout(false);
            this.pnlKhoaHoc.PerformLayout();
            this.pnlDangKy.ResumeLayout(false);
            this.pnlDangKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDangKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlHocVien;
        private System.Windows.Forms.Label lblHVValue;
        private System.Windows.Forms.Label lblHVTitle;
        private System.Windows.Forms.Panel pnlGiangVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGVTitle;
        private System.Windows.Forms.Panel pnlKhoaHoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblKHTitle;
        private System.Windows.Forms.Panel pnlDangKy;
        private System.Windows.Forms.Label lblDKTitle;
        private System.Windows.Forms.Label lblGVValue;
        private System.Windows.Forms.Label lblKHValue;
        private System.Windows.Forms.Label lblDKValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDangKy;
    }
}