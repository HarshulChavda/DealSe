/****** Object:  StoredProcedure [dbo].[GetAllState]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllState] 1
CREATE PROCEDURE [dbo].[GetAllState]
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
GO
