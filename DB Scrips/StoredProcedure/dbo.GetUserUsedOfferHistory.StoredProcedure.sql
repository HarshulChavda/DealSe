/****** Object:  StoredProcedure [dbo].[GetUserUsedOfferHistory]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec GetUserUsedOfferHistory 1
CREATE PROCEDURE [dbo].[GetUserUsedOfferHistory]
(@UserID int,
@PageIndex int,
@PageSize int
)
AS
BEGIN

select * from (Select 
USO.OfferId as OfferID,
O.[Name] as Title,
S.Logo as [Image],
S.[Name] as StoreName,
A.[Name] as AreaName,
S.[Address] as StoreAddress,
O.SortDescription as ShortDescription,
O.LongDescription as OfferNote,
(Select FORMAT(USO.RedeemDate, 'dd/MM/yyyy, hh:mm:ss ')) 'RedeemDate'
from UserUsedOffer USO 
inner join Offer O on USO.OfferId=O.OfferId  and O.Deleted=0  
inner join Store S on O.StoreId=S.StoreId and S.Deleted=0
inner join Area A on S.AreaId=A.AreaId
where USO.Active=1 and USO.IsRedeem=1 and USO.Deleted=0  and USO.UserId = @UserID
order by O.AddedDate Desc
OFFSET @PageSize * (@PageIndex - 1) ROWS
FETCH NEXT @PageSize ROWS ONLY) as Result

END
/****** Object:  StoredProcedure [dbo].[GetLimitedTimeOffers]    Script Date: 2/28/2021 2:31:13 PM ******/
SET ANSI_NULLS ON
GO
