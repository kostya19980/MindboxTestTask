CREATE DATABASE StoreDB;
GO
USE StoreDB;
CREATE TABLE Products
(
    Id INT PRIMARY KEY,
    Name VARCHAR(100),
)
CREATE TABLE Categories 
(
	Id INT PRIMARY KEY,
	Name VARCHAR(100)
);
CREATE TABLE ProductCategories (
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	PRIMARY KEY (ProductId, CategoryId)
);
INSERT INTO Products 
VALUES
(1,'iPhone SE 2022'),
(2,'MSI Modern 15 B11M-003XRU'),
(3,'GIGABYTE [GP-GSTFS31256GTND]'),
(4,'NoCatProduct')
INSERT INTO Categories 
VALUES
(1,'Smartphone'),
(2,'Laptop'),
(3,'SSD'),
(4,'Phone'),
(5,'Disk')
INSERT INTO ProductCategories
VALUES
	(1, 1),
	(1, 4),
	(2, 2),
	(3, 3),
	(3, 5);

SELECT P.Name, C.Name
FROM Products AS P
LEFT JOIN ProductCategories AS PC
	ON P.Id = PC.ProductId
LEFT JOIN Categories AS C
	ON PC.CategoryId = C.Id;