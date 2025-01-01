--Câu 6
select tHoaDonBan.SoHDB, (tChiTietHDB.SLBan * tSach.DonGiaBan) as GiaTriHoaDonBan
from (tHoaDonBan inner join tChiTietHDB on tHoaDonBan.SoHDB = tChiTietHDB.SoHDB) inner join tSach on tChiTietHDB.MaSach = tSach.MaSach
where month(tHoaDonBan.NgayBan) = 4 and year(tHoaDonBan.NgayBan) = 2014
order by day(tHoaDonBan.NgayBan) asc, GiaTriHoaDonBan desc

--8
select tChiTietHDB.SoHDB as N'Số hóa đơn bán', sum(tChiTietHDB.SLBan*tSach.DonGiaBan) as N'Trị Giá' 
from tHoaDonBan join tChiTietHDB on tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
join tSach on tChiTietHDB.MaSach=tSach.MaSach
join tNhanVien on tHoaDonBan.MaNV=tNhanVien.MaNV
where (tHoaDonBan.NgayBan ='2014-08-11') and tNhanVien.TenNV like N'Trần Huy'
group by tChiTietHDB.SoHDB

--9
select tSach.MaSach,TenSach
from tSach join tChiTietHDB on tSach.MaSach=tChiTietHDB.MaSach
join tHoaDonBan on tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
join tKhachHang on tKhachHang.MaKH=tHoaDonBan.MaKH
where tKhachHang.TenKH = N'Nguyễn Đình Sơn' and MONTH(tHoaDonBan.NgayBan)=8
AND Year(tHoaDonBan.NgayBan)=2014 

--10
select SoHDB
from tChiTietHDB join tSach on tChiTietHDB.MaSach=tSach.MaSach
where tSach.TenSach = N'Cấu trúc dữ liệu và giải thuật'


--1
select MaSach,TenSach
from (tSach INNER JOIN tNhaXuatBan ON tSach.MaNXB = tNhaXuatBan.MaNXB)
where  tNhaXuatBan.TenNXB = N'NXB Giáo Dục';

--2
select *
from tSach
where TenSach like 'Ngày%';
--3
select MaSach,TenSach
from (tSach INNER JOIN tNhaXuatBan ON tSach.MaNXB = tNhaXuatBan.MaNXB)
where  tNhaXuatBan.TenNXB = N'NXB Giáo Dục' and tSach.DonGiaBan between 10000 and 150000
--4
select MaSach,TenSach
from tSach join tNhaXuatBan on tSach.MaNXB=tNhaXuatBan.MaNXB
where (tNhaXuatBan.TenNXB = N'NXB Giáo Dục' or tNhaXuatBan.TenNXB = N'NXB Trẻ' )and tSach.DonGiaBan between 90000 and 140000

--5
select tChiTietHDB.SoHDB as N'Số hóa đơn bán', sum(tChiTietHDB.SLBan*tSach.DonGiaBan) as N'Trị Giá' 
from tHoaDonBan join tChiTietHDB on tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
join tSach on tChiTietHDB.MaSach=tSach.MaSach
where tHoaDonBan.NgayBan ='2013-01-01' or tHoaDonBan.NgayBan='2013-12-31'
group by tChiTietHDB.SoHDB


--6
SELECT tChiTietHDB.SoHDB AS N'Số hóa đơn bán', 
       SUM(tChiTietHDB.SLBan * tSach.DonGiaBan) AS TriGia 
FROM tHoaDonBan 
JOIN tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB 
JOIN tSach ON tChiTietHDB.MaSach = tSach.MaSach 
WHERE MONTH(tHoaDonBan.NgayBan) = 4 AND YEAR(tHoaDonBan.NgayBan) = 2014 
GROUP BY tChiTietHDB.SoHDB 
ORDER BY tHoaDonBan.NgayBan ASC, TriGia DESC;

--7
select tKhachHang.MaKH,TenKH
from tKhachHang join tHoaDonBan on tKhachHang.MaKH=tHoaDonBan.MaKH
where  MONTH(tHoaDonBan.NgayBan)=4 
AND Year(tHoaDonBan.NgayBan)=2014 and day(thoaDonBan.NgayBan)=10

