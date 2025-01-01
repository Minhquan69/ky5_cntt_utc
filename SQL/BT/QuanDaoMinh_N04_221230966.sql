--BÀI TẬP TỔNG HỢP: CSDL QUẢN LÝ ĐIỂM TRƯỜNG ĐẠI HỌC
--Đào Minh Quân_N04_221230966

--View
--1.Tạo view liệt kê tất cả các sinh viên trong trường, bao gồm mã sinh viên, tên, ngày sinh, và lớp học.
create view a as
select MaSinhVien, Ten, NgaySinh, TenLop
from SinhVien join Lop on SinhVien.MaLop = Lop.MaLop
select * from a

--2.Tạo view đưa ra bảng điểm của sinh viên có mã 171202737 bao gồm mã học phần, tên học phần, --điểm quá trình, điểm thi và điểm tổng kết hệ 10, điểm tổng kết hệ chữ.
create view cau2 as
with MaxDiem as(
	select lhpsv.MaHocPhan, Max(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) as DiemMax
	from LopHocPhan_SinhVien lhpsv join HocPhan hp on lhpsv.MaHocPhan = hp.MaHocPhan
	where lhpsv.MaSinhVien = '171202737'
	group by lhpsv.MaHocPhan
)
SELECT lhpsv.MaHocPhan, hp.TenHocPhan, lhpsv.DiemQuaTrinh, lhpsv.DiemThiKTHP, md.DiemMax as DiemHe10,
    CASE
        WHEN md.DiemMax >= 8.5 THEN 'A' WHEN md.DiemMax >= 7.0 THEN 'B'
        WHEN md.DiemMax >= 5.5 THEN 'C' WHEN md.DiemMax >= 4.5 THEN 'D'
        ELSE 'F'
    END AS DiemHeChu, lhpsv.LanHoc
FROM LopHocPhan_SinhVien lhpsv JOIN HocPhan hp ON lhpsv.MaHocPhan = hp.MaHocPhan 
JOIN MaxDiem md ON lhpsv.MaHocPhan = md.MaHocPhan
AND (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) = md.DiemMax
WHERE lhpsv.MaSinhVien = '171202737'

--3.Tạo view hiển thị danh sách các sinh viên còn nợ học phần Cơ sở dữ liệu.
create view cau3 as
SELECT sv.MaSinhVien, sv.Ten, 
    MAX(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) AS DiemKTHP
FROM SinhVien sv 
JOIN LopHocPhan_SinhVien lhpsv ON sv.MaSinhVien = lhpsv.MaSinhVien  
JOIN HocPhan hp ON lhpsv.MaHocPhan = hp.MaHocPhan
WHERE hp.TenHocPhan = N'Cơ sở dữ liệu'
GROUP BY sv.MaSinhVien, sv.Ten
HAVING MAX(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) < 4

--4.Tạo view để thống kê số lượng sinh viên theo mỗi khoa.
create view SVtheoKhoa as
SELECT k.MaKhoa, k.TenKhoa, COUNT(sv.MaSinhVien) AS SoLuongSinhVien
FROM Khoa k
left JOIN Lop l ON k.MaKhoa = l.MaKhoa
left JOIN SinhVien sv ON l.MaLop = sv.MaLop
GROUP BY k.MaKhoa, k.TenKhoa

select * from Khoa

--5.Tạo view hiển thị danh sách tất cả các giảng viên, bao gồm tên, khoa, và các học phần họ giảng dạy.
create view cau5 as
SELECT DISTINCT gv.HoDem + ' ' + gv.Ten AS TenGiangVien, k.TenKhoa, hp.TenHocPhan
FROM GiangVien gv
JOIN BoMon bm ON gv.MaBoMon = bm.MaBoMon
JOIN Khoa k ON bm.MaKhoa = k.MaKhoa
JOIN LopHocPhan lhp ON gv.MaGiangVien = lhp.MaGiangVien
JOIN HocPhan hp ON lhp.MaHocPhan = hp.MaHocPhan

--6.Tạo view liệt kê tất cả các lớp học phần được giảng dạy trong kỳ hiện tại của Bộ học phần Mạng và các HTTT, kèm theo mã học phần, tên học phần, và giảng viên phụ trách.
create view cau6 as
SELECT lhp.MaLopHocPhan,hp.MaHocPhan,hp.TenHocPhan,gv.HoDem + ' ' + gv.Ten AS TenGiangVien
FROM LopHocPhan lhp
JOIN HocPhan hp ON lhp.MaHocPhan = hp.MaHocPhan
JOIN GiangVien gv ON lhp.MaGiangVien = gv.MaGiangVien
JOIN BoMon bm ON hp.MaBoMon = bm.MaBoMon
WHERE bm.TenBoMon = N'MẠNG VÀ CÁC HỆ THỐNG THÔNG TIN'
AND lhp.NamHoc = CASE 
                        WHEN MONTH(GETDATE()) BETWEEN 8 AND 12 
                            THEN CONCAT(YEAR(GETDATE()), '-', YEAR(GETDATE()) + 1)
                        ELSE CONCAT(YEAR(GETDATE()) - 1, '-', YEAR(GETDATE()))
                      END
