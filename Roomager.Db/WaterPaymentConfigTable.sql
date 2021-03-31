CREATE TABLE [dbo].[WaterPaymentConfigTable]
(
	[ConfigId] INT NOT NULL PRIMARY KEY,
	[AddDate] DATETIME NOT NULL,
	[ColdWaterFee] DECIMAL(18,2) NOT NULL,
	[HotWaterFee]DECIMAL(18,2) NOT NULL
)
