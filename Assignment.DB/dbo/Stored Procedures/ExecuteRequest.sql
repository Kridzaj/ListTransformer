-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ExecuteRequest]
	@GUID uniqueidentifier
AS
BEGIN
	
	declare @Name nvarchar(50), @LastName nvarchar(50), @ProcessRequestId int

	select 
	@ProcessRequestId = ProcessRequestId,
	@Name = [Name], 
	@LastName = [LastName] from dbo.ProcessRequest
	where Guid = @GUID

	update dbo.ProcessRequest
				set progress = 0,
				ProcessStatusId = 3 -- InProcess
			where ProcessRequestId = @ProcessRequestId

	create table #OutputsTemp 
	(
		Ordinal int, 
		Value nvarchar(100)
	)

	declare @ind int
	DECLARE @RandomDelay int
	set @ind = 1

	while @ind <= 100
	BEGIN
		
		insert into #OutputsTemp select @ind,dbo.GenerateOutputValue(@ind,@Name,@LastName)
		
		if @ind % 10 = 0
		BEGIN
			update dbo.ProcessRequest
				set Progress = @ind
			where  ProcessRequestId = @ProcessRequestId
		END


		select @ind = @ind +1
		select @RandomDelay = ABS(CHECKSUM(NEWID()) % 3)
		--WAITFOR DELAY @RandomDelay
	END

	begin tran
		insert into dbo.Output
		select Ordinal,Value,@ProcessRequestId  from #OutputsTemp

		update dbo.ProcessRequest
				set ProcessStatusId = 4 -- Processed
		where ProcessRequestId = @ProcessRequestId

	commit

	drop table #OutputsTemp

END
