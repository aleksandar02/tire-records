CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Level] [varchar](100) NOT NULL,
	[Logger] [varchar](1000) NOT NULL,
	[Message] [varchar](3600) NOT NULL,
	[UserId] [int] NULL,
	[Exception] [varchar](3600) NULL,
	[StackTrace] [varchar](3600) NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]