USE CRM_System;

IF OBJECT_ID('dbo.Order', 'U') IS NOT NULL
DROP TABLE dbo.[Order]
CREATE TABLE [Order] (
	orderID int IDENTITY(1,1),
	clientID int NOT NULL,
	[desc] nvarchar(100) NULL,
	orderDate date NOT NULL,
	price money NOT NULL,

	CONSTRAINT FK_OrderClientID FOREIGN KEY (clientID)
	REFERENCES Client (clientID)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
)

IF OBJECT_ID('dbo.Client', 'U') IS NOT NULL
DROP TABLE dbo.[Client]
CREATE TABLE [Client] (
	clientID int IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	firstName nvarchar(20) NOT NULL,
	middleName nvarchar(20) NOT NULL,
	lastName nvarchar(20) NOT NULL,
	birthdate datetime NOT NULL
)

INSERT INTO Client (firstName, middleName, lastName, birthdate) VALUES
	('1', '1', '1', 2002-09-04),
	('2', '2', '2', 2003-10-24),
	('3', '3', '3', 2000-01-15),
	('a', 'b', 'c', 2001-07-14),
	('4', '4', '4', 2012-03-09),
	('r', 'a', 'm', 2002-05-05),
	('d', 'v', 'd', 2002-04-20)


