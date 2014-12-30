-- CREATED BY: Nathan Townsend
-- CREATED DATE: 12/30/2014
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Log_Update]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Log_Update]
    END
GO

CREATE PROCEDURE [dbo].[Log_Update]
    @Id Int,
    @Date DateTime,
    @Thread VarChar(255),
    @Level VarChar(50),
    @Logger VarChar(255),
    @Message VarChar(4000),
    @Exception VarChar(2000) = null
AS

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE [dbo].[Log]
    SET
        [Date] = @Date,
        [Thread] = @Thread,
        [Level] = @Level,
        [Logger] = @Logger,
        [Message] = @Message,
        [Exception] = @Exception
    WHERE
        [Id] = @Id

    SELECT @@ROWCOUNT AS UPDATED; 
END