/****** Object:  StoredProcedure [dbo].[GetAllCity]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllCity] 1
CREATE PROCEDURE [dbo].[GetAllCity]
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
GO
