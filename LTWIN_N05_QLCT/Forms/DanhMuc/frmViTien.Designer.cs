namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    partial class frmViTien
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
            this.lblMaVi = new System.Windows.Forms.Label();
            this.txtMaVi = new System.Windows.Forms.TextBox();
            this.lblTenVi = new System.Windows.Forms.Label();
            this.txtTenVi = new System.Windows.Forms.TextBox();
            this.lblLoaiVi = new System.Windows.Forms.Label();
            this.cboLoaiVi = new System.Windows.Forms.ComboBox();
            this.lblSoDuBanDau = new System.Windows.Forms.Label();
            this.txtSoDuBanDau = new System.Windows.Forms.TextBox();
            this.lblSoDuHienTai = new System.Windows.Forms.Label();
            this.txtSoDuHienTai = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.dgvViTien = new System.Windows.Forms.DataGridView();
            this.pnlNut = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViTien)).BeginInit();
            this.pnlNut.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 16);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(210, 25);
            this.lblTieuDe.Text = "DANH MỤC VÍ TIỀN";
            this.lblTieuDe.TabIndex = 0;
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.Location = new System.Drawing.Point(24, 60);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(872, 190);
            this.pnlThongTin.TabIndex = 1;
            this.pnlThongTin.Controls.Add(this.lblMaVi);
            this.pnlThongTin.Controls.Add(this.txtMaVi);
            this.pnlThongTin.Controls.Add(this.lblTenVi);
            this.pnlThongTin.Controls.Add(this.txtTenVi);
            this.pnlThongTin.Controls.Add(this.lblLoaiVi);
            this.pnlThongTin.Controls.Add(this.cboLoaiVi);
            this.pnlThongTin.Controls.Add(this.lblSoDuBanDau);
            this.pnlThongTin.Controls.Add(this.txtSoDuBanDau);
            this.pnlThongTin.Controls.Add(this.lblSoDuHienTai);
            this.pnlThongTin.Controls.Add(this.txtSoDuHienTai);
            this.pnlThongTin.Controls.Add(this.lblGhiChu);
            this.pnlThongTin.Controls.Add(this.txtGhiChu);
            this.pnlThongTin.Controls.Add(this.chkTrangThai);
            // 
            // lblMaVi
            // 
            this.lblMaVi.AutoSize = true;
            this.lblMaVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMaVi.Location = new System.Drawing.Point(20, 24);
            this.lblMaVi.Name = "lblMaVi";
            this.lblMaVi.Size = new System.Drawing.Size(80, 19);
            this.lblMaVi.Text = "Mã ví";
            this.lblMaVi.TabIndex = 2;
            // 
            // txtMaVi
            // 
            this.txtMaVi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtMaVi.Location = new System.Drawing.Point(140, 20);
            this.txtMaVi.Name = "txtMaVi";
            this.txtMaVi.ReadOnly = true;
            this.txtMaVi.Size = new System.Drawing.Size(280, 25);
            this.txtMaVi.TabStop = false;
            this.txtMaVi.Text = "(tự sinh)";
            this.txtMaVi.TabIndex = 3;
            // 
            // lblTenVi
            // 
            this.lblTenVi.AutoSize = true;
            this.lblTenVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTenVi.Location = new System.Drawing.Point(450, 24);
            this.lblTenVi.Name = "lblTenVi";
            this.lblTenVi.Size = new System.Drawing.Size(80, 19);
            this.lblTenVi.Text = "Tên ví";
            this.lblTenVi.TabIndex = 4;
            // 
            // txtTenVi
            // 
            this.txtTenVi.Location = new System.Drawing.Point(570, 20);
            this.txtTenVi.MaxLength = 50;
            this.txtTenVi.Name = "txtTenVi";
            this.txtTenVi.Size = new System.Drawing.Size(280, 25);
            this.txtTenVi.TabIndex = 5;
            this.txtTenVi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // lblLoaiVi
            // 
            this.lblLoaiVi.AutoSize = true;
            this.lblLoaiVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblLoaiVi.Location = new System.Drawing.Point(20, 66);
            this.lblLoaiVi.Name = "lblLoaiVi";
            this.lblLoaiVi.Size = new System.Drawing.Size(80, 19);
            this.lblLoaiVi.Text = "Loại ví";
            this.lblLoaiVi.TabIndex = 6;
            // 
            // cboLoaiVi
            // 
            this.cboLoaiVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiVi.FormattingEnabled = true;
            this.cboLoaiVi.Location = new System.Drawing.Point(140, 62);
            this.cboLoaiVi.Name = "cboLoaiVi";
            this.cboLoaiVi.Size = new System.Drawing.Size(280, 25);
            this.cboLoaiVi.TabIndex = 7;
            this.cboLoaiVi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // lblSoDuBanDau
            // 
            this.lblSoDuBanDau.AutoSize = true;
            this.lblSoDuBanDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSoDuBanDau.Location = new System.Drawing.Point(450, 66);
            this.lblSoDuBanDau.Name = "lblSoDuBanDau";
            this.lblSoDuBanDau.Size = new System.Drawing.Size(80, 19);
            this.lblSoDuBanDau.Text = "Số dư ban đầu";
            this.lblSoDuBanDau.TabIndex = 8;
            // 
            // txtSoDuBanDau
            // 
            this.txtSoDuBanDau.Location = new System.Drawing.Point(570, 62);
            this.txtSoDuBanDau.MaxLength = 15;
            this.txtSoDuBanDau.Name = "txtSoDuBanDau";
            this.txtSoDuBanDau.Size = new System.Drawing.Size(280, 25);
            this.txtSoDuBanDau.Text = "0";
            this.txtSoDuBanDau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoDuBanDau.TabIndex = 9;
            this.txtSoDuBanDau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoDuBanDau_KeyPress);
            this.txtSoDuBanDau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // lblSoDuHienTai
            // 
            this.lblSoDuHienTai.AutoSize = true;
            this.lblSoDuHienTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSoDuHienTai.Location = new System.Drawing.Point(20, 108);
            this.lblSoDuHienTai.Name = "lblSoDuHienTai";
            this.lblSoDuHienTai.Size = new System.Drawing.Size(80, 19);
            this.lblSoDuHienTai.Text = "Số dư hiện tại";
            this.lblSoDuHienTai.TabIndex = 10;
            // 
            // txtSoDuHienTai
            // 
            this.txtSoDuHienTai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtSoDuHienTai.Location = new System.Drawing.Point(140, 104);
            this.txtSoDuHienTai.Name = "txtSoDuHienTai";
            this.txtSoDuHienTai.ReadOnly = true;
            this.txtSoDuHienTai.Size = new System.Drawing.Size(280, 25);
            this.txtSoDuHienTai.TabStop = false;
            this.txtSoDuHienTai.Text = "0";
            this.txtSoDuHienTai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoDuHienTai.TabIndex = 11;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblGhiChu.Location = new System.Drawing.Point(450, 108);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(80, 19);
            this.lblGhiChu.Text = "Ghi chú";
            this.lblGhiChu.TabIndex = 12;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(570, 104);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(280, 25);
            this.txtGhiChu.TabIndex = 13;
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.chkTrangThai.Location = new System.Drawing.Point(140, 146);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(115, 23);
            this.chkTrangThai.Text = "Đang sử dụng";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            this.chkTrangThai.TabIndex = 14;
            // 
            // dgvViTien
            // 
            this.dgvViTien.AllowUserToAddRows = false;
            this.dgvViTien.AllowUserToDeleteRows = false;
            this.dgvViTien.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvViTien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViTien.Location = new System.Drawing.Point(24, 266);
            this.dgvViTien.MultiSelect = false;
            this.dgvViTien.Name = "dgvViTien";
            this.dgvViTien.ReadOnly = true;
            this.dgvViTien.RowHeadersWidth = 51;
            this.dgvViTien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViTien.Size = new System.Drawing.Size(872, 270);
            this.dgvViTien.TabIndex = 15;
            this.dgvViTien.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvViTien_CellFormatting);
            this.dgvViTien.SelectionChanged += new System.EventHandler(this.dgvViTien_SelectionChanged);
            // 
            // pnlNut
            // 
            this.pnlNut.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlNut.Location = new System.Drawing.Point(24, 548);
            this.pnlNut.Name = "pnlNut";
            this.pnlNut.Size = new System.Drawing.Size(872, 40);
            this.pnlNut.TabIndex = 16;
            this.pnlNut.Controls.Add(this.btnThem);
            this.pnlNut.Controls.Add(this.btnSua);
            this.pnlNut.Controls.Add(this.btnXoa);
            this.pnlNut.Controls.Add(this.btnLuu);
            this.pnlNut.Controls.Add(this.btnBoQua);
            this.pnlNut.Controls.Add(this.btnDong);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThem.FlatAppearance.BorderSize = 1;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(0, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 38);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.TabIndex = 17;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSua.FlatAppearance.BorderSize = 1;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSua.Location = new System.Drawing.Point(112, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 38);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.TabIndex = 18;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnXoa.FlatAppearance.BorderSize = 1;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXoa.Location = new System.Drawing.Point(224, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 38);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnLuu.FlatAppearance.BorderSize = 1;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(336, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 38);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Enabled = false;
            this.btnLuu.TabIndex = 20;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnBoQua.BackColor = System.Drawing.Color.White;
            this.btnBoQua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoQua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnBoQua.FlatAppearance.BorderSize = 1;
            this.btnBoQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoQua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnBoQua.Location = new System.Drawing.Point(448, 0);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(100, 38);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = false;
            this.btnBoQua.Enabled = false;
            this.btnBoQua.TabIndex = 21;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDong.FlatAppearance.BorderSize = 1;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDong.Location = new System.Drawing.Point(772, 0);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 38);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.TabIndex = 22;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmViTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(920, 610);
            this.Controls.Add(this.pnlNut);
            this.Controls.Add(this.dgvViTien);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmViTien";
            this.Text = "Ví tiền";
            this.Load += new System.EventHandler(this.frmViTien_Load);
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViTien)).EndInit();
            this.pnlNut.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblMaVi;
        private System.Windows.Forms.TextBox txtMaVi;
        private System.Windows.Forms.Label lblTenVi;
        private System.Windows.Forms.TextBox txtTenVi;
        private System.Windows.Forms.Label lblLoaiVi;
        private System.Windows.Forms.ComboBox cboLoaiVi;
        private System.Windows.Forms.Label lblSoDuBanDau;
        private System.Windows.Forms.TextBox txtSoDuBanDau;
        private System.Windows.Forms.Label lblSoDuHienTai;
        private System.Windows.Forms.TextBox txtSoDuHienTai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.DataGridView dgvViTien;
        private System.Windows.Forms.Panel pnlNut;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnDong;
    }
}
