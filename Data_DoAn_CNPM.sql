--Tạo bảng
create database Database_CNPM
go
use Database_CNPM
go
create table QuanTri (
	idAdmin int IDENTITY(1000,1) ,
	ho nvarchar (20) not null,
	ten nvarchar (50) not null,
	ngaySinh date not null,
	gioiTinh nvarchar (5) not null,
	CMND varchar (20) not null,
	diaChi nvarchar (100),
	soDT varchar (15),
	email varchar (50),
	anhAdmin image null,
	CONSTRAINT pk_QuanTri PRIMARY KEY ( idAdmin)
);
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
	diaChi nvarchar (50),
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
	CONSTRAINT fk_idsach FOREIGN KEY (idSach) REFERENCES Sach (idSach)
	ON DELETE SET NULL,
	CONSTRAINT fk_sothe_muonsach FOREIGN KEY (soThe) REFERENCES TheThuVien (soThe),
	CONSTRAINT fk_nhavien FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien)
	ON DELETE SET NULL
);
go

create table TraSach(
	idTraSach int IDENTITY(2000,1),
	idMuon int,
	ngayTra date not null,
	idNhanVien int,
	CONSTRAINT pk_ PRIMARY KEY (idTraSach),
	CONSTRAINT fk_muon FOREIGN KEY (idMuon) REFERENCES MuonSach (idMuon)
		on delete cascade on update cascade,
	CONSTRAINT fk_nhavien_trasach FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien)
	ON DELETE no action
	ON UPDATE no action
);
go
create table PhieuPhat(
	idPhieuPhat int IDENTITY(3000,1),
	idTraSach int,
	soNgayQuaHan int,
	ngayLapPhieu date,
	idNhanVien int,
	soTienPhat int,
	CONSTRAINT pk_PhieuPhat PRIMARY KEY (idPhieuPhat),
	CONSTRAINT fk_idTraSach FOREIGN KEY (idTraSach) REFERENCES TraSach (idTraSach)
		on delete  cascade  on update  cascade,
	CONSTRAINT fk_NhanVienLapPhieuPhat FOREIGN KEY (idNhanVien) REFERENCES NhanVien (idNhanVien)
		on delete no action on update no action
);
go
-- tạo trigger tự insert vào bảng phiếu phạt
create trigger trig_InsertPhieuPhat on PhieuPhat
after insert
as 
begin
	update PhieuPhat
	set soNgayQuaHan = (select a.Tre from (select datediff(day,hanTra,ngayTra) as Tre, TraSach.idTraSach from  MuonSach,TraSach 
		where MuonSach.idMuon=TraSach.idMuon )as a, inserted where a.idTraSach = inserted.idTraSach)
	where PhieuPhat.idTraSach = (select idTraSach from inserted)

	update PhieuPhat
	set ngayLapPhieu = (select TraSach.ngayTra 
		from TraSach,inserted where TraSach.idTraSach = inserted.idTraSach)
	where PhieuPhat.idTraSach = (select idTraSach from inserted)

	update PhieuPhat
	set soTienPhat = 5000*(select Tre from (select datediff(day,hanTra,ngayTra) as Tre,  TraSach.idTraSach from  MuonSach,TraSach 
		where MuonSach.idMuon=TraSach.idMuon) as a, inserted where a.idTraSach = inserted.idTraSach )
	where PhieuPhat.idTraSach = (select idTraSach from inserted)
end

--trigg tự động thêm vào bảng phiếu phạt khi nhập vào bảng trả sách
go
create trigger trig_InserttoPhieuPhat on TraSach
after insert 
as 
begin
declare @x date = (select hanTra from MuonSach,inserted,TraSach where MuonSach.idMuon=TraSach.idMuon and TraSach.idMuon=inserted.idMuon)
declare @y date =( select TraSach.ngayTra from TraSach,inserted where TraSach.ngayTra=inserted.ngayTra )
	if ((select datediff(day,@x,@y)) >0)
	begin
	insert into PhieuPhat(idTraSach, idNhanVien)
		(select inserted.idTraSach, inserted.idNhanVien from inserted)
	end
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
				rollback transaction
			end
	end
