CREATE DATABASE TrungTamTiengAnh;
GO
USE TrungTamTiengAnh;
GO

CREATE TABLE TaiKhoan (
    MaTK INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL DEFAULT 'NhanVien'
);
GO

CREATE TABLE GiangVien (
    MaGV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    SDT NVARCHAR(15),
    Email NVARCHAR(100),
    ChuyenMon NVARCHAR(100)
);
GO

CREATE TABLE HocVien (
    MaHV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    SDT NVARCHAR(15),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(200)
);
GO

CREATE TABLE KhoaHoc (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255),
    HocPhi DECIMAL(18,2) NOT NULL DEFAULT 0,
    ThoiLuong INT NOT NULL DEFAULT 0,
    MaGV INT NULL,
    CONSTRAINT FK_KhoaHoc_GiangVien FOREIGN KEY (MaGV) REFERENCES GiangVien(MaGV)
);
GO

CREATE TABLE DangKyHoc (
    MaDK INT IDENTITY(1,1) PRIMARY KEY,
    MaHV INT NOT NULL,
    MaKH INT NOT NULL,
    NgayDangKy DATE NOT NULL DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Đang học',
    CONSTRAINT FK_DangKy_HocVien FOREIGN KEY (MaHV) REFERENCES HocVien(MaHV),
    CONSTRAINT FK_DangKy_KhoaHoc FOREIGN KEY (MaKH) REFERENCES KhoaHoc(MaKH)
);
GO

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro) VALUES ('admin', '123456', 'Admin');

INSERT INTO GiangVien (HoTen, GioiTinh, NgaySinh, SDT, Email, ChuyenMon) VALUES
(N'Nguyễn Văn An', N'Nam', '1985-03-12', '0901111111', 'an.nguyen@tta.edu.vn', N'Tiếng Anh giao tiếp'),
(N'Trần Thị Bình', N'Nữ', '1990-07-22', '0902222222', 'binh.tran@tta.edu.vn', N'IELTS');

INSERT INTO HocVien (HoTen, GioiTinh, NgaySinh, SDT, Email, DiaChi) VALUES
(N'Lê Thị Hoa', N'Nữ', '2003-05-10', '0911111111', 'hoa.le@gmail.com', N'TP.HCM'),
(N'Phạm Văn Long', N'Nam', '2002-11-02', '0922222222', 'long.pham@gmail.com', N'Hà Nội');

INSERT INTO KhoaHoc (TenKH, MoTa, HocPhi, ThoiLuong, MaGV) VALUES
(N'Tiếng Anh giao tiếp cơ bản', N'Khóa học cho người mới bắt đầu', 1500000, 30, 1),
(N'IELTS Foundation', N'Luyện thi IELTS từ 0 - 5.0', 3000000, 45, 2);

INSERT INTO DangKyHoc (MaHV, MaKH, NgayDangKy, TrangThai) VALUES
(1, 1, '2026-05-01', N'Đang học'),
(2, 2, '2026-05-03', N'Đang học');
GO
