--Bài tập thực hành tại lớp: BÀI TẬP QUẢN LÝ BÁN SÁCH
--Đào Minh Quân_221230966_N04
--View
--1. Tạo view in ra danh sách các sách của nhà xuất bản giáo dục nhập trong năm 2024 
create view SachNXBGiaoDuc as
select b.MaSach, b.TenSach
from tSach b join tNhaXuatBan nxb on b.MaNXB = nxb.MaNXB
join tChiTietHDN ct on b.MaSach = ct.MaSach 
join tHoaDonNhap hdn on ct.SoHDN = hdn.SoHDN
where nxb.TenNXB = N'NXB Giáo Dục' and year(hdn.NgayNhap) = 2021
--Gọi view
select * from SachNXBGiaoDuc

--2. Tạo view thống kê các sách không bán được trong năm 2024 
create view SachKhongBanDuoc as
select ts.MaSach, ts.TenSach
from tSach ts
where ts.MaSach not in (
	select s.MaSach
	from tSach s join tChiTietHDB ct on s.MaSach = ct.MaSach 
	join tHoaDonBan n on ct.SoHDB = n.SoHDB
	where year(n.NgayBan) = 2024)
--Gọi view
select * from SachKhongBanDuoc

--3. Tạo view thống kê 10 khách hàng có tổng tiền tiêu dùng cao nhất trong năm 2021
alter view Top10KHTieuDung as
select top 10 kh.MaKH, kh.TenKH, sum(ct.SLBan*s.DonGiaBan) as TieuDung
from tKhachHang kh join tHoaDonBan b on kh.MaKH = b.MaKH
join tChiTietHDB ct on b.SoHDB=ct.SoHDB
join tSach s on ct.MaSach = s.MaSach
where year(b.NgayBan) = 2014
group by Kh.MaKH, kh.TenKH
order by TieuDung DESC
--Gọi view
select * from Top10KHTieuDung

--4. Tạo view thống kê số lượng sách bán ra trong năm 2021 và số lượng sách nhập trong năm 
--2021 và chênh lệch giữa hai số lượng này ứng với mỗi đầu sách 
create view BanNhapSach as
WITH Nhap AS (
    SELECT MaSach, SUM(SLNhap) AS SLNhap
    FROM tChiTietHDN JOIN tHoaDonNhap ON tChiTietHDN.SoHDN = tHoaDonNhap.SoHDN
    WHERE YEAR(NgayNhap) = 2021
    GROUP BY MaSach
),Ban AS (
    SELECT MaSach, SUM(SLBan) AS SLBan
    FROM tChiTietHDB JOIN tHoaDonBan ON tChiTietHDB.SoHDB = tHoaDonBan.SoHDB
    WHERE YEAR(NgayBan) = 2021
    GROUP BY MaSach
)
SELECT tSach.MaSach,ISNULL(N.SLNhap, 0)AS SLNhap,ISNULL(B.SLBan, 0)AS SLBan,
	ISNULL(B.SLBan, 0) - ISNULL(N.SLNhap, 0) AS Chenhlech
FROM tSach full join Ban B on tSach.MaSach=B.MaSach
full JOIN Nhap N ON N.MaSach = tSach.MaSach
--Gọi view
select * from BanNhapSach

--5. Tạo view đưa ra những thông tin hóa đơn và tổng tiền của hóa đơn đó trong ngày 
--16/11/2021 
create view HDtrongNgay as
SELECT H.SoHDB as SoHD ,H.NgayBan as Ngay, KH.TenKH,
    SUM(CT.SLBan * S.DonGiaBan) AS TongTien, N'Hoa don ban' as chitiet
FROM tHoaDonBan H
JOIN tChiTietHDB CT ON H.SoHDB = CT.SoHDB
JOIN tSach S ON CT.MaSach = S.MaSach
JOIN tKhachHang KH ON H.MaKH = KH.MaKH
WHERE H.NgayBan = '2021-05-03'
GROUP BY H.SoHDB, H.NgayBan, KH.TenKH
UNION ALL
SELECT H.SoHDN ,H.NgayNhap , CC.TenNCC,
    SUM(CT.SLNhap * S.DonGiaBan) AS TongTien, N'Hoa don nhap'
FROM tHoaDonNhap H
JOIN tChiTietHDN CT ON H.SoHDN = CT.SoHDN
JOIN tSach S ON CT.MaSach = S.MaSach
JOIN tNhaCungCap CC ON H.MaNCC = CC.MaNCC
WHERE H.NgayNhap = '2021-05-03'
GROUP BY H.SoHDN, H.NgayNhap, CC.TenNCC
--Gọi view
select * from HDtrongNgay

--6.  Tạo view đưa ra doanh thu bán hàng của từng tháng trong năm 2014, những tháng không 
--có doanh thu thì ghi là 0. 
create view DoanhThu2014 as
with ThangList as (
	select 1 as Thang union all select 2 union all select 3 union all
	select 4  union all select 5 union all select 6 union all
	select 7  union all select 8 union all select 9 union all
	select 10  union all select 11 union all select 12 )
select T.Thang, isnull(sum(ct.SLBan*s.DonGiaBan), 0) as DoanhThu
from Thanglist T left join tHoaDonBan HDB on T.Thang = MONTH(HDB.NgayBan) AND YEAR(HDB.NgayBan) = 2021
left join tChiTietHDB ct on HDB.SoHDB = ct.SoHDB
left join tSach s on ct.MaSach = s.MaSach
group by T.Thang
--Gọi view
select * from DoanhThu2014

--7. Tạo view đưa ra doanh thu bán hàng theo ngày, và tổng doanh thu cho mỗi tháng (dùng roll up) 
create view DoanhThuNgayThang as
SELECT DAY(tHoaDonBan.NgayBan) AS Ngay, MONTH(tHoaDonBan.NgayBan) AS Thang,
	YEAR(tHoaDonBan.NgayBan) AS Nam, SUM(tChiTietHDB.SLBan * tSach.DonGiaBan) AS DoanhThu
FROM  tHoaDonBan JOIN tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
JOIN tSach ON tSach.MaSach = tChiTietHDB.MaSach
GROUP BY ROLLUP(YEAR(tHoaDonBan.NgayBan), MONTH(tHoaDonBan.NgayBan), DAY(tHoaDonBan.NgayBan))
HAVING YEAR(tHoaDonBan.NgayBan) IS NOT NULL
--Gọi view
select * from DoanhThuNgayThang

--8. Tạo view đưa ra danh sách 3 khách hàng có tiền tiêu dùng cao nhất 
create view Top3KHTieuDung as
select top 3 Kh.MaKH, kh.TenKH, sum(ct.SLBan*s.DonGiaBan) as TieuDung 
from tKhachHang kh join tHoaDonBan HDB on kh.MaKH= HDB.MaKH
join tChiTietHDB ct on ct.SoHDB=HDB.SoHDB
join tSach s on s.MaSach=ct.MaSach
group by Kh.MaKH, kh.TenKH
order by TieuDung DESC
--Gọi view
select * from Top3KHTieuDung

