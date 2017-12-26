-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetOrderForProcessing 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- SELECTS FIRST NOT PROCESSED ORDER
	
	SELECT top 1 Id from Orders
		WHERE Processed = 0;
END