--8
select tChiTietHDB.SoHDB as N'Số hóa đơn bán', sum(tChiTietHDB.SLBan*tSach.DonGiaBan) as N'Trị Giá' 
from tHoaDonBan join tChiTietHDB on tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
join tSach on tChiTietHDB.MaSach=tSach.MaSach
join tNhanVien on tHoaDonBan.MaNV=tNhanVien.MaNV
where (tHoaDonBan.NgayBan ='2014-08-11') and tNhanVien.TenNV like N'Trần Huy'
group by tChiTietHDB.SoHDB

--9
select tSach.MaSach,TenSach
from tSach join tChiTietHDB on tSach.MaSach=tChiTietHDB.MaSach
join tHoaDonBan on tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
join tKhachHang on tKhachHang.MaKH=tHoaDonBan.MaKH
where tKhachHang.TenKH = N'Nguyễn Đình Sơn' and MONTH(tHoaDonBan.NgayBan)=8
AND Year(tHoaDonBan.NgayBan)=2014 

--10
select SoHDB
from tChiTietHDB join tSach on tChiTietHDB.MaSach=tSach.MaSach
where tSach.TenSach = N'Cấu trúc dữ liệu và giải thuật'

--11
select SoHDB
from tChiTietHDB
where MaSach ='S01' or MaSach = 'S02' and SLBan between 10 and 20;

--12
select SoHDB
from tChiTietHDB
where MaSach ='S10' and MaSach = 'S11' and SLBan between 5 and 10;

--13
select *
from tChiTietHDB
where SLBan = 0

--14
select *
from tChiTietHDB join tHoaDonBan on tChiTietHDB.SoHDB=tHoaDonBan.SoHDB
where tChiTietHDB.SLBan = 0 and year(tHoaDonBan.NgayBan)=2014 

--15
select *
from tChiTietHDB join tHoaDonBan on tChiTietHDB.SoHDB=tHoaDonBan.SoHDB
join tSach on tChiTietHDB.MaSach=tSach.MaSach
join tNhaXuatBan on tNhaXuatBan.MaNXB=tSach.MaNXB
where tChiTietHDB.SLBan = 0 and year(tHoaDonBan.NgayBan)=2014 and tNhaXuatBan.TenNXB = N'NXB Giáo Dục'

--16
select tChiTietHDB.SoHDB
from tChiTietHDB join tHoaDonBan on tChiTietHDB.SoHDB=tHoaDonBan.SoHDB
join tSach on tChiTietHDB.MaSach=tSach.MaSach
join tNhaXuatBan on tNhaXuatBan.MaNXB=tSach.MaNXB
where tNhaXuatBan.TenNXB = N'NXB Giáo Dục'

--17
SELECT COUNT(DISTINCT MaSach) AS 'Số lượng đầu sách khác nhau được bán ra trong năm 2014'
FROM tChiTietHDB 
JOIN tHoaDonBan ON tChiTietHDB.SoHDB = tHoaDonBan.SoHDB
WHERE YEAR(tHoaDonBan.NgayBan) = 2014;


--18
SELECT 
    N'Số hóa đơn bán' AS [Số hóa đơn bán], 
    SUM(TotalPrice) AS [Trị Giá],
    MAX(TotalPrice) AS [Max Trị Giá],
    MIN(TotalPrice) AS [Min Trị Giá]
FROM (
    SELECT 
        tChiTietHDB.SoHDB, 
        SUM(tChiTietHDB.SLBan * tSach.DonGiaBan) AS TotalPrice
    FROM 
        tHoaDonBan 
    JOIN 
        tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    JOIN 
        tSach ON tChiTietHDB.MaSach = tSach.MaSach
    GROUP BY 
        tChiTietHDB.SoHDB
) AS Subquery;

--19
select avg (totalprice) as [Trị Giá Trung Bình]
from (
select sum(tChiTietHDB.SLBan*tSach.DonGiaBan) as totalprice
from tHoaDonBan join tChiTietHDB on tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
join tSach on tChiTietHDB.MaSach=tSach.MaSach
where year(tHoaDonBan.NgayBan) =2014
group by tChiTietHDB.SoHDB
)AS Subquery;

