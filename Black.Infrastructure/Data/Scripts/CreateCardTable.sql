
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Cards' AND xtype = 'U')
BEGIN
    CREATE TABLE Cards (
        Id INT IDENTITY(1,1) PRIMARY KEY, 
        CardNumber NVARCHAR(100) NOT NULL,
        Expiration NVARCHAR(100) NOT NULL,
        PinCode NVARCHAR(100) NOT NULL,
        AccountId INT,  -- Foreign key to Account table
        CONSTRAINT FK_Card_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
    );
END;
