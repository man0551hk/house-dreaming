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
alter PROCEDURE [dbo].[InsertAgency]
@companyNameEn varchar(45), 
@companyNameTc nvarchar(45), 
@companyNameSc nvarchar(45), 
@companyLicense varchar(15), 
@agentNameEn varchar(45), 
@agentNameTc nvarchar(45), 
@agentNameSc nvarchar(45), 
@agentLicense varchar(15), 
@email varchar(60), 
@mobile int, 
@officePhone int, 
@fax int, 
@gender varchar(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into houseRoot.agency (companyNameEn, companyNameTc, companyNameSc, companyLicense, agentNameEn, agentNameTc, agentNameSc, agentLicense, email, mobile, officePhone, fax, gender, createDate)
	values 
	(@companyNameEn, @companyNameTc, @companyNameSc, 
	@companyLicense, @agentNameEn, @agentNameTc, @agentNameSc, 
	@agentLicense, @email, @mobile, @officePhone, @fax, @gender, GETDATE())

END
GO