AND lhp.HocKy = CASE 
                       WHEN MONTH(GETDATE()) BETWEEN 8 AND 12 THEN 1  -- Học kỳ 1
                       WHEN MONTH(GETDATE()) BETWEEN 1 AND 5 THEN 2   -- Học kỳ 2
                       ELSE 3  -- Học kỳ hè
                    END

--7.Tạo view hiển thị tất cả các học phần mà sinh viên 201200026 đã học, bao gồm điểm số và thêm trạng thái là “đạt” nếu điểm >=4 và “học lại” nếu ngược lại.
create view cau7 as
SELECT hp.MaHocPhan,hp.TenHocPhan,lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP AS DiemKTHP,
    CASE
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 4.0 THEN N'Đạt'
        ELSE N'Học lại'
    END AS TrangThai
FROM LopHocPhan_SinhVien lhpsv
JOIN HocPhan hp ON lhpsv.MaHocPhan = hp.MaHocPhan
WHERE lhpsv.MaSinhVien = '201200026'
AND (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) = (
        SELECT MAX(lhpsv2.DiemQuaTrinh * hp2.TrongSoDiemQuaTrinh + lhpsv2.DiemThiKTHP * hp2.TrongSoDiemThiKTHP)
        FROM LopHocPhan_SinhVien lhpsv2
        JOIN HocPhan hp2 ON lhpsv2.MaHocPhan = hp2.MaHocPhan
        WHERE lhpsv2.MaSinhVien = lhpsv.MaSinhVien
            AND hp2.MaHocPhan = hp.MaHocPhan
    )

--8.Tạo view liệt kê tất cả các sinh viên đã nhận được học bổng trong kỳ học hiện tại (những bạn có điểm tổng kết 3.6 hệ 4 trở lên) (ghi chú: quy đổi điểm hệ 4 theo chỉ dẫn của trường).
create cau 8 as
SELECT hp.MaHocPhan,hp.TenHocPhan, lhpsv.MaSinhVien,lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP AS DiemKTHP,
    CASE
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 4.0 THEN N'Đạt'
        ELSE N'Học lại'
    END AS TrangThai
FROM LopHocPhan_SinhVien lhpsv
JOIN HocPhan hp ON lhpsv.MaHocPhan = hp.MaHocPhan
JOIN LopHocPhan lhp ON lhp.MaHocPhan = hp.MaHocPhan
AND (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) = (
        SELECT MAX(lhpsv2.DiemQuaTrinh * hp2.TrongSoDiemQuaTrinh + lhpsv2.DiemThiKTHP * hp2.TrongSoDiemThiKTHP)
        FROM LopHocPhan_SinhVien lhpsv2
        JOIN HocPhan hp2 ON lhpsv2.MaHocPhan = hp2.MaHocPhan
        WHERE lhpsv2.MaSinhVien = lhpsv.MaSinhVien
            AND hp2.MaHocPhan = hp.MaHocPhan
    )
AND lhp.NamHoc = CASE 
                        WHEN MONTH(GETDATE()) BETWEEN 8 AND 12 
                            THEN CONCAT(YEAR(GETDATE()), '-', YEAR(GETDATE()) + 1)
                        ELSE CONCAT(YEAR(GETDATE()) - 1, '-', YEAR(GETDATE()))
                      END
AND lhp.HocKy = CASE 
                       WHEN MONTH(GETDATE()) BETWEEN 8 AND 12 THEN 1  -- Học kỳ 1
                       WHEN MONTH(GETDATE()) BETWEEN 1 AND 5 THEN 2   -- Học kỳ 2
                       ELSE 3  -- Học kỳ hè
                    END

--9.Tạo view hiển thị danh sách các sinh viên bị cảnh báo học vụ cho các sinh viên có điểm trung bình cả kỳ học hiện tại dưới 1 (hệ 4).
create view cau9 as
SELECT sv.MaSinhVien, sv.Ten, 
       CASE 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 9.5 THEN 4.0 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 8.5 THEN 3.8 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 8.0 THEN 3.5 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 7.0 THEN 3.0 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 6.0 THEN 2.5 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 5.5 THEN 2.0 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 4.5 THEN 1.5 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 4.0 THEN 1.0 
           WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 2.0 THEN 0.5 
           ELSE 0 
       END AS DiemHe4
FROM LopHocPhan_SinhVien lhpsv JOIN SinhVien sv ON sv.MaSinhVien = lhpsv.MaSinhVien
join HocPhan hp on hp.MaHocPhan = lhpsv.MaHocPhan
JOIN LopHocPhan lhp ON lhp.MaHocPhan = hp.MaHocPhan
AND lhp.NamHoc = CASE 
                        WHEN MONTH(GETDATE()) BETWEEN 8 AND 12 
                            THEN CONCAT(YEAR(GETDATE()), '-', YEAR(GETDATE()) + 1)
                        ELSE CONCAT(YEAR(GETDATE()) - 1, '-', YEAR(GETDATE()))
                      END
AND lhp.HocKy = CASE 
                       WHEN MONTH(GETDATE()) BETWEEN 8 AND 12 THEN 1  -- Học kỳ 1
                       WHEN MONTH(GETDATE()) BETWEEN 1 AND 5 THEN 2   -- Học kỳ 2
                       ELSE 3  -- Học kỳ hè
                    END
WHERE (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) < 4.0

