-- CREATED BY: Nathan Townsend
-- CREATED DATE: 12/29/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[WebsiteUpdate_GetByPK]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[WebsiteUpdate_GetByPK]
    END
GO

CREATE PROCEDURE [dbo].[WebsiteUpdate_GetByPK]
    @WebsiteUpdateId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [WebsiteUpdateId],
        [VersionInstalled],
        [UpdateDescription],
        [PreviousVersion],
        [InstalledByUserName],
        [InstallDate]
    FROM [dbo].[WebsiteUpdate]
    WHERE 
        [WebsiteUpdateId] = @WebsiteUpdateId

END