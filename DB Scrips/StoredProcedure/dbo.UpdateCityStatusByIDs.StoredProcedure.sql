/****** Object:  StoredProcedure [dbo].[UpdateCityStatusByIDs]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCityStatusByIDs] 
@CityIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update [City] set Active = 1,UpdatedDate = GetDate()  where CityId in (Select Item FROM dbo.SplitString(@CityIds, ','))
end
else
begin
	update [City] set Active = 0,UpdatedDate = GetDate()  where CityId in (Select Item FROM dbo.SplitString(@CityIds, ','))
end
END
GO
