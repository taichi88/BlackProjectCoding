﻿

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Person' AND xtype = 'U')
BEGIN
    CREATE TABLE Person (
        Id INT IDENTITY(1,1) PRIMARY KEY, 
        Name NVARCHAR(100) NOT NULL
    );
END;