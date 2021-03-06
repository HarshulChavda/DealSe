/****** Object:  StoredProcedure [dbo].[GetAllStoreForAdminListing]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [GetAllStoreForAdminListing] 0,0
CREATE PROCEDURE [dbo].[GetAllStoreForAdminListing]
@AreaId int,
@StoreTypeId int
AS
BEGIN
  
Declare @SelectQuery varchar(MAX)= ''
Declare @WhereQuery varchar(MAX)= ''

Set @SelectQuery = '
SELECT 
	   S.[StoreId]
      ,ST.[Name] ''StoreTypeName''
	  ,A.[Name] ''AreaName''
	  ,S.[Name]
      ,S.[Email]
      ,S.[OwnerName]
      ,S.[OwnerMobileNo]
      ,S.[Approved]
      ,S.[Active]
      ,S.[AddedDate]      
  FROM [Store] S
  Inner Join [StoreType] ST On ST.StoreTypeId = S.StoreTypeId
  Inner Join [Area] A On A.AreaId = S.AreaId'
Set @WhereQuery = ' Where 1=1'

If(@AreaId <> 0)
Begin
Set @WhereQuery = @WhereQuery + ' And S.AreaId = '+CONVERT(VARCHAR(5), @AreaId )+''
End

If(@StoreTypeId <> 0)
Begin
Set @WhereQuery = @WhereQuery + ' And S.StoreTypeId = '+CONVERT(VARCHAR(5), @StoreTypeId )+''
End

Print(@SelectQuery+@WhereQuery)
Exec(@SelectQuery+@WhereQuery)

END
GO
