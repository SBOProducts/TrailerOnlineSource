-- CREATED BY: Nathan Townsend
-- CREATED DATE: 1/6/2015
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Lookup_GetByLookup_Category]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Lookup_GetByLookup_Category]
    END
GO

CREATE PROCEDURE [dbo].[Lookup_GetByLookup_Category]
    @Category VarChar(50)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [LookupId],
        [Category],
        [Name],
        [Value],
        [Description]
    FROM [dbo].[Lookup]
    WHERE 
        [Category] = @Category

END