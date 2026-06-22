using QL_trung_tam_tieng_anh.DAL;
using QL_trung_tam_tieng_anh.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QL_trung_tam_tieng_anh.Forms
{
    public partial class frmKhoaHoc : Form
    {
        private readonly KhoaHocDAL dal = new KhoaHocDAL();
        private readonly GiangVienDAL gvDal = new GiangVienDAL();
        private int selectedId = 0;
        public frmKhoaHoc()
        {
            InitializeComponent();
        }

        private void frmKhoaHoc_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadGiangVienOptions();
            SetupGrid();
            LoadData();
        }

        private void ApplyTheme()
        {
            Theme.StyleForm(this);
            Theme.StyleTitle(label1);
            Theme.StyleTextBox(txtTenKH);
            Theme.StyleTextBox(txtMoTa);
            Theme.StyleTextBox(txtHocPhi);
            Theme.StyleTextBox(txtThoiLuong);
            Theme.StyleTextBox(txtTimKiem);
            Theme.StyleComboBox(cmbGiangVien);
            Theme.StylePrimaryButton(btnThem);
            Theme.StylePrimaryButton(btnSua);
            Theme.StyleDangerButton(btnXoa);
            Theme.StyleSecondaryButton(btnLamMoi);
            Theme.StyleSecondaryButton(btnTimKiem);
            Theme.StyleGrid(dgvKhoaHoc);
            Theme.StyleFormWithBackground(this, @"D:\trung-tam-tieng-anh\QL trung tam tieng anh\new.jpg");

            pnlStats.BackColor = Color.White;
            lblStatsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatsTitle.ForeColor = Theme.TextGray;
            lblStatsValue.Font = new Font("Bahnschrift", 32F, FontStyle.Bold);
            lblStatsValue.ForeColor = Theme.Navy;
        }
        private void LoadGiangVienOptions()
        {
            cmbGiangVien.DisplayMember = "HoTen";
            cmbGiangVien.ValueMember = "MaGV";
            var list = gvDal.GetAll();
            list.Insert(0, new Models.GiangVien { MaGV = 0, HoTen = "-- Chưa phân công --" });
            cmbGiangVien.DataSource = list;
        }

        private void SetupGrid()
        {
            dgvKhoaHoc.AutoGenerateColumns = false;
            dgvKhoaHoc.Columns.Clear();
            dgvKhoaHoc.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKH", DataPropertyName = "MaKH", HeaderText = "Mã KH", Width = 70 });
            dgvKhoaHoc.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKH", DataPropertyName = "TenKH", HeaderText = "Tên khóa học", Width = 160 });
            dgvKhoaHoc.Columns.Add(new DataGridViewTextBoxColumn { Name = "MoTa", DataPropertyName = "MoTa", HeaderText = "Mô tả", Width = 160 });
            dgvKhoaHoc.Columns.Add(new DataGridViewTextBoxColumn { Name = "HocPhi", DataPropertyName = "HocPhi", HeaderText = "Học phí", Width = 100 });
            dgvKhoaHoc.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThoiLuong", DataPropertyName = "ThoiLuong", HeaderText = "Thời lượng", Width = 90 });
            dgvKhoaHoc.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenGV", DataPropertyName = "TenGV", HeaderText = "Giảng viên", Width = 160 });

            dgvKhoaHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoaHoc.MultiSelect = false;
            dgvKhoaHoc.ReadOnly = true;
            dgvKhoaHoc.AllowUserToAddRows = false;

            dgvKhoaHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvKhoaHoc.ColumnHeadersHeight = 40;
            dgvKhoaHoc.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvKhoaHoc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void LoadData()
        {
            var list = dal.GetAll();
            dgvKhoaHoc.DataSource = list;
            lblStatsValue.Text = list.Count.ToString();
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtTenKH.Text = "";
            txtMoTa.Text = "";
            txtHocPhi.Text = "";
            txtThoiLuong.Text = "";
            cmbGiangVien.SelectedIndex = 0;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khóa học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtHocPhi.Text, out decimal hocPhi) || hocPhi < 0)
            {
                MessageBox.Show("Học phí không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtThoiLuong.Text, out int thoiLuong) || thoiLuong <= 0)
            {
                MessageBox.Show("Thời lượng phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dal.IsTrungTen(txtTenKH.Text, selectedId))
            {
                MessageBox.Show("Tên khóa học đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private KhoaHoc GetFormData()
        {
            int maGV = (int)cmbGiangVien.SelectedValue;
            return new KhoaHoc
            {
                MaKH = selectedId,
                TenKH = txtTenKH.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                HocPhi = decimal.Parse(txtHocPhi.Text),
                ThoiLuong = int.Parse(txtThoiLuong.Text),
                MaGV = maGV == 0 ? (int?)null : maGV
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            var kh = GetFormData();
            dal.Add(kh);
            MessageBox.Show("Đã thêm khóa học", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn khóa học cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;
            var kh = GetFormData();
            dal.Update(kh);
            MessageBox.Show("Đã cập nhật khóa học", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn khóa học cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("Xóa khóa học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                dal.Delete(selectedId);
                MessageBox.Show("Đã xóa khóa học", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                .Where(x => x.TenKH.ToLower().Contains(keyword)
                    || (x.MoTa ?? "").ToLower().Contains(keyword)
                    || (x.TenGV ?? "").ToLower().Contains(keyword))
                .ToList();
            dgvKhoaHoc.DataSource = filtered;
        }

        private void dgvKhoaHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvKhoaHoc.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["MaKH"].Value);
            txtTenKH.Text = row.Cells["TenKH"].Value?.ToString();
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
            txtHocPhi.Text = row.Cells["HocPhi"].Value?.ToString();
            txtThoiLuong.Text = row.Cells["ThoiLuong"].Value?.ToString();

            var khFull = dal.GetById(selectedId);
            cmbGiangVien.SelectedValue = khFull.MaGV ?? 0;
        }
    }
}
