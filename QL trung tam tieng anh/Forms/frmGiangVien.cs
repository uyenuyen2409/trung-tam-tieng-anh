using QL_trung_tam_tieng_anh.DAL;
using QL_trung_tam_tieng_anh.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QL_trung_tam_tieng_anh.Forms
{
    public partial class frmGiangVien : Form
    {
        private readonly GiangVienDAL dal = new GiangVienDAL();
        private int selectedId = 0;
        public frmGiangVien()
        {
            InitializeComponent();
            cmbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            SetupGrid();
            LoadData();
            
        }

        private void ApplyTheme()
        {
            Theme.StyleForm(this);
            Theme.StyleTitle(label1);
            Theme.StyleTextBox(txtHoTen);
            Theme.StyleTextBox(txtSDT);
            Theme.StyleTextBox(txtEmail);
            Theme.StyleTextBox(txtChuyenMon);
            Theme.StyleTextBox(txtTimKiem);
            Theme.StyleComboBox(cmbGioiTinh);
            Theme.StylePrimaryButton(btnThem);
            Theme.StylePrimaryButton(btnSua);
            Theme.StyleDangerButton(btnXoa);
            Theme.StyleSecondaryButton(btnLamMoi);
            Theme.StyleSecondaryButton(btnTimKiem);
            Theme.StyleGrid(dgvGiangVien);
            Theme.StyleFormWithBackground(this, @"D:\trung-tam-tieng-anh\QL trung tam tieng anh\new.jpg");

            pnlStats.BackColor = Color.White;
            lblStatsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatsTitle.ForeColor = Theme.TextGray;
            lblStatsValue.Font = new Font("Bahnschrift", 32F, FontStyle.Bold);
            lblStatsValue.ForeColor = Theme.Navy;
        }

        private void SetupGrid()
        {
            dgvGiangVien.AutoGenerateColumns = false;
            dgvGiangVien.Columns.Clear();
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaGV", DataPropertyName = "MaGV", HeaderText = "Mã GV", Width = 70 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", DataPropertyName = "HoTen", HeaderText = "Họ tên", Width = 160 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioiTinh", DataPropertyName = "GioiTinh", HeaderText = "Giới tính", Width = 90 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgaySinh", DataPropertyName = "NgaySinh", HeaderText = "Ngày sinh", Width = 100 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "SDT", DataPropertyName = "SDT", HeaderText = "SĐT", Width = 110 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", DataPropertyName = "Email", HeaderText = "Email", Width = 200 });
            dgvGiangVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "ChuyenMon", DataPropertyName = "ChuyenMon", HeaderText = "Chuyên môn", Width = 180 });

            dgvGiangVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiangVien.MultiSelect = false;
            dgvGiangVien.ReadOnly = true;
            dgvGiangVien.AllowUserToAddRows = false;

            dgvGiangVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGiangVien.ColumnHeadersHeight = 40;
            dgvGiangVien.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvGiangVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private void LoadData()
        {
            var list = dal.GetAll();
            dgvGiangVien.DataSource = list;
            lblStatsValue.Text = list.Count.ToString();
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtHoTen.Text = "";
            cmbGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtChuyenMon.Text = "";
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
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && dal.IsTrungEmail(txtEmail.Text, selectedId))
            {
                MessageBox.Show("Email đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private GiangVien GetFormData()
        {
            return new GiangVien
            {
                MaGV = selectedId,
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = cmbGioiTinh.SelectedItem?.ToString(),
                NgaySinh = dtpNgaySinh.Value,
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ChuyenMon = txtChuyenMon.Text.Trim()
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            var gv = GetFormData();
            dal.Add(gv);
            MessageBox.Show("Đã thêm giảng viên", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;
            var gv = GetFormData();
            dal.Update(gv);
            MessageBox.Show("Đã cập nhật giảng viên", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("Xóa giảng viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                dal.Delete(selectedId);
                MessageBox.Show("Đã xóa giảng viên", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dgvGiangVien.DataSource = filtered;
        }

        private void dgvGiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvGiangVien.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["MaGV"].Value);
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            cmbGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value?.ToString();
            if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            txtSDT.Text = row.Cells["SDT"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtChuyenMon.Text = row.Cells["ChuyenMon"].Value?.ToString();
        }
    }
}
