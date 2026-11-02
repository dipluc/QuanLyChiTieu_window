namespace LTWIN_N05_QLCT.Forms.HeThong
{
    partial class frmPhanQuyen
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
            this.pnlDanhSach = new System.Windows.Forms.Panel();
            this.lblChiDoc = new System.Windows.Forms.Label();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.dgvPhanQuyen = new System.Windows.Forms.DataGridView();
            this.colMaND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuyenHienTai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDanhSachTieuDe = new System.Windows.Forms.Label();
            this.pnlVaiTro = new System.Windows.Forms.Panel();
            this.pnlLuuY = new System.Windows.Forms.Panel();
            this.lblLuuYNoiDung = new System.Windows.Forms.Label();
            this.lblLuuYThieuDe = new System.Windows.Forms.Label();
            this.btnLuuQuyen = new System.Windows.Forms.Button();
            this.lblHuongDanVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblThongTinTrangThai = new System.Windows.Forms.Label();
            this.txtTaiKhoanChon = new System.Windows.Forms.TextBox();
            this.lblTaiKhoanDangChon = new System.Windows.Forms.Label();
            this.lblGanVaiTroTieuDe = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).BeginInit();
            this.pnlVaiTro.SuspendLayout();
            this.pnlLuuY.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(262, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Phân quyền tài khoản";
            // 
            // pnlDanhSach
            // 
            this.pnlDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDanhSach.BackColor = System.Drawing.Color.White;
            this.pnlDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDanhSach.Controls.Add(this.lblChiDoc);
            this.pnlDanhSach.Controls.Add(this.lblThongKe);
            this.pnlDanhSach.Controls.Add(this.dgvPhanQuyen);
            this.pnlDanhSach.Controls.Add(this.lblDanhSachTieuDe);
            this.pnlDanhSach.Location = new System.Drawing.Point(24, 65);
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.Size = new System.Drawing.Size(730, 560);
            this.pnlDanhSach.TabIndex = 1;
            // 
            // lblChiDoc
            // 
            this.lblChiDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChiDoc.AutoSize = true;
            this.lblChiDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChiDoc.Location = new System.Drawing.Point(671, 16);
            this.lblChiDoc.Name = "lblChiDoc";
            this.lblChiDoc.Size = new System.Drawing.Size(68, 23);
            this.lblChiDoc.TabIndex = 3;
            this.lblChiDoc.Text = "Chỉ đọc";
            // 
            // lblThongKe
            // 
            this.lblThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblThongKe.Location = new System.Drawing.Point(16, 525);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(500, 23);
            this.lblThongKe.TabIndex = 2;
            this.lblThongKe.Text = "5 tài khoản • 4 hoạt động, 1 đã khóa • 1 Admin đang hoạt động";
            // 
            // dgvPhanQuyen
            // 
            this.dgvPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhanQuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanQuyen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaND,
            this.colTenDangNhap,
            this.colHoTen,
            this.colQuyenHienTai,
            this.colTrangThai});
            this.dgvPhanQuyen.EnableHeadersVisualStyles = false;
            this.dgvPhanQuyen.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvPhanQuyen.Location = new System.Drawing.Point(16, 50);
            this.dgvPhanQuyen.MultiSelect = false;
            this.dgvPhanQuyen.Name = "dgvPhanQuyen";
            this.dgvPhanQuyen.ReadOnly = true;
            this.dgvPhanQuyen.RowHeadersVisible = false;
            this.dgvPhanQuyen.RowHeadersWidth = 51;
            this.dgvPhanQuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhanQuyen.Size = new System.Drawing.Size(698, 460);
            this.dgvPhanQuyen.TabIndex = 1;
            // 
            // colMaND
            // 
            this.colMaND.DataPropertyName = "MaND";
            this.colMaND.MinimumWidth = 6;
            this.colMaND.Name = "colMaND";
            this.colMaND.ReadOnly = true;
            this.colMaND.Visible = false;
            this.colMaND.Width = 125;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.DataPropertyName = "TenDangNhap";
            this.colTenDangNhap.FillWeight = 110F;
            this.colTenDangNhap.HeaderText = "Tên đăng nhập";
            this.colTenDangNhap.MinimumWidth = 6;
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.ReadOnly = true;
            this.colTenDangNhap.Width = 125;
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.FillWeight = 160F;
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            this.colHoTen.Width = 125;
            // 
            // colQuyenHienTai
            // 
            this.colQuyenHienTai.DataPropertyName = "QuyenHienTai";
            this.colQuyenHienTai.FillWeight = 90F;
            this.colQuyenHienTai.HeaderText = "Vai trò";
            this.colQuyenHienTai.MinimumWidth = 6;
            this.colQuyenHienTai.Name = "colQuyenHienTai";
            this.colQuyenHienTai.ReadOnly = true;
            this.colQuyenHienTai.Width = 125;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThaiText";
            this.colTrangThai.FillWeight = 90F;
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 125;
            // 
            // lblDanhSachTieuDe
            // 
            this.lblDanhSachTieuDe.AutoSize = true;
            this.lblDanhSachTieuDe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDanhSachTieuDe.Location = new System.Drawing.Point(16, 14);
            this.lblDanhSachTieuDe.Name = "lblDanhSachTieuDe";
            this.lblDanhSachTieuDe.Size = new System.Drawing.Size(190, 25);
            this.lblDanhSachTieuDe.TabIndex = 0;
            this.lblDanhSachTieuDe.Text = "Danh sách tài khoản";
            // 
            // pnlVaiTro
            // 
            this.pnlVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVaiTro.BackColor = System.Drawing.Color.White;
            this.pnlVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVaiTro.Controls.Add(this.pnlLuuY);
            this.pnlVaiTro.Controls.Add(this.btnLuuQuyen);
            this.pnlVaiTro.Controls.Add(this.lblHuongDanVaiTro);
            this.pnlVaiTro.Controls.Add(this.cboVaiTro);
            this.pnlVaiTro.Controls.Add(this.lblVaiTro);
            this.pnlVaiTro.Controls.Add(this.lblThongTinTrangThai);
            this.pnlVaiTro.Controls.Add(this.txtTaiKhoanChon);
            this.pnlVaiTro.Controls.Add(this.lblTaiKhoanDangChon);
            this.pnlVaiTro.Controls.Add(this.lblGanVaiTroTieuDe);
            this.pnlVaiTro.Location = new System.Drawing.Point(770, 65);
            this.pnlVaiTro.Name = "pnlVaiTro";
            this.pnlVaiTro.Size = new System.Drawing.Size(380, 560);
            this.pnlVaiTro.TabIndex = 2;
            // 
            // pnlLuuY
            // 
            this.pnlLuuY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlLuuY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLuuY.Controls.Add(this.lblLuuYNoiDung);
            this.pnlLuuY.Controls.Add(this.lblLuuYThieuDe);
            this.pnlLuuY.Location = new System.Drawing.Point(16, 420);
            this.pnlLuuY.Name = "pnlLuuY";
            this.pnlLuuY.Size = new System.Drawing.Size(345, 120);
            this.pnlLuuY.TabIndex = 8;
            // 
            // lblLuuYNoiDung
            // 
            this.lblLuuYNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLuuYNoiDung.Location = new System.Drawing.Point(12, 35);
            this.lblLuuYNoiDung.Name = "lblLuuYNoiDung";
            this.lblLuuYNoiDung.Size = new System.Drawing.Size(320, 70);
            this.lblLuuYNoiDung.TabIndex = 1;
            this.lblLuuYNoiDung.Text = "Hệ thống phải luôn có ít nhất một Admin đang hoạt động. Không được hạ quyền hoặc " +
    "khóa Admin hoạt động cuối cùng.";
            // 
            // lblLuuYThieuDe
            // 
            this.lblLuuYThieuDe.AutoSize = true;
            this.lblLuuYThieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuuYThieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblLuuYThieuDe.Location = new System.Drawing.Point(12, 10);
            this.lblLuuYThieuDe.Name = "lblLuuYThieuDe";
            this.lblLuuYThieuDe.Size = new System.Drawing.Size(190, 21);
            this.lblLuuYThieuDe.TabIndex = 0;
            this.lblLuuYThieuDe.Text = "Lưu ý về quyền quản trị";
            // 
            // btnLuuQuyen
            // 
            this.btnLuuQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnLuuQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuQuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuQuyen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuQuyen.ForeColor = System.Drawing.Color.White;
            this.btnLuuQuyen.Location = new System.Drawing.Point(16, 360);
            this.btnLuuQuyen.Name = "btnLuuQuyen";
            this.btnLuuQuyen.Size = new System.Drawing.Size(345, 38);
            this.btnLuuQuyen.TabIndex = 7;
            this.btnLuuQuyen.Text = "Lưu quyền";
            this.btnLuuQuyen.UseVisualStyleBackColor = false;
            // 
            // lblHuongDanVaiTro
            // 
            this.lblHuongDanVaiTro.AutoSize = true;
            this.lblHuongDanVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHuongDanVaiTro.Location = new System.Drawing.Point(16, 325);
            this.lblHuongDanVaiTro.Name = "lblHuongDanVaiTro";
            this.lblHuongDanVaiTro.Size = new System.Drawing.Size(266, 23);
            this.lblHuongDanVaiTro.TabIndex = 6;
            this.lblHuongDanVaiTro.Text = "Vai trò có thể chọn: Admin / User";
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(16, 290);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(345, 31);
            this.cboVaiTro.TabIndex = 5;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblVaiTro.Location = new System.Drawing.Point(16, 265);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(60, 23);
            this.lblVaiTro.TabIndex = 4;
            this.lblVaiTro.Text = "Vai trò";
            // 
            // lblThongTinTrangThai
            // 
            this.lblThongTinTrangThai.AutoSize = true;
            this.lblThongTinTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblThongTinTrangThai.Location = new System.Drawing.Point(16, 130);
            this.lblThongTinTrangThai.Name = "lblThongTinTrangThai";
            this.lblThongTinTrangThai.Size = new System.Drawing.Size(277, 23);
            this.lblThongTinTrangThai.TabIndex = 3;
            this.lblThongTinTrangThai.Text = "Nguyễn Phương Thảo • Hoạt động";
            // 
            // txtTaiKhoanChon
            // 
            this.txtTaiKhoanChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTaiKhoanChon.Location = new System.Drawing.Point(16, 95);
            this.txtTaiKhoanChon.Name = "txtTaiKhoanChon";
            this.txtTaiKhoanChon.ReadOnly = true;
            this.txtTaiKhoanChon.Size = new System.Drawing.Size(345, 30);
            this.txtTaiKhoanChon.TabIndex = 2;
            // 
            // lblTaiKhoanDangChon
            // 
            this.lblTaiKhoanDangChon.AutoSize = true;
            this.lblTaiKhoanDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTaiKhoanDangChon.Location = new System.Drawing.Point(16, 70);
            this.lblTaiKhoanDangChon.Name = "lblTaiKhoanDangChon";
            this.lblTaiKhoanDangChon.Size = new System.Drawing.Size(169, 23);
            this.lblTaiKhoanDangChon.TabIndex = 1;
            this.lblTaiKhoanDangChon.Text = "Tài khoản đang chọn";
            // 
            // lblGanVaiTroTieuDe
            // 
            this.lblGanVaiTroTieuDe.AutoSize = true;
            this.lblGanVaiTroTieuDe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanVaiTroTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGanVaiTroTieuDe.Location = new System.Drawing.Point(130, 14);
            this.lblGanVaiTroTieuDe.Name = "lblGanVaiTroTieuDe";
            this.lblGanVaiTroTieuDe.Size = new System.Drawing.Size(110, 25);
            this.lblGanVaiTroTieuDe.TabIndex = 0;
            this.lblGanVaiTroTieuDe.Text = "Gán vai trò";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblThongBao.Location = new System.Drawing.Point(24, 635);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 23);
            this.lblThongBao.TabIndex = 4;
            this.lblThongBao.Visible = false;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDong.Location = new System.Drawing.Point(1050, 635);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 38);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1175, 685);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.pnlVaiTro);
            this.Controls.Add(this.pnlDanhSach);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhanQuyen";
            this.Text = "Phân quyền tài khoản";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            this.pnlDanhSach.ResumeLayout(false);
            this.pnlDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).EndInit();
            this.pnlVaiTro.ResumeLayout(false);
            this.pnlVaiTro.PerformLayout();
            this.pnlLuuY.ResumeLayout(false);
            this.pnlLuuY.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlDanhSach;
        private System.Windows.Forms.Label lblDanhSachTieuDe;
        private System.Windows.Forms.DataGridView dgvPhanQuyen;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Panel pnlVaiTro;
        private System.Windows.Forms.Label lblGanVaiTroTieuDe;
        private System.Windows.Forms.Label lblTaiKhoanDangChon;
        private System.Windows.Forms.TextBox txtTaiKhoanChon;
        private System.Windows.Forms.Label lblThongTinTrangThai;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblHuongDanVaiTro;
        private System.Windows.Forms.Button btnLuuQuyen;
        private System.Windows.Forms.Panel pnlLuuY;
        private System.Windows.Forms.Label lblLuuYThieuDe;
        private System.Windows.Forms.Label lblLuuYNoiDung;
        private System.Windows.Forms.Label lblChiDoc;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaND;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuyenHienTai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}