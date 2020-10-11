CREATE TABLE [dbo].[LabTests](
	[Id] [nvarchar](128) NOT NULL,
	[TestName] [nvarchar](128) NOT NULL,
	[Description] [text] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_lab_tests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[LabTests] ADD  CONSTRAINT [DF_lab_tests_last_update]  DEFAULT (getdate()) FOR [LastUpdate]
GO


