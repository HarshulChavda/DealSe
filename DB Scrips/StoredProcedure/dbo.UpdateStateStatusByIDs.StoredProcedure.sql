/****** Object:  StoredProcedure [dbo].[UpdateStateStatusByIDs]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStateStatusByIDs] 
@StateIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update [State] set Active = 1,UpdatedDate = GetDate()  where StateId in (Select Item FROM dbo.SplitString(@StateIds, ','))
end
else
begin
	update [State] set Active = 0,UpdatedDate = GetDate()  where StateId in (Select Item FROM dbo.SplitString(@StateIds, ','))
end
END
GO
