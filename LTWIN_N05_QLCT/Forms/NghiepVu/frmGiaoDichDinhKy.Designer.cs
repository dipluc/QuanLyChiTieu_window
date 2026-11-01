namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    partial class frmGiaoDichDinhKy
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
            this.lblMaGD = new System.Windows.Forms.Label();
            this.txtMaGD = new System.Windows.Forms.TextBox();
            this.lblLoaiGD = new System.Windows.Forms.Label();
            this.cboLoaiGD = new System.Windows.Forms.ComboBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblMaVi = new System.Windows.Forms.Label();
            this.cboMaVi = new System.Windows.Forms.ComboBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblTanSuat = new System.Windows.Forms.Label();
            this.cboTanSuat = new System.Windows.Forms.ComboBox();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKeTiep = new System.Windows.Forms.Label();
            this.dtpNgayKeTiep = new System.Windows.Forms.DateTimePicker();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.pnlThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Text = "Giao dịch định kỳ";
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
            this.pnlThongTin.Controls.Add(this.txtGhiChu);
            this.pnlThongTin.Controls.Add(this.lblGhiChu);
            this.pnlThongTin.Controls.Add(this.chkTrangThai);
            this.pnlThongTin.Controls.Add(this.dtpNgayKeTiep);
            this.pnlThongTin.Controls.Add(this.lblNgayKeTiep);
            this.pnlThongTin.Controls.Add(this.dtpNgayKetThuc);
            this.pnlThongTin.Controls.Add(this.lblNgayKetThuc);
            this.pnlThongTin.Controls.Add(this.dtpNgayBatDau);
            this.pnlThongTin.Controls.Add(this.lblNgayBatDau);
            this.pnlThongTin.Controls.Add(this.cboTanSuat);
            this.pnlThongTin.Controls.Add(this.lblTanSuat);
            this.pnlThongTin.Controls.Add(this.txtSoTien);
            this.pnlThongTin.Controls.Add(this.lblSoTien);
            this.pnlThongTin.Controls.Add(this.cboMaVi);
            this.pnlThongTin.Controls.Add(this.lblMaVi);
            this.pnlThongTin.Controls.Add(this.cboDanhMuc);
            this.pnlThongTin.Controls.Add(this.lblDanhMuc);
            this.pnlThongTin.Controls.Add(this.cboLoaiGD);
            this.pnlThongTin.Controls.Add(this.lblLoaiGD);
            this.pnlThongTin.Controls.Add(this.txtMaGD);
            this.pnlThongTin.Controls.Add(this.lblMaGD);
            // 
            // lblMaGD
            // 
            this.lblMaGD.AutoSize = true;
            this.lblMaGD.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaGD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMaGD.Location = new System.Drawing.Point(20, 24);
            this.lblMaGD.Text = "Mã giao dịch";
            this.lblMaGD.Name = "lblMaGD";
            this.lblMaGD.TabIndex = 2;
            // 
            // txtMaGD
            // 
            this.txtMaGD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGD.Location = new System.Drawing.Point(140, 20);
            this.txtMaGD.Size = new System.Drawing.Size(250, 25);
            this.txtMaGD.ReadOnly = true;
            this.txtMaGD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtMaGD.Name = "txtMaGD";
            this.txtMaGD.TabIndex = 3;
            // 
            // lblLoaiGD
            // 
            this.lblLoaiGD.AutoSize = true;
            this.lblLoaiGD.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiGD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblLoaiGD.Location = new System.Drawing.Point(420, 24);
            this.lblLoaiGD.Text = "Loại giao dịch";
            this.lblLoaiGD.Name = "lblLoaiGD";
            this.lblLoaiGD.TabIndex = 4;
            // 
            // cboLoaiGD
            // 
            this.cboLoaiGD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiGD.Location = new System.Drawing.Point(540, 20);
            this.cboLoaiGD.Size = new System.Drawing.Size(252, 25);
            this.cboLoaiGD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiGD.FormattingEnabled = true;
            this.cboLoaiGD.Name = "cboLoaiGD";
            this.cboLoaiGD.TabIndex = 5;
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDanhMuc.Location = new System.Drawing.Point(20, 66);
            this.lblDanhMuc.Text = "Danh mục";
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.TabIndex = 6;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDanhMuc.Location = new System.Drawing.Point(140, 62);
            this.cboDanhMuc.Size = new System.Drawing.Size(250, 25);
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.TabIndex = 7;
            // 
            // lblMaVi
            // 
            this.lblMaVi.AutoSize = true;
            this.lblMaVi.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMaVi.Location = new System.Drawing.Point(420, 66);
            this.lblMaVi.Text = "Ví";
            this.lblMaVi.Name = "lblMaVi";
            this.lblMaVi.TabIndex = 8;
            // 
            // cboMaVi
            // 
            this.cboMaVi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaVi.Location = new System.Drawing.Point(540, 62);
            this.cboMaVi.Size = new System.Drawing.Size(252, 25);
            this.cboMaVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaVi.FormattingEnabled = true;
            this.cboMaVi.Name = "cboMaVi";
            this.cboMaVi.TabIndex = 9;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoTien.Location = new System.Drawing.Point(20, 108);
            this.lblSoTien.Text = "Số tiền (VNĐ)";
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.TabIndex = 10;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.Location = new System.Drawing.Point(140, 104);
            this.txtSoTien.Size = new System.Drawing.Size(250, 25);
            this.txtSoTien.MaxLength = 15;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.TabIndex = 11;
            // 
            // lblTanSuat
            // 
            this.lblTanSuat.AutoSize = true;
            this.lblTanSuat.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanSuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTanSuat.Location = new System.Drawing.Point(420, 108);
            this.lblTanSuat.Text = "Tần suất";
            this.lblTanSuat.Name = "lblTanSuat";
            this.lblTanSuat.TabIndex = 12;
            // 
            // cboTanSuat
            // 
            this.cboTanSuat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTanSuat.Location = new System.Drawing.Point(540, 104);
            this.cboTanSuat.Size = new System.Drawing.Size(252, 25);
            this.cboTanSuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTanSuat.FormattingEnabled = true;
            this.cboTanSuat.Name = "cboTanSuat";
            this.cboTanSuat.TabIndex = 13;
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayBatDau.Location = new System.Drawing.Point(20, 150);
            this.lblNgayBatDau.Text = "Ngày bắt đầu";
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.TabIndex = 14;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBatDau.Location = new System.Drawing.Point(140, 146);
            this.dtpNgayBatDau.Size = new System.Drawing.Size(250, 25);
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.TabIndex = 15;
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayKetThuc.Location = new System.Drawing.Point(420, 150);
            this.lblNgayKetThuc.Text = "Ngày kết thúc";
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.TabIndex = 16;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(540, 146);
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(252, 25);
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKetThuc.ShowCheckBox = true;
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.TabIndex = 17;
            // 
            // lblNgayKeTiep
            // 
            this.lblNgayKeTiep.AutoSize = true;
            this.lblNgayKeTiep.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKeTiep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayKeTiep.Location = new System.Drawing.Point(20, 192);
            this.lblNgayKeTiep.Text = "Đến hạn tiếp theo";
            this.lblNgayKeTiep.Name = "lblNgayKeTiep";
            this.lblNgayKeTiep.TabIndex = 18;
            // 
            // dtpNgayKeTiep
            // 
            this.dtpNgayKeTiep.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKeTiep.Location = new System.Drawing.Point(140, 188);
            this.dtpNgayKeTiep.Size = new System.Drawing.Size(250, 25);
            this.dtpNgayKeTiep.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKeTiep.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKeTiep.Name = "dtpNgayKeTiep";
            this.dtpNgayKeTiep.TabIndex = 19;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.chkTrangThai.Location = new System.Drawing.Point(540, 190);
            this.chkTrangThai.Text = "Đang hoạt động";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.TabIndex = 20;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGhiChu.Location = new System.Drawing.Point(20, 234);
            this.lblGhiChu.Text = "Ghi chú";
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.TabIndex = 21;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(140, 230);
            this.txtGhiChu.Size = new System.Drawing.Size(652, 25);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.TabIndex = 22;
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
            this.lblThongBao.TabIndex = 23;
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.AllowUserToAddRows = false;
            this.dgvGiaoDich.AllowUserToDeleteRows = false;
            this.dgvGiaoDich.AllowUserToResizeRows = false;
            this.dgvGiaoDich.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGiaoDich.BackgroundColor = System.Drawing.Color.White;
            this.dgvGiaoDich.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDich.EnableHeadersVisualStyles = false;
            this.dgvGiaoDich.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.dgvGiaoDich.Location = new System.Drawing.Point(24, 362);
            this.dgvGiaoDich.MultiSelect = false;
            this.dgvGiaoDich.ReadOnly = true;
            this.dgvGiaoDich.RowHeadersVisible = false;
            this.dgvGiaoDich.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGiaoDich.Size = new System.Drawing.Size(812, 176);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.TabIndex = 24;
            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGiaoDich.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGiaoDich.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvGiaoDich.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.dgvGiaoDich.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
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
            this.btnThem.TabIndex = 25;
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
            this.btnSua.TabIndex = 26;
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
            this.btnXoa.TabIndex = 27;
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
            this.btnLuu.TabIndex = 28;
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
            this.btnBoQua.TabIndex = 29;
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
            this.btnDong.TabIndex = 30;
            // 
            // frmGiaoDichDinhKy
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
            this.Controls.Add(this.dgvGiaoDich);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGiaoDichDinhKy";
            this.Text = "Giao dịch định kỳ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblMaGD;
        private System.Windows.Forms.TextBox txtMaGD;
        private System.Windows.Forms.Label lblLoaiGD;
        private System.Windows.Forms.ComboBox cboLoaiGD;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblMaVi;
        private System.Windows.Forms.ComboBox cboMaVi;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label lblTanSuat;
        private System.Windows.Forms.ComboBox cboTanSuat;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Label lblNgayKeTiep;
        private System.Windows.Forms.DateTimePicker dtpNgayKeTiep;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.DataGridView dgvGiaoDich;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnDong;
    }
}