--10.Tạo view hiển thị danh sách các sinh viên bị buộc thôi học cho các sinh viên có ba kỳ liên tiếp bị cảnh báo học vụ.
create view cau 10 as
SELECT 
    sv.MaSinhVien, 
    sv.Ten, 
    lhp.NamHoc, 
    lhp.HocKy,
    CASE 
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 9.5 THEN 4.0
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 8.5 THEN 3.8
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 8.0 THEN 3.5
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 7.0 THEN 3.0
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 6.0 THEN 2.5
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 5.5 THEN 2.0
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 4.5 THEN 1.5
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 4.0 THEN 1.0
        ELSE 0
    END AS DiemHe4
FROM 
    LopHocPhan_SinhVien lhpsv 
JOIN SinhVien sv ON sv.MaSinhVien = lhpsv.MaSinhVien
JOIN HocPhan hp ON hp.MaHocPhan = lhpsv.MaHocPhan
JOIN LopHocPhan lhp ON lhp.MaHocPhan = hp.MaHocPhan

--11.Tạo view thống kê số lượng học phần được giảng dạy trong từng Bộ học phần.
--12.Tạo view để thống kê tỷ lệ sinh viên đã hoàn thành và chưa hoàn thành từng học phần.
CREATE VIEW cau12 AS
WITH LanThiCaoNhat AS (
    SELECT 
        lhpsv.MaSinhVien,
        lhpsv.MaHocPhan,
        MAX(DiemQuaTrinh * TrongSoDiemQuaTrinh + DiemThiKTHP * TrongSoDiemThiKTHP) AS DiemTongKetCaoNhat
    FROM 
        LopHocPhan_SinhVien lhpsv
        JOIN LopHocPhan lhp ON lhpsv.MaHocPhan = lhp.MaHocPhan
        JOIN HocPhan hp ON lhp.MaHocPhan = hp.MaHocPhan
    GROUP BY 
        lhpsv.MaSinhVien, lhpsv.MaHocPhan
)
SELECT 
    hp.MaHocPhan,
    hp.TenHocPhan,
    COUNT(CASE WHEN ltcn.DiemTongKetCaoNhat >= 4 THEN 1 END) AS SoSinhVienHoanThanh,
    COUNT(CASE WHEN ltcn.DiemTongKetCaoNhat < 4 THEN 1 END) AS SoSinhVienChuaHoanThanh,
    COUNT(ltcn.MaSinhVien) AS TongSoSinhVien,
    (COUNT(CASE WHEN ltcn.DiemTongKetCaoNhat >= 4 THEN 1 END) * 100.0 / COUNT(ltcn.MaSinhVien)) AS TiLeHoanThanh,
    (COUNT(CASE WHEN ltcn.DiemTongKetCaoNhat < 4 THEN 1 END) * 100.0 / COUNT(ltcn.MaSinhVien)) AS TiLeChuaHoanThanh
FROM LanThiCaoNhat ltcn JOIN HocPhan hp ON ltcn.MaHocPhan = hp.MaHocPhan
GROUP BY hp.MaHocPhan, hp.TenHocPhan

--13.Tạo view hiển thị top 10 phần trăm danh sách các sinh viên có điểm trung bình cao nhất mỗi lớp.
--14.Tạo view liệt kê tất cả các sinh viên còn nợ học phần và chưa đủ điều kiện tốt nghiệp.
--15.Tạo view đưa sinh viên đủ điều kiện nhận đồ án tốt nghiệp (sinh viên có điểm tích lũy >=1.9).
--16.Tạo view hiển thị danh sách sinh viên và số tín chỉ họ đã hoàn thành?
create view cau16 as
select sv.MaSinhVien, sum(SoTinChi) as TongSoTC
from SinhVien sv
join LopHocPhan_SinhVien lhpsv on sv.MaSinhVien = lhpsv.MaSinhVien
join LopHocPhan lhp on lhpsv.MaLopHocPhan = lhp.MaLopHocPhan
join HocPhan hp on lhp.MaHocPhan = hp.MaHocPhan
group by sv.MaSinhVien
--17.Tạo view hiển thị danh sách các học phần không có sinh viên nào đăng ký?
--18.Tạo view để liệt kê tất cả các lớp học dưới số lượng sinh viên tối thiểu (tối thiểu 15 SV) cho phép?
--19.Tạo view hiển thị tỷ lệ sinh viên qua học phần (>=4), giỏi (>=8.5) so với tổng số sinh viên theo từng ngành học?
--20.Tạo view để liệt kê các sinh viên đã cải thiện điểm số sau kỳ thi lại.

--ThuTuc
--1.Tạo thủ tục để cập nhật các trường điểm quá trình, điểm thi kết thúc học phần, Điểm tổng kết học phần, điểm hệ chữ, điểm hệ 4, lần học của một sinh viên cho một học phần cụ thể với mã sinh viên và mã học phần, điểm quá trình, điểm thi kết thúc học phần là tham số đầu vào.
create PROCEDURE CapNhatDiemSV @MaSinhVien VARCHAR(10), @MaHocPhan VARCHAR(25),
								@DiemQuaTrinh FLOAT, @DiemThiKTHP FLOAT
