CREATE TABLE [dbo].[Plan](
	[Id] [nvarchar](128) NOT NULL,
	[Day1] [text] NULL,
	[Day2] [text] NULL,
	[Day3] [text] NULL,
	[Day4] [text] NULL,
	[Day5] [text] NULL,
	[Day6] [text] NULL,
	[Day7] [text] NULL,
	[Description] [text] NOT NULL,
	[Type] [nvarchar](125) NOT NULL,
 CONSTRAINT [PK_medicine_plan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


