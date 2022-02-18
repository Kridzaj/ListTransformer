-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION dbo.GenerateOutputValue 
(
	@Index int,
	@Name nvarchar(50),
	@LastName nvarchar(50)
)
RETURNS nvarchar(100)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RetVal nvarchar(100)

	select @RetVal = CASE 
	WHEN @Index % 15  = 0 then @Name + @LastName
	WHEN @Index % 3 = 0 THEN @Name
	WHEN @Index % 5 = 0 THEN @LastName
	ELSE CAST(@Index as nvarchar(100))
	END

	-- Return the result of the function
	RETURN @RetVal

END
