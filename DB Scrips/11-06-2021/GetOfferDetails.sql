USE [DealSe]
GO
/****** Object:  StoredProcedure [dbo].[GetOfferDetails]    Script Date: 11-06-2021 23:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec GetOfferDetails 6
ALTER PROCEDURE [dbo].[GetOfferDetails]
@OfferID int
AS
BEGIN
	
	Select 
	O.OfferId as OfferID,
	O.[Name] as Title,
	S.[Name] as StoreName,
	S.[Address] as StoreAddress,
	O.StartDate as StartDate,
	O.EndDate as EndDate,
	S.MobileNo1 as StoreContact,
	S.OwnerMobileNo as StoreOwnerContact,
	O.SortDescription as ShortDescription,
	S.Latitude as StoreLatitude,
	S.Longitude as StoreLongitude,
	O.TermsAndConditions as TermsAndConditions,
	(select OB.OfferBannerId,[Image] from OfferBanner OB 
	where OB.OfferId=@OfferID and OB.Active=1 and OB.Approved=1 and OB.Deleted=0 for json PATH) as 'OfferImages',
	(select (
		select
			MondayOpenHours,
			MondayCloseHours,
			TuesdayOpenHours,
			TuesdayCloseHours,
			WednesdayOpenHours,
			WednesdayCloseHours,
			ThursdayOpenHours,
			ThursdayCloseHours,
			FridayOpenHours,
			FridayCloseHours,
			SaturdayOpenHours,
			SaturdayCloseHours,
			SundayOpenHours,
			SundayCloseHours 
		from StoreTime ST where ST.Active=1 and ST.Deleted=0 for Json PATH) 
	) as 'StoreTimes'
	from Offer O 
	inner join Store S on O.StoreId=S.StoreId and S.Active=1 and S.Deleted=0 and S.Approved=1
	where O.OfferId=@OfferID and
	O.Deleted=0 and O.Active=1 and O.Approved=1
END
