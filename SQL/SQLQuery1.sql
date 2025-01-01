exec sp_addlogin MQ, 1234
use BT1CSDL
--cap quyen
exec sp_adduser  MQ,  MQuser

--nhom quyen

--phan quyen


exec sp_addlogin A, 123
exec sp_addlogin B, 123
use BT1CSDL
exec sp_adduser A, Aer
exec sp_adduser B, Ber

grant select, update on tKhachHang to Aer with grant option




exec sp_addlogin C, 123
exec sp_addlogin D, 123
exec sp_addlogin E, 123
use BT1CSDL
exec sp_adduser C, Cer
exec sp_adduser D, Der
exec sp_adduser E, Eer
grant select, update on tNhaCungCap to Cer with grant option

drop login C