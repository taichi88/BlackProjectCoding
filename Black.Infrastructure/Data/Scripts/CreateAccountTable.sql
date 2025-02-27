

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Accounts' AND xtype = 'U')
BEGIN
    CREATE TABLE Accounts (
        Id INT IDENTITY(1,1) PRIMARY KEY, 
        AccountNumber NVARCHAR(100) NOT NULL,
        PersonId INT,  -- Foreign key to Person table
        CONSTRAINT FK_Account_Person FOREIGN KEY (PersonId) REFERENCES Person(Id)
    );
END;
