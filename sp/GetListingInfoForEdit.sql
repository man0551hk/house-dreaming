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
alter PROCEDURE [dbo].[GetListingInfoForEdit]
@listingID int,
@lang int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select 
		case @lang when 1 then a.areaEn when 2 then a.areaTc when 3 then a.areaSc end as area,
		L.areaID,
		case @lang when 1 then d.districtEn when 2 then d.districtTc when 3 then d.districtSc end as district,
		L.districtID,
		L.titleEn, L.titleTc, L.subTitleEn, L.subTitleSc,
		L.room, L.bathroom, L.netSize, L.size, L.listingType,
		L.salePrice, L.rentPrice, L.descEn, L.descTc,
		L.classID, L.youTubeID
	from 
	houseRoot.listing L with (nolock)
	inner join houseRoot.district D with (nolock) on L.districtID = D.districtID
	inner join houseRoot.area A with (nolock) on L.areaID = A.areaID
	where L.listingID = @listingID
	

END
GO
