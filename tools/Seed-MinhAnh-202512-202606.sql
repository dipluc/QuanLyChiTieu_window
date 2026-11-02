SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRANSACTION;
DECLARE @MaND int;
IF (SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap=N'minhanh') <> 1
    THROW 50001, 'Expected exactly one minhanh account.', 1;
SELECT @MaND=MaND FROM NguoiDung WHERE TenDangNhap=N'minhanh';
IF NOT EXISTS (SELECT 1 FROM ViTien WHERE MaVi=2 AND MaND=@MaND)
    THROW 50002, 'Expected wallet not found.', 1;
DECLARE @i int=0, @Thang date='20251201';
WHILE @i<7
BEGIN
    INSERT INTO ThuNhap (MaND,MaVi,MaLoaiThu,NgayThu,SoTien,GhiChu)
    SELECT @MaND,2,v.Loai,DATEADD(day,v.Ngay,@Thang),v.Tien,
           N'[DEMO-MA-202512-202606] '+v.GhiChu
    FROM (VALUES
        (1,4,CAST(18000000+@i*500000 AS decimal(18,2)),N'Luong mau'),
        (2,19,CAST(1000000+(@i%3)*750000 AS decimal(18,2)),N'Thuong mau')
    ) v(Loai,Ngay,Tien,GhiChu)
    WHERE NOT EXISTS (
        SELECT 1 FROM ThuNhap t WHERE t.MaND=@MaND
        AND t.NgayThu=DATEADD(day,v.Ngay,@Thang)
        AND t.GhiChu=N'[DEMO-MA-202512-202606] '+v.GhiChu);

    INSERT INTO ChiTieu (MaND,MaVi,MaLoaiChi,NgayChi,SoTien,GhiChu)
    SELECT @MaND,2,v.Loai,DATEADD(day,v.Ngay,@Thang),v.Tien,
           N'[DEMO-MA-202512-202606] '+v.GhiChu
    FROM (VALUES
        (7,1,CAST(4500000 AS decimal(18,2)),N'Nha o mau'),
        (1,9,CAST(2800000+@i*150000 AS decimal(18,2)),N'An uong mau'),
        (6,14,CAST(600000+(@i%3)*100000 AS decimal(18,2)),N'Di chuyen mau'),
        (8,21,CAST(900000+(@i%4)*350000 AS decimal(18,2)),N'Mua sam mau'),
        (10,24,CAST(400000+@i*80000 AS decimal(18,2)),N'Chi khac mau')
    ) v(Loai,Ngay,Tien,GhiChu)
    WHERE NOT EXISTS (
        SELECT 1 FROM ChiTieu t WHERE t.MaND=@MaND
        AND t.NgayChi=DATEADD(day,v.Ngay,@Thang)
        AND t.GhiChu=N'[DEMO-MA-202512-202606] '+v.GhiChu);
    SET @i=@i+1;
    SET @Thang=DATEADD(month,1,@Thang);
END;
COMMIT;

SELECT CONVERT(char(7),Ngay,120) AS Thang,
       SUM(Thu) AS ThuMau,SUM(Chi) AS ChiMau,COUNT(*) AS SoGiaoDichMau
FROM (
    SELECT NgayThu AS Ngay,SoTien AS Thu,CAST(0 AS decimal(18,2)) AS Chi
    FROM ThuNhap WHERE MaND=@MaND AND GhiChu LIKE N'[[]DEMO-MA-202512-202606]%'
    UNION ALL
    SELECT NgayChi,0,SoTien FROM ChiTieu
    WHERE MaND=@MaND AND GhiChu LIKE N'[[]DEMO-MA-202512-202606]%'
) gd
GROUP BY CONVERT(char(7),Ngay,120)
ORDER BY Thang;
