
USE [Library];

 

CREATE TABLE [Authors]
(
[IdAuthor] INT IDENTITY(1,1),
[Name] VARCHAR (30),
[LastName] VARCHAR(30),
[Email] VARCHAR(30)

CONSTRAINT PK_Author PRIMARY KEY (IdAuthor),
);

CREATE TABLE [Books]
(
[IdBook] INT IDENTITY(1,1),
[IdAuthor] INT NULL,
[Title] VARCHAR(30),
[Description] VARCHAR(200),
[Section] VARCHAR(20),
[Genre] VARCHAR(30),
[Year] INT,
[Publisher] VARCHAR(30),

CONSTRAINT PK_Book PRIMARY KEY (IdBook),

CONSTRAINT FK_BooksAuthors FOREIGN KEY ([IdAuthor]) REFERENCES [Authors]([IdAuthor])
);

/* ------------------------- */
/*  populates tables authors */
/* ------------------------- */

INSERT INTO [Authors]
(
[Name],
[LastName],
[Email]
)
VALUES
(
'Jane',
'Austen',
'j.austey@gmail.com'
);


INSERT INTO [Authors]
(
[Name],
[LastName],
[Email]
)
VALUES
(
'Paulo',
'Coelho',
'p.coelho@gmail.com'
);


INSERT INTO [Authors]
(
[Name],
[LastName],
[Email]
)
VALUES
(
'William',
'Goldman',
'w.goldman@gmail.com'
);


INSERT INTO [Authors]
(
[Name],
[LastName],
[Email]
)
VALUES
(
'Miguel',
'Cervantes',
'm.cervantes@gmail.com'
);

/* --------------------- */
/* populate tables books */
/* --------------------- */
INSERT INTO Books
(
[IdAuthor],
[Title],
[Description],
[Section],
[Genre],
[Year],
[Publisher]
)
VALUES
(
3,
'The princess bride',
'The book combines elements of comedy and romance',
'Family',
'Romance',
'1973',
'Londom-Books'
);
/* --------------------- */

 

INSERT INTO Books
(
[IdAuthor],
[Title],
[Description],
[Section],
[Genre],
[Year],
[Publisher]
)
VALUES
(
1,
'Pride and Perjudice',
'Pride and Prejudice is a romantic novel by Jane Austen, first published in 1813.',
'Adults',
'Romance',
'1813',
'Thomas Egerton'
);

/* --------------------- */
INSERT INTO Books
(
[IdAuthor],
[Title],
[Description],
[Section],
[Genre],
[Year],
[Publisher]
)
VALUES
(
4,
'Sir Quixote of La Mancha',
'Is a Spanish novel by Miguel de Cervantes Saavedra. ',
'Adventure',
'Novel',
'1605',
'Francisco de Robles'
);

 

/* --------------------- */

INSERT INTO Books
(
[IdAuthor],
[Title],
[Description],
[Section],
[Genre],
[Year],
[Publisher]
)
VALUES
(
4,
'Don quijote de la Mancha',
'Novela mas influyente en la lengua española ',
'Adventura',
'Novela',
'1605',
'Francisco de Robles'
);

 
/* --------------------- */

INSERT INTO Books
(
[IdAuthor],
[Title],
[Description],
[Section],
[Genre],
[Year],
[Publisher]
)
VALUES
(
2,
'The darkest forest',
'Is a novel by Brazilian author Paulo Coelho which was first published in 1988. ',
'Adults',
'Fear',
'1988',
'Bright-Books'
);
