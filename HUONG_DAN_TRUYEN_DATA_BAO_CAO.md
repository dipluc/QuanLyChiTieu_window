# Truyền dữ liệu cho 5 form báo cáo và sao lưu

Phần đã lập trình và kiểm tra trong lần này: biểu đồ thu chi 12 tháng và xuất Excel/PDF trực tiếp tại `frmBieuDo`.
Bốn form còn lại hiện vẫn chủ yếu là giao diện; các bước bên dưới là hướng dẫn để bạn tự nối tiếp, không phải thông báo rằng chúng đã hoạt động.

## 1. Hiểu đường đi dữ liệu

```text
SQL Server → DuLieu/ThongKeDL.cs → NghiepVu/ThongKeNV.cs → Form
Phiên đăng nhập → PhienDangNhap.MaND ────────────────────┘
Form cha → constructor (kỳ xem / tùy chọn xuất / đường dẫn file) → Form con
```

`MaND` lấy từ `PhienDangNhap.MaND`, không nhập tay và không dùng tên đăng nhập để lọc SQL. Form truyền điều kiện xem cho tầng nghiệp vụ; tầng dữ liệu luôn lọc `MaND` bằng `SqlParameter`.

Với thống kê tháng, dùng khoảng `[ngày đầu tháng, ngày đầu tháng sau)`. Cách này lấy được cả giao dịch có giờ vào ngày cuối tháng.

Không lấy số liệu từ chuỗi Label như `"25.000.000 đ"`. Giữ dữ liệu bằng `decimal`, `DateTime`, `DataTable` hoặc model; chỉ định dạng khi hiển thị/xuất.

## 2. frmBieuDo — đã làm

Biểu đồ ở màn hình chính thực tế nằm trong `Forms/Chinh/frmDashboard.cs`, được `frmMain` nhúng vào vùng nội dung. Hàm cũ `NapThuChi12Thang` dùng tháng đang xem và 11 tháng trước; form biểu đồ hiện dùng cùng quy tắc.

### Bước 1: lấy tổng thu chi theo tháng

Đã thêm `ThongKeDL.LayThuChiTheoThang(maND, tuNgay, denNgay)`. Truy vấn gộp `ThuNhap` và `ChiTieu` bằng `UNION ALL`, sau đó nhóm theo tháng/năm. Không JOIN trực tiếp hai bảng giao dịch, vì có thể làm nhân đôi tổng tiền.

Kết quả có 3 cột:

| Cột | Kiểu | Ý nghĩa |
|---|---|---|
| `Thang` | `DateTime` | Ngày đầu tháng |
| `TongThu` | `decimal` | Thu nhập tháng |
| `TongChi` | `decimal` | Chi tiêu tháng |

### Bước 2: bảo đảm luôn có 12 tháng

Đã thêm `ThongKeNV.LayThuChi12Thang(maND, kyCuoi)`. Hàm điền 0 vào tháng không có giao dịch và sắp xếp từ cũ đến mới.

Ví dụ chọn **11/2026** thì kết quả từ **12/2025 đến 11/2026**, gồm cả tháng được chọn. Đây là 12 tháng kết thúc tại kỳ xem, không cố định tháng 1–12 của cùng năm.

### Bước 3: đưa dữ liệu lên Chart

Trong `frmBieuDo.TaiBieuDo()`, đã gọi `TaiThuChi12Thang(maND, ky)`. Hàm này xóa điểm cũ của hai series `Thu`, `Chi`, rồi thêm 12 cặp điểm. Trục Y và tooltip đều dùng **đồng**, không còn nhãn triệu đồng trong khi dữ liệu là đồng.

Ba bảng được giữ trong form:

```csharp
private DataTable _chiTheoLoai;
private DataTable _chiLuyKe;
private DataTable _thuChi12Thang;
```

### Bước 4: xuất trực tiếp ở frmBieuDo

Hai nút `btnXuatExcel`, `btnXuatPdf` đã nối đến `XuatBieuDo`. Khi bấm:

