namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    partial class frmMucTieuTietKiem
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.lblMaMucTieu = new System.Windows.Forms.Label();
            this.txtMaMucTieu = new System.Windows.Forms.TextBox();
            this.lblTenMucTieu = new System.Windows.Forms.Label();
            this.txtTenMucTieu = new System.Windows.Forms.TextBox();
            this.lblSoTienMucTieu = new System.Windows.Forms.Label();
            this.txtSoTienMucTieu = new System.Windows.Forms.TextBox();
            this.lblDaTietKiem = new System.Windows.Forms.Label();
            this.txtDaTietKiem = new System.Windows.Forms.TextBox();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayDich = new System.Windows.Forms.Label();
            this.dtpNgayDich = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTienDo = new System.Windows.Forms.Label();
            this.prgTienDo = new System.Windows.Forms.ProgressBar();
            this.lblPhanTram = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblSoTienNap = new System.Windows.Forms.Label();
            this.txtSoTienNap = new System.Windows.Forms.TextBox();
            this.btnNapTien = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.dgvMucTieu = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMucTieu)).BeginInit();
            this.pnlThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Text = "Mục tiêu tiết kiệm";
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.TabIndex = 0;
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.Location = new System.Drawing.Point(24, 60);
            this.pnlThongTin.Size = new System.Drawing.Size(812, 270);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.TabIndex = 1;
            this.pnlThongTin.Controls.Add(this.btnNapTien);
            this.pnlThongTin.Controls.Add(this.txtSoTienNap);
            this.pnlThongTin.Controls.Add(this.lblSoTienNap);
            this.pnlThongTin.Controls.Add(this.txtGhiChu);
            this.pnlThongTin.Controls.Add(this.lblGhiChu);
            this.pnlThongTin.Controls.Add(this.lblPhanTram);
            this.pnlThongTin.Controls.Add(this.prgTienDo);
            this.pnlThongTin.Controls.Add(this.lblTienDo);
            this.pnlThongTin.Controls.Add(this.cboTrangThai);
            this.pnlThongTin.Controls.Add(this.lblTrangThai);
            this.pnlThongTin.Controls.Add(this.dtpNgayDich);
            this.pnlThongTin.Controls.Add(this.lblNgayDich);
            this.pnlThongTin.Controls.Add(this.dtpNgayBatDau);
            this.pnlThongTin.Controls.Add(this.lblNgayBatDau);
            this.pnlThongTin.Controls.Add(this.txtDaTietKiem);
            this.pnlThongTin.Controls.Add(this.lblDaTietKiem);
            this.pnlThongTin.Controls.Add(this.txtSoTienMucTieu);
            this.pnlThongTin.Controls.Add(this.lblSoTienMucTieu);
            this.pnlThongTin.Controls.Add(this.txtTenMucTieu);
            this.pnlThongTin.Controls.Add(this.lblTenMucTieu);
            this.pnlThongTin.Controls.Add(this.txtMaMucTieu);
            this.pnlThongTin.Controls.Add(this.lblMaMucTieu);
            // 
            // lblMaMucTieu
            // 
            this.lblMaMucTieu.AutoSize = true;
            this.lblMaMucTieu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMucTieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMaMucTieu.Location = new System.Drawing.Point(20, 24);
            this.lblMaMucTieu.Text = "Mã mục tiêu";
            this.lblMaMucTieu.Name = "lblMaMucTieu";
            this.lblMaMucTieu.TabIndex = 2;
            // 
            // txtMaMucTieu
            // 
            this.txtMaMucTieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMucTieu.Location = new System.Drawing.Point(140, 20);
            this.txtMaMucTieu.Size = new System.Drawing.Size(250, 25);
            this.txtMaMucTieu.ReadOnly = true;
            this.txtMaMucTieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtMaMucTieu.Name = "txtMaMucTieu";
            this.txtMaMucTieu.TabIndex = 3;
            // 
            // lblTenMucTieu
            // 
            this.lblTenMucTieu.AutoSize = true;
            this.lblTenMucTieu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMucTieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTenMucTieu.Location = new System.Drawing.Point(420, 24);
            this.lblTenMucTieu.Text = "Tên mục tiêu";
            this.lblTenMucTieu.Name = "lblTenMucTieu";
            this.lblTenMucTieu.TabIndex = 4;
            // 
            // txtTenMucTieu
            // 
            this.txtTenMucTieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMucTieu.Location = new System.Drawing.Point(540, 20);
            this.txtTenMucTieu.Size = new System.Drawing.Size(252, 25);
            this.txtTenMucTieu.MaxLength = 100;
            this.txtTenMucTieu.Name = "txtTenMucTieu";
            this.txtTenMucTieu.TabIndex = 5;
            // 
            // lblSoTienMucTieu
            // 
            this.lblSoTienMucTieu.AutoSize = true;
            this.lblSoTienMucTieu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienMucTieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoTienMucTieu.Location = new System.Drawing.Point(20, 66);
            this.lblSoTienMucTieu.Text = "Số tiền mục tiêu";
            this.lblSoTienMucTieu.Name = "lblSoTienMucTieu";
            this.lblSoTienMucTieu.TabIndex = 6;
            // 
            // txtSoTienMucTieu
            // 
            this.txtSoTienMucTieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTienMucTieu.Location = new System.Drawing.Point(140, 62);
            this.txtSoTienMucTieu.Size = new System.Drawing.Size(250, 25);
            this.txtSoTienMucTieu.MaxLength = 15;
            this.txtSoTienMucTieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoTienMucTieu.Name = "txtSoTienMucTieu";
            this.txtSoTienMucTieu.TabIndex = 7;
            // 
            // lblDaTietKiem
            // 
            this.lblDaTietKiem.AutoSize = true;
            this.lblDaTietKiem.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaTietKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDaTietKiem.Location = new System.Drawing.Point(420, 66);
            this.lblDaTietKiem.Text = "Đã tiết kiệm";
            this.lblDaTietKiem.Name = "lblDaTietKiem";
            this.lblDaTietKiem.TabIndex = 8;
            // 
            // txtDaTietKiem
            // 
            this.txtDaTietKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaTietKiem.Location = new System.Drawing.Point(540, 62);
            this.txtDaTietKiem.Size = new System.Drawing.Size(252, 25);
            this.txtDaTietKiem.ReadOnly = true;
            this.txtDaTietKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtDaTietKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDaTietKiem.Text = "0";
            this.txtDaTietKiem.Name = "txtDaTietKiem";
            this.txtDaTietKiem.TabIndex = 9;
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayBatDau.Location = new System.Drawing.Point(20, 108);
            this.lblNgayBatDau.Text = "Ngày bắt đầu";
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.TabIndex = 10;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBatDau.Location = new System.Drawing.Point(140, 104);
            this.dtpNgayBatDau.Size = new System.Drawing.Size(250, 25);
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.TabIndex = 11;
            // 
            // lblNgayDich
            // 
            this.lblNgayDich.AutoSize = true;
            this.lblNgayDich.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayDich.Location = new System.Drawing.Point(420, 108);
            this.lblNgayDich.Text = "Ngày đích";
            this.lblNgayDich.Name = "lblNgayDich";
            this.lblNgayDich.TabIndex = 12;
            // 
            // dtpNgayDich
            // 
            this.dtpNgayDich.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDich.Location = new System.Drawing.Point(540, 104);
            this.dtpNgayDich.Size = new System.Drawing.Size(252, 25);
            this.dtpNgayDich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDich.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDich.ShowCheckBox = true;
            this.dtpNgayDich.Name = "dtpNgayDich";
            this.dtpNgayDich.TabIndex = 13;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTrangThai.Location = new System.Drawing.Point(20, 150);
            this.lblTrangThai.Text = "Trạng thái";
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.TabIndex = 14;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrangThai.Location = new System.Drawing.Point(140, 146);
            this.cboTrangThai.Size = new System.Drawing.Size(250, 25);
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.TabIndex = 15;
            // 
            // lblTienDo
            // 
            this.lblTienDo.AutoSize = true;
            this.lblTienDo.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTienDo.Location = new System.Drawing.Point(420, 150);
            this.lblTienDo.Text = "Tiến độ";
            this.lblTienDo.Name = "lblTienDo";
            this.lblTienDo.TabIndex = 16;
            // 
            // prgTienDo
            // 
            this.prgTienDo.Location = new System.Drawing.Point(540, 148);
            this.prgTienDo.Size = new System.Drawing.Size(200, 22);
            this.prgTienDo.Name = "prgTienDo";
            this.prgTienDo.TabIndex = 17;
            // 
            // lblPhanTram
            // 
            this.lblPhanTram.AutoSize = true;
            this.lblPhanTram.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanTram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblPhanTram.Location = new System.Drawing.Point(748, 151);
            this.lblPhanTram.Text = "0%";
            this.lblPhanTram.Name = "lblPhanTram";
            this.lblPhanTram.TabIndex = 18;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGhiChu.Location = new System.Drawing.Point(20, 192);
            this.lblGhiChu.Text = "Ghi chú";
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.TabIndex = 19;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(140, 188);
            this.txtGhiChu.Size = new System.Drawing.Size(652, 25);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.TabIndex = 20;
            // 
            // lblSoTienNap
            // 
            this.lblSoTienNap.AutoSize = true;
            this.lblSoTienNap.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienNap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoTienNap.Location = new System.Drawing.Point(20, 234);
            this.lblSoTienNap.Text = "Số tiền nạp";
            this.lblSoTienNap.Name = "lblSoTienNap";
            this.lblSoTienNap.TabIndex = 21;
            // 
            // txtSoTienNap
            // 
            this.txtSoTienNap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTienNap.Location = new System.Drawing.Point(140, 230);
            this.txtSoTienNap.Size = new System.Drawing.Size(250, 25);
            this.txtSoTienNap.MaxLength = 15;
            this.txtSoTienNap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoTienNap.Text = "0";
            this.txtSoTienNap.Name = "txtSoTienNap";
            this.txtSoTienNap.TabIndex = 22;
            // 
            // btnNapTien
            // 
            this.btnNapTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnNapTien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNapTien.FlatAppearance.BorderSize = 0;
            this.btnNapTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNapTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNapTien.ForeColor = System.Drawing.Color.White;
            this.btnNapTien.Location = new System.Drawing.Point(540, 227);
            this.btnNapTien.Size = new System.Drawing.Size(120, 32);
            this.btnNapTien.Text = "Nạp tiền";
            this.btnNapTien.UseVisualStyleBackColor = false;
            this.btnNapTien.Name = "btnNapTien";
            this.btnNapTien.TabIndex = 23;
            // 
            // lblThongBao
            // 
            this.lblThongBao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.Location = new System.Drawing.Point(24, 336);
            this.lblThongBao.Size = new System.Drawing.Size(812, 20);
            this.lblThongBao.Text = "";
            this.lblThongBao.Visible = false;
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.TabIndex = 24;
            // 
            // dgvMucTieu
            // 
            this.dgvMucTieu.AllowUserToAddRows = false;
            this.dgvMucTieu.AllowUserToDeleteRows = false;
            this.dgvMucTieu.AllowUserToResizeRows = false;
            this.dgvMucTieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMucTieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvMucTieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMucTieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMucTieu.EnableHeadersVisualStyles = false;
            this.dgvMucTieu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.dgvMucTieu.Location = new System.Drawing.Point(24, 362);
            this.dgvMucTieu.MultiSelect = false;
            this.dgvMucTieu.ReadOnly = true;
            this.dgvMucTieu.RowHeadersVisible = false;
            this.dgvMucTieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMucTieu.Size = new System.Drawing.Size(812, 176);
            this.dgvMucTieu.Name = "dgvMucTieu";
            this.dgvMucTieu.TabIndex = 25;
            this.dgvMucTieu.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvMucTieu.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvMucTieu.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMucTieu.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMucTieu.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvMucTieu.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.dgvMucTieu.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(24, 552);
            this.btnThem.Size = new System.Drawing.Size(100, 38);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Name = "btnThem";
            this.btnThem.TabIndex = 26;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSua.Location = new System.Drawing.Point(134, 552);
            this.btnSua.Size = new System.Drawing.Size(100, 38);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Name = "btnSua";
            this.btnSua.TabIndex = 27;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnXoa.Location = new System.Drawing.Point(244, 552);
            this.btnXoa.Size = new System.Drawing.Size(100, 38);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.TabIndex = 28;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(354, 552);
            this.btnLuu.Size = new System.Drawing.Size(100, 38);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.TabIndex = 29;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBoQua.BackColor = System.Drawing.Color.White;
            this.btnBoQua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoQua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnBoQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoQua.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnBoQua.Location = new System.Drawing.Point(464, 552);
            this.btnBoQua.Size = new System.Drawing.Size(100, 38);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = false;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.TabIndex = 30;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDong.Location = new System.Drawing.Point(736, 552);
            this.btnDong.Size = new System.Drawing.Size(100, 38);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Name = "btnDong";
            this.btnDong.TabIndex = 31;
            // 
            // frmMucTieuTietKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(860, 604);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvMucTieu);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMucTieuTietKiem";
            this.Text = "Mục tiêu tiết kiệm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMucTieu)).EndInit();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblMaMucTieu;
        private System.Windows.Forms.TextBox txtMaMucTieu;
        private System.Windows.Forms.Label lblTenMucTieu;
        private System.Windows.Forms.TextBox txtTenMucTieu;
        private System.Windows.Forms.Label lblSoTienMucTieu;
        private System.Windows.Forms.TextBox txtSoTienMucTieu;
        private System.Windows.Forms.Label lblDaTietKiem;
        private System.Windows.Forms.TextBox txtDaTietKiem;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label lblNgayDich;
        private System.Windows.Forms.DateTimePicker dtpNgayDich;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTienDo;
        private System.Windows.Forms.ProgressBar prgTienDo;
        private System.Windows.Forms.Label lblPhanTram;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblSoTienNap;
        private System.Windows.Forms.TextBox txtSoTienNap;
        private System.Windows.Forms.Button btnNapTien;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.DataGridView dgvMucTieu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnDong;
    }
}
