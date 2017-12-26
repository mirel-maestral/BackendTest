CREATE TABLE [dbo].[Orders] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [Processed]           BIT           NULL,
    [ProcessedByInstance] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

