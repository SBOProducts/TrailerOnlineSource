-- CREATED BY: Nathan Townsend
-- CREATED DATE: 1/6/2015
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Lookup_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Lookup_Insert]
    END
GO

CREATE PROCEDURE [dbo].[Lookup_Insert]
    @Category VarChar(50),
    @Name VarChar(50),
    @Value VarChar(50),
    @Description VarChar(MAX) = null
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Lookup]
	(
        [Category],
        [Name],
        [Value],
        [Description]
    ) VALUES (
        @Category,
        @Name,
        @Value,
        @Description
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END