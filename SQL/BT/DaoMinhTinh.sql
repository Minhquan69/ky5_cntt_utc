--Baitap 1
/*1. Tạo hàm có đầu vào là lộ trình, đầu ra là số xe, mã trọng tải, số lượng vận tải, ngày đi, ngày 
đến (SoXe, MaTrongTai, SoLuongVT, NgayDi, NgayDen.)*/
CREATE FUNCTION TTLoTrinh (@MaLoTrinh nvarchar(20))
RETURNS TABLE AS
RETURN
(
    SELECT SoXe, MaTrongTai, SoLuongVT, NgayDi, NgayDen
    FROM ChiTietVanTai
    WHERE MaLoTrinh = @MaLoTrinh
)
--Gọi hàm
SELECT * FROM TTLoTrinh('HN')
/*2. Thiết lập hàm có đầu vào là số xe, đầu ra là thông tin về lộ trình*/
CREATE  FUNCTION TTLT (@SoXe NVARCHAR(255))
RETURNS TABLE AS
RETURN
(
    SELECT lt.MaLoTrinh,lt.TenLoTrinh,ct.SoLuongVT, ct.NgayDi, ct.NgayDen,lt.DonGia, lt.ThoiGianQD
    FROM ChiTietVanTai ct join LoTrinh lt ON ct.MaLoTrinh = lt.MaLoTrinh
    WHERE ct.SoXe = @SoXe
)
--Gọi hàm
SELECT * FROM TTLT('123')
/*3.Tạo hàm có đầu vào là trọng tải, đầu ra là các số xe có trọng tải quy định lớn hơn hoặc bằng 
trọng tải đó*/
CREATE FUNCTION TTQuiDinh(@MinTT INT)
RETURNS TABLE AS
RETURN
  (	SELECT DISTINCT c.Soxe, t.TrongTaiQD
    FROM ChiTietVanTai c
    join TrongTai t on c.MaTrongTai = t.MaTrongTai
    WHERE t.TrongTaiQD >= @MinTT
  )
--Gọi hàm
SELECT * FROM TTQuiDinh(8)
/*4. Tạo hàm có đầu vào là trọng tải và mã lộ trình, đầu ra là số lượng xe có trọng tải quy định 
lớn hơn hoặc bằng trọng tải đó và thuộc lộ trình đó.*/
CREATE FUNCTION TrongTaiLoTrinh( @TT INT, @MaLT nvarchar(20))
RETURNS INT AS
BEGIN
    DECLARE @Count INT
    SELECT @Count = COUNT(DISTINCT ct.Soxe)
    FROM ChiTietVanTai ct join TrongTai tt on ct.MaTrongTai = tt.MaTrongTai
    WHERE tt.TrongTaiQD >= @TT
    AND ct.MaLoTrinh = @MaLT
    RETURN @Count
END
-- Gọi hàm
DECLARE @a INT
SELECT @a =  dbo.TrongTaiLoTrinh(4, 'HN')
print @a

/*5. Tạo thủ tục có đầu vào Mã lộ trình đầu ra là số lượng xe thuộc lộ trình đó.*/
CREATE PROCEDURE C5 @MaLotrinh nvarchar(20), @sl int output
AS
BEGIN
    SELECT @sl = COUNT( DISTINCT SoXe)
    FROM ChiTietVanTai
	WHERE MaLoTrinh = @MaLotrinh
END
-- Gọi thủ tục
declare @soluong int
exec C5 'HN' , @soluong output
print @soluong

/*6. Tạo thủ tục có đầu vào là mã lộ trình, năm vận tải, đầu ra là số tiền theo mã lộ trình và năm 
vận tải đó*/
CREATE PROCEDURE TienTheoLT @MaLoTrinh VARCHAR(50), @NamVanTai INT
AS
BEGIN
    SELECT SUM(lt.DonGia) AS TongTien, @NamVanTai AS NamVanTai
    FROM ChiTietVanTai ct join LoTrinh lt on ct.MaLoTrinh = lt.MaLoTrinh
    WHERE ct.MaLoTrinh = @MaLoTrinh AND YEAR(ct.NgayDi) = @NamVanTai
END
-- Gọi thủ tục
EXEC TienTheoLT 'HN', 2014


CREATE PROCEDURE TienTheoLT @malt NVARCHAR(10), @nam INT, 
    @sotien MONEY OUTPUT, @namvt INT OUTPUT
AS 
BEGIN       
    SELECT @sotien = SUM(lt.DonGia),
        @namvt = @nam
    FROM ChiTietVanTai ct
    JOIN LoTrinh lt ON ct.MaLoTrinh = lt.MaLoTrinh   
    WHERE  @malt = ct.MaLoTrinh AND YEAR(ct.NgayDi) = @nam
