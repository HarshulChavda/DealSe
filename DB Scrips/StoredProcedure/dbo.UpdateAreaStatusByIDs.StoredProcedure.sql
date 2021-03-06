/****** Object:  StoredProcedure [dbo].[UpdateAreaStatusByIDs]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAreaStatusByIDs] 
@AreaIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update [Area] set Active = 1,UpdatedDate = GetDate()  where AreaId in (Select Item FROM dbo.SplitString(@AreaIds, ','))
end
else
begin
	update [Area] set Active = 0,UpdatedDate = GetDate()  where AreaId in (Select Item FROM dbo.SplitString(@AreaIds, ','))
end
END
GO