AS
BEGIN
	declare @diem float, @TrongSoQT float, @TrongSOKT float, @lan int
	select @TrongSoQT = TrongSoDiemQuaTrinh, @TrongSOKT = TrongSoDiemThiKTHP from HocPhan where MaHocPhan = @MaHocPhan
	select @diem = (@DiemQuaTrinh*@TrongSOKT+@DiemThiKTHP*@TrongSOKT)
	select @lan = isnull(LanHoc,1) from LopHocPhan_SinhVien where MaHocPhan = @MaHocPhan and MaSinhVien = @MaSinhVien
	update LopHocPhan_SinhVien set
	DiemQuaTrinh = @DiemQuaTrinh, DiemThiKTHP = @DiemThiKTHP,
	DiemTKHP = @diem, DiemHeChu = CASE
        WHEN @diem >= 8.5 THEN 'A' WHEN @diem >= 7.0 THEN 'B'
        WHEN @diem >= 5.5 THEN 'C' WHEN @diem >= 4.5 THEN 'D'
        ELSE 'F'
    END, DiemHe4 = case 
		when @diem >= 9.5 then 4.0 when @diem >= 8.5 then 3.8
		when @diem >= 8.0 then 3.5 when @diem >= 7.0 then 3.0
		when @diem >= 6.0 then 2.5 when @diem >= 5.5 then 2.0 
		when @diem >= 4.5 then 1.5 when @diem >= 4.0 then 1
		when @diem >= 2.0 then 0.5 else 0 end
		, LanHoc = @lan
	where MaHocPhan = @MaHocPhan and MaSinhVien = @MaSinhVien
END
--chay
EXEC CapNhatDiemSV @MaSinhVien = '212602565', @MaHocPhan = 'IE3.002.3', @DiemQuaTrinh = 9, @DiemThiKTHP = 9;

--2.	Tạo thủ tục để tính điểm trung bình cho một sinh viên theo từng học phần với mã sinh viên là tham số đầu vào.
alter PROCEDURE DTB @MaSinhVien VARCHAR(20)
AS
BEGIN
	select avg(A.DiemTrungBinh)
	from(select lhpsv.MaHocPhan, max(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) as DiemTrungBinh
		from LopHocPhan_SinhVien lhpsv
		join HocPhan hp on hp.MaHocPhan = lhpsv.MaHocPhan
		where MaSinhVien = @MaSinhVien
		group by lhpsv.MaHocPhan ) A
END
--chay
EXEC DTB @MaSinhVien = '171202737'

select lhpsv.MaHocPhan, MaLopHocPhan, (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) as Diem
		from LopHocPhan_SinhVien lhpsv
		join HocPhan hp on hp.MaHocPhan = lhpsv.MaHocPhan
		where MaSinhVien = '171202737'

--3.	Tạo thủ tục để tính điểm tích lũy cho một sinh viên với mã sinh viên là tham số đầu vào.
--4.	Tạo thủ tục có đầu vào là mã lớp học phần, mã học phần, năm học, kỳ học đầu ra là danh sách sinh viên không đủ điều kiện thi của học phần đó.
--5.	Tạo thủ tục để cập nhật tình trạng học vụ của sinh viên dựa trên điểm số (cảnh cáo, đình chỉ, v.v.) với đầu vào là mã sinh viên, năm học, kỳ học.
--5.Tạo thủ tục để cập nhật tình trạng học vụ của sinh viên dựa trên điểm số (cảnh cáo, đình chỉ, v.v.) với đầu vào là mã sinh viên, năm học, kỳ học.
alter table SinhVien add TinhTrangHocVu nvarchar(20)
create procedure cau55(@MaSinhVien varchar(10),@NamHoc VARCHAR(20),@HocKy INT)
AS
BEGIN
    DECLARE @DiemTichLuy FLOAT
    SELECT @DiemTichLuy = SUM(((DiemQuaTrinh * TrongSoDiemQuaTrinh + DiemThiKTHP * TrongSoDiemThiKTHP) * 0.4) * SoTinChi) / SUM(SoTinChi)
    FROM LopHocPhan_SinhVien JOIN HocPhan ON LopHocPhan_SinhVien.MaHocPhan = HocPhan.MaHocPhan
	join LopHocPhan on LopHocPhan_SinhVien.MaHocPhan = LopHocPhan.MaHocPhan
    WHERE MaSinhVien = @MaSinhVien 
      AND NamHoc = @NamHoc 
      AND HocKy = @HocKy
    IF @DiemTichLuy < 1.0
        UPDATE SinhVien
        SET TinhTrangHocVu = N'Đình Chỉ'
        WHERE MaSinhVien = @MaSinhVien
    ELSE IF @DiemTichLuy < 1.5
        UPDATE SinhVien
        SET TinhTrangHocVu = N'Cảnh Cáo'
        WHERE MaSinhVien = @MaSinhVien
    ELSE
        UPDATE SinhVien
        SET TinhTrangHocVu = N'Đạt'
        WHERE MaSinhVien = @MaSinhVien
