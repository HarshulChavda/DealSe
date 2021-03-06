/****** Object:  StoredProcedure [dbo].[GetLimitedTimeOffers]    Script Date: 15-06-2021 01:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLimitedTimeOffers] 
@UserLatitude decimal(11,8),
@UserLongitude decimal(11,8),
@PageIndex int,
@PageSize int 
AS
BEGIN

			Declare @LimitedTimeOffers as varchar(MAX)='';

			set @LimitedTimeOffers=(select
			(Select 
			O.OfferId as OfferID,
			O.[Name] as Title,
			(Select TOP(1) [Image] from OfferBanner OB where OB.OfferId=O.OfferId and OB.Active=1 and OB.Deleted=0 and OB.Approved=1) as [Image],
			S.[Name] as StoreName,
			(select [Name] from Area A where A.AreaId=S.AreaId and A.Active=1) as AreaName,
			O.SortDescription as ShortDescription,
			O.LongDescription as OfferNote
			from Store S
			inner join Offer O on S.StoreId=O.StoreId and O.Active=1 and O.Deleted=0 and O.Approved=1 and O.LimitedTimeOffer=1
			where
			S.Deleted=0
			and
			s.Active=1
			and
			s.Approved=1
			and
			(SELECT 
			Cast(geography::Point(@UserLatitude,@UserLongitude, 4326).STDistance(geography::Point(S.Latitude,S.Longitude, 4326))/1000 As decimal)
			) < 250
			order by newid(),O.AddedDate
			OFFSET @PageSize * (@PageIndex - 1) ROWS
			FETCH NEXT @PageSize ROWS ONLY
			FOR JSON PATH
			) as 'LimitedTimeOffers')

			select ROW_NUMBER() OVER (Order By @LimitedTimeOffers) SrNo,
			@LimitedTimeOffers as 'LimitedTimeOffers'

END
GO
