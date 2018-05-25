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
alter PROCEDURE [dbo].[UpdateListing]
@listingID int, 
@titleEN varchar(200), 
@titleTc nvarchar(200), 
@titleSc nvarchar(200),
@subTitleEn varchar(200), 
@subTitleTc nvarchar(200), 
@subTitleSc nvarchar(200),
@room int,
@bathroom int,
@netSize int,
@size int, 
@listingType int, 
@salePrice int, 
@rentPrice int,
@descEn varchar(max), 
@descTc nvarchar(max), 
@descSc nvarchar(max), 
@youTubeID varchar(45),
@keyword nvarchar(2000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update houseRoot.listing set 
	titleEn = @titleEN,
	titleTc = @titleTc,
	titleSc = @titleSc,
	subTitleEn = @subTitleEn,
	subTitleTc = @subTitleTc,
	modifiedDate = dateadd(hour,8,getdate()),
	room = @room,
	bathroom = @bathroom,
	netSize = @netSize,
	size = @size,
	listingType = @listingType,
	salePrice = @salePrice,
	rentPrice = @rentPrice,
	descEn = @descEn,
	descTc =  @descTc,
	descSc = @descSc,
	youTubeID = @youTubeID,
	keyword = @keyword
	where listingID = @listingID
	

END
GO
