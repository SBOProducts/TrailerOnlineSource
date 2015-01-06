-- CREATED BY: Nathan Townsend
-- CREATED DATE: 1/6/2015
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Lookup_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Lookup_Update]
    END
GO

CREATE PROCEDURE [dbo].[Lookup_Update]
    @LookupId Int,
    @Category VarChar(50),
    @Name VarChar(50),
    @Value VarChar(50),
    @Description VarChar(MAX) = null
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[Lookup]
    SET
        [Category] = @Category,
        [Name] = @Name,
        [Value] = @Value,
        [Description] = @Description
    WHERE
        [LookupId] = @LookupId

    SELECT @@ROWCOUNT AS UPDATED; 
END