go


--tạo triiger tự tạo tài khoản cho nhân viên
create trigger trig_InsertTaiKhoanNhanVien on NhanVien
	after insert
	as
	begin
		insert into TaiKhoan (id, userName, pass, loai)
			select idNhanVien,soDT,soDT, 'nhanvien' from inserted
	end
go

--tạo trigger tự tạo tài khoản cho độc giả
create trigger trig_InsertTaiKhoanDocGia on DocGia
	after insert
	as
	begin
		insert into TaiKhoan (id, userName, pass, loai)
			select idDocGia,soDT,soDT, 'docgia' from inserted
	end
go
-- Thêm độc giả và tự động tạo thẻ thư viện
create procedure sp_ThemDocGia (@ho nvarchar (20), @ten nvarchar (50),@ngaySinh date,@gioiTinh nvarchar (5),
								@CMND varchar (20),@diaChi nvarchar (50),@soDT varchar (15),
								@email varchar (50), @anhDG image) as
begin
	begin tran
	DECLARE @ngayLap date = getdate();
	DECLARE @hanSuDung date =DATEADD(year, 1, @ngayLap)
	insert into TheThuVien(ngayLap,hanSuDung) values (@ngayLap,@hanSuDung)

	declare @soThe int
	set @soThe=(select max(TheThuVien.soThe) FROM TheThuVien)
	INSERT INTO [dbo].[DocGia]([ho],[ten],[ngaySinh],[gioiTinh],[CMND],[diaChi],[soDT],[email],[ngayDK],[soThe],[anhDG])
				VALUES (@ho,@ten,@ngaySinh,@gioiTinh,@CMND,@diaChi,@soDT,@email,@ngayLap,@soThe,@anhDG)
	commit tran
end
go

-- Thêm đầu sách
create procedure sp_Insert_Sach
@tenSach nvarchar(100),
@butDanh nvarchar(50),
@tenNXB nvarchar(50),
@namXB date,
@theLoai nvarchar(50),
@gia int,
@soLuong int,
@vitri nvarchar (50),
@anhDS image
as
begin
	begin tran
	declare @idNXB int
	declare @idTheLoai int
	declare @idTacGia int
	if(@butDanh not in(select butDanh from TacGia))
	begin
		insert into TacGia(butDanh) values(@butDanh)
		select @idTacGia=idTacGia from TacGia where TacGia.butDanh = @butDanh
	end
	else
	begin
		select @idTacGia=idTacGia from TacGia where TacGia.butDanh = @butDanh
	end

	if(@tenNXB not in(select ten from NhaXuatBan))
	begin
		insert into NhaXuatBan(ten) values(@tenNXB)
		select @idNXB=idNXB from NhaXuatBan where NhaXuatBan.ten = @tenNXB
	end
	else
	begin
		select @idNXB=idNXB from NhaXuatBan where NhaXuatBan.ten = @tenNXB
	end

	if(@theLoai not in(select tenTheLoai from TheLoaiSach))
	begin
		insert into TheLoaiSach(tenTheLoai) values(@theLoai)
		select @idTheLoai=idTheLoai from TheLoaiSach where TheLoaiSach.tenTheLoai = @theLoai
	end
	else
	begin
		select @idTheLoai=idTheLoai from TheLoaiSach where TheLoaiSach.tenTheLoai = @theLoai
	end
	
	insert into DauSach(tenSach,idNXB,namXB,idTheLoai,gia,soLuong,idTacGia,anhDS,soLuongMuon,viTri) 
				values(@tenSach,@idNXB,@namXB,@idTheLoai,@gia,@soLuong,@idTacGia, @anhDS,0,@vitri)
	commit tran
