namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    partial class frmLoaiThuNhap
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
            this.lblThongKe = new System.Windows.Forms.Label();
            this.dgvLoaiThu = new System.Windows.Forms.DataGridView();
            this.lblDanhSachTieuDe = new System.Windows.Forms.Label();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.btnNgungSuDung = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTrangThaiGiaTri = new System.Windows.Forms.Label();
            this.lblTrangThaiTieuDe = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtTenLoaiThu = new System.Windows.Forms.TextBox();
            this.lblTenLoaiThu = new System.Windows.Forms.Label();
            this.lblDangChon = new System.Windows.Forms.Label();
            this.lblThongTinTieuDe = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiThu)).BeginInit();
            this.pnlThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(170, 32);
            this.lblTieuDe.TabIndex = 5;
            this.lblTieuDe.Text = "Loại thu nhập";
            // 
            // pnlDanhSach
            // 
            this.pnlDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDanhSach.BackColor = System.Drawing.Color.White;
            this.pnlDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDanhSach.Controls.Add(this.lblThongKe);
            this.pnlDanhSach.Controls.Add(this.dgvLoaiThu);
            this.pnlDanhSach.Controls.Add(this.lblDanhSachTieuDe);
            this.pnlDanhSach.Location = new System.Drawing.Point(24, 60);
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.Size = new System.Drawing.Size(730, 525);
            this.pnlDanhSach.TabIndex = 1;
            // 
            // lblThongKe
            // 
            this.lblThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblThongKe.Location = new System.Drawing.Point(16, 490);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(403, 23);
            this.lblThongKe.TabIndex = 0;
            this.lblThongKe.Text = "6 loại thu nhập • 5 đang sử dụng, 1 ngừng sử dụng";
            // 
            // dgvLoaiThu
            // 
            this.dgvLoaiThu.AllowUserToAddRows = false;
            this.dgvLoaiThu.AllowUserToDeleteRows = false;
            this.dgvLoaiThu.AllowUserToResizeRows = false;
            this.dgvLoaiThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoaiThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoaiThu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoaiThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiThu.EnableHeadersVisualStyles = false;
            this.dgvLoaiThu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvLoaiThu.Location = new System.Drawing.Point(16, 50);
            this.dgvLoaiThu.MultiSelect = false;
            this.dgvLoaiThu.Name = "dgvLoaiThu";
            this.dgvLoaiThu.ReadOnly = true;
            this.dgvLoaiThu.RowHeadersVisible = false;
            this.dgvLoaiThu.RowHeadersWidth = 51;
            this.dgvLoaiThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiThu.Size = new System.Drawing.Size(698, 425);
            this.dgvLoaiThu.TabIndex = 1;
            this.dgvLoaiThu.SelectionChanged += new System.EventHandler(this.dgvLoaiThu_SelectionChanged);
            // 
            // lblDanhSachTieuDe
            // 
            this.lblDanhSachTieuDe.AutoSize = true;
            this.lblDanhSachTieuDe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDanhSachTieuDe.Location = new System.Drawing.Point(16, 14);
            this.lblDanhSachTieuDe.Name = "lblDanhSachTieuDe";
            this.lblDanhSachTieuDe.Size = new System.Drawing.Size(224, 25);
            this.lblDanhSachTieuDe.TabIndex = 2;
            this.lblDanhSachTieuDe.Text = "Danh sách loại thu nhập";
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTin.Controls.Add(this.lblLuuY);
            this.pnlThongTin.Controls.Add(this.btnNgungSuDung);
            this.pnlThongTin.Controls.Add(this.btnMoi);
            this.pnlThongTin.Controls.Add(this.btnSua);
            this.pnlThongTin.Controls.Add(this.btnThem);
            this.pnlThongTin.Controls.Add(this.lblTrangThaiGiaTri);
            this.pnlThongTin.Controls.Add(this.lblTrangThaiTieuDe);
            this.pnlThongTin.Controls.Add(this.txtGhiChu);
            this.pnlThongTin.Controls.Add(this.lblGhiChu);
            this.pnlThongTin.Controls.Add(this.txtTenLoaiThu);
            this.pnlThongTin.Controls.Add(this.lblTenLoaiThu);
            this.pnlThongTin.Controls.Add(this.lblDangChon);
            this.pnlThongTin.Controls.Add(this.lblThongTinTieuDe);
            this.pnlThongTin.Location = new System.Drawing.Point(770, 60);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(380, 525);
            this.pnlThongTin.TabIndex = 2;
            // 
            // lblLuuY
            // 
            this.lblLuuY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLuuY.Location = new System.Drawing.Point(16, 465);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.Size = new System.Drawing.Size(345, 45);
            this.lblLuuY.TabIndex = 0;
            this.lblLuuY.Text = "Loại đã dùng trong giao dịch chỉ được ngừng sử dụng, không xóa lịch sử.";
            // 
            // btnNgungSuDung
            // 
            this.btnNgungSuDung.BackColor = System.Drawing.Color.White;
            this.btnNgungSuDung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNgungSuDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNgungSuDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNgungSuDung.Location = new System.Drawing.Point(16, 415);
            this.btnNgungSuDung.Name = "btnNgungSuDung";
            this.btnNgungSuDung.Size = new System.Drawing.Size(345, 38);
            this.btnNgungSuDung.TabIndex = 6;
            this.btnNgungSuDung.Text = "Ngừng sử dụng";
            this.btnNgungSuDung.UseVisualStyleBackColor = false;
            this.btnNgungSuDung.Click += new System.EventHandler(this.btnNgungSuDung_Click);
            // 
            // btnMoi
            // 
            this.btnMoi.BackColor = System.Drawing.Color.White;
            this.btnMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnMoi.Location = new System.Drawing.Point(281, 365);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(80, 38);
            this.btnMoi.TabIndex = 5;
            this.btnMoi.Text = "Mới";
            this.btnMoi.UseVisualStyleBackColor = false;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSua.Location = new System.Drawing.Point(185, 365);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 38);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(16, 365);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(158, 38);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblTrangThaiGiaTri
            // 
            this.lblTrangThaiGiaTri.AutoSize = true;
            this.lblTrangThaiGiaTri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTrangThaiGiaTri.Location = new System.Drawing.Point(95, 325);
            this.lblTrangThaiGiaTri.Name = "lblTrangThaiGiaTri";
            this.lblTrangThaiGiaTri.Size = new System.Drawing.Size(118, 23);
            this.lblTrangThaiGiaTri.TabIndex = 7;
            this.lblTrangThaiGiaTri.Text = "Đang sử dụng";
            // 
            // lblTrangThaiTieuDe
            // 
            this.lblTrangThaiTieuDe.AutoSize = true;
            this.lblTrangThaiTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTrangThaiTieuDe.Location = new System.Drawing.Point(16, 325);
            this.lblTrangThaiTieuDe.Name = "lblTrangThaiTieuDe";
            this.lblTrangThaiTieuDe.Size = new System.Drawing.Size(91, 23);
            this.lblTrangThaiTieuDe.TabIndex = 8;
            this.lblTrangThaiTieuDe.Text = "Trạng thái:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(16, 175);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(345, 125);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGhiChu.Location = new System.Drawing.Point(16, 150);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(69, 23);
            this.lblGhiChu.TabIndex = 9;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtTenLoaiThu
            // 
            this.txtTenLoaiThu.Location = new System.Drawing.Point(16, 105);
            this.txtTenLoaiThu.Name = "txtTenLoaiThu";
            this.txtTenLoaiThu.Size = new System.Drawing.Size(345, 30);
            this.txtTenLoaiThu.TabIndex = 1;
            this.txtTenLoaiThu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // lblTenLoaiThu
            // 
            this.lblTenLoaiThu.AutoSize = true;
            this.lblTenLoaiThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTenLoaiThu.Location = new System.Drawing.Point(16, 80);
            this.lblTenLoaiThu.Name = "lblTenLoaiThu";
            this.lblTenLoaiThu.Size = new System.Drawing.Size(99, 23);
            this.lblTenLoaiThu.TabIndex = 10;
            this.lblTenLoaiThu.Text = "Tên loại thu";
            // 
            // lblDangChon
            // 
            this.lblDangChon.AutoSize = true;
            this.lblDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDangChon.Location = new System.Drawing.Point(16, 45);
            this.lblDangChon.Name = "lblDangChon";
            this.lblDangChon.Size = new System.Drawing.Size(151, 23);
            this.lblDangChon.TabIndex = 11;
            this.lblDangChon.Text = "Đang chọn: Lương";
            // 
            // lblThongTinTieuDe
            // 
            this.lblThongTinTieuDe.AutoSize = true;
            this.lblThongTinTieuDe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblThongTinTieuDe.Location = new System.Drawing.Point(80, 0);
            this.lblThongTinTieuDe.Name = "lblThongTinTieuDe";
            this.lblThongTinTieuDe.Size = new System.Drawing.Size(221, 25);
            this.lblThongTinTieuDe.TabIndex = 12;
            this.lblThongTinTieuDe.Text = "Thông tin loại thu nhập";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblThongBao.Location = new System.Drawing.Point(24, 595);
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
            this.btnDong.Location = new System.Drawing.Point(1050, 595);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 38);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmLoaiThuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1175, 645);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.pnlDanhSach);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoaiThuNhap";
            this.Text = "Loại thu nhập";
            this.Load += new System.EventHandler(this.frmLoaiThuNhap_Load);
            this.pnlDanhSach.ResumeLayout(false);
            this.pnlDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiThu)).EndInit();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlDanhSach;
        private System.Windows.Forms.Label lblDanhSachTieuDe;
        private System.Windows.Forms.DataGridView dgvLoaiThu;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblThongTinTieuDe;
        private System.Windows.Forms.Label lblDangChon;
        private System.Windows.Forms.Label lblTenLoaiThu;
        private System.Windows.Forms.TextBox txtTenLoaiThu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblTrangThaiTieuDe;
        private System.Windows.Forms.Label lblTrangThaiGiaTri;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnNgungSuDung;
        private System.Windows.Forms.Label lblLuuY;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Button btnDong;
    }
}