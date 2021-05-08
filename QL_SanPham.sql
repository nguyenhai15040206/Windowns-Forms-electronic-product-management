Create Database QL_SanPham
Use QL_SanPham
Go

-- tạo bảng

Create table NguoiDung
(
	tenNguoiDung nvarchar(51),
	tenDangNhap varchar(51) primary key,
	matKhau varchar(51),
	diaChi nvarchar(500),
	soDienThoai varchar(11),
	email varchar(51),
	ngayVaoLam date,
	hoatDong bit,
)

Create table QL_NhomNguoiDung
(
	maNhom varchar(51) primary key,
	tenNhom nvarchar(100),
	ghiChu nvarchar(101)
)

Create table DanhMucManHinh
(
	maManHinh varchar(51) primary key,
	tenManHinh nvarchar(300)
)


Create table QL_NguoiDungNhomNguoiDung
(
	tenDangNhap varchar(51),
	maNhomNguoiDung int,
	ghiChu nvarchar(101),
	primary key (tenDangNhap,maNhomNguoiDung)
)

Create table QL_PhanQuyen
(
	maNhomNguoiDung varchar(51),
	maManHinh varchar(51),
	coQuyen bit,
	primary key(maNhomNguoiDung, maManHinh)
)

Create table KhachHang
(
	maKhachHang int identity (1,1) primary key,
	tenKhachHang nvarchar(51),
	soDienThoai varchar(11),
	email varchar(51),
	diaChi nvarchar(500),
	tenDangNhap varchar(51),
	matKhau varchar(51),
)

Create table NhaSanXuat
(
	maNhaSanXuat int identity (1,1) primary key,
	tenNhaSanXuat nvarchar(51),
	diaChi nvarchar(500),
	soDienThoai varchar(11),
	email varchar(71),
	logo varchar(500),
)

Create table NhaCungCap
(
	maNhaCungCap int identity (1,1) primary key,
	tenNhaCungCap nvarchar(51),
	diaChi nvarchar(500),
	soDienThoai varchar(11),
	email varchar(51)
) 

Create table Banner
(
	maBanner int identity (1,1) primary key,
	fileBanner varchar(500),
	kichHoat bit,
	ghiChu nvarchar(500)
)

Create table LoaiTinTuc
(
	maLoaiTin int identity(1,1) primary key,
	tenLoaiTin nvarchar(500),
	ghiChu nvarchar(500)
)

Create table TinTuc
(
	maTinTuc int identity(1,1) primary key,
	tenTinTuc nvarchar(500),
	noiDung nvarchar(600),
	ngayDang date,
	anhMinhHoa varchar(500),
	kichHoat bit,
	ghiChu nvarchar(500),
	maLoaiTin int,
	Constraint fk_TinTuc_LoaiTinTuc foreign key(maLoaiTin) references LoaiTinTuc(maLoaiTin)
)

Create table DanhMuc
(
	maDanhMuc int identity (1,1) primary key,
	tenDanhMuc nvarchar(500),
	maNhaSanXuat int,
	ghiChu varchar(50),
	logoTungDanhMucSP varchar(500),
	Constraint fk_DanhMuc_NhaSanXuat foreign key(maNhaSanXuat) references NhaSanXuat(maNhaSanXuat)
)

Create table SanPham
(
	maSanPham int identity (1,1) primary key,
	tenSanPham nvarchar(500),
	soLuong int,
	donGia money,
	moTa nvarchar(800),
	moTaChiTiet nvarchar(800),
	khuyenMai nvarchar(800),
	giamGia money,
	ngayCapNhat date,
	xuatXu nvarchar(100),
	hinhMinhHoa varchar(500),
	dsHinh varchar(500),
	tinhTrang bit,
	maDanhMuc int,
	Constraint fk_SanPham_DanhMuc foreign key(maDanhMuc) references DanhMuc(maDanhMuc)
)


Create table PhieuNhap
(
	maPhieuNhap int identity(1,1) primary key,
	ngayNhap date,
	maNhaCungCap int,
	tienNhap money,
	Constraint fk_PhieuNhap_NhaCungCap foreign key(maNhaCungCap) references NhaCungCap(maNhaCungCap)
)

Create table CTPhieuNhap
(
	maPhieuNhap int,
	maSanPham int,
	soLuong int,
	giaNhap money,
	ThanhTien money,
	primary key(maPhieuNhap),
	Constraint fk_CTPhieuNhap_PhieuNhap foreign key(maPhieuNhap) references PhieuNhap(maPhieuNhap),
	Constraint fk_CTPhieuNhap_SanPham foreign key(maSanPham) references SanPham(maSanPham)
)

Create table HoaDon
(
	maHoaDon int identity (1,1) primary key,
	ngayBan date,
	maKhachHang int,
	tienBan money,
	giamGia float,
	tongTien money,
	ghiChu nvarchar(500),
	maNguoiDung int,
	Constraint fk_HoaDon_KhachHang foreign key(maKhachhang) references KhachHang(maKhachHang),
	Constraint fk_HoaDon_NguoiDung foreign key(maNguoiDung) references NguoiDung(maNguoiDung)
)

Create table CTHoaDon
(
	maHoaDon int,
	maSanPham int,
	soLuong int,
	donGia money,
	giamGia float,
	thanhTien money,
	ghiChu nvarchar(500),
	primary key(maHoaDon,maSanPham),
	Constraint fk_CTHoaDon_HoaDon foreign key(maHoaDon) references HoaDon(maHoaDon),
	Constraint fk_CTHoaDon_SanPham foreign key(maSanPham) references SanPham(maSanPham)
)

