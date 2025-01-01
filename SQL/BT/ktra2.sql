CREATE PROCEDURE BanThang @malcb char(20),@banthang INT OUTPUT
AS
BEGIN
    SET @banthang = 0
    SELECT @banthang = count(bt.GhiBanID)
    FROM CAULACBO clb
    JOIN TRANDAU_GHIBAN bt ON clb.CauLacBoID = bt.CauLacBoID
    WHERE clb.CauLacBoID = @malcb
END


with Khach as ( 
	SELECT SUM(CAST(SUBSTRING(KetQua, 1, CHARINDEX('-', KetQua) - 1) AS INT)) AS HomeTeamGoals
	FROM TRANDAU WHERE CLBKhach = '101'
), Nha as(
	SELECT  SUM(CAST(SUBSTRING(KetQua, CHARINDEX('-', KetQua) + 1, LEN(KetQua)) AS INT)) AS AwayTeamGoals
	FROM TRANDAU WHERE CLBNha = '101'
)
SELECT *
from CAULACBO
where CauLacBoID = '101'

WITH Khach AS (
    SELECT SUM(CAST(SUBSTRING(KetQua, 1, CHARINDEX('-', KetQua) - 1) AS INT)) AS HomeTeamGoals
    FROM TRANDAU
    WHERE CLBKhach = '101'
), 
Nha AS (
    SELECT SUM(CAST(SUBSTRING(KetQua, CHARINDEX('-', KetQua) + 1, LEN(KetQua)) AS INT)) AS AwayTeamGoals
    FROM TRANDAU
    WHERE CLBNha = '101'
)
SELECT 
    ISNULL(Khach.HomeTeamGoals, 0) + ISNULL(Nha.AwayTeamGoals, 0) AS TotalGoals
FROM Khach, Nha;

alter PROCEDURE GetGoalsForTeam
@TeamID VARCHAR(50)
AS
BEGIN

	WITH Khach AS (
		SELECT SUM(CAST(SUBSTRING(KetQua, 1, CHARINDEX('-', KetQua) - 1) AS INT)) AS HomeTeamGoals
		FROM TRANDAU WHERE CLBKhach = @TeamID
	), 
	Nha AS (
		SELECT SUM(CAST(SUBSTRING(KetQua, CHARINDEX('-', KetQua) + 1, LEN(KetQua)) AS INT)) AS AwayTeamGoals
		FROM TRANDAU WHERE CLBNha = @TeamID
	)
	SELECT 
		ISNULL(Khach.HomeTeamGoals, 0) + ISNULL(Nha.AwayTeamGoals, 0) AS TotalGoals
	FROM Khach, Nha
END

exec GetGoalsForTeam '101'
-- chạy
select *
from TRANDAU 
where CLBKhach = '101' or CLBNha = '101'
 SELECT count(bt.GhiBanID)
    FROM CAULACBO clb
    Left JOIN TRANDAU td ON clb.CauLacBoID = td.CLBKhach
	Left JOIN TRANDAU tt ON clb.CauLacBoID = tt.CLBKhach
    WHERE clb.CauLacBoID = '101'


exec GetGoalsForTeam '120'
DECLARE @ban INT
EXEC BanThang @malcb = '120', @banthang = @ban OUTPUT
SELECT @ban AS SoLuongSachBanTrong2014


select *
from TRANDAU
where TranDauID = '1'
select * 
from TRANDAU_GHIBAN 
where TranDauID = '1'


--3
CREATE FUNCTION CauThuCLB(@malcb char(20))
RETURNS TABLE
AS
RETURN
(
    SELECT ct.CauThuID, ct.HoVaTen, ct.ViTri, ct.QuocTich, ct.SoAo
    FROM CAULACBO clb
    JOIN CAUTHU ct on clb.CauLacBoID = ct.CauLacBoID
	where ct.CauLacBoID=@malcb
)
SELECT * FROM CauThuCLB('101')
--4
ALTER TABLE CAULACBO
ADD SotranDau int

create TRIGGER SoTranDau
ON TRANDAU
FOR INSERT, DELETE,UPDATE
AS
BEGIN
	declare @mak_ins char(20),@mak_del char(20),@manha_ins char(20),@manha_del char(20)
	select @mak_ins = CLBKhach, @manha_ins = CLBNha from inserted
	select @mak_del = CLBKhach,@manha_del = CLBNha from deleted
	update CAULACBO set SotranDau=isnull(SotranDau,0)+1 where CauLacBoID = @mak_ins or CauLacBoID = @manha_ins
	update CAULACBO set SotranDau=isnull(SotranDau,0)-1 where CauLacBoID = @mak_del or CauLacBoID = @manha_del
END;

--5
CREATE VIEW Cau5 AS
SELECT distinct clb.CauLacBoID, clb.TenCLB, ct.HoVaTen, svd.TenSan, td.NgayThiDau,
tdgb.ThoiDiemGhiBan
FROM CAULACBO clb
JOIN CAUTHU ct ON clb.CauLacBoID = ct.CauLacBoID
JOIN SANVANDONG svd ON clb.SanVanDongID = svd.SanVanDongID
LEFT JOIN TRANDAU td ON td.CLBKhach = clb.CauLacBoID
LEFT JOIN TRANDAU td1 ON td1.CLBNha = clb.CauLacBoID
JOIN TRANDAU_GHIBAN tdgb ON td.TranDauID = tdgb.TranDauID
WHERE clb.CauLacBoID = (SELECT TOP 1 CauLacBoID FROM CAULACBO WHERE TenCLB = 'Manchester United') 

--6
-- Tạo login
exec sp_addlogin DaoMinhQuan, 123
--tạo user
USE QLiGiaiBongDa
exec sp_adduser  DaoMinhQuan, DaoMinhQuan
-- Phân quyền
GRANT SELECT ON CAUTHU TO NguyenDucThuan

--7
CREATE PROCEDURE c_7
    @CauLacBoID CHAR(20) AS
BEGIN
    -- Kiểm tra xem mã câu lạc bộ có được sử dụng trong các bảng khác không
    IF NOT EXISTS (
        SELECT 1
        FROM CAUTHU
        WHERE CauLacBoID = @CauLacBoID
        UNION ALL
        SELECT 1
        FROM TRANDAU
        WHERE CLBKhach = @CauLacBoID OR CLBNha = @CauLacBoID
        UNION ALL
        SELECT 1
        FROM TRANDAU_GHIBAN
        WHERE CauLacBoID = @CauLacBoID
        UNION ALL
        SELECT 1
        FROM TRANDAU_CAUTHU
        WHERE CauThuID IN (SELECT CauThuID FROM CAUTHU WHERE CauLacBoID = @CauLacBoID)
        UNION ALL
        SELECT 1
        FROM TRONGTAI_TRANDAU
        WHERE TranDauID IN (SELECT TranDauID FROM TRANDAU WHERE CLBKhach = @CauLacBoID OR CLBNha = @CauLacBoID)
    )
    BEGIN
        -- Nếu không có sử dụng, xóa câu lạc bộ
        DELETE FROM CAULACBO
        WHERE CauLacBoID = @CauLacBoID;
    END
    ELSE
    BEGIN
        PRINT 'Câu lạc bộ này vẫn đang được sử dụng và không thể xóa.';
    END
END