-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MarkOrderAsProcessed]
	-- Add the parameters for the stored procedure here
	@orderid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRAN

    update Orders set Processed = 1 
	where Id = @orderid

	INSERT INTO ProcessingLog([Time], OrderId) VALUES(GETDATE(), @orderid)

	COMMIT
END