select * from DanhMuc
-- Dữ liệu cho bảng danh mục sản phẩm
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Iphone',null,N'DienThoai',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'SAMSUNG',null,N'DienThoai',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'VIVO',null,N'DienThoai',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Realme',null,N'DienThoai',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Xiaomi',null,N'DienThoai',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Oppo',null,N'DienThoai',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Macbook',null,N'Laptop',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Asus',null,N'Laptop',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Dell',null,N'Laptop',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Acer',null,N'Laptop',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'Hp',null,N'Laptop',null)
INSERT INTO DanhMuc (tenDanhMuc,maNhaSanXuat,ghiChu,logoTungDanhMucSP) VALUES(N'MSI',null,N'Laptop',null)

--Dữ liệu cho bảng sản phẩm
select * from SanPham
--ĐIện thoại
	-- Iphone
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone 11promax 64GB', 120, 27000000.0000, N'6.1", Liquid Retina HD, IPS LCD, 828 x 1792 Pixel | 12.0 MP | 7.0 MP | A12 Bionic | 4GB | 64 GB', N'Apple GPU 4 nhân | 3110 mAh | 2, 1 eSIM, 1 Nano SIM | 	iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2019-09-01' AS Date), N'	Trung Quốc', N'IPHONE11PRO_TRANG.PNG', NULL, NULL, 1)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone SE 64GB', 120, 11490000, N'4.7", Retina HD, IPS LCD, 750 x 1334 Pixel | 12.0 MP | 7.0 MP | A12 Bionic | 3GB | 64 GB', N'	Apple GPU 4 nhân | 1821 mAh | 2, 1 eSIM, 1 Nano SIM | iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'IPHONESE64GB_DEN.PNG', NULL, NULL, 1)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone 12 64GB', 120, 24990000, N'6.1", Super Retina XDR, AMOLED | 12.0 MP + 12.0 MP | 12.0 MP | A14 Bionic | 4GB | 64 GB', N'	Apple GPU 4 nhân | 2815 mAh | 2, 1 eSIM, 1 Nano SIM | iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2019-09-01' AS Date), N'Trung Quốc', N'IPHONE12_DEN.PNG', NULL, NULL, 1)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone 12 pro 64GB', 120, 30990000, N'6.1", Super Retina XDR, AMOLED | 12.0 MP + 12.0 MP + 12.0 MP | 12.0 MP | A14 Bionic | 6GB | 64 GB', N'Apple GPU 4 nhân | 2815 mAh | 2, 1 eSIM, 1 Nano SIM | iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2019-09-01' AS Date), N'	Trung Quốc', N'IPHONE12PRO_TRANG.PNG', NULL, NULL, 1)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone 12 pro max 64GB', 120, 33990000, N'6.7", Super Retina XDR, AMOLED | 12.0 MP + 12.0 MP + 12.0 MP | 12.0 MP | A14 Bionic | 6GB | 64 GB', N'	Apple GPU 4 nhân | 3110 mAh | 	2, 1 eSIM, 1 Nano SIM | 	iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2019-09-01' AS Date), N'	Trung Quốc', N'IPHONE12PRO_XANHREU.PNG', NULL, NULL, 1)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone 11 64GB', 120, 1749000, N'6.1", Liquid Retina HD, IPS LCD, 828 x 1792 Pixel | 12.0 MP | 7.0 MP | A12 Bionic | 4GB | 64 GB', N'	Apple GPU 4 nhân | 3110 mAh | 	2, 1 eSIM, 1 Nano SIM | 	iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2019-09-01' AS Date), N'	Trung Quốc', N'IPHONE1164GB_TRANG.PNG', NULL, NULL, 1)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone XR 64GB', 120, 12790000, N'6.1", Liquid Retina HD, IPS LCD, 828 x 1792 Pixel | 12.0 MP | 7.0 MP | A12 Bionic | 4GB | 64 GB', N'	Apple GPU 4 nhân | 3110 mAh | 	2, 1 eSIM, 1 Nano SIM | 	iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2019-09-01' AS Date), N'	Trung Quốc', N'IPHONEXR64GB_DEN.PNG', NULL, NULL, 1)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone 12 mini 64GB', 120, 19450000, N'6.1", Liquid Retina HD, IPS LCD, 828 x 1792 Pixel | 12.0 MP | 7.0 MP | A12 Bionic | 4GB | 64 GB', N'	Apple GPU 4 nhân | 3110 mAh | 	2, 1 eSIM, 1 Nano SIM | 	iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2019-09-01' AS Date), N'	Trung Quốc', N'IPHONE12_DEN.PNG', NULL, NULL, 1)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'iPhone 11 pro 64GB', 120, 19450000, N'6.1", Liquid Retina HD, IPS LCD, 828 x 1792 Pixel | 12.0 MP | 7.0 MP | A12 Bionic | 4GB | 64 GB', N'	Apple GPU 4 nhân | 3110 mAh | 	2, 1 eSIM, 1 Nano SIM | 	iOS 14', N'Giảm ngay 15.000.000đ | Tặng Sim đồng thương hiệu Mobifone Gọi Thả Ga F160 1T đầu 07/08/09 | Trả góp 0%', 25000000.0000, CAST(N'2019-09-01' AS Date), N'	Trung Quốc', N'IPHONE11PRO_TRANG.PNG', NULL, NULL, 1)
	--Oppo
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Oppo A53 4GB-128GB', 120, 4490000.0000, N'6.5", HD+, IPS LCD, 720 x 1600 Pixel | 13.0 MP + 2.0 MP + 2.0 MP | 16.0 MP | Snapdragon 460 | 	4 GB | 128 GB', N'Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 500000.0000, CAST(N'2020-08-01' AS Date), N'Trung Quốc', N'OPPOA53_XANH.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'OPPO Reno4', 50, 7990000.0000, N'6.4", FHD+, AMOLED, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 32.0 MP + Cảm biến thông minh A.I | Snapdragon 720G | 8 GB | 128 GB', N'Adreno 618 | 4015 mAh | 2, Nano SIM | Android 10.0 | ', NULL, 2000000.0000, CAST(N'2020-07-01' AS Date), N'	Trung Quốc', N'OPPORENO4_DEN.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'OPPO A93 8GB-128GB', 50, 7190000.0000, N'6.43", FHD+, AMOLED, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 16.0 MP + 2.0 MP | Mediatek Helio P95 | 8 GB | 128 GB', N'IMG 9XM-HP8 | 4000 mAh | 2, Nano SIM | Android 10.0 ', NULL, 500000.0000, CAST(N'2020-09-01' AS Date), N'Trung Quốc', N'OPPOA93_DEN.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Oppo A52 6GB-128GB', 50, 5690000.0000, N'6.5", FHD+, TFT LCD, 1080 x 2400 Pixel | 12.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 16.0 MP | Snapdragon 665 | 6 GB | 128 GB', N'Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', N' ', 200000.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'OPPOA52_TRANG.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Oppo Reno4 Pro', 100, 11990000.0000, N'6.5", FHD+, AMOLED, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 32.0 MP | Snapdragon 720G | 8 GB | 256 GB ', N'Adreno 618 | 4000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-07-01' AS Date), N'Trung Quốc', N'OPPORENO4PRO_TRANG.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'OPPO A92', 0, 6190000.0000, N'6.5", FHD+, TFT LCD, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 16.0 MP | Snapdragon 665 | 8 GB | 128 GB', N'	Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-05-01' AS Date), N'Trung Quốc', N'OPPOA53_XANH.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Oppo A12 3GB-32GB', 10, 2990000.0000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'OPPOA12_BAC.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Oppo A31 4GB-128GB', 0, 4490000, N'6.5", HD+, TFT LCD, 720 x 1600 Pixel | 12.0 MP + 2.0 MP + 2.0 MP | 8.0 MP | Helio P35 | 4 GB | 128 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-05-01' AS Date), N'Trung Quốc', N'OPPOA53_XANH.PNG', NULL, NULL, 6)

	-- samsung
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy Note 20 Ultra 5G', 10, 27990000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYNOTE20ULTRA5G_VANG.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy Note 20 Ultra', 0,24990000, N'6.5", FHD+, TFT LCD, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 16.0 MP | Snapdragon 665 | 8 GB | 128 GB', N'	Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-05-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYNOTE20ULTRA_DEN.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy Note 20', 10, 20990000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYNOTE20ULTRA_DEN.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy Z Fold2 5G', 10, 50000000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'SAMSUNGGALASYZFOLD25G_DEN.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy S20+', 0, 23990000, N'6.5", FHD+, TFT LCD, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 16.0 MP | Snapdragon 665 | 8 GB | 128 GB', N'	Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-05-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYS20_DEN.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy S20 Ultra', 10, 29990000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYS20ULTRA_DEN.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy S20 FE', 10, 15990000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYS20FE_TIM.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy Z Flip', 0, 29000000, N'6.5", FHD+, TFT LCD, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 16.0 MP | Snapdragon 665 | 8 GB | 128 GB', N'	Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-05-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYZFLIP_XANH.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy Note 10 Lite', 10, 10990000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYNOTE10LITE_BAC.PNG', NULL, NULL, 2)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Samsung Galaxy A71', 10, 8900000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'SAMSUNGGALAXYA71_BAC.PNG', NULL, NULL, 2)

INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'OPPO A92', 0, 6190000.0000, N'6.5", FHD+, TFT LCD, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 16.0 MP | Snapdragon 665 | 8 GB | 128 GB', N'	Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-05-01' AS Date), N'Trung Quốc', N'OPPOA53_XANH.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Oppo A12 3GB-32GB', 10, 2990000.0000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'OPPOA12_BAC.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Oppo A12 3GB-32GB', 10, 2990000.0000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'OPPOA12_BAC.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'OPPO A92', 0, 6190000.0000, N'6.5", FHD+, TFT LCD, 1080 x 2400 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP | 16.0 MP | Snapdragon 665 | 8 GB | 128 GB', N'	Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-05-01' AS Date), N'Trung Quốc', N'OPPOA53_XANH.PNG', NULL, NULL, 6)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Oppo A12 3GB-32GB', 10, 2990000.0000, N'6.22", HD+, IPS LCD, 720 x 1560 Pixel | 13.0 MP + 2.0 MP | 5.0 MP | Helio P35 | 3 GB | 32 GB', N'IMG PowerVR GE8320 | 4230 mAh | 2, Nano SIM | Android 9.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', N'OPPOA12_BAC.PNG', NULL, NULL, 6)



INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Vivo X60 Pro', 10, 15990000.0000, N'6.56", FHD+, AMOLED, 1080 x 2376 Pixel | 48.0 MP + 13.0 MP + 13.0 MP |32.0 MP | Snapdragon 870 | 12GB | 256 GB', N'Adreno 650 | 4200 mAh | 2, Nano SIM | Android 11', NULL, 0.0000, CAST(N'2021-04-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 3)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Vivo Y12s 2021 3GB-32GB ', 10, 2990000.0000, N'6.51", HD+, IPS, 720 x 1600 Pixel |13.0 MP + 2.0 MP |8.0 MP | Snapdragon 439 | 3GB | 32 GB', N'Adreno 505 | 5000 mAh | 2, Nano SIM | Android 11', NULL, 0.0000, CAST(N'2021-03-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 3)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Vivo V20 2021 8GB - 128GB', 10, 7799000.0000, N'6.44", FHD+, AMOLED, 1080 x 2400 Pixel | 64.0 MP + 8.0 MP + 2.0 MP | 44.0 MP | Snapdragon 730 | 8GB | 128 GB', N'Adreno 618 | 4000 mAh | 2, Nano SIM | Android 11', NULL, 0.0000, CAST(N'2021-02-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 3)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Vivo Y51 8GB - 128GB', 10, 5990000.0000, N'6.58", FHD+, IPS LCD, 1080 x 2400 Pixel, 1080 x 2376 Pixel | 48.0 MP + 8.0 MP + 2.0 MP |16.0 MP | Snapdragon 662 | 8GB | 128 GB', N'Adreno 610 | 5000 mAh | 2, Nano SIM | Android 11', NULL, 0.0000, CAST(N'2021-01-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 3)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Vivo Y50 8GB - 128GB', 10, 4990000.0000, N'6.53", FHD+, LCD, 1080 x 2340 Pixel | 13.0 MP + 8.0 MP + 2.0 MP + 2.0 MP |16.0 MP | Snapdragon 665 | 8GB | 128 GB', N'Adreno 610 | 5000 mAh | 2, Nano SIM | Android 11', NULL, 0.0000, CAST(N'2021-04-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 3)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Vivo Y20s 6GB - 128GB', 10, 4690000.0000, N'6.51", HD+, IPS LCD, 720 x 1600 Pixel | 13.0 MP + 2.0 MP + 2.0 MP |8.0 MP | Snapdragon 460 | 6GB | 128 GB', N'Adreno 610 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-09-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 3)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Vivo V20 SE 8GB-128GB', 10, 6490000.0000, N'6.44", FHD+, AMOLED, 1080 x 2040 Pixel | 48.0 MP + 8.0 MP + 2.0 MP |32.0 MP | Snapdragon 665 | 8GB | 128 GB', N'Adreno 610 | 4100 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-10-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 3)

INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Realme C25 4GB-128GB', 10, 4390000.0000, N'6.5", HD+, LCD, 720 x 1600 Pixel | 48.0 MP + 2.0 MP + 2.0 MP |8.0 MP | Helio G70 | 4GB | 128 GB', N'ARM Mali-G52 MC2 | 6000 mAh | 2, Micro Sim | Android 11', NULL, 0.0000, CAST(N'2021-05-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 4)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Realme C20 2GB-32GB', 10, 2490000.0000, N'6.5", HD+, IPS LCD, 720 x 1600 Pixel | 8.0 MP |5.0 MP | Mediatek Helio G35 | 2GB | 32 GB', N'IMG PowerVR GE8320 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2021-01-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 4)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Realme C15 4GB-64GB ', 10, 3790000.0000, N'6.52", HD+, LCD, 720 x 1600 Pixel | 13.0 MP + 8.0 MP + 2.0 MP + 2.0 MP |8.0 MP | 	Snapdragon 460 | 4GB | 64 GB', N'Adreno 610 | 6000 mAh | 2, Micro Sim | Android 10.0', NULL, 0.0000, CAST(N'2021-01-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 4)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Realme C12 3GB-32GB ', 10, 2990000.0000, N'6.52", HD+, IPS LCD, 720 x 1600 Pixel | 13.0 MP + 2.0 MP + 2.0 MP | 5.0 MP | 	Helio G35 | 3GB | 32 GB', N'IMG PowerVR GE8320 | 6000 mAh | 2, Micro Sim | Android 10.0', NULL, 0.0000, CAST(N'2020-08-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 4)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Realme C11 2GB-32GB ', 10, 2490000.0000, N'6.5", HD+, IPS LCD, 720 x 1600 Pixel | 13.0 MP + 2.0 MP |5.0 MP | Mediatek Helio G35 | 2GB | 32 GB', N'IMG PowerVR GE8320 | 5000 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-07-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 4)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Realme C17 6GB - 128GB ', 10, 5290000.0000, N'6.52", HD+, LCD, 720 x 1600 Pixel | 13.0 MP + 8.0 MP + 2.0 MP + 2.0 MP |8.0 MP | Snapdragon 460 | 6GB | 128 GB', N'Adreno 610 | 5000 mAh | 2, Micro Sim | Android 10.0', NULL, 0.0000, CAST(N'2020-12-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 4)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Realme 7i 8GB-128GB ', 10, 5340000.0000, N'6.5", HD+, IPS LCD, 720 x 1600 Pixel | 64.0 MP + 8.0 MP + 2.0 MP + 2.0 MP |16.0 MP | Snapdragon 662 | 8GB | 128 GB', N'Adreno 610 | 5000 mAh | 2, Nano SIM | Không', NULL, 0.0000, CAST(N'2021-01-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 4)

INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Xiaomi Redmi Note 10 Pro 8GB-128GB MFF 2021 ', 10, 7490000.0000, N'6.67", FHD+, AMOLED, 1080 x 2400 Pixel | 108.0 MP + 8.0 MP + 2.0 MP + 5.0 MP |16.0 MP | Snapdragon 732G | 8GB | 128 GB', N'Adreno 618 | 5020 mAh | 2, Nano SIM | Android 11', NULL, 0.0000, CAST(N'2021-03-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 5)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Xiaomi Mi 10T Lite 5G 6GB-128GB ', 10, 6990000.0000, N'6.67", FHD+, IPS LCD, 1080 x 2400 Pixel | 64.0 MP + 8.0 MP + 2.0 MP + 2.0 MP |16.0 MP | Snapdragon 750G | 6GB | 128 GB', N'Adreno 619 | 4820 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2021-01-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 5)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Xiaomi Redmi Note 10 6GB-128GB ', 10, 5090000.0000, N'6.43", FHD+, AMOLED, 2440 x 1080 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP MP |13.0 MP | Snapdragon 678 | 6GB | 128 GB', N'Adreno 612 | 5000 mAh | 2, Nano SIM | Android 11', NULL, 0.0000, CAST(N'2021-03-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 5)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Xiaomi Redmi Note 9 4GB-128GB ', 10, 4190000.0000, N'6.53", FHD+, IPS LCD, 1080 x 2340 Pixel | 48.0 MP + 8.0 MP + 2.0 MP + 2.0 MP |13.0 MP | Helio G85 | 4GB | 128 GB', N'Mali-G52 MC2 | 5020 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-04-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 5)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Xiaomi Mi 11 5G 8GB-256GB ', 10, 1990000.0000, N'6.81", 2K+, AMOLED, 1440 x 3200 Pixel | 108.0 MP + 13.0 MP + 5.0 MP |20.0 MP | Snapdragon 888 | 8GB | 256 GB', N'Adreno 660 | 4600 mAh | 2, Nano SIM | Android 11', NULL, 0.0000, CAST(N'2021-03-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 5)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Xiaomi Redmi 9 4GB-64GB ', 10, 3190000.0000, N'6.53", FHD+, IPS LCD, 1080 x 2340 Pixel | 13.0 MP + 8.0 MP + 5.0 MP + 2.0 MP |8.0 MP | Helio G80 | 4GB | 64 GB', N'ARM Mali-G52 MC2 | 5020 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-06-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 5)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Xiaomi Poco X3 NFC 6GB-128GB ', 10, 5940000.0000, N'6.67", FHD+, IPS LCD, 1080 x 2400 Pixel | 64.0 MP + 13.0 MP + 2.0 MP + 2.0 MP |20.0 MP | Snapdragon 732G | 6GB | 128 GB', N'Adreno 618 | 5160 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-09-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 5)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES (N'Xiaomi Poco X3 NFC 6GB-128GB ', 10, 5940000.0000, N'6.67", FHD+, IPS LCD, 1080 x 2400 Pixel | 64.0 MP + 13.0 MP + 2.0 MP + 2.0 MP |20.0 MP | Snapdragon 732G | 6GB | 128 GB', N'Adreno 618 | 5160 mAh | 2, Nano SIM | Android 10.0', NULL, 0.0000, CAST(N'2020-09-01' AS Date), N'Trung Quốc', NULL, NULL, NULL, 5)


-- Laptop
	--Macbook
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'MacBook Air 13" 2020 1.1GHz Core i5 512GB', 120, 30990000.0000, N'16.0", 3072 x 1920 Pixel, IPS, IPS LCD LED Backlit, True Tone | Intel Core i5-10th-gen | 8 GB, LPDDR4, 3733 MHz | SSD 512 GB | Intel Iris Plus Graphics', N'Mac OS | 1.29 | 304.1 x 212.4 x 4.1 ~ 16.1', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%', 2000000.0000, CAST(N'2020-01-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 7)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'MacBook Pro 16" 2019 Touch Bar 2.3GHz Core i9 1TB', 120, 69990000.0000, N'13.3", 2560 x 1600 Pixel, IPS, IPS LCD LED Backlit, True Tone | Intel Core i9-9th-gen | 16 GB, DDR4, 2666 MHz | SSD 1 TB | AMD Radeon Pro 5500M 4 GB - Intel UHD Graphics 630', N'Mac OS | 2.0 | 357.9 x 24.59 x 16.2"', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0 , CAST(N'2020-01-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 7)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'MacBook Pro 13" 2020 Touch Bar 2.0GHz Core i5 512GB', 120, 46990000.0000, N'13.3", 2560 x 1600 Pixel, IPS, IPS LCD LED Backlit, True Tone | Intel Core i5-10th-gen | 16 GB, LPDDR4X, 3733 MHz | SSD 512 GB | Intel Iris Plus Graphics', N'Mac OS | 1.4 | 304.1 x 212.4 x 15.6', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0 , CAST(N'2020-01-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 7)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'MacBook Pro 13" 2020 Touch Bar M1 16GB/256GB', 120, 39990000.0000, N'13.3", 2560 x 1600 Pixel, IPS, IPS LCD LED Backlit, True Tone | Apple M1 | 16 GB, LPDDR4 | SSD 256 GB | Apple M1', N'Mac OS | 1.4 | 304.1 x 212.4 x 4.1', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-02-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 7)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'MacBook Pro 13" 2020 Touch Bar M1 256GB ', 120, 30990000.0000, N'13.3", 2560 x 1600 Pixel, IPS, IPS LCD LED Backlit, True Tone | Apple M1 | 8 GB, LPDDR4 | SSD 256 GB | Apple M1', N'Mac OS | 1.4 | 304.1 x 212.4 x 4.1', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-02-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 7)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'MacBook Air 13" 2020 M1 16GB/256GB', 120, 33990000.0000, N'13.3", 2560 x 1600 Pixel, IPS, IPS LCD LED Backlit, True Tone | Apple M1 | 16 GB, LPDDR4 | SSD 256 GB | Apple M1', N'Mac OS | 1.4 | 304.1 x 212.4 x 4.1', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-02-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 7)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'MacBook Air 2017 i5 1.8GHz/8GB/128GB', 120, 19990000.0000, N'13.3", WXGA+(1440 x 900) | Intel Core i5 Broadwell, 1.80 GHz | 8 GB, DDR3L(On board), 1600 MHz | SSD 128 GB |  Intel HD Graphics 6000', N'Mac OS | 1.35 | 325 x 227 x 17', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2017-02-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 7)


INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Asus Strix G512 IAL013T i5 8GB/512G SSD/GTX 1650Ti 4GB/Win10', 120, 22490000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, 250 nits, Anti-glare LED-backlit | Intel Core i5-10300H | 8 GB, DDR4, 3200 MHz | SSD 512 GB |  GeForce GTX 1650 Ti 4GB', N'Windows 10 | 2.39 | 360 x 275 x 21.7', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2021-02-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 8)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Asus TUF FX506LI HN039T i5 10300H/8GB/512GB SSD/Win10', 120, 21790000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, 250 nits, LED Backlit | Intel Core i5-10300H | 8 GB, DDR4, 2933 MHz | SSD 512 GB |  NVIDIA GeForce GTX1650Ti 4Gb', N'Windows 10 | 2.3 | 359 x 256 x 24.7', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2021-01-01' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 8)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Asus Zenbook UX325EA-EG079T i5 1135G7/8GB/256GB SSD/Intel Iris Xe Graphics/Win10', 120, 21790000.0000, N'13.3", 1920 x 1080 Pixel, IPS, 60 Hz, 300 nits, Anti-glare LED-backlit | Intel Core i5-1135G7 | 8 GB, LPDDR4X, 3200 MHz | SSD 256 GB | Intel Iris Xe Graphics', N'Windows 10 | 1.1 | 304.1 x 203.19 x 13.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2021-02-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 8)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Asus Vivobook M413UA EK054T R5 5500U/8GB/512GB SSD/Win10', 120, 15990000.0000, N'14.0", 1920 x 1080 Pixel, 60 Hz, 220 nits, Anti-glare LED-backlit | AMD Ryzen 5-5500U | 8 GB, DDR4, 3200 MHz | SSD 512 GB |  AMD Radeon Graphics', N'Windows 10 | 1.1 | 324 x 213', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2021-02-1' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 8)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Asus Gaming ROG Strix G512-IHN281T i7 10870H/8GB/512GB SSD/GTX1650Ti 4GB/WIN10', 120, 28790000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, 250 nits | Intel Core i7-10870H | 8 GB, DDR4, 2933 MHz | SSD 512 GB |  GeForce GTX 1650 Ti 4GB', N'Windows 10 | 2.28 | 360 x 275 x 20.8', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2021-01-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 8)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Asus TUF Gaming FX516PM HN023T i7 11370H/16GB/512GB SSD/RTX3060_6GB/Win10', 120, 32790000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, 250 nits, IPS LCD LED Backlit, True Tone | Intel Core i7-11370H | 16 GB, DDR4, 3200 MHz | SSD 512 GB |  Geforce RTX 3060 6GB DDR6', N'Windows 10 | 2.0 | 360 x 225 x 19.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2021-03-15' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 8)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Asus VivoBook M413IA-EK481T R7 4700U/8GB/1TB SSD/WIN10', 120, 18790000.0000, N'14.0", 1920 x 1080 Pixel, IPS, 60 Hz, Anti-glare LED-backlit | AMD Ryzen 7-4700U | 8 GB, DDR4, 3200 MHz | SSD 1 TB |  AMD Graphics', N'Windows 10 | 1.45 | 325 x 213 x 16.2', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2021-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 8)

INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Dell G3 15 i5 10300H/2x4GB/256GB+1TB/GTX 1650 4GB/15.6"FHD/Win 10', 120, 22490000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit | Intel Core i5-10300H | 8 GB, DDR4, 2933 MHz | HDD 1000 GB - SSD 256 GB |  GeForce GTX 1650 4GB', N'Windows 10 | 2.34 | 254', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 9)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Dell Inspiron N7501 i7 10750H/8GB/512GB/15.6"FHD/GTX1650Ti 4GB/Win 10', 120, 30290000.0000, N'15.6", 1920 x 1080 Pixel, TFT, 60 Hz, WVA Anti-glare LED Backlit Narrow Border | Intel Core i7-10750H | 8 GB, DDR4, 2933 MHz | SSD 512 GB | NVIDIA® GeForce GTX™ 1650Ti 4Gb', N'Windows 10 | 1.81 | 356 x 234 x 18.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-05-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 9)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Dell Inspiron N5593 i3 1005G1/4Gb/128Gb/15.6"FHD/Win 10 ', 120, 13590000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 60 Hz, LED-backlit | Intel Core i3-1005G1 | 4 GB, DDR4, 2666 MHz | SSD 128 GB |  Intel UHD Graphics', N'Windows 10 | 2.05 | 363.96 x 249 x 19.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2019-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 9)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Dell Inspiron N7490 i5 10210U/8GB/512GB/NVIDIA MX250 2GB/Win 10', 120, 29290000.0000, N'14.0", 1920 x 1080 Pixel, IPS, 60 Hz, 300 nits, Truelife LED-Backlit | Intel Core i5-10210U | 8 GB, LPDDR3, 2133 MHz | SSD 512 GB | GeForce MX250 2GB', N'Windows 10 | 1.32 |319 x 208.5 x 17.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-05-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 9)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Dell Inspiron N3501A i3 1005G1/4GB/256GB/15.6"FHD/Win10', 120, 11990000.0000, N'15.6", 1920 x 1080 Pixel, WVA, 60 Hz, 220 nits | Intel Core i3-1005G1 | 4 GB, DDR4, 2666 MHz | SSD 256 GB |  Intel UHD Graphics', N'Windows 10 | 1.91 | 363.96 x 249 x 18 ~ 19.90', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-01-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 9)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Dell XPS 13 9310 i5 1135G7/8GB/256GB/13.4"FHDTouch/Win 10', 120, 40790000.0000, N'13.4", 1920 x 1080 Pixel, WVA, 60 Hz, 400 nits, LED-backlit | Intel Core i5-1135G7 | 8 GB, LPDDR4, 4266 MHz |SSD 256 GB |  Intel Iris Xe Graphics', N'Windows 10 | 2.32 | 296.9 x 208 x 14.7', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 9)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Dell G5 15 5500 i7 10750H/8GB/512GB/GeForce GTX1660 Ti 6GB/15.6"FHD/Win 10', 120, 30290000.0000, N'15.6", 1920 x 1080 Pixel, WVA, 120 Hz, 250 nits, Anti-glare LED-backlit | Intel Core i7-10750H | 8 GB, DDR4, 2933 MHz | SSD 512 GB |  GeForce RTX1660 Ti 6GB', N'Windows 10 | 2.34 | 365 x 275 x 23.4', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 9)

INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Acer Aspire 3 A315-57G-524Z i5 1035G1/8GB/512GB SSD/MX330-2G/Win10', 120, 16290000.0000, N'15.6", 1920 x 1080 Pixel, TN, 60 Hz, Acer ComfyView LED-backlit | Intel Core i5-1035G1 | 8 GB, DDR4, 2400 MHz | SSD 512 GB | GeForce MX330 2GB', N'Windows 10 | 1.9 | 363.4 x 250.5 x 19.5', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 10)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Acer Nitro 5 AN515 55 5923 i5 10300H/8GB/512GB SSD//Win 10', 120, 21790000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, Acer ComfyView Anti-glare LED-backlit | Intel Core i5-10300H | 8 GB, DDR4, 2933 MHz | SSD 512 GB | GeForce GTX 1650 Ti 4GB', N'Windows 10 | 2.3 | 363.4 x 255 x 23.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 10)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Acer Nitro Gaming AN515 44 R9JM R5 4600H/8GB/512GB SSD/Nvidia GTX1650 4GB/Win10', 120, 20990000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, Acer ComfyView Anti-glare LED-backlit | AMD Ryzen 5-4600H | 8 GB, DDR4, 3200 MHz | SSD 512 GB | GeForce GTX 1650 4GB', N'Windows 10 | 2.17 | 363.4 x 255 x 23.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 10)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Acer Aspire Gaming A715 42G R4ST R5 5500U/8GB/256GB SSD/Nvidia GTX1650 4GB/Win10', 120, 19790000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 60 Hz, Acer ComfyView Anti-glare LED-backlit | AMD Ryzen 5-5500U | 8 GB, DDR4, 2400 MHz | SSD 256 GB | GeForce GTX 1650 4GB', N'Windows 10 | 2.1 | 363.4 x 254.5 x 22.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 10)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Acer Nitro Gaming AN515-55-77P9 i7 10750H/8GB/512GB/GTX1650Ti 4GB/Win 10', 120, 25990000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, LED-backlit | Intel Core i7-10750H | 8 GB, DDR4, 2666 MHz | SSD 512 GB | GeForce GTX 1650 Ti 4GB', N'Windows 10 | 2.3 | 363.4 x 255 x 23.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 10)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Acer Nitro Gaming AN515 45 R0B6 R7 5800H/8GB/512GB SSD/RTX3060-6G/Win10', 120, 31790000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, IPS LCD LED Backlit, True Tone | AMD Ryzen 7-5800H | 8 GB, DDR4, 3200 MHz | SSD 512 GB | NVIDIA GeForce RTX 3060 6GB DDR6', N'Windows 10 | 2.2 | 363.4 x 255 x 23.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 10)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop Acer Aspire Gaming A715 41G R150 R7 3750H/8GB/512GB SSD/Win 10', 120, 21290000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 60 Hz, LED-backlit | AMD Ryzen 7-3750H | 8 GB, DDR4, 2666 MHz | SSD 512 GB | GeForce GTX 1650 Ti 4GB', N'Windows 10 | 2.1 | 363.4 x 254.5 x 23.25', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 10)

INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop HP 15s fq1107TU i3 1005G1/4GB/256GB SSD/WIN10', 120, 10990000.0000, N'15.6", 1366 x 768 Pixel, SVA, 60 Hz, 220 nits, Micro-edge WLED-backlit | Intel Core i3-1005G1 | 4 GB, DDR4, 2666 MHz | SSD 256 GB | Intel UHD Graphics 620', N'Windows 10 | 1.65 | 358.8 x 242.2 x 17.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 11)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop HP Pavilion 15 eg0003TX i5 1135G7/4GB/256GB/2GB MX450/Win10+OfficeHome&Student', 120, 17390000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit | Intel Core i5-1135G7 | 4 GB, DDR4, 3200 MHz | SSD 256 GB | NVIDIA GeForce MX450 2GB', N'Windows 10 | 1.726 | 360 x 234 x 17.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2021-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 11)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop HP 15s fq2027TU i5 1135G7/8GB/512GB/Intel Graphics/15.6"HD/Win 10', 120, 16390000.0000, N'15.6", 1366 x 768 Pixel, SVA, 60 Hz, 250 nits, Ultra Slim | Intel Core i5-1135G7 | 8 GB, DDR4, 2666 MHz | SSD 512 GB | Intel Iris Xe Graphics', N'Windows 10 | 1.91 | 358.5 x 242 x 18', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 11)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop HP Pavilion x360 14 dw1017TU i3 1115G4/4GB/512GB/Pen/Win 10+Office Home&Student', 120, 15190000.0000, N'14.0", 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, WLED-backlit | Intel Core i3-1115G4 | 4 GB, DDR4, 3200 MHz | SSD 512 GB | Intel UHD Graphics', N'Windows 10 | 1.64 | 324 x 221.7 x 19', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 11)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop HP Envy 13 ba1028TU i5 1135G7/8GB/512GB/Win 10/Office Home& Student', 120, 23390000.0000, N'13.3", 1920 x 1080 Pixel, IPS, 60 Hz, 400 nits, LED-backlit | Intel Core i5-1135G7 | 8 GB, DDR4, 3200 MHz | SSD 512 GB | Intel Iris Xe Graphics', N'Windows 10 | 1.31 | 358.8 x 242.2 x 17.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 11)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop HP Pavilion 15 eg0008TU i3 1115G4/4GB/256GB/15.6FHD/Win10+OfficeHome&Student', 120, 14190000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare WLED-backlit | Intel Core i3-1115G4 | 4 GB, DDR4, 3200 MHz | SSD 256 GB | Intel UHD Graphics', N'Windows 10 | 1.65 | 360 x 234 x 17.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 11)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop HP Pavilion 14 dv0009TU i5 1135G7/8GB/512GB/14"FHD/Win 10+Office Home&Student', 120, 17890000.0000, N'14.0", 1920 x 1080 Pixel, IPS, 60 Hz, 250 nits, Anti-glare LED-backlit | Intel Core i5-1135G7 | 8 GB, DDR4, 3200 MHz | SSD 512 GB | Intel Iris Xe Graphics', N'Windows 10 | 1.41 | 325 x 242.2 x 17.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 11)

INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop MSI GF63 Thin 10SCXR 052VN i7 10750H/8GB/512GB/15.6" FHD/GTX1650 MaxQ 4GB/Win 10', 120, 20990000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 60 Hz | Intel Core i7-10750H | 8 GB, DDR4, 3200 MHz | SSD 512 GB | GeForce GTX 1650 MaxQ 4GB', N'Windows 10 | 1.86 | 359 x 254 x 21.7', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 12)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop MSI Modern 14 B11MO-004VN i5 1135G7/8GB/512GB SSD/Intel Iris Xe Graphics/Win10', 120, 19290000.0000, N'14.0", 1920 x 1080 Pixel, IPS, 60 Hz| Intel Core i5-1135G7 | 8 GB, DDR4, 3200 MHz | SSD 512 GB | Intel Iris Xe Graphics', N'Windows 10 | 1.3 | 319 x 219 x 16.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 12)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop MSI Gaming GF63 10SC 255VN i5 10300H/8GB/512GB/GTX 1650 4GB/15.6"FHD/Win10', 120, 20390000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, 300 nits, IPS LCD LED Backlit, True Tone | Intel Core i5-10300H | 8 GB, DDR4, 3200 MHz | SSD 512 GB | NVIDIA® GeForce® GTX 1650 Max Q- 4GB', N'Windows 10 | 1.86 | 359 x 254 x 21.7', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 12)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop MSI GF63 9SCSR-846VN i7 9750H/8GB/512GB SSD/GTX 1650Ti-4GB/Win10', 120, 24290000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, 250 nits, IPS LCD LED Backlit, True Tone | Intel Core i7-9750H | 8 GB, 2666 MHz | SSD 512 GB | GeForce GTX 1650 Ti 4GB', N'Windows 10 | 1.86 | 359 x 254 x 21.7', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 12)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop MSI Bravo 15 A4DCR-270VN R5 4600H/8GB/256GB/AMD RX5300M-3GB/Win10', 120, 19790000.0000, N'15.6", 1920 x 1080 Pixel, 144 Hz | AMD Ryzen 5-4600H | 8 GB, DDR4, 3200 MHz | SSD 256 GB | AMD Radeon R5300M-3GB DDR6', N'Windows 10 | 1.96 | 359 x 254 x 21.7', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 12)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop MSI Modern 14 B10MW 427VN i3 10110U/8GB/256GB/14"FHD/Win 10', 120, 13990000.0000, N'14.0", 1920 x 1080 Pixel, IPS, 60 Hz, 300 nits, Acer ComfyView Anti-glare LED-backlit | Intel Core i3-10110U | 8 GB, DDR4, 3200 MHz | SSD 256 GB | Intel UHD Graphics', N'Windows 10 | 1.3 | 320 x 220.3 x 16.9', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 12)
INSERT Into SanPham (tenSanPham, soLuong, donGia, moTa, moTaChiTiet, khuyenMai, giamGia, ngayCapNhat, xuatXu, hinhMinhHoa, dsHinh, tinhTrang, maDanhMuc) VALUES ( N'Laptop MSI GL65 Leopard 10SCXK-093VN i7 10750H/8GB/512GB/15.6"FHD/GTX1650 4Gb/Win 10', 120, 24790000.0000, N'15.6", 1920 x 1080 Pixel, IPS, 144 Hz, IPS LCD LED Backlit, True Tone | Intel Core i7-10750H | 8 GB, DDR4, 2666 MHz | SSD 512 GB | NVIDIA® GeForce® GTX1650 4GB', N'Windows 10 | 2.3 | 357 x 248 x 27.5', N'Giảm ngay 4.000.000đ khi mua Online áp dụng đến 14/12 | Tặng Balo Laptop | Thu cũ đổi mới – Trợ giá ngay 15%',0, CAST(N'2020-03-02' AS Date), N'Trung Quốc', N'MBA-13.JPG', NULL, NULL, 12)




Insert into Banner(fileBanner, kichHoat, ghiChu) values('Hinh1.jpg',1,'new')
Insert into Banner(fileBanner, kichHoat, ghiChu) values('Hinh2.jpg',0,'new')
Insert into Banner(fileBanner, kichHoat, ghiChu) values('Hinh3.jpg',0,'new')
