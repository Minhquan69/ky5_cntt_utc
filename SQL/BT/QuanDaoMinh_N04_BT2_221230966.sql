--BT1
--Tạo View danh sách sinh viên, gồm các thông tin sau: 
--Mã sinh viên, Họ sinh viên, Tên sinh viên, Học bổng.  
Create VIEW Cau1
AS
SELECT MaSV, HoSV, TenSV, HocBong
FROM DSSinhVien 

SELECT * FROM Cau1
--Tạo view Liệt kê các sinh viên có học bổng từ 150,000 trở lên và sinh ở Hà Nội, gồm các thông tin: 
--Họ tên sinh viên, Mã khoa, Nơi sinh, Học bổng.  
Create VIEW Cau2
AS
SELECT HoSV , TensV, MaKhoa, NoiSinh, HocBong
FROM DSSinhVien
WHERE HocBong >= 150000 and NoiSinh = N'Hà Nội'

SELECT * FROM Cau2
--Tạo view liệt kê những sinh viên nam của khoa Anh văn và khoa tin học, gồm các thông tin: 
--Mã sinh viên, Họ tên sinh viên, tên khoa, Phái.  
Create VIEW Cau3
AS
SELECT MaSV, HoSV+' '+TenSV AS HoTen, DMKhoa.TenKhoa, Phai
FROM DSSinhVien JOIN DMKhoa ON DMKhoa.MaKhoa = DSSinhVien.MaKhoa
WHERE (DMKhoa.TenKhoa = N'Anh Văn' OR DMKhoa.TenKhoa = N'Tin Học') AND DSSinhVien.Phai = N'Nam'

SELECT * FROM Cau3
--Tạo view gồm những sinh viên có tuổi từ 20 đến 25, thông tin gồm: Họ tên sinh viên, Tuổi, Tên khoa.  
Create VIEW Cau4
AS
SELECT HoSV+' '+TenSV AS HoVaTen, DATEDIFF(YEAR, NgaySinh, GETDATE()) AS Tuoi, DMKhoa.TenKhoa
FROM DSSinhVien join DMKhoa ON DMKhoa.MaKhoa = DSSinhVien.MaKhoa
WHERE DATEDIFF(YEAR, NgaySinh, GETDATE()) BETWEEN 20 AND 25

SELECT * FROM Cau4
--Tạo view cho biết thông tin về mức học bổng của các sinh viên, gồm: Mã sinh viên, 
--Phái, Mã khoa, Mức học bổng. Trong đó, mức học bổng sẽ hiển thị là “Học bổng cao” 
--nếu giá trị của field học bổng lớn hơn 500,000 và ngược lại hiển thị là “Mức trung bình”  
Create VIEW Cau5
AS
SELECT MaSV, Phai, MaKhoa,
		CASE 
			WHEN HocBong > 500000 THEN N'Học bổng cao'
			ELSE N'Mức trung bình'
		END AS MucHocBong
FROM DSSinhVien

SELECT * FROM Cau5

--Tạo view đưa ra thông tin những sinh viên có học bổng lớn hơn bất kỳ học bổng của sinh viên học khóa anh văn  
create view Cau6
as
select DS.MaSV, DS.HoSV, DS.TenSV, DS.HocBong
from DSSinhVien as DS join DMKhoa as K on DS.MaKhoa = K.MaKhoa
where DS.HocBong > (select max(DS.HocBong)
						from DSSinhVien as DS
						where DS.MaKhoa = 'AV')
select * from Cau6
--Tạo view đưa ra thông tin những sinh viên đạt điểm cao nhất trong từng môn.  
Create VIEW Cau7
AS
SELECT kq.MaMH, mh.TenMH, sv.MaSV, sv.HoSV, sv.TenSV, kq.Diem 
FROM KetQua kq JOIN DSSinhVien sv ON kq.MaSV = sv.MaSV 
	JOIN DMMonHoc mh ON kq.MaMH = mh.MaMH 
WHERE kq.Diem = (
        SELECT MAX(kq2.Diem)
        FROM KetQua kq2
        WHERE kq2.MaMH = kq.MaMH)

SELECT * FROM Cau7
--Tạo view đưa ra những sinh viên chưa thi môn cơ sở dữ liệu.  
Create VIEW Cau8
AS
SELECT DSSinhVien.MaSV, HoSV, TenSV
FROM DSSinhVien LEFT JOIN KetQua ON DSSinhVien.MaSV = KetQua.MaSV AND KetQua.MaMH = N'01'
WHERE KetQua.MaSV IS NULL

