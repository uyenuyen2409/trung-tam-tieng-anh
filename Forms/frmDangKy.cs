using QL_trung_tam_tieng_anh.DAL;
using QL_trung_tam_tieng_anh.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QL_trung_tam_tieng_anh.Forms
{ 
    public partial class frmDangKy : Form
    {
        private readonly DangKyHocDAL dal = new DangKyHocDAL();
        private readonly HocVienDAL hvDal = new HocVienDAL();
        private readonly KhoaHocDAL khDal = new KhoaHocDAL();
        private int selectedId = 0;

        public frmDangKy()
            {
                InitializeComponent();
                cmbTrangThai.Items.AddRange(new string[] { "Đang học", "Hoàn thành", "Đã hủy" });
            }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadOptions();
            SetupGrid();
            LoadData();
        }

        private void ApplyTheme()
        {
            Theme.StyleForm(this);
            Theme.StyleTitle(label1);
            Theme.StyleComboBox(cmbHocVien);
            Theme.StyleComboBox(cmbKhoaHoc);
            Theme.StyleComboBox(cmbTrangThai);
            Theme.StyleTextBox(txtTimKiem);
            Theme.StylePrimaryButton(btnThem);
            Theme.StylePrimaryButton(btnSua);
            Theme.StyleDangerButton(btnXoa);
            Theme.StyleSecondaryButton(btnLamMoi);
            Theme.StyleSecondaryButton(btnTimKiem);
            Theme.StyleGrid(dgvDangKy);
            Theme.StyleFormWithBackground(this, @"D:\trung-tam-tieng-anh\QL trung tam tieng anh\new.jpg");

            pnlStats.BackColor = Color.White;
            lblStatsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatsTitle.ForeColor = Theme.TextGray;
            lblStatsValue.Font = new Font("Bahnschrift", 32F, FontStyle.Bold);
            lblStatsValue.ForeColor = Theme.Navy;
        }

        private void LoadOptions()
        {
            cmbHocVien.DisplayMember = "HoTen";
            cmbHocVien.ValueMember = "MaHV";
            cmbHocVien.DataSource = hvDal.GetAll();

            cmbKhoaHoc.DisplayMember = "TenKH";
            cmbKhoaHoc.ValueMember = "MaKH";
            cmbKhoaHoc.DataSource = khDal.GetAll();
        }

        private void SetupGrid()
        {
            dgvDangKy.AutoGenerateColumns = false;
            dgvDangKy.Columns.Clear();
            dgvDangKy.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDK", DataPropertyName = "MaDK", HeaderText = "Mã ĐK", Width = 70 });
            dgvDangKy.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenHV", DataPropertyName = "TenHV", HeaderText = "Học viên", Width = 160 });
            dgvDangKy.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKH", DataPropertyName = "TenKH", HeaderText = "Khóa học", Width = 160 });
            dgvDangKy.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayDangKy", DataPropertyName = "NgayDangKy", HeaderText = "Ngày đăng ký", Width = 110 });
            dgvDangKy.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", DataPropertyName = "TrangThai", HeaderText = "Trạng thái", Width = 110 });

            dgvDangKy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDangKy.MultiSelect = false;
            dgvDangKy.ReadOnly = true;
            dgvDangKy.AllowUserToAddRows = false;

            dgvDangKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDangKy.ColumnHeadersHeight = 40;
            dgvDangKy.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvDangKy.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void LoadData()
        {
            var list = dal.GetAll();
            dgvDangKy.DataSource = list;
            lblStatsValue.Text = list.Count.ToString();
        }

        private void ClearForm()
        {
            selectedId = 0;
            if (cmbHocVien.Items.Count > 0) cmbHocVien.SelectedIndex = 0;
            if (cmbKhoaHoc.Items.Count > 0) cmbKhoaHoc.SelectedIndex = 0;
            dtpNgayDangKy.Value = DateTime.Now;
            cmbTrangThai.SelectedIndex = 0;
        }

        private bool ValidateInput()
        {
            if (cmbHocVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn học viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbKhoaHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khóa học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            int maHV = (int)cmbHocVien.SelectedValue;
            int maKH = (int)cmbKhoaHoc.SelectedValue;
            if (dal.IsTrungDangKy(maHV, maKH, selectedId))
            {
                MessageBox.Show("Học viên này đã đăng ký khóa học này rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private DangKyHoc GetFormData()
        {
            return new DangKyHoc
            {
                MaDK = selectedId,
                MaHV = (int)cmbHocVien.SelectedValue,
                MaKH = (int)cmbKhoaHoc.SelectedValue,
                NgayDangKy = dtpNgayDangKy.Value,
                TrangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Đang học"
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            var dk = GetFormData();
            dal.Add(dk);
            MessageBox.Show("Đã thêm đăng ký", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn đăng ký cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;
            var dk = GetFormData();
            dal.Update(dk);
            MessageBox.Show("Đã cập nhật đăng ký", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn đăng ký cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("Xóa đăng ký này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                dal.Delete(selectedId);
                MessageBox.Show("Đã xóa đăng ký", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                .Where(x => x.TenHV.ToLower().Contains(keyword)
                    || x.TenKH.ToLower().Contains(keyword))
                .ToList();
            dgvDangKy.DataSource = filtered;
        }

        private void dgvDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvDangKy.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["MaDK"].Value);

            var dkFull = dal.GetById(selectedId);
            cmbHocVien.SelectedValue = dkFull.MaHV;
            cmbKhoaHoc.SelectedValue = dkFull.MaKH;
            dtpNgayDangKy.Value = dkFull.NgayDangKy;
            cmbTrangThai.SelectedItem = dkFull.TrangThai;
        }
    }
}
