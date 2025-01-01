create database CSDL
use CSDL
CREATE TABLE Learner (
    LearnerID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(50),
    FirstMidName NVARCHAR(50),
    EnrollmentDate DATE,
    MajorID INT,
    FOREIGN KEY (MajorID) REFERENCES Major(MajorID)
);

CREATE TABLE Major (
    MajorID INT IDENTITY(1,1) PRIMARY KEY,
    MajorName NVARCHAR(100)
);

CREATE TABLE Course (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100),
    Credits INT
);

CREATE TABLE Enrollment (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    CourseID INT,
    LearnerID INT,
    Grade DECIMAL(3, 2),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
    CONSTRAINT UC_Enrollment UNIQUE (CourseID, LearnerID)
);

