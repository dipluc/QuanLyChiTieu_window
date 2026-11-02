using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    partial class frmNganSach
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
            this.pnlMain = new System.Windows.Forms.Panel();

            // Top Section
            this.pnlTopSection = new System.Windows.Forms.Panel();
            this.lblNganSach = new System.Windows.Forms.Label();
            this.lblThang2 = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnDatHanMuc = new System.Windows.Forms.Button();
            this.btnSaoChep = new System.Windows.Forms.Button();
            this.lblThang102026DuLieuDen = new System.Windows.Forms.Label();
            this.lblChonDanhMucDatHanMucRoiNhanDat = new System.Windows.Forms.Label();

            // Summary Cards
            this.pnlTheTongHop = new System.Windows.Forms.Panel();
            this.lblTongHanMuc = new System.Windows.Forms.Label();
            this.lblTongHanMuc2 = new System.Windows.Forms.Label();
            this.lblSoDanhMucDaDat = new System.Windows.Forms.Label();

            this.pnlTheTongHop2 = new System.Windows.Forms.Panel();
            this.lblDaChi = new System.Windows.Forms.Label();
            this.lblDaChi2 = new System.Windows.Forms.Label();
            this.lblPhanTramTongHanMuc = new System.Windows.Forms.Label();

            this.pnlTheTongHop3 = new System.Windows.Forms.Panel();
            this.lblConLai = new System.Windows.Forms.Label();
            this.lblConLai2 = new System.Windows.Forms.Label();
            this.lblNganSachThang102026 = new System.Windows.Forms.Label();

            // Budget By Category
            this.pnlNganSachDanhMuc = new System.Windows.Forms.Panel();
            this.lblLoaiChi = new System.Windows.Forms.Label();
            this.lblDaChiHanMuc = new System.Windows.Forms.Label();
            this.lblMucSuDung = new System.Windows.Forms.Label();
            this.lblConLai3 = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();

            // Category rows
            this.lblNhaO = new System.Windows.Forms.Label();
            this.lblNhaO2 = new System.Windows.Forms.Label();
            this.prgNhaO = new System.Windows.Forms.ProgressBar();
            this.lblTyLe = new System.Windows.Forms.Label();
            this.lblNhaO3 = new System.Windows.Forms.Label();
            this.lblDaChamHanMuc = new System.Windows.Forms.Label();

            this.lblAnUong = new System.Windows.Forms.Label();
            this.lblAnUong2 = new System.Windows.Forms.Label();
            this.prgAnUong = new System.Windows.Forms.ProgressBar();
            this.lblTyLe2 = new System.Windows.Forms.Label();
            this.lblAnUong3 = new System.Windows.Forms.Label();
            this.lblSapDatHanMuc = new System.Windows.Forms.Label();

            this.lblDiChuyen = new System.Windows.Forms.Label();
            this.lblDiChuyen2 = new System.Windows.Forms.Label();
            this.prgDiChuyen = new System.Windows.Forms.ProgressBar();
            this.lblTyLe3 = new System.Windows.Forms.Label();
            this.lblDiChuyen3 = new System.Windows.Forms.Label();
            this.lblVuotHanMuc = new System.Windows.Forms.Label();

            this.lblMuaSam = new System.Windows.Forms.Label();
            this.lblMuaSam2 = new System.Windows.Forms.Label();
            this.prgMuaSam = new System.Windows.Forms.ProgressBar();
            this.lblTyLe4 = new System.Windows.Forms.Label();
            this.lblMuaSam3 = new System.Windows.Forms.Label();
            this.lblTrongHanMuc = new System.Windows.Forms.Label();

            this.lblKhac = new System.Windows.Forms.Label();
            this.lblKhac2 = new System.Windows.Forms.Label();
            this.prgKhac = new System.Windows.Forms.ProgressBar();
            this.lblTyLe5 = new System.Windows.Forms.Label();
            this.lblKhac3 = new System.Windows.Forms.Label();
            this.lblChuaDatHanMuc = new System.Windows.Forms.Label();

            this.lblYTe = new System.Windows.Forms.Label();
            this.lblYTe2 = new System.Windows.Forms.Label();
            this.prgYTe = new System.Windows.Forms.ProgressBar();
            this.lblTyLe6 = new System.Windows.Forms.Label();
            this.lblYTe3 = new System.Windows.Forms.Label();
            this.lblTrangThaiYTe = new System.Windows.Forms.Label();

            // Legend
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.pnlGreenSquare = new System.Windows.Forms.Panel();
            this.lblDuoi80 = new System.Windows.Forms.Label();
            this.pnlOrangeSquare = new System.Windows.Forms.Panel();
            this.lblTu80DenDuoi100 = new System.Windows.Forms.Label();
            this.pnlRedSquare = new System.Windows.Forms.Panel();
            this.lblTu100TroLen = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ════════════════════════════════════════════════
            // pnlMain (Outer Scrollable Container)
            // ════════════════════════════════════════════════
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlMain.Controls.Add(this.pnlTopSection);
            this.pnlMain.Controls.Add(this.pnlTheTongHop);
            this.pnlMain.Controls.Add(this.pnlTheTongHop2);
            this.pnlMain.Controls.Add(this.pnlTheTongHop3);
            this.pnlMain.Controls.Add(this.pnlNganSachDanhMuc);
            this.pnlMain.Controls.Add(this.pnlLegend);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(1060, 600);
            this.pnlMain.TabIndex = 0;

            // ───────────────────────────────────────────────
            // pnlTopSection
            // ───────────────────────────────────────────────
            this.pnlTopSection.BackColor = System.Drawing.Color.White;
            this.pnlTopSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopSection.Controls.Add(this.lblNganSach);
            this.pnlTopSection.Controls.Add(this.lblThang2);
            this.pnlTopSection.Controls.Add(this.cboThang);
            this.pnlTopSection.Controls.Add(this.lblNam);
            this.pnlTopSection.Controls.Add(this.cboNam);
            this.pnlTopSection.Controls.Add(this.btnXem);
            this.pnlTopSection.Controls.Add(this.btnDatHanMuc);
            this.pnlTopSection.Controls.Add(this.btnSaoChep);
            this.pnlTopSection.Controls.Add(this.lblThang102026DuLieuDen);
            this.pnlTopSection.Controls.Add(this.lblChonDanhMucDatHanMucRoiNhanDat);
            this.pnlTopSection.Location = new System.Drawing.Point(15, 10);
            this.pnlTopSection.Name = "pnlTopSection";
            this.pnlTopSection.Size = new System.Drawing.Size(1015, 68);
            this.pnlTopSection.TabIndex = 0;

            this.lblNganSach.AutoSize = true;
            this.lblNganSach.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNganSach.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblNganSach.Location = new System.Drawing.Point(12, 6);
            this.lblNganSach.Name = "lblNganSach";
            this.lblNganSach.Size = new System.Drawing.Size(106, 25);
            this.lblNganSach.TabIndex = 0;
            this.lblNganSach.Text = "Ngân sách";

            this.lblThang2.AutoSize = true;
            this.lblThang2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThang2.Location = new System.Drawing.Point(12, 38);
            this.lblThang2.Name = "lblThang2";
            this.lblThang2.Size = new System.Drawing.Size(43, 15);
            this.lblThang2.TabIndex = 1;
            this.lblThang2.Text = "Tháng:";

            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboThang.Location = new System.Drawing.Point(58, 35);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(55, 23);
            this.cboThang.TabIndex = 2;

            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNam.Location = new System.Drawing.Point(122, 38);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(36, 15);
            this.lblNam.TabIndex = 3;
            this.lblNam.Text = "Năm:";

            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNam.Location = new System.Drawing.Point(162, 35);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(70, 23);
            this.cboNam.TabIndex = 4;

            this.btnXem.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(240, 33);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(65, 27);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;

            this.btnDatHanMuc.BackColor = System.Drawing.Color.White;
            this.btnDatHanMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatHanMuc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDatHanMuc.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnDatHanMuc.Location = new System.Drawing.Point(320, 33);
            this.btnDatHanMuc.Name = "btnDatHanMuc";
            this.btnDatHanMuc.Size = new System.Drawing.Size(120, 27);
            this.btnDatHanMuc.TabIndex = 6;
            this.btnDatHanMuc.Text = "+ Đặt hạn mức";
            this.btnDatHanMuc.UseVisualStyleBackColor = true;

            this.btnSaoChep.BackColor = System.Drawing.Color.White;
            this.btnSaoChep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaoChep.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSaoChep.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnSaoChep.Location = new System.Drawing.Point(448, 33);
            this.btnSaoChep.Name = "btnSaoChep";
            this.btnSaoChep.Size = new System.Drawing.Size(155, 27);
            this.btnSaoChep.TabIndex = 7;
            this.btnSaoChep.Text = "📋 Sao chép tháng trước";
            this.btnSaoChep.UseVisualStyleBackColor = true;

            this.lblThang102026DuLieuDen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThang102026DuLieuDen.AutoSize = true;
            this.lblThang102026DuLieuDen.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblThang102026DuLieuDen.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblThang102026DuLieuDen.Location = new System.Drawing.Point(680, 10);
            this.lblThang102026DuLieuDen.Name = "lblThang102026DuLieuDen";
            this.lblThang102026DuLieuDen.Size = new System.Drawing.Size(242, 15);
            this.lblThang102026DuLieuDen.TabIndex = 8;
            this.lblThang102026DuLieuDen.Text = "Tháng 10/2026 • Dữ liệu đến ngày 26/10/2026";

            this.lblChonDanhMucDatHanMucRoiNhanDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChonDanhMucDatHanMucRoiNhanDat.AutoSize = true;
            this.lblChonDanhMucDatHanMucRoiNhanDat.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblChonDanhMucDatHanMucRoiNhanDat.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblChonDanhMucDatHanMucRoiNhanDat.Location = new System.Drawing.Point(680, 39);
            this.lblChonDanhMucDatHanMucRoiNhanDat.Name = "lblChonDanhMucDatHanMucRoiNhanDat";
            this.lblChonDanhMucDatHanMucRoiNhanDat.Size = new System.Drawing.Size(263, 13);
            this.lblChonDanhMucDatHanMucRoiNhanDat.TabIndex = 9;
            this.lblChonDanhMucDatHanMucRoiNhanDat.Text = "Chọn danh mục rồi nhấn Đặt hạn mức để cập nhật.";

            // ───────────────────────────────────────────────
            // Summary Cards
            // ───────────────────────────────────────────────
            int cardTop = 86;
            int cardHeight = 85;
            int cardWidth = 325;
            int cardGap = 20;

            // pnlTheTongHop (Tổng hạn mức)
            this.pnlTheTongHop.BackColor = System.Drawing.Color.White;
            this.pnlTheTongHop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTheTongHop.Controls.Add(this.lblTongHanMuc);
            this.pnlTheTongHop.Controls.Add(this.lblTongHanMuc2);
            this.pnlTheTongHop.Controls.Add(this.lblSoDanhMucDaDat);
            this.pnlTheTongHop.Location = new System.Drawing.Point(15, cardTop);
            this.pnlTheTongHop.Name = "pnlTheTongHop";
            this.pnlTheTongHop.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlTheTongHop.TabIndex = 1;

            this.lblTongHanMuc.AutoSize = true;
            this.lblTongHanMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTongHanMuc.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblTongHanMuc.Location = new System.Drawing.Point(12, 8);
            this.lblTongHanMuc.Name = "lblTongHanMuc";
            this.lblTongHanMuc.Size = new System.Drawing.Size(83, 15);
            this.lblTongHanMuc.TabIndex = 0;
            this.lblTongHanMuc.Text = "Tổng hạn mức";

            this.lblTongHanMuc2.AutoSize = true;
            this.lblTongHanMuc2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongHanMuc2.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblTongHanMuc2.Location = new System.Drawing.Point(10, 26);
            this.lblTongHanMuc2.Name = "lblTongHanMuc2";
            this.lblTongHanMuc2.Size = new System.Drawing.Size(51, 30);
            this.lblTongHanMuc2.TabIndex = 1;
            this.lblTongHanMuc2.Text = "0 đ";

            this.lblSoDanhMucDaDat.AutoSize = true;
            this.lblSoDanhMucDaDat.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSoDanhMucDaDat.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblSoDanhMucDaDat.Location = new System.Drawing.Point(12, 58);
            this.lblSoDanhMucDaDat.Name = "lblSoDanhMucDaDat";
            this.lblSoDanhMucDaDat.Size = new System.Drawing.Size(164, 15);
            this.lblSoDanhMucDaDat.TabIndex = 2;
            this.lblSoDanhMucDaDat.Text = "0 danh mục đã đặt hạn mức";

            // pnlTheTongHop2 (Đã chi)
            this.pnlTheTongHop2.BackColor = System.Drawing.Color.White;
            this.pnlTheTongHop2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTheTongHop2.Controls.Add(this.lblDaChi);
            this.pnlTheTongHop2.Controls.Add(this.lblDaChi2);
            this.pnlTheTongHop2.Controls.Add(this.lblPhanTramTongHanMuc);
            this.pnlTheTongHop2.Location = new System.Drawing.Point(15 + cardWidth + cardGap, cardTop);
            this.pnlTheTongHop2.Name = "pnlTheTongHop2";
            this.pnlTheTongHop2.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlTheTongHop2.TabIndex = 2;

            this.lblDaChi.AutoSize = true;
            this.lblDaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDaChi.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblDaChi.Location = new System.Drawing.Point(12, 8);
            this.lblDaChi.Name = "lblDaChi";
            this.lblDaChi.Size = new System.Drawing.Size(41, 15);
            this.lblDaChi.TabIndex = 0;
            this.lblDaChi.Text = "Đã chi";

            this.lblDaChi2.AutoSize = true;
            this.lblDaChi2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDaChi2.ForeColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.lblDaChi2.Location = new System.Drawing.Point(10, 26);
            this.lblDaChi2.Name = "lblDaChi2";
            this.lblDaChi2.Size = new System.Drawing.Size(51, 30);
            this.lblDaChi2.TabIndex = 1;
            this.lblDaChi2.Text = "0 đ";

            this.lblPhanTramTongHanMuc.AutoSize = true;
            this.lblPhanTramTongHanMuc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPhanTramTongHanMuc.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblPhanTramTongHanMuc.Location = new System.Drawing.Point(12, 58);
            this.lblPhanTramTongHanMuc.Name = "lblPhanTramTongHanMuc";
            this.lblPhanTramTongHanMuc.Size = new System.Drawing.Size(126, 15);
            this.lblPhanTramTongHanMuc.TabIndex = 2;
            this.lblPhanTramTongHanMuc.Text = "0.0% tổng hạn mức";

            // pnlTheTongHop3 (Còn lại)
            this.pnlTheTongHop3.BackColor = System.Drawing.Color.White;
            this.pnlTheTongHop3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTheTongHop3.Controls.Add(this.lblConLai);
            this.pnlTheTongHop3.Controls.Add(this.lblConLai2);
            this.pnlTheTongHop3.Controls.Add(this.lblNganSachThang102026);
            this.pnlTheTongHop3.Location = new System.Drawing.Point(15 + (cardWidth + cardGap) * 2, cardTop);
            this.pnlTheTongHop3.Name = "pnlTheTongHop3";
            this.pnlTheTongHop3.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlTheTongHop3.TabIndex = 3;

            this.lblConLai.AutoSize = true;
            this.lblConLai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConLai.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblConLai.Location = new System.Drawing.Point(12, 8);
            this.lblConLai.Name = "lblConLai";
            this.lblConLai.Size = new System.Drawing.Size(44, 15);
            this.lblConLai.TabIndex = 0;
            this.lblConLai.Text = "Còn lại";

            this.lblConLai2.AutoSize = true;
            this.lblConLai2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblConLai2.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblConLai2.Location = new System.Drawing.Point(10, 26);
            this.lblConLai2.Name = "lblConLai2";
            this.lblConLai2.Size = new System.Drawing.Size(51, 30);
            this.lblConLai2.TabIndex = 1;
            this.lblConLai2.Text = "0 đ";

            this.lblNganSachThang102026.AutoSize = true;
            this.lblNganSachThang102026.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNganSachThang102026.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblNganSachThang102026.Location = new System.Drawing.Point(12, 58);
            this.lblNganSachThang102026.Name = "lblNganSachThang102026";
            this.lblNganSachThang102026.Size = new System.Drawing.Size(117, 15);
            this.lblNganSachThang102026.TabIndex = 2;
            this.lblNganSachThang102026.Text = "Ngân sách tháng ...";

            // ───────────────────────────────────────────────
            // pnlNganSachDanhMuc
            // ───────────────────────────────────────────────
            int dmTop = 180;
            this.pnlNganSachDanhMuc.BackColor = System.Drawing.Color.White;
            this.pnlNganSachDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNganSachDanhMuc.Location = new System.Drawing.Point(15, dmTop);
            this.pnlNganSachDanhMuc.Name = "pnlNganSachDanhMuc";
            this.pnlNganSachDanhMuc.Size = new System.Drawing.Size(1015, 300);
            this.pnlNganSachDanhMuc.TabIndex = 4;

            // Headers
            int hdrY = 10;
            System.Drawing.Font hdrFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color hdrColor = System.Drawing.Color.FromArgb(80, 80, 80);

            this.lblLoaiChi.AutoSize = true;
            this.lblLoaiChi.Font = hdrFont;
            this.lblLoaiChi.ForeColor = hdrColor;
            this.lblLoaiChi.Location = new System.Drawing.Point(15, hdrY);
            this.lblLoaiChi.Name = "lblLoaiChi";
            this.lblLoaiChi.Size = new System.Drawing.Size(50, 15);
            this.lblLoaiChi.Text = "Loại chi";

            this.lblDaChiHanMuc.AutoSize = true;
            this.lblDaChiHanMuc.Font = hdrFont;
            this.lblDaChiHanMuc.ForeColor = hdrColor;
            this.lblDaChiHanMuc.Location = new System.Drawing.Point(160, hdrY);
            this.lblDaChiHanMuc.Name = "lblDaChiHanMuc";
            this.lblDaChiHanMuc.Size = new System.Drawing.Size(105, 15);
            this.lblDaChiHanMuc.Text = "Đã chi / Hạn mức";

            this.lblMucSuDung.AutoSize = true;
            this.lblMucSuDung.Font = hdrFont;
            this.lblMucSuDung.ForeColor = hdrColor;
            this.lblMucSuDung.Location = new System.Drawing.Point(400, hdrY);
            this.lblMucSuDung.Name = "lblMucSuDung";
            this.lblMucSuDung.Size = new System.Drawing.Size(78, 15);
            this.lblMucSuDung.Text = "Mức sử dụng";

            this.lblConLai3.AutoSize = true;
            this.lblConLai3.Font = hdrFont;
            this.lblConLai3.ForeColor = hdrColor;
            this.lblConLai3.Location = new System.Drawing.Point(700, hdrY);
            this.lblConLai3.Name = "lblConLai3";
            this.lblConLai3.Text = "Còn lại";

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = hdrFont;
            this.lblTrangThai.ForeColor = hdrColor;
            this.lblTrangThai.Location = new System.Drawing.Point(850, hdrY);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái";

            this.pnlNganSachDanhMuc.Controls.Add(this.lblLoaiChi);
            this.pnlNganSachDanhMuc.Controls.Add(this.lblDaChiHanMuc);
            this.pnlNganSachDanhMuc.Controls.Add(this.lblMucSuDung);
            this.pnlNganSachDanhMuc.Controls.Add(this.lblConLai3);
            this.pnlNganSachDanhMuc.Controls.Add(this.lblTrangThai);

            // Category rows setup
            int baseY = 38;
            int rowH = 42;
            System.Drawing.Font rowFont = new System.Drawing.Font("Segoe UI", 9F);
            System.Drawing.Font rowBoldFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // Row 0: Nhà ở
            SetupCategoryRowControls(this.lblNhaO, "Nhà ở", this.lblNhaO2, this.prgNhaO, this.lblTyLe, this.lblNhaO3, this.lblDaChamHanMuc, "Đã chạm hạn mức", baseY, rowFont, rowBoldFont);

            // Row 1: Ăn uống
            SetupCategoryRowControls(this.lblAnUong, "Ăn uống", this.lblAnUong2, this.prgAnUong, this.lblTyLe2, this.lblAnUong3, this.lblSapDatHanMuc, "Sắp đạt hạn mức", baseY + rowH, rowFont, rowBoldFont);

            // Row 2: Di chuyển
            SetupCategoryRowControls(this.lblDiChuyen, "Di chuyển", this.lblDiChuyen2, this.prgDiChuyen, this.lblTyLe3, this.lblDiChuyen3, this.lblVuotHanMuc, "Vượt hạn mức", baseY + rowH * 2, rowFont, rowBoldFont);

            // Row 3: Mua sắm
            SetupCategoryRowControls(this.lblMuaSam, "Mua sắm", this.lblMuaSam2, this.prgMuaSam, this.lblTyLe4, this.lblMuaSam3, this.lblTrongHanMuc, "Trong hạn mức", baseY + rowH * 3, rowFont, rowBoldFont);

            // Row 4: Khác
            SetupCategoryRowControls(this.lblKhac, "Khác", this.lblKhac2, this.prgKhac, this.lblTyLe5, this.lblKhac3, this.lblChuaDatHanMuc, "Chưa đặt hạn mức", baseY + rowH * 4, rowFont, rowBoldFont);

            // Row 5: Y tế
            SetupCategoryRowControls(this.lblYTe, "Y tế", this.lblYTe2, this.prgYTe, this.lblTyLe6, this.lblYTe3, this.lblTrangThaiYTe, "", baseY + rowH * 5, rowFont, rowBoldFont);

            // ───────────────────────────────────────────────
            // Legend Panel
            // ───────────────────────────────────────────────
            int legendTop = 490;
            this.pnlLegend.BackColor = System.Drawing.Color.White;
            this.pnlLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegend.Location = new System.Drawing.Point(15, legendTop);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(1015, 32);
            this.pnlLegend.TabIndex = 5;

            this.pnlGreenSquare.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.pnlGreenSquare.Location = new System.Drawing.Point(12, 8);
            this.pnlGreenSquare.Name = "pnlGreenSquare";
            this.pnlGreenSquare.Size = new System.Drawing.Size(16, 16);

            this.lblDuoi80.AutoSize = true;
            this.lblDuoi80.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDuoi80.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblDuoi80.Location = new System.Drawing.Point(32, 8);
            this.lblDuoi80.Name = "lblDuoi80";
            this.lblDuoi80.Size = new System.Drawing.Size(56, 15);
            this.lblDuoi80.Text = "Dưới 80%";

            this.pnlOrangeSquare.BackColor = System.Drawing.Color.FromArgb(245, 124, 0);
            this.pnlOrangeSquare.Location = new System.Drawing.Point(140, 8);
            this.pnlOrangeSquare.Name = "pnlOrangeSquare";
            this.pnlOrangeSquare.Size = new System.Drawing.Size(16, 16);

            this.lblTu80DenDuoi100.AutoSize = true;
            this.lblTu80DenDuoi100.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTu80DenDuoi100.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTu80DenDuoi100.Location = new System.Drawing.Point(160, 8);
            this.lblTu80DenDuoi100.Name = "lblTu80DenDuoi100";
            this.lblTu80DenDuoi100.Size = new System.Drawing.Size(130, 15);
            this.lblTu80DenDuoi100.Text = "Từ 80% đến dưới 100%";

            this.pnlRedSquare.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.pnlRedSquare.Location = new System.Drawing.Point(340, 8);
            this.pnlRedSquare.Name = "pnlRedSquare";
            this.pnlRedSquare.Size = new System.Drawing.Size(16, 16);

            this.lblTu100TroLen.AutoSize = true;
            this.lblTu100TroLen.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTu100TroLen.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTu100TroLen.Location = new System.Drawing.Point(360, 8);
            this.lblTu100TroLen.Name = "lblTu100TroLen";
            this.lblTu100TroLen.Size = new System.Drawing.Size(91, 15);
            this.lblTu100TroLen.Text = "Từ 100% trở lên";

            this.pnlLegend.Controls.Add(this.pnlGreenSquare);
            this.pnlLegend.Controls.Add(this.lblDuoi80);
            this.pnlLegend.Controls.Add(this.pnlOrangeSquare);
            this.pnlLegend.Controls.Add(this.lblTu80DenDuoi100);
            this.pnlLegend.Controls.Add(this.pnlRedSquare);
            this.pnlLegend.Controls.Add(this.lblTu100TroLen);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 600);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmNganSach";
            this.Text = "Quản Lý Chi Tiêu — Ngân sách";
            this.Load += new System.EventHandler(this.frmNganSach_Load);

            this.pnlTopSection.ResumeLayout(false);
            this.pnlTopSection.PerformLayout();
            this.pnlTheTongHop.ResumeLayout(false);
            this.pnlTheTongHop.PerformLayout();
            this.pnlTheTongHop2.ResumeLayout(false);
            this.pnlTheTongHop2.PerformLayout();
            this.pnlTheTongHop3.ResumeLayout(false);
            this.pnlTheTongHop3.PerformLayout();
            this.pnlNganSachDanhMuc.ResumeLayout(false);
            this.pnlNganSachDanhMuc.PerformLayout();
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void SetupCategoryRowControls(
            System.Windows.Forms.Label lblCat,
            string catName,
            System.Windows.Forms.Label lblDetail,
            System.Windows.Forms.ProgressBar prg,
            System.Windows.Forms.Label lblPct,
            System.Windows.Forms.Label lblRem,
            System.Windows.Forms.Label lblStatus,
            string defaultStatus,
            int yPos,
            System.Drawing.Font rFont,
            System.Drawing.Font rBoldFont)
        {
            lblCat.AutoSize = true;
            lblCat.Font = rBoldFont;
            lblCat.Location = new System.Drawing.Point(15, yPos);
            lblCat.Name = "lbl_" + catName;
            lblCat.Text = catName;

            lblDetail.AutoSize = true;
            lblDetail.Font = rFont;
            lblDetail.Location = new System.Drawing.Point(160, yPos);
            lblDetail.Name = "lblDetail_" + catName;
            lblDetail.Text = "—";

            prg.Location = new System.Drawing.Point(400, yPos);
            prg.Size = new System.Drawing.Size(220, 18);
            prg.Name = "prg_" + catName;

            lblPct.AutoSize = true;
            lblPct.Font = rBoldFont;
            lblPct.Location = new System.Drawing.Point(630, yPos);
            lblPct.Name = "lblPct_" + catName;
            lblPct.Text = "0%";

            lblRem.AutoSize = true;
            lblRem.Font = rFont;
            lblRem.Location = new System.Drawing.Point(700, yPos);
            lblRem.Name = "lblRem_" + catName;
            lblRem.Text = "—";

            lblStatus.AutoSize = true;
            lblStatus.Font = rBoldFont;
            lblStatus.Location = new System.Drawing.Point(850, yPos);
            lblStatus.Name = "lblStatus_" + catName;
            lblStatus.Text = defaultStatus;

            this.pnlNganSachDanhMuc.Controls.Add(lblCat);
            this.pnlNganSachDanhMuc.Controls.Add(lblDetail);
            this.pnlNganSachDanhMuc.Controls.Add(prg);
            this.pnlNganSachDanhMuc.Controls.Add(lblPct);
            this.pnlNganSachDanhMuc.Controls.Add(lblRem);
            this.pnlNganSachDanhMuc.Controls.Add(lblStatus);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTopSection;
        private System.Windows.Forms.Label lblNganSach;
        private System.Windows.Forms.Label lblThang2;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnDatHanMuc;
        private System.Windows.Forms.Button btnSaoChep;
        private System.Windows.Forms.Label lblThang102026DuLieuDen;
        private System.Windows.Forms.Label lblChonDanhMucDatHanMucRoiNhanDat;

        private System.Windows.Forms.Panel pnlTheTongHop;
        private System.Windows.Forms.Label lblTongHanMuc;
        private System.Windows.Forms.Label lblTongHanMuc2;
        private System.Windows.Forms.Label lblSoDanhMucDaDat;

        private System.Windows.Forms.Panel pnlTheTongHop2;
        private System.Windows.Forms.Label lblDaChi;
        private System.Windows.Forms.Label lblDaChi2;
        private System.Windows.Forms.Label lblPhanTramTongHanMuc;

        private System.Windows.Forms.Panel pnlTheTongHop3;
        private System.Windows.Forms.Label lblConLai;
        private System.Windows.Forms.Label lblConLai2;
        private System.Windows.Forms.Label lblNganSachThang102026;

        private System.Windows.Forms.Panel pnlNganSachDanhMuc;
        private System.Windows.Forms.Label lblLoaiChi;
        private System.Windows.Forms.Label lblDaChiHanMuc;
        private System.Windows.Forms.Label lblMucSuDung;
        private System.Windows.Forms.Label lblConLai3;
        private System.Windows.Forms.Label lblTrangThai;

        private System.Windows.Forms.Label lblNhaO;
        private System.Windows.Forms.Label lblNhaO2;
        private System.Windows.Forms.ProgressBar prgNhaO;
        private System.Windows.Forms.Label lblTyLe;
        private System.Windows.Forms.Label lblNhaO3;
        private System.Windows.Forms.Label lblDaChamHanMuc;

        private System.Windows.Forms.Label lblAnUong;
        private System.Windows.Forms.Label lblAnUong2;
        private System.Windows.Forms.ProgressBar prgAnUong;
        private System.Windows.Forms.Label lblTyLe2;
        private System.Windows.Forms.Label lblAnUong3;
        private System.Windows.Forms.Label lblSapDatHanMuc;

        private System.Windows.Forms.Label lblDiChuyen;
        private System.Windows.Forms.Label lblDiChuyen2;
        private System.Windows.Forms.ProgressBar prgDiChuyen;
        private System.Windows.Forms.Label lblTyLe3;
        private System.Windows.Forms.Label lblDiChuyen3;
        private System.Windows.Forms.Label lblVuotHanMuc;

        private System.Windows.Forms.Label lblMuaSam;
        private System.Windows.Forms.Label lblMuaSam2;
        private System.Windows.Forms.ProgressBar prgMuaSam;
        private System.Windows.Forms.Label lblTyLe4;
        private System.Windows.Forms.Label lblMuaSam3;
        private System.Windows.Forms.Label lblTrongHanMuc;

        private System.Windows.Forms.Label lblKhac;
        private System.Windows.Forms.Label lblKhac2;
        private System.Windows.Forms.ProgressBar prgKhac;
        private System.Windows.Forms.Label lblTyLe5;
        private System.Windows.Forms.Label lblKhac3;
        private System.Windows.Forms.Label lblChuaDatHanMuc;

        private System.Windows.Forms.Label lblYTe;
        private System.Windows.Forms.Label lblYTe2;
        private System.Windows.Forms.ProgressBar prgYTe;
        private System.Windows.Forms.Label lblTyLe6;
        private System.Windows.Forms.Label lblYTe3;
        private System.Windows.Forms.Label lblTrangThaiYTe;

        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Panel pnlGreenSquare;
        private System.Windows.Forms.Label lblDuoi80;
        private System.Windows.Forms.Panel pnlOrangeSquare;
        private System.Windows.Forms.Label lblTu80DenDuoi100;
        private System.Windows.Forms.Panel pnlRedSquare;
        private System.Windows.Forms.Label lblTu100TroLen;
    }
}