SELECT * FROM Cau8
--Tạo view đưa ra thông tin những sinh viên không trượt môn nào. 
Create VIEW Cau9 AS
SELECT *
FROM DSSinhVien sv
WHERE 
    sv.MaSV IN (
        SELECT DISTINCT kq.MaSV
        FROM KetQua kq
        WHERE NOT EXISTS (
            SELECT 1
            FROM KetQua kq1
            WHERE kq1.MaSV = kq.MaSV
            AND (SELECT MAX(Diem) FROM KetQua WHERE MaSV = kq1.MaSV AND MaMH = kq1.MaMH) < 4
        )
    )

SELECT * FROM Cau9



--Bài 2
/*
1. Tạo view DSHS10A1 gồm thông tin Mã học sinh, họ tên, giới tính (là “Nữ” nếu Nu=1, 
ngược lại là “Nam”), các điểm Toán, Lý, Hóa, Văn của các học sinh lớp 10A1 
2. Tạo login TranThanhPhong, tạo user TranThanhPhong cho TranThanhPhong trên CSDL 
QLHocSinh 
Phân quyền Select trên view DSHS10A1 cho TranThanhPhong 
Đăng nhập TranThanhPhong để kiểm tra 
Tạo login PhamVanNam, tạo PhamVanNam cho PhamVanNam trên CSDL QLHocSinh 
Đăng nhập PhamVanNam để kiểm tra 
Tạo view DSHS10A2 tương tự như câu 1 
Phân quyền Select trên view DSHS10A2 cho PhamVanNam 
Đăng nhập PhamVanNam để kiểm tra 
3. Tạo view báo cáo Kết thúc năm học gồm các thông tin: Mã học sinh, Họ và tên, Ngày sinh, 
Giới tính, Điểm Toán, Lý, Hóa, Văn, Điểm Trung bình, Xếp loại, Sắp xếp theo xếp loại (chọn 
1000 bản ghi đầu). Trong đó: 
Điểm trung bình (DTB) = ((Toán  + Văn)*2 + Lý + Hóa)/6) 
Cách thức xếp loại như sau: - Xét điểm thấp nhất (DTN) của các 4 môn  - Nếu DTB>5 và DTN>4 là “Lên Lớp”, ngược lại là lưu ban 
4. Tạo view danh sách HOC SINH XUAT SAC bao gồm các học sinh có DTB>=8.5 và 
DTN>=8 với các trường: Lop, Mahs, Hoten, Namsinh (năm sinh), Nu, Toan, Ly, Hoa, Van, 
DTN, DTB 
5. Tạo view danh sách HOC SINH DAT THU KHOA KY THI bao gồm các học sinh xuất 
sắc có DTB lớn nhất với các trường: Lop, Mahs, Hoten, Namsinh, Nu, Toan, Ly, Hoa, Van, 
DTB
*/
--1
Create VIEW DSHS10A1
AS
SELECT DSHS.MAHS, HO+' '+TEN AS HoVaTen,CASE 
		WHEN NU=1 THEN N'Nữ'
		ELSE 'Nam'
	end as GoiTinh, TOAN, LY, HOA, VAN
FROM DSHS JOIN DIEM ON DSHS.MAHS=DIEM.MAHS 
WHERE DSHS.MALOP='10A1'

SELECT * FROM DSHS10A1
--2
--Tạo login TranThanhPhong
exec sp_addlogin TranThanhPhong,123
--Tạo user ThanThanhPhong cho TranThanhPhong
USE QLHS
exec sp_adduser TranThanhPhong, TranThanhPhong
--Phân quyền Select trên view DSHS10A1 cho TranThanhPhong
grant select on DSHS10A1 to TranThanhPhong
--Đăng nhập TranThanhPhong để kiểm tra 

--Tạo view DSHS10A2 tương tự như câu 1 
CREATE VIEW DSHS10A2
AS
SELECT DSHS.MAHS, HO+' '+TEN AS HoVaTen, iif(NU=1, N'Nữ', 'Nam')
AS GioiTinh, NGAYSINH, MALOP, TOAN, LY, HOA, VAN,
ROUND((TOAN*2+VAN*2+LY+HOA)/6,2) AS DiemTB FROM DSHS, DIEM 
WHERE DSHS.MAHS=DIEM.MAHS and DSHS.MALOP='10A2'

SELECT * FROM DSHS10A2
--Phân quyền Select trên view DSHS10A2 cho PhamVanNam 
grant select on DSHS10A2 to PhamVanNam
--ăng nhập PhamVanNam để kiểm tra


