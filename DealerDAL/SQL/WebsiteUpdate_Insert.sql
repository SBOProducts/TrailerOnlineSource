-- CREATED BY: Nathan Townsend
-- CREATED DATE: 1/6/2015
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[WebsiteUpdate_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[WebsiteUpdate_Insert]
    END
GO

CREATE PROCEDURE [dbo].[WebsiteUpdate_Insert]
    @VersionInstalled Int,
    @UpdateDescription VarChar(MAX),
    @InstallDate DateTime
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO [dbo].[WebsiteUpdate]
	(
        [VersionInstalled],
        [UpdateDescription],
        [InstallDate]
    ) VALUES (
        @VersionInstalled,
        @UpdateDescription,
        @InstallDate
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END