1) Install the following
   a. ASP.NET CORE SDK
      https://dotnet.microsoft.com/download     

   b. Visual Studio Code 
      https://code.visualstudio.com/Download

   c. Postman
      https://www.postman.com/downloads/
      
   d. SQLserver express
      https://www.microsoft.com/es-mx/sql-server/sql-server-downloads?rtc=1

2) When SDK is installed please to mount the following NUGETs in the command line typing the following:
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet restore
   dotnet build

3) Get the code from the repository
   

4) Go to SQL Server Express and execute the following scripts:
   1-CreateDatabase.sql
   2- Create-Populate Tables.sql
   
4) Compile the rest api using VS Code.

5) Testing the API Rest

=====  A U T H O R S ==========================
-- Get all Authors
http://localhost:5000/api/v1/library/authors

-- Get Authors by ID
http://localhost:5000/api/v1/library/authors/2

-- Add a new Author
-- Method POST
http://localhost:5000/api/v1/library/authors

{
    "authorName": "Juncho",
    "authorLastName": "Polo Valencia",
    "authorEmail": "juancho.polo@gmail.com",
}

-- Update an existing author
-- Method PUT
http://localhost:5000/api/v1/library/authors/6
{
    "authorid": 6,
    "authorName": "Juncho",
    "authorLastName": "Polo Valencia",
    "authorEmail": "juancho.polo@gmail.com",
}


-- Delete an Author
-- Method DELETE
http://localhost:5000/api/v1/library/authors/7

=====  B O O K S ==============================
-- Get all books
http://localhost:5000/api/v1/library/books



--Get books id
http://localhost:5000/api/v1/library/books/6

-- Add a new book 
-- Method POST
http://localhost:5000/api/v1/library/books

  {
        "title": "Pedrito el Escamoso",
        "description": "Comedy and Drama",
        "section": "Family",
        "genre": "Comedy",
        "year": 2005,
        "publisher": "Gozadera-Books",
        "authorid": 6
  }

--Update an existing book
-- Method PUT
http://localhost:5000/api/v1/library/books/6

  {
        "title": "Pedrito el Escamoso",
        "description": "Comedy and Drama and Huesera",
        "section": "Family",
        "genre": "Comedy",
        "year": 2002,
        "publisher": "Gozadera-Books.",
        "authorid": 6
  }



-- Delete books
-- method DELETE
http://localhost:5000/api/v1/library/books/6

