-- CREATED BY: Nathan Townsend
-- CREATED DATE: 12/29/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[WebsiteUpdateLog_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[WebsiteUpdateLog_Insert]
    END
GO

CREATE PROCEDURE [dbo].[WebsiteUpdateLog_Insert]
    @WebsiteUpdateId Int,
    @InstallSequence Int,
    @InstallAction VarChar(50),
    @SourceFilePath VarChar(250),
    @DestinationFilePath VarChar(250)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[WebsiteUpdateLog]
	(
        [WebsiteUpdateId],
        [InstallSequence],
        [InstallAction],
        [SourceFilePath],
        [DestinationFilePath]
    ) VALUES (
        @WebsiteUpdateId,
        @InstallSequence,
        @InstallAction,
        @SourceFilePath,
        @DestinationFilePath
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END