end
go
-- tự động thêm vào bảng sách khi thêm đầu sách
create trigger trig_InsertDauSachToSach on DauSach
	after insert
	as
	begin
		DECLARE @soLuong int
		DECLARE @idDauSach int
		set @idDauSach= (select idDauSach from inserted)
		set @soLuong = (select soLuong from inserted)
		WHILE @soLuong >0
		BEGIN
		 insert into Sach (idDauSach,trangThai) values (@idDauSach,N'Chưa mượn')
		 SET @soLuong = @soLuong -1 ;
		END;
		if (@@ERROR <>0)
		begin
			-- 16 : muc do nghiem trong loi do nguoi dung nhap du lieu
			-- 1 : trang thai -> do ltv tu dat de nhan biet loi
			raiserror('Error',16,1)
			rollback
			return 
		end
	end
go
-- proc thêm mượn sách
create procedure proc_themMuonSach (@idSach int, @soThe int , @idNhanVien int)
as
begin
	declare @ngayMuon date =  getdate()
	declare @hanTra date = dateadd(month,4,@ngayMuon)
	insert into MuonSach values (@idSach, @soThe, @idNhanVien, @ngayMuon, @hanTra)
end

go
-- Thêm trả sách
-- proc thêm trả sách
create procedure proc_themTraSach (@idMuon int , @idNhanVien int)
as
begin
	declare @ngayTra date =  getdate()
	insert into TraSach values (@idMuon, @ngayTra, @idNhanVien)
end
go

-- Tạo view xem thông tin của sách
create view InforOfBook as
select DauSach.idDauSach as 'ID sách',
		DauSach.tenSach as 'Tên sách', TacGia.butDanh as 'Tác giả',
	   NhaXuatBan.Ten as 'NXB',DauSach.soLuong as'Số lượng', DauSach.soLuongMuon as 'Số lượng mượn',
	   DauSach.namXB as 'Năm xuất bản', DauSach.viTri as 'Vị trí', DauSach.anhDS as 'Ảnh bìa'
from DauSach,TacGia,NhaXuatBan,TheLoaiSach
where DauSach.idNXB=NhaXuatBan.idNXB and
	  DauSach.idTacGia=TacGia.idTacGia and
	  DauSach.idTheLoai = TheLoaiSach.idTheLoai
go

-- Tạo view báo cáo tình trạng mượn trả sách
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
-- function tìm đầu sách gần đúng theo tên sách
create function fu_timSach(@ten nvarchar(20))
returns table
as
	return select * from dbo.InforOfBook where dbo.InforOfBook.[Tên sách] like '%'+@ten+'%'
go

-- function  tìm kiếm đầu sách gần đúng theo tên tác giả
create function fu_timSachTheoTenTG(@tentg nvarchar(20))
returns table
as
	return select * from dbo.InforOfBook where dbo.InforOfBook.[Tác giả] like '%'+@tentg+'%'
go

-- function tìm độc giả gần đúng theo tên độc giả
go
create function fu_timTenDocGia(@ten nvarchar(10))
returns table
as
	return select * from dbo.InforOfUser where (select concat( dbo.InforOfUser.ho,' ',dbo.InforOfUser.ten)) like '%'+@ten+'%'
go


-- function tìm độc giả chính xác theo thẻ độc giả
go
create function fu_timTheDocGia(@id int)
returns table
as
	return select * from dbo.InforOfUser where dbo.InforOfUser.soThe = @id
go
-- function kiểm tra đăng nhập
create function fun_dangnhap(@user nvarchar(50), @pass int)
returns table
as
 return select loai from dbo.TaiKhoan where userName = @user and pass = @pass
go

-- Sửa thông tin độc giả

create procedure sp_SuaDocGia (@idDocGia int,@ho nvarchar (20), @ten nvarchar (50),@ngaySinh date,@gioiTinh nvarchar (5),
								@CMND varchar (20),@diaChi nvarchar (50),@soDT varchar (15),
								@email varchar (50),@ngayDK date, @soThe int,@anhDG image) as
begin
	begin tran

	-- Cập nhật ngày lập ở bảng TheThuVien
	UPDATE TheThuVien
	SET  ngayLap=@ngayDK 
	WHERE soThe=@soThe;
	-- Cập nhật ở bảng DocGia
	UPDATE [dbo].[DocGia]
   SET [ho] = @ho
      ,[ten] = @ten
      ,[ngaySinh] =@ngaySinh
      ,[gioiTinh] = @gioiTinh
      ,[CMND] = @CMND
      ,[diaChi] = @diaChi
      ,[soDT] = @soDT
      ,[email] = @email
      ,[ngayDK] = @ngayDK
      ,[soThe] = @soThe
      ,[anhDG] = @anhDG
	WHERE DocGia.idDocGia=@idDocGia
	commit tran
