/****** Object:  StoredProcedure [dbo].[UpdateCountryStatusByIDs]    Script Date: 08-01-2021 00:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCountryStatusByIDs] 
@CountryIds as varchar(max),
@Status as nvarchar(20)
AS

begin
if(@Status = 'Active')
begin
	update Country set Active = 1,UpdatedDate = GetDate()  where CountryId in (Select Item FROM dbo.SplitString(@CountryIds, ','))
end
else
begin
	update Country set Active = 0,UpdatedDate = GetDate()  where CountryId in (Select Item FROM dbo.SplitString(@CountryIds, ','))
end
END
