CREATE DATABASE [Movies]

GO

CREATE TABLE Directors (
    Id INT PRIMARY KEY,
    DirectorName VARCHAR(100) NOT NULL,
    Notes VARCHAR(255)
);

INSERT INTO Directors (Id, DirectorName, Notes)
VALUES
    (1, 'Christopher Nolan', 'British-American film director and screenwriter'),
    (2, 'Quentin Tarantino', 'American film director, screenwriter, producer, and actor'),
    (3, 'Martin Scorsese', 'American film director, producer, screenwriter, and actor'),
    (4, 'Steven Spielberg', 'American film director, producer, and screenwriter'),
    (5, 'James Cameron', 'Canadian film director, producer, and screenwriter');

CREATE TABLE Genres (
    Id INT PRIMARY KEY,
    GenreName VARCHAR(50) NOT NULL,
    Notes VARCHAR(255)
);

INSERT INTO Genres (Id, GenreName, Notes)
VALUES
    (1, 'Action', 'Movies featuring intense physical action'),
    (2, 'Drama', 'Movies focused on character development and emotional themes'),
    (3, 'Sci-Fi', 'Movies featuring speculative fiction and futuristic elements'),
    (4, 'Adventure', 'Movies involving risky or exciting experiences'),
    (5, 'Comedy', 'Movies intended to make the audience laugh');

CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL,
    Notes VARCHAR(255)
);

INSERT INTO Categories (Id, CategoryName, Notes)
VALUES
    (1, 'Thriller', 'Movies intended to excite or scare the audience'),
    (2, 'Romance', 'Movies centered around romantic relationships and love stories'),
    (3, 'Horror', 'Movies designed to evoke fear and terror in the audience'),
    (4, 'Fantasy', 'Movies featuring elements of magic, myth, and the supernatural'),
    (5, 'Animation', 'Movies created using animation techniques');

CREATE TABLE Movies (
    Id INT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    DirectorId INT,
    CopyrightYear INT,
    Length INT,
    GenreId INT,
    CategoryId INT,
    Rating DECIMAL(3,1),
    Notes VARCHAR(255),
    FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
    FOREIGN KEY (GenreId) REFERENCES Genres(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

INSERT INTO Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
    (1, 'Inception', 1, 2010, 148, 3, 1, 8.8, 'Mind-bending sci-fi thriller'),
    (2, 'Pulp Fiction', 2, 1994, 154, 2, 1, 8.9, 'Cult classic crime drama'),
    (3, 'The Departed', 3, 2006, 151, 1, 1, 8.5, 'Gritty crime thriller'),
    (4, 'Jurassic Park', 4, 1993, 127, 4, 4, 8.1, 'Iconic adventure film'),
    (5, 'Avatar', 5, 2009, 162, 3, 4, 7.8, 'Epic science fiction adventure');