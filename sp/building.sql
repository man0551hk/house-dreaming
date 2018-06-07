CREATE TABLE building(
	[buildingID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[areaID] varchar(30),
	[districtID] varchar(30) NULL,
	[buildingNameEn] varchar(300) NULL,
	[buildingNameTc] varchar(300) NULL,
	[buildingNameSc] varchar(300) NULL,
	[addressEn]  varchar(300) NULL,
	[addressTc]  varchar(300) NULL,
	[addressSc]  varchar(300) NULL,
	latitude decimal(10, 7) null,
	longitude decimal(10, 7) null
 CONSTRAINT [PK_buildingID] PRIMARY KEY CLUSTERED 
(
	[buildingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO