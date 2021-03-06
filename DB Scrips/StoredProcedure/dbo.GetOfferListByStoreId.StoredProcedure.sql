/****** Object:  StoredProcedure [dbo].[GetOfferListByStoreId]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetOfferListByStoreId 2,1,10
CREATE PROCEDURE [dbo].[GetOfferListByStoreId]
(	
	@StoreId int,
	@PageIndex int,
	@PageSize int
)
AS
BEGIN
	
	Select *,
	(Select OfferBannerId,Image 'OfferImage' from (
Select Image,OfferBannerId From OfferBanner OB Where OB.Deleted = 0 And Result.OfferId = OB.OfferId) AS jsonresult FOR json auto) 'OfferImagesList'
	From(Select 
	O.OfferId,
	O.[Name] 'Name',
	(Select (convert(varchar, O.StartDate, 106) + ' - ' + convert(varchar, O.EndDate, 106))) 'EffectiveDateRange',
	O.SortDescription,
	O.LongDescription,
	O.StartDate,
	O.EndDate,
	O.TermsAndConditions,
	O.Active,
	O.AddedDate
	From Offer O
	where O.Deleted = 0
	And O.StoreId = @StoreId
	order by O.AddedDate Desc
	OFFSET @PageSize * (@PageIndex - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY) as Result
	    
END
GO