1. Tải lại dữ liệu của kỳ đang chọn; dừng nếu tải thất bại.
2. Mở `SaveFileDialog` để chọn tên/vị trí file.
3. Truyền 3 bảng và 3 Chart vào `Services/XuatBieuDoService.cs`.
4. Hiển thị đường dẫn sau khi xuất thành công.

Excel `.xlsx` có 3 sheet: **Chi theo loại**, **Chi lũy kế**, **Thu chi 12 tháng**. Mỗi sheet có số liệu và ảnh biểu đồ. Số tiền là ô số, ngày/tháng là ô ngày; có thể tiếp tục tính toán trong Excel.

PDF có ít nhất 3 trang tương ứng ba biểu đồ, kèm bảng số liệu. Bảng nhiều dòng tự sang trang. Cột văn bản quá dài trong PDF được rút gọn bằng dấu `…`; Excel giữ nguyên văn bản.

Thư viện đã thêm vào project: `ClosedXML 0.104.2`, `PDFsharp-GDI 6.2.4`. Restore NuGet trước khi build. Không cần cài Microsoft Excel để xuất.

## 3. frmBaoCaoThang — nối tiếp theo thứ tự này

### Bước 1: tạo hàm TaiBaoCaoThang()

Trong `frmBaoCaoThang.cs`, thêm `using NghiepVu;`, `using NghiepVu.TienIch;`, `using System.Globalization;`.

Đầu hàm kiểm tra `PhienDangNhap.DaDangNhap`, sau đó lấy dữ liệu:

```csharp
int maND = PhienDangNhap.MaND;
DateTime ky = dtpThangBaoCao.Value;
var tong = ThongKeNV.LayTongQuanThang(maND, ky.Month, ky.Year);
var nganSach = ThongKeNV.LayCanhBaoNganSachThang(maND, ky.Month, ky.Year);
DataTable chiTheoLoai = ThongKeNV.LayChiTheoLoaiThang(maND, ky.Month, ky.Year);
var viVN = CultureInfo.GetCultureInfo("vi-VN");

lblTongThu.Text = tong.TongThu.ToString("N0", viVN) + " đ";
lblTongChi.Text = tong.TongChi.ToString("N0", viVN) + " đ";
lblTongTietKiem.Text = tong.ChenhLech.ToString("N0", viVN) + " đ";
lblMoTaTietKiem.Text = "Tổng thu − Tổng chi • "
    + tong.TyLeTietKiem.ToString("N1", viVN) + "% thu nhập";
lblPhamVi.Text = "Tất cả ví • Kỳ " + ky.ToString("MM/yyyy");
```

Đặt thao tác tải trong `try/catch`, hiển thị lỗi và không giữ lại các con số minh họa khi tải thất bại.

### Bước 2: đổ lvChiTiet

`lvChiTiet` hiện có 5 cột: **Danh mục, Hạn mức, Đã chi, Còn lại, %**. Xóa `Items` minh họa trước khi thêm dòng thật.

Lấy hợp các `MaLoaiChi` từ `nganSach` và `chiTheoLoai` để bao gồm cả danh mục chưa đặt ngân sách. Ghép bằng mã loại, tránh ghép bằng tên.

| Cột giao diện | Dữ liệu |
|---|---|
| Danh mục | `TenLoaiChi` |
| Hạn mức | `NganSachMH.HanMuc`; chưa có ngân sách thì `—` |
| Đã chi | `chiTheoLoai.TongChi`; không có giao dịch thì 0 |
| Còn lại | `HanMuc - DaChi`; chưa có ngân sách thì `—` |
| % | `DaChi * 100m / HanMuc` khi hạn mức > 0; còn lại hiển thị `—` |

Ví dụ thêm một dòng có ngân sách:

```csharp
var item = new ListViewItem(ns.TenLoaiChi);
item.SubItems.Add(ns.HanMuc.ToString("N0", viVN));
item.SubItems.Add(ns.DaChi.ToString("N0", viVN));
item.SubItems.Add(ns.ConLai.ToString("N0", viVN));
item.SubItems.Add(ns.HanMuc > 0
    ? ns.PhanTram.ToString("N1", viVN) + "%" : "—");
item.Tag = ns.MaLoaiChi;
lvChiTiet.Items.Add(item);
```

