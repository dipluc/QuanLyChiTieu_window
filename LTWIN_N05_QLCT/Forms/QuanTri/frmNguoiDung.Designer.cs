namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    partial class frmNguoiDung
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
            this.lblQuanLyNguoiDung = new System.Windows.Forms.Label();
            this.lblQuyenTruyCap = new System.Windows.Forms.Label();
            this.pnlDanhSachNguoiDung = new System.Windows.Forms.Panel();
            this.pnlChan = new System.Windows.Forms.Panel();
            this.btnDoiQuyen = new System.Windows.Forms.Button();
            this.btnDatLaiMatKhau = new System.Windows.Forms.Button();
            this.btnKhoaMoKhoa = new System.Windows.Forms.Button();
            this.lblTaiKhoanDaChon = new System.Windows.Forms.Label();
            this.dgvNguoiDung = new System.Windows.Forms.DataGridView();
            this.pnlThongTinDanhSach = new System.Windows.Forms.Panel();
            this.lblCheDo = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.pnlDanhSachNguoiDung.SuspendLayout();
            this.pnlChan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.pnlThongTinDanhSach.SuspendLayout();
            this.pnlTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuanLyNguoiDung
            // 
            this.lblQuanLyNguoiDung.AutoSize = true;
            this.lblQuanLyNguoiDung.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblQuanLyNguoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblQuanLyNguoiDung.Location = new System.Drawing.Point(16, 8);
            this.lblQuanLyNguoiDung.Name = "lblQuanLyNguoiDung";
            this.lblQuanLyNguoiDung.Size = new System.Drawing.Size(244, 32);
            this.lblQuanLyNguoiDung.TabIndex = 0;
            this.lblQuanLyNguoiDung.Text = "Quản lý người dùng";
            // 
            // lblQuyenTruyCap
            // 
            this.lblQuyenTruyCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuyenTruyCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblQuyenTruyCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblQuyenTruyCap.Location = new System.Drawing.Point(440, 12);
            this.lblQuyenTruyCap.Name = "lblQuyenTruyCap";
            this.lblQuyenTruyCap.Size = new System.Drawing.Size(484, 20);
            this.lblQuyenTruyCap.TabIndex = 1;
            this.lblQuyenTruyCap.Text = "Quản trị viên • Quản lý tài khoản và phân quyền";
            this.lblQuyenTruyCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlDanhSachNguoiDung
            // 
            this.pnlDanhSachNguoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDanhSachNguoiDung.BackColor = System.Drawing.Color.White;
            this.pnlDanhSachNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDanhSachNguoiDung.Controls.Add(this.pnlChan);
            this.pnlDanhSachNguoiDung.Controls.Add(this.dgvNguoiDung);
            this.pnlDanhSachNguoiDung.Controls.Add(this.pnlThongTinDanhSach);
            this.pnlDanhSachNguoiDung.Controls.Add(this.pnlTimKiem);
            this.pnlDanhSachNguoiDung.Location = new System.Drawing.Point(10, 44);
            this.pnlDanhSachNguoiDung.Name = "pnlDanhSachNguoiDung";
            this.pnlDanhSachNguoiDung.Size = new System.Drawing.Size(920, 446);
            this.pnlDanhSachNguoiDung.TabIndex = 2;
            // 
            // pnlChan
            // 
            this.pnlChan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChan.Controls.Add(this.btnDoiQuyen);
            this.pnlChan.Controls.Add(this.btnDatLaiMatKhau);
            this.pnlChan.Controls.Add(this.btnKhoaMoKhoa);
            this.pnlChan.Controls.Add(this.lblTaiKhoanDaChon);
            this.pnlChan.Location = new System.Drawing.Point(0, 390);
            this.pnlChan.Name = "pnlChan";
            this.pnlChan.Size = new System.Drawing.Size(918, 54);
            this.pnlChan.TabIndex = 11;
            // 
            // btnDoiQuyen
            // 
            this.btnDoiQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoiQuyen.BackColor = System.Drawing.Color.White;
            this.btnDoiQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoiQuyen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDoiQuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiQuyen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDoiQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDoiQuyen.Location = new System.Drawing.Point(808, 12);
            this.btnDoiQuyen.Name = "btnDoiQuyen";
            this.btnDoiQuyen.Size = new System.Drawing.Size(96, 30);
            this.btnDoiQuyen.TabIndex = 15;
            this.btnDoiQuyen.Text = "Đổi quyền";
            this.btnDoiQuyen.UseVisualStyleBackColor = false;
            // 
            // btnDatLaiMatKhau
            // 
            this.btnDatLaiMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatLaiMatKhau.BackColor = System.Drawing.Color.White;
            this.btnDatLaiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatLaiMatKhau.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDatLaiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatLaiMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDatLaiMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDatLaiMatKhau.Location = new System.Drawing.Point(670, 12);
            this.btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            this.btnDatLaiMatKhau.Size = new System.Drawing.Size(130, 30);
            this.btnDatLaiMatKhau.TabIndex = 14;
            this.btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            this.btnDatLaiMatKhau.UseVisualStyleBackColor = false;
            // 
            // btnKhoaMoKhoa
            // 
            this.btnKhoaMoKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhoaMoKhoa.BackColor = System.Drawing.Color.White;
            this.btnKhoaMoKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhoaMoKhoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnKhoaMoKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoaMoKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKhoaMoKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnKhoaMoKhoa.Location = new System.Drawing.Point(582, 12);
            this.btnKhoaMoKhoa.Name = "btnKhoaMoKhoa";
            this.btnKhoaMoKhoa.Size = new System.Drawing.Size(80, 30);
            this.btnKhoaMoKhoa.TabIndex = 13;
            this.btnKhoaMoKhoa.Text = "Khóa";
            this.btnKhoaMoKhoa.UseVisualStyleBackColor = false;
            // 
            // lblTaiKhoanDaChon
            // 
            this.lblTaiKhoanDaChon.AutoSize = true;
            this.lblTaiKhoanDaChon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTaiKhoanDaChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTaiKhoanDaChon.Location = new System.Drawing.Point(14, 17);
            this.lblTaiKhoanDaChon.Name = "lblTaiKhoanDaChon";
            this.lblTaiKhoanDaChon.Size = new System.Drawing.Size(144, 20);
            this.lblTaiKhoanDaChon.TabIndex = 12;
            this.lblTaiKhoanDaChon.Text = "Chưa chọn tài khoản";
            // 
            // dgvNguoiDung
            // 
            this.dgvNguoiDung.AllowUserToAddRows = false;
            this.dgvNguoiDung.AllowUserToDeleteRows = false;
            this.dgvNguoiDung.AllowUserToResizeRows = false;
            this.dgvNguoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNguoiDung.BackgroundColor = System.Drawing.Color.White;
            this.dgvNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNguoiDung.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNguoiDung.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNguoiDung.ColumnHeadersHeight = 32;
            this.dgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNguoiDung.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNguoiDung.EnableHeadersVisualStyles = false;
            this.dgvNguoiDung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.dgvNguoiDung.Location = new System.Drawing.Point(0, 84);
            this.dgvNguoiDung.MultiSelect = false;
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.ReadOnly = true;
            this.dgvNguoiDung.RowHeadersVisible = false;
            this.dgvNguoiDung.RowHeadersWidth = 51;
            this.dgvNguoiDung.RowTemplate.Height = 32;
            this.dgvNguoiDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguoiDung.Size = new System.Drawing.Size(918, 306);
            this.dgvNguoiDung.TabIndex = 10;
            // 
            // pnlThongTinDanhSach
            // 
            this.pnlThongTinDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlThongTinDanhSach.Controls.Add(this.lblCheDo);
            this.pnlThongTinDanhSach.Controls.Add(this.lblSoLuong);
            this.pnlThongTinDanhSach.Location = new System.Drawing.Point(0, 54);
            this.pnlThongTinDanhSach.Name = "pnlThongTinDanhSach";
            this.pnlThongTinDanhSach.Size = new System.Drawing.Size(918, 30);
            this.pnlThongTinDanhSach.TabIndex = 7;
            // 
            // lblCheDo
            // 
            this.lblCheDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheDo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCheDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCheDo.Location = new System.Drawing.Point(404, 6);
            this.lblCheDo.Name = "lblCheDo";
            this.lblCheDo.Size = new System.Drawing.Size(500, 18);
            this.lblCheDo.TabIndex = 9;
            this.lblCheDo.Text = "Chỉ đọc • Chọn một tài khoản để thao tác";
            this.lblCheDo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoLuong.Location = new System.Drawing.Point(14, 6);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(87, 20);
            this.lblSoLuong.TabIndex = 8;
            this.lblSoLuong.Text = "0 tài khoản";
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimKiem.Controls.Add(this.btnTim);
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Controls.Add(this.lblTimKiem);
            this.pnlTimKiem.Location = new System.Drawing.Point(0, 0);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(918, 54);
            this.pnlTimKiem.TabIndex = 3;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.White;
            this.btnTim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnTim.Location = new System.Drawing.Point(456, 13);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 28);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.Location = new System.Drawing.Point(112, 14);
            this.txtTimKiem.MaxLength = 100;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(338, 29);
            this.txtTimKiem.TabIndex = 5;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTimKiem.Location = new System.Drawing.Point(14, 18);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(99, 20);
            this.lblTimKiem.TabIndex = 4;
            this.lblTimKiem.Text = "Tìm tài khoản";
            // 
            // frmNguoiDung
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(940, 500);
            this.Controls.Add(this.pnlDanhSachNguoiDung);
            this.Controls.Add(this.lblQuyenTruyCap);
            this.Controls.Add(this.lblQuanLyNguoiDung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNguoiDung";
            this.Text = "Quản lý người dùng";
            this.pnlDanhSachNguoiDung.ResumeLayout(false);
            this.pnlChan.ResumeLayout(false);
            this.pnlChan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.pnlThongTinDanhSach.ResumeLayout(false);
            this.pnlThongTinDanhSach.PerformLayout();
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuanLyNguoiDung;
        private System.Windows.Forms.Label lblQuyenTruyCap;
        private System.Windows.Forms.Panel pnlDanhSachNguoiDung;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Panel pnlThongTinDanhSach;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblCheDo;
        private System.Windows.Forms.DataGridView dgvNguoiDung;
        private System.Windows.Forms.Panel pnlChan;
        private System.Windows.Forms.Label lblTaiKhoanDaChon;
        private System.Windows.Forms.Button btnKhoaMoKhoa;
        private System.Windows.Forms.Button btnDatLaiMatKhau;
        private System.Windows.Forms.Button btnDoiQuyen;
    }
}
