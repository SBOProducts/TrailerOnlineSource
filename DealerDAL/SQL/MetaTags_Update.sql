-- CREATED BY: Nathan Townsend
-- CREATED DATE: 1/6/2015
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[MetaTags_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[MetaTags_Update]
    END
GO

CREATE PROCEDURE [dbo].[MetaTags_Update]
    @MetaTagsId Int,
    @Title VarChar(52),
    @Description VarChar(250),
    @KeyWords VarChar(250),
    @Author VarChar(50),
    @Robots VarChar(10)
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[MetaTags]
    SET
        [Title] = @Title,
        [Description] = @Description,
        [KeyWords] = @KeyWords,
        [Author] = @Author,
        [Robots] = @Robots
    WHERE
        [MetaTagsId] = @MetaTagsId

    SELECT @@ROWCOUNT AS UPDATED; 
END