--20
select sum(totalprice) as [Doanh Thu]
from(
select sum(tChiTietHDB.SLBan*tSach.DonGiaBan) as totalprice
from tHoaDonBan join tChiTietHDB on tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
join tSach on tChiTietHDB.MaSach=tSach.MaSach
where year(tHoaDonBan.NgayBan) =2014
group by tChiTietHDB.SoHDB
)AS Subquery;

--21
SELECT TOP 1 SoHDB
FROM (
    SELECT 
        tChiTietHDB.SoHDB, 
        SUM(tChiTietHDB.SLBan * tSach.DonGiaBan) AS totalprice
    FROM 
        tHoaDonBan 
    JOIN 
        tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    JOIN 
        tSach ON tChiTietHDB.MaSach = tSach.MaSach
    WHERE 
        YEAR(tHoaDonBan.NgayBan) = 2014
    GROUP BY 
        tChiTietHDB.SoHDB
) AS Subquery
ORDER BY 
    totalprice DESC;


--22
SELECT TOP 1 TenKH
FROM (
    SELECT 
        tKhachHang.TenKH, 
        SUM(tChiTietHDB.SLBan * tSach.DonGiaBan) AS totalprice
    FROM 
        tHoaDonBan 
    JOIN 
        tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    JOIN 
        tSach ON tChiTietHDB.MaSach = tSach.MaSach
	JOIN 
	    tKhachHang ON tKhachHang.MaKH = tHoaDonBan.MaKH
    WHERE 
        YEAR(tHoaDonBan.NgayBan) = 2014
    GROUP BY 
        tKhachHang.TenKH
) AS Subquery
ORDER BY 
    totalprice DESC;


--23
SELECT MaKH, TenKH
FROM (
    SELECT 
        tHoaDonBan.MaKH,
        tKhachHang.TenKH,
        SUM(tChiTietHDB.SLBan * tSach.DonGiaBan) AS TotalRevenue,
        ROW_NUMBER() OVER (ORDER BY SUM(tChiTietHDB.SLBan * tSach.DonGiaBan) DESC) AS RowNum
    FROM 
        tHoaDonBan 
    JOIN 
        tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
    JOIN 
        tSach ON tChiTietHDB.MaSach = tSach.MaSach
    JOIN
        tKhachHang ON tHoaDonBan.MaKH = tKhachHang.MaKH
    GROUP BY 
        tHoaDonBan.MaKH, tKhachHang.TenKH
) AS RankedCustomers
WHERE 
    RowNum <= 3;

--24
SELECT MaSach, TenSach, DonGiaBan
FROM (
    SELECT 
        MaSach,
        TenSach,
        DonGiaBan,
        ROW_NUMBER() OVER (ORDER BY DonGiaBan DESC) AS RowNum
    FROM tSach
) AS RankedBooks
WHERE 
    RowNum <= 3;


--25
SELECT MaSach, TenSach, DonGiaBan
FROM (
    SELECT 
        MaSach,
        TenSach,
        DonGiaBan,
        ROW_NUMBER() OVER (ORDER BY DonGiaBan DESC) AS RowNum
    FROM tSach
	JOIN tNhaXuatBan ON tNhaXuatBan.MaNXB=tSach.MaNXB
	WHERE tNhaXuatBan.TenNXB=N'NXB Giáo Dục'
) AS RankedBooks
WHERE 
    RowNum <= 3;

--26
SELECT COUNT(*) AS [Tổng số đầu sách:]
FROM tSach
JOIN tNhaXuatBan ON tNhaXuatBan.MaNXB=tSach.MaNXB
WHERE tNhaXuatBan.TenNXB = N'NXB Giáo Dục'

--27
SELECT tNhaXuatBan.TenNXB, COUNT(tSach.MaSach) AS [Tổng số sách]
FROM tNhaXuatBan
JOIN tSach ON tNhaXuatBan.MaNXB = tSach.MaNXB
GROUP BY tNhaXuatBan.TenNXB;

--28
SELECT 
    tNhaXuatBan.TenNXB, 
    MAX(tSach.DonGiaBan) AS [Giá Bán Cao Nhất],
    MIN(tSach.DonGiaBan) AS [Giá Bán Thấp Nhất],
    AVG(tSach.DonGiaBan) AS [Trung bình của các sản phẩm]
FROM 
    tNhaXuatBan
