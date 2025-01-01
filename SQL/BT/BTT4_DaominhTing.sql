--Bai 1
--1. Viết một Trigger gắn với bảng DIEM dựa trên sự kiện Insert, Update để tự động cập nhật 
--điểm trung bình của học sinh khi thêm mới hay cập nhật bảng điểm 
--Điểm trung bình= ((Toán +Văn)*2+Lý+Hóa)/6
--1 bản ghi
CREATE TRIGGER TinhDTB ON DIEM
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @MaHS NVARCHAR(10), @DTB FLOAT
	SELECT @MaHS = MAHS, @DTB = ((TOAN+VAN)*2+LY+HOA)/6 FROM inserted
    UPDATE DIEM SET DTB = @DTB WHERE MAHS = @MaHS
END
--Test
insert into DIEM(MAHS,TOAN, LY, HOA, VAN) values ('00001', 8, 8, 8, 8)
UPDATE DIEM SET TOAN = 10, VAN = 10 WHERE MAHS IN ('00001')
--Nhiều bản ghi
ALTER TRIGGER TinhDTB ON DIEM
FOR INSERT, UPDATE
AS
BEGIN
    UPDATE DIEM SET DTB = ( SELECT ((i.TOAN+i.VAN)*2+i.LY+i.HOA)/6
							FROM INSERTED i WHERE i.MAHS = DIEM.MAHS)
	WHERE MAHS IN (SELECT MAHS FROM INSERTED)
END
--Test
insert into DIEM(MAHS,TOAN, LY, HOA, VAN) values ('00004', 10, 10, 10, 10),('00002', 9, 9, 9, 9),('00003', 8, 8, 8, 8)

--2. Viết một Trigger gắn với bảng DIEM dựa trên sự kiện Insert, Update  để tự động xếp loại 
--học sinh, cách thức xếp loại như sau - Nếu Điểm trung bình>=5 là lên lớp, ngược lại là lưu ban 
CREATE TRIGGER XepLoai on DIEM
FOR INSERT, UPDATE AS
BEGIN
	declare @MaHS nvarchar(10), @DTB float
	select @MaHS = MAHS, @DTB = 
	((i.TOAN+i.VAN)*2+i.LY+i.HOA)/6 from inserted i
	UPDATE DIEM SET XEPLOAI = 
	CASE
		WHEN @dtb >= 5 THEN N'Lên lớp'
		ELSE N'Lưu ban'	
	END
    WHERE DIEM.MAHS = @MaHS
END
--Test
insert into DIEM(MAHS,TOAN, LY, HOA, VAN) values ('00005',10, 9, 8, 7)
insert into DIEM(MAHS,TOAN, LY, HOA, VAN) values ('00006',1, 6, 6, 1)
UPDATE DIEM SET TOAN = 10, VAN = 10 WHERE MAHS IN ('00006')
--3. Viết một Trigger gắn với bảng DIEM dựa trên sự kiện Insert, Update  để tự động xếp loại 
--học sinh, cách thức xếp loại như sau - Xét điểm thấp nhất (DTN) của các 4 môn  
-- Nếu DTB>=5 và DTN>=4 là “Lên Lớp”, ngược lại là lưu ban 
CREATE TRIGGER XepLoai2 on DIEM
for insert, update
as
begin
	DECLARE @MAHS NVARCHAR(10), @DTB FLOAT, @DTN FLOAT
    SELECT @MAHS = MAHS, @DTB = ((i.TOAN+i.VAN)*2+i.LY+i.HOA)/6, 
	@DTN = (SELECT MIN(V) FROM (VALUES (TOAN), (LY), (HOA), (VAN)) AS value(V))
    FROM Inserted i
	UPDATE DIEM SET XEPLOAI = 
	CASE
		WHEN ( @DTB >= 5 AND @DTN>=4)  THEN N'Lên lớp'
		ELSE N'Lưu ban'	
	END
    WHERE DIEM.MAHS = @MAHS
END
--Test
insert into DIEM(MAHS,TOAN, LY, HOA, VAN) values ('00007', 10, 10, 10, 10)
UPDATE DIEM SET TOAN = 1 WHERE MAHS IN ('00007')
--4. Viết một trigger xóa tự động bản ghi về điểm học sinh khi xóa dữ liệu học sinh đó trong DSHS
create trigger XoaHS on DSHS
for delete
as
begin
	declare @MaHS nvarchar(10)
	select @MaHS = MAHS from deleted
	delete from DIEM
	where @MaHS=DIEM.MAHS
