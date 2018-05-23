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
alter PROCEDURE [dbo].[CreatePayment]
@agencyID int,
@totalAmount int,
@paymentID int output 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into houseRoot.payment
	(agencyID, createDate, status, totalAmount, payDate)
	values 
	(@agencyID, GETDATE(), 0, @totalAmount, null)
	
	SELECT @paymentID = IDENT_CURRENT('payment') 
	
	if @totalAmount = 0
	Begin
		update houseRoot.payment set
		status = 1, payDate = GETDATE()
		where paymentID = @paymentID
	End

END
GO
