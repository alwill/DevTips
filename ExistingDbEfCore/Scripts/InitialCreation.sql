CREATE DATABASE ExistingScaffold;
GO

USE ExistingScaffold;
GO

CREATE TABLE [Order] (
    Id int PRIMARY KEY,
    Name nvarchar(max) NOT NULL,
    Total int
);
GO

CREATE TABLE [Item] (
    Id int PRIMARY KEY,
    Name NVARCHAR(max) NOT NULL,
    OrderId int,
    FOREIGN KEY (OrderId) REFERENCES [Order](Id)
);
GO

INSERT INTO [Order] (Id,[Name], Total)
VALUES (1, 'Test Ordder', 300);
GO

INSERT INTO [Item] (Id, [Name], OrderId)
VALUES (1, 'Item', 1);
GO