end
go
-- Xóa độc giả tức là sẽ xóa đi tài khoản của độc giả -> không thể đăng nhập vào hệ thống
create procedure sp_XoaDocGia (@idDocGia int) as
begin 
	delete from TaiKhoan where TaiKhoan.id=@idDocGia
end
go
-- Xem thông tin độc giả khi đăng nhập 

CREATE FUNCTION fu_ThongTinDocGiaDangNhap (@username varchar(50), @pass varchar(20))
returns table as
return select ho, ten, ngaySinh, cmnd, diaChi,soDT, email, ngayDK, soThe,anhDG 
		from DocGia inner join TaiKhoan on DocGia.idDocGia=TaiKhoan.id
		where TaiKhoan.userName=@username and TaiKhoan.pass=@pass
go

-- Tạo PROC update ten, gia, soLuong
create procedure sp_UpdateBook
@idDauSach int,
@tenSach nvarchar(100),
@vitri nvarchar(50),
@soLuong int
as
begin
	update DauSach set DauSach.tenSach = @tenSach, DauSach.viTri = @vitri, DauSach.soLuong = @soLuong 
		where DauSach.idDauSach = @idDauSach
end
go
-- Thêm số lượng sách trong bảng sách tương ứng khi cập nhật lại (chỉ tính tăng số lượng) số lượng sách trong đầu sách 
create trigger trig_UpdateDauSach on DauSach
after update
as
	begin 
		declare @soluongmoi as int 
		declare @soluongcu as int
		declare @idDauSach as int
		declare @n as int
		
		select @idDauSach=inserted.idDauSach from inserted

		select @soluongmoi=inserted.soLuong from inserted
		select @soluongcu=deleted.soLuong from deleted
		set @n=@soluongmoi-@soluongcu
		if (@n>0)
		begin 
		 while @n>0
		 begin 
			insert into Sach (idDauSach,trangThai) values (@idDauSach,N'Chưa mượn')
			set @n=@n-1
		 end
		end
	end
go

-- Xóa đầu sách
create procedure sp_XoDauSach @idDauSach int as
begin 
	delete from DauSach where DauSach.idDauSach=@idDauSach
end
go
-- tìm ra bảng các độc giả trả sách trể hạn
 create function fun_docgiatrasachtre()
 returns table
 as

	 return select idDocGia,ho,ten,ngaySinh,gioiTinh,CMND,diaChi,soDT,email,ngayDK,DocGia.soThe
	from DocGia,(select datediff(day,hanTra,ngayTra) as Tre,soThe from  MuonSach,TraSach 
		where MuonSach.idMuon=TraSach.idMuon ) as A
			where DocGia.soThe=A.soThe and Tre>0
go
---
-- tạo một thủ tục tính tổng số tiền phạt
create proc proc_tongphat
as
 select sum(soTienPhat) as TongPhat from  PhieuPhat;


 -- tạo function danh sach phạt độc giả
 go
 create function fun_danhsachphattien ()
 returns table
 as
  return select idDocGia,ho,ten,ngaySinh,gioiTinh,CMND, DocGia.soThe,soNgayQuaHan,soTienPhat,ngayTra 
	from DocGia,PhieuPhat,MuonSach ,TraSach
		where DocGia.soThe=MuonSach.soThe and MuonSach.idMuon=TraSach.idMuon and TraSach.idTraSach=PhieuPhat.idTraSach

-- tạo một function tìm ra đọc giả nợ tiền nhiều nhất.
go
create function fun_phatđg()
returns table
as
 return select idDocGia,sum(soTienPhat) as tongNo from fun_danhsachphattien() 
	group by idDocGia
go
create proc proc_maxphat
as
	select max(tongNo)from  fun_phatđg()
go
		
