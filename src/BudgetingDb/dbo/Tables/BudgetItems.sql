CREATE TABLE [dbo].[BudgetItems] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Amount]      MONEY          NOT NULL,
    [Frequency]   NVARCHAR (50)  NOT NULL,
    [StartDate]   DATETIME       NOT NULL,
    [EndDate]     DATETIME       NULL,
    [Type]        NVARCHAR (50)  NOT NULL
);

