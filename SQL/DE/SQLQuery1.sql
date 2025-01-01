--Mau 1
--Câu 1: Tạo hàm đưa ra danh sách các nhân viên có địa chỉ cho trước với địa chỉ là tham số đầu vào.
CREATE FUNCTION LayDanhSachNhanVienTheoDiaChi (@DiaChi NVARCHAR(255))
RETURNS TABLE
AS
RETURN(
    SELECT MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai
    FROM tNhanVien
    WHERE DiaChi = @DiaChi
)

SELECT * FROM LayDanhSachNhanVienTheoDiaChi(N'Hà Nội')
--Câu 2: Tạo thủ tục có đầu vào là tỉnh (thành phố) đầu ra là số nhân viên nam, số nhân viên nữ của tỉnh (thành phố) đó.
CREATE PROCEDURE DemNhanVienTheoGioiTinhVaDiaChi
    @TinhThanh NVARCHAR(255)
AS
BEGIN
    SELECT DiaChi,
           SUM(CASE WHEN GioiTinh = 'Nam' THEN 1 ELSE 0 END) AS SoNam,
           SUM(CASE WHEN GioiTinh = N'Nữ' THEN 1 ELSE 0 END) AS SoNu
    FROM tNhanVien
    WHERE DiaChi = @TinhThanh
    GROUP BY DiaChi
END
EXEC DemNhanVienTheoGioiTinhVaDiaChi N'Nam Định'

--Câu 3: Tạo view đưa ra thông tin các nhân viên và hóa đơn bán, hóa đơn nhập họ đã xử lý của các nhân viên ở HN trong năm 2014
CREATE VIEW View_NhanVien_HoaDon_HN_2014 AS
SELECT NV.MaNV,NV.TenNV, NV.DiaChi, COUNT(DISTINCT HDB.SoHDB) AS SoLuongHDBan,
    COUNT(DISTINCT HDN.SoHDN) AS SoLuongHDNhap
FROM tNhanVien NV
LEFT JOIN tHoaDonBan HDB ON NV.MaNV = HDB.MaNV AND YEAR(HDB.NgayBan) = 2014
LEFT JOIN tHoaDonNhap HDN ON NV.MaNV = HDN.MaNV AND YEAR(HDN.NgayNhap) = 2014
WHERE NV.DiaChi = N'Hà Nội'
GROUP BY NV.MaNV, NV.TenNV, NV.DiaChi
--Câu 4: Thêm trường Tổng tiền và bảng nhân viên, cập nhật tự động cho trường này mỗi khi thêm một chi tiết hóa đơn bán
ALTER TABLE tNhanVien
ADD TongTien DECIMAL(18, 2)

CREATE TRIGGER trg_UpdateTongTien_AfterInsert
ON tChiTietHDB
for INSERT
AS
BEGIN
    UPDATE tNhanVien
    SET TongTien =  isnull(TongTien,0) + (INSERTED.SLBan * S.DonGiaBan)
    from INSERTED JOIN tSach S ON INSERTED.MaSach = S.MaSach
	where tNhanVien.MaNV = (select tHoaDonBan.MaNV from inserted join tHoaDonBan on inserted.SoHDB=tHoaDonBan.SoHDB)
END

insert into tChiTietHDB(SoHDB,MaSach,SLBan) values ('HDB03','S16',10)
--Câu 5: Tạo login Tran Thanh Phong, tạo user TranThanhPhong cho Tran ThanhPhong trên CSDL QLBanSach 
--Phân quyền Select, update trên bảng tSach cho Tran Thanh Phong và Tran Thanh Phong được phép phân quyền cho người khác 
--Đăng nhập Tran Thanh Phong để kiểm tra 
--Tạo login PhamVanNam, tạo Pham VanNam cho Pham VanNam trên CSDL QLBanSach
--Đăng nhập Pham VanNam để kiểm tra 
--Từ login Tran Thanh Phong, phân quyền Select trên bảng tSach cho PhamVanNam 
--Đăng nhập Pham VanNam để kiểm tra
--Câu 6: Tạo view đưa ra những nhân viên có tổng tiền hóa đơn cao nhất và cao nhì trong năm 2014
CREATE VIEW TopNhanVien AS
SELECT Top 2 N.MaNV,N.TenNV,SUM(CT.SLBan * S.DonGiaBan) AS TongTien
FROM tNhanVien N
JOIN tHoaDonBan H ON N.MaNV = H.MaNV
JOIN tChiTietHDB CT ON H.SoHDB = CT.SoHDB
JOIN tSach S ON CT.MaSach = S.MaSach
WHERE YEAR(H.NgayBan) = 2014
GROUP BY N.MaNV, N.TenNV
ORDER BY TongTien DESC

