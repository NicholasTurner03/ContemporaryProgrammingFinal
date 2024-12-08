USE FinalProjectContext;

-- Create Hobbies Table
-- Create Books Table
CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    Pages INT NOT NULL,
    PublishedDate DATETIME NOT NULL
);

-- Create Hobby Table (singular)
CREATE TABLE Hobby (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
    HoursPerWeek INT NOT NULL
);

-- Create TeamMembers Table
CREATE TABLE TeamMembers (
    Id INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(255) NOT NULL,
    Birthdate DATETIME NOT NULL,
    CollegeProgram NVARCHAR(255) NOT NULL,
    YearInProgram NVARCHAR(50) NOT NULL
);

-- Create FavoriteFoods Table
CREATE TABLE FavoriteFood (
    Id INT PRIMARY KEY IDENTITY,
    FoodName NVARCHAR(255) NOT NULL,
    IsVegetarian BIT NOT NULL,
    CuisineType NVARCHAR(255)
);
