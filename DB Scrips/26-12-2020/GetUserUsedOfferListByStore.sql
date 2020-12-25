USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetUserUsedOfferListByStore]    Script Date: 26-12-2020 01:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetUserUsedOfferListByStore 2,1,10
ALTER PROCEDURE [dbo].[GetUserUsedOfferListByStore]
(	
	@PageIndex int,
	@PageSize int
)
AS
BEGIN
	
	Select 
	UUO.UserUsedOfferId,
	U.FirstName + ' ' + U.LastName 'UserName',
	O.Name 'OfferName',
	UUO.RedeemDate
	from UserUsedOffer UUO
	inner join [User] U on U.UserId = UUO.UserId
	inner join [Offer] O on O.OfferId = UUO.OfferId
	where UUO.IsRedeem = 1 and UUO.Active = 1 and UUO.Deleted = 0
	order by UUo.AddedDate Desc
	OFFSET @PageSize * (@PageIndex - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY
	    
END