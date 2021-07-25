CREATE TABLE [dbo].[PaymentsRecordTable] (
    [RecordId]         INT             NOT NULL,
    [EnergyReading]    FLOAT (53)      NOT NULL,
    [EnergyUsage]      FLOAT (53)      NOT NULL,
    [EnergyCost]       DECIMAL (18, 2) NOT NULL,
    [ColdWaterReading] FLOAT (53)      NOT NULL,
    [HotWaterReading]  FLOAT (53)      DEFAULT ((0)) NOT NULL,
    [ColdWaterCost]    DECIMAL (18, 2) NOT NULL,
    [HotWaterCost]     DECIMAL (18, 2) DEFAULT ((0)) NOT NULL,
    [GasCost]          DECIMAL (18, 2) NOT NULL,
    [NumberOfTenants]  INT             NOT NULL,
    [TotalCost]        DECIMAL (18, 2) NOT NULL,
    [CostPerPerson]    DECIMAL (18, 2) NOT NULL,
    [AddDate]          DATETIME        NOT NULL,
    [Comment]          VARCHAR (100)   NULL,
    PRIMARY KEY CLUSTERED ([RecordId] ASC)
);

