CREATE DATABASE QLCONGTYXEKHACH
-----------------------------------
USE QLCONGTYXEKHACH
------------------------------------
CREATE TABLE BENXE(
    MABENXE INT IDENTITY (1,1) CONSTRAINT PK_BENXE PRIMARY KEY ,
    TENBENXE NVARCHAR(100) NOT NULL CONSTRAINT UNQ_TENBENXE UNIQUE,
	DIACHI NVARCHAR(255) NOT NULL,
	HOTLINE VARCHAR(15) NULL
)
CREATE TABLE TUYEN(
	MATUYEN INT IDENTITY (1,1) CONSTRAINT PK_TUYEN PRIMARY KEY ,
	BENDAU INT NOT NULL CONSTRAINT FK_BD FOREIGN KEY REFERENCES BENXE(MABENXE) ON DELETE NO ACTION ON UPDATE NO ACTION,
	BENCUOI INT NOT NULL CONSTRAINT FK_BC FOREIGN KEY REFERENCES BENXE(MABENXE) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT UNIQUE_BENDAUBENCUOI UNIQUE(BENDAU,BENCUOI),
	CONSTRAINT CHK_BENDAUBENCUOI CHECK(BENDAU<>BENCUOI),
	QUANGDUONG INT CONSTRAINT CHK_QD CHECK (QUANGDUONG>0) NULL,
	THOIGIANDUKIEN INT CONSTRAINT CHK_TG CHECK (THOIGIANDUKIEN>0) NULL
)
CREATE TABLE KHUNGGIO(
	GIO TIME CONSTRAINT PK_KHUNGGIO PRIMARY KEY
)
CREATE TABLE LOAIVE(
	MALOAIVE INT IDENTITY (1,1) CONSTRAINT PK_LOAIVE PRIMARY KEY ,
	TENLOAIVE NVARCHAR(100) NOT NULL UNIQUE
)
CREATE TABLE XE(
    MAXE INT IDENTITY (1,1) CONSTRAINT PK_XE PRIMARY KEY ,
    BIENSOXE VARCHAR(20) NOT NULL UNIQUE,
	SOCHO INT NOT NULL CHECK (SOCHO>0),
	MALOAIVE INT NOT NULL 
	CONSTRAINT FK_XE_LOAIVE FOREIGN KEY REFERENCES LOAIVE(MALOAIVE) ON DELETE NO ACTION ON UPDATE NO ACTION
)
CREATE TABLE CHUCVU(
	MACHUCVU INT IDENTITY (1,1) CONSTRAINT PK_CHUCVU PRIMARY KEY ,
	TENCHUCVU NVARCHAR(100) NOT NULL UNIQUE
)
CREATE TABLE NHANVIEN(
	MANHANVIEN INT IDENTITY (1,1) CONSTRAINT PK_NHANVIEN PRIMARY KEY,
	MACHUCVU INT NOT NULL CONSTRAINT FK_NHANVIEN_MACHUCVU FOREIGN KEY REFERENCES CHUCVU(MACHUCVU) ON DELETE NO ACTION ON UPDATE CASCADE,
	HOTEN NVARCHAR(100) NOT NULL,
	NGAYSINH DATE NULL,
	DIACHI NVARCHAR(255) NULL,
	DIENTHOAI VARCHAR(15) NULL,
	GIAYPHEPLAIXE NVARCHAR(25)NULL
)
CREATE  TABLE TAIKHOAN(
	MATAIKHOAN INT IDENTITY (1,1) CONSTRAINT PK_TAIKHOAN PRIMARY KEY,
	TENDANGNHAP VARCHAR(100) NOT NULL UNIQUE,
	MATKHAU VARCHAR(100) NOT NULL,
	MANHANVIEN INT NULL CONSTRAINT FK_TAIKHOAN_NHANVIEN FOREIGN KEY REFERENCES NHANVIEN(MANHANVIEN) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT UNIQ_TAIKHOAN_NHANVIEN UNIQUE(MANHANVIEN)
)

