USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCity]    Script Date: 16-02-2021 00:50:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllCity] 1
ALTER PROCEDURE [dbo].[GetAllCity]
@StateId int
AS
BEGIN

SELECT 
		C.[CityId],
		C.[Name],
		C.[AddedDate],
		C.[Active]
FROM City C
  Inner Join [State] S On C.StateId = S.StateId
  Where C.StateId = @StateId
END
