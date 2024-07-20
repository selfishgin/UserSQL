CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    Surname NVARCHAR(50),
    Age INT,
    Login NVARCHAR(50) UNIQUE,
    Password NVARCHAR(50)
);
