﻿--DDL trigger Sử dung CSDL quản lý điểm trường đại học
--Tạo một bảng theo dõi các sự kiện và taọ DDL trigger cập nhật bảng theo các yêu cầu sau:
--1.	Theo dõi việc tạo bảng mới: Ghi lại thông tin khi một bảng mới được tạo trong cơ sở dữ liệu.
--2.	Theo dõi việc xóa bảng: Ghi log khi một bảng bị xóa khỏi cơ sở dữ liệu.
--3.	Theo dõi việc sửa đổi bảng (CREATE, ALTER, DROP TABLE): Ghi lại các thay đổi cấu trúc của bảng như thêm, sửa, hoặc xóa cột.
--4.	Theo dõi việc tạo view (CREATE, ALTER, DROP VIEW): Ghi lại khi một view mới được tạo, được sửa, xóa trong cơ sở dữ liệu.
--5.	Theo dõi việc tạo trigger mới (CREATE, ALTER, DROP TRIGGER): Ghi lại khi một trigger mới được tạo, được sửa, xóa trong hệ thống.
--6.	Theo dõi việc cấp quyền (GRANT): Ghi lại khi quyền được cấp cho người dùng hoặc vai trò.
--7.	Theo dõi việc thu hồi quyền (REVOKE): Ghi lại khi quyền bị thu hồi từ người dùng hoặc vai trò.
--8.	Không cho phép xóa bảng SinhVien
