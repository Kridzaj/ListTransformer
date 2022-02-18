CREATE TABLE [dbo].[ProcessRequest] (
    [ProcessRequestId] INT              IDENTITY (1, 1) NOT NULL,
    [Guid]             UNIQUEIDENTIFIER CONSTRAINT [DF_ProcessRequest_Guid] DEFAULT (newid()) NOT NULL,
    [Created]          DATETIME         CONSTRAINT [DF_ProcessRequest_Created] DEFAULT (getdate()) NOT NULL,
    [Processed]        DATETIME         NULL,
    [ProcessStatusId]  SMALLINT         CONSTRAINT [DF_ProcessRequest_ProcessStatusId] DEFAULT ((1)) NOT NULL,
    [Name]             NVARCHAR (50)    NULL,
    [LastName]         NVARCHAR (50)    NULL,
    [Progress]         INT              CONSTRAINT [DF_ProcessRequest_Progress] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_ProcessRequest] PRIMARY KEY CLUSTERED ([ProcessRequestId] ASC)
);

