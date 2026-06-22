using QL_trung_tam_tieng_anh.DAL;
using QL_trung_tam_tieng_anh.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QL_trung_tam_tieng_anh.Forms
{
    public partial class frmHocVien : Form
    {
        private readonly HocVienDAL dal = new HocVienDAL();
        private int selectedId = 0;

        public frmHocVien()
        {
            InitializeComponent();
            cmbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
        }

        private void LoadData()
        {
            var list = dal.GetAll();
            dgvHocVien.DataSource = list;
            lblStatsValue.Text = list.Count.ToString();
        }

        private void frmHocVien_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            SetupGrid();
            LoadData();
            
            
        }

        private void ApplyTheme()
        {
            Theme.StyleForm(this);
            Theme.StyleTitle(label2);
            Theme.StyleTextBox(txtHoTen);
            Theme.StyleTextBox(txtSDT);
            Theme.StyleTextBox(txtEmail);
            Theme.StyleTextBox(txtDiaChi);
            Theme.StyleTextBox(txtTimKiem);
            Theme.StyleComboBox(cmbGioiTinh);
            Theme.StylePrimaryButton(btnThem);
            Theme.StylePrimaryButton(btnSua);
            Theme.StyleDangerButton(btnXoa);
            Theme.StyleSecondaryButton(btnLamMoi);
            Theme.StyleSecondaryButton(btnTimKiem);
            Theme.StyleGrid(dgvHocVien);
            Theme.StyleFormWithBackground(this, @"D:\trung-tam-tieng-anh\QL trung tam tieng anh\new.jpg");

            pnlStats.BackColor = Color.White;
            lblStatsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatsTitle.ForeColor = Theme.TextGray;
            lblStatsValue.Font = new Font("Bahnschrift", 32F, FontStyle.Bold);
            lblStatsValue.ForeColor = Theme.Navy;
        }



        private void SetupGrid()
        {
            dgvHocVien.AutoGenerateColumns = false;
            dgvHocVien.Columns.Clear();
            dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaHV", DataPropertyName = "MaHV", HeaderText = "Mã HV", Width = 70 });
            dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", DataPropertyName = "HoTen", HeaderText = "Họ tên", Width = 160 });
            dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioiTinh", DataPropertyName = "GioiTinh", HeaderText = "Giới tính", Width = 90 });
            dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgaySinh", DataPropertyName = "NgaySinh", HeaderText = "Ngày sinh", Width = 100 });
            dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "SDT", DataPropertyName = "SDT", HeaderText = "SĐT", Width = 110 });
            dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", DataPropertyName = "Email", HeaderText = "Email", Width = 200 });
            dgvHocVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaChi", DataPropertyName = "DiaChi", HeaderText = "Địa chỉ", Width = 180 });

            dgvHocVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocVien.MultiSelect = false;
            dgvHocVien.ReadOnly = true;
            dgvHocVien.AllowUserToAddRows = false;

            dgvHocVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHocVien.ColumnHeadersHeight = 40;
            dgvHocVien.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHocVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        

        private void ClearForm()
        {
            selectedId = 0;
            txtHoTen.Text = "";
            cmbGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtSDT.Text) && !System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text, @"^[0-9]{9,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (9-11 số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtSDT.Text) && dal.IsTrungSDT(txtSDT.Text, selectedId))
            {
                MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private HocVien GetFormData()
        {
            return new HocVien
            {
                MaHV = selectedId,
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = cmbGioiTinh.SelectedItem?.ToString(),
                NgaySinh = dtpNgaySinh.Value,
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            var hv = GetFormData();
            dal.Add(hv);
            MessageBox.Show("Đã thêm học viên", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;
            var hv = GetFormData();
            dal.Update(hv);
            MessageBox.Show("Đã cập nhật học viên", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("Xóa học viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                dal.Delete(selectedId);
                MessageBox.Show("Đã xóa học viên", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var filtered = dal.GetAll()
                .Where(x => x.HoTen.ToLower().Contains(keyword)
                    || (x.SDT ?? "").Contains(keyword)
                    || (x.Email ?? "").ToLower().Contains(keyword))
                .ToList();
            dgvHocVien.DataSource = filtered;
        }


        private void dgvHocVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHocVien.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["MaHV"].Value);
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            cmbGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value?.ToString();
            if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            txtSDT.Text = row.Cells["SDT"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
        }

        private void pnlStats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblStatsTitle_Click(object sender, EventArgs e)
        {

        }
    }
}