--9. Tạo view đưa ra 10 đầu sách được tiêu thụ nhiều nhất trong năm 2022 và số lượng tiêu thụ 
--mỗi đầu sách.
create view Top10SachTieuThu as
select top 10 s.MaSach, s.TenSach, sum(ct.SLBan) as SLTieuThu
from tSach s join tChiTietHDB ct on s.MaSach = ct.MaSach
join tHoaDonBan hdb on hdb.SoHDB = ct.SoHDB and year(hdb.NgayBan)=2021
group by s.MaSach, s.TenSach
order by SLTieuThu desc

--10. Tạo view SachGD đưa ra danh sách các sách  với các thông tin MaSach,TenSach, tên 
--thể loại, tổng số lượng nhập, tổng số lượng bán, số lượng tồn do Nhà xuất bản Giáo Dục xuất bản.
create view SachGD as
WITH Nhap AS (
    SELECT s.MaSach, SUM(hd.SLNhap) AS SLNhap
    FROM tSach s 
    JOIN tChiTietHDN hd ON s.MaSach = hd.MaSach
    GROUP BY s.MaSach
), Ban AS (
    SELECT s.MaSach, SUM(hd.SLBan) AS SLBan
    FROM tSach s 
    JOIN tChiTietHDB hd ON s.MaSach = hd.MaSach
    GROUP BY s.MaSach
)
SELECT 
    tSach.MaSach, 
    tSach.TenSach, 
    tTheLoai.TenTheLoai, 
    isnull(Nhap.SLNhap,0) AS TongSoLuongNhap, 
    isnull(Ban.SLBan,0) AS TongSoLuongBan, 
    tSach.SoLuong AS SoLuongTon
FROM tSach JOIN tTheLoai ON tSach.MaTheLoai = tTheLoai.MaTheLoai
LEFT JOIN Nhap ON tSach.MaSach = Nhap.MaSach
LEFT JOIN Ban ON tSach.MaSach = Ban.MaSach
JOIN tNhaXuatBan ON tSach.MaNXB = tNhaXuatBan.MaNXB
WHERE tNhaXuatBan.TenNXB = N'NXB Giáo Dục'

--11. Tạo view KhachVip đưa ra khách hàng gồm thông tin MaKH, TenKH, địa chỉ, điện thoại cho những khách hàng đã mua hàng 
--với tổng tất cả các trị giá hóa đơn trong năm hiện tại lớn hơn 30.000.000\
create view KhachVip as
select kh.MaKH, kh.TenKH,kh.DiaChi, kh.DienThoai, sum(ct.SLBan*s.DonGiaBan) as TieuDung
from tKhachHang kh join tHoaDonBan b on kh.MaKH = b.MaKH
join tChiTietHDB ct on b.SoHDB=ct.SoHDB
join tSach s on ct.MaSach = s.MaSach
where year(b.NgayBan) = year(GETDATE())
group by Kh.MaKH, kh.TenKH, kh.DiaChi, kh.DienThoai
having sum(ct.SLBan*s.DonGiaBan) > 300000

--12. Tạo view đưa ra số hóa đơn, trị giá các hóa đơn và tổng toàn bộ trị giá của các hoa đơn do nhân viên có tên “Trần Huy” lập trong tháng hiện tại 
CREATE VIEW HoaDonTranHuy AS
SELECT hdb.SoHDB, SUM(cthdb.SLBan * s.DonGiaBan) AS TriGiaHoaDon
FROM tHoaDonBan hdb
JOIN tNhanVien nv ON hdb.MaNV = nv.MaNV
JOIN tChiTietHDB cthdb ON hdb.SoHDB = cthdb.SoHDB
JOIN tSach s ON cthdb.MaSach = s.MaSach
WHERE nv.TenNV = N'Trần Huy' AND MONTH(hdb.NgayBan) = MONTH(GETDATE())
AND YEAR(hdb.NgayBan) = YEAR(GETDATE())
GROUP BY ROLLUP(hdb.SoHDB)

--13. Tạo view đưa thông tin các các sách còn tồn 
CREATE VIEW SachTon AS
SELECT s.MaSach, s.TenSach, s.TacGia,nxb.TenNXB,tl.TenTheLoai,s.SoLuong
FROM tSach s JOIN tNhaXuatBan nxb ON s.MaNXB = nxb.MaNXB
JOIN tTheLoai tl ON s.MaTheLoai = tl.MaTheLoai
WHERE s.SoLuong > 0

--14. Tạo view đưa ra danh sách các sách không bán được trong năm 2014. 
create view SachKhongBanDuoc as
select ts.MaSach, ts.TenSach
from tSach ts join tNhaXuatBan nxb on ts.MaNXB = nxb.MaNXB
where ts.MaSach not in (
	select s.MaSach
	from tSach s join tChiTietHDB ct on s.MaSach = ct.MaSach 
	join tHoaDonBan n on ct.SoHDB = n.SoHDB
	where year(n.NgayBan) = 2014)
--15. Tạo view đưa ra danh sách các sách của NXB Giáo Dục không bán được trong năm 2014.
create view SachKhongBanDuocNXBGD as
select ts.MaSach, ts.TenSach
from tSach ts join tNhaXuatBan nxb on ts.MaNXB = nxb.MaNXB
where nxb.TenNXB = N'NXB Giáo Dục'
and ts.MaSach not in (
	select s.MaSach
	from tSach s join tChiTietHDB ct on s.MaSach = ct.MaSach 
	join tHoaDonBan n on ct.SoHDB = n.SoHDB
	where year(n.NgayBan) = 2014)

--16. Tạo view đưa ra các thông tin về sách và số lượng từng sách được bán ra trong năm 2014. 
CREATE VIEW SachVaSoLuongBan2014 AS
SELECT s.MaSach, s.TenSach, SUM(ct.SLBan) AS TongSoLuongBan
FROM tSach s
JOIN tChiTietHDB ct ON s.MaSach = ct.MaSach
JOIN tHoaDonBan hdb ON ct.SoHDB = hdb.SoHDB
WHERE YEAR(hdb.NgayBan) = 2014
GROUP BY s.MaSach, s.TenSach

--17.  Tạo view đưa ra họ tên khách hàng đã mua hóa đơn có trị giá cao nhất trong năm 2014.
create view KHMuaHDMax as
with HD as (
	select top 1 ct.SoHDB,hdb.MaKH ,sum(ct.SLBan*s.DonGiaBan) as TriGia
	from tHoaDonBan hdb join tChiTietHDB ct on hdb.SoHDB=ct.SoHDB
	join tSach s on s.MaSach=ct.MaSach
	where year(hdb.NgayBan) = 2014
	group by ct.SoHDB ,hdb.MaKH
	ORDER BY TriGia DESC
)
select tKhachHang.TenKH
from tKhachHang join HD on tKhachHang.MaKH = HD.MaKH
--goi view
select * from KHMuaHDMax

--18. Tạo view đưa ra danh sách 3 nhân viên (MaNV, TenNV) có doanh số cao nhất của năm hiện tại. 
CREATE VIEW Top3Employees AS
SELECT TOP 3 NV.MaNV, NV.TenNV
FROM tNhanVien NV
JOIN (
    SELECT MaNV, SUM(ct.SLBan*s.DonGiaBan) AS DoanhSo
    from tHoaDonBan hdb join tChiTietHDB ct on hdb.SoHDB=ct.SoHDB
	join tSach s on s.MaSach=ct.MaSach
    WHERE YEAR(NgayBan) = YEAR(GETDATE())
    GROUP BY MaNV
)  DS ON NV.MaNV = DS.MaNV
ORDER BY DS.DoanhSo DESC

