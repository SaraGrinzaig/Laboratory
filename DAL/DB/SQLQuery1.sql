CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(255) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(50) NOT NULL
);

CREATE TABLE Devices (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    DeviceType VARCHAR(50) NOT NULL,
    DeviceModel VARCHAR(255) NOT NULL,
    IssueDescription TEXT NOT NULL,
    UnlockCode VARCHAR(50),
    EstimatedPrice DECIMAL(10, 2),
    FinalPrice DECIMAL(10, 2),
    Notes TEXT,
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);

CREATE TABLE StatusTypes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    StatusName NVARCHAR(50) NOT NULL UNIQUE
);

INSERT INTO StatusTypes (StatusName)
VALUES (N'נכנס'), (N'בטיפול'), (N'הוזמן רכיב'), (N'תקוע'), (N'הסתיים');

CREATE TABLE Statuses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DeviceId INT NOT NULL,
    StatusId INT NOT NULL,
    StatusChangeDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DeviceId) REFERENCES Devices(Id),
    FOREIGN KEY (StatusId) REFERENCES StatusTypes(Id)
);

CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DeviceId INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    Notes TEXT,
    FOREIGN KEY (DeviceId) REFERENCES Devices(Id)
);
