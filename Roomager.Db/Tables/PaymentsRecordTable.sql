CREATE TABLE [dbo].[PaymentsRecordTable] (
    [RecordId]         INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [EnergyCost]       DECIMAL (18, 2) NOT NULL,
    [ColdWaterCost]    DECIMAL (18, 2) NOT NULL,
    [HotWaterCost]     DECIMAL (18, 2) NOT NULL,
    [GasCost]          DECIMAL (18, 2) NOT NULL,
    [NumberOfTenants]  INT             NOT NULL,
    [TotalCost]        DECIMAL (18, 2) NOT NULL,
    [CostPerPerson]    DECIMAL (18, 2) NOT NULL,
    [AddDate]          DATETIME        NOT NULL,
    [Comment]          VARCHAR (100)   NULL
);

