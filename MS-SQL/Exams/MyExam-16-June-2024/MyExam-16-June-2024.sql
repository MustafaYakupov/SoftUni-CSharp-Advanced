CREATE DATABASE LibraryDb 

GO

USE LibraryDb 

GO

-- Problem 01 DDL
CREATE TABLE Contacts
(
	Id INT PRIMARY KEY IDENTITY
	,Email NVARCHAR(100) 
	,PhoneNumber NVARCHAR(20) 
	,PostAddress NVARCHAR(200) 
	,Website NVARCHAR(50) 
)

CREATE TABLE Authors
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(100) NOT NULL
	,ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY
	,Title NVARCHAR(100) NOT NULL
	,YearPublished INT NOT NULL
	,ISBN NVARCHAR(13) NOT NULL
	,AuthorId INT FOREIGN KEY REFERENCES Authors(Id) NOT NULL
	,GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
)

CREATE TABLE Libraries
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(50) NOT NULL
	,ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE LibrariesBooks
(
	LibraryId INT FOREIGN KEY REFERENCES Libraries(Id) NOT NULL
	,BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL
	,PRIMARY KEY(LibraryId, BookId)
)

GO

-- Problem 02
INSERT INTO Contacts(Email, PhoneNumber, PostAddress, Website)
VALUES 
	(NULL, NULL, NULL, NULL)
	,(NULL, NULL, NULL, NULL)
	,('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com')
	,('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

INSERT INTO Authors([Name], ContactId)
VALUES 
	('George Orwell', 21)
	,('Aldous Huxley', 22)
	,('Stephen King', 23)
	,('Suzanne Collins', 24)

INSERT INTO Books(Title, YearPublished, ISBN, AuthorId, GenreId)
VALUES 
	('1984', 1949, '9780451524935', 16, 2)
	,('Animal Farm', 1945, '9780451526342'	, 16, 2)
	,('Brave New World', 1932, '9780060850524', 17, 2)
	,('The Doors of Perception', 1954, '9780060850531', 17, 2)
	,('The Shining', 1977, '9780307743657', 18, 9)
	,('It', 1986, '9781501142970', 18, 9)
	,('The Hunger Games', 2008, '9780439023481', 19, 7)
	,('Catching Fire', 2009, '9780439023498', 19, 7)
	,('Mockingjay', 2010, '9780439023511', 19, 7)

INSERT INTO LibrariesBooks(LibraryId, BookId)
VALUES 
	(1, 36)
	,(1, 37)
	,(2, 38)
	,(2, 39)
	,(3, 40)
	,(3, 41)
	,(4, 42)
	,(4, 43)
	,(5, 44)

GO

-- Problem 03
UPDATE Contacts 
SET Website = CONCAT_WS('.', 'www', LOWER(REPLACE(a.[Name], ' ', '')), 'com')
FROM Authors AS a
JOIN Contacts AS c ON a.ContactId = c.Id
WHERE c.Website IS NULL

GO

-- Problem 04
DELETE
FROM LibrariesBooks
WHERE BookId = 1

DELETE
FROM Books
WHERE AuthorId = 1

DELETE
FROM Authors
WHERE Id = 1

GO

-- Problem 05
SELECT 
	Title AS [Book Title]
	,ISBN
	,YearPublished AS YearReleased
FROM Books
ORDER BY YearPublished DESC, Title

GO

-- Problem 06
SELECT 
	b.Id
	,b.Title
	,b.ISBN
	,g.[Name] AS Genre
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
WHERE g.[Name] = 'Biography' OR g.[Name] = 'Historical Fiction' 
ORDER BY g.[Name], b.Title

-- Problem 07
SELECT 
	l.[Name] AS [Library]
	,c.Email 
FROM Libraries AS l
JOIN LibrariesBooks AS lb ON l.Id = lb.LibraryId
JOIN Books AS b ON lb.BookId = b.Id
JOIN Genres AS g ON g.Id = b.GenreId
JOIN Contacts AS c ON l.ContactId = c.Id
WHERE g.[Name] NOT LIKE '%Mystery%'
AND l.[Name] NOT LIKE 'City Lights'
GROUP BY l.[Name], c.Email
ORDER BY l.[Name]

-- Problem 08
SELECT TOP (3)
	b.Title
	,b.YearPublished AS [Year]
	,g.[Name] AS Genre
FROM Books AS b 
JOIN Genres AS g ON g.Id = b.GenreId
WHERE b.YearPublished > 2000 AND b.Title LIKE '%a%'
OR  b.YearPublished < 1950 AND g.[Name] LIKE '%Fantasy%'
ORDER BY b.Title, b.YearPublished DESC

-- Problem 09
SELECT 
	a.[Name] AS Author
	,c.Email
	,c.PostAddress AS Address
FROM Authors AS a 
JOIN Contacts AS c ON a.ContactId = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.[Name]

-- Problem 10
SELECT 
	a.[Name] AS Author
	,b.Title
	,l.[Name] AS [Library]
	,c.PostAddress AS [Library Address]
FROM Books AS b
JOIN LibrariesBooks AS lb ON lb.BookId = b.Id
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Contacts AS c ON l.ContactId = c.Id
JOIN Genres AS g ON b.GenreId = g.Id
JOIN Authors AS a ON b.AuthorId = a.Id
WHERE g.[Name] = 'Fiction' 
AND c.PostAddress LIKE '%Denver%'
GROUP BY a.[Name], b.Title, l.[Name], c.PostAddress
ORDER BY b.Title

GO

-- Problem 11
CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(50))
RETURNS INT AS
BEGIN
	DECLARE @CountOfBooksByAuthor INT

	SET @CountOfBooksByAuthor = 
	(
		SELECT COUNT(*)
		FROM Books AS b
		JOIN Authors AS a ON b.AuthorId = a.Id
		WHERE a.[Name] = @name
	)

	RETURN @CountOfBooksByAuthor
END

GO

SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling')

GO

-- Problem 12
CREATE PROC usp_SearchByGenre(@genreName NVARCHAR(50))
AS
BEGIN
	SELECT 
		b.Title
		,b.YearPublished AS [Year]
		,b.ISBN
		,a.[Name] AS Author
		,g.[Name] AS Genre
	FROM Books AS b
	JOIN Genres AS g ON g.Id = b.GenreId
	JOIN Authors AS a ON b.AuthorId = a.Id
	WHERE g.[Name] = @genreName
	ORDER BY b.Title
END

GO

EXEC usp_SearchByGenre 'Fantasy'

GO