JOIN 
    tSach ON tNhaXuatBan.MaNXB = tSach.MaNXB
GROUP BY 
    tNhaXuatBan.TenNXB;

--29
SELECT 
    tHoaDonBan.NgayBan AS [Ngày],
    SUM(tChiTietHDB.SLBan * tSach.DonGiaBan) AS [Doanh Thu]
FROM 
    tHoaDonBan 
JOIN 
    tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
JOIN 
    tSach ON tChiTietHDB.MaSach = tSach.MaSach
GROUP BY 
    tHoaDonBan.NgayBan;

--30
SELECT tSach.TenSach, COUNT(tSach.MaSach) AS [Tổng số sách]
FROM tSach
JOIN tChiTietHDB ON tChiTietHDB.MaSach=tSach.MaSach
JOIN tHoaDonBan ON tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
WHERE MONTH(tHoaDonBan.NgayBan)=10 AND YEAR(tHoaDonBan.NgayBan)=2014
GROUP BY tSach.TenSach;

--31
SELECT 
    Months.Month AS [Tháng],
    ISNULL(SUM(tChiTietHDB.SLBan * tSach.DonGiaBan), 0) AS [Doanh Thu]
FROM 
    (
        SELECT 1 AS Month
        UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5 UNION SELECT 6 
        UNION SELECT 7 UNION SELECT 8 UNION SELECT 9 UNION SELECT 10 UNION SELECT 11 
        UNION SELECT 12
    ) AS Months
LEFT JOIN 
    tHoaDonBan ON MONTH(tHoaDonBan.NgayBan) = Months.Month AND YEAR(tHoaDonBan.NgayBan) = 2014
LEFT JOIN 
    tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
LEFT JOIN 
    tSach ON tChiTietHDB.MaSach = tSach.MaSach
GROUP BY 
    Months.Month
ORDER BY 
    Months.Month;

--32
SELECT 
    tChiTietHDB.SoHDB AS [Số hóa đơn]
FROM 
    tChiTietHDB
GROUP BY 
    tChiTietHDB.SoHDB
HAVING 
    COUNT(DISTINCT tChiTietHDB.MaSach) >= 4;


--33
SELECT 
    tChiTietHDB.SoHDB AS [Số hóa đơn]
FROM 
    tChiTietHDB
    JOIN tSach ON tSach.MaSach = tChiTietHDB.MaSach
    JOIN tNhaXuatBan ON tNhaXuatBan.MaNXB = tSach.MaNXB
WHERE 
    tNhaXuatBan.TenNXB = N'NXB Giáo Dục'
GROUP BY 
    tChiTietHDB.SoHDB
HAVING 
    COUNT(DISTINCT tChiTietHDB.MaSach) = 3;

--34
SELECT 
    tKhachHang.MaKH, TenKH
FROM 
    tKhachHang
JOIN 
    tHoaDonBan ON tHoaDonBan.MaKH = tKhachHang.MaKH
GROUP BY 
    tKhachHang.MaKH, tKhachHang.TenKH
HAVING 
    COUNT(DISTINCT tHoaDonBan.SoHDB) = (
        SELECT 
            MAX(OrderCount)
        FROM 
            (SELECT 
                MaKH, COUNT(DISTINCT SoHDB) AS OrderCount
            FROM 
                tHoaDonBan
            GROUP BY 
                MaKH) AS SubQuery
    );

--35
SELECT top 1
    MONTH(NgayBan) AS [Tháng],
    SUM(SLBan * DonGiaBan) AS [Doanh Số]
FROM 
    tHoaDonBan
JOIN 
    tChiTietHDB ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
JOIN 
    tSach ON tChiTietHDB.MaSach = tSach.MaSach
WHERE 
    YEAR(NgayBan) = 2014
GROUP BY 
    MONTH(NgayBan)
ORDER BY 
    [Doanh Số] DESC

--36
SELECT TOP 1
       tSach.TenSach AS [Tên Sách],
       SUM(tChiTietHDB.SLBan) AS [Tổng Số lượng Bán]
FROM 
    tSach
JOIN 
    tChiTietHDB ON tChiTietHDB.MaSach = tSach.MaSach
JOIN 
    tHoaDonBan ON tHoaDonBan.SoHDB = tChiTietHDB.SoHDB
