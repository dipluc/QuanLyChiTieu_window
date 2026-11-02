namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    partial class frmXacNhanPhucHoi
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.lblTenTep = new System.Windows.Forms.Label();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lblCanhBao.Location = new System.Drawing.Point(22, 22);
            this.lblCanhBao.Size = new System.Drawing.Size(468, 30);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.TabIndex = 0;
            this.lblCanhBao.Text = "⚠  Toàn bộ dữ liệu hiện tại sẽ bị thay thế";
            this.lblCanhBao.AutoSize = false;
            this.lblCanhBao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCanhBao.ForeColor = System.Drawing.Color.FromArgb(30, 47, 70);
            this.lblNoiDung.Location = new System.Drawing.Point(22, 65);
            this.lblNoiDung.Size = new System.Drawing.Size(466, 55);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.TabIndex = 1;
            this.lblNoiDung.Text = "Phục hồi bản sao lưu này sẽ ghi đè toàn bộ dữ liệu hiện tại. Các thay đổi sau thời điểm sao lưu sẽ bị mất và không thể hoàn tác.";
            this.lblNoiDung.AutoSize = false;
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblNoiDung.ForeColor = System.Drawing.Color.FromArgb(30, 47, 70);
            this.lblTenTep.Location = new System.Drawing.Point(22, 132);
            this.lblTenTep.Size = new System.Drawing.Size(465, 24);
            this.lblTenTep.Name = "lblTenTep";
            this.lblTenTep.TabIndex = 2;
            this.lblTenTep.Text = "ChiTieu_26-10-2026_0830.bak";
            this.lblTenTep.AutoSize = false;
            this.lblTenTep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTenTep.ForeColor = System.Drawing.Color.FromArgb(30, 47, 70);
            this.lblThongTin.Location = new System.Drawing.Point(22, 160);
            this.lblThongTin.Size = new System.Drawing.Size(465, 22);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.TabIndex = 3;
            this.lblThongTin.Text = "Ngày tạo: 26/10/2026 08:30 • Dung lượng: 4,8 MB";
            this.lblThongTin.AutoSize = false;
            this.lblThongTin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblThongTin.ForeColor = System.Drawing.Color.FromArgb(115, 131, 153);
            this.lblLuuY.Location = new System.Drawing.Point(22, 194);
            this.lblLuuY.Size = new System.Drawing.Size(465, 22);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.TabIndex = 4;
            this.lblLuuY.Text = "Nên sao lưu dữ liệu hiện tại trước khi tiếp tục.";
            this.lblLuuY.AutoSize = false;
            this.lblLuuY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblLuuY.ForeColor = System.Drawing.Color.FromArgb(115, 131, 153);
            this.btnHuy.Location = new System.Drawing.Point(280, 239);
            this.btnHuy.Size = new System.Drawing.Size(95, 32);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(30, 47, 70);
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(223, 229, 238);
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPhucHoi.Location = new System.Drawing.Point(387, 239);
            this.btnPhucHoi.Size = new System.Drawing.Size(100, 32);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.TabIndex = 6;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhucHoi.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnPhucHoi.ForeColor = System.Drawing.Color.White;
            this.btnPhucHoi.UseVisualStyleBackColor = false;
            this.btnPhucHoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnPhucHoi.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.btnPhucHoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.Controls.Add(this.lblCanhBao);
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.lblTenTep);
            this.Controls.Add(this.lblThongTin);
            this.Controls.Add(this.lblLuuY);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnPhucHoi);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 286);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            this.Name = "frmXacNhanPhucHoi";
            this.Text = "Xác nhận phục hồi dữ liệu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.CancelButton = this.btnHuy;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label lblTenTep;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Label lblLuuY;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnPhucHoi;
    }
}
