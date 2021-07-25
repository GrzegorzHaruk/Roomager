CREATE TABLE [dbo].[WaterPaymentConfigTable] (
    [ConfigId]     INT             NOT NULL,
    [AddDate]      DATETIME        NOT NULL,
    [ColdWaterFee] DECIMAL (18, 2) NOT NULL,
    [HotWaterFee]  DECIMAL (18, 2) NOT NULL,
    FOREIGN KEY ([ConfigId]) REFERENCES [dbo].[PaymentsConfigTable] ([Id])
);