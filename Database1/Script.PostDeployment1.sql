/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


--INSERTING ORDERS FOR TESTING
DECLARE @cnt INT = 0;

WHILE @cnt < 300000
BEGIN
   INSERT INTO Orders(Processed, Locked)
   VALUES(0, 0)
   SET @cnt = @cnt + 1;
END;
