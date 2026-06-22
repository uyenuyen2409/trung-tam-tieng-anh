using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using QL_trung_tam_tieng_anh.DAL;

namespace QL_trung_tam_tieng_anh.Forms
{
    public partial class frmTongQuan : Form
    {
        private readonly HocVienDAL hvDal = new HocVienDAL();
        private readonly GiangVienDAL gvDal = new GiangVienDAL();
        private readonly KhoaHocDAL khDal = new KhoaHocDAL();
        private readonly DangKyHocDAL dkDal = new DangKyHocDAL();
        public frmTongQuan()
        {
            InitializeComponent();
        }

        private void frmTongQuan_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadStats();
            LoadChart();
        }

        private void ApplyTheme()
        {
            Theme.StyleFormWithBackground(this, @"D:\trung-tam-tieng-anh\QL trung tam tieng anh\new.jpg");
            lblTitle.Font = Theme.FontTitle;
            lblTitle.ForeColor = Theme.Navy;

            StyleCard(pnlHocVien, lblHVTitle, lblHVValue);
            StyleCard(pnlGiangVien, lblGVTitle, lblGVValue);
            StyleCard(pnlKhoaHoc, lblKHTitle, lblKHValue);
            StyleCard(pnlDangKy, lblDKTitle, lblDKValue);
        }

        private void StyleCard(Panel pnl, Label title, Label value)
        {
            pnl.BackColor = Color.White;
            title.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            title.ForeColor = Theme.TextGray;
            value.Font = new Font("Bahnschrift", 28F, FontStyle.Bold);
            value.ForeColor = Theme.Navy;
        }

        private void LoadStats()
        {
            lblHVValue.Text = hvDal.GetAll().Count.ToString();
            lblGVValue.Text = gvDal.GetAll().Count.ToString();
            lblKHValue.Text = khDal.GetAll().Count.ToString();
            lblDKValue.Text = dkDal.GetAll().Count.ToString();
        }

        private void LoadChart()
        {
            chartDangKy.Series.Clear();
            chartDangKy.Titles.Clear();
            chartDangKy.Legends.Clear();
            chartDangKy.Titles.Add("Tỉ lệ trạng thái đăng ký");

            var list = dkDal.GetAll();
            var dangHoc = list.Count(x => x.TrangThai == "Đang học");
            var hoanThanh = list.Count(x => x.TrangThai == "Hoàn thành");
            var daHuy = list.Count(x => x.TrangThai == "Đã hủy");

            var series = new Series("TrangThai")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true
            };
            series.Points.AddXY("Đang học", dangHoc);
            series.Points.AddXY("Hoàn thành", hoanThanh);
            series.Points.AddXY("Đã hủy", daHuy);

            series.Points[0].Color = ColorTranslator.FromHtml("#0091FF");
            series.Points[1].Color = ColorTranslator.FromHtml("#3DDC97");
            series.Points[2].Color = ColorTranslator.FromHtml("#FF5733");

            chartDangKy.Series.Add(series);
            chartDangKy.Legends.Add(new Legend("Legend1"));
        }

        private void chartDangKy_Click(object sender, EventArgs e)
        {

        }
    }
}
