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
            this.pnlNhomChi = new System.Windows.Forms.Panel();
            this.btnNgungSuDungNhom = new System.Windows.Forms.Button();
            this.btnSuaNhom = new System.Windows.Forms.Button();
            this.btnThemNhom = new System.Windows.Forms.Button();
            this.txtGhiChuNhom = new System.Windows.Forms.TextBox();
            this.lblGhiChuNhom = new System.Windows.Forms.Label();
            this.txtTenNhomChi = new System.Windows.Forms.TextBox();
            this.lblTenNhomChi = new System.Windows.Forms.Label();
            this.dgvNhomChi = new System.Windows.Forms.DataGridView();
            this.lblNhomChiTieu = new System.Windows.Forms.Label();
            this.pnlLoaiChi = new System.Windows.Forms.Panel();
            this.lblChiDoc = new System.Windows.Forms.Label();
            this.btnNgungSuDungLoai = new System.Windows.Forms.Button();
            this.btnSuaLoai = new System.Windows.Forms.Button();
            this.btnThemLoai = new System.Windows.Forms.Button();
            this.txtGhiChuLoai = new System.Windows.Forms.TextBox();
            this.lblGhiChuLoai = new System.Windows.Forms.Label();
            this.cboNhomChiKhoa = new System.Windows.Forms.ComboBox();
            this.lblNhomChiKhoa = new System.Windows.Forms.Label();
            this.txtTenLoaiChi = new System.Windows.Forms.TextBox();
            this.lblTenLoaiChi = new System.Windows.Forms.Label();
            this.dgvLoaiChi = new System.Windows.Forms.DataGridView();
            this.pnlNhomDangChon = new System.Windows.Forms.Panel();
            this.lblNhomDangChon = new System.Windows.Forms.Label();
            this.lblLoaiChiTieuTieuDe = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlNhomChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomChi)).BeginInit();
            this.pnlLoaiChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiChi)).BeginInit();
            this.pnlNhomDangChon.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(257, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Nhóm và loại chi tiêu";
            // 
            // pnlNhomChi
            // 
            this.pnlNhomChi.BackColor = System.Drawing.Color.White;
            this.pnlNhomChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNhomChi.Controls.Add(this.btnNgungSuDungNhom);
            this.pnlNhomChi.Controls.Add(this.btnSuaNhom);
            this.pnlNhomChi.Controls.Add(this.btnThemNhom);
            this.pnlNhomChi.Controls.Add(this.txtGhiChuNhom);
            this.pnlNhomChi.Controls.Add(this.lblGhiChuNhom);
            this.pnlNhomChi.Controls.Add(this.txtTenNhomChi);
            this.pnlNhomChi.Controls.Add(this.lblTenNhomChi);
            this.pnlNhomChi.Controls.Add(this.dgvNhomChi);
            this.pnlNhomChi.Controls.Add(this.lblNhomChiTieu);
            this.pnlNhomChi.Location = new System.Drawing.Point(24, 65);
            this.pnlNhomChi.Name = "pnlNhomChi";
            this.pnlNhomChi.Size = new System.Drawing.Size(380, 560);
            this.pnlNhomChi.TabIndex = 1;
            // 
            // btnNgungSuDungNhom
            // 
            this.btnNgungSuDungNhom.BackColor = System.Drawing.Color.White;
            this.btnNgungSuDungNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNgungSuDungNhom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNgungSuDungNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNgungSuDungNhom.Location = new System.Drawing.Point(16, 502);
            this.btnNgungSuDungNhom.Name = "btnNgungSuDungNhom";
            this.btnNgungSuDungNhom.Size = new System.Drawing.Size(345, 38);
            this.btnNgungSuDungNhom.TabIndex = 8;
            this.btnNgungSuDungNhom.Text = "Ngừng sử dụng";
            this.btnNgungSuDungNhom.UseVisualStyleBackColor = false;
            // 
            // btnSuaNhom
            // 
            this.btnSuaNhom.BackColor = System.Drawing.Color.White;
            this.btnSuaNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaNhom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSuaNhom.Location = new System.Drawing.Point(100, 452);
            this.btnSuaNhom.Name = "btnSuaNhom";
            this.btnSuaNhom.Size = new System.Drawing.Size(80, 38);
            this.btnSuaNhom.TabIndex = 7;
            this.btnSuaNhom.Text = "Sửa";
            this.btnSuaNhom.UseVisualStyleBackColor = false;
            // 
            // btnThemNhom
            // 
            this.btnThemNhom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThemNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNhom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNhom.ForeColor = System.Drawing.Color.White;
            this.btnThemNhom.Location = new System.Drawing.Point(16, 452);
            this.btnThemNhom.Name = "btnThemNhom";
            this.btnThemNhom.Size = new System.Drawing.Size(78, 38);
            this.btnThemNhom.TabIndex = 6;
            this.btnThemNhom.Text = "Thêm";
            this.btnThemNhom.UseVisualStyleBackColor = false;
            // 
            // txtGhiChuNhom
            // 
            this.txtGhiChuNhom.Location = new System.Drawing.Point(16, 372);
            this.txtGhiChuNhom.Multiline = true;
            this.txtGhiChuNhom.Name = "txtGhiChuNhom";
            this.txtGhiChuNhom.Size = new System.Drawing.Size(345, 65);
            this.txtGhiChuNhom.TabIndex = 5;
            // 
            // lblGhiChuNhom
            // 
            this.lblGhiChuNhom.AutoSize = true;
            this.lblGhiChuNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGhiChuNhom.Location = new System.Drawing.Point(16, 348);
            this.lblGhiChuNhom.Name = "lblGhiChuNhom";
            this.lblGhiChuNhom.Size = new System.Drawing.Size(69, 23);
            this.lblGhiChuNhom.TabIndex = 4;
            this.lblGhiChuNhom.Text = "Ghi chú";
            // 
            // txtTenNhomChi
            // 
            this.txtTenNhomChi.Location = new System.Drawing.Point(16, 310);
            this.txtTenNhomChi.Name = "txtTenNhomChi";
            this.txtTenNhomChi.Size = new System.Drawing.Size(345, 30);
            this.txtTenNhomChi.TabIndex = 3;
            // 
            // lblTenNhomChi
            // 
            this.lblTenNhomChi.AutoSize = true;
            this.lblTenNhomChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTenNhomChi.Location = new System.Drawing.Point(16, 286);
            this.lblTenNhomChi.Name = "lblTenNhomChi";
            this.lblTenNhomChi.Size = new System.Drawing.Size(113, 23);
            this.lblTenNhomChi.TabIndex = 2;
            this.lblTenNhomChi.Text = "Tên nhóm chi";
            // 
            // dgvNhomChi
            // 
            this.dgvNhomChi.AllowUserToAddRows = false;
            this.dgvNhomChi.AllowUserToDeleteRows = false;
            this.dgvNhomChi.AllowUserToResizeRows = false;
            this.dgvNhomChi.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhomChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNhomChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhomChi.EnableHeadersVisualStyles = false;
            this.dgvNhomChi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvNhomChi.Location = new System.Drawing.Point(16, 48);
            this.dgvNhomChi.MultiSelect = false;
            this.dgvNhomChi.Name = "dgvNhomChi";
            this.dgvNhomChi.ReadOnly = true;
            this.dgvNhomChi.RowHeadersVisible = false;
            this.dgvNhomChi.RowHeadersWidth = 51;
            this.dgvNhomChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhomChi.Size = new System.Drawing.Size(345, 225);
            this.dgvNhomChi.TabIndex = 1;
            // 
            // lblNhomChiTieu
            // 
            this.lblNhomChiTieu.AutoSize = true;
            this.lblNhomChiTieu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhomChiTieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNhomChiTieu.Location = new System.Drawing.Point(104, -1);
            this.lblNhomChiTieu.Name = "lblNhomChiTieu";
            this.lblNhomChiTieu.Size = new System.Drawing.Size(136, 25);
            this.lblNhomChiTieu.TabIndex = 0;
            this.lblNhomChiTieu.Text = "Nhóm chi tiêu";
            // 
            // pnlLoaiChi
            // 
            this.pnlLoaiChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLoaiChi.BackColor = System.Drawing.Color.White;
            this.pnlLoaiChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoaiChi.Controls.Add(this.lblChiDoc);
            this.pnlLoaiChi.Controls.Add(this.btnNgungSuDungLoai);
            this.pnlLoaiChi.Controls.Add(this.btnSuaLoai);
            this.pnlLoaiChi.Controls.Add(this.btnThemLoai);
            this.pnlLoaiChi.Controls.Add(this.txtGhiChuLoai);
            this.pnlLoaiChi.Controls.Add(this.lblGhiChuLoai);
            this.pnlLoaiChi.Controls.Add(this.cboNhomChiKhoa);
            this.pnlLoaiChi.Controls.Add(this.lblNhomChiKhoa);
            this.pnlLoaiChi.Controls.Add(this.txtTenLoaiChi);
            this.pnlLoaiChi.Controls.Add(this.lblTenLoaiChi);
            this.pnlLoaiChi.Controls.Add(this.dgvLoaiChi);
            this.pnlLoaiChi.Controls.Add(this.pnlNhomDangChon);
            this.pnlLoaiChi.Controls.Add(this.lblLoaiChiTieuTieuDe);
            this.pnlLoaiChi.Location = new System.Drawing.Point(420, 65);
            this.pnlLoaiChi.Name = "pnlLoaiChi";
            this.pnlLoaiChi.Size = new System.Drawing.Size(730, 560);
            this.pnlLoaiChi.TabIndex = 2;
            // 
            // lblChiDoc
            // 
            this.lblChiDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChiDoc.AutoSize = true;
            this.lblChiDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChiDoc.Location = new System.Drawing.Point(676, 16);
            this.lblChiDoc.Name = "lblChiDoc";
            this.lblChiDoc.Size = new System.Drawing.Size(68, 23);
            this.lblChiDoc.TabIndex = 12;
            this.lblChiDoc.Text = "Chỉ đọc";
            // 
            // btnNgungSuDungLoai
            // 
            this.btnNgungSuDungLoai.BackColor = System.Drawing.Color.White;
            this.btnNgungSuDungLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNgungSuDungLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNgungSuDungLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNgungSuDungLoai.Location = new System.Drawing.Point(16, 502);
            this.btnNgungSuDungLoai.Name = "btnNgungSuDungLoai";
            this.btnNgungSuDungLoai.Size = new System.Drawing.Size(345, 38);
            this.btnNgungSuDungLoai.TabIndex = 11;
            this.btnNgungSuDungLoai.Text = "Ngừng sử dụng";
            this.btnNgungSuDungLoai.UseVisualStyleBackColor = false;
            // 
            // btnSuaLoai
            // 
            this.btnSuaLoai.BackColor = System.Drawing.Color.White;
            this.btnSuaLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSuaLoai.Location = new System.Drawing.Point(100, 452);
            this.btnSuaLoai.Name = "btnSuaLoai";
            this.btnSuaLoai.Size = new System.Drawing.Size(80, 38);
            this.btnSuaLoai.TabIndex = 10;
            this.btnSuaLoai.Text = "Sửa";
            this.btnSuaLoai.UseVisualStyleBackColor = false;
            // 
            // btnThemLoai
            // 
            this.btnThemLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThemLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemLoai.ForeColor = System.Drawing.Color.White;
            this.btnThemLoai.Location = new System.Drawing.Point(16, 452);
            this.btnThemLoai.Name = "btnThemLoai";
            this.btnThemLoai.Size = new System.Drawing.Size(78, 38);
            this.btnThemLoai.TabIndex = 9;
            this.btnThemLoai.Text = "Thêm";
            this.btnThemLoai.UseVisualStyleBackColor = false;
            // 
            // txtGhiChuLoai
            // 
            this.txtGhiChuLoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChuLoai.Location = new System.Drawing.Point(16, 372);
            this.txtGhiChuLoai.Multiline = true;
            this.txtGhiChuLoai.Name = "txtGhiChuLoai";
            this.txtGhiChuLoai.Size = new System.Drawing.Size(698, 65);
            this.txtGhiChuLoai.TabIndex = 8;
            // 
            // lblGhiChuLoai
            // 
            this.lblGhiChuLoai.AutoSize = true;
            this.lblGhiChuLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGhiChuLoai.Location = new System.Drawing.Point(16, 348);
            this.lblGhiChuLoai.Name = "lblGhiChuLoai";
            this.lblGhiChuLoai.Size = new System.Drawing.Size(69, 23);
            this.lblGhiChuLoai.TabIndex = 7;
            this.lblGhiChuLoai.Text = "Ghi chú";
            // 
            // cboNhomChiKhoa
            // 
            this.cboNhomChiKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNhomChiKhoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.cboNhomChiKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboNhomChiKhoa.Enabled = false;
            this.cboNhomChiKhoa.Location = new System.Drawing.Point(375, 310);
            this.cboNhomChiKhoa.Name = "cboNhomChiKhoa";
            this.cboNhomChiKhoa.Size = new System.Drawing.Size(339, 27);
            this.cboNhomChiKhoa.TabIndex = 6;
            // 
            // lblNhomChiKhoa
            // 
            this.lblNhomChiKhoa.AutoSize = true;
            this.lblNhomChiKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNhomChiKhoa.Location = new System.Drawing.Point(375, 286);
            this.lblNhomChiKhoa.Name = "lblNhomChiKhoa";
            this.lblNhomChiKhoa.Size = new System.Drawing.Size(134, 23);
            this.lblNhomChiKhoa.TabIndex = 5;
            this.lblNhomChiKhoa.Text = "Thuộc nhóm chi";
            // 
            // txtTenLoaiChi
            // 
            this.txtTenLoaiChi.Location = new System.Drawing.Point(16, 310);
            this.txtTenLoaiChi.Name = "txtTenLoaiChi";
            this.txtTenLoaiChi.Size = new System.Drawing.Size(345, 30);
            this.txtTenLoaiChi.TabIndex = 4;
            // 
            // lblTenLoaiChi
            // 
            this.lblTenLoaiChi.AutoSize = true;
            this.lblTenLoaiChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTenLoaiChi.Location = new System.Drawing.Point(16, 286);
            this.lblTenLoaiChi.Name = "lblTenLoaiChi";
            this.lblTenLoaiChi.Size = new System.Drawing.Size(95, 23);
            this.lblTenLoaiChi.TabIndex = 3;
            this.lblTenLoaiChi.Text = "Tên loại chi";
            // 
            // dgvLoaiChi
            // 
            this.dgvLoaiChi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoaiChi.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoaiChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoaiChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiChi.EnableHeadersVisualStyles = false;
            this.dgvLoaiChi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvLoaiChi.Location = new System.Drawing.Point(16, 95);
            this.dgvLoaiChi.MultiSelect = false;
            this.dgvLoaiChi.Name = "dgvLoaiChi";
            this.dgvLoaiChi.ReadOnly = true;
            this.dgvLoaiChi.RowHeadersVisible = false;
            this.dgvLoaiChi.RowHeadersWidth = 51;
            this.dgvLoaiChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiChi.Size = new System.Drawing.Size(698, 180);
            this.dgvLoaiChi.TabIndex = 2;
            // 
            // pnlNhomDangChon
            // 
            this.pnlNhomDangChon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNhomDangChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlNhomDangChon.Controls.Add(this.lblNhomDangChon);
            this.pnlNhomDangChon.Location = new System.Drawing.Point(16, 48);
            this.pnlNhomDangChon.Name = "pnlNhomDangChon";
            this.pnlNhomDangChon.Size = new System.Drawing.Size(698, 38);
            this.pnlNhomDangChon.TabIndex = 1;
            // 
            // lblNhomDangChon
            // 
            this.lblNhomDangChon.AutoSize = true;
            this.lblNhomDangChon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhomDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblNhomDangChon.Location = new System.Drawing.Point(12, 8);
            this.lblNhomDangChon.Name = "lblNhomDangChon";
            this.lblNhomDangChon.Size = new System.Drawing.Size(274, 21);
            this.lblNhomDangChon.TabIndex = 0;
            this.lblNhomDangChon.Text = "Nhóm đang chọn: Ăn uống • 4 loại chi";
            // 
            // lblLoaiChiTieuTieuDe
            // 
            this.lblLoaiChiTieuTieuDe.AutoSize = true;
            this.lblLoaiChiTieuTieuDe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiChiTieuTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblLoaiChiTieuTieuDe.Location = new System.Drawing.Point(234, -1);
            this.lblLoaiChiTieuTieuDe.Name = "lblLoaiChiTieuTieuDe";
            this.lblLoaiChiTieuTieuDe.Size = new System.Drawing.Size(275, 25);
            this.lblLoaiChiTieuTieuDe.TabIndex = 0;
            this.lblLoaiChiTieuTieuDe.Text = "Loại chi thuộc nhóm Ăn uống";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblThongBao.Location = new System.Drawing.Point(24, 635);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 23);
            this.lblThongBao.TabIndex = 0;
            this.lblThongBao.Visible = false;
            // 
            // frmLoaiChiTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1175, 675);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.pnlLoaiChi);
            this.Controls.Add(this.pnlNhomChi);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoaiChiTieu";
            this.Text = "Nhóm và loại chi tiêu";
            this.pnlNhomChi.ResumeLayout(false);
            this.pnlNhomChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomChi)).EndInit();
            this.pnlLoaiChi.ResumeLayout(false);
            this.pnlLoaiChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiChi)).EndInit();
            this.pnlNhomDangChon.ResumeLayout(false);
            this.pnlNhomDangChon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlNhomChi;
        private System.Windows.Forms.Label lblNhomChiTieu;
        private System.Windows.Forms.DataGridView dgvNhomChi;
        private System.Windows.Forms.Label lblTenNhomChi;
        private System.Windows.Forms.TextBox txtTenNhomChi;
        private System.Windows.Forms.Label lblGhiChuNhom;
        private System.Windows.Forms.TextBox txtGhiChuNhom;
        private System.Windows.Forms.Button btnThemNhom;
        private System.Windows.Forms.Button btnSuaNhom;
        private System.Windows.Forms.Button btnNgungSuDungNhom;
        private System.Windows.Forms.Panel pnlLoaiChi;
        private System.Windows.Forms.Label lblLoaiChiTieuTieuDe;
        private System.Windows.Forms.Panel pnlNhomDangChon;
        private System.Windows.Forms.Label lblNhomDangChon;
        private System.Windows.Forms.DataGridView dgvLoaiChi;
        private System.Windows.Forms.Label lblTenLoaiChi;
        private System.Windows.Forms.TextBox txtTenLoaiChi;
        private System.Windows.Forms.Label lblNhomChiKhoa;
        private System.Windows.Forms.ComboBox cboNhomChiKhoa;
        private System.Windows.Forms.Label lblGhiChuLoai;
        private System.Windows.Forms.TextBox txtGhiChuLoai;
        private System.Windows.Forms.Button btnThemLoai;
        private System.Windows.Forms.Button btnSuaLoai;
        private System.Windows.Forms.Button btnNgungSuDungLoai;
        private System.Windows.Forms.Label lblChiDoc;
        private System.Windows.Forms.Label lblThongBao;
    }
}