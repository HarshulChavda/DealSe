/*
   17 December 202000:00:58
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
ALTER TABLE dbo.[User]
	DROP CONSTRAINT FK_User_City
GO
ALTER TABLE dbo.City SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.City', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.City', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.City', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.[User]
	DROP CONSTRAINT DF_User_Deleted
GO
CREATE TABLE dbo.Tmp_User
	(
	UserId int NOT NULL IDENTITY (1, 1),
	CityId int NULL,
	FirstName nvarchar(50) NULL,
	LastName nvarchar(50) NULL,
	MobileNo nvarchar(10) NOT NULL,
	Email nvarchar(150) NULL,
	RegistrationType tinyint NOT NULL,
	GoogleId nvarchar(MAX) NULL,
	FacebookId nvarchar(MAX) NULL,
	Photo nvarchar(50) NULL,
	Gender tinyint NULL,
	MaritalStatus tinyint NULL,
	DOB datetime NULL,
	Address1 nvarchar(500) NULL,
	Address2 nvarchar(500) NULL,
	Address3 nvarchar(500) NULL,
	Approved bit NOT NULL,
	Active bit NOT NULL,
	AddedDate datetime NOT NULL,
	Deleted bit NOT NULL,
	DeletedDate datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_User SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_User ADD CONSTRAINT
	DF_User_Deleted DEFAULT ((0)) FOR Deleted
GO
SET IDENTITY_INSERT dbo.Tmp_User ON
GO
IF EXISTS(SELECT * FROM dbo.[User])
	 EXEC('INSERT INTO dbo.Tmp_User (UserId, CityId, FirstName, LastName, MobileNo, Email, RegistrationType, GoogleId, FacebookId, Photo, Gender, MaritalStatus, DOB, Address1, Address2, Address3, Approved, Active, AddedDate, Deleted, DeletedDate)
		SELECT UserId, CityId, FirstName, LastName, MobileNo, Email, RegistrationType, CONVERT(nvarchar(MAX), GoogleId), CONVERT(nvarchar(MAX), FacebookId), Photo, Gender, MaritalStatus, DOB, Address1, Address2, Address3, Approved, Active, AddedDate, Deleted, DeletedDate FROM dbo.[User] WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_User OFF
GO
ALTER TABLE dbo.UserUsedOffer
	DROP CONSTRAINT FK_UserUsedOffer_User
GO
DROP TABLE dbo.[User]
GO
EXECUTE sp_rename N'dbo.Tmp_User', N'User', 'OBJECT' 
GO
ALTER TABLE dbo.[User] ADD CONSTRAINT
	PK_User PRIMARY KEY CLUSTERED 
	(
	UserId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.[User] ADD CONSTRAINT
	FK_User_City FOREIGN KEY
	(
	CityId
	) REFERENCES dbo.City
	(
	CityId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.[User]', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.[User]', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.[User]', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.UserUsedOffer ADD CONSTRAINT
	FK_UserUsedOffer_User FOREIGN KEY
	(
	UserId
	) REFERENCES dbo.[User]
	(
	UserId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.UserUsedOffer SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.UserUsedOffer', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.UserUsedOffer', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.UserUsedOffer', 'Object', 'CONTROL') as Contr_Per 