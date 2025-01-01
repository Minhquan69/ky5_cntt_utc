--Tạo View theo các yêu cầu sau:
--1.	Tạo view liệt kê tất cả các sinh viên trong trường, bao gồm mã sinh viên, tên, ngày sinh, và lớp học.
create view yc1 as
select MaSinhVien, Ten, NgaySinh, TenLop
from SinhVien join Lop on SinhVien.MaLop = Lop.MaLop

--2.	Tạo view đưa ra bảng điểm của sinh viên có mã 171202737 bao gồm mã học phần, tên học phần, điểm quá trình, 
--điểm thi và điểm tổng kết hệ 10, điểm tổng kết hệ chữ.
select hp.MaHocPhan, hp.TenHocPhan, lhpsv.DiemQuaTrinh, lhpsv.DiemThiKTHP,
	(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) as TongKetHe10,
   case when (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 8.5 then 'A'
		when (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 7.0 then 'B'
		when (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 5.5 then 'C'
		when (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 4.0 then 'D'
		else 'F'
	end as DiemHeChu
from LopHocPhan_SinhVien lhpsv join HocPhan hp on lhpsv.MaHocPhan=hp.MaHocPhan
where lhpsv.MaSinhVien = '171202737'

with MaxDiem as( select lhpsv.MaHocPhan, Max(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) as DiemMax from LopHocPhan_SinhVien lhpsv join HocPhan hp on lhpsv.MaHocPhan=hp.MaHocPhan
 where lhpsv.MaSinhVien = '171202737' group by lhpsv.MaHocPhan
)
select lhpsv.MaHocPhan, hp.TenHocPhan, lhpsv.DiemQuaTrinh, lhpsv.DiemThiKTHP, (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) as TongKetHe10,
case when (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 8.5 then 'A'
		when (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 7.0 then 'B'
		when (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 5.5 then 'C'
		when (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 4.0 then 'D'
		else 'F'
	end as DiemHeChu
from LopHocPhan_SinhVien lhpsv join HocPhan hp on lhpsv.MaHocPhan = hp.MaHocPhan
join MaxDiem on lhpsv.MaHocPhan = MaxDiem.MaHocPhan
where lhpsv.MaSinhVien = '171202737' and (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) = MaxDiem.



with MaxDiem as(
	select lhpsv.MaHocPhan, Max(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) as DiemMax
	from LopHocPhan_SinhVien lhpsv join HocPhan hp
	on lhpsv.MaHocPhan = hp.MaHocPhan
	where lhpsv.MaSinhVien = '171202737'
	group by lhpsv.MaHocPhan
)

SELECT lhpsv.MaHocPhan, hp.TenHocPhan, lhpsv.DiemQuaTrinh, lhpsv.DiemThiKTHP,
    (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) AS DiemHe10,
    CASE
        WHEN (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) >= 8.5 THEN 'A'
        WHEN (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) >= 7.0 THEN 'B'
        WHEN (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) >= 5.5 THEN 'C'
        WHEN (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) >= 4.5 THEN 'D'
        ELSE 'F'
    END AS DiemHeChu,
    lhpsv.LanHoc
FROM LopHocPhan_SinhVien lhpsv 
JOIN HocPhan hp ON lhpsv.MaHocPhan = hp.MaHocPhan 
JOIN MaxDiem md ON lhpsv.MaHocPhan = md.MaHocPhan
AND (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) = md.DiemMax
WHERE lhpsv.MaSinhVien = '171202737'




SELECT 
    lhpsv.MaHocPhan, hp.TenHocPhan, lhpsv.DiemQuaTrinh, lhpsv.DiemThiKTHP,
    (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) as DiemHe10,
    CASE
        WHEN (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 8.5 THEN 'A'
        WHEN (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 7.0 THEN 'B'
        WHEN (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 5.5 THEN 'C'
        WHEN (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) >= 4.5 THEN 'D'
        ELSE 'F'
    END as DiemHeChu, LanHoc
FROM LopHocPhan_SinhVien lhpsv
JOIN LopHocPhan lhp ON lhpsv.MaLopHocPhan = lhp.MaLopHocPhan
JOIN HocPhan hp ON lhp.MaHocPhan = hp.MaHocPhan
WHERE lhpsv.MaSinhVien = '171202737'
    AND (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) = 
    (
        select Max(lhpsv2.DiemQuaTrinh*hp2.TrongSoDiemQuaTrinh + lhpsv2.DiemThiKTHP*hp2.TrongSoDiemThiKTHP)
		from LopHocPhan_SinhVien lhpsv2 join HocPhan hp2 
		on lhpsv2.MaHocPhan = hp2.MaHocPhan
		where lhpsv2.MaSinhVien = lhpsv.MaSinhVien and hp.MaHocPhan=hp2.MaHocPhan
    )




--3.	Tạo view hiển thị danh sách các sinh viên còn nợ môn Cơ sở dữ liệu.
select sv.MaSinhVien, sv.Ten, (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP)
	as DiemKTHP
from SinhVien sv join LopHocPhan_SinhVien lhpsv on sv.MaSinhVien = lhpsv.MaSinhVien
	join HocPhan hp on lhpsv.MaHocPhan = hp.MaHocPhan
where hp.TenHocPhan = N'Cơ sở dữ liệu'
and (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh+lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) < 4
AND (lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) = 
    (
        SELECT 
            MAX(lhpsv2.DiemQuaTrinh*hp2.TrongSoDiemQuaTrinh + lhpsv2.DiemThiKTHP*hp2.TrongSoDiemThiKTHP)
        FROM LopHocPhan_SinhVien lhpsv2
        JOIN HocPhan hp2 ON lhpsv2.MaHocPhan = hp2.MaHocPhan
        WHERE lhpsv2.MaSinhVien = lhpsv.MaSinhVien
            AND hp2.TenHocPhan = N'Cơ sở dữ liệu'
    )


SELECT 
    sv.MaSinhVien, 
    sv.Ten, 
    MAX(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) AS DiemKTHP
FROM 
    SinhVien sv 
JOIN 
    LopHocPhan_SinhVien lhpsv ON sv.MaSinhVien = lhpsv.MaSinhVien
JOIN 
    HocPhan hp ON lhpsv.MaHocPhan = hp.MaHocPhan
WHERE 
    hp.TenHocPhan = N'Cơ sở dữ liệu'
GROUP BY 
    sv.MaSinhVien, sv.Ten
HAVING 
    MAX(lhpsv.DiemQuaTrinh*hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP*hp.TrongSoDiemThiKTHP) < 4;
--4.	Tạo view để thống kê số lượng sinh viên theo mỗi khoa.
SELECT k.MaKhoa, k.TenKhoa, 
    COUNT(sv.MaSinhVien) AS SoLuongSinhVien
FROM SinhVien sv
JOIN Lop l ON sv.MaLop = l.MaLop
JOIN Khoa k ON l.MaKhoa = k.MaKhoa
GROUP BY k.MaKhoa, k.TenKhoa
ORDER BY SoLuongSinhVien DESC;
--5.	Tạo view hiển thị danh sách tất cả các giảng viên, bao gồm tên, khoa, và các môn họ giảng dạy.
SELECT DISTINCT gv.HoDem + ' ' + gv.Ten AS TenGiangVien, k.TenKhoa, hp.TenHocPhan
FROM GiangVien gv
JOIN BoMon bm ON gv.MaBoMon = bm.MaBoMon
JOIN Khoa k ON bm.MaKhoa = k.MaKhoa
JOIN LopHocPhan lhp ON gv.MaGiangVien = lhp.MaGiangVien
JOIN HocPhan hp ON lhp.MaHocPhan = hp.MaHocPhan
ORDER BY TenGiangVien, TenKhoa, TenHocPhan

--6.	Tạo view liệt kê tất cả các lớp học phần được giảng dạy trong kỳ hiện tại của Bộ môn Mạng và các HTTT, 
--kèm theo mã môn học, tên môn, và giảng viên phụ trách.
SELECT lhp.MaLopHocPhan,hp.MaHocPhan,hp.TenHocPhan,
    gv.HoDem + ' ' + gv.Ten AS TenGiangVien
FROM LopHocPhan lhp
JOIN HocPhan hp ON lhp.MaHocPhan = hp.MaHocPhan
JOIN GiangVien gv ON lhp.MaGiangVien = gv.MaGiangVien
JOIN BoMon bm ON gv.MaBoMon = bm.MaBoMon
WHERE bm.TenBoMon = N'MẠNG VÀ CÁC HỆ THỐNG THÔNG TIN'
    AND lhp.NamHoc = CASE 
                        WHEN MONTH(GETDATE()) BETWEEN 8 AND 12 THEN CONCAT(YEAR(GETDATE()), '-', YEAR(GETDATE()) + 1)
                        ELSE CONCAT(YEAR(GETDATE()) - 1, '-', YEAR(GETDATE()))
                      END
    AND lhp.HocKy = CASE 
                       WHEN MONTH(GETDATE()) BETWEEN 8 AND 12 THEN 1  -- Học kỳ 1
                       WHEN MONTH(GETDATE()) BETWEEN 1 AND 5 THEN 2   -- Học kỳ 2
                       ELSE 3  -- Học kỳ hè
                    END
ORDER BY lhp.MaLopHocPhan, hp.MaHocPhan, TenGiangVien;



--7.	Tạo view hiển thị tất cả các môn học mà sinh viên 201200026 đã học, bao gồm điểm số và trạng thái hoàn thành.
SELECT 
    hp.MaHocPhan,
    hp.TenHocPhan,
    lhpsv.DiemQuaTrinh,
    lhpsv.DiemThiKTHP,
    lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP AS DiemKTHP,
    CASE
        WHEN lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP >= 5.0 THEN 'Hoàn thành'
        ELSE 'Chưa hoàn thành'
    END AS TrangThaiHoanThanh
FROM 
    LopHocPhan_SinhVien lhpsv
JOIN 
    HocPhan hp ON lhpsv.MaHocPhan = hp.MaHocPhan
WHERE 
    lhpsv.MaSinhVien = '201200026'
    AND (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP) = (
        SELECT 
            MAX(lhpsv2.DiemQuaTrinh * hp2.TrongSoDiemQuaTrinh + lhpsv2.DiemThiKTHP * hp2.TrongSoDiemThiKTHP)
        FROM LopHocPhan_SinhVien lhpsv2
        JOIN HocPhan hp2 ON lhpsv2.MaHocPhan = hp2.MaHocPhan
        WHERE lhpsv2.MaSinhVien = lhpsv.MaSinhVien
            AND hp2.MaHocPhan = hp.MaHocPhan
    )
ORDER BY 
    hp.MaHocPhan, hp.TenHocPhan


--8.	Tạo view liệt kê tất cả các sinh viên đã nhận được học bổng trong kỳ học hiện tại (những bạn có điểm tổng kết 3.6 hệ 4 trở lên).
--9.	Tạo view hiển thị danh sách các sinh viên bị cảnh báo học vụ cho các sinh viên có điểm trung bình cả kỳ học dưới 1 (hệ 4).
--10.	Tạo view hiển thị danh sách các sinh viên bị buộc thôi học cho các sinh viên có ba kỳ liên tiếp bị cảnh báo học vụ.
--11.	Tạo view thống kê số lượng môn học được giảng dạy trong từng Bộ môn.
--12.	Tạo view để thống kê tỷ lệ sinh viên đã hoàn thành và chưa hoàn thành từng môn học.
--13.	Tạo view hiển thị top 10 phần trăm danh sách các sinh viên có điểm trung bình cao nhất mỗi lớp.
--14.	Tạo view liệt kê tất cả các sinh viên còn nợ môn học và chưa đủ điều kiện tốt nghiệp.
--15.	Tạo view đưa sinh viên đủ điều kiện nhận đồ án tốt nghiệp (sinh viên có điểm tích lũy >=1.9).
--16.	Taoh view hiển thị danh sách sinh viên và số tín chỉ họ đã hoàn thành?
--17.	Tạo view hiển thị danh sách các môn học không có sinh viên nào đăng ký?
--18.	Tạo view để liệt kê tất cả các lớp học dưới số lượng sinh viên tối thiểu (tối thiểu 15 SV) cho phép?
--19.	Tạo view hiển thị tỷ lệ sinh viên qua môn (>=4), giỏi (>=8.5) so với tổng số sinh viên theo từng ngành học?
--20.	Tạo view để liệt kê các sinh viên đã cải thiện điểm số sau kỳ thi lại.
--21.	
--THỦ TỤC
--1.	Tạo thủ tục hiển thị lịch dạy của giảng viên trong tuần hiện tại, bao gồm thời gian, 
--phòng học và môn học với mã giảng viên là tham số đầu vào.
CREATE PROCEDURE HienThiLichDay_GiangVien(
    @MaGiangVien VARCHAR(10)
)
AS
BEGIN
    SELECT 
        LHP.TenLopHocPhan, 
        LHP.NamHoc, 
        LHP.HocKy, 
        LHP.DotHoc, 
        LHP.PhongHoc, 
        LHP.ThoiGian
    FROM 
        LopHocPhan LHP
    WHERE 
        LHP.MaGiangVien = @MaGiangVien
        AND DATEPART(WEEK, GETDATE()) = DATEPART(WEEK, LHP.ThoiGian)
    ORDER BY 
        LHP.ThoiGian;
END;

--2.	Tạo thủ tục để cập nhật điểm số của một sinh viên cho một môn học cụ thể với mã sinh viên và mã môn học là tham số đầu vào.
--3.	Tạo thủ tục để tính điểm trung bình cho một sinh viên theo từng môn học với mã sinh viên là tham số đầu vào.
CREATE PROCEDURE TinhDiemTrungBinh
    @MaSinhVien NVARCHAR(50)
AS
BEGIN
    -- Tính điểm trung bình cho từng môn học của sinh viên
    SELECT
        hp.MaHocPhan,
        hp.TenHocPhan,
        (lhpsv.DiemQuaTrinh * hp.TrongSoDiemQuaTrinh + 
         lhpsv.DiemThiKTHP * hp.TrongSoDiemThiKTHP)  AS DiemTrungBinh
    FROM
        SinhVien sv
    JOIN
        LopHocPhan_SinhVien lhpsv ON sv.MaSinhVien = lhpsv.MaSinhVien
    JOIN
        LopHocPhan lhp ON lhpsv.MaHocPhan = lhp.MaHocPhan AND lhpsv.MaLopHocPhan = lhp.MaLopHocPhan
    JOIN
        HocPhan hp ON lhp.MaHocPhan = hp.MaHocPhan
    WHERE
        sv.MaSinhVien = @MaSinhVien
END

EXEC TinhDiemTrungBinh @MaSinhVien = '212606012';



--4.	Tạo thủ tục để tính điểm tích lũy cho một sinh viên với mã sinh viên là tham số đầu vào.
--5.	Tạo thủ tục có đầu vào là mã lớp học phần, đầu ra là danh sách sinh viên không đủ điều kiện thi của học phần đó.
--6.	Thống kê số sinh viên đạt điểm A, B, C, D, F: Tạo thủ tục để thống kê số lượng sinh viên đạt từng loại điểm cho một môn học với tham số đầu vào là mã môn học.
--7.	Tạo thủ tục để xác định các sinh viên có điểm tích lũy thấp hơn một ngưỡng nhất định.
--8.	Tạo thủ tục để cập nhật tình trạng học vụ của sinh viên dựa trên điểm số (cảnh cáo, đình chỉ, v.v.) với đầu vào là mã sinh viên.
--9.	Tạo thủ tục để tính và thống kê điểm trung bình toàn khóa cho sinh viên với khóa học là tham số đầu vào.