CREATE TABLE NHOMQUYEN(
	MANHOMQUYEN INT CONSTRAINT PK_NHOMQUYEN PRIMARY KEY,
	TENNHOMQUYEN NVARCHAR(100) NOT NULL UNIQUE,
	MOTA NVARCHAR(500) NULL,
)
CREATE  TABLE TK_NQ(
	MATAIKHOAN INT NOT NULL
	CONSTRAINT PK_TK_NQ PRIMARY KEY
	CONSTRAINT FK_TKNQ_TK FOREIGN KEY REFERENCES TAIKHOAN(MATAIKHOAN) ON DELETE CASCADE ON UPDATE CASCADE,
	MANHOMQUYEN INT NOT NULL 
	CONSTRAINT FK_TKNQ_NQ FOREIGN KEY REFERENCES NHOMQUYEN(MANHOMQUYEN) ON DELETE CASCADE ON UPDATE CASCADE
)
CREATE TABLE KHACH(
	MAKHACH INT IDENTITY (1,1) CONSTRAINT PK_KHACH PRIMARY KEY,
	HOTEN NVARCHAR(100) NOT NULL,
	DIENTHOAI VARCHAR(15) NOT NULL CONSTRAINT UNQ_DTKHACH UNIQUE,
	DIACHI NVARCHAR(255) NULL,
)
CREATE  TABLE CHUYENXE(
	MACHUYENXE INT IDENTITY (1,1) CONSTRAINT PK_CHUYEN PRIMARY KEY ,
	MATUYEN INT NOT NULL CONSTRAINT FK_CHUYEN_TUYEN FOREIGN KEY REFERENCES TUYEN(MATUYEN) ON DELETE NO ACTION  ON UPDATE NO ACTION,
	NGAYDI DATE NOT NULL,
	GIOXUATBEN TIME NOT NULL CONSTRAINT FK_CHUYEN_KHUNGGIO FOREIGN KEY REFERENCES KHUNGGIO(GIO) ON DELETE NO ACTION ON UPDATE CASCADE,
	MALOAIVE INT NOT NULL CONSTRAINT FK_CHUYEN_LOAIVE FOREIGN KEY REFERENCES LOAIVE(MALOAIVE) ON DELETE NO ACTION ON UPDATE CASCADE,
	MAXE INT NOT NULL CONSTRAINT FK_CHUYEN_XE FOREIGN KEY REFERENCES XE(MAXE) ON DELETE NO ACTION ON UPDATE CASCADE,
	MATAIXE INT NOT NULL CONSTRAINT FK_CHUYEN_NHANVIEN FOREIGN KEY REFERENCES NHANVIEN(MANHANVIEN) ON DELETE NO ACTION ON UPDATE CASCADE
)
CREATE TABLE BANGGIA(
	MATUYEN INT NOT NULL CONSTRAINT FK_BANGGIA_TUYEN FOREIGN KEY REFERENCES TUYEN(MATUYEN) ON DELETE NO ACTION  ON UPDATE NO ACTION,
	MALOAIVE INT NOT NULL CONSTRAINT FK_BIANGGIA_LOAIVE FOREIGN KEY REFERENCES LOAIVE(MALOAIVE) ON DELETE NO ACTION ON UPDATE CASCADE,
	SOTIEN INT NOT NULL CONSTRAINT CHK_GIAVE CHECK(SOTIEN>0),
	CONSTRAINT PK_BANGGIA PRIMARY KEY(MATUYEN,MALOAIVE)
)
CREATE  TABLE PHIEUDATVE(
	MAPHIEUDATVE INT IDENTITY (1,1) CONSTRAINT PK_PHIEUDATVE PRIMARY KEY ,
	NGAYDAT DATETIME NOT NULL,
	MAKHACH INT NOT NULL CONSTRAINT FK_DATVE_KHACH FOREIGN KEY REFERENCES KHACH(MAKHACH) ON DELETE CASCADE  ON UPDATE CASCADE,
	MACHUYEN INT NOT NULL CONSTRAINT FK_DATVE_CHUYENXE FOREIGN KEY REFERENCES CHUYENXE(MACHUYENXE) ON DELETE CASCADE  ON UPDATE CASCADE
	CONSTRAINT UNIQDATVE_KHACH_CHUYEN  UNIQUE(MAKHACH,MACHUYEN)
)
CREATE  TABLE CHITIETDATVE(
	MAPHIEUDATVE INT NOT NULL CONSTRAINT FK_CTDATVE_DATVE FOREIGN KEY REFERENCES PHIEUDATVE(MAPHIEUDATVE) ON DELETE CASCADE  ON UPDATE CASCADE,
	SOGHE VARCHAR(5) NOT NULL,
	CONSTRAINT PK_CHITIETDATVE PRIMARY KEY(MAPHIEUDATVE,SOGHE)
)
--------------------------------------------
insert into CHUCVU(TENCHUCVU) values (N'TÀI XẾ')
insert into CHUCVU(TENCHUCVU) values (N'LỄ TÂN')
insert into CHUCVU(TENCHUCVU) values (N'KẾ TOÁN')
insert into CHUCVU(TENCHUCVU) values (N'NHÂN SỰ')
insert into CHUCVU(TENCHUCVU) values (N'QUẢN LÝ')
-----------------------------------------------
SET DATEFORMAT DMY
insert into NHANVIEN(MACHUCVU, HOTEN,NGAYSINH, DIACHI, DIENTHOAI) values (5,N'LÊ BÁ QUÁT','1/2/1980',N'QUẬN 1','0987625378')
insert into NHANVIEN(MACHUCVU, HOTEN,NGAYSINH, DIACHI, DIENTHOAI) values (1,N'NGUYỄN VĂN TÀI',N'22/1/1991',N'QUẬN 12','0936745388')
insert into NHANVIEN(MACHUCVU, HOTEN,NGAYSINH, DIACHI, DIENTHOAI) values (1,N'CAO PHI TÀI','21/12/1975',NULL,'0913456457')
insert into NHANVIEN(MACHUCVU, HOTEN,NGAYSINH, DIACHI, DIENTHOAI) values (1,N'MAI GIA TÀI','5/6/1989',N'QUẬN 9','0833208889')
insert into NHANVIEN(MACHUCVU, HOTEN,NGAYSINH, DIACHI, DIENTHOAI) values (2,N'HỒ NGỌC HÀ','30/5/2000',N'QUẬN 7', NULL)
insert into NHANVIEN(MACHUCVU, HOTEN,NGAYSINH, DIACHI, DIENTHOAI) values (4,N'NGUYỄN VĂN CÔNG LÝ',NULL,N'QUẬN 5','0356145155')
----------------------------------------------
INSERT INTO NHOMQUYEN VALUES(1,N'KẾ TOÁN',N'XEM DOANH THU')
INSERT INTO NHOMQUYEN VALUES(2,N'ALL',N'TOÀN QUYỀN')
INSERT INTO NHOMQUYEN VALUES(3,N'NHÂN SỰ',NULL)
INSERT INTO NHOMQUYEN VALUES(4,N'LỄ TÂN',NULL)
INSERT INTO NHOMQUYEN VALUES(5,N'TÀI XẾ',NULL)
INSERT INTO NHOMQUYEN VALUES(6,N'QUẢN LÝ CHUYẾN ĐI',NULL)

