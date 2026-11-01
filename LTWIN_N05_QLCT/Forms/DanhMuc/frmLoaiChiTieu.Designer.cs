namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    partial class frmLoaiChiTieu
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
            this.pnlNhapLieu = new System.Windows.Forms.Panel();
            this.lblMaLoaiChi = new System.Windows.Forms.Label();
            this.txtMaLoaiChi = new System.Windows.Forms.TextBox();
            this.lblNhomChi = new System.Windows.Forms.Label();
            this.cboNhomChi = new System.Windows.Forms.ComboBox();
            this.lblTenLoaiChi = new System.Windows.Forms.Label();
            this.txtTenLoaiChi = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.dgvLoaiChiTieu = new System.Windows.Forms.DataGridView();
            this.pnlNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiChiTieu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(168, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Loại chi tiêu";
            // 
            // pnlNhapLieu
            // 
            this.pnlNhapLieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNhapLieu.BackColor = System.Drawing.Color.White;
            this.pnlNhapLieu.Controls.Add(this.lblMaLoaiChi);
            this.pnlNhapLieu.Controls.Add(this.txtMaLoaiChi);
            this.pnlNhapLieu.Controls.Add(this.lblNhomChi);
            this.pnlNhapLieu.Controls.Add(this.cboNhomChi);
            this.pnlNhapLieu.Controls.Add(this.lblTenLoaiChi);
            this.pnlNhapLieu.Controls.Add(this.txtTenLoaiChi);
            this.pnlNhapLieu.Controls.Add(this.lblGhiChu);
            this.pnlNhapLieu.Controls.Add(this.txtGhiChu);
            this.pnlNhapLieu.Controls.Add(this.chkTrangThai);
            this.pnlNhapLieu.Controls.Add(this.btnThem);
            this.pnlNhapLieu.Controls.Add(this.btnSua);
            this.pnlNhapLieu.Controls.Add(this.btnXoa);
            this.pnlNhapLieu.Controls.Add(this.btnLuu);
            this.pnlNhapLieu.Controls.Add(this.btnBoQua);
            this.pnlNhapLieu.Controls.Add(this.btnDong);
            this.pnlNhapLieu.Location = new System.Drawing.Point(24, 64);
            this.pnlNhapLieu.Name = "pnlNhapLieu";
            this.pnlNhapLieu.Size = new System.Drawing.Size(952, 196);
            this.pnlNhapLieu.TabIndex = 1;
            // 
            // lblMaLoaiChi
            // 
            this.lblMaLoaiChi.AutoSize = true;
            this.lblMaLoaiChi.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaLoaiChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMaLoaiChi.Location = new System.Drawing.Point(20, 24);
            this.lblMaLoaiChi.Name = "lblMaLoaiChi";
            this.lblMaLoaiChi.Size = new System.Drawing.Size(76, 21);
            this.lblMaLoaiChi.TabIndex = 0;
            this.lblMaLoaiChi.Text = "Mã loại chi";
            // 
            // txtMaLoaiChi
            // 
            this.txtMaLoaiChi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtMaLoaiChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoaiChi.Location = new System.Drawing.Point(140, 20);
            this.txtMaLoaiChi.Name = "txtMaLoaiChi";
            this.txtMaLoaiChi.ReadOnly = true;
            this.txtMaLoaiChi.Size = new System.Drawing.Size(280, 25);
            this.txtMaLoaiChi.TabIndex = 1;
            this.txtMaLoaiChi.TabStop = false;
            // 
            // lblNhomChi
            // 
            this.lblNhomChi.AutoSize = true;
            this.lblNhomChi.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhomChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNhomChi.Location = new System.Drawing.Point(460, 24);
            this.lblNhomChi.Name = "lblNhomChi";
            this.lblNhomChi.Size = new System.Drawing.Size(65, 21);
            this.lblNhomChi.TabIndex = 2;
            this.lblNhomChi.Text = "Nhóm chi";
            // 
            // cboNhomChi
            // 
            this.cboNhomChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhomChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhomChi.FormattingEnabled = true;
            this.cboNhomChi.Location = new System.Drawing.Point(570, 20);
            this.cboNhomChi.Name = "cboNhomChi";
            this.cboNhomChi.Size = new System.Drawing.Size(350, 25);
            this.cboNhomChi.TabIndex = 3;
            // 
            // lblTenLoaiChi
            // 
            this.lblTenLoaiChi.AutoSize = true;
            this.lblTenLoaiChi.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLoaiChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTenLoaiChi.Location = new System.Drawing.Point(20, 64);
            this.lblTenLoaiChi.Name = "lblTenLoaiChi";
            this.lblTenLoaiChi.Size = new System.Drawing.Size(79, 21);
            this.lblTenLoaiChi.TabIndex = 4;
            this.lblTenLoaiChi.Text = "Tên loại chi";
            // 
            // txtTenLoaiChi
            // 
            this.txtTenLoaiChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLoaiChi.Location = new System.Drawing.Point(140, 60);
            this.txtTenLoaiChi.MaxLength = 50;
            this.txtTenLoaiChi.Name = "txtTenLoaiChi";
            this.txtTenLoaiChi.Size = new System.Drawing.Size(280, 25);
            this.txtTenLoaiChi.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGhiChu.Location = new System.Drawing.Point(460, 64);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(57, 21);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(570, 60);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(350, 25);
            this.txtGhiChu.TabIndex = 7;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.chkTrangThai.Location = new System.Drawing.Point(140, 100);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(118, 25);
            this.chkTrangThai.TabIndex = 8;
            this.chkTrangThai.Text = "Đang sử dụng";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnThem.Location = new System.Drawing.Point(20, 144);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 34);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSua.Location = new System.Drawing.Point(130, 144);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 34);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXoa.Location = new System.Drawing.Point(240, 144);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 34);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(350, 144);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 34);
            this.btnLuu.TabIndex = 12;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnBoQua
            // 
            this.btnBoQua.BackColor = System.Drawing.Color.White;
            this.btnBoQua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoQua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnBoQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoQua.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnBoQua.Location = new System.Drawing.Point(460, 144);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(100, 34);
            this.btnBoQua.TabIndex = 13;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDong.Location = new System.Drawing.Point(570, 144);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 34);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblThongBao.Location = new System.Drawing.Point(24, 270);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 20);
            this.lblThongBao.TabIndex = 15;
            this.lblThongBao.Visible = false;
            // 
            // dgvLoaiChiTieu
            // 
            this.dgvLoaiChiTieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoaiChiTieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiChiTieu.Location = new System.Drawing.Point(24, 300);
            this.dgvLoaiChiTieu.Name = "dgvLoaiChiTieu";
            this.dgvLoaiChiTieu.Size = new System.Drawing.Size(952, 260);
            this.dgvLoaiChiTieu.TabIndex = 16;
            // 
            // frmLoaiChiTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1000, 584);
            this.Controls.Add(this.dgvLoaiChiTieu);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.pnlNhapLieu);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoaiChiTieu";
            this.Text = "Loại chi tiêu";
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiChiTieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlNhapLieu;
        private System.Windows.Forms.Label lblMaLoaiChi;
        private System.Windows.Forms.TextBox txtMaLoaiChi;
        private System.Windows.Forms.Label lblNhomChi;
        private System.Windows.Forms.ComboBox cboNhomChi;
        private System.Windows.Forms.Label lblTenLoaiChi;
        private System.Windows.Forms.TextBox txtTenLoaiChi;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.DataGridView dgvLoaiChiTieu;
    }
}
