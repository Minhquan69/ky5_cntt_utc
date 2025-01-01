CREATE PROCEDURE DanhSachSinhVienTheoLop
    @MaLop NVARCHAR(10)
AS
BEGIN
    SELECT 
        DSHS.MaHS, 
        DSHS.Ho, 
        DSHS.Ten, 
        DSHS.NU, 
        DSHS.NgaySinh, 
        DSHS.GhiChu, 
        DSHS.XepLoai AS XepLoaiHanhKiem, 
        Diem.Toan, 
        Diem.Ly, 
        Diem.Hoa, 
        Diem.Van, 
        Diem.DTB, 
        Diem.XepLoai AS XepLoaiHocLuc
    FROM 
        DSHS
    JOIN 
        Diem ON DSHS.MaHS = Diem.MaHS
    WHERE 
        DSHS.MaLop = @MaLop;
END;

EXEC DanhSachSinhVienTheoLop '10A1';



CREATE PROCEDURE DiemTrungBinh @mahs nvarchar(5), @dtb float
 output
 AS
 begin
 select @dtb=round((toan*2+van*2+ly+hoa)/6, 2) from diem where
 MAHS=@mahs
 End

 declare @tb float
 exec DiemTrungBinh '00001', @tb output
 print @tb