WHERE 
    YEAR(tHoaDonBan.NgayBan) = 2014
GROUP BY
    tSach.TenSach
ORDER BY 
    [Tổng Số lượng Bán] ASC;

--37
SELECT 
    NXB.TenNXB,
    Sach.MaSach,
    Sach.TenSach,
    Sach.DonGiaBan AS [Giá Bán Cao Nhất]
FROM 
    tSach AS Sach
JOIN 
    tNhaXuatBan AS NXB ON Sach.MaNXB = NXB.MaNXB
JOIN (
    SELECT 
        MaNXB,
        MaSach,
        TenSach,
        DonGiaBan,
        ROW_NUMBER() OVER (PARTITION BY MaNXB ORDER BY DonGiaBan DESC) AS RowNum
    FROM 
        tSach
) AS RankedSach ON Sach.MaSach = RankedSach.MaSach
WHERE 
    RowNum = 1;

--38
UPDATE tSach
SET DonGiaBan = DonGiaBan * 0.9
WHERE MaNXB IN (SELECT MaNXB FROM tNhaXuatBan WHERE TenNXB = N'NXB Giáo Dục');

--39
ALTER TABLE tHoaDonBan
ADD TongTien DECIMAL(18, 2); 

UPDATE tHoaDonBan
SET TongTien = (
    SELECT SUM(tChiTietHDB.SLBan * tSach.DonGiaBan)
    FROM tChiTietHDB
    JOIN tSach ON tChiTietHDB.MaSach = tSach.MaSach
    WHERE tChiTietHDB.SoHDB = tHoaDonBan.SoHDB
);

--40
UPDATE tHoaDonBan
SET TongTien = TongTien * 0.9 
WHERE MONTH(NgayBan) = 9 
AND YEAR(NgayBan) = 2014 
AND TongTien > 500000; 

--41
SELECT COUNT(SLNhap) as [Tổng số lượng nhập]
FROM tChiTietHDN
JOIN tHoaDonNhap ON tHoaDonNhap.SoHDN=tChiTietHDN.SoHDN
WHERE YEAR(tHoaDonNhap.NgayNhap)=2014

--42
SELECT COUNT(SLBan) as [Tổng số lượng bán]
FROM tChiTietHDB
JOIN tHoaDonBan ON tHoaDonBan.SoHDB=tChiTietHDB.SoHDB
WHERE YEAR(tHoaDonBan.NgayBan)=2014

--43
SELECT SUM( tChiTietHDN.SLNhap*tSach.DonGiaNhap) as [Tổng tiền đã nhập]
FROM tChiTietHDN
JOIN tHoaDonNhap ON tHoaDonNhap.SoHDN=tChiTietHDN.SoHDN
JOIN tSach ON tSach.MaSach=tChiTietHDN.MaSach
WHERE YEAR(tHoaDonNhap.NgayNhap)=2014

--44
-- Xóa chi tiết hóa đơn
DELETE FROM tChiTietHDB
WHERE SoHDB IN (
    SELECT SoHDB
    FROM tHoaDonBan
    WHERE MaNV IN (
        SELECT MaNV
        FROM tNhanVien
        WHERE TenNV = N'Trần Huy'
    )
);

-- Xóa các hóa đơn
DELETE FROM tHoaDonBan
WHERE MaNV IN (
    SELECT MaNV
    FROM tNhanVien
    WHERE TenNV = N'Trần Huy'
);

--45
UPDATE tNhaXuatBan
SET TenNXB = N'NXB Văn học'
WHERE TenNXB = N'NXB Thăng Long';

--46
SELECT 
    tSach.MaSach,
    tSach.TenSach,
    tSach.DonGiaBan,
    COALESCE(SUM(CASE WHEN YEAR(tHoaDonBan.NgayBan) = 2014 THEN tChiTietHDB.SLBan ELSE 0 END), 0) AS 'SL Bán 2014'
FROM 
    tSach
LEFT JOIN 
    tChiTietHDB ON tSach.MaSach = tChiTietHDB.MaSach
LEFT JOIN 
    tHoaDonBan ON tChiTietHDB.SoHDB = tHoaDonBan.SoHDB
GROUP BY 
    tSach.MaSach,
    tSach.TenSach,
    tSach.DonGiaBan;
