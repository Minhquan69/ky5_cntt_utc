CREATE DATABASE BanHang;
USE BanHang;

CREATE TABLE tblMatHang (
    MaSP NCHAR(10) PRIMARY KEY,
    TenSP NVARCHAR(30) NOT NULL,
    NgaySX DATE NOT NULL,
    NgayHH DATE NOT NULL,
    DonVi NVARCHAR(10),
    DonGia FLOAT CHECK (DonGia >= 0),
    GhiChu NVARCHAR(200)
);
insert into tblMatHang VALUES ('SP00001', N'Bàn phím Dell', '2015-01-03', '2018-08-15', 'Chiếc', 50000, 'khong');
insert into tblMatHang VALUES ('SP00002', N'Chuột không dây', '2018-01-03', '2021-08-15', 'Cái', 200000, 'khong');
insert into tblMatHang VALUES ('SP00003', N'Bàn phím Logitech', '2017-12-25', '2023-01-10', 'Cái', 30000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00004', N'Logitech M185', '2020-01-15', '2024-10-11', 'Cái', 150000, 'wireless mouse');
INSERT INTO tblMatHang VALUES ('SP00005', N'Màn hình Dell', '2019-02-12', '2024-03-01', 'Chiếc', 3000000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00006', N'Bàn di chuột', '2016-05-10', '2022-07-14', 'Cái', 100000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00007', N'Loa Bluetooth', '2020-10-25', '2024-05-23', 'Chiếc', 500000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00008', N'Tai nghe Sony', '2019-06-18', '2024-06-30', 'Cái', 700000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00009', N'Sạc dự phòng', '2021-04-05', '2023-09-01', 'Chiếc', 400000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00010', N'Webcam Logitech', '2017-11-10', '2024-01-15', 'Cái', 800000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00011', N'Ổ cứng di động', '2018-09-22', '2022-12-01', 'Chiếc', 1200000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00012', N'Bộ nhớ RAM', '2021-01-12', '2023-11-11', 'Thanh', 1500000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00013', N'Tay cầm chơi game', '2019-07-15', '2023-08-08', 'Cái', 600000, 'khong');
INSERT INTO tblMatHang VALUES ('SP00014', N'Bàn phím cơ Razer', '2020-03-03', '2024-09-30', 'Cái', 2500000, 'khong');
