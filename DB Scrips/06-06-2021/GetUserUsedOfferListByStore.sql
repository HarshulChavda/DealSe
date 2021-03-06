USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetUserUsedOfferListByStore]    Script Date: 06-06-2021 20:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--GetUserUsedOfferListByStore 8,1,5
ALTER PROCEDURE [dbo].[GetUserUsedOfferListByStore]
(	
	@StoreId int,
	@PageIndex int,
	@PageSize int
)
AS
BEGIN
	
	Select 
	UUO.UserUsedOfferId,
	U.[Name] 'UserName',
	U.MobileNo 'UserMobileNo',
	O.Name 'OfferName',
	UUO.RedeemDate
	from UserUsedOffer UUO
	inner join [User] U on U.UserId = UUO.UserId
	inner join [Offer] O on O.OfferId = UUO.OfferId
	where O.StoreId = @StoreId and UUO.IsRedeem = 1 and UUO.Active = 1 and UUO.Deleted = 0
	order by UUo.AddedDate
	OFFSET @PageSize * (@PageIndex - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY
	    
END
