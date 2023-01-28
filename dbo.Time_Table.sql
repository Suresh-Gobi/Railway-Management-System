CREATE TABLE [dbo].[Time_Table] (
    [Train_No] INT        NOT NULL,
    [From]     VARCHAR(50) NULL,
    [To]       VARCHAR(50) NULL,
    [Arrive]   INT NULL,
    [Depart]   INT NULL,
    [Distance] INT NULL,
    [Fare]     INT NULL,
    PRIMARY KEY CLUSTERED ([Train_No] ASC)
);