end
--chạy
select * from DSHS where MAHS = '00001'
select * from DIEM where MAHS = '00001'
delete DSHS where MAHS = '00001' 
--Bài 2
--1. Viết truy vấn tạo bảng doanh thu (tDoanhThu) gồm các trường 
CREATE TABLE [dbo].[tDoanhThu](
	[MaDK] [nvarchar](3) NOT NULL,
	[LoaiPhong] [nvarchar](2) NULL,
	[SoNgayO] [int] NULL,
	[ThucThu] [bigint] NULL,
	PRIMARY KEY CLUSTERED ([MaDK] ASC)
)
--2. Tạo Trigger tính tiền và điền tự động vào bảng tDoanhThu như sau: 
--Các trường lấy thông tin từ các bảng và các thông tin sau: 
--Trong đó:  
--(a) Số Ngày Ở= Ngày Ra – Ngày Vào  
--(b) ThucThu: Tính theo yêu cầu sau:  
--Nếu Số Ngày ở <10 Thành tiền = Đơn Giá * Số ngày ở  
--Nếu 10 <=Số Ngày ở <30 Thành Tiền = Đơn Giá* Số Ngày ở * 0.95 (Giảm5%)  
--Nếu Số ngày ở >= 30 Thành Tiền = Đơn Giá* Số Ngày ở * 0.9 (Giảm10%) 
CREATE TRIGGER TinhTien ON tDangKy 
FOR INSERT, UPDATE
AS
BEGIN
		DECLARE @MaDK nvarchar(3), @SoNgayO INT, @LoaiPhong nvarchar(2), @DonGia int, @ThucThu DECIMAL(10, 2)
        SELECT @MaDK = MaDK, @LoaiPhong = LoaiPhong, @SoNgayO = DATEDIFF(DAY, NgayVao, NgayRa) FROM inserted 
		SELECT @DonGia = (SELECT DonGia FROM tLoaiPhong WHERE LoaiPhong = @LoaiPhong)
        IF @SoNgayO < 10 SET @ThucThu = @DonGia * @SoNgayO;
        ELSE IF @SoNgayO >= 10 AND @SoNgayO < 30 SET @ThucThu = @DonGia * @SoNgayO * 0.95
        ELSE SET @ThucThu = @DonGia * @SoNgayO * 0.9
		IF EXISTS (SELECT * FROM tDoanhThu WHERE MaDK = @MaDK)
			BEGIN
				UPDATE tDoanhThu set SoNgayO = @SoNgayO where MaDK = @MaDK
				UPDATE tDoanhThu set LoaiPhong = @LoaiPhong where MaDK = @MaDK
				UPDATE tDoanhThu set ThucThu = @ThucThu where MaDK = @MaDK
			END
        ELSE
			BEGIN
				INSERT INTO tDoanhThu (MaDK, LoaiPhong, SoNgayO, ThucThu)
				VALUES (@MaDK,@LoaiPhong, @SoNgayO, @ThucThu)
			END
END
--test
insert into tDangKy(MaDK, SoPhong,LoaiPhong, NgayVao, NgayRa) values ('016', '101', 'A', '2024-02-27','2024-03-01')
insert into tDangKy(MaDK, SoPhong,LoaiPhong, NgayVao, NgayRa) values ('017', '102', 'B', '2024-02-27','2024-05-01')
select * from tDoanhThu where MaDK = '016' or MaDK = '017'
--3. Thêm trường DonGia vào bảng tDangKy, tạo trigger cập nhật tự động cho trường này. 
--Thêm trường DonGia vào bảng tDangKy
ALTER TABLE tDangKy
ADD DonGia DECIMAL(10, 2)
--tạo trigger
CREATE TRIGGER TinhDonGia ON tDangKy 
FOR INSERT, UPDATE
AS
BEGIN
		DECLARE @MaDK nvarchar(3), @SoNgayO INT, @LoaiPhong nvarchar(2), @DoanhThu DECIMAL(10, 2), @DonGia int
        SELECT @MaDK = MaDK, @LoaiPhong = LoaiPhong, @SoNgayO = DATEDIFF(DAY, NgayVao, NgayRa) FROM inserted 
		SELECT @DonGia = (SELECT DonGia FROM tLoaiPhong WHERE LoaiPhong = @LoaiPhong)
        IF @SoNgayO < 10
            SET @DoanhThu = @DonGia * @SoNgayO
        ELSE IF @SoNgayO >= 10 AND @SoNgayO < 30
            SET @DoanhThu = @DonGia * @SoNgayO * 0.95
        ELSE
            SET @DoanhThu = @DonGia * @SoNgayO * 0.9
        BEGIN
            UPDATE tDangKy set DonGia = @DoanhThu where MaDK = @MaDK
        END  
