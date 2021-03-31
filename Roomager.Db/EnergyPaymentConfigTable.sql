CREATE TABLE [dbo].[EnergyPaymentConfigTable]
(
	[ConfigId] INT NOT NULL PRIMARY KEY,
	[AddDate] DATETIME NOT NULL,
	[SellFee] DECIMAL(18,2) NOT NULL,
	[DistributionFee] DECIMAL(18,2) NOT NULL,
	[CogenerationFee] DECIMAL(18,2) NOT NULL,
	[FixedDistributionFee] DECIMAL(18,2) NOT NULL,
	[FixedTemporaryFee] DECIMAL(18,2) NOT NULL,
	[FixedSubscriptionFee] DECIMAL(18,2) NOT NULL,
	[Tax] FLOAT NOT NULL
)