----------------------------------------------
INSERT INTO TAIKHOAN(TENDANGNHAP,MATKHAU,MANHANVIEN) VALUES('ADMIN','ADMIN123',NULL)
INSERT INTO TAIKHOAN(TENDANGNHAP,MATKHAU,MANHANVIEN) VALUES('TAICUTE','888888',2)
INSERT INTO TAIKHOAN(TENDANGNHAP,MATKHAU,MANHANVIEN) VALUES('CAOPHITAI','CAOPHITAI',3)
INSERT INTO TAIKHOAN(TENDANGNHAP,MATKHAU,MANHANVIEN) VALUES('CHUTAIXE','XXX',4)
INSERT INTO TAIKHOAN(TENDANGNHAP,MATKHAU,MANHANVIEN) VALUES('HNH','30052000',5)
INSERT INTO TAIKHOAN(TENDANGNHAP,MATKHAU,MANHANVIEN) VALUES('CONGLY','HIHIHIHI',6)
INSERT INTO TAIKHOAN(TENDANGNHAP,MATKHAU,MANHANVIEN) VALUES('ABC','XYZ',1)
--------------------------------------------------
INSERT INTO TK_NQ(MATAIKHOAN,MANHOMQUYEN) VALUES(1,2)
INSERT INTO TK_NQ(MATAIKHOAN,MANHOMQUYEN) VALUES(2,5)
INSERT INTO TK_NQ(MATAIKHOAN,MANHOMQUYEN) VALUES(3,5)
INSERT INTO TK_NQ(MATAIKHOAN,MANHOMQUYEN) VALUES(4,5)
INSERT INTO TK_NQ(MATAIKHOAN,MANHOMQUYEN) VALUES(5,4)
INSERT INTO TK_NQ(MATAIKHOAN,MANHOMQUYEN) VALUES(6,3)
INSERT INTO TK_NQ(MATAIKHOAN,MANHOMQUYEN) VALUES(7,6)
------------------------------------------------------
insert into LOAIVE(TENLOAIVE) values (N'GHẾ NGỒI')
insert into LOAIVE(TENLOAIVE) values (N'GHẾ NẰM')
insert into LOAIVE(TENLOAIVE) values (N'GIƯỜNG NẰM')
insert into LOAIVE(TENLOAIVE) values (N'PHÒNG')
-------------------------------------------------------
insert into BENXE(TENBENXE,DIACHI,HOTLINE) values (N'CÁI NƯỚC', N'KHÓM 1, TT.CÁI NƯỚC, H.CÁI NƯỚC, TỈNH CÀ MAU','0944394989')
insert into BENXE(TENBENXE,DIACHI,HOTLINE) values (N'CÀ MAU', N'10 NGUYỄN DU, P5, TP.CÀ MAU','0919717446')
insert into BENXE(TENBENXE,DIACHI,HOTLINE) values (N'TP.HCM', N'ÂU DƯƠNG LÂN, P3, Q8, TP.HCM','0835238239')
--------------------------------------------------------
INSERT INTO TUYEN(BENDAU,BENCUOI,QUANGDUONG,THOIGIANDUKIEN) VALUES(1,3,330,8*60+30)
INSERT INTO BANGGIA(MATUYEN,MALOAIVE,SOTIEN) VALUES (1,1,80000)
INSERT INTO BANGGIA(MATUYEN,MALOAIVE,SOTIEN) VALUES (1,2,125000)
INSERT INTO BANGGIA(MATUYEN,MALOAIVE,SOTIEN) VALUES (1,3,200000)
INSERT INTO BANGGIA(MATUYEN,MALOAIVE,SOTIEN) VALUES (1,4,220000)