--Mau 3
--Câu 1: Tạo hàm có đầu vào là tên thể loại đầu ra là thông tin các sách thuộc thể loại đó.
CREATE FUNCTION TimSachTheoTheLoai (@TenTheLoai NVARCHAR(255))
RETURNS TABLE
AS
RETURN (
    SELECT s.MaSach, s.TenSach, s.TacGia, s.DonGiaNhap, s.DonGiaBan, s.SoLuong, s.SoTrang, s.TrongLuong, s.Anh
    FROM tSach s
    JOIN tTheLoai tl ON s.MaTheLoai = tl.MaTheLoai
    WHERE tl.TenTheLoai = @TenTheLoai
)
SELECT * FROM TimSachTheoTheLoai(N'Bí quyết Cuộc sống')
--Câu 2: Tạo thủ tục có đầu vào là mã nhà xuất bản, đầu ra là số lượng đầu sách, 
--số lượng tiền nhập hàng mà cửa hàng đã nhập của nhà xuất bản đó.
CREATE PROCEDURE TinhSoLuongSachVaTienNhap @MaNXB nvarchar(10), @SoLuongSach INT OUTPUT, 
    @TongTienNhap DECIMAL(18,2) OUTPUT
AS
BEGIN
    SELECT @SoLuongSach = count(distinct ct.MaSach), @TongTienNhap = SUM(ct.SLNhap * s.DonGiaNhap)
    FROM tChiTietHDN ct
    JOIN tSach s ON ct.MaSach = s.MaSach
    JOIN tHoaDonNhap hdn ON hdn.SoHDN = ct.SoHDN
    WHERE s.MaNXB = @MaNXB
END

DECLARE @SoLuongSach INT, @TongTienNhap DECIMAL(18,2)
EXEC TinhSoLuongSachVaTienNhap @MaNXB = 'NXB10', @SoLuongSach = @SoLuongSach OUTPUT, @TongTienNhap = @TongTienNhap OUTPUT
SELECT @SoLuongSach AS SoLuongDauSach, @TongTienNhap AS TongTienNhapHang
--Câu 3: Tạo view đưa ra thông tin các nhà cung cấp và thông tin hóa đơn nhập, trị giá hóa đơn cửa hàng đã nhập trong năm 2014
CREATE VIEW v_ThongTinNhaCungCap_HoaDonNhap AS
SELECT NCC.MaNCC, NCC.TenNCC, HDN.SoHDN, 
       SUM(CTHDN.SLNhap * S.DonGiaNhap ) AS TriGiaHoaDon
FROM tNhaCungCap NCC
JOIN tHoaDonNhap HDN ON NCC.MaNCC = HDN.MaNCC
JOIN tChiTietHDN CTHDN ON HDN.SoHDN = CTHDN.SoHDN
JOIN tSach S ON CTHDN.MaSach = S.MaSach
WHERE YEAR(HDN.NgayNhap) = 2014
GROUP BY NCC.MaNCC, NCC.TenNCC, HDN.SoHDN

--Câu 4: Thêm trường Tổng số đầu sách vào bảng tNhaXuatBan, cập nhật tự động cho trưởng này mỗi khi thêm, sửa, xóa một cuốn sách
ALTER TABLE tNhaXuatBan
ADD TongSoDauSach INT

UPDATE tNhaXuatBan
SET TongSoDauSach = (
    SELECT COUNT(*) 
    FROM tSach 
    WHERE tSach.MaNXB = tNhaXuatBan.MaNXB
)

CREATE TRIGGER UpdateTongSoDauSach
ON tSach
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    declare @manxb_ins nvarchar(10),@manxb_del nvarchar(10)
	select @manxb_ins = MaNXB from inserted
	select @manxb_del = MaNXB from deleted
	update tNhaXuatBan set TongSoDauSach = isnull(TongSoDauSach,0)+1 where MaNXB=@manxb_ins
	update tNhaXuatBan set TongSoDauSach = isnull(TongSoDauSach,0)-1 where MaNXB=@manxb_del
END

insert into tSach(MaSach,MaNXB) values ('S22','NXB01')
delete from tSach WHERE	MaSach = 'S22'
--Câu 5: Tạo login Tran Thanh Phong, tạo user TranThanhPhong cho TranThanhPhong trên CSDL QLBanSach 
--Phân quyền Select, update trên bảng tSach cho Tran Thanh Phong và Tran Thanh Phong được phép phân quyền cho người khác 
--Đăng nhập Tran Thanh Phong để kiểm tra 
--Tạo login PhamVanNam, tạo Pham VanNam cho Pham VanNam trên CSDL QLBanSach
--Đăng nhập Pham VanNam để kiểm tra 
--Từ login Tran Thanh Phong, phân quyền Select trên bảng tSach cho PhamVanNam 
--Đăng nhập Pham VanNam để kiểm tra
--Câu 6: Tạo thủ tục thống kê số lượng hóa đơn mà không tồn tại chi tiết hóa đơn, đồng thời xóa những bản ghi mồ côi này.
CREATE PROCEDURE ThongKeVaXoaHoaDonMoCo
AS
BEGIN
    SELECT COUNT(*) AS SoLuongHoaDonRong
    FROM tHoaDonBan
    WHERE SoHDB NOT IN (SELECT Distinct SoHDB FROM tChiTietHDB)
    DELETE FROM tHoaDonBan
    WHERE SoHDB NOT IN (SELECT Distinct SoHDB FROM tChiTietHDB)
END
exec ThongKeVaXoaHoaDonMoCo