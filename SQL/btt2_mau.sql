
-- Bài tập tuần 3
use BT2
go


-- 1, Tạo View danh sách sinh viên, gồm các thông tin sau: Mã sinh viên, Họ sinh viên, Tên sinh viên, Học bổng
create view HSHS1 
as
select DS.MaSV, DS.HoSV, DS.TenSV, DS.HocBong
from DSSinhVien as DS
go
select * from HSHS1


/* 2, Tạo view Liệt kê các sinh viên có học bổng từ 150,000 trở lên và sinh ở Hà Nội, gồm
các thông tin: Họ tên sinh viên, Mã khoa, Nơi sinh, Học bổng */
create view DSHS2
as
select DS.HoSV, DS.TenSV, DS.HocBong, DS.NoiSinh
from DSSinhVien as DS
where DS.HocBong > 150000 and DS.NoiSinh = N'Hà Nội'

select * from DSHS2


/* 3, Tạo view liệt kê những sinh viên nam của khoa Anh văn và khoa tin học, gồm các thông
tin: Mã sinh viên, Họ tên sinh viên, tên khoa, Phái */
create view DSHS3
as
select DS.MaSV, DS.HoSV, DS.TenSV, K.TenKhoa, DS.Phai
from DSSinhVien as DS join DMKhoa as K on DS.MaKhoa = K.MaKhoa
where DS.Phai = N'Nam' and (K.TenKhoa like N'%Anh Văn%' or K.TenKhoa like N'%Tin Học%')

select * from DSHS3

/* Tạo view gồm những sinh viên có tuổi từ 20 đến 25, thông tin gồm: Họ tên sinh viên,
Tuổi, Tên khoa. */
create view DSHS4
as
select DS.HoSV, DS.TenSV, (year(GETDATE()) - year(DS.NgaySinh)) as Tuoi, K.TenKhoa
from DSSinhVien as DS join DMKhoa as K on DS.MaKhoa = K.MaKhoa
where year(GETDATE()) - year(DS.NgaySinh) between 20 and 25

select * from DSHS4

/* 5, Tạo view cho biết thông tin về mức học bổng của các sinh viên, gồm: Mã sinh viên,
Phái, Mã khoa, Mức học bổng. Trong đó, mức học bổng sẽ hiển thị là “Học bổng cao”
nếu giá trị của field học bổng lớn hơn 500,000 và ngược lại hiển thị là “Mức trung bình” */
create view DSHS5
as 
select DS.MaSV, DS.Phai, K.MaKhoa, DS.HocBong, 
case
	when DS.HocBong > 500000 then 'Hoc bong cao'
	else 'Muc trung binh'
end
as Muc
from DSSinhVien as DS join DMKhoa as K on DS.MaKhoa = K.MaKhoa

select * from DSHS5

/* 6, Tạo view đưa ra thông tin những sinh viên có học bổng lớn hơn tất học bổng của
sinh viên học khóa anh văn */
create view DSHS6
as 
select DS.MaSV, DS.HoSV, DS.TenSV, DS.HocBong
from DSSinhVien as DS join DMKhoa as K on DS.MaKhoa = K.MaKhoa
where DS.HocBong > (select max(DS.HocBong)
						from DSSinhVien as DS
						where DS.MaKhoa = 'AV')
select * from DSHS6


/* 7, Tạo view đưa ra thông tin những sinh viên đạt điểm cao nhất trong từng môn */