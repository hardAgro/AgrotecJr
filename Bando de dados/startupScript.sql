USE [master]
GO
/****** Object:  Database [Inova.Farm]    Script Date: 12/9/2018 3:49:03 PM ******/
CREATE DATABASE [Inova.Farm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inova.Farm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Inova.Farm.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Inova.Farm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Inova.Farm_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Inova.Farm] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inova.Farm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inova.Farm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inova.Farm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inova.Farm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inova.Farm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inova.Farm] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inova.Farm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inova.Farm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inova.Farm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inova.Farm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inova.Farm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inova.Farm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inova.Farm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inova.Farm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inova.Farm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inova.Farm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Inova.Farm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inova.Farm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inova.Farm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inova.Farm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inova.Farm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inova.Farm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inova.Farm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inova.Farm] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Inova.Farm] SET  MULTI_USER 
GO
ALTER DATABASE [Inova.Farm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inova.Farm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inova.Farm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inova.Farm] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Inova.Farm] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Inova.Farm]
GO
/****** Object:  Table [dbo].[CurrentProduction]    Script Date: 12/9/2018 3:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentProduction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FruitId] [int] NOT NULL,
	[CurrentPhaseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_CurrentProduction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fruit]    Script Date: 12/9/2018 3:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fruit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Especie] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Fruit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Irrigation]    Script Date: 12/9/2018 3:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Irrigation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[CurrentPhaseId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Irrigation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductionPhase]    Script Date: 12/9/2018 3:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionPhase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FaseFenologica] [nvarchar](50) NOT NULL,
	[KCNumber] [float] NOT NULL,
	[FruitId] [int] NOT NULL,
 CONSTRAINT [PK_ProductionPhase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SoilCondition]    Script Date: 12/9/2018 3:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoilCondition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MeasuredHumidity] [float] NOT NULL,
	[IrrigationId] [int] NOT NULL,
 CONSTRAINT [PK_SoilCondition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 12/9/2018 3:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Name] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FarmName] [nvarchar](50) NOT NULL,
	[MainFruit] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nchar](10) NOT NULL,
 CONSTRAINT [PK_User2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CurrentProduction]  WITH CHECK ADD  CONSTRAINT [FK_CurrentProduction_Fruit] FOREIGN KEY([FruitId])
REFERENCES [dbo].[Fruit] ([Id])
GO
ALTER TABLE [dbo].[CurrentProduction] CHECK CONSTRAINT [FK_CurrentProduction_Fruit]
GO
ALTER TABLE [dbo].[CurrentProduction]  WITH CHECK ADD  CONSTRAINT [FK_CurrentProduction_ProductionPhase] FOREIGN KEY([CurrentPhaseId])
REFERENCES [dbo].[ProductionPhase] ([Id])
GO
ALTER TABLE [dbo].[CurrentProduction] CHECK CONSTRAINT [FK_CurrentProduction_ProductionPhase]
GO
ALTER TABLE [dbo].[CurrentProduction]  WITH CHECK ADD  CONSTRAINT [FK_CurrentProduction_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[CurrentProduction] CHECK CONSTRAINT [FK_CurrentProduction_User]
GO
ALTER TABLE [dbo].[Irrigation]  WITH CHECK ADD  CONSTRAINT [FK_Irrigation_CurrentProduction] FOREIGN KEY([CurrentPhaseId])
REFERENCES [dbo].[CurrentProduction] ([Id])
GO
ALTER TABLE [dbo].[Irrigation] CHECK CONSTRAINT [FK_Irrigation_CurrentProduction]
GO
ALTER TABLE [dbo].[ProductionPhase]  WITH CHECK ADD  CONSTRAINT [FK_Fruit_ProductionPhase] FOREIGN KEY([FruitId])
REFERENCES [dbo].[Fruit] ([Id])
GO
ALTER TABLE [dbo].[ProductionPhase] CHECK CONSTRAINT [FK_Fruit_ProductionPhase]
GO
ALTER TABLE [dbo].[SoilCondition]  WITH CHECK ADD  CONSTRAINT [FK_SoilCondition_Irrigation] FOREIGN KEY([IrrigationId])
REFERENCES [dbo].[Irrigation] ([Id])
GO
ALTER TABLE [dbo].[SoilCondition] CHECK CONSTRAINT [FK_SoilCondition_Irrigation]
GO
USE [master]
GO
ALTER DATABASE [Inova.Farm] SET  READ_WRITE 
GO