END
--Sử dụng
exec cau55 @MaSinhVien = '171202737', @NamHoc ='2022-2023', @HocKy = 2
select * from SinhVien where MaSinhVien = '171202737'
--6.	Tạo thủ tục để liệt kê tất cả các học phần mà sinh viên còn nợ điểm (chưa qua học phần) với mã sinh viên là tham số đầu vào.
--7.	Tạo thủ tục tính điểm tích lũy của một sinh viên (điểm trung bình của các học phần đã học theo hệ 4) với mã sinh viên là tham số đầu vào.
--8.	Tạo thủ tục tính điểm trung bình của toàn bộ sinh viên trong một lớp học phần với mã lớp học phần là tham số đầu vào
alter PROCEDURE TinhDiemTrungBinhLopHocPhan(
    @MaLopHocPhan VARCHAR(25),
    @DiemTrungBinh FLOAT OUTPUT
)
AS
BEGIN
    SELECT @DiemTrungBinh = AVG(
        CASE 
            WHEN (DiemQuaTrinh * TrongSoDiemQuaTrinh + DiemThiKTHP * TrongSoDiemThiKTHP) >= 8.5 THEN 4.0
            WHEN (DiemQuaTrinh * TrongSoDiemQuaTrinh + DiemThiKTHP * TrongSoDiemThiKTHP) >= 7.0 THEN 3.0
            WHEN (DiemQuaTrinh * TrongSoDiemQuaTrinh + DiemThiKTHP * TrongSoDiemThiKTHP) >= 5.5 THEN 2.0
            WHEN (DiemQuaTrinh * TrongSoDiemQuaTrinh + DiemThiKTHP * TrongSoDiemThiKTHP) >= 4.0 THEN 1.0
            ELSE 0.0
        END
    )
    FROM LopHocPhan_SinhVien join HocPhan on LopHocPhan_SinhVien.MaHocPhan = HocPhan.MaHocPhan
    WHERE MaLopHocPhan = @MaLopHocPhan;
END;
DECLARE @Diem FLOAT;
EXEC TinhDiemTrungBinhLopHocPhan @MaLopHocPhan = '1-2-22-QT02', @DiemTrungBinh = @Diem OUTPUT;
SELECT @Diem AS DiemTrungBinhLopHocPhan;
--9.	Tạo thủ tục tính điểm trung bình của toàn bộ sinh viên trong một lớp với mã lớp là tham số đầu vào
--10.	Tạo thủ tục sửa điểm cho sinh viên với tham số đầu vào là mã sinh viên, mã học phần, điểm quá trình, điểm thi kết thúc học phần
CREATE PROCEDURE SuaDiemSinhVien(@MaSinhVien VARCHAR(10),@MaHocPhan VARCHAR(25),@DiemQuaTrinh FLOAT,@DiemThiKTHP FLOAT)
AS
BEGIN
    DECLARE @DiemTKHP FLOAT;
    SET @DiemTKHP = (@DiemQuaTrinh * 0.4) + (@DiemThiKTHP * 0.6);
    UPDATE LopHocPhan_SinhVien
    SET DiemQuaTrinh = @DiemQuaTrinh,
        DiemThiKTHP = @DiemThiKTHP,
        DiemTKHP = @DiemTKHP
    WHERE MaSinhVien = @MaSinhVien AND MaHocPhan = @MaHocPhan;
END
EXEC SuaDiemSinhVien @MaSinhVien = '212600556', @MaHocPhan = 'IE3.002.3', @DiemQuaTrinh = 6.5, @DiemThiKTHP = 8.8
--11.	Tính điểm trung bình tích lũy cho toàn bộ sinh viên của một khóa trong một khoa với mã khoa và khóa là tham số đầu vào (ví dụ tính điểm trung bình tích lũy của toàn bộ sinh viên khóa 65 của khoa công nghệ thông tin)
--12.	Thống kê tỷ lệ sinh viên đạt và không đạt trong kỳ thi của một học phần với mã học phần, học kỳ học, năm học là tham số đầu vào (ví dụ tính số sinh viên đạt, không đạt trong kỳ thi kết thúc học phần của học phần cơ sở dữ liệu trong học kỳ 2 của năm học 2024-2025)
--13.	Thống kê tỷ lệ sinh viên đạt A, B, C, D, F của một học phần với mã học phần, học kỳ học, năm học là tham số đầu vào (ví dụ tính số sinh viên đạt, không đạt khi học học phần cơ sở dữ liệu trong học kỳ 2 của năm học 2024-2025)
--14.	Tạo thủ tục tính số tín chỉ đã hoàn thành và chưa hoàn thành (bao gồm cả học phần chưa học và học phần trượt môn) dựa trên mã sinh viên là tham số đầu vào.
--15.	Tạo thủ tục đưa ra mã giảng viên, tên giảng viên đang dạy một lớp học phần dựa trên mã lớp học phần.
CREATE PROCEDURE TimGiangVienLopHocPhan(@MaLopHocPhan VARCHAR(25))
AS
BEGIN
    SELECT gv.MaGiangVien, gv.HoDem + ' ' + gv.Ten AS TenGiangVien
    FROM LopHocPhan lhp
    JOIN GiangVien gv ON lhp.MaGiangVien = gv.MaGiangVien
    WHERE lhp.MaLopHocPhan = @MaLopHocPhan;
END

EXEC TimGiangVienLopHocPhan @MaLopHocPhan = '1-2-22-QT02'

