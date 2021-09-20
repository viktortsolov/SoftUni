CREATE TABLE [People](
	[Id]		INT PRIMARY KEY IDENTITY,
	[Name]		NVARCHAR(200)									NOT NULL,
	[Picture]	VARBINARY(MAX),
	CHECK		(DATALENGTH([Picture]) <= 2 * 1024 * 1024),
	[Height]	DECIMAL(3, 2),
	[Weight]	DECIMAL(5, 2),
	[Gender]	CHAR CHECK ([Gender] = 'm' OR [Gender] = 'f')	NOT NULL,
	[Birthdate] DATETIME2										NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate]) VALUES
	('Aleks', 1.76, 65.5,		'm',	CAST('06-10-2003' AS DATETIME2)),
	('Aleksandar', NULL, NULL,	'm',	CAST('03-03-2003' AS DATETIME2)),
	('Antoan', 1.80, 70.3,		'm',	CAST('01-25-2003' AS DATETIME2)),
	('Venelin', 1.76, 70.4,		'm',	CAST('09-06-2003' AS DATETIME2)),
	('Viktor', 1.75, 60.2,		'm',	CAST('05-09-2003' AS DATETIME2))

CREATE TABLE [Users](
	[Id]				BIGINT PRIMARY KEY IDENTITY,
	[Username]			VARCHAR(30) UNIQUE	NOT NULL,
	[Password]			VARCHAR(26)			NOT NULL,
	[ProfilePicture]	VARBINARY(MAX),
	CHECK				(DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime]		DATETIME2,
	[IsDeleted]			BIT					NOT NULL
)

INSERT INTO [Users]([Username], [Password], [LastLoginTime], [IsDeleted]) VALUES
('van4O',	'12345678', CAST('05-09-2021' AS DATETIME2), 0),
('nan40',	'87654321', CAST('05-23-2021' AS DATETIME2), 0),
('klient',	'4143424',	CAST('05-12-2021' AS DATETIME2), 1),
('rejep',	'87654321', CAST('05-22-2021' AS DATETIME2), 1),
('viksun03',	'434343',	CAST('05-24-2021' AS DATETIME2), 0)
