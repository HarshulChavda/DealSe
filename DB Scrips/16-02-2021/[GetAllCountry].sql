USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCountry]    Script Date: 08-01-2021 00:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllCountry] 
CREATE PROCEDURE [dbo].[GetAllCountry]
AS
BEGIN

SELECT [CountryId]
      ,[Name]
      ,[AddedDate]
	  ,[UpdatedDate]
	  ,[Active]
  FROM [Country]
END
