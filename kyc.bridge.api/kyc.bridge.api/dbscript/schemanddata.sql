USE [master]
GO
/****** Object:  Database [kycbridge]    Script Date: 04/26/2020 20:39:20 ******/
CREATE DATABASE [kycbridge] ON  PRIMARY 
( NAME = N'kycbridge', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\kycbridge.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'kycbridge_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\kycbridge_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [kycbridge] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kycbridge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kycbridge] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [kycbridge] SET ANSI_NULLS OFF
GO
ALTER DATABASE [kycbridge] SET ANSI_PADDING OFF
GO
ALTER DATABASE [kycbridge] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [kycbridge] SET ARITHABORT OFF
GO
ALTER DATABASE [kycbridge] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [kycbridge] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [kycbridge] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [kycbridge] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [kycbridge] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [kycbridge] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [kycbridge] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [kycbridge] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [kycbridge] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [kycbridge] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [kycbridge] SET  DISABLE_BROKER
GO
ALTER DATABASE [kycbridge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [kycbridge] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [kycbridge] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [kycbridge] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [kycbridge] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [kycbridge] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [kycbridge] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [kycbridge] SET  READ_WRITE
GO
ALTER DATABASE [kycbridge] SET RECOVERY SIMPLE
GO
ALTER DATABASE [kycbridge] SET  MULTI_USER
GO
ALTER DATABASE [kycbridge] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [kycbridge] SET DB_CHAINING OFF
GO
USE [kycbridge]
GO
/****** Object:  Table [dbo].[RequestResponseLog]    Script Date: 04/26/2020 20:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequestResponseLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestBody] [varchar](5000) NULL,
	[RequestUrl] [varchar](1000) NULL,
	[HttpMethodType] [varchar](10) NULL,
	[RequestTime] [datetime] NULL,
	[ResponseBody] [varchar](5000) NULL,
	[ResponseTime] [datetime] NULL,
	[ResponseHttpCode] [varchar](10) NULL,
 CONSTRAINT [PK_RequestResponseLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[RequestResponseLog] ON
INSERT [dbo].[RequestResponseLog] ([Id], [RequestBody], [RequestUrl], [HttpMethodType], [RequestTime], [ResponseBody], [ResponseTime], [ResponseHttpCode]) VALUES (1, N'{"transactionRef":"SF|KYC|BS|HBN|1525471167246589","bvn":"22222222223"}', N'http://verified.ng:8130/bvn', N'POST', CAST(0x0000AB8B00FE46A9 AS DateTime), N'{"message":"Success","verified":true,"status":"COMPLETED","transactionRef":"SF|KYC|BS|HBN|1525471167246589","faceMatchStatus":"","faceMatchScore":0.0}', CAST(0x0000AB8B00FE811F AS DateTime), N'')
INSERT [dbo].[RequestResponseLog] ([Id], [RequestBody], [RequestUrl], [HttpMethodType], [RequestTime], [ResponseBody], [ResponseTime], [ResponseHttpCode]) VALUES (2, N'{"transactionRef":"SF|KYC|BS|HBN|1905278436282878","bvn":"22222222223"}', N'http://verified.ng:8130/bvn', N'POST', CAST(0x0000AB93013A9CCE AS DateTime), N'', CAST(0x0000AB93013AAF98 AS DateTime), N'')
INSERT [dbo].[RequestResponseLog] ([Id], [RequestBody], [RequestUrl], [HttpMethodType], [RequestTime], [ResponseBody], [ResponseTime], [ResponseHttpCode]) VALUES (3, N'{"transactionRef":"SF|KYC|BS|HBN|2046010237881967","bvn":"22222222223"}', N'http://verified.ng:8130/bvn', N'POST', CAST(0x0000AB9D01563AD8 AS DateTime), N'{"message":"Success","verified":true,"status":"COMPLETED","transactionRef":"SF|KYC|BS|HBN|2046010237881967","faceMatchStatus":"","faceMatchScore":0.0}', CAST(0x0000AB9D01564096 AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[RequestResponseLog] OFF
/****** Object:  Table [dbo].[ExceptionLog]    Script Date: 04/26/2020 20:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorMessage] [text] NULL,
	[ErrorStacktrace] [text] NULL,
	[ErrorSource] [text] NULL,
	[ErrorDatetime] [datetime] NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ExceptionLog] ON
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (1, N'The type initializer for ''kyc.bridge.api.DataAccess.Seamfix.KycService'' threw an exception.', N'   at kyc.bridge.api.DataAccess.Seamfix.KycService.IdServiceValidation(IdValidationRequest idValidation)
   at kyc.bridge.api.BusinessLogic.KycLogic.IdValidationProcessor(IdValidationRequest idValidationRequest) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\BusinessLogic\KycLogic.cs:line 21', N'kyc.bridge.api', CAST(0x0000AB7900F04D18 AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (2, N'The type initializer for ''kyc.bridge.api.DataAccess.Seamfix.KycService'' threw an exception.', N'   at kyc.bridge.api.DataAccess.Seamfix.KycService.IdServiceValidation(IdValidationRequest idValidation)
   at kyc.bridge.api.BusinessLogic.KycLogic.IdValidationProcessor(IdValidationRequest idValidationRequest) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\BusinessLogic\KycLogic.cs:line 21', N'kyc.bridge.api', CAST(0x0000AB7900F4323C AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (3, N'The type initializer for ''kyc.bridge.api.DataAccess.Seamfix.KycService'' threw an exception.', N'   at kyc.bridge.api.DataAccess.Seamfix.KycService.IdServiceValidation(IdValidationRequest idValidation)
   at kyc.bridge.api.BusinessLogic.KycLogic.IdValidationProcessor(IdValidationRequest idValidationRequest) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\BusinessLogic\KycLogic.cs:line 21', N'kyc.bridge.api', CAST(0x0000AB7900F4BB45 AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (4, N'The type initializer for ''kyc.bridge.api.DataAccess.Seamfix.KycService'' threw an exception.', N'   at kyc.bridge.api.DataAccess.Seamfix.KycService.BvnServiceRequestValidation(BvnServiceRequest bvnValidation)
   at kyc.bridge.api.BusinessLogic.KycLogic.BvnProcessor(BvnServiceRequest bvnReq) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\BusinessLogic\KycLogic.cs:line 52', N'kyc.bridge.api', CAST(0x0000AB7A00052B42 AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (5, N'The remote server returned an error: (415) Unsupported Media Type.', N'   at System.Net.WebClient.UploadValues(Uri address, String method, NameValueCollection data)
   at System.Net.WebClient.UploadValues(String address, NameValueCollection data)
   at kyc.bridge.api.DataAccess.Seamfix.KycService.BvnServiceRequestValidation(BvnServiceRequest bvnValidation) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\DataAccess\Seamfix\KycService.cs:line 151', N'System', CAST(0x0000AB7A00E2C446 AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (6, N'The Content-Type header cannot be changed from its default value for this request.', N'   at System.Net.WebClient.UploadValues(Uri address, String method, NameValueCollection data)
   at System.Net.WebClient.UploadValues(String address, NameValueCollection data)
   at kyc.bridge.api.DataAccess.Seamfix.KycService.BvnServiceRequestValidation(BvnServiceRequest bvnValidation) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\DataAccess\Seamfix\KycService.cs:line 153', N'System', CAST(0x0000AB7A00E65B8A AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (7, N'The Content-Type header cannot be changed from its default value for this request.', N'   at System.Net.WebClient.UploadValues(Uri address, String method, NameValueCollection data)
   at System.Net.WebClient.UploadValues(String address, NameValueCollection data)
   at kyc.bridge.api.DataAccess.Seamfix.KycService.BvnServiceRequestValidation(BvnServiceRequest bvnValidation) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\DataAccess\Seamfix\KycService.cs:line 153', N'System', CAST(0x0000AB8B00B683F7 AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (8, N'The remote name could not be resolved: ''verified.ng''', N'   at System.Net.WebClient.UploadValues(Uri address, String method, NameValueCollection data)
   at System.Net.WebClient.UploadValues(String address, NameValueCollection data)
   at kyc.bridge.api.DataAccess.Seamfix.KycService.BvnServiceRequestValidation(BvnServiceRequest bvnValidation) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\DataAccess\Seamfix\KycService.cs:line 153', N'System', CAST(0x0000AB8B00B7BF1D AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (9, N'One or more errors occurred.', N'   at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)
   at System.Threading.Tasks.Task`1.GetResultCore(Boolean waitCompletionNotification)
   at System.Threading.Tasks.Task`1.get_Result()
   at kyc.bridge.api.DataAccess.Seamfix.KycService.BvnServiceRequestValidation0(BvnServiceRequest bvnValidation) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\DataAccess\Seamfix\KycService.cs:line 154', N'mscorlib', CAST(0x0000AB93016B5F40 AS DateTime))
INSERT [dbo].[ExceptionLog] ([Id], [ErrorMessage], [ErrorStacktrace], [ErrorSource], [ErrorDatetime]) VALUES (10, N'One or more errors occurred.', N'   at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)
   at System.Threading.Tasks.Task`1.GetResultCore(Boolean waitCompletionNotification)
   at System.Threading.Tasks.Task`1.get_Result()
   at kyc.bridge.api.DataAccess.Seamfix.KycService.BvnServiceRequestValidation(BvnServiceRequest bvnValidation) in C:\AppCenter\projects\kyc.bridge.api\kyc.bridge.api\kyc.bridge.api\DataAccess\Seamfix\KycService.cs:line 156', N'mscorlib', CAST(0x0000AB9C0122FC2D AS DateTime))
SET IDENTITY_INSERT [dbo].[ExceptionLog] OFF