--Tạo login PhamVanNam, tạo PhamVanNam cho PhamVanNam trên CSDL QLHocSinh 
exec sp_addlogin PhamVanNam,123
USE QLHS
exec sp_adduser PhamVanNam, PhamVanNam
--Đăng nhập PhamVanNam để kiểm tra 
--Phân quyền Select trên view DSHS10A2 cho PhamVanNam 
grant select on DSHS10A2 to PhamVanNam

--3
CREATE VIEW BaoCaoKetThucNamHoc
AS
SELECT TOP(1000) DSHS.MAHS,DSHS.HO,DSHS.TEN,DSHS.NGAYSINH,
(CASE
	WHEN DSHS.NU = 1 THEN N'Nữ'
	ELSE N'Nam'
END ) AS GioiTinh,
DIEM.TOAN,DIEM.LY,DIEM.HOA,DIEM.VAN,ROUND((TOAN*2+VAN*2+LY+HOA)/6,2) AS DiemTB,
CASE
   WHEN ROUND((TOAN*2+VAN*2+LY+HOA)/6,2) > 5.0 AND LEAST(TOAN,LY,HOA,VAN) > 4.0 THEN N'LÊN LỚP'
   ELSE N'LƯU BAN'
END AS XepLoai
FROM DSHS JOIN DIEM ON DSHS.MAHS = DIEM.MAHS

SELECT * FROM BaoCaoKetThucNamHoc

--4
CREATE VIEW DSHSXuatSac
AS
SELECT DSHS.MALOP,DSHS.MAHS,DSHS.HO,DSHS.TEN,YEAR(NGAYSINH) AS NAMSINH,
(CASE
	WHEN DSHS.NU = 1 THEN N'Nữ'
	ELSE N'Nam'
END ) AS GioiTinh,TOAN,LY,HOA,VAN,LEAST(TOAN,LY,HOA,VAN) AS DTN
, ROUND((TOAN*2+VAN*2+LY+HOA)/6,2) AS DTB
FROM DSHS JOIN DIEM ON DIEM.MAHS = DSHS.MAHS
WHERE ROUND((TOAN*2+VAN*2+LY+HOA)/6,2) >= 8.5 AND LEAST(TOAN,LY,HOA,VAN) >= 8

SELECT * FROM DSHSXuatSac

--5
CREATE VIEW DSHSDATTHUKHOAKYTHI
AS
SELECT DSHS.MALOP,DSHS.MAHS,DSHS.HO,DSHS.TEN,YEAR(NGAYSINH) AS NAMSINH,
(CASE
	WHEN DSHS.NU = 1 THEN N'Nữ'
	ELSE N'Nam'
END ) AS GioiTinh,TOAN,LY,HOA,VAN,LEAST(TOAN,LY,HOA,VAN) AS DTN
, ROUND((TOAN*2+VAN*2+LY+HOA)/6,2) AS DTB
FROM DSHS JOIN DIEM ON DIEM.MAHS = DSHS.MAHS
WHERE ROUND((TOAN*2+VAN*2+LY+HOA)/6,2) = 
	(
        SELECT MAX(ROUND((TOAN * 2 + VAN * 2 + LY + HOA) / 6, 2))
        FROM DIEM
    )

SELECT * FROM DSHSDATTHUKHOAKYTHI
/*Bài tập 3: Cho CSDL về quản lý bán hàng trong file QLSinhVien.sql  
1. Tạo login Login1, tạo User1 cho Login1 
2. Phân quyền Select trên bảng DSSinhVien cho User1 
3. Đăng nhập để kiểm tra 
4. Tạo login Login2, tạo User2 cho Login2 
5. Phân quyền Update trên bảng DSSinhVien cho User2, người này có thể cho phép người 
khác sử dụng quyền này 
6. Đăng nhập dưới Login2 và trao quyền Update trên bảng DSSinhVien cho  User 1 
7. Đăng nhập Login 1 để kiểm tra */
--login1
exec sp_addlogin Login1, 123
use QLSinhVien
exec sp_adduser Login1, User1

grant select on DSSinhVien to User1 
--login2
exec sp_addlogin Login2, 123
use QLSinhVien
exec sp_adduser Login2, User2

grant update on DSSinhVien to User2 with grant option


--Đăng nhập Login2 và trao quyền Update trên bảng DSSinhVien cho  User 1 
grant update on DSSinhVien to User1  