--Hàm
--1.	Tạo hàm đưa ra danh sách sinh viên trong một lớp học cụ thể với mã lớp là tham số đầu vào.
create function DSSVTheoLop (@MaLop varchar(25))
returns table
as
return
(
	select MaSinhVien, HoDem, Ten, NgaySinh
	from SinhVien
	where MaLop = @MaLop
)
select * from DSSVTheoLop('K61.CNTT2')
--2.	Tạo hàm hiển thị danh sách sinh viên sinh viên theo từng chương trình đào tạo cụ thể (mã chương trình đào tạo là tham số đầu vào).
CREATE FUNCTION DanhSachSinhVienTheoCTDT (@MaCTDT NVARCHAR(10))
RETURNS TABLE
AS
RETURN
(
    SELECT 
        sv.MaSinhVien,
        sv.HoDem + ' ' + sv.Ten AS HoTen,
        sv.NgaySinh,
        sv.DiaChi
    FROM SinhVien sv
    WHERE sv.MaCTDT = @MaCTDT
)

select * from DanhSachSinhVienTheoCTDT('7.48.02.01')
--3.	Tạo hàm hiển thị danh sách điểm của từng lớp gồm mã sinh viên, họ đệm, tên, điểm quá trình, điểm thi, điểm tổng kết học phần, điểm hệ chữ trong một lớp học phần cụ thể với mã lớp học phần, mã học phần, năm học, kỳ học là tham số đầu vào.
--4.	Tạo hàm để truy xuất danh sách các sinh viên có điểm trung bình thấp hơn điểm trung bình của cả lớp với mã lớp, năm học, kỳ học là tham số đầu vào
--5.	Đưa ra bảng điểm của sinh viên với mã sinh viên là tham số đầu vào và mỗi học phần chỉ đưa ra một thông tin điểm cho lần học có điểm cao nhất (điểm TKHP)
--6.	Tạo hàm đưa ra danh sách xếp hạng các sinh viên có điểm hệ 4 từ 3.2 trở lên của một khoa trong một học kỳ với mã khoa, kỳ học, năm học là tham số đầu vào 
--7.	Tạo hàm để liệt kê tất cả các học phần mà sinh viên được phép học cải thiện điểm (có điểm C, D, F) với mã sinh viên là tham số đầu vào.
UPDATE lhp
SET DiemHeChu = (
    CASE 
        WHEN (lhp.DiemQuaTrinh * hp2.TrongSoDiemQuaTrinh + lhp.DiemThiKTHP * hp2.TrongSoDiemThiKTHP) >= 8.5 THEN 'A'
        WHEN (lhp.DiemQuaTrinh * hp2.TrongSoDiemQuaTrinh + lhp.DiemThiKTHP * hp2.TrongSoDiemThiKTHP) >= 7.0 THEN 'B'
        WHEN (lhp.DiemQuaTrinh * hp2.TrongSoDiemQuaTrinh + lhp.DiemThiKTHP * hp2.TrongSoDiemThiKTHP) >= 5.5 THEN 'C'
        WHEN (lhp.DiemQuaTrinh * hp2.TrongSoDiemQuaTrinh + lhp.DiemThiKTHP * hp2.TrongSoDiemThiKTHP) >= 4 THEN 'D'
        ELSE 'F'
    END
)
FROM LopHocPhan_SinhVien lhp
JOIN HocPhan hp2 ON lhp.MaHocPhan = hp2.MaHocPhan;

ALTER FUNCTION hocCaiThien (@MaSinhVien nvarchar(10))
RETURNS TABLE
AS
RETURN
(
    SELECT lhp.MaHocPhan, lhp.DiemHeChu
    FROM LopHocPhan_SinhVien lhp
    WHERE lhp.MaSinhVien = @MaSinhVien
      AND lhp.DiemHeChu IN ('C', 'D', 'F')
      AND NOT EXISTS (
          SELECT 1
          FROM LopHocPhan_SinhVien lhp2
          WHERE lhp2.MaSinhVien = lhp.MaSinhVien
            AND lhp2.MaHocPhan = lhp.MaHocPhan
            AND (lhp2.DiemHeChu = 'A' OR lhp2.DiemHeChu = 'B')
      )
);


select * from hocCaiThien('212602565')
select * from LopHocPhan_SinhVien where MaSinhVien = '212602565'
update LopHocPhan_SinhVien set DiemQuaTrinh = 1, DiemThiKTHP = 1
where MaHocPhan = 'IE3.002.3' and MaLopHocPhan = '1-2-22-QT02' and MaSinhVien= '212602565'