-- tạo function hiển thị danh sách các quyển sách dã được mượn.
create function fun_sachdaduocmuon()
returns table
as 
	return select idSach,tenSach,DauSach.idDauSach,tenTheLoai,gia,viTri from Sach,DauSach,TheLoaiSach where Sach.idDauSach=DauSach.idDauSach and TheLoaiSach.idTheLoai=DauSach.idTheLoai and trangThai=N'Đã mượn'
	go
--tạo function hiển thị danh sách các quyển sách dã được mượn.
create function fun_sachchuaduocmuon()
returns table
as
	return select idSach,tenSach,DauSach.idDauSach,tenTheLoai,gia,viTri from Sach,DauSach,TheLoaiSach where Sach.idDauSach=DauSach.idDauSach and TheLoaiSach.idTheLoai=DauSach.idTheLoai and trangThai=N'Chưa mượn'
go

create function fun_sacmuonnhieunhat()
returns table
as 
	return select  tenSach, count(DauSach.idDauSach) as soLuong from DauSach,Sach where DauSach.idDauSach= Sach.idDauSach and trangThai=N'Đã mượn' group by tenSach
go
create proc proc_sachmuonnhiunhat
as 
	 select max(tenSach) as a from fun_sacmuonnhieunhat()
go

-- Xem thông tin các sách mà độc giả đã mượn
CREATE FUNCTION fu_ThongTinMuonSachCuaDocGia (@username varchar(50), @pass varchar(20))
returns table as
return select idMuon, Sach.idSach, ngayMuon,hanTra,tenSach  from 
	TaiKhoan inner join DocGia on TaiKhoan.id=DocGia.idDocGia
	inner join MuonSach on DocGia.soThe=MuonSach.soThe
	inner join Sach on Sach.idSach=MuonSach.idSach
	inner join DauSach on Sach.idDauSach=DauSach.idDauSach
	where TaiKhoan.userName=@username and TaiKhoan.pass=@pass
go

