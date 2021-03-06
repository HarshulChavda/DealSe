USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCountryStatusByIDs]    Script Date: 14-02-2021 01:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateStateStatusByIDs] 
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
