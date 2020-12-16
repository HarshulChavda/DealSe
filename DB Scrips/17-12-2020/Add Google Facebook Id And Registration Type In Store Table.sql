/*
   17 December 202000:02:38
   User: harshulpc
   Server: HARSHUL-PC\SQLEXPRESS
   Database: DealSe
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Store
	DROP CONSTRAINT FK_Store_City
GO
ALTER TABLE dbo.City SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.City', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.City', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.City', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Store
	DROP CONSTRAINT FK_Store_StoreType
GO
ALTER TABLE dbo.StoreType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.StoreType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.StoreType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.StoreType', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Store
	DROP CONSTRAINT DF_Store_Deleted
GO
CREATE TABLE dbo.Tmp_Store
	(
	StoreId int NOT NULL IDENTITY (1, 1),
	StoreTypeId int NOT NULL,
	CityId int NOT NULL,
	Name nvarchar(100) NOT NULL,
	Email nvarchar(100) NULL,
	RegistrationType tinyint NOT NULL,
	GoogleId nvarchar(MAX) NULL,
	FacebookId nvarchar(MAX) NULL,
	MobileNo1 nvarchar(10) NULL,
	MobileNo2 nvarchar(10) NULL,
	Address1 nvarchar(500) NOT NULL,
	Address2 nvarchar(500) NULL,
	Address3 nvarchar(500) NULL,
	OpenTime nvarchar(5) NOT NULL,
	CloseTime nvarchar(5) NOT NULL,
	Latitude decimal(11, 8) NOT NULL,
	Longitude decimal(11, 8) NOT NULL,
	OwnerName nvarchar(100) NOT NULL,
	OwnerMobileNo nvarchar(10) NOT NULL,
	About nvarchar(2000) NULL,
	Approved bit NOT NULL,
	Active bit NOT NULL,
	AddedDate datetime NOT NULL,
	Deleted bit NOT NULL,
	DeletedDate datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Store SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Store ADD CONSTRAINT
	DF_Store_Deleted DEFAULT ((0)) FOR Deleted
GO
SET IDENTITY_INSERT dbo.Tmp_Store ON
GO
IF EXISTS(SELECT * FROM dbo.Store)
	 EXEC('INSERT INTO dbo.Tmp_Store (StoreId, StoreTypeId, CityId, Name, Email, MobileNo1, MobileNo2, Address1, Address2, Address3, OpenTime, CloseTime, Latitude, Longitude, OwnerName, OwnerMobileNo, About, Approved, Active, AddedDate, Deleted, DeletedDate)
		SELECT StoreId, StoreTypeId, CityId, Name, Email, MobileNo1, MobileNo2, Address1, Address2, Address3, OpenTime, CloseTime, Latitude, Longitude, OwnerName, OwnerMobileNo, About, Approved, Active, AddedDate, Deleted, DeletedDate FROM dbo.Store WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Store OFF
GO
ALTER TABLE dbo.Offer
	DROP CONSTRAINT FK_Offer_Store
GO
ALTER TABLE dbo.StoreSuggestedOffer
	DROP CONSTRAINT FK_StoreSuggestedOffer_Store
GO
DROP TABLE dbo.Store
GO
EXECUTE sp_rename N'dbo.Tmp_Store', N'Store', 'OBJECT' 
GO
ALTER TABLE dbo.Store ADD CONSTRAINT
	PK_Store PRIMARY KEY CLUSTERED 
	(
	StoreId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Store ADD CONSTRAINT
	FK_Store_StoreType FOREIGN KEY
	(
	StoreTypeId
	) REFERENCES dbo.StoreType
	(
	StoreTypeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Store ADD CONSTRAINT
	FK_Store_City FOREIGN KEY
	(
	CityId
	) REFERENCES dbo.City
	(
	CityId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Store', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.StoreSuggestedOffer ADD CONSTRAINT
	FK_StoreSuggestedOffer_Store FOREIGN KEY
	(
	StoreId
	) REFERENCES dbo.Store
	(
	StoreId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.StoreSuggestedOffer SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.StoreSuggestedOffer', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.StoreSuggestedOffer', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.StoreSuggestedOffer', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Offer ADD CONSTRAINT
	FK_Offer_Store FOREIGN KEY
	(
	StoreId
	) REFERENCES dbo.Store
	(
	StoreId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Offer SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Offer', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Offer', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Offer', 'Object', 'CONTROL') as Contr_Per 