from pathlib import Path
import re
for p in Path('document_review/ERD').glob('*.dot'):
 s=p.read_text(encoding='utf8').replace('nodesep=0.65, ranksep=1.5, splines=polyline','nodesep=0.5, ranksep=1.1, splines=spline')
 s=re.sub(r'taillabel="([^"]+)",headlabel="([^"]+)",labeldistance=2.2',lambda m:'label="'+m[1]+' → '+m[2]+'"',s)
 s=s[:-1]+'\n{rank=same; NguoiDung;}\n{rank=same; CauHinh; MucTieu; ViTien; LoaiThu; NhomChi;}\n{rank=same; ChuyenTien; ThuNhap; LoaiChi;}\n{rank=same; ChiTieu; GiaoDichDinhKy; NganSach;}\n}'
 p.write_text(s,encoding='utf8')
