--DML trigger
--1.Tạo trường Trạng thái của bảng sinh viên, tự động cập nhật trạng thái tốt nghiệp của sinh viên khi họ đạt đủ điều kiện tốt nghiệp 
--(hoàn thành đủ môn học, không nợ môn, có điểm tích lũy (hệ 4) toàn khóa từ 2 trở lên).
--2.Tạo trigger tự động tính lại điểm kết thúc học phần, điểm hệ chữ, điểm hệ 4, 
--lần học của sinh viên sau khi có thay đổi về điểm trong bảng LopHocPhan_SinhVien
alter trigger TinhDiem on LopHocPhan_Sinhvien
for insert, update
as
begin
	declare @mahp varchar(25), @malhp varchar(25),@msv varchar(10), @dqt float, @dtkthp float, @tsdqt float, @tsdtkthp float,@diem float
	select @mahp = MaHocPhan, @malhp = MaLopHocPhan, @msv = MaSinhVien, @dqt = DiemQuaTrinh, @dtkthp = DiemThiKTHP
	from inserted
	select @tsdqt = TrongSoDiemQuaTrinh, @tsdtkthp = TrongSoDiemThiKTHP from HocPhan where MaHocPhan = @mahp
	select @diem = (@dqt*@tsdqt+@dtkthp*@tsdtkthp)
	update LopHocPhan_Sinhvien set DiemTKHP =  @diem where MaHocPhan = @mahp and MaLopHocPhan = @malhp and MaSinhVien = @msv
	update LopHocPhan_Sinhvien set DiemHeChu =  (case 
		when @diem >= 9.5 then 'A+' when @diem >= 8.5 then 'A'
		when @diem >= 8.0 then 'B+' when @diem >= 7.0 then 'B'
		when @diem >= 6.0 then 'C+' when @diem >= 5.5 then 'C' 
		when @diem >= 4.5 then 'D+' when @diem >= 4.0 then 'D'
		when @diem >= 2.0 then 'F+' else 'F' end) 
	where MaHocPhan = @mahp and MaLopHocPhan = @malhp and MaSinhVien = @msv
	update LopHocPhan_Sinhvien set DiemHe4 =  (case 
		when @diem >= 9.5 then 4.0 when @diem >= 8.5 then 3.8
		when @diem >= 8.0 then 3.5 when @diem >= 7.0 then 3.0
		when @diem >= 6.0 then 2.5 when @diem >= 5.5 then 2.0 
		when @diem >= 4.5 then 1.5 when @diem >= 4.0 then 1
		when @diem >= 2.0 then 0.5 else 0 end)
	where MaHocPhan = @mahp and MaLopHocPhan = @malhp and MaSinhVien = @msv
	update LopHocPhan_Sinhvien set LanHoc =  (select max(isnull(LanHoc,0))
	from LopHocPhan_Sinhvien where MaHocPhan = @mahp and MaSinhVien = @msv) +1
	where MaHocPhan = @mahp and MaLopHocPhan = @malhp and MaSinhVien = @msv
end

insert into LopHocPhan_SinhVien(MaHocPhan, MaLopHocPhan, MaSinhVien, DiemQuaTrinh, DiemThiKTHP)
values ('IT1.217.3', '1-2-23-N04', '882126017', 10, 10)
select * from LopHocPhan_SinhVien where MaSinhVien='882126017'
--3.Tạo trigger gửi thông báo khi sinh viên hoàn thành tất cả các học phần trong chương trình đào tạo.
--4.Xây dựng bảng trạng thái lớp gồm các trường mã lớp, số SV tốt nghiệp, Số SV buộc thôi học, Số SV chưa tốt nghiệp.
--Tạo trigger tự động cập nhật trạng thái bảng này.
--5.Tạo trigger tự động xóa các bản ghi điểm khi sinh viên bị xóa khỏi cơ sở dữ liệu.
alter TRIGGER XoaSV ON SinhVien
instead of delete
AS
BEGIN	
    DELETE FROM LopHocPhan_SinhVien
    WHERE MaSinhVien IN (SELECT MaSinhVien FROM DELETED)
	DELETE FROM SinhVien
    WHERE MaSinhVien IN (SELECT MaSinhVien FROM DELETED)
END
delete SinhVien WHERE MaSinhVien ='212600556'
select * from LopHocPhan_SinhVien WHERE MaSinhVien ='212600556'
--6.Tạo bảng SinhVien_CNTT_K65 gồm các trường mã sinh viên, tên sinh viên, lớp, các trường có trong chương trình đào tạo của sinh viên CNTT K65, 
--trường số tín chỉ hoàn thành, điểm tích lũy. Tạo trigger tự động cập nhật:
---	Họ và tên, mã sinh viên, lớp mỗi khi thêm một sinh viên K65
---	Thêm điểm cao nhất của các môn ứng với các cột tương ứng
---	Tính tổng số tín chỉ hoàn thành vào trường số tín chỉ hoàn thành
---	Tính điểm tích lũy vào trường điểm tích lũy