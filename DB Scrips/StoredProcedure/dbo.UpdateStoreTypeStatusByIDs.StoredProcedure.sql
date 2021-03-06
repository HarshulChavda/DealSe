/****** Object:  StoredProcedure [dbo].[UpdateStoreTypeStatusByIDs]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStoreTypeStatusByIDs] 
@StoreTypeIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update StoreType set Active = 1 where StoreTypeId in (Select Item FROM dbo.SplitString(@StoreTypeIds, ','))
end
else if(@Status = 'InActive')
begin
	update StoreType set Active = 0 where StoreTypeId in (Select Item FROM dbo.SplitString(@StoreTypeIds, ','))
end
else
begin
	update StoreType set Deleted = 0 where StoreTypeId in (Select Item FROM dbo.SplitString(@StoreTypeIds, ','))
end
END
GO
