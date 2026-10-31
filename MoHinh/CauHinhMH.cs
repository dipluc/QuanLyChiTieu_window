using System;

namespace MoHinh
{
    public class CauHinhMH
    {
        public int MaND { get; set; }
        public string ThuMucSaoLuu { get; set; }
        public int NguongCanhBao { get; set; } = 80; // 80% mac dinh
        public bool TuDongSaoLuu { get; set; } = false;

        public CauHinhMH() { }
    }
}
