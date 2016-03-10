USE [master]
GO
/****** Object:  Database [shoe_stores]    Script Date: 3/10/2016 12:05:22 AM ******/
CREATE DATABASE [shoe_stores]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'shoe_stores', FILENAME = N'C:\Users\michael\shoe_stores.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'shoe_stores_log', FILENAME = N'C:\Users\michael\shoe_stores_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [shoe_stores] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [shoe_stores].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [shoe_stores] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [shoe_stores] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [shoe_stores] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [shoe_stores] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [shoe_stores] SET ARITHABORT OFF 
GO
ALTER DATABASE [shoe_stores] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [shoe_stores] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [shoe_stores] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [shoe_stores] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [shoe_stores] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [shoe_stores] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [shoe_stores] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [shoe_stores] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [shoe_stores] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [shoe_stores] SET  ENABLE_BROKER 
GO
ALTER DATABASE [shoe_stores] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [shoe_stores] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [shoe_stores] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [shoe_stores] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [shoe_stores] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [shoe_stores] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [shoe_stores] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [shoe_stores] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [shoe_stores] SET  MULTI_USER 
GO
ALTER DATABASE [shoe_stores] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [shoe_stores] SET DB_CHAINING OFF 
GO
ALTER DATABASE [shoe_stores] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [shoe_stores] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [shoe_stores] SET DELAYED_DURABILITY = DISABLED 
GO
USE [shoe_stores]
GO
/****** Object:  Table [dbo].[brands]    Script Date: 3/10/2016 12:05:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[brands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stores]    Script Date: 3/10/2016 12:05:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stores_brands]    Script Date: 3/10/2016 12:05:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stores_brands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[store_id] [int] NULL,
	[brand_id] [int] NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [shoe_stores] SET  READ_WRITE 
GO
