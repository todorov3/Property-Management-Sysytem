﻿CREATE DATABASE PropertyManagementDB
GO

USE PropertyManagementDB
GO

CREATE TABLE Users
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(35) NOT NULL,
	LastName NVARCHAR(35) NOT NULL,
	Username NVARCHAR(35) NOT NULL UNIQUE,
	Email NVARCHAR(75) NOT NULL UNIQUE,
	PhoneNumber NVARCHAR(14) NOT NULL UNIQUE,
	UserPassword NVARCHAR(35) NOT NULL,
	IsAdmin BIT DEFAULT 0,
	IsActive BIT DEFAULT 1,
	IsDeleted BIT DEFAULT 0,
	UserPhoto VARBINARY(MAX),
	CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY,
	TownName NVARCHAR(75) NOT NULL,
);

CREATE TABLE Properties
(
	Id INT IDENTITY PRIMARY KEY,
	LandlordId INT NOT NULL,
	TownId INT NOT NULL,
	PropertyType INT NOT NULL,
	Area INT NOT NULL,
	NumOfRooms INT,
	NumOfFloors INT,
	NumOfBedrooms INT,
	NumOfBathrooms INT,
	PetsAllowed BIT DEFAULT 0,
	YardArea INT DEFAULT 0,
	Price DECIMAL(10, 2),
	Photo VARBINARY(MAX),
	FreeDates DATETIME,
	IsArchived BIT DEFAULT 0,
	IsDeleted BIT DEFAULT 0,
	FOREIGN KEY(LandlordId) REFERENCES Users(Id),
	FOREIGN KEY(TownId) REFERENCES Towns(Id)
);

CREATE TABLE Requests
(
	Id INT IDENTITY PRIMARY KEY,
	TenandId INT NOT NULL,
	PropertyId INT NOT NULL,
	MoveIn DATETIME NOT NULL,
	MoveOut DATETIME NOT NULL,
	IsAccepted INT DEFAULT 0,
	IsDeleted BIT DEFAULT 0
	FOREIGN KEY(TenandId) REFERENCES Users(Id),
	FOREIGN KEY(PropertyId) REFERENCES Properties(Id)
);

CREATE TABLE Feedbacks
(
	Id INT IDENTITY PRIMARY KEY,
	RequestId INT NOT NULL,
	Content NVARCHAR(150) NOT NULL,
	AuthorId INT NOT NULL,
	CommentedUserId INT NOT NULL,
	IsAuthorLandlord BIT,
	Rating INT NOT NULL,
	CreatedDate DATETIME DEFAULT GETDATE(),
	FOREIGN KEY(RequestId) REFERENCES Requests(Id),
	FOREIGN KEY(AuthorId) REFERENCES Users(Id),
	FOREIGN KEY(CommentedUserId) REFERENCES Users(Id)
);