END
--test
insert into tDangKy(MaDK, SoPhong,LoaiPhong, NgayVao, NgayRa) values ('018',  '601', 'B', '2024-02-27','2024-05-01')
select * from tDangKy where MaDK = '018'
UPDATE tDangKy SET NgayRa='2024-05-05' WHERE MADK = '018'
--4. Thêm trường tổng tiêu dùng (TongTieuDung) vào bảng khách hàng và tính tự động tổng 
--tiền khách hàng đã trả cho khách sạn mỗi khi thêm, sửa, xóa bản tDangKy
--Thêm trường tổng tiêu dùng (TongTieuDung)
ALTER TABLE tChiTietKH
ADD TongTieuDung DECIMAL(18, 2)
--tạo trigger
create trigger TongTieuDung on tDangKy
for insert, delete, update
as
begin
	DECLARE @MaDK_ins nvarchar(3), @SoNgayO_ins INT, @LoaiPhong_ins nvarchar(2), @DoanhThu_ins DECIMAL(10, 2), @DonGia_ins int,
			@MaDK_del nvarchar(3), @SoNgayO_del INT, @LoaiPhong_del nvarchar(2), @DoanhThu_del DECIMAL(10, 2), @DonGia_del int
    SELECT @MaDK_ins = MaDK, @LoaiPhong_ins = LoaiPhong, @SoNgayO_ins = DATEDIFF(DAY, NgayVao, NgayRa) FROM inserted 
	SELECT @MaDK_del = MaDK, @LoaiPhong_del = LoaiPhong, @SoNgayO_del = DATEDIFF(DAY, NgayVao, NgayRa) FROM deleted
	SELECT @DonGia_ins = (SELECT DonGia FROM tLoaiPhong WHERE LoaiPhong = @LoaiPhong_ins)
	SELECT @DonGia_del = (SELECT DonGia FROM tLoaiPhong WHERE LoaiPhong = @LoaiPhong_del)   
	update tChiTietKH set TongTieuDung = isnull(TongTieuDung,0) + @DonGia_ins*(case when @SoNgayO_ins < 10 then @SoNgayO_ins
		when (@SoNgayO_ins >= 10 AND @SoNgayO_ins < 30) then (@SoNgayO_ins * 0.95) else (@SoNgayO_ins * 0.9) end)
	where tChiTietKH.MaDK = @MaDK_ins
	update tChiTietKH set TongTieuDung = isnull(TongTieuDung,0) - @DonGia_del*(case when @SoNgayO_del < 10 then @SoNgayO_del
		when (@SoNgayO_del >= 10 AND @SoNgayO_del < 30) then (@SoNgayO_del * 0.95) else (@SoNgayO_del * 0.9) end)
	where tChiTietKH.MaDK = @MaDK_del
end
--chạy
insert into tDangKy(MaDK, SoPhong,LoaiPhong, NgayVao, NgayRa) values ('001', '201', 'A', '2019-04-03','2019-04-13')
insert into tDangKy(MaDK, SoPhong,LoaiPhong, NgayVao, NgayRa) values ('002', '601', 'B', '2024-02-27','2024-05-01')
insert into tDangKy(MaDK, SoPhong,LoaiPhong, NgayVao, NgayRa) values ('003', '101', 'A', '2024-02-27','2024-05-05')
select * from tChiTietKH where MaDK = '001' or MaDK = '002' or MaDK = '003'
delete from tDangKy where MaDK = '001'