create function cau7func(@maKhoa nvarchar(20),@nam nvarchar(20), @ki int)
returns table
as return(
	select SinhVien.MaSinhVien, HoDem +' '+Ten as hoten, 
	sum((TrongSoDiemQuaTrinh*DiemQuaTrinh+TrongSoDiemThiKTHP*DiemThiKTHP)*SoTinChi)/sum(SoTinChi)*4/10 as diemhe4
	from SinhVien join LopHocPhan_SinhVien on SinhVien.MaSinhVien=LopHocPhan_SinhVien.MaSinhVien
	join LopHocPhan on LopHocPhan.MaLopHocPhan=LopHocPhan_SinhVien.MaLopHocPhan and LopHocPhan.MaHocPhan=LopHocPhan_SinhVien.MaHocPhan
	join HocPhan on HocPhan.MaHocPhan=LopHocPhan.MaHocPhan
	join Lop on Lop.MaLop= SinhVien.MaLop
	where NamHoc=@nam and HocKy=@ki and MaKhoa=@maKhoa
	group by SinhVien.MaSinhVien,HoDem, Ten
	having sum((TrongSoDiemQuaTrinh*DiemQuaTrinh+TrongSoDiemThiKTHP*DiemThiKTHP)*SoTinChi)/sum(SoTinChi)*4/10>=3.2
)
select * from cau7func('CNTT','2022-2023',2)
--8.	Tạo hàm để tính và thống kê điểm trung bình của tất cả sinh viên theo từng chương trình đào tạo với mã chương trình đào tạo là tham số đầu vào
--9.	Tạo hàm thống kê số sinh viên đạt điểm A, B, C, D, F cho một học phần trong một kỳ học với tham số đầu vào là mã học phần, kỳ học, năm học.
--10.	Tạo hàm đưa ra danh sách sinh viên trong một khóa có điểm trung bình của một kỳ thấp hơn một ngưỡng nhất định với ngưỡng, khóa học là tham số đầu vào.
--11.	Tạo hàm để tính và thống kê điểm trung bình toàn khóa cho sinh viên với khóa học là tham số đầu vào.
--12.	Tạo hàm tính điểm trung bình của sinh viên theo mã sinh viên.
--13.	 Tạo hàm lấy danh sách thông tin học phần mà sinh viên đã học với mã sinh viên là tham số đầu vào
CREATE FUNCTION LayThongTinHocPhanDaHoc (@MaSinhVien VARCHAR(10))
RETURNS TABLE
AS
RETURN
(SELECT HP.MaHocPhan, HP.TenHocPhan, HP.SoTinChi, LHSV.DiemTKHP AS DiemTichLuy
    FROM LopHocPhan_SinhVien AS LHSV
    INNER JOIN HocPhan AS HP ON LHSV.MaHocPhan = HP.MaHocPhan
    WHERE LHSV.MaSinhVien = @MaSinhVien
)

select * from LayThongTinHocPhanDaHoc('212602565')
select * from LopHocPhan_SinhVien where MaSinhVien = '212602565'
--14.	Tạo hàm đưa ra danh sách sinh viên đủ điều kiện nhận đồ án (điểm tích lũy hệ 4 là 1.9) với khóa học là tham số đầu vào.
--15.	Tạo hàm đưa ra danh sách sinh viên đủ điều kiện tốt nghiệp (điểm tích lũy hệ 4 là 2.0) với khóa học là tham số đầu vào.
--16.	Tạo hàm kiểm tra sinh viên đủ điều kiện tốt nghiệp (điểm tích lũy hệ 4 là 2.0) với mã sinh viên là tham số đầu vào
--17.	Tạo hàm kiểm tra sinh viên có đăng ký học phần hay chưa dựa trên mã học phần và mã sinh viên.
CREATE FUNCTION KiemTraDangKyHocPhan (@MaHocPhan NVARCHAR(25),@MaSinhVien NVARCHAR(10))
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @Status NVARCHAR(50);
    IF EXISTS (
        SELECT 1
        FROM LopHocPhan_SinhVien
        WHERE MaHocPhan = @MaHocPhan
        AND MaSinhVien = @MaSinhVien
    )
    BEGIN
        SET @Status = N'Đã đăng ký';
    END
    ELSE
    BEGIN
        SET @Status = N'Chưa đăng ký';
    END
    RETURN @Status
END

SELECT dbo.KiemTraDangKyHocPhan('IE3.002.3', '991790005')

CREATE FUNCTION KiemTraDangKyHocPhan2 (
    @MaSinhVien VARCHAR(10),
    @MaHocPhan VARCHAR(25)
)
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @KetQua NVARCHAR(50);
  
    IF EXISTS (
        SELECT 1
        FROM LopHocPhan_SinhVien
        WHERE MaSinhVien = @MaSinhVien
          AND MaHocPhan = @MaHocPhan
    )
    BEGIN
        SET @KetQua = N'đã đăng ký'; 
    END
    ELSE
    BEGIN
        SET @KetQua = N'chưa đăng ký'; 
    END

    RETURN @KetQua;
END;


SELECT dbo.KiemTraDangKyHocPhan2('212600556', 'IE3.002.3') AS KetQua;
--18.	Tạo hàm để tính tổng số sinh viên đang học trong một lớp học phần cụ thể.
CREATE FUNCTION TinhTongSoSinhVienTrongLop (
    @MaLopHocPhan VARCHAR(25)
)
RETURNS INT
AS
BEGIN
    DECLARE @TongSoSinhVien INT;

    -- Đếm số lượng sinh viên đã đăng ký vào lớp học phần
    SELECT @TongSoSinhVien = COUNT(*)
    FROM LopHocPhan_SinhVien
    WHERE MaLopHocPhan = @MaLopHocPhan;

    RETURN @TongSoSinhVien;
END;
select dbo.TinhTongSoSinhVienTrongLop('1-2-22-QT02')
select * from LopHocPhan_SinhVien where MaLopHocPhan ='1-2-22-QT02'
--19.	Tạo hàm để tính tổng số học phần, số lớp do một khoa giảng dạy với mã khoa, kỳ học, năm học là tham số đầu vào.
CREATE FUNCTION cau19fc (@MaKhoa VARCHAR(10),@KyHoc INT,@NamHoc VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT COUNT(DISTINCT HP.MaHocPhan) AS TongSoHocPhan,
        COUNT(DISTINCT LHP.MaLopHocPhan) AS TongSoLop
    from HocPhan HP join BoMon on HP.MaBoMon = BoMon.MaBoMon
	join LopHocPhan LHP on HP.MaHocPhan = LHP.MaHocPhan
    WHERE BoMon.MaKhoa = @MaKhoa
        AND LHP.HocKy = @KyHoc
        AND LHP.NamHoc = @NamHoc
)
select * from cau19fc('CNTT',2,'2022-2023')

