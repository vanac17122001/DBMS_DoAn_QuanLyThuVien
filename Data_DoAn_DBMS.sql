--Tạo bảng
create database Database_DBMS
go
use Database_DBMS
go
create table NhanVien (
	idNhanVien int ,
	Ho nvarchar (10) not null,
	Ten nvarchar (20) not null,
	ngaySinh date not null,
	gioiTinh nvarchar (10) not null,
	CMND varchar (20) not null,
	diaChi nvarchar (30),
	soDT varchar (15),
	Email varchar (30),
	ngayBatDau date,
	CONSTRAINT pk_nhanvien PRIMARY KEY ( idNhanVien)
);
create table TacGia (
	idTacGia int,
	butDanh nvarchar (20),
	CONSTRAINT pk_TacGia PRIMARY KEY (idTacGia)
);

create table TheThuVien (
	soThe int,
	ngayLap date not null,
	hanSuDung date,
	CONSTRAINT pk_thethuvien PRIMARY KEY (soThe)
);
create table TaiKhoan (
	id int,
	userName varchar (20) not null,
	pass varchar (20) not null,
	Loai bit not null,
	CONSTRAINT pk_taikhoan PRIMARY KEY (id)
);
create table TheLoaiSach(
	idTheLoai int,
	Ten nvarchar (20) not null,
	CONSTRAINT pk_theloaisach PRIMARY KEY (idTheLoai)
);
create table NhaXuatBan (
	idNXB int,
	Ten nvarchar (20) not null,
	SoDT varchar (15),
	diaChi nvarchar (30) not null,
	Email varchar (30),
	Website varchar (40),
	CONSTRAINT pk_nhaxuatban PRIMARY KEY (idNXB)
);
create table DocGia (
	idDocGia int,
	Ho nvarchar (10) not null,
	Ten nvarchar (10) not null,
	ngaySinh date not null,
	gioiTinh nvarchar (10) not null,
	CMND varchar (20) not null,
	diaChi nvarchar (30),
	soDT varchar (15),
	Email varchar (30),
	ngayDK date not null,
	soThe int ,
	CONSTRAINT pk_docgia PRIMARY KEY (idDocGia),
	CONSTRAINT fk_sothe FOREIGN KEY (soThe) REFERENCES TheThuVien(sothe)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
create table DauSach (
	idDauSach int,
	tenSach nvarchar (20) not null,
	idNXB int,
	namXB date,
	idTheLoai int ,
	Gia int,
	soLuongMuon int,
	soLuong int,
	idTacGia int,
	CONSTRAINT pk_dausach PRIMARY KEY (idDauSach),
	CONSTRAINT fk_idnxb FOREIGN KEY (idNXB) REFERENCES NhaXuatBan (idNXB),
	CONSTRAINT fk_idthelaoi FOREIGN KEY (idTheLoai) REFERENCES TheLoaiSach (idTheLoai),
	CONSTRAINT fk_idtacgia FOREIGN KEY (idTacGia) REFERENCES TacGia (idTacGia)
	ON UPDATE CASCADE
);
create table Sach (
	idSach int,
	idDauSach int,
	trangThai nvarchar (20),
	CONSTRAINT pk_sach PRIMARY KEY (idSach),
	CONSTRAINT fk_iddausach FOREIGN KEY (idDauSach) REFERENCES DauSach (idDauSach)
	ON DELETE CASCADE
); 


create table MuonSach (
	idMuon int,
	idSach int,
	soThe int,
	idNhanVien int ,
	ngayMuon date not null,
	CONSTRAINT pk_muonsach PRIMARY KEY (idMuon),
	CONSTRAINT fk_idsach FOREIGN KEY (idSach) REFERENCES Sach (idSach),
	CONSTRAINT fk_sothe_muonsach FOREIGN KEY (soThe) REFERENCES TheThuVien (soThe),
	CONSTRAINT fk_nhavien FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
create table TraSach(
	idTraSach int,
	idMuon int,
	ngayTra date not null,
	idNhanVien int,
	CONSTRAINT pk_ PRIMARY KEY (idTraSach),
	CONSTRAINT fk_muon FOREIGN KEY (idMuon) REFERENCES MuonSach (idMuon),
	CONSTRAINT fk_nhavien_trasach FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

-- Thêm dữ liệu 
use Database_DBMS
go
insert into NhanVien values
(001,N'Trần',N'Văn Duy','2001-1-1',N'Nam','215530901',N'Hoài Nhơn - Bình Định','0814233577','tranvanduy@gmail.com','2021-1-1'),
(002,N'Trần',N'Văn Hào','2001-2-1',N'Nam','215530701',N'Hoài Nhơn - Bình Phước','0814233555','caovanhao@gmail.com','2021-2-1'),
(003,N'Trần',N'Trường','2001-3-1',N'Nam','215530801',N'Tây Sơn - Bình Định','0765233577','trancongtruong@gmail.com','2021-1-15'),
(004,N'Cao',N'Anh Văn','2001-1-5',N'Nam','215530221',N'Tây Sơn - Bình Định','0814563577','caoanhvan@gmail.com','2021-6-1'),
(005,N'Lê',N'Phương Nam','2001-10-1',N'Nam','215531221',N'Biên Hòa - Đồng Nai','0814238767','lephuongnam@gmail.com','2021-1-7'),
(006,N'Nguyễn',N'Ngọc Hân','2001-12-22',N'Nữ','215530156',N'Thủ Đức - TP.HCM','0925233577','nguyenngochan@gmail.com','2021-11-1');
go
insert into TacGia values
(0001,N'Nam Cao'),
(0002,N'Nam Thành'),
(0003,N'Xuân Diệu'),
(0004,N'Hồ Xuân Hương'),
(0005,N'Huy Cận'),
(0006,N'Tản Đà');
go
insert into TheThuVien values
(1,'2021-10-1','2022-10-1'),
(2,'2021-11-1','2022-11-1'),
(3,'2021-12-1','2022-12-1'),
(4,'2021-10-15','2022-10-15'),
(5,'2021-10-12','2022-10-12'),
(6,'2021-6-22','2022-6-22');
go
insert into TaiKhoan values
(1,'user','1',0),
(2,'emoloyee','1',1);
go 
insert into TheLoaiSach values
(111,N'Giáo khoa'),
(112,N'Hướng dẫn'),
(113,N'Bài tập'),
(114,N'Khoa học'),
(115,N'Văn học');
go
insert into NhaXuatBan values
(1111,N'NXB Kim Đồng','0913672405',N'Ba Đình-Hà Nội','nxbkimdong@gmail.com','www.nxbkimdong.vn'),
(1112,N'NXB Giáo dục','0913222415',N'Ba Đình-Hà Nội','nxbkimdong@gmail.com','www.nxbkimdong.vn'),
(1113,N'NXB Tuổi trẻ','0873672419',N'Q1-TP.HCM','nxbkimdong@gmail.com','www.nxbkimdong.vn'),
(1114,N'NXB ĐHQG','0913876405',N'Thủ Đức-TP.HCM','nxbkimdong@gmail.com','www.nxbkimdong.vn'),
(1115,N'NXB TPHCM','09136724222',N'Q1-TP.HCM','nxbkimdong@gmail.com','www.nxbkimdong.vn');
go
insert into DocGia values
(101,N'Trần',N'Ngọc Chiến','1999-2-1',N'Nam','223550924',N'Linh Trung-Thủ Đức','0987122947','ngochien@gmail.com','2019-1-1',1),
(102,N'Trần',N'Ngọc Như','1998-1-3',N'Nữ','223340087',N'Linh Xuân-Thủ Đức','0987122941','ngocnhu@gmail.com','2019-1-1',2),
(103,N'Nguyễn',N'Văn Toàn','1999-4-1',N'Nam','223340123',N'Kha Vạn Cân-Thủ Đức','0987122981','vantoang@gmail.com','2019-3-1',3),
(104,N'Trần',N'Quốc Quân','2001-5-1',N'Nam','223340345',N'Dĩ An-Bình Dương','0987155541','quocquann@gmail.com','2019-11-1',4),
(105,N'Cao',N'Hông Hoa','2002-11-1',N'Nữ','223340678',N'Hiệp Bình Chánh-Thủ Đức','0987122149','honghoa@gmail.com','2019-1-20',5),
(106,N'Lưu',N'Quốc Dũng','2002-10-1',N'Nam','223342134',N'Hoàng Diệu 2-Thủ Đức','0996522941','quocdung@gmail.com','2019-5-6',6);
go
insert into DauSach values
(12345,N'Kỹ thuật lập trình',1111,'2005-1-1',111,50000,30,100,0001),
(12346,N'Kỹ thuật điện',1112,'2005-2-1',111,50000,20,100,0002),
(12347,N'Kỹ thuật cơ khí',1113,'2005-3-1',111,50000,10,100,0003),
(12348,N'Lão Hạc',1114,'2015-1-19',115,70000,5,100,0004),
(12349,N'Tắt đèn',1114,'2015-10-1',115,70000,22,100,0005),
(12350,N'Bài tập lập trình',1114,'2015-10-1',113,25000,70,110,0005),
(12351,N'Bài tập vật lý 1',1111,'2012-1-11',113,25000,80,100,0006),
(12352,N'Khoa học vũ trụ',1112,'2016-1-12',114,100000,31,90,0001),
(12353,N'Thế giới động vật',1112,'2011-1-13',114,100000,2,50,0003);
go
insert into Sach values
(99001,12345,N'Đã mượn'),
(99002,12345,N'Chưa mượn'),
(99003,12345,N'Đã mượn'),
(99004,12345,N'Chưa mượn'),
(99005,12345,N'Đã mượn'),
(99006,12346,N'Chưa mượn'),
(99007,12346,N'Chưa mượn'),
(99008,12346,N'Đã mượn'),
(99009,12347,N'Chưa mượn'),
(99010,12347,N'Đã mượn'),
(99011,12348,N'Đã mượn'),
(99012,12348,N'Đã mượn');
go
insert into MuonSach values
(01,99001,1,001,'2020-2-1'),
(02,99012,1,001,'2020-3-13'),
(03,99003,2,001,'2020-4-13'),
(04,99011,3,001,'2020-5-11'),
(05,99005,2,002,'2020-11-12'),
(06,99010,2,002,'2020-3-19'),
(07,99008,3,002,'2020-6-5');
go
insert into TraSach values
(221,01,'2021-1-1',005),
(222,03,'2020-11-29',004),
(223,05,'2020-12-1',004),
(224,06,'2020-12-5',004),
(225,07,'2021-1-5',001);

-- Trigger 
use Database_DBMS
go

--tạo triiger cập nhật lại số lượng sách khi sách được mượn--

create trigger trig_InsertMuonSach on MuonSach 
	after insert
	as
		begin
			--Tăng số lượng sách đã mượn lên 1 đơn vị
			update DauSach 
			set soLuongMuon=soLuongMuon+1
			where idDauSach=(select Sach.idDauSach
							from Inserted inner join Sach on Inserted.idSach=Sach.idSach)
			--Update trạng thái của sách được mượn thành đã mượn
			update Sach
			set trangThai=N'Đã mượn'
			where Sach.idSach=(SELECT TOP (1) Inserted.idSach FROM Inserted)
		end
go

--tạo triiger cập nhật lại số lượng sách khi sách được trả--
create trigger trig_InsertTraSach on TraSach 
	after insert
	as
		begin
		--Giảm số lượng sách đã mượn xuống 1 đơn vị
			update DauSach 
			set soLuongMuon=soLuongMuon-1
			where idDauSach=(select idDauSach from 
							(
								Inserted inner join MuonSach on Inserted.idMuon=MuonSach.idMuon 
									inner join Sach on MuonSach.idSach=Sach.idSach
							))
			--Update trạng thái của sách được mượn thành chưa mượn
			update Sach
			set trangThai=N'Chưa mượn'
			where Sach.idSach=(select idSach
								from Inserted inner join MuonSach on Inserted.idMuon=MuonSach.idMuon)				
		end
go



--Kiểm tra số lượng sách khi thêm, sửa một đầu sách phải >0--
create trigger trig_InsertDauSach on DauSach
after insert, update
as
	begin 
		declare @soluong as int 
		select @soluong=inserted.soLuong from inserted
		if (@soluong<0)
			begin
				print(N'Số lượng phải >0')
				rollback transaction
			end
	end
go

--Kiểm tra hạn dùng của thẻ thư viện phải lớn hơn ngày lập--
create trigger trig_CheckDateTheThuVien on TheThuVien
for insert, update 
as
	begin
		DECLARE @ngaylap DATE, @hanSuDung DATE
		SET @ngaylap=(SELECT ngayLap FROM inserted)
		SET @hanSuDung=(SELECT hanSuDung FROM inserted)
		IF(@hanSuDung<=@ngaylap)
		begin
			print(N'Hạn dùng phải sau ngày đăng ký')
			ROLLBACK TRAN
		end
	end
go

--Tạo thẻ thư viện và tài khoản cho độc giả mới được tạo--

--View
USE Database_DBMS
go
-- Tạo view xem thông tin của sách
CREATE VIEW InforOfBook as
select DauSach.tenSach as 'Tên sách', TacGia.butDanh as 'Tác giả', TheLoaiSach.Ten as 'Thể loại', 
	   NhaXuatBan.Ten as 'NXB', DauSach.Gia as 'Giá', DauSach.soLuong as'Số lượng'
from DauSach,TacGia,NhaXuatBan,TheLoaiSach
where DauSach.idNXB=NhaXuatBan.idNXB and
	  DauSach.idTacGia=TacGia.idTacGia and
	  DauSach.idTheLoai = TheLoaiSach.idTheLoai
go
-- Tạo view tìm kiếm sách
create view SearchBook as
select DauSach.tenSach as 'Tên sách', DauSach.Gia as 'Giá', DauSach.soLuongMuon as'Số lượng sách đã được mượn'
from DauSach
go
-- Tạo view báo cáo tình trạng mượn trả sách
create view Report as
select MuonSach.soThe, MuonSach.ngayMuon, TraSach.ngayTra
from MuonSach, TraSach,TheThuVien, NhanVien
where MuonSach.soThe=TheThuVien.soThe and
	  MuonSach.idMuon = TraSach.idMuon and
	  MuonSach.idNhanVien = NhanVien.idNhanVien
go