--19. Tạo view đưa ra danh sách sách và số lượng nhập của mỗi nhà xuất bản trong năm 2014
CREATE VIEW DanhSachSachVaSoLuongNhap AS
SELECT S.TenSach, N.TenNXB, SUM(C.SLNhap) AS SoLuongNhap
FROM tSach S
JOIN tChiTietHDN C ON S.MaSach = C.MaSach
JOIN tHoaDonNhap H ON C.SoHDN = H.SoHDN
JOIN tNhaXuatBan N ON S.MaNXB = N.MaNXB
WHERE YEAR(H.NgayNhap) = 2014
GROUP BY S.TenSach, N.TenNXB


--THỦ TỤC
--Cau 1. Tạo thủ tục có đầu vào là mã sách, đầu ra là số lượng sách đó được bán trong năm 2014
CREATE PROCEDURE SL @MaSach NVARCHAR(50),@SLBan2014 INT OUTPUT
AS
BEGIN
    SET @SLBan2014 = 0
    SELECT @SLBan2014 = SUM(ct.SLBan)
    FROM tChiTietHDB ct
    JOIN tHoaDonBan hd ON ct.SoHDB = hd.SoHDB
    WHERE ct.MaSach = @MaSach
    AND YEAR(hd.NgayBan) = 2014
END
-- chạy
DECLARE @SoLuongBan2014 INT
EXEC SL @MaSach = 'S02', @SLBan2014 = @SoLuongBan2014 OUTPUT
SELECT @SoLuongBan2014 AS SoLuongSachBanTrong2014

--Cau 2. Tạo thủ tục có đầu vào là ngày, đầy ra là số lượng hóa đơn và số lượng tiền bán của sách trong ngày đó 
CREATE PROCEDURE HoaDonTongTien @Ngay DATE,@SoLuongHoaDon INT OUTPUT, @TongTien DECIMAL(18, 2) OUTPUT
AS
BEGIN
    SET @SoLuongHoaDon = 0
    SET @TongTien = 0
    SELECT @SoLuongHoaDon = COUNT(hd.SoHDB)
    FROM tHoaDonBan hd
    WHERE hd.NgayBan = @Ngay
    SELECT @TongTien = SUM(ct.SLBan * s.DonGiaBan)
    FROM tChiTietHDB ct
    JOIN tHoaDonBan hd ON ct.SoHDB = hd.SoHDB
    JOIN tSach s ON ct.MaSach = s.MaSach
    WHERE hd.NgayBan = @Ngay
END
--chạy
DECLARE @SoLuongHoaDon INT
DECLARE @TongTien DECIMAL(18, 2)
EXEC HoaDonTongTien @Ngay = '2024-05-03 00:00:00.000', @SoLuongHoaDon = @SoLuongHoaDon OUTPUT, @TongTien = @TongTien OUTPUT
SELECT @SoLuongHoaDon AS SoLuongHoaDon, @TongTien AS TongTien

--Cau3.Tạo thủ tục có đầu vào là mã nhà cung cấp, đầu ra là số đầu sách và số tiền cửa hàng đã nhập của nhà cung cấp đó 
CREATE PROCEDURE NCC @MaNCC NVARCHAR(50),@SoDauSach INT OUTPUT,@TongTien DECIMAL(18, 2) OUTPUT
AS
BEGIN
    SET @SoDauSach = 0
    SET @TongTien = 0
    SELECT @SoDauSach = COUNT(DISTINCT s.MaSach)
    FROM tChiTietHDN ct
    JOIN tHoaDonNhap hd ON ct.SoHDN = hd.SoHDN
    JOIN tSach s ON ct.MaSach = s.MaSach
    WHERE hd.MaNCC = @MaNCC
    SELECT @TongTien = SUM(ct.SLNhap * s.DonGiaNhap)
    FROM tChiTietHDN ct
    JOIN tHoaDonNhap hd ON ct.SoHDN = hd.SoHDN
    JOIN tSach s ON ct.MaSach = s.MaSach
    WHERE hd.MaNCC = @MaNCC
END
--gọi
DECLARE @SoDauSach INT
DECLARE @TongTien DECIMAL(18, 2)
EXEC NCC @MaNCC = 'NCC01', @SoDauSach = @SoDauSach OUTPUT,@TongTien = @TongTien OUTPUT
SELECT @SoDauSach AS SoDauSach, @TongTien AS TongTien

--Cau4. Tạo thủ tục có đầu vào là năm, đầu ra là số tiền nhập hàng, số tiền bán hàng của năm đó. 
CREATE PROCEDURE TienNhapNam @Nam INT,@TongTienNhap DECIMAL(18, 2) OUTPUT, @TongTienBan DECIMAL(18, 2) OUTPUT
AS
BEGIN
    SET @TongTienNhap = 0
    SET @TongTienBan = 0
    SELECT @TongTienNhap = SUM(ct.SLNhap * s.DonGiaNhap)
    FROM tChiTietHDN ct
    JOIN tHoaDonNhap hd ON ct.SoHDN = hd.SoHDN
    JOIN tSach s ON ct.MaSach = s.MaSach
    WHERE YEAR(hd.NgayNhap) = @Nam
    SELECT @TongTienBan = SUM(ct.SLBan * s.DonGiaBan)
    FROM tChiTietHDB ct
    JOIN tHoaDonBan hd ON ct.SoHDB = hd.SoHDB
    JOIN tSach s ON ct.MaSach = s.MaSach
    WHERE YEAR(hd.NgayBan) = @Nam
END
--gọi
DECLARE @a DECIMAL(18, 2)
DECLARE @b DECIMAL(18, 2)
EXEC TienNhapNam @Nam = 2014, @TongTienNhap = @a OUTPUT, @TongTienBan = @b OUTPUT
SELECT @a AS TongTienNhap, @b AS TongTienBan

--Câu 5. Tạo thủ tục có đầu vào là mã NXB, đầu ra là số lượng sách tồn của nhà xuất bản đó
CREATE PROCEDURE SoLuongTheoNXB @MaNXB NVARCHAR(50), @SoLuongTon INT OUTPUT
AS
BEGIN
    SET @SoLuongTon = 0
    SELECT @SoLuongTon = SUM(s.SoLuong)
    FROM tSach s
    WHERE s.MaNXB = @MaNXB;
END
-- gọi
DECLARE @SoLuongTon INT
EXEC SoLuongTheoNXB @MaNXB = 'NXB01', @SoLuongTon = @SoLuongTon OUTPUT
SELECT @SoLuongTon AS SoLuongTon
-- cách 2
CREATE PROCEDURE TinhSoLuongSachTonCuaNXB
    @MaNXB INT,
    @SoLuongTon INT OUTPUT
AS
BEGIN
    DECLARE @SoLuongNhap INT, @SoLuongBan INT;
    SELECT @SoLuongNhap = SUM(SLNhap)
    FROM tChiTietHDN
    JOIN tSach ON tChiTietHDN.MaSach = tSach.MaSach
    WHERE tSach.MaNXB = @MaNXB;
    SELECT @SoLuongBan = SUM(SLBan)
    FROM tChiTietHDB
    JOIN tSach ON tChiTietHDB.MaSach = tSach.MaSach
    WHERE tSach.MaNXB = @MaNXB;
    SET @SoLuongTon = ISNULL(@SoLuongNhap, 0) - ISNULL(@SoLuongBan, 0);