select BoMon.MaBoMon ,HocPhan.MaHocPhan, LopHocPhan.MaLopHocPhan 
from  BoMon 
join HocPhan on BoMon.MaBoMon = HocPhan.MaBoMon
left join LopHocPhan on HocPhan.MaHocPhan = LopHocPhan.MaHocPhan
where BoMon.MaKhoa = 'CNTT' and NamHoc ='2022-2023' and HocKy = 2
order by BoMon.MaBoMon desc
--20.	Tạo hàm để tính tổng số học phần, số lớp do một bộ môn giảng dạy với mã bộ môn, kỳ học, năm học là tham số đầu vào.
CREATE FUNCTION TinhTongHocPhan_Lop (@MaBoMon VARCHAR(10),@KyHoc INT,@NamHoc VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT COUNT(DISTINCT HP.MaHocPhan) AS TongSoHocPhan,
        COUNT(DISTINCT LHP.MaLopHocPhan) AS TongSoLop
    FROM LopHocPhan AS LHP
    INNER JOIN HocPhan AS HP ON LHP.MaHocPhan = HP.MaHocPhan
    WHERE HP.MaBoMon = @MaBoMon
        AND LHP.HocKy = @KyHoc
        AND LHP.NamHoc = @NamHoc
)
select * from TinhTongHocPhan_Lop('MHT',1,'2023-2024')

select BoMon.MaBoMon ,HocPhan.MaHocPhan, LopHocPhan.MaLopHocPhan 
from Khoa join BoMon on Khoa.MaKhoa = BoMon.MaKHoa
join HocPhan on BoMon.MaBoMon = HocPhan.MaBoMon
left join LopHocPhan on HocPhan.MaHocPhan = LopHocPhan.MaHocPhan
where Khoa.MaKhoa = 'CNTT' and BoMon.MaBoMon = 'MHT' and NamHoc ='2023-2024' and HocKy = 2
order by BoMon.MaBoMon desc

--DML trigger
--1.Tạo trường Trạng thái của bảng sinh viên, tự động cập nhật trạng thái tốt nghiệp của sinh viên khi họ đạt đủ điều kiện tốt nghiệp 
--(hoàn thành đủ môn học, không nợ môn, có điểm tích lũy (hệ 4) toàn khóa từ 2 trở lên).
--2.Tạo trigger tự động tính lại điểm kết thúc học phần, điểm hệ chữ, điểm hệ 4, 
--lần học của sinh viên sau khi có thay đổi về điểm trong bảng LopHocPhan_SinhVien
create trigger TinhDiem on LopHocPhan_Sinhvien 
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
UPDATE LopHocPhan_SinhVien
SET DiemQuaTrinh = 9, DiemThiKTHP = 9
WHERE MaHocPhan = 'IT1.217.3' AND MaLopHocPhan = '1-2-23-N04' AND MaSinhVien = '882126017';

delete from LopHocPhan_SinhVien
where MaSinhVien='882126017' and MaHocPhan = 'IT1.217.3' and MaLopHocPhan = '1-2-23-N04'
select * from LopHocPhan_SinhVien where MaSinhVien='882126017'
--3.Tạo trigger gửi thông báo khi sinh viên hoàn thành tất cả các học phần trong chương trình đào tạo.
--4.Xây dựng bảng trạng thái lớp gồm các trường mã lớp, số SV tốt nghiệp, Số SV buộc thôi học, Số SV chưa tốt nghiệp.
--Tạo trigger tự động cập nhật trạng thái bảng này.
--5.Tạo trigger tự động xóa các bản ghi điểm khi sinh viên bị xóa khỏi cơ sở dữ liệu.
alter TRIGGER XoaSV11 ON SinhVien
instead of delete
AS
BEGIN	
    DELETE FROM LopHocPhan_SinhVien
    WHERE MaSinhVien IN (SELECT MaSinhVien FROM DELETED)
	DELETE FROM SinhVien
    WHERE MaSinhVien IN (SELECT MaSinhVien FROM DELETED)
END

delete SinhVien WHERE MaSinhVien ='212601105' or MaSinhVien ='212602500'
select * from LopHocPhan_SinhVien WHERE MaSinhVien ='212601105' or MaSinhVien ='212602500'
select * from SinhVien where MaSinhVien='212601105' or MaSinhVien ='212602500'
--6.Tạo bảng SinhVien_CNTT_K65 gồm các trường mã sinh viên, tên sinh viên, lớp, các trường có trong chương trình đào tạo của sinh viên CNTT K65, 
--trường số tín chỉ hoàn thành, điểm tích lũy. Tạo trigger tự động cập nhật:
---	Họ và tên, mã sinh viên, lớp mỗi khi thêm một sinh viên K65
---	Thêm điểm cao nhất của các môn ứng với các cột tương ứng
---	Tính tổng số tín chỉ hoàn thành vào trường số tín chỉ hoàn thành
---	Tính điểm tích lũy vào trường điểm tích lũy
