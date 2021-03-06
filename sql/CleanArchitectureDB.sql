CREATE DATABASE CleanArchitectureDB
GO
USE CleanArchitectureDB

/****** Object:  Table [dbo].[LoginLogs]    Script Date: 16-11-2020 05:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginLogs](
	[LoginLogId] [uniqueidentifier] NOT NULL,
	[LoginLogInd] [bigint] IDENTITY(1,1) NOT NULL,
	[LoginDate] [datetime] NULL,
	[LoginUserIP] [nvarchar](50) NULL,
	[LoginSuccess] [bit] NULL,
	[LoginLogTypeId] [uniqueidentifier] NULL,
	[UserIdentifier] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoginLogs] PRIMARY KEY CLUSTERED 
(
	[LoginLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginLogTypes]    Script Date: 16-11-2020 05:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginLogTypes](
	[LoginLogTypeId] [uniqueidentifier] NOT NULL,
	[LoginLogTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoginLogTypes] PRIMARY KEY CLUSTERED 
(
	[LoginLogTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 16-11-2020 05:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[PasswordSalt] [nvarchar](max) NOT NULL,
	[UserStatusId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserStatuses]    Script Date: 16-11-2020 05:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatuses](
	[UserStatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusDescription] [nvarchar](50) NULL,
	[StatusValue] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserStatuses] PRIMARY KEY CLUSTERED 
(
	[UserStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 16-11-2020 05:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserTokenId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Token] [nvarchar](max) NOT NULL,
	[JwtToken] [nvarchar](max) NOT NULL,
	[ExpireDate] [datetime] NOT NULL,
	[ReplacedByToken] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[RevokedDate] [datetime] NULL,
	[CreatedByIp] [nvarchar](50) NOT NULL,
	[RevokedByIp] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserTokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Users] ([UserId], [UserName], [FirstName], [LastName], [UserEmail], [PasswordHash], [PasswordSalt], [UserStatusId], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (N'9ffa5061-f38b-a621-e0ee-3793d7eaf67b', N'system', N'System', N'Admin', N'systemadmin@gmail.com', N'VKM8pU0kY4yi+pWhfSP91E/gNKM1Kg3A7w3JI9CigiXoCpWJWQjFt2IIoxtkR88mljbD/BcY7Lb0+L6IVkmfuw==', N'jHRSqxS9/D3wZFq/ikOZy4RXOujJ18ybBq3HU1yzQdIa3nus5XpY84Xu2xrN+TGkOb74S6ZTl4gKgPrkmwCcJ3QU6jMiVIlmTDeFdwTLLnTaaqZkv/18du6uD9uGyvKvD3IeV2aQAMKCqB0yZIwfeI6F1TY2py61iAB5kugPs5o=', 1, CAST(N'2020-11-14 23:16:01.333' AS DateTime), NULL, N'9ffa5061-f38b-a621-e0ee-3793d7eaf67b', NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [FirstName], [LastName], [UserEmail], [PasswordHash], [PasswordSalt], [UserStatusId], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (N'24d2c710-2db7-4d01-9235-c28b9df1a06b', N'sunilkumarboda', N'Sunil', N'Kumar', N'sunilkumar@test.com', N'fn4ZxO06eTjNq59Rv0F56kCgyS7TmiFbPDUQ/VxVweKU6Bj5K2F5QGA9BMkZ2OHjOEHYsYzEdKE1nWl0b1xddg==', N'+nxWhH6cfI0rnvC8buxt9cb8RH5QM900m70kbetegqPhUegcLdI/oqD1I6nSn4UFX15Qg3fOeuW3SKWWSWwbFno6nurIOYZMzPnJGdHhtCynX72LjsvhIzPNbt+ctoE262y5kK2YGj6JiNSR9kXLPCPTCQ0EaZPfrlWPbQm547M=', 1, CAST(N'2020-11-15 13:34:12.430' AS DateTime), NULL, N'9ffa5061-f38b-a621-e0ee-3793d7eaf67b', N'00000000-0000-0000-0000-000000000000')
SET IDENTITY_INSERT [dbo].[UserStatuses] ON 

INSERT [dbo].[UserStatuses] ([UserStatusId], [StatusDescription], [StatusValue]) VALUES (1, N'Active', N'Active')
INSERT [dbo].[UserStatuses] ([UserStatusId], [StatusDescription], [StatusValue]) VALUES (2, N'InActive', N'InActive')
INSERT [dbo].[UserStatuses] ([UserStatusId], [StatusDescription], [StatusValue]) VALUES (3, N'Locked', N'Locked')
SET IDENTITY_INSERT [dbo].[UserStatuses] OFF
ALTER TABLE [dbo].[LoginLogs]  WITH CHECK ADD  CONSTRAINT [FK_LoginLogs_LoginLogTypes] FOREIGN KEY([LoginLogTypeId])
REFERENCES [dbo].[LoginLogTypes] ([LoginLogTypeId])
GO
ALTER TABLE [dbo].[LoginLogs] CHECK CONSTRAINT [FK_LoginLogs_LoginLogTypes]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserStatuses] FOREIGN KEY([UserStatusId])
REFERENCES [dbo].[UserStatuses] ([UserStatusId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserStatuses]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users]
GO

GO
INSERT [dbo].[LoginLogTypes] ([LoginLogTypeId], [LoginLogTypeName]) VALUES (N'1841087a-c077-4f86-8462-5914279bbb83', N'Success')
GO
INSERT [dbo].[LoginLogTypes] ([LoginLogTypeId], [LoginLogTypeName]) VALUES (N'5077898b-82e1-48cb-83b4-933aa473bfac', N'SSOSuccess')
GO
INSERT [dbo].[LoginLogTypes] ([LoginLogTypeId], [LoginLogTypeName]) VALUES (N'35e328e5-405c-412b-ba5c-d329157236c2', N'IncorrectUserNameOrPassword')
GO
INSERT [dbo].[LoginLogTypes] ([LoginLogTypeId], [LoginLogTypeName]) VALUES (N'f177ab9d-3808-41c9-8256-d97ecf9b6107', N'UserInActive')
GO

/****** Object:  Table [dbo].[EmailTemplates]    Script Date: 21-11-2020 02:32:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailTemplates](
	[EmailTemplateId] [uniqueidentifier] NOT NULL,
	[EmailTemplateInd] [bigint] IDENTITY(1,1) NOT NULL,
	[EmailTemplateName] [nvarchar](200) NULL,
	[EmailLabel] [nvarchar](50) NULL,
	[EmailSubject] [nvarchar](500) NULL,
	[EmailSenderEmail] [nvarchar](50) NULL,
	[EmailContent] [nvarchar](max) NULL,
	[EmailSignature] [nvarchar](500) NULL,
	[IsMasterTemplate] [bit] NULL,
	[EmailIsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_EmailTemplates] PRIMARY KEY CLUSTERED 
(
	[EmailTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

INSERT INTO [dbo].[EmailTemplates]
           ([EmailTemplateId]
           ,[EmailTemplateName]
           ,[EmailLabel]
           ,[EmailSubject]
           ,[EmailSenderEmail]
           ,[EmailContent]
           ,[EmailSignature]
           ,[IsMasterTemplate]
           ,[EmailIsActive]
           ,[CreatedDate]
           ,[UpdatedDate]
           ,[CreatedBy]
           ,[UpdatedBy])
     VALUES
           ('18cb6a71-34f5-4bed-8d19-346f5b8c019d'
           ,'ForgotPasswordNotification'
           ,'Forgot Password Notification'
           ,'Reset Password'
           ,'info@gmail.com'
           ,'Dear [Username], Your temporary password is [password]'
           ,''
           ,1
           ,1
           ,GETDATE()
           ,GETDATE()
           ,'9ffa5061-f38b-a621-e0ee-3793d7eaf67b'
           ,'9ffa5061-f38b-a621-e0ee-3793d7eaf67b')
GO


/****** Object:  Table [dbo].[EmailRecipients]    Script Date: 21-11-2020 02:32:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailRecipients](
	[EmailRecipientId] [uniqueidentifier] NOT NULL,
	[EmailTemplateID] [uniqueidentifier] NULL,
	[RecipientUserID] [uniqueidentifier] NULL,
	[RecipientEmail] [nvarchar](200) NULL,
	[EmailLabel] [nvarchar](50) NULL,
	[EmailSubject] [nvarchar](500) NULL,
	[EmailSenderEmail] [nvarchar](50) NULL,
	[EmailContent] [nvarchar](max) NULL,
	[EmailSignature] [nvarchar](500) NULL,
	[IsPending] [bit] NULL,
	[ToBeProcessedOn] [datetime] NULL,
	[EmailSentOn] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_EmailRecipients] PRIMARY KEY CLUSTERED 
(
	[EmailRecipientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO