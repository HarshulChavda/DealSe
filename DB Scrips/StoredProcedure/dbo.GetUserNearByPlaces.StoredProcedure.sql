USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetUserNearByPlaces]    Script Date: 27-06-2021 22:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec GetUserNearByPlaces 7,'23.0000000000','72.0000000000',1,10
ALTER PROCEDURE [dbo].[GetUserNearByPlaces]
@CategoryID int,
@UserLatitude decimal(11,8),
@UserLongitude decimal(11,8),
@PageIndex int,
@PageSize int 
AS
BEGIN

			Declare @UserNearByPlaces as nvarchar(MAX)='';
			
			if(@CategoryID<>0)
				begin
					set @UserNearByPlaces = (Select  (Select 
						O.OfferId as OfferID,
						O.[Name] as OfferName,
						S.[Logo] as StoreImage,
						S.[Name] as StoreName,
						(select [Name] from Area A where A.AreaId=S.AreaId and A.Active=1) as AreaName,
						O.SortDescription as OfferShortDescription,
						O.LongDescription as OfferLongDescription 
						from Offer O
						inner join Store S on O.StoreId=S.StoreId and S.Active=1 and S.Deleted=0 and S.Approved=1
						inner join StoreType ST on S.StoreTypeId=ST.StoreTypeId and ST.StoreTypeId=@CategoryID and ST.Deleted=0 and ST.Active=1
						where 
						O.Deleted=0 and O.Active=1 and O.Approved=1
						and
						(SELECT 
						Cast(geography::Point(@UserLatitude,@UserLongitude, 4326).STDistance(geography::Point(S.Latitude,S.Longitude, 4326))/1000 As decimal)
						) < 250 
						order by newid(),O.AddedDate
						OFFSET @PageSize * (@PageIndex - 1) ROWS
						FETCH NEXT @PageSize ROWS ONLY
						for json PATH
						) as 'UserNearByPlaces')
				end
			else
				begin
						set @UserNearByPlaces = (Select  (Select 
						O.OfferId as OfferID,
						O.[Name] as OfferName,
						S.[Logo] as StoreImage,
						S.[Name] as StoreName,
						(select [Name] from Area A where A.AreaId=S.AreaId and A.Active=1) as AreaName,
						O.SortDescription as OfferShortDescription,
						O.LongDescription as OfferLongDescription 
						from Offer O
						inner join Store S on O.StoreId=S.StoreId and S.Active=1 and S.Deleted=0 and S.Approved=1
						where 
						O.Deleted=0 and O.Active=1 and O.Approved=1
						and
						(SELECT 
						Cast(geography::Point(@UserLatitude,@UserLongitude, 4326).STDistance(geography::Point(S.Latitude,S.Longitude, 4326))/1000 As decimal)
						) < 250 
						order by newid(),O.AddedDate
						OFFSET @PageSize * (@PageIndex - 1) ROWS
						FETCH NEXT @PageSize ROWS ONLY
						for json PATH
						) as 'UserNearByPlaces')
				end
				
				select ROW_NUMBER() OVER (Order By @UserNearByPlaces) SrNo,
				@UserNearByPlaces as 'UserNearByPlaces'
END