END
-- Gọi thủ tục
DECLARE @st MONEY, @namvt INT
EXEC TienTheoLT 'HN', 2014, @st OUTPUT, @namvt OUTPUT
PRINT N'Số tiền: ' + CAST(@st AS NVARCHAR(10)) + N' Năm vận tải: ' + CAST(@namvt AS NVARCHAR(10))

/*7. Tạo thủ tục có đầu vào là số xe, năm vận tải, đầu ra là số tiền theo số xe và năm vận tải đó 
đó*/
create procedure TienTheoXe @soxe nvarchar(10),@nam int  ,@sotien int output, @namvt INT OUTPUT
as 
begin
	select @sotien=sum(Dongia), @namvt = @nam
	from ChiTietVanTai ct join lotrinh lt 
	on ct.malotrinh=lt.malotrinh   
	where @soxe = SoXe and @nam=year(ngaydi) 
end 
-- gọi thủ tục
declare @st int, @namvt int
exec TienTheoXe '444',2014,@st output, @namvt output
PRINT N'Số tiền: ' + CAST(@st AS NVARCHAR(10)) + N' Năm vận tải: ' + CAST(@namvt AS NVARCHAR(10))

/*8. Tạo thủ tục có đầu vào là mã trọng tải, đầu ra là số lượng xe vượt quá trọng tải quy định 
của mã trọng tải đó.*/
create procedure SLQuaTT @matrongtai nvarchar(10),@sl int output 
as 
begin     
	select @sl=count(distinct soxe)
	from ChiTietVanTai ct join TrongTai tt 
	on ct.MaTrongTai = tt.MaTrongTai
	where ct.MaTrongTai = @matrongtai and SoLuongVT>TrongTaiQD
end
-- Gọi thủ tục
declare @soluong int 
exec SLQuaTT '50',@soluong output
print N'Số lượng xe: ' +cast(@soluong as nvarchar(10))


--Baitap 2
--1. Tạo hàm với đầu vào là năm, đầu ra là danh sách nhân viên sinh vào năm đó 
create function NSNV (@nam int)
returns table
as 
return(
	select MaNV, Ho + ' ' + Ten as HoTen, case when PHAI = 1 then N'Nữ' else N'Nam' end as GioiTinh
	from tNhanVien 
	where YEAR(NTNS) = @nam
	) 
-- Gọi hàm
select * from NSNV(1969)
--2. Tạo hàm với đầu vào là số thâm niên (số năm làm việc) đầu ra là danh sách nhân viên có thâm niên đó 
alter function  ThamNien (@thamnien int)
returns table 
as
return(      
	select MaNV, Ho + ' ' + Ten as HoTen, year(getdate()) - year(NgayBD) as NamThamNien
	from tNhanVien  
	where year(getdate()) - year(NgayBD) = @thamnien
	)
-- Gọi hàm
select * from ThamNien(30)
--3. Tạo hàm đầu vào là chức vụ đầu ra là những nhân viên cùng chức vụ đó 
CREATE FUNCTION ChucVu(@chucvu NVARCHAR(10))
RETURNS TABLE 
AS
RETURN(   
	select tChiTietNhanVien.MaNV,tNhanVien.Ho + ' ' + tNhanVien.Ten as HoTen, tChiTietNhanVien.Chucvu   
	from tChiTietNhanVien join tNhanVien on tChiTietNhanVien.MaNV = tNhanVien.MaNV
	where tChiTietNhanVien.Chucvu = @chucvu
	)   
-- Gọi hàm
select * from ChucVu('PGD')
--4. Tạo hàm đưa ra thông tin về nhân viên được tăng lương của ngày hôm nay (giả sử 3 năm lên lương 1 lần)
create function TangLuong()
returns table 
as
return(      
	select MaNV,Ho + ' ' + Ten as HoTen, FLOOR(DATEDIFF(DAY, NgayBD, GETDATE()) / (365.0 * 3)) as 'Số lần tăng lương'  
	from tnhanvien  
	where DATEDIFF(DAY, NgayBD, GETDATE()) >= (365.0 * 3)
	)
