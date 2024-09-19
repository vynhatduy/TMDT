-- Tạo database
CREATE DATABASE TMDT;
GO
USE TMDT;
GO

-- Tạo bảng

-- 1. Bảng Role
CREATE TABLE Role (
    RoleId INT PRIMARY KEY,
    RoleName VARCHAR(255) NOT NULL
);

-- 2. Bảng User
CREATE TABLE [User] (
    UID UNIQUEIDENTIFIER PRIMARY KEY,
    HoTen NVARCHAR(255) NOT NULL,
    GioTinh BIT,
    DiaChi NVARCHAR(255),
    SDT NVARCHAR(20) UNIQUE,
    NgaySinh DATE
);

-- 3. Bảng Account
CREATE TABLE Account (
    UID UNIQUEIDENTIFIER PRIMARY KEY REFERENCES [User](UID),
    RoleId INT FOREIGN KEY REFERENCES Role(RoleId),
    Username NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Status BIT,
    Shop BIT,
    CreateDate DATE
);

-- 4. Bảng Shops
CREATE TABLE Shops (
    IDShop INT PRIMARY KEY,
    UID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Account(UID),
    TenShop NVARCHAR(255) NOT NULL,
    Mota NVARCHAR(MAX),
    DiaChi NVARCHAR(255),
    Sao FLOAT,
    CreateDate DATE
);

-- 5. Bảng DanhMuc
CREATE TABLE DanhMuc (
    IDDanhMuc INT PRIMARY KEY,
    Ten NVARCHAR(255) NOT NULL,
    HinhAnh NVARCHAR(MAX) -- Thay đổi độ dài thành MAX
);

-- 6. Bảng Loai
CREATE TABLE Loai (
    IDLoai INT PRIMARY KEY,
    Ten NVARCHAR(255) NOT NULL,
    IDDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(IDDanhMuc)
);

-- 7. Bảng SanPham
CREATE TABLE SanPham (
    IDSanPham VARCHAR(50) PRIMARY KEY,
    HinhAnh NVARCHAR(MAX), -- Thay đổi độ dài thành MAX
    Ten NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(MAX),
    MoTaChiTiet NVARCHAR(MAX),
    IDLoai INT FOREIGN KEY REFERENCES Loai(IDLoai),
    IDShop INT FOREIGN KEY REFERENCES Shops(IDShop),
    GiaBan DECIMAL(18, 2),
    SoLuong INT,
    DaBan INT
);

-- 8. Bảng Vouchers
CREATE TABLE Vouchers (
    IDVouchers VARCHAR(50) PRIMARY KEY,
    Ten NVARCHAR(255),
    HinhAnh NVARCHAR(MAX), -- Thay đổi độ dài thành MAX
    Giam DECIMAL(18, 2),
    DonViTinh NVARCHAR(50),
    PhamViApDung NVARCHAR(255),
    SoLuong INT,
    SoLuongConlai INT
);

-- 9. Bảng HoaDon
CREATE TABLE HoaDon (
    IDHoaDon VARCHAR(50) PRIMARY KEY,
    UID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Account(UID),
    NgayTao DATE,
    TrangThai NVARCHAR(50),
    ThanhTien DECIMAL(18, 2),
    IDVouchers VARCHAR(50) FOREIGN KEY REFERENCES Vouchers(IDVouchers),
	IDShop INT FOREIGN KEY REFERENCES Shops(IDShop),
);

-- 10. Bảng CTHoaDon
CREATE TABLE CTHoaDon (
    IDHoaDon VARCHAR(50) FOREIGN KEY REFERENCES HoaDon(IDHoaDon),
    IDSanPham VARCHAR(50) FOREIGN KEY REFERENCES SanPham(IDSanPham),
    SoLuong INT,
    DonGia DECIMAL(18, 2),
    PRIMARY KEY (IDHoaDon, IDSanPham)
);

-- 11. Bảng DanhGia
CREATE TABLE DanhGia (
    IDDanhGia VARCHAR(50) PRIMARY KEY,
    UID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Account(UID),
    IDSanPham VARCHAR(50) FOREIGN KEY REFERENCES SanPham(IDSanPham),
    TieuDe NVARCHAR(255),
    ChiTiet NVARCHAR(MAX),
    Sao FLOAT,
    HinhAnh NVARCHAR(MAX) -- Thay đổi độ dài thành MAX
);

-- 12. Bảng Ultility
CREATE TABLE Ultility (
    IDTienIch INT PRIMARY KEY,
    Ten NVARCHAR(255) NOT NULL,
    TrangThai BIT,
    PhamViApDung NVARCHAR(255),
    HinhAnh NVARCHAR(MAX) -- Thay đổi độ dài thành MAX
);

-- 13. Bảng MyUtility
CREATE TABLE MyUtility (
    IDTienIch INT FOREIGN KEY REFERENCES Ultility(IDTienIch),
    UID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Account(UID),
    PRIMARY KEY (IDTienIch, UID)
);

-- 14. Bảng MyVouchers
CREATE TABLE MyVouchers (
    IDVouchers VARCHAR(50) FOREIGN KEY REFERENCES Vouchers(IDVouchers),
    UID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Account(UID),
    PRIMARY KEY (IDVouchers, UID)
);

-- 15. Bảng Banner
CREATE TABLE Banner(
    IDBanner INT PRIMARY KEY IDENTITY(1,1),
    Link NVARCHAR(100),
    HinhAnh NVARCHAR(MAX), -- Thay đổi độ dài thành MAX
    TrangThai BIT
);
CREATE TABLE GioHang (
    IDGioHang INT PRIMARY KEY IDENTITY(1,1),
    UID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Account(UID),
    NgayTao DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE ChiTietGioHang (
    IDChiTiet INT PRIMARY KEY IDENTITY(1,1),
    IDGioHang INT FOREIGN KEY REFERENCES GioHang(IDGioHang),
    IDSanPham VARCHAR(50) FOREIGN KEY REFERENCES SanPham(IDSanPham),
    SoLuong INT NOT NULL,
    Gia DECIMAL(18, 2) NOT NULL,
    ThanhTien AS (SoLuong * Gia),
	IDShop INT FOREIGN KEY REFERENCES Shops(IDShop),
);


-- Chèn dữ liệu vào bảng Role
INSERT INTO Role (RoleId, RoleName) VALUES (0, 'Admin');
INSERT INTO Role (RoleId, RoleName) VALUES (1, 'User');

INSERT INTO Ultility (IDTienIch, Ten, HinhAnh, PhamViApDung, TrangThai) VALUES 
(0, 'Freeship-Xtra', '~/App_Data/freeship-xtra.png', '', 1),
(1, 'Voucher-Xtra', '~/App_Data/voucher-xtra.png', '', 1),
(3, 'Mã giảm giá', '~/App_Data/magiamgia.png', '', 1),
(4, 'Hàng quốc tế', '~/App_Data/hangquocte.png', '', 1);
