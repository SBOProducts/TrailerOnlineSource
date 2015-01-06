-- CREATED BY: Nathan Townsend
-- CREATED DATE: 1/6/2015
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[WebsiteUpdateLog_Delete]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[WebsiteUpdateLog_Delete]
    END
GO

CREATE PROCEDURE [dbo].[WebsiteUpdateLog_Delete]
    @WebsiteUpdateId Int,
        @InstallSequence Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DELETE 
        [dbo].[WebsiteUpdateLog]
    WHERE
        [WebsiteUpdateId] = @WebsiteUpdateId AND
        [InstallSequence] = @InstallSequence

    SELECT @@ROWCOUNT AS DELETED; 
END