--Tạo bảng
drop database Database_DBMS
go
create database Database_DBMS
go
use Database_DBMS
go
create table NhanVien (
	idNhanVien int IDENTITY(100,1) ,
	ho nvarchar (20) not null,
	ten nvarchar (50) not null,
	ngaySinh date not null,
	gioiTinh nvarchar (5) not null,
	CMND varchar (20) not null,
	diaChi nvarchar (100),
	soDT varchar (15),
	email varchar (50),
	ngayBatDau date,
	anhNV image null,
	CONSTRAINT pk_nhanvien PRIMARY KEY ( idNhanVien)
);
go
create table TacGia (
	idTacGia int IDENTITY(200,1),
	butDanh nvarchar (50),
	CONSTRAINT pk_TacGia PRIMARY KEY (idTacGia)
);
go
create table TheThuVien (
	soThe int IDENTITY(300,1),
	ngayLap date not null,
	hanSuDung date,
	CONSTRAINT pk_thethuvien PRIMARY KEY (soThe)
);
go
create table TaiKhoan (
	id int,
	userName varchar (50) not null,
	pass varchar (20) not null,
	loai varchar(20) not null,
	CONSTRAINT pk_taikhoan PRIMARY KEY (id)
);
go
create table TheLoaiSach(
	idTheLoai int IDENTITY(500,1),
	tenTheLoai nvarchar (50) not null,
	CONSTRAINT pk_theloaisach PRIMARY KEY (idTheLoai)
);
go
create table NhaXuatBan (
	idNXB int IDENTITY(600,1),
	ten nvarchar (50) not null,
	soDT varchar (15),
	diaChi nvarchar (50) not null,
	email varchar (50),
	website varchar (100),
	CONSTRAINT pk_nhaxuatban PRIMARY KEY (idNXB)
);
go
create table DocGia (
	idDocGia int IDENTITY(700,1),
	ho nvarchar (20) not null,
	ten nvarchar (50) not null,
	ngaySinh date not null,
	gioiTinh nvarchar (5) not null,
	CMND varchar (20) not null,
	diaChi nvarchar (50),
	soDT varchar (15),
	email varchar (50),
	ngayDK date not null,
	soThe int ,
	anhDG image null, 
	CONSTRAINT pk_docgia PRIMARY KEY (idDocGia),
	CONSTRAINT fk_sothe FOREIGN KEY (soThe) REFERENCES TheThuVien(soThe)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
go
create table DauSach (
	idDauSach int IDENTITY(800,1),
	tenSach nvarchar (100) not null,
	idNXB int,
	namXB date,
	idTheLoai int ,
	gia int,
	soLuongMuon int,
	soLuong int,
	idTacGia int,
	anhDS image null,
	viTri nvarchar(50),
	CONSTRAINT pk_dausach PRIMARY KEY (idDauSach),
	CONSTRAINT fk_idnxb FOREIGN KEY (idNXB) REFERENCES NhaXuatBan (idNXB),
	CONSTRAINT fk_idthelaoi FOREIGN KEY (idTheLoai) REFERENCES TheLoaiSach (idTheLoai),
	CONSTRAINT fk_idtacgia FOREIGN KEY (idTacGia) REFERENCES TacGia (idTacGia)
	ON UPDATE CASCADE
);
go
create table Sach (
	idSach int IDENTITY(900,1),
	idDauSach int,
	trangThai nvarchar (20),
	CONSTRAINT pk_sach PRIMARY KEY (idSach),
	CONSTRAINT fk_iddausach FOREIGN KEY (idDauSach) REFERENCES DauSach (idDauSach)
	ON DELETE CASCADE
); 
go
create table MuonSach (
	idMuon int IDENTITY(1000,1),
	idSach int,
	soThe int,
	idNhanVien int ,
	ngayMuon date not null,
	hanTra date,
	CONSTRAINT pk_muonsach PRIMARY KEY (idMuon),
	CONSTRAINT fk_idsach FOREIGN KEY (idSach) REFERENCES Sach (idSach),
	CONSTRAINT fk_sothe_muonsach FOREIGN KEY (soThe) REFERENCES TheThuVien (soThe),
	CONSTRAINT fk_nhavien FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

go
create table TraSach(
	idTraSach int IDENTITY(2000,1),
	idMuon int,
	ngayTra date not null,
	idNhanVien int,
	CONSTRAINT pk_ PRIMARY KEY (idTraSach),
	CONSTRAINT fk_muon FOREIGN KEY (idMuon) REFERENCES MuonSach (idMuon),
	CONSTRAINT fk_nhavien_trasach FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);
go
create table PhieuPhat(
	idPhieuPhat int IDENTITY(3000,1),
	idMuon int,
	idTraSach int,
	soNgayQuaHan int,
	ngayLapPhieu date,
	idNhanVien int,
	soTienPhat int,
	CONSTRAINT pk_PhieuPhat PRIMARY KEY (idPhieuPhat),
	CONSTRAINT fk_idMuon FOREIGN KEY (idMuon) REFERENCES MuonSach (idMuon),
	CONSTRAINT fk_idTraSach FOREIGN KEY (idTraSach) REFERENCES TraSach (idTraSach)
		on delete  cascade  on update  cascade,
	CONSTRAINT fk_NhanVienLapPhieuPhat FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien)
);
go
-- Thêm dữ liệu 
use Database_DBMS
go
insert into NhanVien values
(N'Trần',N'Văn Duy','2001-1-1',N'Nam','215530901',N'Hoài Nhơn - Bình Định','0814233577','tranvanduy@gmail.com','2021-1-1',null),
(N'Trần',N'Văn Hào','2001-2-1',N'Nam','215530701',N'Hoài Nhơn - Bình Phước','0814233555','caovanhao@gmail.com','2021-2-1',null),
(N'Trần',N'Trường','2001-3-1',N'Nam','215530801',N'Tây Sơn - Bình Định','0765233577','trancongtruong@gmail.com','2021-1-15',null),
(N'Cao',N'Anh Văn','2001-1-5',N'Nam','215530221',N'Tây Sơn - Bình Định','0814563577','caoanhvan@gmail.com','2021-6-1',null),
(N'Lê',N'Phương Nam','2001-10-1',N'Nam','215531221',N'Biên Hòa - Đồng Nai','0814238767','lephuongnam@gmail.com','2021-1-7',null),
(N'Nguyễn',N'Ngọc Hân','2001-12-22',N'Nữ','215530156',N'Thủ Đức - TP.HCM','0925233577','nguyenngochan@gmail.com','2021-11-1',null);

go
insert into TacGia values
(N'Nam Cao'),
(N'Nam Thành'),
(N'Xuân Diệu'),
(N'Hồ Xuân Hương'),
(N'Huy Cận'),
(N'Tản Đà');
go
insert into TheThuVien values
('2021-10-1','2022-10-1')
insert into TheThuVien values
('2021-11-1','2022-11-1')
insert into TheThuVien values
('2021-12-1','2022-12-1')
insert into TheThuVien values
('2021-10-15','2022-10-15')
insert into TheThuVien values
('2021-10-12','2022-10-12')
insert into TheThuVien values
('2021-6-22','2022-6-22')

go 
insert into TheLoaiSach values
(N'Giáo khoa'),
(N'Hướng dẫn'),
(N'Bài tập'),
(N'Khoa học'),
(N'Văn học');
go
insert into NhaXuatBan values
(N'NXB Kim Đồng','0913672405',N'Ba Đình-Hà Nội','nxbkimdong@gmail.com','www.nxbkimdong.vn'),
(N'NXB Giáo dục','0913222415',N'Ba Đình-Hà Nội','nxbkimdong@gmail.com','www.nxbkimdong.vn'),
(N'NXB Tuổi trẻ','0873672419',N'Q1-TP.HCM','nxbkimdong@gmail.com','www.nxbkimdong.vn'),
(N'NXB ĐHQG','0913876405',N'Thủ Đức-TP.HCM','nxbkimdong@gmail.com','www.nxbkimdong.vn'),
(N'NXB TPHCM','09136724222',N'Q1-TP.HCM','nxbkimdong@gmail.com','www.nxbkimdong.vn');
go
insert into DocGia values
(N'Trần',N'Ngọc Chiến','1999-2-1',N'Nam','223550924',N'Linh Trung-Thủ Đức','0987122947','ngochien@gmail.com','2019-1-1',306,null),
(N'Trần',N'Ngọc Như','1998-1-3',N'Nữ','223340087',N'Linh Xuân-Thủ Đức','0987122941','ngocnhu@gmail.com','2019-1-1',307,null),
(N'Nguyễn',N'Văn Toàn','1999-4-1',N'Nam','223340123',N'Kha Vạn Cân-Thủ Đức','0987122981','vantoang@gmail.com','2019-3-1',308,null),
(N'Trần',N'Quốc Quân','2001-5-1',N'Nam','223340345',N'Dĩ An-Bình Dương','0987155541','quocquann@gmail.com','2019-11-1',309,null),
(N'Cao',N'Hông Hoa','2002-11-1',N'Nữ','223340678',N'Hiệp Bình Chánh-Thủ Đức','0987122149','honghoa@gmail.com','2019-1-20',310,null),
(N'Lưu',N'Quốc Dũng','2002-10-1',N'Nam','223342134',N'Hoàng Diệu 2-Thủ Đức','0996522941','quocdung@gmail.com','2019-5-6',311,null);
go
insert into DauSach values
(N'Kỹ thuật lập trình',600,'2005-1-1',500,50000,30,100,200,null,N'Kệ 1'),
(N'Kỹ thuật điện',601,'2005-2-1',500,50000,20,100,201,null,N'Kệ 2'),
(N'Kỹ thuật cơ khí',602,'2005-3-1',500,50000,10,100,202,null,N'Kệ 1'),
(N'Lão Hạc',603,'2015-1-19',501,70000,5,100,203,null,N'Kệ 1'),
(N'Tắt đèn',604,'2015-10-1',502,70000,22,100,204,null,N'Kệ 2'),
(N'Bài tập lập trình',600,'2015-10-1',503,25000,70,110,205,null,N'Kệ 1'),
(N'Bài tập vật lý 1',601,'2012-1-11',504,25000,80,100,200,null,N'Kệ 3'),
(N'Khoa học vũ trụ',602,'2016-1-12',504,100000,31,90,201,null,N'Kệ 3'),
(N'Thế giới động vật',603,'2011-1-13',502,100000,2,50,202,null,N'Kệ 3');
go
insert into Sach values
(800,N'Đã mượn'),
(800,N'Chưa mượn'),
(800,N'Đã mượn'),
(801,N'Chưa mượn'),
(801,N'Đã mượn'),
(801,N'Chưa mượn'),
(802,N'Chưa mượn'),
(802,N'Đã mượn'),
(802,N'Chưa mượn'),
(803,N'Đã mượn'),
(803,N'Đã mượn'),
(803,N'Đã mượn'),
(804,N'Đã mượn'),
(804,N'Chưa mượn'),
(804,N'Đã mượn'),
(805,N'Chưa mượn'),
(805,N'Đã mượn'),
(805,N'Chưa mượn'),
(806,N'Chưa mượn'),
(806,N'Đã mượn'),
(806,N'Chưa mượn'),
(807,N'Đã mượn'),
(807,N'Đã mượn'),
(807,N'Đã mượn'),
(808,N'Đã mượn'),
(808,N'Đã mượn'),
(808,N'Chưa mượn'),
(808,N'Đã mượn');
go
insert into MuonSach values
(900,306,100,'2020-2-1','2020-04-01')
insert into MuonSach values
(902,306,101,'2020-3-13','2020-05-13')
insert into MuonSach values
(904,306,100,'2020-4-13','2020-05-13')
insert into MuonSach values
(907,307,101,'2020-5-11','2020-8-15')
insert into MuonSach values
(909,308,102,'2020-11-12','2020-12-20')
insert into MuonSach values
(910,309,102,'2020-3-19','2020-07-19')
insert into MuonSach values
(911,310,103,'2020-6-5','2020-07-15')

go
insert into TraSach values
(1008,'2021-1-1',100)
insert into TraSach values
(1009,'2021-11-29',101)
insert into TraSach values
(1010,'2021-12-1',100)
insert into TraSach values
(1011,'2021-12-5',101)
insert into TraSach values
(1012,'2021-1-5',102)
go
-- Trigger 
use Database_DBMS

-- tạo trigger tự insert vào bảng phiếu phạt
create trigger trig_InsertPhieuPhat on PhieuPhat
after insert
as 
begin
	update PhieuPhat
	set idTraSach = (select TraSach.idTraSach 
		from TraSach, inserted where TraSach.idMuon = inserted.idMuon)
	where PhieuPhat.idMuon = (select idmuon from inserted)

	update PhieuPhat
	set soNgayQuaHan = (select a.Tre from (select datediff(day,hanTra,ngayTra) as Tre, MuonSach.idMuon from  MuonSach,TraSach 
		where MuonSach.idMuon=TraSach.idMuon )as a, inserted where a.idMuon = inserted.idMuon)
	where PhieuPhat.idMuon = (select idmuon from inserted)

	update PhieuPhat
	set ngayLapPhieu = (select TraSach.ngayTra 
		from TraSach,inserted where TraSach.idMuon = inserted.idMuon)
	where PhieuPhat.idMuon = (select idmuon from inserted)

	update PhieuPhat
	set soTienPhat = 5000*(select Tre from (select datediff(day,hanTra,ngayTra) as Tre,  MuonSach.idMuon from  MuonSach,TraSach 
		where MuonSach.idMuon=TraSach.idMuon) as a, inserted where a.idMuon = inserted.idMuon )
	where PhieuPhat.idMuon = (select idmuon from inserted)
end

--trigg tự động thêm vào bảng phiếu phạt khi nhập vào bảng trả sách
go
create trigger trig_InserttoPhieuPhat on TraSach
after insert 
as 
begin
	insert into PhieuPhat(idMuon, idNhanVien)
		(select TraSach.idMuon, TraSach.idNhanVien from TraSach, inserted
			where TraSach.idMuon = inserted.idMuon)
end
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

go
--tạo triiger tự tạo tài khoản cho nhân viên
create trigger trig_InsertTaiKhoanNhanVien on NhanVien
	after insert
	as
	begin
		insert into TaiKhoan (id, userName, pass, loai)
			select idNhanVien,email,soDT, 'nhanvien' from inserted
	end
go
--tạo trigger tự tạo tài khoản cho đọc giả
create trigger trig_InsertTaiKhoanDocGia on DocGia
	after insert
	as
	begin
		insert into TaiKhoan (id, userName, pass, loai)
			select idDocGia,email,soDT, 'docgia' from inserted
	end
go

--Tạo thẻ thư viện và tài khoản cho độc giả mới được tạo--

--View
USE Database_DBMS
-- Tạo view xem thông tin của sách
go
create view InforOfBook as
select DauSach.tenSach as 'Tên sách', TacGia.butDanh as 'Tác giả', TheLoaiSach.tenTheLoai as 'Thể loại', 
	   NhaXuatBan.Ten as 'NXB', DauSach.gia as 'Giá', DauSach.soLuong as'Số lượng'
from DauSach,TacGia,NhaXuatBan,TheLoaiSach
where DauSach.idNXB=NhaXuatBan.idNXB and
	  DauSach.idTacGia=TacGia.idTacGia and
	  DauSach.idTheLoai = TheLoaiSach.idTheLoai
go
-- Tạo view tìm kiếm sách( bỏ)
create view SearchBook as
select DauSach.tenSach as 'Tên sách', DauSach.Gia as 'Giá', DauSach.soLuongMuon as'Số lượng sách đã được mượn'
from DauSach
go
-- Tạo view báo cáo tình trạng mượn trả sách( có đổi cái view này)
create view Report as
select MuonSach.soThe, DocGia.Ho, DocGia.Ten,MuonSach.ngayMuon, TraSach.ngayTra
from MuonSach, TraSach,TheThuVien, NhanVien, DocGia
where MuonSach.soThe=TheThuVien.soThe and
	  TheThuVien.soThe=DocGia.soThe and
	  MuonSach.idMuon = TraSach.idMuon and
	  MuonSach.idNhanVien = NhanVien.idNhanVien
go
-- Tạo view xem thông tin độc giả
create view InforOfUser as
select ho,ten, ngaySinh, gioiTinh, CMND, diaChi,soDT,email,soThe,ngayDK
from DocGia
go
-- Tạo view xem thông tin nhân viên
create view InforOfEmp as
select ho,ten,ngaySinh,gioiTinh,CMND,diaChi,soDT,email,ngayBatDau
from NhanVien
go
-- tạo view độc giả mượn sách
create view view_DocGiaMuonSach
as
select idDocGia, CONCAT(ho,' ',ten) as hoTen,idmuonmuon,idSach, idNhanVienMuon, ngayMuon, idTraSach, ngayTra, idNhanVienTra  from (
	select MuonSach.idMuon as idmuonmuon, TraSach.idMuon as idmuontra, soThe, idSach, MuonSach.idNhanVien as idNhanVienMuon
			, TraSach.idNhanVien as idNhanVienTra, ngayMuon, idTraSach, ngayTra from MuonSach left join TraSach
		on MuonSach.idMuon = TraSach.idMuon) as A, DocGia
			where DocGia.soThe = a.soThe
go
-- tạo view thông tin nhân viên
create view view_thongTinNhanVien
as
	select * from NhanVien inner join TaiKhoan on TaiKhoan.id = nhanvien.idNhanVien
go

-- function
-- funtion tìm gần đúng theo tên sách
create function fu_timSach(@ten nvarchar(20))
returns table
as
	return select * from dbo.InforOfBook where dbo.InforOfBook.[Tên sách] like '%'+@ten+'%'
go

-- function tìm gần đúng theo tên độc giả
go
create function fu_timTenDocGia(@ten nvarchar(10))
returns table
as
	return select * from dbo.InforOfUser where (select concat( dbo.InforOfUser.ho,' ',dbo.InforOfUser.ten)) like '%'+@ten+'%'
go

-- function tìm chính xác theo thẻ độc giả
go
create function fu_timTheDocGia(@id int)
returns table
as
	return select * from dbo.InforOfUser where dbo.InforOfUser.soThe = @id
go
-- function đăng nhập
go
create function fun_dangnhap(@user nvarchar(50), @pass int)
returns table
as
 return select loai from dbo.TaiKhoan where userName = @user and pass = @pass
go
-- proceduce
-- proc thêm mượn sách
create procedure proc_themMuonSach (@idSach int, @soThe int , @idNhanVien int)
as
begin
	declare @ngayMuon date =  getdate()
	declare @hanTra date = dateadd(month,4,@ngayMuon)
	insert into MuonSach values (@idSach, @soThe, @idNhanVien, @ngayMuon, @hanTra)
end
go
-- proc thêm trả sách
create procedure proc_themTraSach (@idMuon int , @idNhanVien int)
as
begin
	declare @ngayTra date =  getdate()
	insert into TraSach values (@idMuon, @ngayTra, @idNhanVien)
end
go
-- tesst
select * from MuonSach
select * from TraSach
select * from PhieuPhat

exec  proc_themTraSach 1008,100