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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.btnNapTien = new System.Windows.Forms.Button();
            this.txtSoTienNap = new System.Windows.Forms.TextBox();
            this.lblSoTienNap = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblPhanTram = new System.Windows.Forms.Label();
            this.prgTienDo = new System.Windows.Forms.ProgressBar();
            this.lblTienDo = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.dtpNgayDich = new System.Windows.Forms.DateTimePicker();
            this.lblNgayDich = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.txtDaTietKiem = new System.Windows.Forms.TextBox();
            this.lblDaTietKiem = new System.Windows.Forms.Label();
            this.txtSoTienMucTieu = new System.Windows.Forms.TextBox();
            this.lblSoTienMucTieu = new System.Windows.Forms.Label();
            this.txtTenMucTieu = new System.Windows.Forms.TextBox();
            this.lblTenMucTieu = new System.Windows.Forms.Label();
            this.txtMaMucTieu = new System.Windows.Forms.TextBox();
            this.lblMaMucTieu = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.dgvMucTieu = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMucTieu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Blue;
            this.lblTieuDe.Location = new System.Drawing.Point(21, 8);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(290, 38);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "MỤC TIÊU TIẾT KIỆM";
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
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
            this.pnlThongTin.Location = new System.Drawing.Point(24, 48);
            this.pnlThongTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(812, 216);
            this.pnlThongTin.TabIndex = 1;
            // 
            // btnNapTien
            // 
            this.btnNapTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnNapTien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNapTien.FlatAppearance.BorderSize = 0;
            this.btnNapTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNapTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNapTien.ForeColor = System.Drawing.Color.White;
            this.btnNapTien.Location = new System.Drawing.Point(540, 182);
            this.btnNapTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNapTien.Name = "btnNapTien";
            this.btnNapTien.Size = new System.Drawing.Size(120, 26);
            this.btnNapTien.TabIndex = 23;
            this.btnNapTien.Text = "Nạp tiền";
            this.btnNapTien.UseVisualStyleBackColor = false;
            // 
            // txtSoTienNap
            // 
            this.txtSoTienNap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTienNap.Location = new System.Drawing.Point(140, 184);
            this.txtSoTienNap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoTienNap.MaxLength = 15;
            this.txtSoTienNap.Name = "txtSoTienNap";
            this.txtSoTienNap.Size = new System.Drawing.Size(250, 30);
            this.txtSoTienNap.TabIndex = 22;
            this.txtSoTienNap.Text = "0";
            this.txtSoTienNap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSoTienNap
            // 
            this.lblSoTienNap.AutoSize = true;
            this.lblSoTienNap.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienNap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoTienNap.Location = new System.Drawing.Point(20, 187);
            this.lblSoTienNap.Name = "lblSoTienNap";
            this.lblSoTienNap.Size = new System.Drawing.Size(96, 21);
            this.lblSoTienNap.TabIndex = 21;
            this.lblSoTienNap.Text = "Số tiền nạp";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(140, 150);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(652, 30);
            this.txtGhiChu.TabIndex = 20;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGhiChu.Location = new System.Drawing.Point(20, 154);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(68, 21);
            this.lblGhiChu.TabIndex = 19;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // lblPhanTram
            // 
            this.lblPhanTram.AutoSize = true;
            this.lblPhanTram.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanTram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblPhanTram.Location = new System.Drawing.Point(748, 121);
            this.lblPhanTram.Name = "lblPhanTram";
            this.lblPhanTram.Size = new System.Drawing.Size(33, 21);
            this.lblPhanTram.TabIndex = 18;
            this.lblPhanTram.Text = "0%";
            // 
            // prgTienDo
            // 
            this.prgTienDo.Location = new System.Drawing.Point(540, 118);
            this.prgTienDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prgTienDo.Name = "prgTienDo";
            this.prgTienDo.Size = new System.Drawing.Size(200, 18);
            this.prgTienDo.TabIndex = 17;
            // 
            // lblTienDo
            // 
            this.lblTienDo.AutoSize = true;
            this.lblTienDo.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTienDo.Location = new System.Drawing.Point(420, 120);
            this.lblTienDo.Name = "lblTienDo";
            this.lblTienDo.Size = new System.Drawing.Size(67, 21);
            this.lblTienDo.TabIndex = 16;
            this.lblTienDo.Text = "Tiến độ";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(140, 117);
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(250, 31);
            this.cboTrangThai.TabIndex = 15;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTrangThai.Location = new System.Drawing.Point(20, 120);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(87, 21);
            this.lblTrangThai.TabIndex = 14;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // dtpNgayDich
            // 
            this.dtpNgayDich.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDich.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDich.Location = new System.Drawing.Point(540, 83);
            this.dtpNgayDich.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayDich.Name = "dtpNgayDich";
            this.dtpNgayDich.ShowCheckBox = true;
            this.dtpNgayDich.Size = new System.Drawing.Size(252, 30);
            this.dtpNgayDich.TabIndex = 13;
            // 
            // lblNgayDich
            // 
            this.lblNgayDich.AutoSize = true;
            this.lblNgayDich.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayDich.Location = new System.Drawing.Point(420, 86);
            this.lblNgayDich.Name = "lblNgayDich";
            this.lblNgayDich.Size = new System.Drawing.Size(88, 21);
            this.lblNgayDich.TabIndex = 12;
            this.lblNgayDich.Text = "Ngày đích";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(140, 83);
            this.dtpNgayBatDau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(250, 30);
            this.dtpNgayBatDau.TabIndex = 11;
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayBatDau.Location = new System.Drawing.Point(20, 86);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(113, 21);
            this.lblNgayBatDau.TabIndex = 10;
            this.lblNgayBatDau.Text = "Ngày bắt đầu";
            // 
            // txtDaTietKiem
            // 
            this.txtDaTietKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtDaTietKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaTietKiem.Location = new System.Drawing.Point(540, 50);
            this.txtDaTietKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDaTietKiem.Name = "txtDaTietKiem";
            this.txtDaTietKiem.ReadOnly = true;
            this.txtDaTietKiem.Size = new System.Drawing.Size(252, 30);
            this.txtDaTietKiem.TabIndex = 9;
            this.txtDaTietKiem.Text = "0";
            this.txtDaTietKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDaTietKiem
            // 
            this.lblDaTietKiem.AutoSize = true;
            this.lblDaTietKiem.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaTietKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDaTietKiem.Location = new System.Drawing.Point(420, 53);
            this.lblDaTietKiem.Name = "lblDaTietKiem";
            this.lblDaTietKiem.Size = new System.Drawing.Size(103, 21);
            this.lblDaTietKiem.TabIndex = 8;
            this.lblDaTietKiem.Text = "Đã tiết kiệm";
            // 
            // txtSoTienMucTieu
            // 
            this.txtSoTienMucTieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTienMucTieu.Location = new System.Drawing.Point(140, 50);
            this.txtSoTienMucTieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoTienMucTieu.MaxLength = 15;
            this.txtSoTienMucTieu.Name = "txtSoTienMucTieu";
            this.txtSoTienMucTieu.Size = new System.Drawing.Size(250, 30);
            this.txtSoTienMucTieu.TabIndex = 7;
            this.txtSoTienMucTieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSoTienMucTieu
            // 
            this.lblSoTienMucTieu.AutoSize = true;
            this.lblSoTienMucTieu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTienMucTieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoTienMucTieu.Location = new System.Drawing.Point(20, 53);
            this.lblSoTienMucTieu.Name = "lblSoTienMucTieu";
            this.lblSoTienMucTieu.Size = new System.Drawing.Size(134, 21);
            this.lblSoTienMucTieu.TabIndex = 6;
            this.lblSoTienMucTieu.Text = "Số tiền mục tiêu";
            // 
            // txtTenMucTieu
            // 
            this.txtTenMucTieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMucTieu.Location = new System.Drawing.Point(540, 16);
            this.txtTenMucTieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenMucTieu.MaxLength = 100;
            this.txtTenMucTieu.Name = "txtTenMucTieu";
            this.txtTenMucTieu.Size = new System.Drawing.Size(252, 30);
            this.txtTenMucTieu.TabIndex = 5;
            // 
            // lblTenMucTieu
            // 
            this.lblTenMucTieu.AutoSize = true;
            this.lblTenMucTieu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMucTieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTenMucTieu.Location = new System.Drawing.Point(420, 19);
            this.lblTenMucTieu.Name = "lblTenMucTieu";
            this.lblTenMucTieu.Size = new System.Drawing.Size(108, 21);
            this.lblTenMucTieu.TabIndex = 4;
            this.lblTenMucTieu.Text = "Tên mục tiêu";
            // 
            // txtMaMucTieu
            // 
            this.txtMaMucTieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtMaMucTieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMucTieu.Location = new System.Drawing.Point(140, 16);
            this.txtMaMucTieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaMucTieu.Name = "txtMaMucTieu";
            this.txtMaMucTieu.ReadOnly = true;
            this.txtMaMucTieu.Size = new System.Drawing.Size(250, 30);
            this.txtMaMucTieu.TabIndex = 3;
            // 
            // lblMaMucTieu
            // 
            this.lblMaMucTieu.AutoSize = true;
            this.lblMaMucTieu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMucTieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMaMucTieu.Location = new System.Drawing.Point(20, 19);
            this.lblMaMucTieu.Name = "lblMaMucTieu";
            this.lblMaMucTieu.Size = new System.Drawing.Size(105, 21);
            this.lblMaMucTieu.TabIndex = 2;
            this.lblMaMucTieu.Text = "Mã mục tiêu";
            // 
            // lblThongBao
            // 
            this.lblThongBao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.Location = new System.Drawing.Point(24, 269);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(812, 16);
            this.lblThongBao.TabIndex = 24;
            this.lblThongBao.Visible = false;
            // 
            // dgvMucTieu
            // 
            this.dgvMucTieu.AllowUserToAddRows = false;
            this.dgvMucTieu.AllowUserToDeleteRows = false;
            this.dgvMucTieu.AllowUserToResizeRows = false;
            this.dgvMucTieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMucTieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvMucTieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMucTieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMucTieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMucTieu.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMucTieu.EnableHeadersVisualStyles = false;
            this.dgvMucTieu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.dgvMucTieu.Location = new System.Drawing.Point(24, 290);
            this.dgvMucTieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMucTieu.MultiSelect = false;
            this.dgvMucTieu.Name = "dgvMucTieu";
            this.dgvMucTieu.ReadOnly = true;
            this.dgvMucTieu.RowHeadersVisible = false;
            this.dgvMucTieu.RowHeadersWidth = 51;
            this.dgvMucTieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMucTieu.Size = new System.Drawing.Size(812, 141);
            this.dgvMucTieu.TabIndex = 25;
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
            this.btnThem.Location = new System.Drawing.Point(24, 442);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
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
            this.btnSua.Location = new System.Drawing.Point(134, 442);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 30);
            this.btnSua.TabIndex = 27;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
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
            this.btnXoa.Location = new System.Drawing.Point(244, 442);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 28;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
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
            this.btnLuu.Location = new System.Drawing.Point(354, 442);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 30);
            this.btnLuu.TabIndex = 29;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
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
            this.btnBoQua.Location = new System.Drawing.Point(464, 442);
            this.btnBoQua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(100, 30);
            this.btnBoQua.TabIndex = 30;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = false;
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
            this.btnDong.Location = new System.Drawing.Point(736, 442);
            this.btnDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.TabIndex = 31;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // frmMucTieuTietKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(860, 483);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMucTieuTietKiem";
            this.Text = "Mục tiêu tiết kiệm";
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMucTieu)).EndInit();
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