END
--gọi
DECLARE @SoLuongTon INT
EXEC SoLuongTheoNXB @MaNXB = 'NXB01', @SoLuongTon = @SoLuongTon OUTPUT
SELECT @SoLuongTon AS SoLuongTon

--Câu 6. Tạo thủ tục nhập dữ liệu cho bảng hóa đơn nhập và chi tiết hóa đơn nhập cùng lúc (sử dụng 
transaction)
CREATE PROCEDURE ThemHoaDonNhap
    @SoHDN NVARCHAR(50),
    @MaNV NVARCHAR(50),
    @NgayNhap DATE,
    @MaNCC NVARCHAR(50),
    @ChiTietHDN tChiTietHDN READONLY  
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO tHoaDonNhap (SoHDN, MaNV, NgayNhap, MaNCC)
        VALUES (@SoHDN, @MaNV, @NgayNhap, @MaNCC)
        INSERT INTO tChiTietHDN (SoHDN, MaSach, SLNhap, KhuyenMai)
        SELECT @SoHDN, MaSach, SLNhap, KhuyenMai
        FROM @ChiTietHDN
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        DECLARE @ErrorMessage NVARCHAR(4000)
        DECLARE @ErrorSeverity INT
        DECLARE @ErrorState INT
        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE()
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState)
    END CATCH
END
--Gọi Bươc1
CREATE TYPE tChiTietHDN AS TABLE (
    MaSach NVARCHAR(50),
    SLNhap INT,
    KhuyenMai DECIMAL(5, 2)
)
-- Bước 2
DECLARE @ChiTietHDN tChiTietHDN
INSERT INTO @ChiTietHDN (MaSach, SLNhap, KhuyenMai)
VALUES ('S01', 10, 0.1)
EXEC ThemHoaDonNhap @SoHDN = 'HDN06', @MaNV = 'NV01', 
@NgayNhap = '2024-09-18', @MaNCC = 'NCC01', @ChiTietHDN = @ChiTietHDN

--Câu 7. Tạo thủ tục xóa đồng thời hóa đơn bán và chi tiết hóa đơn bán (dùng transaction) 
CREATE PROCEDURE XoaHoaDonBan
    @SoHDB NVARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM tChiTietHDB
        WHERE SoHDB = @SoHDB;
        DELETE FROM tHoaDonBan
        WHERE SoHDB = @SoHDB;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;      
        DECLARE @LoiDoEm NVARCHAR(4000);
        DECLARE @LoiDoAnh INT;
        DECLARE @LoiDoChungTa INT;
        SELECT
            @LoiDoEm = ERROR_MESSAGE(),
            @LoiDoAnh = ERROR_SEVERITY(),
            @LoiDoChungTa = ERROR_STATE();
        RAISERROR (@LoiDoEm, @LoiDoAnh, @LoiDoChungTa);
    END CATCH
END

EXEC XoaHoaDonBan @SoHDB = 'HDB02'

--Câu 8.  Tạo thủ tục có đầu vào là năm, đầu ra là số lượng sách nhập, sách bán của năm đó 
create procedure cau8 @nam nvarchar(50),
@slgnhap int output, @slgban int output
as begin
    SELECT @slgnhap = SUM(ISNULL(tChiTietHDN.SLNhap, 0))
    FROM tHoaDonNhap
    JOIN tChiTietHDN ON tHoaDonNhap.SoHDN = tChiTietHDN.SoHDN
    WHERE YEAR(tHoaDonNhap.NgayNhap) = @nam;
 
    SELECT @slgban = SUM(ISNULL(tChiTietHDB.SLBan, 0))
    FROM tHoaDonBan
    JOIN tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    WHERE YEAR(tHoaDonBan.NgayBan) = @nam;
end;
--Câu 9. Tạo thủ tục có đầu vào là mã sách, năm, đầu ra số lượng sách nhập, số lượng sách bán trong năm đó
CREATE PROCEDURE GetBookx @MaSach INT, @Year INT,
    @BooksPurchase INT OUTPUT,@BooksSold INT OUTPUT
AS
BEGIN
    SELECT @BooksPurchase= SUM(SLNhap)
    FROM tHoaDonNhap
    JOIN tChiTietHDN ON tHoaDonNhap.SoHDN = tChiTietHDN.SoHDN
    WHERE tChiTietHDN.MaSach = @MaSach AND YEAR(tHoaDonNhap.NgayNhap) = @Year
    SELECT @BooksSold = SUM(SLBan)
    FROM tHoaDonBan
    JOIN tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    WHERE tChiTietHDB.MaSach = @MaSach AND YEAR(tHoaDonBan.NgayBan) = @Year
END

--10. Tạo thủ tục có đầu vào là mã khách hàng, năm, đầu ra là số lượng sách đã mua và số lượng tiền tiêu dùng của khách hàng đó trong năm nhập vào. 
CREATE PROCEDURE GetCustomer @MaKH INT, @Year INT,
    @BooksPurchase INT OUTPUT,@TotalSpent DECIMAL(18, 2) OUTPUT
AS
BEGIN
    SELECT @BooksPurchase = SUM(SLBan)
    FROM tHoaDonBan
    JOIN tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    WHERE tHoaDonBan.MaKH = @MaKH AND YEAR(tHoaDonBan.NgayBan) = @Year
   
    SELECT @TotalSpent = SUM(tChiTietHDB.SLBan * tSach.DonGiaBan)
    FROM tHoaDonBan
    JOIN tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    JOIN tSach ON tChiTietHDB.MaSach = tSach.MaSach
    WHERE tHoaDonBan.MaKH = @MaKH AND YEAR(tHoaDonBan.NgayBan) = @Year
END

--11. Tạo thủ tục có đầu vào là mã khách hàng, năm, đầu ra là số lượng hóa đơn đã mua và số lượng tiền tiêu dùng của khách hàng đó trong năm đó.
CREATE PROCEDURE ThongKeHoaDonKhachHang(@MaKH NVARCHAR(50), @Nam INT)
AS
BEGIN
    DECLARE @SoLuongHoaDon INT;
    DECLARE @TongTien DECIMAL(18, 2)
    SELECT @SoLuongHoaDon = COUNT(*)
    FROM tHoaDonBan
    WHERE MaKH = @MaKH AND YEAR(NgayBan) = @Nam
    SELECT @TongTien = ISNULL(SUM(ct.SLBan * s.DonGiaBan * (1 - ISNULL(ct.KhuyenMai, 0))), 0)
    FROM tHoaDonBan hdb
    JOIN tChiTietHDB ct ON hdb.SoHDB = ct.SoHDB
    JOIN tSach s ON ct.MaSach = s.MaSach
    WHERE hdb.MaKH = @MaKH AND YEAR(hdb.NgayBan) = @Nam
    SELECT @SoLuongHoaDon AS SoLuongHoaDon, @TongTien AS TongTienDaTieu;
END
--gọi
EXEC ThongKeHoaDonKhachHang @MaKH = 'KH01', @Nam = 2014


