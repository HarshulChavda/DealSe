/****** Object:  StoredProcedure [dbo].[UpdateStoreStatusByIDs]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStoreStatusByIDs] 
@StoreIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update Store set Active = 1 where StoreId in (Select Item FROM dbo.SplitString(@StoreIds, ','))
end
else if(@Status = 'InActive')
begin
	update Store set Active = 0 where StoreId in (Select Item FROM dbo.SplitString(@StoreIds, ','))
end
else if(@Status = 'Approve')
begin
	update Store set Approved = 1 where StoreId in (Select Item FROM dbo.SplitString(@StoreIds, ','))
end
else if(@Status = 'DisApprove')
begin
	update Store set Approved = 0 where StoreId in (Select Item FROM dbo.SplitString(@StoreIds, ','))
end
else
begin
	update Store set Deleted = 0 where StoreId in (Select Item FROM dbo.SplitString(@StoreIds, ','))
end
END
GO
