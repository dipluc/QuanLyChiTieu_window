using System.Drawing;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    partial class frmCauHinh
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
            this.pnlMain = new Panel();
            this.lblCauHinhUngDung = new Label();
            this.pnlCauHinh = new Panel();

            // Section 1 - Sao luu du lieu
            this.pnlSaoLuu = new Panel();
            this.lblSaoLuuDuLieu = new Label();
            this.pnlThuMucMacDinh = new Panel();
            this.lblThuMucMacDinh = new Label();
            this.txtThuMucSaoLuuMacDinh = new TextBox();
            this.pnlChonThuMuc = new Panel();
            this.btnDuyetThuMuc = new Button();
            this.lblGoiYThuMuc = new Label();
            this.chkTuDongSaoLuuKhiThoat = new CheckBox();

            // Section 2 - Canh bao ngan sach
            this.pnlNganSach = new Panel();
            this.lblCanhBaoNganSach = new Label();
            this.pnlNguongCanhBao = new Panel();
            this.lblNguongCanhBao = new Label();
            this.txtNguongCanhBao = new TextBox();
            this.lblPercent = new Label();
            this.btnTang = new Button();
            this.btnGiam = new Button();
            this.lblNguongCanhBao2 = new Label();
            this.lblGiaiThichNguong = new Label();

            // Bottom buttons
            this.pnlBottomButtons = new Panel();
            this.btnLuuThayDoi = new Button();
            this.btnHuy = new Button();

            this.pnlMain.SuspendLayout();
            this.pnlCauHinh.SuspendLayout();
            this.pnlSaoLuu.SuspendLayout();
            this.pnlThuMucMacDinh.SuspendLayout();
            this.pnlChonThuMuc.SuspendLayout();
            this.pnlNganSach.SuspendLayout();
            this.pnlNguongCanhBao.SuspendLayout();
            this.pnlBottomButtons.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════
            // pnlMain  (scrollable main content area)
            // ════════════════════════════════════════════════
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = Color.FromArgb(245, 246, 248);
            this.pnlMain.Controls.Add(this.lblCauHinhUngDung);
            this.pnlMain.Controls.Add(this.pnlCauHinh);
            this.pnlMain.Controls.Add(this.pnlBottomButtons);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(28, 16, 28, 16);
            this.pnlMain.Size = new Size(1060, 600);
            this.pnlMain.TabIndex = 0;

            // lblCauHinhUngDung
            this.lblCauHinhUngDung.AutoSize = true;
            this.lblCauHinhUngDung.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblCauHinhUngDung.ForeColor = Color.FromArgb(33, 33, 33);
            this.lblCauHinhUngDung.Location = new Point(28, 16);
            this.lblCauHinhUngDung.Name = "lblCauHinhUngDung";
            this.lblCauHinhUngDung.Size = new Size(196, 28);
            this.lblCauHinhUngDung.TabIndex = 0;
            this.lblCauHinhUngDung.Text = "Cấu hình ứng dụng";

            // ════════════════════════════════════════════════
            // pnlCauHinh  (main settings panel)
            // ════════════════════════════════════════════════
            this.pnlCauHinh.BackColor = Color.White;
            this.pnlCauHinh.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCauHinh.Controls.Add(this.pnlSaoLuu);
            this.pnlCauHinh.Controls.Add(this.pnlNganSach);
            this.pnlCauHinh.Location = new Point(28, 56);
            this.pnlCauHinh.Name = "pnlCauHinh";
            this.pnlCauHinh.Size = new Size(990, 340);
            this.pnlCauHinh.TabIndex = 1;

            // ─── Section 1: pnlSaoLuu ───
            this.pnlSaoLuu.BackColor = Color.White;
            this.pnlSaoLuu.Controls.Add(this.lblSaoLuuDuLieu);
            this.pnlSaoLuu.Controls.Add(this.pnlThuMucMacDinh);
            this.pnlSaoLuu.Controls.Add(this.chkTuDongSaoLuuKhiThoat);
            this.pnlSaoLuu.Dock = DockStyle.Top;
            this.pnlSaoLuu.Location = new Point(0, 0);
            this.pnlSaoLuu.Name = "pnlSaoLuu";
            this.pnlSaoLuu.Padding = new Padding(24, 16, 24, 12);
            this.pnlSaoLuu.Size = new Size(988, 175);
            this.pnlSaoLuu.TabIndex = 0;

            // lblSaoLuuDuLieu
            this.lblSaoLuuDuLieu.AutoSize = true;
            this.lblSaoLuuDuLieu.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.lblSaoLuuDuLieu.ForeColor = Color.FromArgb(33, 33, 33);
            this.lblSaoLuuDuLieu.Location = new Point(20, 14);
            this.lblSaoLuuDuLieu.Name = "lblSaoLuuDuLieu";
            this.lblSaoLuuDuLieu.Size = new Size(111, 20);
            this.lblSaoLuuDuLieu.TabIndex = 0;
            this.lblSaoLuuDuLieu.Text = "Sao lưu dữ liệu";

            // pnlThuMucMacDinh
            this.pnlThuMucMacDinh.Controls.Add(this.lblThuMucMacDinh);
            this.pnlThuMucMacDinh.Controls.Add(this.txtThuMucSaoLuuMacDinh);
            this.pnlThuMucMacDinh.Controls.Add(this.pnlChonThuMuc);
            this.pnlThuMucMacDinh.Controls.Add(this.lblGoiYThuMuc);
            this.pnlThuMucMacDinh.Location = new Point(20, 42);
            this.pnlThuMucMacDinh.Name = "pnlThuMucMacDinh";
            this.pnlThuMucMacDinh.Size = new Size(940, 78);
            this.pnlThuMucMacDinh.TabIndex = 1;

            // lblThuMucMacDinh
            this.lblThuMucMacDinh.AutoSize = true;
            this.lblThuMucMacDinh.Font = new Font("Segoe UI", 9.5F);
            this.lblThuMucMacDinh.ForeColor = Color.FromArgb(66, 66, 66);
            this.lblThuMucMacDinh.Location = new Point(0, 4);
            this.lblThuMucMacDinh.Name = "lblThuMucMacDinh";
            this.lblThuMucMacDinh.Size = new Size(161, 17);
            this.lblThuMucMacDinh.TabIndex = 0;
            this.lblThuMucMacDinh.Text = "Thư mục sao lưu mặc định";

            // txtThuMucSaoLuuMacDinh
            this.txtThuMucSaoLuuMacDinh.BackColor = Color.FromArgb(250, 250, 250);
            this.txtThuMucSaoLuuMacDinh.BorderStyle = BorderStyle.FixedSingle;
            this.txtThuMucSaoLuuMacDinh.Font = new Font("Segoe UI", 9.5F);
            this.txtThuMucSaoLuuMacDinh.ForeColor = Color.FromArgb(51, 51, 51);
            this.txtThuMucSaoLuuMacDinh.Location = new Point(0, 26);
            this.txtThuMucSaoLuuMacDinh.Name = "txtThuMucSaoLuuMacDinh";
            this.txtThuMucSaoLuuMacDinh.Size = new Size(540, 24);
            this.txtThuMucSaoLuuMacDinh.TabIndex = 1;
            this.txtThuMucSaoLuuMacDinh.Text = @"D:\QuanLyChiTieu\SaoLuu";

            // pnlChonThuMuc
            this.pnlChonThuMuc.Controls.Add(this.btnDuyetThuMuc);
            this.pnlChonThuMuc.Location = new Point(548, 24);
            this.pnlChonThuMuc.Name = "pnlChonThuMuc";
            this.pnlChonThuMuc.Size = new Size(100, 32);
            this.pnlChonThuMuc.TabIndex = 2;

            // btnDuyetThuMuc
            this.btnDuyetThuMuc.BackColor = Color.White;
            this.btnDuyetThuMuc.FlatAppearance.BorderColor = Color.FromArgb(180, 180, 180);
            this.btnDuyetThuMuc.FlatStyle = FlatStyle.Flat;
            this.btnDuyetThuMuc.Font = new Font("Segoe UI", 9F);
            this.btnDuyetThuMuc.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnDuyetThuMuc.Location = new Point(0, 1);
            this.btnDuyetThuMuc.Name = "btnDuyetThuMuc";
            this.btnDuyetThuMuc.Size = new Size(90, 27);
            this.btnDuyetThuMuc.TabIndex = 0;
            this.btnDuyetThuMuc.Text = "Duyệt...";
            this.btnDuyetThuMuc.UseVisualStyleBackColor = false;

            // lblGoiYThuMuc
            this.lblGoiYThuMuc.AutoSize = true;
            this.lblGoiYThuMuc.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblGoiYThuMuc.ForeColor = Color.FromArgb(130, 130, 130);
            this.lblGoiYThuMuc.Location = new Point(0, 56);
            this.lblGoiYThuMuc.Name = "lblGoiYThuMuc";
            this.lblGoiYThuMuc.Size = new Size(357, 15);
            this.lblGoiYThuMuc.TabIndex = 3;
            this.lblGoiYThuMuc.Text = "Các bản sao lưu thủ công và tự động sẽ được lưu vào thư mục này.";

            // chkTuDongSaoLuuKhiThoat
            this.chkTuDongSaoLuuKhiThoat.AutoSize = true;
            this.chkTuDongSaoLuuKhiThoat.Font = new Font("Segoe UI", 9.5F);
            this.chkTuDongSaoLuuKhiThoat.ForeColor = Color.FromArgb(51, 51, 51);
            this.chkTuDongSaoLuuKhiThoat.Location = new Point(20, 135);
            this.chkTuDongSaoLuuKhiThoat.Name = "chkTuDongSaoLuuKhiThoat";
            this.chkTuDongSaoLuuKhiThoat.Size = new Size(174, 21);
            this.chkTuDongSaoLuuKhiThoat.TabIndex = 2;
            this.chkTuDongSaoLuuKhiThoat.Text = "Tự động sao lưu khi thoát";
            this.chkTuDongSaoLuuKhiThoat.UseVisualStyleBackColor = true;

            // ─── Section 2: pnlNganSach ───
            this.pnlNganSach.BackColor = Color.White;
            this.pnlNganSach.Controls.Add(this.lblCanhBaoNganSach);
            this.pnlNganSach.Controls.Add(this.pnlNguongCanhBao);
            this.pnlNganSach.Controls.Add(this.lblGiaiThichNguong);
            this.pnlNganSach.Location = new Point(0, 180);
            this.pnlNganSach.Name = "pnlNganSach";
            this.pnlNganSach.Padding = new Padding(24, 16, 24, 16);
            this.pnlNganSach.Size = new Size(988, 150);
            this.pnlNganSach.TabIndex = 1;

            // lblCanhBaoNganSach
            this.lblCanhBaoNganSach.AutoSize = true;
            this.lblCanhBaoNganSach.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            this.lblCanhBaoNganSach.ForeColor = Color.FromArgb(33, 33, 33);
            this.lblCanhBaoNganSach.Location = new Point(20, 14);
            this.lblCanhBaoNganSach.Name = "lblCanhBaoNganSach";
            this.lblCanhBaoNganSach.Size = new Size(147, 20);
            this.lblCanhBaoNganSach.TabIndex = 0;
            this.lblCanhBaoNganSach.Text = "Cảnh báo ngân sách";

            // pnlNguongCanhBao
            this.pnlNguongCanhBao.Controls.Add(this.lblNguongCanhBao);
            this.pnlNguongCanhBao.Controls.Add(this.txtNguongCanhBao);
            this.pnlNguongCanhBao.Controls.Add(this.lblPercent);
            this.pnlNguongCanhBao.Controls.Add(this.btnTang);
            this.pnlNguongCanhBao.Controls.Add(this.btnGiam);
            this.pnlNguongCanhBao.Controls.Add(this.lblNguongCanhBao2);
            this.pnlNguongCanhBao.Location = new Point(20, 44);
            this.pnlNguongCanhBao.Name = "pnlNguongCanhBao";
            this.pnlNguongCanhBao.Size = new Size(940, 40);
            this.pnlNguongCanhBao.TabIndex = 1;

            // lblNguongCanhBao
            this.lblNguongCanhBao.AutoSize = true;
            this.lblNguongCanhBao.Font = new Font("Segoe UI", 9.5F);
            this.lblNguongCanhBao.ForeColor = Color.FromArgb(66, 66, 66);
            this.lblNguongCanhBao.Location = new Point(0, 8);
            this.lblNguongCanhBao.Name = "lblNguongCanhBao";
            this.lblNguongCanhBao.Size = new Size(176, 17);
            this.lblNguongCanhBao.TabIndex = 0;
            this.lblNguongCanhBao.Text = "Ngưỡng cảnh báo ngân sách";

            // txtNguongCanhBao
            this.txtNguongCanhBao.BackColor = Color.FromArgb(250, 250, 250);
            this.txtNguongCanhBao.BorderStyle = BorderStyle.FixedSingle;
            this.txtNguongCanhBao.Font = new Font("Segoe UI", 10F);
            this.txtNguongCanhBao.ForeColor = Color.FromArgb(33, 33, 33);
            this.txtNguongCanhBao.Location = new Point(190, 4);
            this.txtNguongCanhBao.Name = "txtNguongCanhBao";
            this.txtNguongCanhBao.Size = new Size(55, 25);
            this.txtNguongCanhBao.TabIndex = 1;
            this.txtNguongCanhBao.Text = "80";
            this.txtNguongCanhBao.TextAlign = HorizontalAlignment.Center;

            // lblPercent
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new Font("Segoe UI", 10F);
            this.lblPercent.ForeColor = Color.FromArgb(66, 66, 66);
            this.lblPercent.Location = new Point(248, 7);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new Size(20, 19);
            this.lblPercent.TabIndex = 2;
            this.lblPercent.Text = "%";

            // btnTang
            this.btnTang.BackColor = Color.White;
            this.btnTang.FlatAppearance.BorderColor = Color.FromArgb(180, 180, 180);
            this.btnTang.FlatStyle = FlatStyle.Flat;
            this.btnTang.Font = new Font("Segoe UI", 8F);
            this.btnTang.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnTang.Location = new Point(275, 4);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new Size(28, 25);
            this.btnTang.TabIndex = 3;
            this.btnTang.Text = "▲";
            this.btnTang.UseVisualStyleBackColor = false;

            // btnGiam
            this.btnGiam.BackColor = Color.White;
            this.btnGiam.FlatAppearance.BorderColor = Color.FromArgb(180, 180, 180);
            this.btnGiam.FlatStyle = FlatStyle.Flat;
            this.btnGiam.Font = new Font("Segoe UI", 8F);
            this.btnGiam.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnGiam.Location = new Point(308, 4);
            this.btnGiam.Name = "btnGiam";
            this.btnGiam.Size = new Size(28, 25);
            this.btnGiam.TabIndex = 4;
            this.btnGiam.Text = "▼";
            this.btnGiam.UseVisualStyleBackColor = false;

            // lblNguongCanhBao2
            this.lblNguongCanhBao2.AutoSize = true;
            this.lblNguongCanhBao2.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblNguongCanhBao2.ForeColor = Color.FromArgb(130, 130, 130);
            this.lblNguongCanhBao2.Location = new Point(350, 9);
            this.lblNguongCanhBao2.Name = "lblNguongCanhBao2";
            this.lblNguongCanhBao2.Size = new Size(88, 15);
            this.lblNguongCanhBao2.TabIndex = 5;
            this.lblNguongCanhBao2.Text = "Mặc định: 80%";

            // lblGiaiThichNguong
            this.lblGiaiThichNguong.AutoSize = true;
            this.lblGiaiThichNguong.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblGiaiThichNguong.ForeColor = Color.FromArgb(130, 130, 130);
            this.lblGiaiThichNguong.Location = new Point(20, 95);
            this.lblGiaiThichNguong.Name = "lblGiaiThichNguong";
            this.lblGiaiThichNguong.Size = new Size(393, 15);
            this.lblGiaiThichNguong.TabIndex = 2;
            this.lblGiaiThichNguong.Text = "Hiển thị cảnh báo khi chi tiêu đạt từ 80% hạn mức ngân sách trở lên.";

            // ════════════════════════════════════════════════
            // pnlBottomButtons
            // ════════════════════════════════════════════════
            this.pnlBottomButtons.BackColor = Color.Transparent;
            this.pnlBottomButtons.Controls.Add(this.btnLuuThayDoi);
            this.pnlBottomButtons.Controls.Add(this.btnHuy);
            this.pnlBottomButtons.Location = new Point(28, 410);
            this.pnlBottomButtons.Name = "pnlBottomButtons";
            this.pnlBottomButtons.Size = new Size(990, 50);
            this.pnlBottomButtons.TabIndex = 2;

            // btnLuuThayDoi
            this.btnLuuThayDoi.BackColor = Color.FromArgb(21, 101, 192);
            this.btnLuuThayDoi.FlatAppearance.BorderSize = 0;
            this.btnLuuThayDoi.FlatStyle = FlatStyle.Flat;
            this.btnLuuThayDoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnLuuThayDoi.ForeColor = Color.White;
            this.btnLuuThayDoi.Location = new Point(20, 8);
            this.btnLuuThayDoi.Name = "btnLuuThayDoi";
            this.btnLuuThayDoi.Size = new Size(130, 34);
            this.btnLuuThayDoi.TabIndex = 0;
            this.btnLuuThayDoi.Text = "Lưu thay đổi";
            this.btnLuuThayDoi.UseVisualStyleBackColor = false;

            // btnHuy
            this.btnHuy.BackColor = Color.White;
            this.btnHuy.FlatAppearance.BorderColor = Color.FromArgb(180, 180, 180);
            this.btnHuy.FlatStyle = FlatStyle.Flat;
            this.btnHuy.Font = new Font("Segoe UI", 9.5F);
            this.btnHuy.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnHuy.Location = new Point(160, 8);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(90, 34);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;

            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1060, 600);
            this.Controls.Add(this.pnlMain);
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "frmCauHinh";
            this.Text = "Quản Lý Chi Tiêu — Cấu hình";

            this.pnlSaoLuu.ResumeLayout(false);
            this.pnlSaoLuu.PerformLayout();
            this.pnlThuMucMacDinh.ResumeLayout(false);
            this.pnlThuMucMacDinh.PerformLayout();
            this.pnlChonThuMuc.ResumeLayout(false);
            this.pnlNganSach.ResumeLayout(false);
            this.pnlNganSach.PerformLayout();
            this.pnlNguongCanhBao.ResumeLayout(false);
            this.pnlNguongCanhBao.PerformLayout();
            this.pnlBottomButtons.ResumeLayout(false);
            this.pnlCauHinh.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Label lblCauHinhUngDung;
        private Panel pnlCauHinh;

        private Panel pnlSaoLuu;
        private Label lblSaoLuuDuLieu;
        private Panel pnlThuMucMacDinh;
        private Label lblThuMucMacDinh;
        private TextBox txtThuMucSaoLuuMacDinh;
        private Panel pnlChonThuMuc;
        private Button btnDuyetThuMuc;
        private Label lblGoiYThuMuc;
        private CheckBox chkTuDongSaoLuuKhiThoat;

        private Panel pnlNganSach;
        private Label lblCanhBaoNganSach;
        private Panel pnlNguongCanhBao;
        private Label lblNguongCanhBao;
        private TextBox txtNguongCanhBao;
        private Label lblPercent;
        private Button btnTang;
        private Button btnGiam;
        private Label lblNguongCanhBao2;
        private Label lblGiaiThichNguong;

        private Panel pnlBottomButtons;
        private Button btnLuuThayDoi;
        private Button btnHuy;
    }
}
