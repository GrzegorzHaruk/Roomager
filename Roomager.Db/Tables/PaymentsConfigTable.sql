CREATE TABLE [dbo].[PaymentsConfigTable] (
    [Id]             INT NOT NULL,
    [EnergyConfigId] INT NOT NULL,
    [WaterConfigId]  INT NOT NULL,
    [GasConfigId]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

