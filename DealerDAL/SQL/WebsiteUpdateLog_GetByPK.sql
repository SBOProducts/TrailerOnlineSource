-- CREATED BY: Nathan Townsend
-- CREATED DATE: 12/30/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[WebsiteUpdateLog_GetByPK]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[WebsiteUpdateLog_GetByPK]
    END
GO

CREATE PROCEDURE [dbo].[WebsiteUpdateLog_GetByPK]
    @WebsiteUpdateId Int,
    @InstallSequence Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [WebsiteUpdateId],
        [InstallSequence],
        [ActionType],
        [Message]
    FROM [dbo].[WebsiteUpdateLog]
    WHERE 
        [WebsiteUpdateId] = @WebsiteUpdateId AND
        [InstallSequence] = @InstallSequence

END