INSERT INTO TUYEN(BENDAU,BENCUOI,QUANGDUONG,THOIGIANDUKIEN) VALUES(3,1,330,8*60+30)
INSERT INTO BANGGIA(MATUYEN,MALOAIVE,SOTIEN) VALUES (2,1,80000)
INSERT INTO BANGGIA(MATUYEN,MALOAIVE,SOTIEN) VALUES (2,2,120000)
INSERT INTO BANGGIA(MATUYEN,MALOAIVE,SOTIEN) VALUES (2,3,195000)
INSERT INTO BANGGIA(MATUYEN,MALOAIVE,SOTIEN) VALUES (2,4,220000)

-------------------------------------------------------------------------------------------
INSERT INTO KHACH(HOTEN, DIENTHOAI, DIACHI) VALUES(N'THẢO','0835238239',N'45/19 ÂU DƯƠNG LÂN, P3 Q8')
INSERT INTO KHACH(HOTEN, DIENTHOAI, DIACHI) VALUES(N'VY','0941394989',N'ĐƯỜNG 30 THÁNG 4, KHÓM 1, TT.CÁI NƯỚC')
INSERT INTO KHACH(HOTEN, DIENTHOAI, DIACHI) VALUES(N'VŨ','0919008073',N'ẤP KINH TƯ, XÃ HÒA MỸ, H.CÁI NƯỚC')
---------------------------------------------------------------------------------------------
INSERT INTO XE(BIENSOXE,MALOAIVE,SOCHO) VALUES('A123',1,45)
INSERT INTO XE(BIENSOXE,MALOAIVE,SOCHO) VALUES('A128',1,45)
INSERT INTO XE(BIENSOXE,MALOAIVE,SOCHO) VALUES('A207',2,45)
INSERT INTO XE(BIENSOXE,MALOAIVE,SOCHO) VALUES('A890',2,45)
INSERT INTO XE(BIENSOXE,MALOAIVE,SOCHO) VALUES('B456',3,36)
INSERT INTO XE(BIENSOXE,MALOAIVE,SOCHO) VALUES('B757',3,36)
INSERT INTO XE(BIENSOXE,MALOAIVE,SOCHO) VALUES('B200',3,36)
INSERT INTO XE(BIENSOXE,MALOAIVE,SOCHO) VALUES('C1',4,24)

