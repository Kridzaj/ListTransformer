CREATE TABLE [dbo].[Output] (
    [OutputId]         INT            IDENTITY (1, 1) NOT NULL,
    [Ordinal]          INT            NOT NULL,
    [Value]            NVARCHAR (100) NOT NULL,
    [ProcessRequestId] INT            NOT NULL,
    CONSTRAINT [PK_Outputs] PRIMARY KEY CLUSTERED ([OutputId] ASC),
    CONSTRAINT [FK_Output_ProcessRequest] FOREIGN KEY ([ProcessRequestId]) REFERENCES [dbo].[ProcessRequest] ([ProcessRequestId])
);

