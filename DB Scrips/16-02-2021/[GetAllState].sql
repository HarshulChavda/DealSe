USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetAllState]    Script Date: 16-02-2021 00:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllState] 1
ALTER PROCEDURE [dbo].[GetAllState]
@CountryId int
AS
BEGIN

SELECT 
	  S.StateId
      ,S.[Name]
      ,S.[AddedDate]
	  ,S.[Active]
  FROM [State] S
  Where S.CountryId = @CountryId
END
