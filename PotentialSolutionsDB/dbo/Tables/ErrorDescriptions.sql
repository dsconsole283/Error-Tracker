CREATE TABLE [dbo].[ErrorDescriptions] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (2000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

