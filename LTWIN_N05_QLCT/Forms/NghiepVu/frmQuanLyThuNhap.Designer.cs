namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    partial class frmQuanLyThuNhap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblQuanLyThuNhap = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvThuNhap = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSoGiaoDich = new System.Windows.Forms.Label();
            this.pnlTongThu = new System.Windows.Forms.Panel();
            this.lblTongThuTrongKyLoc = new System.Windows.Forms.Label();
            this.lblTongThu = new System.Windows.Forms.Label();
            this.pnlCoCauThuNhap = new System.Windows.Forms.Panel();
            this.lblCoCauThuNhapThang10 = new System.Windows.Forms.Label();
            this.lblLuong = new System.Windows.Forms.Label();
            this.lblLuong2 = new System.Windows.Forms.Label();
            this.lblLuong3 = new System.Windows.Forms.Label();
            this.lblThuong = new System.Windows.Forms.Label();
            this.lblThuong2 = new System.Windows.Forms.Label();
            this.lblThuong3 = new System.Windows.Forms.Label();
            this.lblThuNhapKhac = new System.Windows.Forms.Label();
            this.lblThuNhapKhac2 = new System.Windows.Forms.Label();
            this.lblThuNhapKhac3 = new System.Windows.Forms.Label();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLocLoaiThu = new System.Windows.Forms.Label();
            this.cboLocLoaiThu = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlQuanLyGiaoDich = new System.Windows.Forms.Panel();
            this.lblThongTinKhoanThu = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiThu = new System.Windows.Forms.Label();
            this.cboLoaiThu = new System.Windows.Forms.ComboBox();
            this.lblLoaiThu2 = new System.Windows.Forms.Label();
            this.lblViThu = new System.Windows.Forms.Label();
            this.cboViThu = new System.Windows.Forms.ComboBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.lblChonMotDongDeSuaHoac = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuNhap)).BeginInit();
            this.pnlTongThu.SuspendLayout();
            this.pnlCoCauThuNhap.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
            this.pnlQuanLyGiaoDich.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlHeader.Controls.Add(this.lblQuanLyThuNhap);
            this.pnlHeader.Controls.Add(this.lblThang);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1101, 40);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblQuanLyThuNhap
            // 
            this.lblQuanLyThuNhap.AutoSize = true;
            this.lblQuanLyThuNhap.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblQuanLyThuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.lblQuanLyThuNhap.Location = new System.Drawing.Point(12, 7);
            this.lblQuanLyThuNhap.Name = "lblQuanLyThuNhap";
            this.lblQuanLyThuNhap.Size = new System.Drawing.Size(199, 31);
            this.lblQuanLyThuNhap.TabIndex = 0;
            this.lblQuanLyThuNhap.Text = "Quản lý thu nhập";
            // 
            // lblThang
            // 
            this.lblThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblThang.ForeColor = System.Drawing.Color.Gray;
            this.lblThang.Location = new System.Drawing.Point(821, 14);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(279, 20);
            this.lblThang.TabIndex = 1;
            this.lblThang.Text = "Tháng 10/2026 • Dữ liệu đến 26/10/2026";
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.AutoScroll = true;
            this.pnlNoiDung.AutoScrollMinSize = new System.Drawing.Size(1060, 560);
            this.pnlNoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.pnlNoiDung.Controls.Add(this.pnlRight);
            this.pnlNoiDung.Controls.Add(this.pnlQuanLyGiaoDich);
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(0, 40);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Padding = new System.Windows.Forms.Padding(12);
            this.pnlNoiDung.Size = new System.Drawing.Size(1101, 603);
            this.pnlNoiDung.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.dgvThuNhap);
            this.pnlRight.Controls.Add(this.lblSoGiaoDich);
            this.pnlRight.Controls.Add(this.pnlTongThu);
            this.pnlRight.Controls.Add(this.pnlCoCauThuNhap);
            this.pnlRight.Controls.Add(this.pnlBoLoc);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(262, 12);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(827, 579);
            this.pnlRight.TabIndex = 1;
            // 
            // dgvThuNhap
            // 
            this.dgvThuNhap.AllowUserToAddRows = false;
            this.dgvThuNhap.AllowUserToDeleteRows = false;
            this.dgvThuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuNhap.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThuNhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4);
            this.dgvThuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThuNhap.ColumnHeadersHeight = 32;
            this.dgvThuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgay,
            this.colLoaiThu,
            this.colVi,
            this.colSoTien,
            this.colGhiChu});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThuNhap.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThuNhap.EnableHeadersVisualStyles = false;
            this.dgvThuNhap.Location = new System.Drawing.Point(12, 54);
            this.dgvThuNhap.MultiSelect = false;
            this.dgvThuNhap.Name = "dgvThuNhap";
            this.dgvThuNhap.ReadOnly = true;
            this.dgvThuNhap.RowHeadersVisible = false;
            this.dgvThuNhap.RowHeadersWidth = 51;
            this.dgvThuNhap.RowTemplate.Height = 28;
            this.dgvThuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuNhap.Size = new System.Drawing.Size(815, 314);
            this.dgvThuNhap.TabIndex = 1;
            this.dgvThuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThuNhap_CellClick);
            // 
            // colNgay
            // 
            this.colNgay.DataPropertyName = "Ngay";
            this.colNgay.FillWeight = 85F;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.MinimumWidth = 6;
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // 
            // colLoaiThu
            // 
            this.colLoaiThu.DataPropertyName = "LoaiThu";
            this.colLoaiThu.FillWeight = 95F;
            this.colLoaiThu.HeaderText = "Loại thu";
            this.colLoaiThu.MinimumWidth = 6;
            this.colLoaiThu.Name = "colLoaiThu";
            this.colLoaiThu.ReadOnly = true;
            // 
            // colVi
            // 
            this.colVi.DataPropertyName = "Vi";
            this.colVi.FillWeight = 95F;
            this.colVi.HeaderText = "Ví";
            this.colVi.MinimumWidth = 6;
            this.colVi.Name = "colVi";
            this.colVi.ReadOnly = true;
            // 
            // colSoTien
            // 
            this.colSoTien.DataPropertyName = "SoTienFormatted";
            this.colSoTien.HeaderText = "Số tiền";
            this.colSoTien.MinimumWidth = 6;
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.ReadOnly = true;
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.FillWeight = 160F;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.MinimumWidth = 6;
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            // 
            // lblSoGiaoDich
            // 
            this.lblSoGiaoDich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSoGiaoDich.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblSoGiaoDich.ForeColor = System.Drawing.Color.Gray;
            this.lblSoGiaoDich.Location = new System.Drawing.Point(12, 368);
            this.lblSoGiaoDich.Name = "lblSoGiaoDich";
            this.lblSoGiaoDich.Size = new System.Drawing.Size(815, 28);
            this.lblSoGiaoDich.TabIndex = 2;
            this.lblSoGiaoDich.Text = "Chỉ đọc • Số giao dịch: 2 • Hiển thị toàn bộ kết quả";
            this.lblSoGiaoDich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTongThu
            // 
            this.pnlTongThu.BackColor = System.Drawing.Color.White;
            this.pnlTongThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongThu.Controls.Add(this.lblTongThuTrongKyLoc);
            this.pnlTongThu.Controls.Add(this.lblTongThu);
            this.pnlTongThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTongThu.Location = new System.Drawing.Point(12, 396);
            this.pnlTongThu.Name = "pnlTongThu";
            this.pnlTongThu.Size = new System.Drawing.Size(815, 45);
            this.pnlTongThu.TabIndex = 3;
            // 
            // lblTongThuTrongKyLoc
            // 
            this.lblTongThuTrongKyLoc.AutoSize = true;
            this.lblTongThuTrongKyLoc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTongThuTrongKyLoc.ForeColor = System.Drawing.Color.Gray;
            this.lblTongThuTrongKyLoc.Location = new System.Drawing.Point(8, 14);
            this.lblTongThuTrongKyLoc.Name = "lblTongThuTrongKyLoc";
            this.lblTongThuTrongKyLoc.Size = new System.Drawing.Size(150, 20);
            this.lblTongThuTrongKyLoc.TabIndex = 0;
            this.lblTongThuTrongKyLoc.Text = "Tổng thu trong kỳ lọc";
            // 
            // lblTongThu
            // 
            this.lblTongThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongThu.AutoSize = true;
            this.lblTongThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTongThu.Location = new System.Drawing.Point(659, 6);
            this.lblTongThu.Name = "lblTongThu";
            this.lblTongThu.Size = new System.Drawing.Size(137, 28);
            this.lblTongThu.TabIndex = 1;
            this.lblTongThu.Text = "25.000.000 đ";
            this.lblTongThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCoCauThuNhap
            // 
            this.pnlCoCauThuNhap.BackColor = System.Drawing.Color.White;
            this.pnlCoCauThuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCoCauThuNhap.Controls.Add(this.tableLayoutPanel1);
            this.pnlCoCauThuNhap.Controls.Add(this.lblCoCauThuNhapThang10);
            this.pnlCoCauThuNhap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCoCauThuNhap.Location = new System.Drawing.Point(12, 441);
            this.pnlCoCauThuNhap.Name = "pnlCoCauThuNhap";
            this.pnlCoCauThuNhap.Size = new System.Drawing.Size(815, 138);
            this.pnlCoCauThuNhap.TabIndex = 4;
            // 
            // lblCoCauThuNhapThang10
            // 
            this.lblCoCauThuNhapThang10.AutoSize = true;
            this.lblCoCauThuNhapThang10.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCoCauThuNhapThang10.Location = new System.Drawing.Point(10, 8);
            this.lblCoCauThuNhapThang10.Name = "lblCoCauThuNhapThang10";
            this.lblCoCauThuNhapThang10.Size = new System.Drawing.Size(205, 21);
            this.lblCoCauThuNhapThang10.TabIndex = 0;
            this.lblCoCauThuNhapThang10.Text = "Cơ cấu thu nhập tháng 10";
            // 
            // lblLuong
            // 
            this.lblLuong.AutoSize = true;
            this.lblLuong.Location = new System.Drawing.Point(3, 0);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(51, 20);
            this.lblLuong.TabIndex = 1;
            this.lblLuong.Text = "Lương";
            // 
            // lblLuong2
            // 
            this.lblLuong2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLuong2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLuong2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblLuong2.Location = new System.Drawing.Point(543, 0);
            this.lblLuong2.Name = "lblLuong2";
            this.lblLuong2.Size = new System.Drawing.Size(160, 30);
            this.lblLuong2.TabIndex = 2;
            this.lblLuong2.Text = "23.000.000 đ";
            this.lblLuong2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLuong3
            // 
            this.lblLuong3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLuong3.ForeColor = System.Drawing.Color.Gray;
            this.lblLuong3.Location = new System.Drawing.Point(714, 0);
            this.lblLuong3.Name = "lblLuong3";
            this.lblLuong3.Size = new System.Drawing.Size(65, 30);
            this.lblLuong3.TabIndex = 3;
            this.lblLuong3.Text = "92,0%";
            this.lblLuong3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThuong
            // 
            this.lblThuong.AutoSize = true;
            this.lblThuong.Location = new System.Drawing.Point(3, 30);
            this.lblThuong.Name = "lblThuong";
            this.lblThuong.Size = new System.Drawing.Size(60, 20);
            this.lblThuong.TabIndex = 4;
            this.lblThuong.Text = "Thưởng";
            // 
            // lblThuong2
            // 
            this.lblThuong2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThuong2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThuong2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblThuong2.Location = new System.Drawing.Point(543, 30);
            this.lblThuong2.Name = "lblThuong2";
            this.lblThuong2.Size = new System.Drawing.Size(160, 30);
            this.lblThuong2.TabIndex = 5;
            this.lblThuong2.Text = "0 đ";
            this.lblThuong2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThuong3
            // 
            this.lblThuong3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThuong3.ForeColor = System.Drawing.Color.Gray;
            this.lblThuong3.Location = new System.Drawing.Point(714, 30);
            this.lblThuong3.Name = "lblThuong3";
            this.lblThuong3.Size = new System.Drawing.Size(65, 30);
            this.lblThuong3.TabIndex = 6;
            this.lblThuong3.Text = "0,0%";
            this.lblThuong3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThuNhapKhac
            // 
            this.lblThuNhapKhac.AutoSize = true;
            this.lblThuNhapKhac.Location = new System.Drawing.Point(3, 60);
            this.lblThuNhapKhac.Name = "lblThuNhapKhac";
            this.lblThuNhapKhac.Size = new System.Drawing.Size(104, 20);
            this.lblThuNhapKhac.TabIndex = 7;
            this.lblThuNhapKhac.Text = "Thu nhập khác";
            // 
            // lblThuNhapKhac2
            // 
            this.lblThuNhapKhac2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThuNhapKhac2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThuNhapKhac2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblThuNhapKhac2.Location = new System.Drawing.Point(543, 60);
            this.lblThuNhapKhac2.Name = "lblThuNhapKhac2";
            this.lblThuNhapKhac2.Size = new System.Drawing.Size(160, 31);
            this.lblThuNhapKhac2.TabIndex = 8;
            this.lblThuNhapKhac2.Text = "2.000.000 đ";
            this.lblThuNhapKhac2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThuNhapKhac3
            // 
            this.lblThuNhapKhac3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThuNhapKhac3.ForeColor = System.Drawing.Color.Gray;
            this.lblThuNhapKhac3.Location = new System.Drawing.Point(714, 60);
            this.lblThuNhapKhac3.Name = "lblThuNhapKhac3";
            this.lblThuNhapKhac3.Size = new System.Drawing.Size(65, 31);
            this.lblThuNhapKhac3.TabIndex = 9;
            this.lblThuNhapKhac3.Text = "8,0%";
            this.lblThuNhapKhac3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBoLoc
            // 
            this.pnlBoLoc.BackColor = System.Drawing.Color.White;
            this.pnlBoLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoLoc.Controls.Add(this.lblTuNgay);
            this.pnlBoLoc.Controls.Add(this.dtpTuNgay);
            this.pnlBoLoc.Controls.Add(this.lblDenNgay);
            this.pnlBoLoc.Controls.Add(this.dtpDenNgay);
            this.pnlBoLoc.Controls.Add(this.lblLocLoaiThu);
            this.pnlBoLoc.Controls.Add(this.cboLocLoaiThu);
            this.pnlBoLoc.Controls.Add(this.btnLoc);
            this.pnlBoLoc.Controls.Add(this.btnXuatExcel);
            this.pnlBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBoLoc.Location = new System.Drawing.Point(12, 0);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Size = new System.Drawing.Size(815, 54);
            this.pnlBoLoc.TabIndex = 0;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTuNgay.Location = new System.Drawing.Point(3, 15);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(65, 20);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(74, 13);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(118, 27);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDenNgay.Location = new System.Drawing.Point(198, 15);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(75, 20);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(280, 13);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(105, 27);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // lblLocLoaiThu
            // 
            this.lblLocLoaiThu.AutoSize = true;
            this.lblLocLoaiThu.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLocLoaiThu.Location = new System.Drawing.Point(391, 17);
            this.lblLocLoaiThu.Name = "lblLocLoaiThu";
            this.lblLocLoaiThu.Size = new System.Drawing.Size(65, 20);
            this.lblLocLoaiThu.TabIndex = 4;
            this.lblLocLoaiThu.Text = "Loại thu:";
            // 
            // cboLocLoaiThu
            // 
            this.cboLocLoaiThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiThu.FormattingEnabled = true;
            this.cboLocLoaiThu.Location = new System.Drawing.Point(462, 10);
            this.cboLocLoaiThu.Name = "cboLocLoaiThu";
            this.cboLocLoaiThu.Size = new System.Drawing.Size(151, 28);
            this.cboLocLoaiThu.TabIndex = 5;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(619, 10);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(84, 27);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXuatExcel.Location = new System.Drawing.Point(709, 10);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(95, 27);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = "📥 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // pnlQuanLyGiaoDich
            // 
            this.pnlQuanLyGiaoDich.BackColor = System.Drawing.Color.White;
            this.pnlQuanLyGiaoDich.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblThongTinKhoanThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblNgay);
            this.pnlQuanLyGiaoDich.Controls.Add(this.dtpNgay);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblLoaiThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.cboLoaiThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblLoaiThu2);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblViThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.cboViThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblSoTien);
            this.pnlQuanLyGiaoDich.Controls.Add(this.txtSoTien);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblGhiChu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.txtGhiChu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.btnThem);
            this.pnlQuanLyGiaoDich.Controls.Add(this.btnSua);
            this.pnlQuanLyGiaoDich.Controls.Add(this.btnXoa);
            this.pnlQuanLyGiaoDich.Controls.Add(this.btnMoi);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblChonMotDongDeSuaHoac);
            this.pnlQuanLyGiaoDich.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlQuanLyGiaoDich.Location = new System.Drawing.Point(12, 12);
            this.pnlQuanLyGiaoDich.Name = "pnlQuanLyGiaoDich";
            this.pnlQuanLyGiaoDich.Size = new System.Drawing.Size(250, 579);
            this.pnlQuanLyGiaoDich.TabIndex = 0;
            // 
            // lblThongTinKhoanThu
            // 
            this.lblThongTinKhoanThu.AutoSize = true;
            this.lblThongTinKhoanThu.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblThongTinKhoanThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblThongTinKhoanThu.Location = new System.Drawing.Point(12, 10);
            this.lblThongTinKhoanThu.Name = "lblThongTinKhoanThu";
            this.lblThongTinKhoanThu.Size = new System.Drawing.Size(187, 25);
            this.lblThongTinKhoanThu.TabIndex = 0;
            this.lblThongTinKhoanThu.Text = "Thông tin khoản thu";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNgay.Location = new System.Drawing.Point(12, 36);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(74, 20);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Ngày thu";
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(12, 54);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(222, 27);
            this.dtpNgay.TabIndex = 2;
            // 
            // lblLoaiThu
            // 
            this.lblLoaiThu.AutoSize = true;
            this.lblLoaiThu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiThu.Location = new System.Drawing.Point(12, 85);
            this.lblLoaiThu.Name = "lblLoaiThu";
            this.lblLoaiThu.Size = new System.Drawing.Size(66, 20);
            this.lblLoaiThu.TabIndex = 3;
            this.lblLoaiThu.Text = "Loại thu";
            // 
            // cboLoaiThu
            // 
            this.cboLoaiThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThu.FormattingEnabled = true;
            this.cboLoaiThu.Location = new System.Drawing.Point(12, 103);
            this.cboLoaiThu.Name = "cboLoaiThu";
            this.cboLoaiThu.Size = new System.Drawing.Size(222, 28);
            this.cboLoaiThu.TabIndex = 4;
            // 
            // lblLoaiThu2
            // 
            this.lblLoaiThu2.AutoSize = true;
            this.lblLoaiThu2.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLoaiThu2.ForeColor = System.Drawing.Color.Gray;
            this.lblLoaiThu2.Location = new System.Drawing.Point(12, 129);
            this.lblLoaiThu2.Name = "lblLoaiThu2";
            this.lblLoaiThu2.Size = new System.Drawing.Size(200, 17);
            this.lblLoaiThu2.TabIndex = 5;
            this.lblLoaiThu2.Text = "Lương • Thưởng • Thu nhập khác";
            // 
            // lblViThu
            // 
            this.lblViThu.AutoSize = true;
            this.lblViThu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblViThu.Location = new System.Drawing.Point(12, 149);
            this.lblViThu.Name = "lblViThu";
            this.lblViThu.Size = new System.Drawing.Size(62, 20);
            this.lblViThu.TabIndex = 6;
            this.lblViThu.Text = "Ví nhận";
            // 
            // cboViThu
            // 
            this.cboViThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViThu.FormattingEnabled = true;
            this.cboViThu.Location = new System.Drawing.Point(12, 167);
            this.cboViThu.Name = "cboViThu";
            this.cboViThu.Size = new System.Drawing.Size(222, 28);
            this.cboViThu.TabIndex = 7;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSoTien.Location = new System.Drawing.Point(12, 198);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(82, 20);
            this.lblSoTien.TabIndex = 8;
            this.lblSoTien.Text = "Số tiền (đ)";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(12, 216);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(222, 27);
            this.txtSoTien.TabIndex = 9;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.Location = new System.Drawing.Point(12, 247);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(62, 20);
            this.lblGhiChu.TabIndex = 10;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(12, 265);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(222, 45);
            this.txtGhiChu.TabIndex = 11;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(12, 320);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(66, 28);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSua.Location = new System.Drawing.Point(84, 320);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(45, 28);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXoa.Location = new System.Drawing.Point(135, 320);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(45, 28);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnMoi
            // 
            this.btnMoi.BackColor = System.Drawing.Color.White;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnMoi.Location = new System.Drawing.Point(186, 320);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(48, 28);
            this.btnMoi.TabIndex = 15;
            this.btnMoi.Text = "Mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // lblChonMotDongDeSuaHoac
            // 
            this.lblChonMotDongDeSuaHoac.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblChonMotDongDeSuaHoac.ForeColor = System.Drawing.Color.Gray;
            this.lblChonMotDongDeSuaHoac.Location = new System.Drawing.Point(12, 356);
            this.lblChonMotDongDeSuaHoac.Name = "lblChonMotDongDeSuaHoac";
            this.lblChonMotDongDeSuaHoac.Size = new System.Drawing.Size(222, 28);
            this.lblChonMotDongDeSuaHoac.TabIndex = 16;
            this.lblChonMotDongDeSuaHoac.Text = "Chọn một dòng để sửa hoặc xóa khoản thu.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.16113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.590793F));
            this.tableLayoutPanel1.Controls.Add(this.lblLuong, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblThuong, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblThuong3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLuong3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLuong2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblThuong2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblThuNhapKhac, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblThuNhapKhac2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblThuNhapKhac3, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 91);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // frmQuanLyThuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 643);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmQuanLyThuNhap";
            this.Text = "Quản Lý Chi Tiêu — Quản lý thu nhập";
            this.Load += new System.EventHandler(this.frmQuanLyThuNhap_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNoiDung.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuNhap)).EndInit();
            this.pnlTongThu.ResumeLayout(false);
            this.pnlTongThu.PerformLayout();
            this.pnlCoCauThuNhap.ResumeLayout(false);
            this.pnlCoCauThuNhap.PerformLayout();
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            this.pnlQuanLyGiaoDich.ResumeLayout(false);
            this.pnlQuanLyGiaoDich.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblQuanLyThuNhap;
        private System.Windows.Forms.Label lblThang;

        // Content
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.Panel pnlQuanLyGiaoDich;
        private System.Windows.Forms.Label lblThongTinKhoanThu;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblLoaiThu;
        private System.Windows.Forms.ComboBox cboLoaiThu;
        private System.Windows.Forms.Label lblLoaiThu2;
        private System.Windows.Forms.Label lblViThu;
        private System.Windows.Forms.ComboBox cboViThu;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Label lblChonMotDongDeSuaHoac;

        // Right
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblLocLoaiThu;
        private System.Windows.Forms.ComboBox cboLocLoaiThu;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnXuatExcel;

        // Grid
        private System.Windows.Forms.DataGridView dgvThuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.Label lblSoGiaoDich;

        // Bottom
        private System.Windows.Forms.Panel pnlTongThu;
        private System.Windows.Forms.Label lblTongThuTrongKyLoc;
        private System.Windows.Forms.Label lblTongThu;
        private System.Windows.Forms.Panel pnlCoCauThuNhap;
        private System.Windows.Forms.Label lblCoCauThuNhapThang10;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.Label lblLuong2;
        private System.Windows.Forms.Label lblLuong3;
        private System.Windows.Forms.Label lblThuong;
        private System.Windows.Forms.Label lblThuong2;
        private System.Windows.Forms.Label lblThuong3;
        private System.Windows.Forms.Label lblThuNhapKhac;
        private System.Windows.Forms.Label lblThuNhapKhac2;
        private System.Windows.Forms.Label lblThuNhapKhac3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
