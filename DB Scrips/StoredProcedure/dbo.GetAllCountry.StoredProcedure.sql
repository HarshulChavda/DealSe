/****** Object:  StoredProcedure [dbo].[GetAllCountry]    Script Date: 15-06-2021 01:16:43 ******/
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
	  ,[Active]
  FROM [Country]
END
GO
