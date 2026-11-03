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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblCauHinhUngDung = new System.Windows.Forms.Label();
            this.pnlCauHinh = new System.Windows.Forms.Panel();
            this.pnlSaoLuu = new System.Windows.Forms.Panel();
            this.lblSaoLuuDuLieu = new System.Windows.Forms.Label();
            this.pnlThuMucMacDinh = new System.Windows.Forms.Panel();
            this.lblThuMucMacDinh = new System.Windows.Forms.Label();
            this.txtThuMucSaoLuuMacDinh = new System.Windows.Forms.TextBox();
            this.pnlChonThuMuc = new System.Windows.Forms.Panel();
            this.btnDuyetThuMuc = new System.Windows.Forms.Button();
            this.lblGoiYThuMuc = new System.Windows.Forms.Label();
            this.chkTuDongSaoLuuKhiThoat = new System.Windows.Forms.CheckBox();
            this.pnlNganSach = new System.Windows.Forms.Panel();
            this.lblCanhBaoNganSach = new System.Windows.Forms.Label();
            this.pnlNguongCanhBao = new System.Windows.Forms.Panel();
            this.lblNguongCanhBao = new System.Windows.Forms.Label();
            this.txtNguongCanhBao = new System.Windows.Forms.TextBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblNguongCanhBao2 = new System.Windows.Forms.Label();
            this.lblGiaiThichNguong = new System.Windows.Forms.Label();
            this.pnlBottomButtons = new System.Windows.Forms.Panel();
            this.btnLuuThayDoi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnTang = new System.Windows.Forms.Button();
            this.btnGiam = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlCauHinh.SuspendLayout();
            this.pnlSaoLuu.SuspendLayout();
            this.pnlThuMucMacDinh.SuspendLayout();
            this.pnlChonThuMuc.SuspendLayout();
            this.pnlNganSach.SuspendLayout();
            this.pnlNguongCanhBao.SuspendLayout();
            this.pnlBottomButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.pnlMain.Controls.Add(this.lblCauHinhUngDung);
            this.pnlMain.Controls.Add(this.pnlCauHinh);
            this.pnlMain.Controls.Add(this.pnlBottomButtons);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(28, 16, 28, 16);
            this.pnlMain.Size = new System.Drawing.Size(1060, 600);
            this.pnlMain.TabIndex = 0;
            // 
            // lblCauHinhUngDung
            // 
            this.lblCauHinhUngDung.AutoSize = true;
            this.lblCauHinhUngDung.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblCauHinhUngDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCauHinhUngDung.Location = new System.Drawing.Point(28, 16);
            this.lblCauHinhUngDung.Name = "lblCauHinhUngDung";
            this.lblCauHinhUngDung.Size = new System.Drawing.Size(239, 35);
            this.lblCauHinhUngDung.TabIndex = 0;
            this.lblCauHinhUngDung.Text = "Cấu hình ứng dụng";
            // 
            // pnlCauHinh
            // 
            this.pnlCauHinh.BackColor = System.Drawing.Color.White;
            this.pnlCauHinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCauHinh.Controls.Add(this.pnlSaoLuu);
            this.pnlCauHinh.Controls.Add(this.pnlNganSach);
            this.pnlCauHinh.Location = new System.Drawing.Point(28, 56);
            this.pnlCauHinh.Name = "pnlCauHinh";
            this.pnlCauHinh.Size = new System.Drawing.Size(990, 340);
            this.pnlCauHinh.TabIndex = 1;
            // 
            // pnlSaoLuu
            // 
            this.pnlSaoLuu.BackColor = System.Drawing.Color.White;
            this.pnlSaoLuu.Controls.Add(this.lblSaoLuuDuLieu);
            this.pnlSaoLuu.Controls.Add(this.pnlThuMucMacDinh);
            this.pnlSaoLuu.Controls.Add(this.chkTuDongSaoLuuKhiThoat);
            this.pnlSaoLuu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSaoLuu.Location = new System.Drawing.Point(0, 0);
            this.pnlSaoLuu.Name = "pnlSaoLuu";
            this.pnlSaoLuu.Padding = new System.Windows.Forms.Padding(24, 16, 24, 12);
            this.pnlSaoLuu.Size = new System.Drawing.Size(988, 175);
            this.pnlSaoLuu.TabIndex = 0;
            // 
            // lblSaoLuuDuLieu
            // 
            this.lblSaoLuuDuLieu.AutoSize = true;
            this.lblSaoLuuDuLieu.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSaoLuuDuLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblSaoLuuDuLieu.Location = new System.Drawing.Point(20, 14);
            this.lblSaoLuuDuLieu.Name = "lblSaoLuuDuLieu";
            this.lblSaoLuuDuLieu.Size = new System.Drawing.Size(140, 25);
            this.lblSaoLuuDuLieu.TabIndex = 0;
            this.lblSaoLuuDuLieu.Text = "Sao lưu dữ liệu";
            // 
            // pnlThuMucMacDinh
            // 
            this.pnlThuMucMacDinh.Controls.Add(this.lblThuMucMacDinh);
            this.pnlThuMucMacDinh.Controls.Add(this.txtThuMucSaoLuuMacDinh);
            this.pnlThuMucMacDinh.Controls.Add(this.pnlChonThuMuc);
            this.pnlThuMucMacDinh.Controls.Add(this.lblGoiYThuMuc);
            this.pnlThuMucMacDinh.Location = new System.Drawing.Point(20, 42);
            this.pnlThuMucMacDinh.Name = "pnlThuMucMacDinh";
            this.pnlThuMucMacDinh.Size = new System.Drawing.Size(940, 78);
            this.pnlThuMucMacDinh.TabIndex = 1;
            // 
            // lblThuMucMacDinh
            // 
            this.lblThuMucMacDinh.AutoSize = true;
            this.lblThuMucMacDinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblThuMucMacDinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblThuMucMacDinh.Location = new System.Drawing.Point(0, 4);
            this.lblThuMucMacDinh.Name = "lblThuMucMacDinh";
            this.lblThuMucMacDinh.Size = new System.Drawing.Size(192, 21);
            this.lblThuMucMacDinh.TabIndex = 0;
            this.lblThuMucMacDinh.Text = "Thư mục sao lưu mặc định";
            // 
            // txtThuMucSaoLuuMacDinh
            // 
            this.txtThuMucSaoLuuMacDinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtThuMucSaoLuuMacDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThuMucSaoLuuMacDinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtThuMucSaoLuuMacDinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtThuMucSaoLuuMacDinh.Location = new System.Drawing.Point(0, 26);
            this.txtThuMucSaoLuuMacDinh.Name = "txtThuMucSaoLuuMacDinh";
            this.txtThuMucSaoLuuMacDinh.Size = new System.Drawing.Size(540, 29);
            this.txtThuMucSaoLuuMacDinh.TabIndex = 1;
            this.txtThuMucSaoLuuMacDinh.Text = "D:\\QuanLyChiTieu\\SaoLuu";
            // 
            // pnlChonThuMuc
            // 
            this.pnlChonThuMuc.Controls.Add(this.btnDuyetThuMuc);
            this.pnlChonThuMuc.Location = new System.Drawing.Point(548, 24);
            this.pnlChonThuMuc.Name = "pnlChonThuMuc";
            this.pnlChonThuMuc.Size = new System.Drawing.Size(100, 32);
            this.pnlChonThuMuc.TabIndex = 2;
            // 
            // btnDuyetThuMuc
            // 
            this.btnDuyetThuMuc.BackColor = System.Drawing.Color.White;
            this.btnDuyetThuMuc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnDuyetThuMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyetThuMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDuyetThuMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDuyetThuMuc.Location = new System.Drawing.Point(0, 1);
            this.btnDuyetThuMuc.Name = "btnDuyetThuMuc";
            this.btnDuyetThuMuc.Size = new System.Drawing.Size(90, 27);
            this.btnDuyetThuMuc.TabIndex = 0;
            this.btnDuyetThuMuc.Text = "Duyệt...";
            this.btnDuyetThuMuc.UseVisualStyleBackColor = false;
            // 
            // lblGoiYThuMuc
            // 
            this.lblGoiYThuMuc.AutoSize = true;
            this.lblGoiYThuMuc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblGoiYThuMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblGoiYThuMuc.Location = new System.Drawing.Point(0, 56);
            this.lblGoiYThuMuc.Name = "lblGoiYThuMuc";
            this.lblGoiYThuMuc.Size = new System.Drawing.Size(439, 20);
            this.lblGoiYThuMuc.TabIndex = 3;
            this.lblGoiYThuMuc.Text = "Các bản sao lưu thủ công và tự động sẽ được lưu vào thư mục này.";
            // 
            // chkTuDongSaoLuuKhiThoat
            // 
            this.chkTuDongSaoLuuKhiThoat.AutoSize = true;
            this.chkTuDongSaoLuuKhiThoat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkTuDongSaoLuuKhiThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.chkTuDongSaoLuuKhiThoat.Location = new System.Drawing.Point(20, 135);
            this.chkTuDongSaoLuuKhiThoat.Name = "chkTuDongSaoLuuKhiThoat";
            this.chkTuDongSaoLuuKhiThoat.Size = new System.Drawing.Size(208, 25);
            this.chkTuDongSaoLuuKhiThoat.TabIndex = 2;
            this.chkTuDongSaoLuuKhiThoat.Text = "Tự động sao lưu khi thoát";
            this.chkTuDongSaoLuuKhiThoat.UseVisualStyleBackColor = true;
            // 
            // pnlNganSach
            // 
            this.pnlNganSach.BackColor = System.Drawing.Color.White;
            this.pnlNganSach.Controls.Add(this.lblCanhBaoNganSach);
            this.pnlNganSach.Controls.Add(this.pnlNguongCanhBao);
            this.pnlNganSach.Controls.Add(this.lblGiaiThichNguong);
            this.pnlNganSach.Location = new System.Drawing.Point(0, 180);
            this.pnlNganSach.Name = "pnlNganSach";
            this.pnlNganSach.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.pnlNganSach.Size = new System.Drawing.Size(988, 150);
            this.pnlNganSach.TabIndex = 1;
            // 
            // lblCanhBaoNganSach
            // 
            this.lblCanhBaoNganSach.AutoSize = true;
            this.lblCanhBaoNganSach.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCanhBaoNganSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblCanhBaoNganSach.Location = new System.Drawing.Point(20, 14);
            this.lblCanhBaoNganSach.Name = "lblCanhBaoNganSach";
            this.lblCanhBaoNganSach.Size = new System.Drawing.Size(184, 25);
            this.lblCanhBaoNganSach.TabIndex = 0;
            this.lblCanhBaoNganSach.Text = "Cảnh báo ngân sách";
            // 
            // pnlNguongCanhBao
            // 
            this.pnlNguongCanhBao.Controls.Add(this.lblNguongCanhBao);
            this.pnlNguongCanhBao.Controls.Add(this.txtNguongCanhBao);
            this.pnlNguongCanhBao.Controls.Add(this.lblPercent);
            this.pnlNguongCanhBao.Controls.Add(this.btnTang);
            this.pnlNguongCanhBao.Controls.Add(this.btnGiam);
            this.pnlNguongCanhBao.Controls.Add(this.lblNguongCanhBao2);
            this.pnlNguongCanhBao.Location = new System.Drawing.Point(20, 44);
            this.pnlNguongCanhBao.Name = "pnlNguongCanhBao";
            this.pnlNguongCanhBao.Size = new System.Drawing.Size(940, 40);
            this.pnlNguongCanhBao.TabIndex = 1;
            // 
            // lblNguongCanhBao
            // 
            this.lblNguongCanhBao.AutoSize = true;
            this.lblNguongCanhBao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNguongCanhBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblNguongCanhBao.Location = new System.Drawing.Point(0, 8);
            this.lblNguongCanhBao.Name = "lblNguongCanhBao";
            this.lblNguongCanhBao.Size = new System.Drawing.Size(209, 21);
            this.lblNguongCanhBao.TabIndex = 0;
            this.lblNguongCanhBao.Text = "Ngưỡng cảnh báo ngân sách";
            // 
            // txtNguongCanhBao
            // 
            this.txtNguongCanhBao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtNguongCanhBao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNguongCanhBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNguongCanhBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txtNguongCanhBao.Location = new System.Drawing.Point(190, 4);
            this.txtNguongCanhBao.Name = "txtNguongCanhBao";
            this.txtNguongCanhBao.Size = new System.Drawing.Size(55, 30);
            this.txtNguongCanhBao.TabIndex = 1;
            this.txtNguongCanhBao.Text = "80";
            this.txtNguongCanhBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblPercent.Location = new System.Drawing.Point(248, 7);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(24, 23);
            this.lblPercent.TabIndex = 2;
            this.lblPercent.Text = "%";
            // 
            // lblNguongCanhBao2
            // 
            this.lblNguongCanhBao2.AutoSize = true;
            this.lblNguongCanhBao2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNguongCanhBao2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblNguongCanhBao2.Location = new System.Drawing.Point(350, 9);
            this.lblNguongCanhBao2.Name = "lblNguongCanhBao2";
            this.lblNguongCanhBao2.Size = new System.Drawing.Size(103, 20);
            this.lblNguongCanhBao2.TabIndex = 5;
            this.lblNguongCanhBao2.Text = "Mặc định: 80%";
            // 
            // lblGiaiThichNguong
            // 
            this.lblGiaiThichNguong.AutoSize = true;
            this.lblGiaiThichNguong.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblGiaiThichNguong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblGiaiThichNguong.Location = new System.Drawing.Point(20, 95);
            this.lblGiaiThichNguong.Name = "lblGiaiThichNguong";
            this.lblGiaiThichNguong.Size = new System.Drawing.Size(450, 20);
            this.lblGiaiThichNguong.TabIndex = 2;
            this.lblGiaiThichNguong.Text = "Hiển thị cảnh báo khi chi tiêu đạt từ 80% hạn mức ngân sách trở lên.";
            // 
            // pnlBottomButtons
            // 
            this.pnlBottomButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottomButtons.Controls.Add(this.btnLuuThayDoi);
            this.pnlBottomButtons.Controls.Add(this.btnHuy);
            this.pnlBottomButtons.Location = new System.Drawing.Point(28, 410);
            this.pnlBottomButtons.Name = "pnlBottomButtons";
            this.pnlBottomButtons.Size = new System.Drawing.Size(990, 50);
            this.pnlBottomButtons.TabIndex = 2;
            // 
            // btnLuuThayDoi
            // 
            this.btnLuuThayDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnLuuThayDoi.FlatAppearance.BorderSize = 0;
            this.btnLuuThayDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuThayDoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLuuThayDoi.ForeColor = System.Drawing.Color.White;
            this.btnLuuThayDoi.Location = new System.Drawing.Point(20, 8);
            this.btnLuuThayDoi.Name = "btnLuuThayDoi";
            this.btnLuuThayDoi.Size = new System.Drawing.Size(130, 34);
            this.btnLuuThayDoi.TabIndex = 0;
            this.btnLuuThayDoi.Text = "Lưu thay đổi";
            this.btnLuuThayDoi.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnHuy.Location = new System.Drawing.Point(160, 8);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 34);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnTang
            // 
            this.btnTang.BackColor = System.Drawing.Color.White;
            this.btnTang.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnTang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTang.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnTang.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoChiTieu_XanhDuong;
            this.btnTang.Location = new System.Drawing.Point(275, 4);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new System.Drawing.Size(28, 25);
            this.btnTang.TabIndex = 3;
            this.btnTang.UseVisualStyleBackColor = false;
            // 
            // btnGiam
            // 
            this.btnGiam.BackColor = System.Drawing.Color.White;
            this.btnGiam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnGiam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiam.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnGiam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnGiam.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoThemThuNhap_XanhDuong;
            this.btnGiam.Location = new System.Drawing.Point(308, 4);
            this.btnGiam.Name = "btnGiam";
            this.btnGiam.Size = new System.Drawing.Size(28, 25);
            this.btnGiam.TabIndex = 4;
            this.btnGiam.UseVisualStyleBackColor = false;
            // 
            // frmCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 600);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmCauHinh";
            this.Text = "Quản Lý Chi Tiêu — Cấu hình";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlCauHinh.ResumeLayout(false);
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
