USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetUserUsedOfferListByStore]    Script Date: 26-12-2020 01:47:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetOfferListByStoreId 2,1,10
Alter PROCEDURE [dbo].[GetOfferListByStoreId]
(	
	@StoreId int,
	@PageIndex int,
	@PageSize int
)
AS
BEGIN
	
	Select *,
	(Select Top 1 Image From OfferBanner OB Where OB.Deleted = 0 And Result.OfferId = OB.OfferId order by OB.AddedDate Desc) 'OfferListImage'
	From(Select 
	O.OfferId,
	O.[Name] 'Name',
	(Select (convert(varchar, O.StartDate, 106) + ' - ' + convert(varchar, O.EndDate, 106))) 'EffectiveDateRange',
	O.SortDescription,
	O.Active
	From Offer O
	where O.Deleted = 0
	order by O.AddedDate Desc
	OFFSET @PageSize * (@PageIndex - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY) as Result
	    
END