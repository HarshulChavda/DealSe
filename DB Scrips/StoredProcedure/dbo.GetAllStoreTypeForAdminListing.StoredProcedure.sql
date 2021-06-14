/****** Object:  StoredProcedure [dbo].[GetAllStoreTypeForAdminListing]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllStoreTypeForAdminListing] 
CREATE PROCEDURE [dbo].[GetAllStoreTypeForAdminListing]
AS
BEGIN

SELECT [StoreTypeId]
      ,[Name]
      ,[AddedDate]
	  ,[Active]
  FROM [StoreType]
  Where Deleted = 0
END
GO
