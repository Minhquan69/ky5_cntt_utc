create trigger TinhSoNT
on PHIEUTHUE
for insert
as
begin
		update PHONG 
		set SoNgayThue = SoNgayThue + DATEDIFF(DAY, Thoigiancheckin, Thoigiancheckout)
		from inserted
		where PHONG.Maphong = inserted.Maphong
end
--Thêm trường ngày thuê vào trong bảng phòng, cập nhật tự động
ALTER TABLE PHONG
ADD SoNgayThue int

create trigger TinhSoNgayThue
on PHIEUTHUE
for insert, delete, update
as
begin
		declare @maphong_ins nvarchar(10), @maphong_del nvarchar(10),
		@ngay_ins int, @ngay_del int
		select @maphong_ins = Maphong, @ngay_ins = DATEDIFF(DAY, Thoigiancheckin, Thoigiancheckout) from inserted
		select @maphong_del = Maphong, @ngay_del = DATEDIFF(DAY, Thoigiancheckin, Thoigiancheckout) from deleted
		update PHONG set SoNgayThue = isnull(SoNgayThue, 0) + @ngay_ins where Maphong = @maphong_ins
		update PHONG set SoNgayThue = isnull(SoNgayThue, 0) - @ngay_del where Maphong = @maphong_del
end
select MaPT ,DATEDIFF(DAY, Thoigiancheckin, Thoigiancheckout)
from PHIEUTHUE 
-- Bảng KHACHHANG
CREATE TABLE KHACHHANG (
    ma_khach_hang INT PRIMARY KEY,
    ho_va_ten NVARCHAR(100),
    dia_chi NVARCHAR(255),
    dien_thoai VARCHAR(15),
    can_cuoc_cong_dan VARCHAR(20),
    gioi_tinh NVARCHAR(10),
    ngay_sinh DATE
);
-- Bảng HOADONTT
CREATE TABLE HOADONTT (
    ma_hoa_don INT PRIMARY KEY,
    ma_dat_phong INT,
    ngay_thanh_toan DATE,
    ngay_lap_hoa_don DATE,
    phuong_thuc NVARCHAR(50),
    ma_nhan_vien INT,
    ghi_chu NVARCHAR(255),
    FOREIGN KEY (ma_dat_phong) REFERENCES PHIEUDAT(ma_dat_phong),
    FOREIGN KEY (ma_nhan_vien) REFERENCES NHANVIEN(ma_nhan_vien)
);
-- Bảng NHANVIEN
CREATE TABLE NHANVIEN (
    ma_nhan_vien INT PRIMARY KEY,
    ho_va_ten NVARCHAR(100),
    so_can_cuoc_cong_dan VARCHAR(20),
    so_dien_thoai VARCHAR(15),
    ngay_sinh DATE,
    gioi_tinh NVARCHAR(10),
    chuc_vu NVARCHAR(50)
);
-- Bảng PHIEUDAT
CREATE TABLE PHIEUDAT (
    ma_dat_phong INT PRIMARY KEY,
    tien_dat_coc DECIMAL(18, 2),
    ngay_den_du_kien DATE,
    ngay_di_du_kien DATE,
    phuong_thuc_dat_coc NVARCHAR(50),
    ma_khach_hang INT,
    FOREIGN KEY (ma_khach_hang) REFERENCES KHACHHANG(ma_khach_hang)
);
-- Bảng PHIEUTHUE
CREATE TABLE PHIEUTHUE (
    ma_phieu_thue INT PRIMARY KEY,
    ma_dat_phong INT,
    thoi_gian_lap_phieu DATETIME,
    thoi_gian_check_out DATETIME,
    thoi_gian_check_in DATETIME,
    khuyen_mai_phong DECIMAL(18, 2),
    ma_phong INT,
    FOREIGN KEY (ma_dat_phong) REFERENCES PHIEUDAT(ma_dat_phong),
    FOREIGN KEY (ma_phong) REFERENCES PHONG(ma_phong)
);
-- Bảng PHONG
CREATE TABLE PHONG (
    ma_phong INT PRIMARY KEY,
    ma_loai_phong INT,
    tinh_trang NVARCHAR(50),
    FOREIGN KEY (ma_loai_phong) REFERENCES LOAIPHONG(ma_loai_phong)
);

