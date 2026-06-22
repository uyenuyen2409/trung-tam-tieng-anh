using System.Drawing;
using System.Windows.Forms;

namespace QL_trung_tam_tieng_anh
{
    public static class Theme
    {
        // Màu sắc chủ đạo
        public static readonly Color Navy = ColorTranslator.FromHtml("#1B2A5E");
        public static readonly Color NavyLight = ColorTranslator.FromHtml("#253A6E");
        public static readonly Color Red = ColorTranslator.FromHtml("#E8382A");
        public static readonly Color BgLight = ColorTranslator.FromHtml("#F7F8FC");
        public static readonly Color White = Color.White;
        public static readonly Color TextDark = ColorTranslator.FromHtml("#1F2937");
        public static readonly Color TextGray = ColorTranslator.FromHtml("#6B7280");
        public static readonly Color BorderGray = ColorTranslator.FromHtml("#E5E7EB");

        public static readonly Font FontTitle = new Font("Bahnschrift", 22F, FontStyle.Bold);
        public static readonly Font FontLabel = new Font("Segoe UI Semibold", 9.5F, FontStyle.Regular);
        public static readonly Font FontInput = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FontButton = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);

        public static void StyleForm(Form f)
        {
            f.BackColor = BgLight;
            f.Font = FontInput;
        }

        public static void StyleTitle(Label lbl)
        {
            lbl.Font = FontTitle;
            lbl.ForeColor = Navy;
        }

        public static void StyleLabel(Label lbl)
        {
            lbl.Font = FontLabel;
            lbl.ForeColor = TextGray;
        }

        public static void StyleTextBox(TextBox txt)
        {
            txt.Font = FontInput;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = White;
        }

        public static void StyleComboBox(ComboBox cmb)
        {
            cmb.Font = FontInput;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = White;
        }

        public static void StylePrimaryButton(Button btn)
        {
            btn.Font = FontButton;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Navy;
            btn.ForeColor = White;
            btn.Cursor = Cursors.Hand;
            btn.Height = 38;
        }

        public static void StyleDangerButton(Button btn)
        {
            btn.Font = FontButton;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Red;
            btn.ForeColor = White;
            btn.Cursor = Cursors.Hand;
            btn.Height = 38;
        }

        public static void StyleSecondaryButton(Button btn)
        {
            btn.Font = FontButton;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = BorderGray;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = White;
            btn.ForeColor = Navy;
            btn.Cursor = Cursors.Hand;
            btn.Height = 38;
        }

        public static void StyleGrid(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = White;
            dgv.GridColor = BorderGray;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = FontInput;
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DCE3F7");
            dgv.DefaultCellStyle.SelectionForeColor = TextDark;
            dgv.RowTemplate.Height = 36;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F7F8FC");
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        public static void StyleFormWithBackground(Form f, string imagePath)
        {
            f.BackgroundImage = Image.FromFile(imagePath);
            f.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}