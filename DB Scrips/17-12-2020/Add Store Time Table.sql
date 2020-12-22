/*
   17 December 202000:41:16
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
ALTER TABLE dbo.Store SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Store', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Store', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.StoreTime
	(
	StoreTimeId int NOT NULL IDENTITY (1, 1),
	StoreId int NOT NULL,
	MondayOpenHours nvarchar(10) NULL,
	MondayCloseHours nvarchar(10) NULL,
	TuesdayOpenHours nvarchar(10) NULL,
	TuesdayCloseHours nvarchar(10) NULL,
	WednesdayOpenHours nvarchar(10) NULL,
	WednesdayCloseHours nvarchar(10) NULL,
	ThursdayOpenHours nvarchar(10) NULL,
	ThursdayCloseHours nvarchar(10) NULL,
	FridayOpenHours nvarchar(10) NULL,
	FridayCloseHours nvarchar(10) NULL,
	SaturdayOpenHours nvarchar(10) NULL,
	SaturdayCloseHours nvarchar(10) NULL,
	SundayOpenHours nvarchar(10) NULL,
	SundayCloseHours nvarchar(10) NULL,
	Active bit NOT NULL,
	AddedDate datetime NOT NULL,
	Deleted bit NOT NULL,
	DeletedDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.StoreTime ADD CONSTRAINT
	DF_StoreTime_Deleted DEFAULT ((0)) FOR Deleted
GO
ALTER TABLE dbo.StoreTime ADD CONSTRAINT
	PK_StoreTime PRIMARY KEY CLUSTERED 
	(
	StoreTimeId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.StoreTime ADD CONSTRAINT
	FK_StoreTime_Store FOREIGN KEY
	(
	StoreId
	) REFERENCES dbo.Store
	(
	StoreId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.StoreTime SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.StoreTime', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.StoreTime', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.StoreTime', 'Object', 'CONTROL') as Contr_Per 