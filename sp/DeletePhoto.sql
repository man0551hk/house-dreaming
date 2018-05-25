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
create PROCEDURE [dbo].[DeletePhoto]
@photoID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @listingID int
	select @listingID = listingID from houseRoot.listingPhoto where photoID = @photoID
	
	delete from houseRoot.listingPhoto where photoID = @photoID
	
	
	UPDATE houseRoot.listingPhoto 
	SET displayOrder = i.RowID
	FROM (
		select photoID, ROW_NUMBER() OVER(ORDER BY displayOrder ASC) AS RowID
		from houseRoot.listingPhoto  with (nolock) where listingID = @listingID
		 ) i
	WHERE 
		i.photoID = houseRoot.listingPhoto.photoID

END
GO