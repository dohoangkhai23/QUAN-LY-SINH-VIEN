﻿CREATE DATABASE QLYSV1
GO
USE QLYSV1

CREATE TABLE KHOA(
MAKHOA VARCHAR(10) PRIMARY KEY,
TENKHOA NVARCHAR(100)
);

CREATE TABLE NGANHHOC(
MANGANH VARCHAR(20) PRIMARY KEY,
TENNGANH NVARCHAR(200),
MAKHOA VARCHAR(10),
FOREIGN KEY (MAKHOA) REFERENCES KHOA(MAKHOA)
);

CREATE TABLE LOPHOC(
MALOP VARCHAR(50) PRIMARY KEY,
TENLOP NVARCHAR(200),
MANGANH VARCHAR(20),
FOREIGN KEY (MANGANH) REFERENCES NGANHHOC(MANGANH)
);

CREATE TABLE SINHVIEN(
MASV VARCHAR(50) PRIMARY KEY,
HOTEN NVARCHAR(100),
GIOITINH NVARCHAR(100),
SODIENTHOAI VARCHAR(10),
DIACHI NVARCHAR(100),
NGAYSINH DATE,
MALOP VARCHAR(50),
FOREIGN KEY (MALOP) REFERENCES LOPHOC(MALOP)
);

CREATE TABLE DANGNHAP(
MASV VARCHAR(50) PRIMARY KEY,
HOTEN NVARCHAR(100),
MATKHAU VARCHAR(50),
QUYEN NVARCHAR(50)
FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV)
);

CREATE TABLE MONHOC(
MAMH VARCHAR(10) PRIMARY KEY,
TENMH NVARCHAR(100),
SOTINCHI INT
);

CREATE TABLE KETQUA(
    MASO INT PRIMARY KEY,
    MASV VARCHAR(50),
    MAMH VARCHAR(10),
    Diem FLOAT,
    KETQUA NVARCHAR(20),
	FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV),
    FOREIGN KEY (MAMH) REFERENCES MONHOC(MAMH)
);

INSERT INTO KHOA (MAKHOA, TENKHOA)
VALUES('K01',N'Khoa Công nghệ thông tin')
INSERT INTO KHOA (MAKHOA, TENKHOA)
VALUES('K02',N'Khoa Kinh tế')

SELECT*FROM KHOA

INSERT INTO NGANHHOC (MANGANH, TENNGANH, MAKHOA)
VALUES('N01', N'Ngành Khoa học máy tính', 'K01')
INSERT INTO NGANHHOC (MANGANH, TENNGANH, MAKHOA)
VALUES('N02', N'Ngành Hệ thống thông tin', 'K01')
INSERT INTO NGANHHOC (MANGANH, TENNGANH, MAKHOA)
VALUES('N03', N'Ngành Quản trị kinh doanh', 'K02')


INSERT INTO LOPHOC (MALOP, TENLOP, MANGANH)
VALUES('L01', N'Lớp Khoa học máy tính 1', 'N01')
INSERT INTO LOPHOC (MALOP, TENLOP, MANGANH)
VALUES('L02', N'Lớp Hệ thống thông tin 1', 'N02')
INSERT INTO LOPHOC (MALOP, TENLOP, MANGANH)
VALUES('L03', N'Lớp Quản trị kinh doanh 1', 'N03')


INSERT INTO SINHVIEN (MASV, HOTEN, GIOITINH, SODIENTHOAI, DIACHI, NGAYSINH, MALOP)
VALUES('SV01', N'Nguyễn Văn A', 'Nam', '0123456789', 'Hà Nội', '2000-01-01', 'L01')
INSERT INTO SINHVIEN (MASV, HOTEN, GIOITINH, SODIENTHOAI, DIACHI, NGAYSINH, MALOP)
VALUES('SV02', N'Trần Thị B', 'Nữ', '0987654321', 'Hồ Chí Minh', '2001-02-02', 'L02')
INSERT INTO SINHVIEN (MASV, HOTEN, GIOITINH, SODIENTHOAI, DIACHI, NGAYSINH, MALOP)
VALUES('SV03', N'Nguyễn Văn C', 'Nam', '03494893445', 'Hồ Chí Minh', '2001-05-02', 'L03')

SELECT*FROM SINHVIEN

INSERT INTO DANGNHAP (MASV, HOTEN, MATKHAU, QUYEN)
VALUES('SV01', N'Nguyễn Văn A', 'password123', 'SinhVien')
INSERT INTO DANGNHAP (MASV, HOTEN, MATKHAU, QUYEN)
VALUES('SV02', N'Trần Thị B', 'password456', 'SinhVien')


INSERT INTO MONHOC (MAMH, TENMH, SOTINCHI)
VALUES('MH01', N'Toán cao cấp', 3)
INSERT INTO MONHOC (MAMH, TENMH, SOTINCHI)
VALUES('MH02', N'Lập trình C++', 4)


INSERT INTO KETQUA (MASO, MASV, MAMH, Diem, KETQUA)
VALUES(1, 'SV01', 'MH01', 9.0, 'Đạt')
INSERT INTO KETQUA (MASO, MASV, MAMH, Diem, KETQUA)
VALUES(2, 'SV02', 'MH02', 8.5, 'Đạt')