--Gọi hàm
select *from TangLuong()
--5.  
CREATE FUNCTION BangLuongNhanVien()
RETURNS TABLE
AS
RETURN
(
    WITH TinhLuong AS (
        SELECT nv.MaNV, nv.HO + ' ' + nv.TEN AS HoTen,nv.MaPB,pb.TENPB,ctnv.ChucVu,ctnv.HSLuong,
            CASE WHEN ctnv.MucDoCV like 'A%' THEN 10000000
                WHEN ctnv.MucDoCV like 'B%' THEN 8000000
                WHEN ctnv.MucDoCV like 'C%' THEN 5000000
                ELSE 0 END AS PhuCap,
            (14900000 * ctnv.HSLuong) + CASE 
                WHEN ctnv.MucDoCV like 'A%' THEN 10000000
                WHEN ctnv.MucDoCV like 'B%' THEN 8000000
                WHEN ctnv.MucDoCV like 'C%' THEN 5000000
                ELSE 0
            END AS TongLuong,
            ISNULL(ctnv.GTGC, 0) * 4400000 AS GiamTruGiaCanh,
            11000000 AS MucChiuThue
        FROM tNhanVien nv
        JOIN tChiTietNhanVien ctnv ON nv.MaNV = ctnv.MaNV
        JOIN tPhongBan pb ON nv.MaPB = pb.MaPB
    ),
    TinhThue AS (
        SELECT *, 0.08 * TongLuong AS BHXH, 0.015 * TongLuong AS BHYT, 
		0.01 * TongLuong AS BHTN,
            (TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) AS ThuNhapChiuThue,
            CASE
                WHEN (TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) <= 5000000 THEN (TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) * 0.05
                WHEN (TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) <= 10000000 THEN ((TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) * 0.1) - 250000
                WHEN (TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) <= 18000000 THEN ((TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) * 0.15) - 750000
                WHEN (TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) <= 32000000 THEN ((TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) * 0.2) - 1650000
                WHEN (TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) <= 52000000 THEN ((TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) * 0.25) - 3250000
                WHEN (TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) <= 80000000 THEN ((TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) * 0.3) - 5850000
                ELSE ((TongLuong - (0.08 * TongLuong + 0.015 * TongLuong + 0.01 * TongLuong + 11000000 + GiamTruGiaCanh)) * 0.35) - 9850000
            END AS ThueTNCN
        FROM TinhLuong
    )
    SELECT 
        MaNV, HoTen, TENPB AS PhongBan, ChucVu, PhuCap, TongLuong, BHXH,
        BHYT, BHTN, ThuNhapChiuThue,
        ThueTNCN, (TongLuong - (BHXH + BHYT + BHTN + ThueTNCN)) AS ThucLinh
    FROM TinhThue
)
--Gọi hàm
SELECT * FROM BangLuongNhanVien()

--6. Tạo thủ tục có đầu vào là mã phòng, đầu ra là số nhân viên của phòng đó và tên trưởng phòng 
CREATE PROCEDURE ThongTinPhongBan @MaPB NVARCHAR(10), @SoNhanVien INT OUTPUT, 
    @TenTruongPhong NVARCHAR(100) OUTPUT
AS
BEGIN
    SELECT @TenTruongPhong = nv.HO + ' ' + nv.TEN
    FROM tPhongBan pb
    JOIN tNhanVien nv ON pb.TruongPhong = nv.MaNV
    WHERE pb.MaPB = @MaPB
    
    SELECT @SoNhanVien = COUNT(*)
    FROM tNhanVien
    WHERE MaPB = @MaPB
END
--Gọi hàm
DECLARE @SoNhanVien INT, @TenTruongPhong NVARCHAR(100)
EXEC ThongTinPhongBan 'KH', @SoNhanVien OUTPUT, @TenTruongPhong OUTPUT
SELECT @SoNhanVien AS SoNhanVien, @TenTruongPhong AS TenTruongPhong

--7. Tạo thủ tục có đầu vào là mã phòng, tháng, năm, đầu ra là số tiền lương của phòng đó
CREATE PROCEDURE TinhLuongTheoThangNam @MaPB NVARCHAR(10),    
    @Thang INT, @Nam INT, @TongLuong BIGINT OUTPUT 
AS
BEGIN
    DECLARE @NgayBD DATETIME = DATEFROMPARTS(@Nam, @Thang, 1)
    SELECT @TongLuong = SUM(
        (1490000 * CASE          
                WHEN DATEDIFF(MONTH, nv.NgayBD,  @NgayBD) >= 36 THEN 
                    ctnv.HSLuong + FLOOR(DATEDIFF(MONTH, nv.NgayBD, @NgayBD) / 36.0)
                ELSE ctnv.HSLuong
            END
        ) + CASE 
				WHEN ctnv.MucDoCV like 'A%' THEN 10000000
				WHEN ctnv.MucDoCV like 'B%' THEN 8000000
				WHEN ctnv.MucDoCV like 'C%' THEN 5000000
				ELSE 0
            END
    )
    FROM tNhanVien nv
    JOIN tChiTietNhanVien ctnv ON nv.MaNV = ctnv.MaNV
    WHERE nv.MaPB = @MaPB
    AND nv.NgayBD <= @NgayBD
END
--Gọi hàm
DECLARE @TongLuong BIGINT
EXEC TinhLuongTheoThangNam 'TC', 6, 2020, @TongLuong OUTPUT
SELECT @TongLuong AS N'Tổng lương theo phòng'


