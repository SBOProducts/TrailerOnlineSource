-- CREATED BY: Nathan Townsend
-- CREATED DATE: 1/6/2015
-- DO NOT MODIFY THIS CODE
-- CHANGES WILL BE LOST WHEN THE GENERATOR IS RUN AGAIN
-- GENERATION TOOL: Dalapi Code Generator (DalapiPro.com)



USE [DB_99F0A1_DealerDB]

-- Drop the procedure if it exists.
If OBJECT_ID('[dbo].[Log_Insert]') IS NOT NULL
    BEGIN
    DROP PROCEDURE [dbo].[Log_Insert]
    END
GO

CREATE PROCEDURE [dbo].[Log_Insert]
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

    INSERT INTO [dbo].[Log]
	(
        [Date],
        [Thread],
        [Level],
        [Logger],
        [Message],
        [Exception]
    ) VALUES (
        @Date,
        @Thread,
        @Level,
        @Logger,
        @Message,
        @Exception
	)

	-- return the new identity value
	SELECT SCOPE_IDENTITY()

END