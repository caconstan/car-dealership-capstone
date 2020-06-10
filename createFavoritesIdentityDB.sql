USE IdentityDb

CREATE TABLE FavoriteCars(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
carid int,
userid NVARCHAR(450)
);

 insert into FavoriteCars values (1,1);