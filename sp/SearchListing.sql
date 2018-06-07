-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE [dbo].[SearchListing]
@lang int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	with listing as (
	select 
		case @lang when 1 then a.areaEn when 2 then a.areaTc when 3 then a.areaSc end as area,
		L.areaID,
		case @lang when 1 then d.districtEn when 2 then d.districtTc when 3 then d.districtSc end as district,
		L.districtID,
		L.titleEn, L.titleTc, L.subTitleEn, L.subTitleTc,
		L.room, L.bathroom, L.netSize, L.size, L.listingType,
		L.salePrice, L.rentPrice, L.descEn, L.descTc,
		L.classID, L.youTubeID, L.listingID
	from 
	houseRoot.listing L with (nolock)
	inner join houseRoot.district D with (nolock) on L.districtID = D.districtID
	inner join houseRoot.area A with (nolock) on L.areaID = A.areaID
	
	)
	select *,
	(
		select top 1 photoPath from houseRoot.listingPhoto p with (nolock)
		where p.listingID = listing.listingID order by p.displayOrder asc
	) as photoPath
	from listing 
	--inner join 
	--(
	--	select top 1 photoPath, listingID from houseRoot.listingPhoto p with (nolock)
	--	where p.listingID = l.listingID
	--)
	
END
GO
