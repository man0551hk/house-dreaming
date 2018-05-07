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
alter PROCEDURE [dbo].[GetPendingListing]
@agencyID int,
@lang int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select listingID, titleEn, titleTc, subTitleEn, subTitleTc, room, 
	bathroom, size, netSize, 
	listingType,
	salePrice, rentPrice,
	case when @lang = 1 then D.districtEn when @lang = 2 then D.districtTc when @lang = 3 then D.districtSc end as district
	from houseRoot.listing L with (nolock)
	inner join houseRoot.district D with (nolock) on L.districtID = D.districtID
	where agencyID = @agencyID and paymentID is null

END
GO