`ns` ở ví dụ là một phần tử của `nganSach`. Bổ sung riêng các loại trong `chiTheoLoai` không xuất hiện ở danh sách ngân sách.

Tính lại `lblGhiChu`, `lblCanhBao`, `lblMoTaChi`, `lblHuongDan` bằng dữ liệu thật. Nếu không có hạn mức thì hiển thị “Chưa đặt ngân sách”. Tổng ngân sách còn lại và khoản tiết kiệm là hai số khác nhau. Khi tính tỷ lệ sử dụng tổng hạn mức, chỉ cộng chi thuộc các danh mục có ngân sách.

### Bước 3: gắn sự kiện

Sau `InitializeComponent()`:

```csharp
dtpThangBaoCao.Value = DateTime.Today;
Load += (s, e) => TaiBaoCaoThang();
dtpThangBaoCao.ValueChanged += (s, e) => TaiBaoCaoThang();
```

Nếu sau này dùng bộ lọc tháng của `frmMain`, triển khai `Forms.IDongBoThang`. `frmMain.MoFormCon()` đã gọi `DongBoThang(dtpThang.Value)` cho form hỗ trợ interface này. Hiện trang báo cáo mở ở chế độ ẩn bộ lọc chung, nên DateTimePicker riêng vẫn là nơi chọn kỳ.

### Bước 4: truyền kỳ khi bấm Xuất

Hiện `btnXuat_Click` chỉ truyền tùy chọn PDF/Excel, chưa truyền tháng. Thêm tham số ngày tùy chọn vào `frmXuatBaoCao`, và truyền tiếp qua `frmMain.MoFormXuatBaoCao` ở cả nhánh nhúng lẫn nhánh `ShowDialog`.

Chữ ký đề xuất, cần tự bổ sung vào code trước khi gọi:

```csharp
public frmXuatBaoCao(bool xuatPdf, DateTime? kyBaoCao) : this()
{
    rdoPdf.Checked = xuatPdf;
    rdoExcel.Checked = !xuatPdf;
    DateTime ky = kyBaoCao ?? DateTime.Today;
    dtpTuNgay.Value = new DateTime(ky.Year, ky.Month, 1);
    dtpDenNgay.Value = dtpTuNgay.Value.AddMonths(1).AddDays(-1);
}
```

Giữ constructor không tham số cho Designer và các chỗ gọi hiện có. Constructor `frmXuatBaoCao(bool)` có thể chuyển tiếp sang constructor mới.

## 4. frmXuatBaoCao — truyền điều kiện, rồi tự tải dữ liệu

1. Khi mở form, khởi tạo khoảng ngày thực tế; xóa tên file cố định năm 2026. Nếu mở từ báo cáo tháng, dùng kỳ đã truyền ở bước trên.
2. Gắn `btnDuyet` với `FolderBrowserDialog`; kết quả đưa vào `txtThuMucLuu`.
3. Khi đổi loại báo cáo, khoảng ngày hoặc định dạng, cập nhật `lblTenTepDuKien`. Ví dụ `GiaoDich_20261101_20261130.xlsx`.
4. Khi bấm `btnXuat`, kiểm tra đã đăng nhập, `TuNgay <= DenNgay`, thư mục hợp lệ và khoảng ngày phù hợp loại báo cáo.
5. Tải dữ liệu theo lựa chọn trong `cboLoaiBaoCao`, sau đó mới xuất file và xử lý `chkMoTep`.

| Lựa chọn | Nguồn dữ liệu hiện có |
|---|---|
| Giao dịch | `DataService.GetThuNhap(tu, den)` và `DataService.GetChiTieu(tu, den)`; ghép thành bảng có loại Thu/Chi, ngày, danh mục, ví, số tiền, ghi chú |
| Thống kê | Tổng theo tháng trong phạm vi ngày; nếu cho phép ngày lẻ thì phải truy vấn theo khoảng ngày chính xác, không dùng tổng cả tháng |
| Ngân sách | Với mỗi tháng được chọn, dùng `ThongKeNV.LayCanhBaoNganSachThang`; thêm tháng/năm vào mỗi dòng để phân biệt các kỳ |

