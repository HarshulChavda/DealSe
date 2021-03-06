USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetAllArea]    Script Date: 16-02-2021 00:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllArea] 1
ALTER PROCEDURE [dbo].[GetAllArea]
@CityId int
AS
BEGIN

SELECT	A.AreaId,
		A.[Name],
		A.[AddedDate],
		A.[Active]
  FROM Area A
  Inner Join [City] C On C.CityId = A.CityId
  Where C.CityId = @CityId
END
