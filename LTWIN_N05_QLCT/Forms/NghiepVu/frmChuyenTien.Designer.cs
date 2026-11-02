using System.Drawing;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    partial class frmChuyenTien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Main scrollable panel
            this.pnlMain = new Panel();
            this.lblChuyenTienGiuaCacVi = new Label();
            this.lblThongTinChuyenTien = new Label();

            // Card 1: Input form
            this.pnlChuyenTien = new Panel();
            this.lblViNguon = new Label();
            this.cboViNguon = new ComboBox();
            this.lblViDich = new Label();
            this.cboViDich = new ComboBox();
            this.lblNgay = new Label();
            this.dtpNgay = new DateTimePicker();
            this.lblSoTien = new Label();
            this.txtSoTien = new TextBox();
            this.lblGhiChu = new Label();
            this.txtGhiChu = new TextBox();
            this.btnChuyenTien = new Button();
            this.btnMoi = new Button();

            // Card 2: Preview banner
            this.pnlChuyenTien2 = new Panel();
            this.lblSauKhiChuyenDuKienVietcombank = new Label();
            this.lblChuyenNoiBoKhongTinhVao = new Label();

            // Card 3: History table
            this.lblLichSuChuyenTien = new Label();
            this.dgvLichSuChuyenTien = new DataGridView();
            this.lblSoGiaoDich = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuChuyenTien)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlChuyenTien.SuspendLayout();
            this.pnlChuyenTien2.SuspendLayout();
            this.SuspendLayout();

            // =============================================
            // pnlMain
            // =============================================
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlMain.Controls.Add(this.lblChuyenTienGiuaCacVi);
            this.pnlMain.Controls.Add(this.lblThongTinChuyenTien);
            this.pnlMain.Controls.Add(this.pnlChuyenTien);
            this.pnlMain.Controls.Add(this.pnlChuyenTien2);
            this.pnlMain.Controls.Add(this.lblLichSuChuyenTien);
            this.pnlMain.Controls.Add(this.dgvLichSuChuyenTien);
            this.pnlMain.Controls.Add(this.lblSoGiaoDich);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(20, 10, 20, 10);
            this.pnlMain.Size = new System.Drawing.Size(1060, 600);
            this.pnlMain.TabIndex = 0;

            // =============================================
            // lblChuyenTienGiuaCacVi
            // =============================================
            this.lblChuyenTienGiuaCacVi.AutoSize = true;
            this.lblChuyenTienGiuaCacVi.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblChuyenTienGiuaCacVi.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblChuyenTienGiuaCacVi.Location = new System.Drawing.Point(20, 12);
            this.lblChuyenTienGiuaCacVi.Name = "lblChuyenTienGiuaCacVi";
            this.lblChuyenTienGiuaCacVi.Size = new System.Drawing.Size(235, 28);
            this.lblChuyenTienGiuaCacVi.Text = "Chuyển tiền giữa các ví";

            // =============================================
            // lblThongTinChuyenTien
            // =============================================
            this.lblThongTinChuyenTien.AutoSize = true;
            this.lblThongTinChuyenTien.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblThongTinChuyenTien.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblThongTinChuyenTien.Location = new System.Drawing.Point(20, 48);
            this.lblThongTinChuyenTien.Name = "lblThongTinChuyenTien";
            this.lblThongTinChuyenTien.Size = new System.Drawing.Size(155, 19);
            this.lblThongTinChuyenTien.Text = "Thông tin chuyển tiền";

            // =============================================
            // pnlChuyenTien
            // =============================================
            this.pnlChuyenTien.BackColor = System.Drawing.Color.White;
            this.pnlChuyenTien.BorderStyle = BorderStyle.FixedSingle;
            this.pnlChuyenTien.Controls.Add(this.lblViNguon);
            this.pnlChuyenTien.Controls.Add(this.cboViNguon);
            this.pnlChuyenTien.Controls.Add(this.lblViDich);
            this.pnlChuyenTien.Controls.Add(this.cboViDich);
            this.pnlChuyenTien.Controls.Add(this.lblNgay);
            this.pnlChuyenTien.Controls.Add(this.dtpNgay);
            this.pnlChuyenTien.Controls.Add(this.lblSoTien);
            this.pnlChuyenTien.Controls.Add(this.txtSoTien);
            this.pnlChuyenTien.Controls.Add(this.lblGhiChu);
            this.pnlChuyenTien.Controls.Add(this.txtGhiChu);
            this.pnlChuyenTien.Controls.Add(this.btnChuyenTien);
            this.pnlChuyenTien.Controls.Add(this.btnMoi);
            this.pnlChuyenTien.Location = new System.Drawing.Point(20, 72);
            this.pnlChuyenTien.Name = "pnlChuyenTien";
            this.pnlChuyenTien.Padding = new Padding(16, 12, 16, 12);
            this.pnlChuyenTien.Size = new System.Drawing.Size(1005, 140);
            this.pnlChuyenTien.TabIndex = 1;

            // lblViNguon
            this.lblViNguon.AutoSize = true;
            this.lblViNguon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViNguon.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblViNguon.Location = new System.Drawing.Point(16, 12);
            this.lblViNguon.Name = "lblViNguon";
            this.lblViNguon.Size = new System.Drawing.Size(55, 15);
            this.lblViNguon.Text = "Ví nguồn";

            // cboViNguon
            this.cboViNguon.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboViNguon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboViNguon.Location = new System.Drawing.Point(16, 32);
            this.cboViNguon.Name = "cboViNguon";
            this.cboViNguon.Size = new System.Drawing.Size(220, 25);
            this.cboViNguon.TabIndex = 0;

            // lblViDich
            this.lblViDich.AutoSize = true;
            this.lblViDich.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViDich.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblViDich.Location = new System.Drawing.Point(252, 12);
            this.lblViDich.Name = "lblViDich";
            this.lblViDich.Size = new System.Drawing.Size(43, 15);
            this.lblViDich.Text = "Ví đích";

            // cboViDich
            this.cboViDich.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboViDich.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboViDich.Location = new System.Drawing.Point(252, 32);
            this.cboViDich.Name = "cboViDich";
            this.cboViDich.Size = new System.Drawing.Size(220, 25);
            this.cboViDich.TabIndex = 1;

            // lblNgay
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgay.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblNgay.Location = new System.Drawing.Point(488, 12);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(77, 15);
            this.lblNgay.Text = "Ngày chuyển";

            // dtpNgay
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNgay.Format = DateTimePickerFormat.Custom;
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Location = new System.Drawing.Point(488, 32);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(140, 24);
            this.dtpNgay.TabIndex = 2;

            // lblSoTien
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoTien.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSoTien.Location = new System.Drawing.Point(644, 12);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(63, 15);
            this.lblSoTien.Text = "Số tiền (đ)";

            // txtSoTien
            this.txtSoTien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoTien.Location = new System.Drawing.Point(644, 32);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(160, 24);
            this.txtSoTien.TabIndex = 3;
            this.txtSoTien.TextAlign = HorizontalAlignment.Right;

            // lblGhiChu
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblGhiChu.Location = new System.Drawing.Point(16, 70);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(48, 15);
            this.lblGhiChu.Text = "Ghi chú";

            // txtGhiChu
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGhiChu.Location = new System.Drawing.Point(16, 90);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(612, 24);
            this.txtGhiChu.TabIndex = 4;

            // btnChuyenTien
            this.btnChuyenTien.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnChuyenTien.FlatStyle = FlatStyle.Flat;
            this.btnChuyenTien.FlatAppearance.BorderSize = 0;
            this.btnChuyenTien.ForeColor = System.Drawing.Color.White;
            this.btnChuyenTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnChuyenTien.Location = new System.Drawing.Point(644, 86);
            this.btnChuyenTien.Name = "btnChuyenTien";
            this.btnChuyenTien.Size = new System.Drawing.Size(120, 30);
            this.btnChuyenTien.TabIndex = 5;
            this.btnChuyenTien.Text = "Chuyển tiền";
            this.btnChuyenTien.Cursor = Cursors.Hand;
            this.btnChuyenTien.UseVisualStyleBackColor = false;

            // btnMoi
            this.btnMoi.FlatStyle = FlatStyle.Flat;
            this.btnMoi.FlatAppearance.BorderSize = 1;
            this.btnMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnMoi.BackColor = System.Drawing.Color.White;
            this.btnMoi.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMoi.Location = new System.Drawing.Point(774, 86);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(80, 30);
            this.btnMoi.TabIndex = 6;
            this.btnMoi.Text = "Mới";
            this.btnMoi.Cursor = Cursors.Hand;

            // =============================================
            // pnlChuyenTien2
            // =============================================
            this.pnlChuyenTien2.BackColor = System.Drawing.Color.FromArgb(232, 245, 253);
            this.pnlChuyenTien2.BorderStyle = BorderStyle.FixedSingle;
            this.pnlChuyenTien2.Controls.Add(this.lblSauKhiChuyenDuKienVietcombank);
            this.pnlChuyenTien2.Controls.Add(this.lblChuyenNoiBoKhongTinhVao);
            this.pnlChuyenTien2.Location = new System.Drawing.Point(20, 222);
            this.pnlChuyenTien2.Name = "pnlChuyenTien2";
            this.pnlChuyenTien2.Padding = new Padding(12, 6, 12, 6);
            this.pnlChuyenTien2.Size = new System.Drawing.Size(1005, 50);
            this.pnlChuyenTien2.TabIndex = 2;

            this.lblSauKhiChuyenDuKienVietcombank.AutoSize = true;
            this.lblSauKhiChuyenDuKienVietcombank.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSauKhiChuyenDuKienVietcombank.ForeColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.lblSauKhiChuyenDuKienVietcombank.Location = new System.Drawing.Point(12, 6);
            this.lblSauKhiChuyenDuKienVietcombank.Name = "lblSauKhiChuyenDuKienVietcombank";
            this.lblSauKhiChuyenDuKienVietcombank.Text = "Sau khi chuyển dự kiến: —";

            this.lblChuyenNoiBoKhongTinhVao.AutoSize = true;
            this.lblChuyenNoiBoKhongTinhVao.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblChuyenNoiBoKhongTinhVao.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblChuyenNoiBoKhongTinhVao.Location = new System.Drawing.Point(12, 26);
            this.lblChuyenNoiBoKhongTinhVao.Name = "lblChuyenNoiBoKhongTinhVao";
            this.lblChuyenNoiBoKhongTinhVao.Text = "Chuyển nội bộ không tính vào thu – chi.";

            // =============================================
            // lblLichSuChuyenTien
            // =============================================
            this.lblLichSuChuyenTien.AutoSize = true;
            this.lblLichSuChuyenTien.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblLichSuChuyenTien.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblLichSuChuyenTien.Location = new System.Drawing.Point(20, 282);
            this.lblLichSuChuyenTien.Name = "lblLichSuChuyenTien";
            this.lblLichSuChuyenTien.Size = new System.Drawing.Size(135, 19);
            this.lblLichSuChuyenTien.Text = "Lịch sử chuyển tiền";

            // =============================================
            // dgvLichSuChuyenTien
            // =============================================
            this.dgvLichSuChuyenTien.AllowUserToAddRows = false;
            this.dgvLichSuChuyenTien.AllowUserToDeleteRows = false;
            this.dgvLichSuChuyenTien.ReadOnly = true;
            this.dgvLichSuChuyenTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuChuyenTien.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSuChuyenTien.BorderStyle = BorderStyle.FixedSingle;
            this.dgvLichSuChuyenTien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLichSuChuyenTien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvLichSuChuyenTien.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(21, 101, 192),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold),
                SelectionBackColor = System.Drawing.Color.FromArgb(21, 101, 192),
                SelectionForeColor = System.Drawing.Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(4)
            };
            this.dgvLichSuChuyenTien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLichSuChuyenTien.ColumnHeadersHeight = 36;
            this.dgvLichSuChuyenTien.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new System.Drawing.Font("Segoe UI", 9.5F),
                SelectionBackColor = System.Drawing.Color.FromArgb(232, 245, 253),
                SelectionForeColor = System.Drawing.Color.Black,
                Padding = new Padding(4)
            };
            this.dgvLichSuChuyenTien.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(248, 248, 248),
                SelectionBackColor = System.Drawing.Color.FromArgb(232, 245, 253),
                SelectionForeColor = System.Drawing.Color.Black
            };
            this.dgvLichSuChuyenTien.EnableHeadersVisualStyles = false;
            this.dgvLichSuChuyenTien.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvLichSuChuyenTien.Location = new System.Drawing.Point(20, 306);
            this.dgvLichSuChuyenTien.Name = "dgvLichSuChuyenTien";
            this.dgvLichSuChuyenTien.RowHeadersVisible = false;
            this.dgvLichSuChuyenTien.RowTemplate.Height = 32;
            this.dgvLichSuChuyenTien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuChuyenTien.Size = new System.Drawing.Size(1005, 210);
            this.dgvLichSuChuyenTien.TabIndex = 3;

            // =============================================
            // lblSoGiaoDich
            // =============================================
            this.lblSoGiaoDich.AutoSize = true;
            this.lblSoGiaoDich.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSoGiaoDich.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblSoGiaoDich.Location = new System.Drawing.Point(20, 524);
            this.lblSoGiaoDich.Name = "lblSoGiaoDich";
            this.lblSoGiaoDich.Size = new System.Drawing.Size(271, 15);
            this.lblSoGiaoDich.TabIndex = 4;
            this.lblSoGiaoDich.Text = "Chỉ đọc • 0 giao dịch • Tổng số tiền đã chuyển: 0 đ";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 600);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmChuyenTien";
            this.Text = "Quản Lý Chi Tiêu — Chuyển tiền giữa các ví";

            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuChuyenTien)).EndInit();
            this.pnlChuyenTien.ResumeLayout(false);
            this.pnlChuyenTien.PerformLayout();
            this.pnlChuyenTien2.ResumeLayout(false);
            this.pnlChuyenTien2.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Label lblChuyenTienGiuaCacVi;
        private Label lblThongTinChuyenTien;

        private Panel pnlChuyenTien;
        private Label lblViNguon;
        private ComboBox cboViNguon;
        private Label lblViDich;
        private ComboBox cboViDich;
        private Label lblNgay;
        private DateTimePicker dtpNgay;
        private Label lblSoTien;
        private TextBox txtSoTien;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnChuyenTien;
        private Button btnMoi;

        private Panel pnlChuyenTien2;
        private Label lblSauKhiChuyenDuKienVietcombank;
        private Label lblChuyenNoiBoKhongTinhVao;

        private Label lblLichSuChuyenTien;
        private DataGridView dgvLichSuChuyenTien;
        private Label lblSoGiaoDich;
    }
}
