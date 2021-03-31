CREATE TABLE [dbo].[PaymentRecordTable]
(	
    [RecordId] INT NOT NULL PRIMARY KEY, 
	[EnergyReading] FLOAT NOT NULL,
	[EnergyUsage] FLOAT NOT NULL,
	[EnergyCost] DECIMAL(18, 2) NOT NULL,
	[ColdWaterReading] FLOAT NOT NULL,
	[HotdWaterReading] FLOAT NOT NULL,
	[ColdWaterCost] DECIMAL(18,2) NOT NULL,
	[HotdWaterCost] DECIMAL(18,2) NOT NULL,
	[GasCost] DECIMAL(18, 2) NOT NULL,
	[NumberOfTenants] INT NOT NULL,
	[TotalCost] DECIMAL(18, 2) NOT NULL,
	[CostPerPerson] DECIMAL(18, 2) NOT NULL, 
    [AddDate] DATETIME NOT NULL,
	[Comment] VARCHAR(100) NOT NULL
)