-----------------------------------------------------------------
------------------------------------------------------------------
---------------------------------------------------------------
------------------------------------------------------------------
--------------------------------------------------------------------
CREATE VIEW DANGNHAP AS
SELECT TK.TENDANGNHAP,TK.MATKHAU,NQ.MANHOMQUYEN,TENNHOMQUYEN, MANHANVIEN
FROM TAIKHOAN TK,TK_NQ _, NHOMQUYEN NQ 
WHERE _.MATAIKHOAN = TK.MATAIKHOAN AND _.MANHOMQUYEN=NQ.MANHOMQUYEN
--------------------------------------------------------------------------------
--------------------------------------------------------------------
CREATE VIEW  TUYEN_BENXE AS
select MATUYEN, bd.tenbenxe as BENDAU, bc.tenbenxe AS BENCUOI, bd.tenbenxe+' - '+BC.TENBENXE AS TUYEN,
QUANGDUONG,CONVERT (VARCHAR(5),THOIGIANDUKIEN/60)+N' GIỜ '+CONVERT (VARCHAR(2),THOIGIANDUKIEN%60)
+N' PHÚT' AS TGDUKIEN, THOIGIANDUKIEN
from TUYEN T, BENXE BD, BENXE BC  
where T.BENDAU=BD.MABENXE AND T.BENCUOI=BC.MABENXE
-------------------------------------------------------------------------------------
--------------------------------------------------------------------
CREATE VIEW BANGGIA_TUYEN_LOAIVE
AS
SELECT BG.MALOAIVE, TENLOAIVE, BG.MATUYEN, TUYEN, SOTIEN FROM BANGGIA BG, LOAIVE LV, TUYEN_BENXE TBX
WHERE BG.MALOAIVE= LV.MALOAIVE AND TBX.MATUYEN=BG.MATUYEN
--------------------
CREATE VIEW CHUYENXE_DETAILS AS
SELECT MACHUYENXE, TUYEN, TENLOAIVE, NGAYDI, GIOXUATBEN, BIENSOXE, CX.MATAIXE, HOTEN
FROM 
(
(
(
CHUYENXE CX left join TUYEN_BENXE TBX on TBX.MATUYEN=CX.MATUYEN
)left join loaive lv on cx.maloaive=lv.maloaive 
) left join NHANVIEN nv on cx.mataixe=nv.manhanvien
) left join xe on cx.MAXE=xe.MAXE
--------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create view nhanvien_chucvu as
select manhanvien,hoten, tenchucvu, n.machucvu,ngaysinh, diachi, dienthoai 
from nhanvien n, chucvu c 
where n.machucvu=c.machucvu
--------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create view xe_loaive as
select maxe, biensoxe, socho, tenloaive, xe.maloaive 
from xe, loaive lv where xe.maloaive=lv.maloaive
--------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create proc chuyenxe_them @tuyen nvarchar(203), @ngaydi date, @gioxuatben time, @loaive nvarchar(100),@biensoxe nvarchar(100), @mataixe int 
as
begin
declare @matuyen int= (select matuyen from TUYEN_BENXE where TUYEN=@tuyen)
declare @maxe int= (select maxe from XE where BIENSOXE=@biensoxe)
declare @maloaive int= (select maloaive from LOAIVE where TENLOAIVE=@loaive)

insert into CHUYENXE(MATUYEN, NGAYDI, GIOXUATBEN, MALOAIVE,MAXE, MATAIXE) VALUES(@matuyen,@ngaydi, @gioxuatben,@maloaive,@maxe,@mataixe)

