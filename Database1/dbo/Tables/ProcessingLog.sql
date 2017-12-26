CREATE TABLE [dbo].[ProcessingLog] (
    [Time]    DATETIME NOT NULL,
    [OrderId] INT      NOT NULL,
    [Id]      INT      IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_PrecessingLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

