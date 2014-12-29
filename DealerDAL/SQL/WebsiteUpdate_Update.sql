-- CREATED BY: Nathan Townsend
-- CREATED DATE: 12/29/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[WebsiteUpdate_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[WebsiteUpdate_Update]
    END
GO

CREATE PROCEDURE [dbo].[WebsiteUpdate_Update]
    @WebsiteUpdateId Int,
    @VersionInstalled Int,
    @UpdateDescription VarChar(MAX),
    @PreviousVersion Int,
    @InstalledByUserName VarChar(50),
    @InstallDate DateTime
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[WebsiteUpdate]
    SET
        [VersionInstalled] = @VersionInstalled,
        [UpdateDescription] = @UpdateDescription,
        [PreviousVersion] = @PreviousVersion,
        [InstalledByUserName] = @InstalledByUserName,
        [InstallDate] = @InstallDate
    WHERE
        [WebsiteUpdateId] = @WebsiteUpdateId

    SELECT @@ROWCOUNT AS UPDATED; 
END