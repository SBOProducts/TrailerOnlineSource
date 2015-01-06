-- CREATED BY: Nathan Townsend
-- CREATED DATE: 1/6/2015
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[MetaTags_GetByPK]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[MetaTags_GetByPK]
    END
GO

CREATE PROCEDURE [dbo].[MetaTags_GetByPK]
    @MetaTagsId Int
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
        [MetaTagsId],
        [Title],
        [Description],
        [KeyWords],
        [Author],
        [Robots]
    FROM [dbo].[MetaTags]
    WHERE 
        [MetaTagsId] = @MetaTagsId

END