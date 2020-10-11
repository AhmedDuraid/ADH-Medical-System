CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[EmailConfirmed] [bit] NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[AuthenticationType] [nvarchar](256) NULL,
	[IsAuthenticated] [bit] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MmiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[PphoneNumber] [char](15) NULL,
	[Gender] [char](10) NOT NULL,
	[Nationality] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_users_create_date]  DEFAULT (getdate()) FOR [CreateDate]
GO


