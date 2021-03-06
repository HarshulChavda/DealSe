/****** Object:  StoredProcedure [dbo].[GetAllAreas]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- exec GetAllAreas 1,10
CREATE PROCEDURE [dbo].[GetAllAreas]
@PageIndex int,
@PageSize int 
AS
BEGIN
	
	Declare @Areas as varchar(MAX)='';

	 set @Areas = (select (
	 Select AreaId,[Name] as AreaName from Area where Active=1
	 Order by [Name] 
	 OFFSET @PageSize * (@PageIndex - 1) ROWS
	 FETCH NEXT @PageSize ROWS ONLY
	 for json PATH
	 ) as 'Areas')

	 select ROW_NUMBER() OVER (Order By @Areas) SrNo,
	 @Areas as 'Areas'

END


/****** Object:  StoredProcedure [dbo].[GetAllStoreTypes]    Script Date: 2/27/2021 6:08:42 PM ******/
SET ANSI_NULLS ON
GO