--HÀM
--Cau 1. Tạo hàm đưa ra tổng số tiền đã nhập sách trong một năm với tham số đầu vào là năm
CREATE FUNCTION TongTienNhap(@Nam INT)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TongTien DECIMAL(18, 2)
    SELECT @TongTien = ISNULL(SUM(t.SLNhap * s.DonGiaNhap), 0)
    FROM tChiTietHDN t
    JOIN tSach s ON t.MaSach = s.MaSach
    JOIN tHoaDonNhap h ON t.SoHDN = h.SoHDN
    WHERE YEAR(h.NgayNhap) = @Nam;
    RETURN @TongTien;
END
--gọi
SELECT dbo.TongTienNhap(2014) AS TongTienNhap

--Cau2. Tạo hàm đưa ra danh sách 5 đầu sách bán chạy nhất trong tháng nào đó (tháng là tham số đầu vào) 
CREATE FUNCTION DanhSachSachBanChay(@Thang INT,@Nam INT)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5 s.MaSach, s.TenSach,SUM(c.SLBan) AS TongSoLuongBan
    FROM tChiTietHDB c
    JOIN tSach s ON c.MaSach = s.MaSach
    JOIN tHoaDonBan h ON c.SoHDB = h.SoHDB
    WHERE MONTH(h.NgayBan) = @Thang AND YEAR(h.NgayBan) = @Nam
    GROUP BY s.MaSach, s.TenSach
    ORDER BY TongSoLuongBan DESC
)
--Gọi
SELECT * FROM dbo.DanhSachSachBanChay(5, 2024)

--câu 3. Tạo hàm đưa ra danh sách n nhân viên có doanh thu cao nhất trong một năm với n và năm là tham số đầu vào 
CREATE FUNCTION dbo.fn_NhanVienDoanhThuCaoNhat(@SoLuongNhanVien INT,@Nam INT)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP (@SoLuongNhanVien) nv.MaNV,nv.TenNV, SUM(ct.SLBan * s.DonGiaBan) AS TongDoanhThu
    FROM tChiTietHDB ct
    JOIN tHoaDonBan hdb ON ct.SoHDB = hdb.SoHDB
    JOIN tNhanVien nv ON hdb.MaNV = nv.MaNV
    JOIN tSach s ON ct.MaSach = s.MaSach
    WHERE YEAR(hdb.NgayBan) = @Nam
    GROUP BY nv.MaNV, nv.TenNV
    ORDER BY TongDoanhThu DESC
)

--Câu 4. Tạo hàm đưa ra thông tin Nhân viên sinh nhật trong ngày là tham số nhập vào
CREATE FUNCTION ThongTinNhanVienSinhNhat(@NgaySinh DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT MaNV, TenNV, GioiTinh, DiaChi, DienThoai
    FROM tNhanVien
    WHERE DAY(NgaySinh) = DAY(@NgaySinh)
      AND MONTH(NgaySinh) = MONTH(@NgaySinh)
	  and YEAR(NgaySinh) = YEAR(@NgaySinh)
)
 
--cau 5. Tạo hàm đưa ra danh sách tồn trong kho quá 2 năm (nhập nhưng không bán hết trong hai năm)
CREATE FUNCTION DanhSachTonKhoQua2Nam()
RETURNS TABLE
AS
RETURN
(
    SELECT s.MaSach, s.TenSach, s.SoLuong, hdn.NgayNhap
    FROM tSach s
    JOIN tChiTietHDN cthdn ON s.MaSach = cthdn.MaSach
    JOIN tHoaDonNhap hdn ON cthdn.SoHDN = hdn.SoHDN
    WHERE DATEDIFF(YEAR, hdn.NgayNhap, GETDATE()) > 2
      AND s.SoLuong > 0
)
--Gọi
select * from DanhSachTonKhoQua2Nam()

--Câu 6. Tạo hàm với đầu vào là ngày, đầu ra là thông tin các hóa đơn và trị giá của hóa đơn trong ngày đó
CREATE FUNCTION ThongTinHoaDonTrongNgay(@NgayBan DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT hdb.SoHDB, kh.TenKH, SUM(s.DonGiaBan * cthdb.SLBan) AS TriGia
    FROM tHoaDonBan hdb
    JOIN tKhachHang kh ON hdb.MaKH = kh.MaKH
    JOIN tChiTietHDB cthdb ON hdb.SoHDB = cthdb.SoHDB
    JOIN tSach s ON cthdb.MaSach = s.MaSach
    WHERE hdb.NgayBan = @NgayBan
    GROUP BY hdb.SoHDB, kh.TenKH
)

--Cau7. Tạo hàm có đầu vào là năm đầu ra là thống kê doanh thu theo từng tháng và cả năm (dùng roll up) 
alter FUNCTION ThongKeDoanhThuTheoNam (@Nam INT)
RETURNS TABLE
AS
RETURN
(WITH ThangList AS (SELECT 1 AS Thang UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL
        SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL
        SELECT 8 UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL
        SELECT 12)
    SELECT ISNULL(CAST(t.Thang AS NVARCHAR(10)), N'Cả Năm') AS Thang, 
        ISNULL(SUM(ct.SLBan * s.DonGiaBan * (1 - ISNULL(ct.KhuyenMai, 0))), 0) AS DoanhThu  
    FROM ThangList t  
    LEFT JOIN tHoaDonBan hd ON MONTH(hd.NgayBan) = t.Thang AND YEAR(hd.NgayBan) = @Nam
    LEFT JOIN tChiTietHDB ct ON hd.SoHDB = ct.SoHDB
    LEFT JOIN tSach s ON ct.MaSach = s.MaSach
    GROUP BY ROLLUP(t.Thang) 
)
SELECT * 
FROM dbo.ThongKeDoanhThuTheoNam(2014)

--Cau8. Tạo hàm có đầu vào là sách, đầu ra là số lượng tồn của sách
CREATE FUNCTION SoLuongTon (@MaSach nvarchar(10))
RETURNS INT
AS
BEGIN
    DECLARE @SoLuongNhap INT
    DECLARE @SoLuongBan INT
    DECLARE @SoLuongTon INT
    SELECT @SoLuongNhap = ISNULL(SUM(SLNhap), 0) FROM tChiTietHDN WHERE MaSach = @MaSach
    SELECT @SoLuongBan = ISNULL(SUM(SLBan), 0) FROM tChiTietHDB WHERE MaSach = @MaSach
    SET @SoLuongTon = @SoLuongNhap - @SoLuongBan
    RETURN @SoLuongTon
END
--Gọi
SELECT dbo.SoLuongTon('S01') AS SoLuongTon

