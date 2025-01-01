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
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values ('HDB13','S06',10),('HDB13','S07',11),('HDB13','S08',12)

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
    SET DonGia = (SELECT tSach.DonGiaBan FROM tSach WHERE tSach.MaSach = tChiTietHDB.MaSach)*Inserted.SLBan
    FROM Inserted
    WHERE tChiTietHDB.SoHDB = Inserted.SoHDB AND tChiTietHDB.MaSach = Inserted.MaSach
END
--chạy
insert into tChiTietHDB(SoHDB,MaSach,SLBan) 
values ('HDB13','S06',10),('HDB13','S07',11),('HDB13','S08',12)

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
	update tKhachHang set SoLuongHD=isnull(SoLuongHD,0)+1 where MaKH=@makh_ins
	update tKhachHang set SoLuongHD=isnull(SoLuongHD,0)-1 where MaKH=@makh_del
END
--kiemtra
select * from tKhachHang where MaKH='KH01' OR MaKH='KH02'
insert into tHoaDonBan values('HDB19','NV01', '2014-08-11 00:00:00.000', 'KH01')
delete from tHoaDonBan where SoHDB='HDB17'
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
insert into tHoaDonBan(SoHDB, MaKH) values ('HDB21','KH01'),('HDB22','KH02')

--4.  Thêm trường số sản phẩm vào bảng hóa đơn bán, cập nhật tự động cho trường này mỗi khi thêm chi tiết hóa đơn 
--Thêm trường số sản phẩm vào bảng hóa đơn bán
ALTER TABLE tHoaDonBan
ADD SoSanPham INT
--cap nhat sl
   UPDATE tHoaDonBan
   SET SoSanPham = (SELECT sum(tChiTietHDB.SLBan) 
                    FROM tChiTietHDB
                    WHERE tChiTietHDB.SoHDB = tHoaDonBan.SoHDB)
--trigger
create TRIGGER ChenSanPham ON tChiTietHDB
for insert
AS 
BEGIN
   DECLARE @SoHDB nvarchar(20)
   SELECT @SoHDB = Inserted.SoHDB FROM Inserted
   UPDATE tHoaDonBan
   SET SoSanPham = SoSanPham + (SELECT SLBan
                    FROM Inserted
                    )
   WHERE SoHDB = @SoHDB
END
--chen
insert into tChiTietHDB(SoHDB,MaSach,SLBan) values ('HDB02','S01',10)

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
	update thoadonban set SoLuongSP=isnull(SoLuongSP,0)+ A.SL
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
create trigger cau7
on tChiTietHDB for insert
as
begin
	update tHoaDonBan set
	TongTien = TongTien + 
		(select sum(SLBan*DonGiaBan)
		from inserted join tSach
		on inserted.MaSach = tSach.MaSach
		)
	where SoHDB = (select SoHDB from inserted)
end
insert into tChiTietHDB(SoHDB, MaSach, SLBan) values ('HDB22', 'S16',1), ('HDB22', 'S17',3)
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
	update tSach set SoLuong = SoLuong - A.SL
	from (select MaSach, sum(SLNhap) as SL from deleted group by MaSach) A	
	where tSach.MaSach = A.MaSach
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
	where tNhaCungCap.MaNCC = (select MaNCC from tHoaDonNhap where SoHDN = A.SoHDN)

	update tNhaCungCap set SoLuongSach = isnull(SoLuongSach,0) - A.SL
	from (select SoHDN, sum(SLNhap) as SL from deleted group by SoHDN) A
	where tNhaCungCap.MaNCC = (select MaNCC from tHoaDonNhap where SoHDN = A.SoHDN)
END

--15. Tạo trigger trên bảng thoadonban thực hiện xóa các chi tiết hóa đơn mỗi khi xóa hóa đơn
CREATE TRIGGER trg_DeleteChiTietHDB
ON tHoaDonBan
AFTER DELETE
AS
BEGIN
    DELETE FROM tChiTietHDB
    WHERE SoHDB IN (SELECT SoHDB FROM deleted);
END