-- Tạo trigger tạo login, user, phân quyền cho độc giả 
create trigger trig_phanQuyenChoDocGia on DocGia
after insert
as
begin
	declare @username varchar(15)
	set @username=(select soDT from inserted)
	--Tạo login
	DECLARE @t nvarchar(4000)
	SET @t = N'CREATE LOGIN ' + QUOTENAME(@username) + ' WITH PASSWORD = ' + QUOTENAME(@username, '''')
	EXEC(@t)
	SET @t = N'CREATE USER ' + QUOTENAME(@username) + ' FOR LOGIN ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'TaiKhoan ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'DocGia ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'MuonSach ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'DauSach ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'fu_timSach ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'fu_timSachTheoTenTG ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'fu_ThongTinDocGiaDangNhap ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'fu_ThongTinMuonSachCuaDocGia ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'fun_dangnhap ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'Grant select on ' + 'InforOfBook ' + ' to ' + QUOTENAME(@username)
	EXEC(@t)
end
go

-- Tạo trigger tạo login, user, phân quyền cho nhân viên
create trigger trig_phanQuyenChoNhanVien on NhanVien
after insert
as
begin
	declare @username varchar(15)
	set @username=(select soDT from inserted)
	--Tạo login
	DECLARE @t nvarchar(4000)
	SET @t = N'CREATE LOGIN ' + QUOTENAME(@username) + ' WITH PASSWORD = ' + QUOTENAME(@username, '''')
	EXEC(@t)
	SET @t = N'CREATE USER ' + QUOTENAME(@username) + ' FOR LOGIN ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'ALTER SERVER ROLE [sysadmin] ADD MEMBER' + QUOTENAME(@username)
	EXEC(@t)
end
go
-- Tạo function tìm những độc giả đã mượn sách
create function fun_docgiamuonsach()
returns table
as
return select idDocGia,ho,ten,ngaySinh,gioiTinh,CMND,diaChi,soDT,email,ngayDK,DocGia.soThe from DocGia,MuonSach where DocGia.soThe=MuonSach.soThe
go

-- Thêm dữ liệu 
use Database_CNPM
go
insert into NhanVien values
(N'Trần',N'Văn Duy','2001-1-1',N'Nam','215530901',N'Hoài Nhơn - Bình Định','0814233577','tranvanduy@gmail.com','2021-1-1',null)
go
insert into NhanVien values
(N'Trần',N'Văn Hào','2001-2-1',N'Nam','215530701',N'Hoài Nhơn - Bình Phước','0814233555','caovanhao@gmail.com','2021-2-1',null)
go
insert into NhanVien values
(N'Trần',N'Trường','2001-3-1',N'Nam','215530801',N'Tây Sơn - Bình Định','0765233577','trancongtruong@gmail.com','2021-1-15',null)
go
insert into NhanVien values
(N'Cao',N'Anh Văn','2001-1-5',N'Nam','215530221',N'Tây Sơn - Bình Định','0814563577','caoanhvan@gmail.com','2021-6-1',null)
go
insert into NhanVien values
(N'Lê',N'Phương Nam','2001-10-1',N'Nam','215531221',N'Biên Hòa - Đồng Nai','0814238767','lephuongnam@gmail.com','2021-1-7',null)
go
insert into NhanVien values
(N'Nguyễn',N'Ngọc Hân','2001-12-22',N'Nữ','215530156',N'Thủ Đức - TP.HCM','0925233577','nguyenngochan@gmail.com','2021-11-1',null)
go

insert into TacGia values
(N'Nam Cao'),
(N'Nam Thành'),
(N'Xuân Diệu'),
(N'Hồ Xuân Hương'),
(N'Huy Cận'),
(N'Tản Đà');
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

exec sp_ThemDocGia N'Trần',N'Ngọc Chiến','1999-2-1',N'Nam','223550924',N'Linh Trung-Thủ Đức','0187122947','ngochien@gmail.com',null
go
exec sp_ThemDocGia N'Trần',N'Ngọc Như','1998-1-3',N'Nữ','223340087',N'Linh Xuân-Thủ Đức','0187122941','ngocnhu@gmail.com',null
go
exec sp_ThemDocGia N'Nguyễn',N'Văn Toàn','1999-4-1',N'Nam','223340123',N'Kha Vạn Cân-Thủ Đức','0187122981','vantoang@gmail.com',null
go
exec sp_ThemDocGia N'Trần',N'Quốc Quân','2001-5-1',N'Nam','223340345',N'Dĩ An-Bình Dương','0187155541','quocquann@gmail.com',null
go
exec sp_ThemDocGia N'Cao',N'Hông Hoa','2002-11-1',N'Nữ','223340678',N'Hiệp Bình Chánh-Thủ Đức','0187122149','honghoa@gmail.com',null
go
exec sp_ThemDocGia N'Lưu',N'Quốc Dũng','2002-10-1',N'Nam','223342134',N'Hoàng Diệu 2-Thủ Đức','0196522941','quocdung@gmail.com',null
go
insert into DauSach values
(N'Kỹ thuật lập trình',600,'2005-1-1',500,50000,30,100,200,null,N'Kệ 1')
go
insert into DauSach values
(N'Kỹ thuật điện',601,'2005-2-1',500,50000,20,100,201,null,N'Kệ 2')
go
insert into DauSach values
(N'Kỹ thuật cơ khí',602,'2005-3-1',500,50000,10,100,202,null,N'Kệ 1')
go
insert into DauSach values
(N'Lão Hạc',603,'2015-1-19',501,70000,5,100,203,null,N'Kệ 1')
go
insert into DauSach values
(N'Tắt đèn',604,'2015-10-1',502,70000,22,100,204,null,N'Kệ 2')
go
insert into DauSach values
(N'Bài tập lập trình',600,'2015-10-1',503,25000,70,110,205,null,N'Kệ 1')
go
insert into DauSach values
(N'Bài tập vật lý 1',601,'2012-1-11',504,25000,80,100,200,null,N'Kệ 3')
go
insert into DauSach values
(N'Khoa học vũ trụ',602,'2016-1-12',504,100000,31,90,201,null,N'Kệ 3')
go
insert into DauSach values
(N'Thế giới động vật',603,'2011-1-13',502,100000,2,50,202,null,N'Kệ 3')
go
insert into MuonSach values 
(900,300,100,'2020-2-1','2020-04-01')
go
insert into MuonSach values 
(902,300,100,'2020-3-13','2020-05-13')
go
insert into MuonSach values
(902,300,100,'2020-3-13','2020-05-13')
go
insert into MuonSach values
(904,301,101,'2020-4-13','2020-05-13')
go
insert into MuonSach values
(907,301,101,'2020-5-11','2020-8-15')
go
insert into MuonSach values
(909,302,102,'2020-11-12','2020-12-20')
go
insert into MuonSach values
(910,303,102,'2020-3-19','2020-07-19')
go
insert into MuonSach values
(911,303,102,'2020-6-5','2020-07-15')
go
insert into TraSach values
(1000,'2021-1-1',100)
go
insert into TraSach values
(1001,'2021-11-29',101)
go
insert into TraSach values
(1002,'2021-12-1',100)
go
insert into TraSach values
(1003,'2021-12-5',101)
go
insert into TraSach values
(1004,'2021-1-5',102)
go
----------
-- function tìm nhân viên gần đúng theo tên nhân viên
go
create function fu_timTenNhanVien(@ten nvarchar(10))
returns table
as
	return select * from NhanVien where (select concat( nhanvien.ho,' ',nhanvien.ten)) like '%'+@ten+'%'
go

-- function tìm nhân viên theo số điện thoại
go
create function fu_timSDTNhanVien(@sdt varchar(20))
returns table
as
	return select * from nhanvien where nhanvien.soDT = @sdt
go
-- procedure thêm nhân viên
create procedure sp_ThemNhanVien (@ho nvarchar (20), @ten nvarchar (50),@ngaySinh date,@gioiTinh nvarchar (5),
								@CMND varchar (20),@diaChi nvarchar (50),@soDT varchar (15),
								@email varchar (50), @anh image) as
begin
	begin tran
	DECLARE @ngayBatDau date = getdate();
	INSERT INTO [dbo].[NhanVien]([ho],[ten],[ngaySinh],[gioiTinh],[CMND],[diaChi],[soDT],[email],[ngayBatDau],[anhNV])
				VALUES (@ho,@ten,@ngaySinh,@gioiTinh,@CMND,@diaChi,@soDT,@email,@ngayBatDau,@anh)
	commit tran
end
go
--view thongtinAdmin
create view view_thongTinAdmin
as
	select * from QuanTri inner join TaiKhoan on TaiKhoan.id = QuanTri.idAdmin
go

--tạo triiger tự tạo tài khoản cho Admin
create trigger trig_InsertTaiKhoanQuanTri on QuanTri
	after insert
	as
	begin
		insert into TaiKhoan (id, userName, pass, loai)
			select idAdmin,soDT,soDT, 'admin' from inserted
	end
go
-- Tạo trigger tạo login, user, phân quyền cho nhân viên
create trigger trig_phanQuyenChoAdmin on QuanTri
after insert
as
begin
	declare @username varchar(15)
	set @username=(select soDT from inserted)
	--Tạo login
	DECLARE @t nvarchar(4000)
	SET @t = N'CREATE LOGIN ' + QUOTENAME(@username) + ' WITH PASSWORD = ' + QUOTENAME(@username, '''')
	EXEC(@t)
	SET @t = N'CREATE USER ' + QUOTENAME(@username) + ' FOR LOGIN ' + QUOTENAME(@username)
	EXEC(@t)
	SET @t = N'ALTER SERVER ROLE [sysadmin] ADD MEMBER' + QUOTENAME(@username)
	EXEC(@t)
end
go
-- thêm dữ liệu vào bảng Quản trị
insert into QuanTri values
(N'Trần',N'Văn Duy','2001-1-1',N'Nam','215530901',N'Hoài Nhơn - Bình Định','012345678','tranvanduy@gmail.com',null)
go
insert into QuanTri values
(N'Trần',N'Văn Hào','2001-2-1',N'Nam','215530701',N'Hoài Nhơn - Bình Phước','876543210','caovanhao@gmail.com',null)


select* from TaiKhoan