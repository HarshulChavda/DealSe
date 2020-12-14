/*
   02 December 202022:44:05
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
ALTER TABLE dbo.Offer
	DROP CONSTRAINT FK_Offer_Store
GO
ALTER TABLE dbo.Store SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Store', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Offer
	DROP CONSTRAINT DF_Offer_Deleted
GO
CREATE TABLE dbo.Tmp_Offer
	(
	OfferId int NOT NULL IDENTITY (1, 1),
	StoreId int NOT NULL,
	Name nvarchar(100) NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NOT NULL,
	SortDescription nvarchar(500) NOT NULL,
	LongDescription nvarchar(MAX) NULL,
	LimitedTimeOffer bit NOT NULL,
	Approved bit NOT NULL,
	Active bit NOT NULL,
	AddedDate datetime NOT NULL,
	Deleted bit NOT NULL,
	DeletedDate datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Offer SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Offer ADD CONSTRAINT
	DF_Offer_LimitedTimeOffer DEFAULT 0 FOR LimitedTimeOffer
GO
ALTER TABLE dbo.Tmp_Offer ADD CONSTRAINT
	DF_Offer_Deleted DEFAULT ((0)) FOR Deleted
GO
SET IDENTITY_INSERT dbo.Tmp_Offer ON
GO
IF EXISTS(SELECT * FROM dbo.Offer)
	 EXEC('INSERT INTO dbo.Tmp_Offer (OfferId, StoreId, Name, StartDate, EndDate, SortDescription, LongDescription, Approved, Active, AddedDate, Deleted, DeletedDate)
		SELECT OfferId, StoreId, Name, StartDate, EndDate, SortDescription, LongDescription, Approved, Active, AddedDate, Deleted, DeletedDate FROM dbo.Offer WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Offer OFF
GO
ALTER TABLE dbo.OfferBanner
	DROP CONSTRAINT FK_OfferBanner_Offer
GO
ALTER TABLE dbo.UserUsedOffer
	DROP CONSTRAINT FK_UserUsedOffer_Offer
GO
DROP TABLE dbo.Offer
GO
EXECUTE sp_rename N'dbo.Tmp_Offer', N'Offer', 'OBJECT' 
GO
ALTER TABLE dbo.Offer ADD CONSTRAINT
	PK_Offer PRIMARY KEY CLUSTERED 
	(
	OfferId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

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
COMMIT
select Has_Perms_By_Name(N'dbo.Offer', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Offer', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Offer', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.UserUsedOffer ADD CONSTRAINT
	FK_UserUsedOffer_Offer FOREIGN KEY
	(
	OfferId
	) REFERENCES dbo.Offer
	(
	OfferId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.UserUsedOffer SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.UserUsedOffer', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.UserUsedOffer', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.UserUsedOffer', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OfferBanner ADD CONSTRAINT
	FK_OfferBanner_Offer FOREIGN KEY
	(
	OfferId
	) REFERENCES dbo.Offer
	(
	OfferId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OfferBanner SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OfferBanner', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OfferBanner', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OfferBanner', 'Object', 'CONTROL') as Contr_Per 