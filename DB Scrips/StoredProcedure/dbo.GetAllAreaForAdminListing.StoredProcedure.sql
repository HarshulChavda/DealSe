/****** Object:  StoredProcedure [dbo].[GetAllAreaForAdminListing]    Script Date: 15-06-2021 01:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllAreaForAdminListing] 1
CREATE PROCEDURE [dbo].[GetAllAreaForAdminListing]
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
GO
