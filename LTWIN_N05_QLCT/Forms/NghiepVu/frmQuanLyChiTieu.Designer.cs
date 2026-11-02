namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    partial class frmQuanLyChiTieu
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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlCanhBao = new System.Windows.Forms.Panel();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.lblKyRieng0125104 = new System.Windows.Forms.Label();

            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlNhapChiTieu = new System.Windows.Forms.Panel();
            this.lblThongTinKhoanChi = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiChi = new System.Windows.Forms.Label();
            this.cboLoaiChi = new System.Windows.Forms.ComboBox();
            this.lblViChi = new System.Windows.Forms.Label();
            this.cboViChi = new System.Windows.Forms.ComboBox();
            this.lblViChi2 = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.lblChonMotDongDeSuaHoac = new System.Windows.Forms.Label();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLocLoaiChi = new System.Windows.Forms.Label();
            this.cboLocLoaiChi = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();

            this.dgvChiTieu = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblSoGiaoDich = new System.Windows.Forms.Label();

            this.pnlTongChi = new System.Windows.Forms.Panel();
            this.lblTongChiTrongKyLoc = new System.Windows.Forms.Label();
            this.lblTongChi = new System.Windows.Forms.Label();
            this.lblKyLoc0110202625 = new System.Windows.Forms.Label();

            this.pnlCanhBao.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlNhapChiTieu.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).BeginInit();
            this.pnlTongChi.SuspendLayout();
            this.SuspendLayout();

            // ===== pnlCanhBao =====
            this.pnlCanhBao.BackColor = System.Drawing.Color.FromArgb(255, 248, 225);
            this.pnlCanhBao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanhBao.Controls.Add(this.lblCanhBao);
            this.pnlCanhBao.Controls.Add(this.lblKyRieng0125104);
            this.pnlCanhBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCanhBao.Location = new System.Drawing.Point(0, 0);
            this.pnlCanhBao.Name = "pnlCanhBao";
            this.pnlCanhBao.Size = new System.Drawing.Size(1060, 52);
            this.pnlCanhBao.TabIndex = 0;
            this.pnlCanhBao.Visible = false;

            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCanhBao.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.lblCanhBao.Location = new System.Drawing.Point(12, 6);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(262, 17);
            this.lblCanhBao.TabIndex = 0;
            this.lblCanhBao.Text = "⚠ Loại chi Ăn uống đã đạt 85% hạn mức";

            this.lblKyRieng0125104.AutoSize = true;
            this.lblKyRieng0125104.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKyRieng0125104.ForeColor = System.Drawing.Color.FromArgb(117, 117, 117);
            this.lblKyRieng0125104.Location = new System.Drawing.Point(12, 27);
            this.lblKyRieng0125104.Name = "lblKyRieng0125104";
            this.lblKyRieng0125104.Size = new System.Drawing.Size(425, 15);
            this.lblKyRieng0125104.TabIndex = 1;
            this.lblKyRieng0125104.Text = "Kỳ riêng 01-25/10: 4.080.000 / 4.800.000 đ. Tháng 10: 4.200.000 / 5.000.000 đ (84%).";

            // ===== pnlMain =====
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlNhapChiTieu);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 52);
            this.pnlMain.AutoScroll = true;
            this.pnlMain.AutoScrollMinSize = new System.Drawing.Size(1036, 524);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(12);
            this.pnlMain.Size = new System.Drawing.Size(1060, 548);
            this.pnlMain.TabIndex = 1;

            // ===== pnlNhapChiTieu (Left Panel) =====
            this.pnlNhapChiTieu.BackColor = System.Drawing.Color.White;
            this.pnlNhapChiTieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNhapChiTieu.Controls.Add(this.lblThongTinKhoanChi);
            this.pnlNhapChiTieu.Controls.Add(this.lblNgay);
            this.pnlNhapChiTieu.Controls.Add(this.dtpNgay);
            this.pnlNhapChiTieu.Controls.Add(this.lblLoaiChi);
            this.pnlNhapChiTieu.Controls.Add(this.cboLoaiChi);
            this.pnlNhapChiTieu.Controls.Add(this.lblViChi);
            this.pnlNhapChiTieu.Controls.Add(this.cboViChi);
            this.pnlNhapChiTieu.Controls.Add(this.lblViChi2);
            this.pnlNhapChiTieu.Controls.Add(this.lblSoTien);
            this.pnlNhapChiTieu.Controls.Add(this.txtSoTien);
            this.pnlNhapChiTieu.Controls.Add(this.lblGhiChu);
            this.pnlNhapChiTieu.Controls.Add(this.txtGhiChu);
            this.pnlNhapChiTieu.Controls.Add(this.btnThem);
            this.pnlNhapChiTieu.Controls.Add(this.btnSua);
            this.pnlNhapChiTieu.Controls.Add(this.btnXoa);
            this.pnlNhapChiTieu.Controls.Add(this.btnMoi);
            this.pnlNhapChiTieu.Controls.Add(this.lblChonMotDongDeSuaHoac);
            this.pnlNhapChiTieu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNhapChiTieu.Location = new System.Drawing.Point(12, 12);
            this.pnlNhapChiTieu.AutoScroll = true;
            this.pnlNhapChiTieu.Name = "pnlNhapChiTieu";
            this.pnlNhapChiTieu.Size = new System.Drawing.Size(250, 524);
            this.pnlNhapChiTieu.TabIndex = 0;

            this.lblThongTinKhoanChi.AutoSize = true;
            this.lblThongTinKhoanChi.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblThongTinKhoanChi.ForeColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.lblThongTinKhoanChi.Location = new System.Drawing.Point(12, 10);
            this.lblThongTinKhoanChi.Name = "lblThongTinKhoanChi";
            this.lblThongTinKhoanChi.Size = new System.Drawing.Size(142, 19);
            this.lblThongTinKhoanChi.TabIndex = 0;
            this.lblThongTinKhoanChi.Text = "Thông tin khoản chi";

            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNgay.Location = new System.Drawing.Point(12, 36);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(55, 15);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Ngày chi";

            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(12, 54);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(222, 23);
            this.dtpNgay.TabIndex = 2;

            this.lblLoaiChi.AutoSize = true;
            this.lblLoaiChi.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiChi.Location = new System.Drawing.Point(12, 85);
            this.lblLoaiChi.Name = "lblLoaiChi";
            this.lblLoaiChi.Size = new System.Drawing.Size(50, 15);
            this.lblLoaiChi.TabIndex = 3;
            this.lblLoaiChi.Text = "Loại chi";

            this.cboLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiChi.FormattingEnabled = true;
            this.cboLoaiChi.Location = new System.Drawing.Point(12, 103);
            this.cboLoaiChi.Name = "cboLoaiChi";
            this.cboLoaiChi.Size = new System.Drawing.Size(222, 23);
            this.cboLoaiChi.TabIndex = 4;

            this.lblViChi.AutoSize = true;
            this.lblViChi.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblViChi.Location = new System.Drawing.Point(12, 138);
            this.lblViChi.Name = "lblViChi";
            this.lblViChi.Size = new System.Drawing.Size(39, 15);
            this.lblViChi.TabIndex = 5;
            this.lblViChi.Text = "Ví chi";

            this.cboViChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViChi.FormattingEnabled = true;
            this.cboViChi.Location = new System.Drawing.Point(12, 156);
            this.cboViChi.Name = "cboViChi";
            this.cboViChi.Size = new System.Drawing.Size(222, 23);
            this.cboViChi.TabIndex = 6;

            this.lblViChi2.AutoSize = true;
            this.lblViChi2.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblViChi2.ForeColor = System.Drawing.Color.Gray;
            this.lblViChi2.Location = new System.Drawing.Point(12, 183);
            this.lblViChi2.Name = "lblViChi2";
            this.lblViChi2.Size = new System.Drawing.Size(130, 12);
            this.lblViChi2.TabIndex = 7;
            this.lblViChi2.Text = "Số dư khả dụng của ví đang chọn";

            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSoTien.Location = new System.Drawing.Point(12, 204);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(65, 15);
            this.lblSoTien.TabIndex = 8;
            this.lblSoTien.Text = "Số tiền (đ)";

            this.txtSoTien.Location = new System.Drawing.Point(12, 222);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(222, 23);
            this.txtSoTien.TabIndex = 9;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.Location = new System.Drawing.Point(12, 253);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(48, 15);
            this.lblGhiChu.TabIndex = 10;
            this.lblGhiChu.Text = "Ghi chú";

            this.txtGhiChu.Location = new System.Drawing.Point(12, 271);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(222, 45);
            this.txtGhiChu.TabIndex = 11;

            this.btnThem.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(12, 326);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(66, 28);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;

            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnSua.Location = new System.Drawing.Point(84, 326);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(45, 28);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;

            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.btnXoa.Location = new System.Drawing.Point(135, 326);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(45, 28);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;

            this.btnMoi.BackColor = System.Drawing.Color.White;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnMoi.Location = new System.Drawing.Point(186, 326);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(48, 28);
            this.btnMoi.TabIndex = 15;
            this.btnMoi.Text = "Mới";
            this.btnMoi.UseVisualStyleBackColor = true;

            this.lblChonMotDongDeSuaHoac.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblChonMotDongDeSuaHoac.ForeColor = System.Drawing.Color.Gray;
            this.lblChonMotDongDeSuaHoac.Location = new System.Drawing.Point(12, 362);
            this.lblChonMotDongDeSuaHoac.Name = "lblChonMotDongDeSuaHoac";
            this.lblChonMotDongDeSuaHoac.Size = new System.Drawing.Size(222, 28);
            this.lblChonMotDongDeSuaHoac.TabIndex = 16;
            this.lblChonMotDongDeSuaHoac.Text = "Chọn một dòng để sửa hoặc xóa khoản chi.";

            // ===== pnlRight =====
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.dgvChiTieu);
            this.pnlRight.Controls.Add(this.lblSoGiaoDich);
            this.pnlRight.Controls.Add(this.pnlTongChi);
            this.pnlRight.Controls.Add(this.lblKyLoc0110202625);
            this.pnlRight.Controls.Add(this.pnlBoLoc);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(262, 12);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(786, 524);
            this.pnlRight.TabIndex = 1;

            // ===== pnlBoLoc (Filter Bar) =====
            this.pnlBoLoc.BackColor = System.Drawing.Color.White;
            this.pnlBoLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoLoc.Controls.Add(this.lblTuNgay);
            this.pnlBoLoc.Controls.Add(this.dtpTuNgay);
            this.pnlBoLoc.Controls.Add(this.lblDenNgay);
            this.pnlBoLoc.Controls.Add(this.dtpDenNgay);
            this.pnlBoLoc.Controls.Add(this.lblLocLoaiChi);
            this.pnlBoLoc.Controls.Add(this.cboLocLoaiChi);
            this.pnlBoLoc.Controls.Add(this.btnLoc);
            this.pnlBoLoc.Controls.Add(this.btnXuatExcel);
            this.pnlBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBoLoc.Location = new System.Drawing.Point(12, 0);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Size = new System.Drawing.Size(774, 54);
            this.pnlBoLoc.TabIndex = 0;

            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTuNgay.Location = new System.Drawing.Point(8, 12);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(52, 15);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";

            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(62, 9);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(105, 23);
            this.dtpTuNgay.TabIndex = 1;

            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDenNgay.Location = new System.Drawing.Point(173, 12);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(60, 15);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";

            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(235, 9);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(105, 23);
            this.dtpDenNgay.TabIndex = 3;

            this.lblLocLoaiChi.AutoSize = true;
            this.lblLocLoaiChi.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLocLoaiChi.Location = new System.Drawing.Point(348, 12);
            this.lblLocLoaiChi.Name = "lblLocLoaiChi";
            this.lblLocLoaiChi.Size = new System.Drawing.Size(50, 15);
            this.lblLocLoaiChi.TabIndex = 4;
            this.lblLocLoaiChi.Text = "Loại chi:";

            this.cboLocLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiChi.FormattingEnabled = true;
            this.cboLocLoaiChi.Location = new System.Drawing.Point(403, 9);
            this.cboLocLoaiChi.Name = "cboLocLoaiChi";
            this.cboLocLoaiChi.Size = new System.Drawing.Size(120, 23);
            this.cboLocLoaiChi.TabIndex = 5;

            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(532, 7);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(65, 27);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;

            this.btnXuatExcel.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnXuatExcel.Location = new System.Drawing.Point(603, 7);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(95, 27);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = "📥 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;

            // ===== dgvChiTieu =====
            this.dgvChiTieu.AllowUserToAddRows = false;
            this.dgvChiTieu.AllowUserToDeleteRows = false;
            this.dgvChiTieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvChiTieu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTieu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dgvHeaderStyle.Padding = new System.Windows.Forms.Padding(4);
            this.dgvChiTieu.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvChiTieu.ColumnHeadersHeight = 32;
            this.dgvChiTieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNgay, this.colLoaiChi, this.colVi, this.colSoTien, this.colGhiChu
            });
            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(227, 242, 253);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvChiTieu.DefaultCellStyle = dgvRowStyle;
            this.dgvChiTieu.EnableHeadersVisualStyles = false;
            this.dgvChiTieu.Location = new System.Drawing.Point(12, 54);
            this.dgvChiTieu.MultiSelect = false;
            this.dgvChiTieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTieu.Name = "dgvChiTieu";
            this.dgvChiTieu.ReadOnly = true;
            this.dgvChiTieu.RowHeadersVisible = false;
            this.dgvChiTieu.RowTemplate.Height = 28;
            this.dgvChiTieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTieu.Size = new System.Drawing.Size(774, 369);
            this.dgvChiTieu.TabIndex = 1;

            this.colNgay.DataPropertyName = "Ngay";
            this.colNgay.FillWeight = 85F;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.Name = "colNgay";

            this.colLoaiChi.DataPropertyName = "LoaiChi";
            this.colLoaiChi.FillWeight = 95F;
            this.colLoaiChi.HeaderText = "Loại chi";
            this.colLoaiChi.Name = "colLoaiChi";

            this.colVi.DataPropertyName = "Vi";
            this.colVi.FillWeight = 95F;
            this.colVi.HeaderText = "Ví";
            this.colVi.Name = "colVi";

            this.colSoTien.DataPropertyName = "SoTienFormatted";
            this.colSoTien.FillWeight = 100F;
            this.colSoTien.HeaderText = "Số tiền";
            this.colSoTien.Name = "colSoTien";

            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.FillWeight = 160F;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";

            // ===== lblSoGiaoDich =====
            this.lblSoGiaoDich.AutoSize = false;
            this.lblSoGiaoDich.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblSoGiaoDich.ForeColor = System.Drawing.Color.Gray;
            this.lblSoGiaoDich.Location = new System.Drawing.Point(12, 423);
            this.lblSoGiaoDich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSoGiaoDich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSoGiaoDich.Name = "lblSoGiaoDich";
            this.lblSoGiaoDich.Size = new System.Drawing.Size(774, 28);
            this.lblSoGiaoDich.TabIndex = 2;
            this.lblSoGiaoDich.Text = "Chỉ đọc • Số giao dịch: 10 • Hiển thị toàn bộ kết quả";

            // ===== pnlTongChi =====
            this.pnlTongChi.BackColor = System.Drawing.Color.White;
            this.pnlTongChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongChi.Controls.Add(this.lblTongChiTrongKyLoc);
            this.pnlTongChi.Controls.Add(this.lblTongChi);
            this.pnlTongChi.Location = new System.Drawing.Point(12, 451);
            this.pnlTongChi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTongChi.Name = "pnlTongChi";
            this.pnlTongChi.Size = new System.Drawing.Size(774, 45);
            this.pnlTongChi.TabIndex = 3;

            this.lblTongChiTrongKyLoc.AutoSize = true;
            this.lblTongChiTrongKyLoc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTongChiTrongKyLoc.ForeColor = System.Drawing.Color.Gray;
            this.lblTongChiTrongKyLoc.Location = new System.Drawing.Point(8, 14);
            this.lblTongChiTrongKyLoc.Name = "lblTongChiTrongKyLoc";
            this.lblTongChiTrongKyLoc.Size = new System.Drawing.Size(125, 15);
            this.lblTongChiTrongKyLoc.TabIndex = 0;
            this.lblTongChiTrongKyLoc.Text = "Tổng chi trong kỳ lọc";

            this.lblTongChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongChi.AutoSize = true;
            this.lblTongChi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongChi.ForeColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.lblTongChi.Location = new System.Drawing.Point(623, 10);
            this.lblTongChi.Name = "lblTongChi";
            this.lblTongChi.Size = new System.Drawing.Size(142, 21);
            this.lblTongChi.TabIndex = 1;
            this.lblTongChi.Text = "16.680.000 đ";
            this.lblTongChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblKyLoc0110202625.AutoSize = false;
            this.lblKyLoc0110202625.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKyLoc0110202625.ForeColor = System.Drawing.Color.Gray;
            this.lblKyLoc0110202625.Location = new System.Drawing.Point(12, 496);
            this.lblKyLoc0110202625.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKyLoc0110202625.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKyLoc0110202625.Name = "lblKyLoc0110202625";
            this.lblKyLoc0110202625.Size = new System.Drawing.Size(774, 28);
            this.lblKyLoc0110202625.TabIndex = 4;
            this.lblKyLoc0110202625.Text = "Kỳ lọc: 01/10/2026 - 25/10/2026 • Tất cả các ví";

            // ===== Form Setup =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlCanhBao);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmQuanLyChiTieu";
            this.Text = "Quản Lý Chi Tiêu — Quản lý chi tiêu";

            this.pnlCanhBao.ResumeLayout(false);
            this.pnlCanhBao.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlNhapChiTieu.ResumeLayout(false);
            this.pnlNhapChiTieu.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).EndInit();
            this.pnlTongChi.ResumeLayout(false);
            this.pnlTongChi.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCanhBao;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.Label lblKyRieng0125104;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlNhapChiTieu;
        private System.Windows.Forms.Label lblThongTinKhoanChi;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblLoaiChi;
        private System.Windows.Forms.ComboBox cboLoaiChi;
        private System.Windows.Forms.Label lblViChi;
        private System.Windows.Forms.ComboBox cboViChi;
        private System.Windows.Forms.Label lblViChi2;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Label lblChonMotDongDeSuaHoac;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblLocLoaiChi;
        private System.Windows.Forms.ComboBox cboLocLoaiChi;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnXuatExcel;

        private System.Windows.Forms.DataGridView dgvChiTieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.Label lblSoGiaoDich;

        private System.Windows.Forms.Panel pnlTongChi;
        private System.Windows.Forms.Label lblTongChiTrongKyLoc;
        private System.Windows.Forms.Label lblTongChi;
        private System.Windows.Forms.Label lblKyLoc0110202625;
    }
}
