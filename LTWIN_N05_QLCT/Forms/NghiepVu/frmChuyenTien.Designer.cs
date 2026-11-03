namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    partial class frmChuyenTien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblSoGiaoDich = new System.Windows.Forms.Label();
            this.dgvLichSuChuyenTien = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViNguon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLichSuChuyenTien = new System.Windows.Forms.Label();
            this.pnlChuyenTien2 = new System.Windows.Forms.Panel();
            this.lblChuyenNoiBoKhongTinhVao = new System.Windows.Forms.Label();
            this.lblSauKhiChuyenDuKienVietcombank = new System.Windows.Forms.Label();
            this.pnlChuyenTien = new System.Windows.Forms.Panel();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnChuyenTien = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.cboViDich = new System.Windows.Forms.ComboBox();
            this.lblViDich = new System.Windows.Forms.Label();
            this.cboViNguon = new System.Windows.Forms.ComboBox();
            this.lblViNguon = new System.Windows.Forms.Label();
            this.lblThongTinChuyenTien = new System.Windows.Forms.Label();
            this.lblChuyenTienGiuaCacVi = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuChuyenTien)).BeginInit();
            this.pnlChuyenTien2.SuspendLayout();
            this.pnlChuyenTien.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.lblSoGiaoDich);
            this.pnlMain.Controls.Add(this.dgvLichSuChuyenTien);
            this.pnlMain.Controls.Add(this.lblLichSuChuyenTien);
            this.pnlMain.Controls.Add(this.pnlChuyenTien2);
            this.pnlMain.Controls.Add(this.pnlChuyenTien);
            this.pnlMain.Controls.Add(this.lblThongTinChuyenTien);
            this.pnlMain.Controls.Add(this.lblChuyenTienGiuaCacVi);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlMain.Size = new System.Drawing.Size(1060, 600);
            this.pnlMain.TabIndex = 0;
            // 
            // lblSoGiaoDich
            // 
            this.lblSoGiaoDich.AutoSize = true;
            this.lblSoGiaoDich.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSoGiaoDich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblSoGiaoDich.Location = new System.Drawing.Point(20, 524);
            this.lblSoGiaoDich.Name = "lblSoGiaoDich";
            this.lblSoGiaoDich.Size = new System.Drawing.Size(325, 20);
            this.lblSoGiaoDich.TabIndex = 6;
            this.lblSoGiaoDich.Text = "Chỉ đọc • 0 giao dịch • Tổng số tiền đã chuyển: 0 đ";
            // 
            // dgvLichSuChuyenTien
            // 
            this.dgvLichSuChuyenTien.AllowUserToAddRows = false;
            this.dgvLichSuChuyenTien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLichSuChuyenTien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichSuChuyenTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLichSuChuyenTien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuChuyenTien.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSuChuyenTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvLichSuChuyenTien.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLichSuChuyenTien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLichSuChuyenTien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichSuChuyenTien.ColumnHeadersHeight = 36;
            this.dgvLichSuChuyenTien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLichSuChuyenTien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgay,
            this.colViNguon,
            this.colViDich,
            this.colSoTien,
            this.colGhiChu});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLichSuChuyenTien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLichSuChuyenTien.EnableHeadersVisualStyles = false;
            this.dgvLichSuChuyenTien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvLichSuChuyenTien.Location = new System.Drawing.Point(20, 306);
            this.dgvLichSuChuyenTien.Name = "dgvLichSuChuyenTien";
            this.dgvLichSuChuyenTien.ReadOnly = true;
            this.dgvLichSuChuyenTien.RowHeadersVisible = false;
            this.dgvLichSuChuyenTien.RowHeadersWidth = 51;
            this.dgvLichSuChuyenTien.RowTemplate.Height = 32;
            this.dgvLichSuChuyenTien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuChuyenTien.Size = new System.Drawing.Size(1005, 210);
            this.dgvLichSuChuyenTien.TabIndex = 5;
            // 
            // colNgay
            // 
            this.colNgay.FillWeight = 85F;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.MinimumWidth = 6;
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // 
            // colViNguon
            // 
            this.colViNguon.FillWeight = 95F;
            this.colViNguon.HeaderText = "Ví nguồn";
            this.colViNguon.MinimumWidth = 6;
            this.colViNguon.Name = "colViNguon";
            this.colViNguon.ReadOnly = true;
            // 
            // colViDich
            // 
            this.colViDich.FillWeight = 95F;
            this.colViDich.HeaderText = "Ví đích";
            this.colViDich.MinimumWidth = 6;
            this.colViDich.Name = "colViDich";
            this.colViDich.ReadOnly = true;
            // 
            // colSoTien
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.colSoTien.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSoTien.FillWeight = 95F;
            this.colSoTien.HeaderText = "Số tiền";
            this.colSoTien.MinimumWidth = 6;
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.ReadOnly = true;
            // 
            // colGhiChu
            // 
            this.colGhiChu.FillWeight = 160F;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.MinimumWidth = 6;
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            // 
            // lblLichSuChuyenTien
            // 
            this.lblLichSuChuyenTien.AutoSize = true;
            this.lblLichSuChuyenTien.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblLichSuChuyenTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblLichSuChuyenTien.Location = new System.Drawing.Point(20, 282);
            this.lblLichSuChuyenTien.Name = "lblLichSuChuyenTien";
            this.lblLichSuChuyenTien.Size = new System.Drawing.Size(170, 24);
            this.lblLichSuChuyenTien.TabIndex = 4;
            this.lblLichSuChuyenTien.Text = "Lịch sử chuyển tiền";
            // 
            // pnlChuyenTien2
            // 
            this.pnlChuyenTien2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChuyenTien2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(253)))));
            this.pnlChuyenTien2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChuyenTien2.Controls.Add(this.lblChuyenNoiBoKhongTinhVao);
            this.pnlChuyenTien2.Controls.Add(this.lblSauKhiChuyenDuKienVietcombank);
            this.pnlChuyenTien2.Location = new System.Drawing.Point(20, 222);
            this.pnlChuyenTien2.Name = "pnlChuyenTien2";
            this.pnlChuyenTien2.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.pnlChuyenTien2.Size = new System.Drawing.Size(1005, 50);
            this.pnlChuyenTien2.TabIndex = 3;
            // 
            // lblChuyenNoiBoKhongTinhVao
            // 
            this.lblChuyenNoiBoKhongTinhVao.AutoSize = true;
            this.lblChuyenNoiBoKhongTinhVao.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblChuyenNoiBoKhongTinhVao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblChuyenNoiBoKhongTinhVao.Location = new System.Drawing.Point(12, 26);
            this.lblChuyenNoiBoKhongTinhVao.Name = "lblChuyenNoiBoKhongTinhVao";
            this.lblChuyenNoiBoKhongTinhVao.Size = new System.Drawing.Size(262, 20);
            this.lblChuyenNoiBoKhongTinhVao.TabIndex = 1;
            this.lblChuyenNoiBoKhongTinhVao.Text = "Chuyển nội bộ không tính vào thu – chi.";
            // 
            // lblSauKhiChuyenDuKienVietcombank
            // 
            this.lblSauKhiChuyenDuKienVietcombank.AutoSize = true;
            this.lblSauKhiChuyenDuKienVietcombank.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSauKhiChuyenDuKienVietcombank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblSauKhiChuyenDuKienVietcombank.Location = new System.Drawing.Point(12, 6);
            this.lblSauKhiChuyenDuKienVietcombank.Name = "lblSauKhiChuyenDuKienVietcombank";
            this.lblSauKhiChuyenDuKienVietcombank.Size = new System.Drawing.Size(193, 20);
            this.lblSauKhiChuyenDuKienVietcombank.TabIndex = 0;
            this.lblSauKhiChuyenDuKienVietcombank.Text = "Sau khi chuyển dự kiến: —";
            // 
            // pnlChuyenTien
            // 
            this.pnlChuyenTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChuyenTien.BackColor = System.Drawing.Color.White;
            this.pnlChuyenTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChuyenTien.Controls.Add(this.btnMoi);
            this.pnlChuyenTien.Controls.Add(this.btnChuyenTien);
            this.pnlChuyenTien.Controls.Add(this.txtGhiChu);
            this.pnlChuyenTien.Controls.Add(this.lblGhiChu);
            this.pnlChuyenTien.Controls.Add(this.txtSoTien);
            this.pnlChuyenTien.Controls.Add(this.lblSoTien);
            this.pnlChuyenTien.Controls.Add(this.dtpNgay);
            this.pnlChuyenTien.Controls.Add(this.lblNgay);
            this.pnlChuyenTien.Controls.Add(this.cboViDich);
            this.pnlChuyenTien.Controls.Add(this.lblViDich);
            this.pnlChuyenTien.Controls.Add(this.cboViNguon);
            this.pnlChuyenTien.Controls.Add(this.lblViNguon);
            this.pnlChuyenTien.Location = new System.Drawing.Point(20, 72);
            this.pnlChuyenTien.Name = "pnlChuyenTien";
            this.pnlChuyenTien.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlChuyenTien.Size = new System.Drawing.Size(1005, 140);
            this.pnlChuyenTien.TabIndex = 2;
            // 
            // btnMoi
            // 
            this.btnMoi.BackColor = System.Drawing.Color.White;
            this.btnMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnMoi.Location = new System.Drawing.Point(774, 86);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(80, 30);
            this.btnMoi.TabIndex = 11;
            this.btnMoi.Text = "Mới";
            this.btnMoi.UseVisualStyleBackColor = false;
            // 
            // btnChuyenTien
            // 
            this.btnChuyenTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnChuyenTien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChuyenTien.FlatAppearance.BorderSize = 0;
            this.btnChuyenTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnChuyenTien.ForeColor = System.Drawing.Color.White;
            this.btnChuyenTien.Location = new System.Drawing.Point(644, 86);
            this.btnChuyenTien.Name = "btnChuyenTien";
            this.btnChuyenTien.Size = new System.Drawing.Size(120, 30);
            this.btnChuyenTien.TabIndex = 10;
            this.btnChuyenTien.Text = "Chuyển tiền";
            this.btnChuyenTien.UseVisualStyleBackColor = false;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGhiChu.Location = new System.Drawing.Point(16, 90);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(612, 29);
            this.txtGhiChu.TabIndex = 9;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblGhiChu.Location = new System.Drawing.Point(16, 70);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(58, 20);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoTien.Location = new System.Drawing.Point(644, 32);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(160, 29);
            this.txtSoTien.TabIndex = 7;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblSoTien.Location = new System.Drawing.Point(644, 12);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(77, 20);
            this.lblSoTien.TabIndex = 6;
            this.lblSoTien.Text = "Số tiền (đ)";
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(488, 32);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(140, 29);
            this.dtpNgay.TabIndex = 5;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblNgay.Location = new System.Drawing.Point(488, 12);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(95, 20);
            this.lblNgay.TabIndex = 4;
            this.lblNgay.Text = "Ngày chuyển";
            // 
            // cboViDich
            // 
            this.cboViDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViDich.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboViDich.FormattingEnabled = true;
            this.cboViDich.Location = new System.Drawing.Point(252, 32);
            this.cboViDich.Name = "cboViDich";
            this.cboViDich.Size = new System.Drawing.Size(220, 29);
            this.cboViDich.TabIndex = 3;
            // 
            // lblViDich
            // 
            this.lblViDich.AutoSize = true;
            this.lblViDich.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViDich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblViDich.Location = new System.Drawing.Point(252, 12);
            this.lblViDich.Name = "lblViDich";
            this.lblViDich.Size = new System.Drawing.Size(53, 20);
            this.lblViDich.TabIndex = 2;
            this.lblViDich.Text = "Ví đích";
            // 
            // cboViNguon
            // 
            this.cboViNguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViNguon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboViNguon.FormattingEnabled = true;
            this.cboViNguon.Location = new System.Drawing.Point(16, 32);
            this.cboViNguon.Name = "cboViNguon";
            this.cboViNguon.Size = new System.Drawing.Size(220, 29);
            this.cboViNguon.TabIndex = 1;
            // 
            // lblViNguon
            // 
            this.lblViNguon.AutoSize = true;
            this.lblViNguon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViNguon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblViNguon.Location = new System.Drawing.Point(16, 12);
            this.lblViNguon.Name = "lblViNguon";
            this.lblViNguon.Size = new System.Drawing.Size(69, 20);
            this.lblViNguon.TabIndex = 0;
            this.lblViNguon.Text = "Ví nguồn";
            // 
            // lblThongTinChuyenTien
            // 
            this.lblThongTinChuyenTien.AutoSize = true;
            this.lblThongTinChuyenTien.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblThongTinChuyenTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblThongTinChuyenTien.Location = new System.Drawing.Point(20, 48);
            this.lblThongTinChuyenTien.Name = "lblThongTinChuyenTien";
            this.lblThongTinChuyenTien.Size = new System.Drawing.Size(199, 24);
            this.lblThongTinChuyenTien.TabIndex = 1;
            this.lblThongTinChuyenTien.Text = "Thông tin chuyển tiền";
            // 
            // lblChuyenTienGiuaCacVi
            // 
            this.lblChuyenTienGiuaCacVi.AutoSize = true;
            this.lblChuyenTienGiuaCacVi.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblChuyenTienGiuaCacVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblChuyenTienGiuaCacVi.Location = new System.Drawing.Point(20, 12);
            this.lblChuyenTienGiuaCacVi.Name = "lblChuyenTienGiuaCacVi";
            this.lblChuyenTienGiuaCacVi.Size = new System.Drawing.Size(287, 35);
            this.lblChuyenTienGiuaCacVi.TabIndex = 0;
            this.lblChuyenTienGiuaCacVi.Text = "Chuyển tiền giữa các ví";
            // 
            // frmChuyenTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 600);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmChuyenTien";
            this.Text = "Quản Lý Chi Tiêu — Chuyển tiền giữa các ví";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuChuyenTien)).EndInit();
            this.pnlChuyenTien2.ResumeLayout(false);
            this.pnlChuyenTien2.PerformLayout();
            this.pnlChuyenTien.ResumeLayout(false);
            this.pnlChuyenTien.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblChuyenTienGiuaCacVi;
        private System.Windows.Forms.Label lblThongTinChuyenTien;
        private System.Windows.Forms.Panel pnlChuyenTien;
        private System.Windows.Forms.Label lblViNguon;
        private System.Windows.Forms.ComboBox cboViNguon;
        private System.Windows.Forms.Label lblViDich;
        private System.Windows.Forms.ComboBox cboViDich;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnChuyenTien;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Panel pnlChuyenTien2;
        private System.Windows.Forms.Label lblSauKhiChuyenDuKienVietcombank;
        private System.Windows.Forms.Label lblChuyenNoiBoKhongTinhVao;
        private System.Windows.Forms.Label lblLichSuChuyenTien;
        private System.Windows.Forms.DataGridView dgvLichSuChuyenTien;
        private System.Windows.Forms.Label lblSoGiaoDich;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViNguon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViDich;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}
