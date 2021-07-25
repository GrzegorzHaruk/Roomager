CREATE TABLE [dbo].[GasPaymentConfigTable] (
    [ConfigId] INT             NOT NULL,
    [AddDate]  DATETIME        NOT NULL,
    [GasFee]   DECIMAL (18, 2) NOT NULL,
    FOREIGN KEY ([ConfigId]) REFERENCES [dbo].[PaymentsConfigTable] ([Id])
);