end
----------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create proc chuyenxe_SUA @ID INT, @tuyen nvarchar(203), @ngaydi date, @gioxuatben time, @loaive nvarchar(100),@biensoxe nvarchar(100), @mataixe int 
as
begin
declare @matuyen int= (select matuyen from TUYEN_BENXE where TUYEN=@tuyen)
declare @maxe int= (select maxe from XE where BIENSOXE=@biensoxe)
declare @maloaive int= (select maloaive from LOAIVE where TENLOAIVE=@loaive)

UPDATE CHUYENXE SET MATUYEN=@matuyen, NGAYDI=@ngaydi, GIOXUATBEN=@gioxuatben,
MALOAIVE=@maloaive,MAXE=@maxe, MATAIXE=@mataixe
WHERE MACHUYENXE=@ID

end
-----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create view sochodadat as
select  cx.machuyenxe,count(soghe) as dadat ,SOCHO-count(soghe) as concho
from ((chuyenxe cx left join xe on xe.MAXE= cx.MAXE)
left join phieudatve p on P.MACHUYEN=cx.MACHUYENXE)
left join chitietdatve ct on p.maphieudatve=ct.maphieudatve
group by  cx.MACHUYENXE,SOCHO
----------------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create  view chuyen_datve2 as
select c.MACHUYENXE,cast (ngaydi as datetime)+cast (GIOXUATBEN as datetime) as xuatben,
dateadd(minute,THOIGIANDUKIEN,cast (ngaydi as datetime)+cast (GIOXUATBEN as datetime))as den,
concho, T.TUYEN, TENLOAIVE 
from (tuyen_benxe t   join CHUYENXE_DETAILS c on t.tuyen= c.tuyen)
left join sochodadat s on s.machuyenxe=c.MACHUYENXE 
--------------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create view doanhthungay as
select NGAYDI,sum( dadat* SOTIEN) as doanhthungay
from sochodadat s, CHUYENXE cx, BANGGIA bg
where s.machuyenxe=cx.MACHUYENXE and cx.MATUYEN=bg.MATUYEN 
and cx.MALOAIVE=bg.MALOAIVE
group by NGAYDI
------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create view doanhthuthang as
select month(ngaydi) as thang, year(ngaydi) as nam, sum(doanhthungay) as doanhthuthang
from doanhthungay
group by month(ngaydi),  year(ngaydi)
-----------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create function doanhthu (@thang int, @nam int) returns int as
begin
declare @a int =
(select doanhthuthang from doanhthuthang where thang=@thang and nam=@nam)
if(@a is null) return 0
return @a
end
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create view doanhthunam as
select nam, sum(doanhthuthang) as doanhthunam
from doanhthuthang
group by nam
------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------
create view doanhthunamthang as 
select nam,
dbo.doanhthu(1,nam) as thang1,dbo.doanhthu(2,nam) as thang2,dbo.doanhthu(3,nam)as thang3,
dbo.doanhthu(4,nam)as thang4,dbo.doanhthu(5,nam)as thang5,dbo.doanhthu(6,nam)as thang6,
dbo.doanhthu(7,nam)as thang7,dbo.doanhthu(8,nam)as thang8,dbo.doanhthu(9,nam)as thang9,
dbo.doanhthu(10,nam)as thang10,dbo.doanhthu(11,nam)as thang11,dbo.doanhthu(12,nam)as thang12
from doanhthunam
----------------------------------------------------------------------
------------------------------------------------------------------
---------------------------------------------------------------------
create  view doanhthunamthang2 as 
select nam, 

format(thang1, '#,#') as thang1,
format(thang2,'#,#') as thang2,
format(thang3, '#,#') as thang3,
format(thang4, '#,#') as thang4,
format(thang5, '#,#') as thang5,
format(thang6, '#,#') as thang6,
format(thang7, '#,#') as thang7,
format(thang8, '#,#') as thang8,
format(thang9, '#,#') as thang9,
format(thang10, '#,#') as thang10,
format(thang11, '#,#') as thang11,
format(thang12, '#,#') as thang12
from doanhthunamthang