Quy ước đề xuất cho Ngân sách: chọn một hoặc nhiều **tháng trọn vẹn**, hiển thị rõ phạm vi đó; tránh so chi vài ngày với hạn mức cả tháng mà không giải thích.

Với API `DataService.GetThuNhap/GetChiTieu`, `denNgay` được hiểu là ngày cuối **có bao gồm trong kết quả** và service tự đổi sang ngày hôm sau. Truyền `DateTime.Date` của ngày cuối, không cộng thêm một ngày lần nữa. Nếu dùng `TimKiemGiaoDich`, phần lọc bổ sung hiện so sánh giờ trực tiếp với `denNgay`; cần sửa thống nhất khoảng ngày trước khi dùng cho xuất toàn ngày.

`XuatBieuDoService` hiện phục vụ ba bảng + Chart của `frmBieuDo`. Để xuất bảng giao dịch/ngân sách bất kỳ, tách thêm hàm xuất bảng dùng chung nhận `DataTable`, tiêu đề và tên cột, sử dụng cùng ClosedXML/PDFsharp. Không truyền bảng giao dịch vào hàm đang yêu cầu các cột `TenLoaiChi`, `ChiLuyKe`, `TongThu`.

Nếu file đã tồn tại thì cho người dùng chọn ghi đè hoặc đổi tên. Lưu file thành công trước khi mở bằng `Process.Start(new ProcessStartInfo(path) { UseShellExecute = true })`. Nếu mở file thất bại, thông báo file đã lưu và chỉ việc mở thất bại.

## 5. frmSaoLuu — truyền đường dẫn file đã chọn

### Bước 1: nạp danh sách file thật

Khi form Load, đọc `DataService.GetCauHinh().ThuMucSaoLuu` vào `txtThuMucSaoLuu`, kiểm tra thư mục tồn tại rồi liệt kê các file `.bak`. Không dùng các dòng minh họa trong Designer.

Mỗi `ListViewItem` hiển thị tên, ngày ghi file, dung lượng và hình thức sao lưu. Gán **đường dẫn tuyệt đối** vào `item.Tag`:

```csharp
var info = new System.IO.FileInfo(duongDan);
var item = new ListViewItem(info.Name);
item.SubItems.Add(info.LastWriteTime.ToString("dd/MM/yyyy HH:mm"));
item.SubItems.Add((info.Length / 1024d / 1024d).ToString("N2") + " MB");
item.SubItems.Add("—"); // Chỉ ghi Tự động/Thủ công khi có metadata xác thực.
item.Tag = info.FullName;
lvSaoLuu.Items.Add(item);
```

Ngày ghi file không nhất thiết là thời điểm backup. Muốn hiển thị ngày backup chính xác, đọc metadata backup từ SQL Server. Cập nhật `lblSoLuong`, `lblDaChon` theo danh sách thật.

### Bước 2: nút Sao lưu

Thêm tầng dữ liệu/nghiệp vụ chuyên sao lưu, ví dụ `SaoLuuDL` và `SaoLuuNV` (chưa tồn tại trong code hiện tại). Sao lưu database đang kết nối bằng SQL Server `BACKUP DATABASE`, không sao chép riêng MDF khi database còn mở. Lấy đúng database từ connection hiện tại, tạo tên file duy nhất, thực hiện xong mới tải lại danh sách.

Đường dẫn backup được SQL Server đọc/ghi. Với LocalDB đang dùng thì thường là máy cục bộ; nếu đổi sang SQL Server ở máy khác, đường dẫn này thuộc máy SQL Server.

### Bước 3: nút Phục hồi

Chỉ bật khi đã chọn đúng một file. Thay việc mở hộp thoại không tham số hiện tại bằng luồng sau sau khi bổ sung constructor ở mục 6:

