/****** Object:  StoredProcedure [dbo].[GetAllStoreTypes]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec GetAllStoreTypes 1,10
CREATE PROCEDURE [dbo].[GetAllStoreTypes]
@PageIndex int,
@PageSize int 
AS
BEGIN
	
	Declare @StoreTyes as varchar(MAX)='';

	set @StoreTyes = (Select 
	(Select StoreTypeId, [Name] as StoreTypeName
	from StoreType 
	where Deleted=0
	order by [Name]
	OFFSET @PageSize * (@PageIndex - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY
	FOR JSON PATH) as 'StoreTypes')

	select ROW_NUMBER() OVER (Order By @StoreTyes) SrNo,
	 @StoreTyes as 'StoreTyes'

END
GO