--Cau9. Tạo hàm có đầu vào là mã loại, đầu ra là thông tin sách, số lượng sách nhập, số lượng sách bán của mỗi sách thuộc mã loại đó 
CREATE FUNCTION ThongTinSachTheoLoai
(
    @MaLoai nvarchar(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT s.MaSach,s.TenSach,
        ISNULL(SUM(n.SLNhap), 0) AS SoLuongNhap,
        ISNULL(SUM(b.SLBan), 0) AS SoLuongBan
    FROM tSach s
    LEFT JOIN tChiTietHDN n ON s.MaSach = n.MaSach
    LEFT JOIN tChiTietHDB b ON s.MaSach = b.MaSach
    WHERE s.MaTheLoai = @MaLoai
    GROUP BY s.MaSach, s.TenSach
)
SELECT *
FROM dbo.ThongTinSachTheoLoai('TL01')


--TRIGGER
--1.  Tạo trường thành tiền (ThanhTien) cho bảng tChitietHDB, tạo trigger cập nhật tự động cho trường này biết ThanhTien=SLBan*DonGiaBan 
create trigger ThanhTien on [dbo].[tChiTietHDB]
for insert, update as
begin 
	declare @sohdb nvarchar(10), @dongia money, @masach nvarchar(10)
	select @sohdb = sohdb, @masach=masach from inserted
	select @dongia=dongiaban from tSach where MaSach=@masach
	update tChiTietHDB set ThanhTien=SLban*@dongia where
	sohdb=@sohdb and  MaSach=@masach
end
--chạy
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values ('HDB13','S05',10)
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values ('HDB13','S06',10)
--TH nhiều bản ghi
create trigger ThanhTien on [dbo].[tChiTietHDB]
for insert, update as
begin 
	update tChiTietHDB set ThanhTien = inserted.SLban*DonGiaBan
	from inserted join tSach on inserted.MaSach = tSach.MaSach
	join tChiTietHDB on inserted.SoHDB = tChiTietHDB.SoHDB and
	inserted.MaSach = tChiTietHDB.MaSach
end
--chạy
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values ('HDB22','S06',10),('HDB22','S07',11),('HDB22','S08',12)

--2  Thêm trường đơn giá (DonGia) cho bảng chi tiết hóa đơn bán, cập nhật dữ liệu cho trường này mỗi khi thêm, sửa bản ghi vào bảng chi tiết hóa đơn bán. 
--Thêm trường đơn giá (DonGia) cho bảng chi tiết hóa đơn bán
ALTER TABLE tChiTietHDB
ADD DonGia money
--Tạo trigger
create TRIGGER UpdateDonGia
ON tChiTietHDB
for insert, update
AS
BEGIN
    UPDATE tChiTietHDB
    SET DonGia = (SELECT tSach.DonGiaBan FROM tSach WHERE tSach.MaSach = Inserted.MaSach)*Inserted.SLBan
    FROM Inserted
    WHERE tChiTietHDB.SoHDB = Inserted.SoHDB AND tChiTietHDB.MaSach = Inserted.MaSach
END
--chạy
insert into tChiTietHDB(SoHDB,MaSach,SLBan) 
values ('HDB22','S06',10),('HDB22','S07',11),('HDB22','S08',12)

--3   Thêm trường số lượng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm hóa đơn
--Thêm trường số lượng hóa đơn vào bảng khách hàng
ALTER TABLE tHoaDonBan
ADD SL INT
--cap nhat sl
   UPDATE tKhachHang
   SET SL = isnull((SELECT count(SoHDB) 
                    FROM tHoaDonBan
                    WHERE tKhachHang.MaKH = tHoaDonBan.MaKH), 0)

--trigger
create TRIGGER cau3_trigger
ON thoadonban
FOR INSERT, DELETE,UPDATE
AS
BEGIN
	declare @makh_ins nvarchar(10),@makh_del nvarchar(10)
	select @makh_ins=makh from inserted
	select @makh_del=makh from deleted
	update tKhachHang set SL=isnull(SL,0)+1 where MaKH=@makh_ins
	update tKhachHang set SL=isnull(SL,0)-1 where MaKH=@makh_del
END
--kiemtra
select * from tKhachHang where MaKH='KH01' OR MaKH='KH02'
insert into tHoaDonBan values('HDB19','NV01', '2014-08-11 00:00:00.000', 'KH01',0,0)
delete from tHoaDonBan where SoHDB='HDB19'
UPDATE tHoaDonBan SET MaKH='KH02' WHERE SoHDB='HDB19'

--cach2
create TRIGGER Cau3 ON tHoaDonBan
for insert
AS 
BEGIN
   DECLARE @makh nvarchar(20)
   SELECT @makh = Inserted.MaKH FROM Inserted
   UPDATE tKhachHang
   SET SL = SL + 1
   WHERE MaKH = @makh
   --nhiều bản ghi
   UPDATE tKhachHang
   SET SL = SL + (SELECT COUNT(*) 
                  FROM Inserted i 
                  WHERE i.MaKH = tKhachHang.MaKH)
   WHERE MaKH IN (SELECT MaKH FROM Inserted)  
END
--chạy
select * from tKhachHang where MaKH='KH01' OR MaKH='KH02' or MaKH='KH03'
insert into tHoaDonBan(SoHDB, MaKH) values ('HDB27','KH01'),('HDB28','KH01')

--4.  Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm chi tiết hóa đơn 
--Thêm trường số sản phẩm vào bảng hóa đơn bán
ALTER TABLE tHoaDonBan
ADD SoSanPham INT
--cap nhat sl
   UPDATE tHoaDonBan
   SET SoSanPham = isnull((SELECT sum(tChiTietHDB.SLBan) 
                    FROM tChiTietHDB
                    WHERE tChiTietHDB.SoHDB = tHoaDonBan.SoHDB), 0)
--trigger
create TRIGGER ChenSanPham ON tChiTietHDB
for insert
AS 
BEGIN
   UPDATE tHoaDonBan
   SET SoSanPham = SoSanPham + (SELECT sum(SLBan)
                    FROM Inserted where inserted.SoHDB = tHoaDonBan.SoHDB
                    )
   WHERE tHoaDonBan.SoHDB in(select SoHDB from Inserted)
END
   --
   DECLARE @SoHDB nvarchar(20)
   SELECT @SoHDB = Inserted.SoHDB FROM Inserted
   UPDATE tHoaDonBan
   SET SoSanPham = SoSanPham + (SELECT SLBan
                    FROM Inserted
                    )
   WHERE SoHDB = @SoHDB
END
--chen
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values ('HDB28','S01',10), ('HDB28','S02',10)

--5  Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi xóa chi tiết hóa đơn 
--Thêm trường số sản phẩm vào bảng hóa đơn bán
ALTER TABLE tHoaDonBan
ADD SoSanPham INT
--cap nhat sl
   UPDATE tHoaDonBan
   SET SoSanPham = (SELECT sum(tChiTietHDB.SLBan) 
                    FROM tChiTietHDB
                    WHERE tChiTietHDB.SoHDB = tHoaDonBan.SoHDB)
--trigger
create TRIGGER UpdateSoSanPham
ON tChiTietHDB
for DELETE
AS 
BEGIN
   DECLARE @SoHDB nvarchar(20)
   SELECT @SoHDB = deleted.SoHDB FROM deleted
   UPDATE tHoaDonBan
   SET SoSanPham = SoSanPham - (SELECT SLBan
                    FROM deleted)
   WHERE SoHDB = @SoHDB
END
--chạy
delete tChiTietHDB 
where SoHDB='HDB14' and MaSach = 'S07'

--6.Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, sửa, xóa chi tiết hóa đơn 
--Thêm trường số sản phẩm vào bảng hóa đơn bán
ALTER TABLE tHoaDonBan
ADD SoSanPham INT
--cap nhat sl
   UPDATE tHoaDonBan
   SET SoSanPham = isnull((SELECT sum(tChiTietHDB.SLBan) 
                    FROM tChiTietHDB
                    WHERE tChiTietHDB.SoHDB = tHoaDonBan.SoHDB), 0)
--TH 1 bản ghi
alter trigger cau6_trigger
on tChiTietHDB
for insert, delete, update
as
begin
	declare @sohdb_ins nvarchar(10), @sohdb_del nvarchar(10),
	@slban_ins int, @slban_del int
	select @sohdb_ins = SoHDB, @slban_ins = SLBan from inserted
	select @sohdb_del = SoHDB, @slban_del = SLBan from deleted
	update tHoaDonBan set SoSanPham = isnull(SoSanPham, 0) + @slban_ins where SoHDB=@sohdb_ins
	update tHoaDonBan set SoSanPham = isnull(SoSanPham, 0) - @slban_del where SoHDB=@sohdb_del
end
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB20', 'S03',10)

--TH nhiều bản ghi
alter TRIGGER cau6_trigger
ON tchitiethdb
FOR INSERT, DELETE,UPDATE
AS
BEGIN
	update thoadonban set SoLuongSP=isnull(SoLuongSP,0) + A.SL
	from (select sohdb, sum(slban) as SL from inserted group by sohdb) A
	where thoadonban.sohdb = A.sohdb

	update thoadonban set SoLuongSP=isnull(SoLuongSP,0)-A.SL
	from (select sohdb, sum(slban) as SL from deleted group by sohdb) A
	where thoadonban.sohdb = A.sohdb
END
--check
select * from thoadonban where sohdb='HDB13' or sohdb='HDB14'
select * from tchitiethdb where sohdb='HDB13' or sohdb='HDB14'
delete from tChiTietHDB where sohdb='HDB13' and (masach='S09' or masach='S03')
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB13', 'S09',10),('HDB13', 'S10',10),('HDB14', 'S11',10)
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB13', 'S03',1)

--7.  Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm chi tiết hóa đơn   
--Thêm trường tổng tiền cho hóa đơn bán
alter table tHoaDonBan
add TongTien decimal(15,2)
--cap nhat
update tHoaDonBan
set TongTien = 
		isnull(
		(select sum(SLBan*DonGiaBan)
		from tChiTietHDB ct join tSach s on ct.MaSach=s.MaSach
		where ct.SoHDB = tHoaDonBan.SoHDB)
	,0)		
--1 ban ghi
alter trigger cau7
on tChiTietHDB for insert
as
begin
	update tHoaDonBan set
	TongTien = TongTien + 
		(select sum(SLBan*DonGiaBan)
		from inserted join tSach
		on inserted.MaSach = tSach.MaSach
		where inserted.SoHDB = tHoaDonBan.SoHDB
		)
	where tHoaDonBan.SoHDB in (select SoHDB from inserted)
end
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB28', 'S16',1), ('HDB27', 'S17',3)
--nhieu ban ghi
create trigger cau7
on tChiTietHDB for insert
as
begin
	update tHoaDonBan set
	TongTien = TongTien + A.Tien
	from (select SoHDB ,sum(SLBan*DonGiaBan) as Tien
		from inserted join tSach
		on inserted.MaSach = tSach.MaSach
		group by SoHDB
		) A
	where tHoaDonBan.SoHDB = A.SoHDB
end
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB28', 'S16',1), ('HDB27', 'S17',3)
--8.  Thêm trường số lượng hóa đơn vào bảng khách hàng và cập nhật tự động cho trường này mỗi khi thêm, sửa, xóa hóa đơn
--cap nhat sl
   UPDATE tKhachHang
   SET SL = isnull((SELECT count(SoHDB) 
                    FROM tHoaDonBan
                    WHERE tKhachHang.MaKH = tHoaDonBan.MaKH), 0)
create TRIGGER cau8_trigger
ON thoadonban
FOR INSERT, DELETE,UPDATE
AS
BEGIN
	declare @makh_ins nvarchar(10),@makh_del nvarchar(10)
	select @makh_ins=makh from inserted
	select @makh_del=makh from deleted
	update tKhachHang set SL=isnull(SL,0)+1 where MaKH=@makh_ins
	update tKhachHang set SL=isnull(SL,0)-1 where MaKH=@makh_del
END
--check
select * from tKhachHang where MaKH='KH01' OR MaKH='KH02'
insert into tHoaDonBan(SoHDB,MaNV,NgayBan, MaKH) values('HDB19','NV01', '2014-08-11 00:00:00.000', 'KH01')
delete from tHoaDonBan where SoHDB='HDB19'
UPDATE tHoaDonBan SET MaKH='KH02' WHERE SoHDB='HDB19'

--9.  Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi 
--thêm, xóa, sửa chi tiết hóa đơn
--1 ban ghi
create trigger cau9 
on tChiTietHDB 
for insert, update, delete
as
begin
	declare @hdb_ins nvarchar(10), @hdb_del nvarchar(10), @sl_ins int, @sl_del int
	select @hdb_ins = SoHDB, @sl_ins = SLBan from inserted
	select @hdb_del = SoHDB, @sl_del = SLBan from deleted
	update tHoaDonBan set SoSanPham = isnull(SoSanPham,0) + @sl_ins where SoHDB = @hdb_ins
	update tHoaDonBan set SoSanPham = isnull(SoSanPham,0) - @sl_del where SoHDB = @hdb_del
end
--chạy
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB19', 'S03',10)

--nhieu ban ghi
create trigger cau9 
on tChiTietHDB 
for insert, update, delete
as
begin
	update tHoaDonBan set SoSanPham = isnull(SoSanPham,0) + A.SL
	from (select SoHDB, sum(SLBan) as SL from inserted group by SoHDB) A
	where tHoaDonBan.SoHDB = A.SoHDB
	update tHoaDonBan set SoSanPham = isnull(SoSanPham,0) - A.SL
	from (select SoHDB, sum(SLBan) as SL from deleted group by SoHDB) A
	where tHoaDonBan.SoHDB = A.SoHDB
end
--chạy
select * from thoadonban where sohdb='HDB13' or sohdb='HDB14'
select * from tchitiethdb where sohdb='HDB13' or sohdb='HDB14'
delete from tChiTietHDB where sohdb='HDB13' and (masach='S09' or masach='S10')
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB13', 'S09',10),('HDB13', 'S10',10),('HDB14', 'S11',10)

--10.  Thêm trường tổng tiền cho hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm, xóa, sửa chi tiết hóa đơn 
--Một bản ghi
create trigger cau10 on tChiTietHDB
for insert, update, delete
as
begin
	declare @hdb_ins nvarchar(10), @hdb_del nvarchar(10)
	select @hdb_ins = SoHDB from inserted
	select @hdb_del = SoHDB from deleted
	update tHoaDonBan set TongTien = isnull(TongTien, 0) + (
		select sum(SLBan*DonGiaBan) from inserted join tSach on inserted.MaSach = tSach.MaSach
		)
	where SoHDB = @hdb_ins
	update tHoaDonBan set TongTien = isnull(TongTien, 0) - (
		select sum(SLBan*DonGiaBan) from deleted join tSach on deleted.MaSach = tSach.MaSach
		)
	where SoHDB = @hdb_del
end
--chạy
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB21', 'S15',1),('HDB21', 'S16',1),('HDB21', 'S17',1)
delete from tChiTietHDB where sohdb='HDB21'
--Nhiều bản ghi
create trigger cau10 on tChiTietHDB
for insert, update, delete
as
begin
	update tHoaDonBan set TongTien = isnull(TongTien, 0) + A.Tien
	from (select SoHDB, sum(SLBan*DonGiaBan) as Tien from inserted join tSach on inserted.MaSach = tSach.MaSach group by SoHDB) A	
	where tHoaDonBan.SoHDB = A.SoHDB
	update tHoaDonBan set TongTien = isnull(TongTien, 0) - A.Tien
	from (select SoHDB, sum(SLBan*DonGiaBan) as Tien from deleted join tSach on deleted.MaSach = tSach.MaSach group by SoHDB) A	
	where tHoaDonBan.SoHDB = A.SoHDB
end
--chạy
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB21', 'S15',1),('HDB21', 'S16',1),('HDB22', 'S17',1)

--11.  Số lượng trong bảng Sách là số lượng tồn kho, cập nhật tự động dữ liệu cho trường này mỗi khi nhập hay bán sách
create trigger Ban on tChiTietHDB
for insert, update, delete
as
begin
	update tSach set SoLuong = SoLuong - A.SL
	from (select MaSach, sum(SLBan) as SL from inserted group by MaSach) A	
	where tSach.MaSach = A.MaSach
	update tSach set SoLuong = SoLuong + A.SL
	from (select MaSach, sum(SLBan) as SL from deleted group by MaSach) A	
	where tSach.MaSach = A.MaSach
end
--chạy
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB21', 'S15',10),('HDB21', 'S16',10),('HDB22', 'S17',10)

create trigger Nhap on tChiTietHDN
for insert, update, delete
as
begin
	update tSach set SoLuong = SoLuong + A.SL
	from (select MaSach, sum(SLNhap) as SL from inserted group by MaSach) A	
	where tSach.MaSach = A.MaSach
	update tSach set SoLuong = SoLuong - A.SL
	from (select MaSach, sum(SLNhap) as SL from deleted group by MaSach) A	
	where tSach.MaSach = A.MaSach
end
--chạy
insert into tChiTietHDN(SoHDN, MaSach, SLNhap) values ('HDN06', 'S15',10),('HDN06', 'S16',10),('HDN05', 'S17',10)

--12.  Thêm trường Tổng tiền tiêu dùng cho bảng khách hàng, cập nhật thông tin cho trường này. 
--Thêm trường Tổng tiền tiêu dùng cho bảng khách hàng
ALTER TABLE tKhachHang
ADD TongTien decimal(15, 2)
--cập nhật
UPDATE tKhachHang
SET TongTien = (
    SELECT SUM(ct.SLBan * s.DonGiaBan)
    FROM tHoaDonBan hdb
    JOIN tChiTietHDB ct ON hdb.SoHDB = ct.SoHDB
    JOIN tSach s ON ct.MaSach = s.MaSach
    WHERE hdb.MaKH = tKhachHang.MaKH
)
--trigger
create trigger cau12 on tChiTietHDB
for insert, update, delete
as
begin
	update tKhachHang set TongTien = isnull(TongTien, 0) + A.Tien
	from (SELECT hdb.MaKH, SUM(cthdb.SLBan * sach.DonGiaBan) AS Tien
    FROM inserted AS cthdb
    JOIN tHoaDonBan AS hdb ON cthdb.SoHDB = hdb.SoHDB
    JOIN TSach AS sach ON cthdb.MaSach = sach.MaSach
    GROUP BY hdb.MaKH) A
	where tKhachHang.MaKH = A.MaKH
	
end

--13.  Thêm trường Số đầu sách cho bảng nhà cung cấp, cập nhật tự động số đầu sách nhà cung cấp cung cấp cho cửa hàng  
--Thêm trường Số đầu sách cho bảng nhà cung cấp
ALTER TABLE tNhaCungCap 
ADD SoDauSach INT DEFAULT 0;
--trigger
create trigger cau13
on tChiTietHDN
for insert, delete, update
as
begin
		declare @sohdn_ins nvarchar(10), @sohdn_del nvarchar(10)
		select @sohdn_ins = SoHDN from inserted
		select @sohdn_del = SoHDN from deleted
		update tNhaCungCap set SoDauSach = isnull(SoDauSach, 0) + 1 where MaNCC = (select MaNCC from tHoaDonNhap where SoHDN = @sohdn_ins)
		update tNhaCungCap set SoDauSach = isnull(SoDauSach, 0) - 1 where MaNCC = (select MaNCC from tHoaDonNhap where SoHDN = @sohdn_del)
end

--14.  Thêm trường Số lượng sách và Tổng tiền hàng vào bảng nhà cung cấp, cập nhật dữ liệu cho trường này mỗi khi nhập hàng. 
--Thêm trường Số lượng sách và Tổng tiền hàng vào bảng nhà cung cấp
ALTER TABLE tNhaCungCap ADD SoLuongSach INT DEFAULT 0;
ALTER TABLE tNhaCungCap ADD TongTienHang DECIMAL(18,2) DEFAULT 0
--trigger
create TRIGGER cau14
ON tChiTietHDN
FOR INSERT, DELETE,UPDATE
AS
BEGIN
	update tNhaCungCap set SoLuongSach = isnull(SoLuongSach,0)+ A.SL
	from (select SoHDN, sum(SLNhap) as SL from inserted group by SoHDN) A
	where tNhaCungCap.MaNCC in (select MaNCC from tHoaDonNhap where SoHDN = A.SoHDN)
	update tNhaCungCap set SoLuongSach = isnull(SoLuongSach,0) - A.SL
	from (select SoHDN, sum(SLNhap) as SL from deleted group by SoHDN) A
	where tNhaCungCap.MaNCC in (select MaNCC from tHoaDonNhap where SoHDN = A.SoHDN)

	update tNhaCungCap set TongTienHang = isnull(TongTienHang,0)+ A.Tien
	from (select SoHDN, sum(SLNhap*DonGiaNhap) as Tien 
	from inserted join tSach on inserted.MaSach = tSach.MaSach group by SoHDN) A
	where tNhaCungCap.MaNCC in (select MaNCC from tHoaDonNhap where SoHDN = A.SoHDN)
	update tNhaCungCap set TongTienHang = isnull(TongTienHang,0)- A.Tien
	from (select SoHDN, sum(SLNhap*DonGiaNhap) as Tien 
	from deleted join tSach on deleted.MaSach = tSach.MaSach group by SoHDN) A
	where tNhaCungCap.MaNCC in (select MaNCC from tHoaDonNhap where SoHDN = A.SoHDN)
END

--15. Tạo trigger trên bảng thoadonban thực hiện xóa các chi tiết hóa đơn mỗi khi xóa hóa đơn
alter TRIGGER trg_DeleteChiTietHDB
ON tHoaDonBan
instead of DELETE
AS
BEGIN
    DELETE FROM tChiTietHDB
    WHERE SoHDB IN (SELECT SoHDB FROM deleted)
	DELETE FROM tHoaDonBan
    WHERE SoHDB IN (SELECT SoHDB FROM deleted)
END

delete FROM tHoaDonBan where SoHDB = 'HDB28'


