CREATE TABLE [dbo].[PaymentsRecordTable] (
    [RecordId]         INT             NOT NULL,
    [EnergyCost]       DECIMAL (18, 2) NOT NULL,
    [ColdWaterCost]    DECIMAL (18, 2) NOT NULL,
    [HotWaterCost]     DECIMAL (18, 2) NOT NULL,
    [GasCost]          DECIMAL (18, 2) NOT NULL,
    [NumberOfTenants]  INT             NOT NULL,
    [TotalCost]        DECIMAL (18, 2) NOT NULL,
    [CostPerPerson]    DECIMAL (18, 2) NOT NULL,
    [AddDate]          DATETIME        NOT NULL,
    [Comment]          VARCHAR (100)   NULL,
    PRIMARY KEY CLUSTERED ([RecordId] ASC)
);

