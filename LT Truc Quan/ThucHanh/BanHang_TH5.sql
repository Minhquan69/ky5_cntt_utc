create database BanHang2
use BanHang2

create table tblUser(userName  nvarchar(50), passWord nvarchar(50))
-- Tạo lại bảng tblHang với khóa ngoại liên kết với cột ChatLieu của tblChatlieu
CREATE TABLE tblHang (
    MaHang NVARCHAR(50) PRIMARY KEY,  -- Khóa chính
    TenHang NVARCHAR(50) NOT NULL,
    ChatLieu NVARCHAR(50),  -- Sử dụng cột ChatLieu hiện tại
    SoLuong INT,
    DonGiaNhap FLOAT,
    DonGiaBan FLOAT,
	Anh NText,
    GhiChu NVARCHAR(100)
    --FOREIGN KEY (ChatLieu) REFERENCES tblChatlieu(ChatLieu)  -- Khóa ngoại liên kết với cột ChatLieu của tblChatlieu
);

-- Tạo bảng tblChatlieu
CREATE TABLE tblChatlieu (
    MaChatlieu NVARCHAR(10) PRIMARY KEY,  -- Khóa chính cho bảng tblChatlieu
    ChatLieu NVARCHAR(50) UNIQUE NOT NULL  -- Cột ChatLieu phải là duy nhất để đảm bảo tính toàn vẹn dữ liệu
);

-- Thêm dữ liệu vào bảng tblHang
INSERT INTO tblHang (MaHang, TenHang, ChatLieu, SoLuong, DonGiaNhap, DonGiaBan, Anh, GhiChu) VALUES
('MH001', N'Sản phẩm A', N'Vàng', 100, 20000, 30000, N'H01.jpg', N'Chất lượng tốt'),
('MH002', N'Sản phẩm B', N'Bông', 200, 15000, 25000, N'H02.jpg', N'Chất liệu tự nhiên'),
('MH003', N'Sản phẩm C', N'Mây', 150, 12000, 22000, N'H03.jpg', N'Sản phẩm thân thiện với môi trường'),
('MH004', N'Sản phẩm D', N'Tre', 80, 18000, 28000, N'H04.jpg', N'Sản phẩm bền bỉ'),
('MH005', N'Sản phẩm E', N'Tổng hợp', 60, 25000, 35000, N'Gio5.jpg', N'Chất liệu tổng hợp cao cấp');



