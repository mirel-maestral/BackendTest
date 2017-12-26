-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetOrderForProcessing 
	@servicename NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRAN
    -- SELECTS FIRST NOT PROCESSED ORDER
	UPDATE TOP(1) Orders WITH (UPDLOCK) SET Locked = 1, LockedByInstance = @servicename 
		WHERE Locked = 0 AND Processed = 0
	
	IF @@ROWCOUNT = 0
		SELECT -1

	SELECT TOP 1 Id from Orders
		WHERE Processed = 0 AND Locked = 1 AND LockedByInstance = @servicename;

	COMMIT

END
