CREATE TABLE [dbo].[PotentialSolutions] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Solution] VARCHAR (2000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
