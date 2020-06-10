CREATE DATABASE InventoryDb
GO
USE InventoryDb

CREATE TABLE Cars(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
make NVARCHAR(10),
model  NVARCHAR(10),
year int,
color NVARCHAR(10)
);

INSERT INTO Cars(make, model, year, color)
VALUES
('Ford', 'Escort', 1998, 'Silver'),
('Toyota', 'Prius', 2014, 'Red'),
('BMW', 'M5', 2010, 'Black')