CREATE TABLE [dbo].[users] (
    [UID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UID]),
    [username] NVARCHAR (50) NULL,
    [password] NVARCHAR (50) NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [QID] INT NULL, 
    [Answer] NVARCHAR(50) NULL, 
    [PID] INT NULL,
     
);