-- Bảng LOAIPHONG
CREATE TABLE LOAIPHONG (
    ma_loai_phong INT PRIMARY KEY,
    kieu_phong NVARCHAR(50),
    dien_tich DECIMAL(10, 2),
    don_gia_thue DECIMAL(18, 2)
);
-- Bảng CHITIETPHONGDAT
CREATE TABLE CHITIETPHONGDAT (
    ma_dat_phong INT,
    ma_loai_phong INT,
    so_luong_phong INT,
    PRIMARY KEY (ma_dat_phong, ma_loai_phong),
    FOREIGN KEY (ma_dat_phong) REFERENCES PHIEUDAT(ma_dat_phong),
    FOREIGN KEY (ma_loai_phong) REFERENCES LOAIPHONG(ma_loai_phong)
);
--Câu 2 Tạo thủ tục có đầu vào là mã khách hàng, năm ,đầu ra là số lượng hóa đơn của mã khách hàng trong năm đó
--(năm được tính dựa trên ngày thanh toán)
CREATE PROCEDURE DemHoaDonKhachHang @makh nvarchar(10),@nam INT
AS
BEGIN
    SELECT COUNT(*) AS SoLuongHoaDon
    FROM HOADONTT
    WHERE MaBooking IN (SELECT MaBooking FROM PHIEUDAT WHERE MaKH = @makh)
    AND YEAR(NgayTT) = @nam
END
EXEC DemHoaDonKhachHang @Makh = 'KH0001', @nam = 2022
--Câu 3 Tạo hàm có đầu vào lã mã Booking, đầu ta là danh sách các thông tin chi tiết phòng thuê của mã Booking đó đó, các thông tin đưa ra gỗm Mã Booking, Mã Khách Hàng,Kiểu phòng,Mã Phòng,Thời gian check in,Thời gian check out)
CREATE FUNCTION LayChiTietPhongThue (@malp nvarchar(10))
RETURNS TABLE
AS
RETURN (SELECT LP.MaLP as N'Mã loại phòng', LP.Kieuphong as N'Kiểu phòng',LP.Dientich as N'Diện tích', P.Maphong as N'Mã phòng'
    FROM LOAIPHONG LP
    JOIN PHONG P ON P.MaLP = LP.MaLP  
    WHERE LP.MaLP = @malp
)
SELECT * FROM LayChiTietPhongThue('PD0001')
--Câu 5 Tạo view gồm các thông tin mã nhân viên ,tên nhân viên,mã HDTT,Ngày lập HD,Ngày thanh toán,phương thức thanh toán ,mã booking,ngày đến dự kiến ,ngày đi dự kiến có ngày đến dự kiến từ ngày 12/12/2022 đến ngày 19/12/2022
CREATE VIEW ThongTinNhanVienHoaDon AS
SELECT NV.MaNV,NV.TenNV,HD.MaHDTT,HD.NgayLapHD,HD.NgayTT,HD.PhuongthucTT,PD.MaBooking,PD.NgayDenDukien,PD.NgayDiDuKien
FROM NHANVIEN NV
JOIN HOADONTT HD ON NV.MaNV = HD.MaNV
JOIN PHIEUDAT PD ON HD.MaBooking = PD.MaBooking
WHERE PD.NgayDenDukien BETWEEN '2022-12-12' AND '2022-12-19'
--Câu 6 Tạo login NguyenDucThuan,tạo user NguyenDucThuan cho login NguyenDucThuan trên CSDL đã cho ,Phân quyền Select Insert,update trên Bảng phiếu đặt cho NguyenDucThuan,và NguyenDucThuan được phép phân quyền cho người khác
-- Tạo login NguyenDucThuan
exec sp_addlogin NguyenDucThuan, 1234
--tạo user NguyenDucThuan cho login NguyenDucThuan
USE QLBanSach
exec sp_adduser  NguyenDucThuan,  NguyenDucThuan
-- Phân quyền Select, Insert, Update trên bảng PHIEUDAT
GRANT SELECT, INSERT, UPDATE ON PHIEUDAT TO NguyenDucThuan with grant option
--Câu 7 Tạo thủ tục có đàu vào là năm bắt đầu ,năm kết thúc ,đầu ra là ba tháng trong năm có tổng doanh thu cao nhất
--(ví dụ từ năm 2020 đến năm 2022 thì tháng 6,7,8 là những tháng có doanh thu cao nhất,tháng lấy theo ngày thanh toán)
CREATE PROCEDURE DoanhThuCaoNhat @nam_bat_dau INT, @nam_ket_thuc INT
AS
BEGIN
    SELECT TOP 3 MONTH(NgayTT) AS Thang, SUM(ct.SLPhong*lp.Dongiaphong) as TongDoanhThu
    FROM HOADONTT hd join CHITIETPHONGDAT ct on hd.MaBooking=ct.MaBooking
    join LOAIPHONG lp on ct.MaLP = lp.MaLP
	WHERE YEAR(NgayTT) BETWEEN @nam_bat_dau AND @nam_ket_thuc
    GROUP BY MONTH(NgayTT)
    ORDER BY TongDoanhThu DESC
END

exec DoanhThuCaoNhat @nam_bat_dau=2020, @nam_ket_thuc = 2022