```csharp
if (lvSaoLuu.SelectedItems.Count != 1) return;
string path = lvSaoLuu.SelectedItems[0].Tag as string;
if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path)) return;

using (var form = new frmXacNhanPhucHoi(path))
{
    if (form.ShowDialog(TopLevelControl) != DialogResult.OK) return;
    // Gọi service phục hồi với form.DuongDanSaoLuu tại đây.
    // Chỉ báo thành công sau khi service hoàn tất.
}
```

Không lấy đường dẫn bằng cách cắt `lblDaChon.Text`, cũng không ghép lại từ tên file nếu đã giữ `FullName` trong Tag.

## 6. frmXacNhanPhucHoi — constructor nhận file, DialogResult trả quyết định

Giữ constructor không tham số cho Designer. Thêm constructor và property:

```csharp
public string DuongDanSaoLuu { get; private set; }

public frmXacNhanPhucHoi(string duongDan) : this()
{
    var info = new System.IO.FileInfo(System.IO.Path.GetFullPath(duongDan));
    if (!info.Exists) throw new System.IO.FileNotFoundException("Không tìm thấy bản sao lưu.", info.FullName);
    DuongDanSaoLuu = info.FullName;
    lblTenTep.Text = "Tệp: " + info.Name;
    lblThongTin.Text = "Ngày ghi tệp: " + info.LastWriteTime.ToString("dd/MM/yyyy HH:mm")
        + " • " + (info.Length / 1024d / 1024d).ToString("N2") + " MB";
    btnPhucHoi.Click += (s, e) =>
    {
        DialogResult = DialogResult.OK;
        Close();
    };
}
```

`btnHuy` đã có `DialogResult.Cancel` trong Designer. Hộp thoại chỉ xác nhận đúng file; `frmSaoLuu` gọi service để thực hiện phục hồi sau khi nhận OK.

Trong service phục hồi cần kiểm tra bản sao lưu bằng SQL Server, tạo bản sao trước phục hồi nếu muốn có đường quay lại, giải phóng connection pool, kết nối `master` để phục hồi database đích, và xử lý trạng thái truy cập database trong cả trường hợp lỗi. Nếu vị trí MDF/LDF trong backup khác máy hiện tại, cần ánh xạ file đích phù hợp. Đây là phục hồi **toàn bộ database**, bao gồm dữ liệu của các tài khoản khác, nên kiểm tra quyền quản trị ở cả UI và nghiệp vụ.

Sau khi phục hồi thành công, xóa phiên và yêu cầu đăng nhập lại; không giữ `MaND`/quyền cũ vì database vừa thay đổi. Không tự chạy phục hồi chỉ vì form được mở hoặc file được chọn.

Trong `frmMain`, menu `mnuSaoLuuDuLieu` hiện đang mở `frmCauHinh`; khi làm xong trang này, đổi để mở `frmSaoLuu` như menu phục hồi.

## 7. Cách chạy kiểm tra phần đã làm

```powershell
dotnet restore .\LTWIN_N05_QLCT\GUI.csproj
dotnet build .\LTWIN_N05_QLCT\GUI.csproj --no-restore
.\tools\Test-BieuDo.ps1
```

`tools/LegacyNuGet.targets` bổ sung giải quyết PackageReference khi build project WinForms cũ bằng `dotnet`; Visual Studio dùng cơ chế NuGet riêng.

Probe chỉ đọc database, đối chiếu 12 tháng với tổng từng tháng cho các tài khoản hiện có, kiểm tra qua năm, rồi tạo và đọc lại XLSX/PDF cho kỳ có dữ liệu và kỳ trống. File thử nằm trong `LTWIN_N05_QLCT/bin/Debug/BieuDoProbe_*.xlsx` và `.pdf`.

Kiểm tra thủ công: mở **Báo cáo → Biểu đồ**, chọn kỳ, bấm **Xem biểu đồ**, xác nhận đủ 12 nhãn tháng, rồi bấm từng nút xuất. Chọn hủy ở hộp lưu phải quay về form mà không báo xuất thành công.

Tài liệu thư viện: [ClosedXML](https://github.com/ClosedXML/ClosedXML/blob/develop/docs/installation.rst), [PDFsharp GDI và NuGet](https://docs.pdfsharp.net/General/Overview/NuGet-Packages.html).
