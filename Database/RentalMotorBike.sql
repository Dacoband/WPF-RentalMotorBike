-- Tạo cơ sở dữ liệu RentalMotoBike
CREATE DATABASE RentalMotoBike;

-- Sử dụng cơ sở dữ liệu RentalMotoBike
USE RentalMotoBike;

-- Tạo bảng Role
CREATE TABLE Role (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);

-- Tạo bảng Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    RoleID INT NOT NULL,
    FOREIGN KEY (RoleID) REFERENCES Role(RoleID) ON DELETE CASCADE
);

-- Tạo bảng MotorbikeStatus (bảng trạng thái xe máy)
CREATE TABLE MotorbikeStatus (
    StatusID INT PRIMARY KEY IDENTITY(1,1),
    StatusName NVARCHAR(50) NOT NULL
);

-- Tạo bảng Motorbike
CREATE TABLE Motorbike (
    MotorbikeID INT PRIMARY KEY IDENTITY(1,1),
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    LicensePlate NVARCHAR(20) NOT NULL,
    RentalPricePerDay DECIMAL(18, 2) NOT NULL,
    StatusID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES MotorbikeStatus(StatusID)
);

-- Tạo bảng Rental (bảng thuê xe)
CREATE TABLE Rental (
    RentalID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NULL,  -- Nếu người dùng bị xóa, đặt UserID là NULL
    MotorbikeID INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE SET NULL,
    FOREIGN KEY (MotorbikeID) REFERENCES Motorbike(MotorbikeID)
);

-- Tạo bảng RentalDetail (chi tiết thuê xe)
CREATE TABLE RentalDetail (
    RentalDetailID INT PRIMARY KEY IDENTITY(1,1),
    RentalID INT NOT NULL,
    DaysRented INT NOT NULL,
    DailyPrice DECIMAL(18, 2) NOT NULL,
    TotalCost DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (RentalID) REFERENCES Rental(RentalID) ON DELETE CASCADE
);

-- Tạo bảng Maintenance (bảo trì)
CREATE TABLE Maintenance (
    MaintenanceID INT PRIMARY KEY IDENTITY(1,1),
    MotorbikeID INT NOT NULL,
    UserID INT NOT NULL,  -- Người bảo trì là User có role Employee
    MaintenanceDate DATETIME NOT NULL,
    Description NVARCHAR(255),
    Cost DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (MotorbikeID) REFERENCES Motorbike(MotorbikeID) ON DELETE CASCADE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
