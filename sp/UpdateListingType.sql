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
create PROCEDURE [dbo].[UpdateListingType]
@nameEn varchar(20),
@nameTc nvarchar(20),
@nameSc nvarchar(20),
@price int,
@typeID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update houseRoot.listingType 
	set typeNameEn = @nameEn,
	typeNameTc = @nameTc,
	typeNameSc = @nameSc,
	price = @price
	where 
	typeID = @typeID
	

END
GO
