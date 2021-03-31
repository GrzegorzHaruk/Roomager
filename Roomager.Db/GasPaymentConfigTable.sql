CREATE TABLE [dbo].[GasPaymentConfigTable]
(
	[ConfigId] INT NOT NULL PRIMARY KEY,
	[AddDate] DATETIME NOT NULL,
	[GasFee] DECIMAL(18,2) NOT NULL,
)
