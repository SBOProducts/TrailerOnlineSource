-- CREATED BY: Nathan Townsend
-- CREATED DATE: 12/30/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[WebsiteUpdateLog_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[WebsiteUpdateLog_Update]
    END
GO

CREATE PROCEDURE [dbo].[WebsiteUpdateLog_Update]
    @WebsiteUpdateId Int,
    @InstallSequence Int,
    @ActionType VarChar(50),
    @Message VarChar(500)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[WebsiteUpdateLog]
    SET
        [WebsiteUpdateId] = @WebsiteUpdateId,
        [InstallSequence] = @InstallSequence,
        [ActionType] = @ActionType,
        [Message] = @Message
    WHERE
        [WebsiteUpdateId] = @WebsiteUpdateId AND
        [InstallSequence] = @InstallSequence

    SELECT @@ROWCOUNT AS UPDATED; 
END