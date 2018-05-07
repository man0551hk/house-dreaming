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
create PROCEDURE [dbo].[AdminLogin]
@login varchar(30),
@password varchar(30),
@accessKey  varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @adminID int= 0

	select @adminID = adminID from houseRoot.adminUser with (nolock)
	where login = @login and password = @password
	
	if (@adminID != 0)
	Begin
		update houseRoot.adminUser set accessKey = @accessKey where adminID = @adminID
		select @adminID
	End
	select @adminID
END
GO
