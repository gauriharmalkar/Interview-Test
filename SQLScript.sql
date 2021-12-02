USE [master]
GO

/****** Object:  Database [JobPortal]    Script Date: 02-12-2021 13:51:49 ******/
CREATE DATABASE [JobPortal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JobPortal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JobPortal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JobPortal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JobPortal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JobPortal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [JobPortal] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [JobPortal] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [JobPortal] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [JobPortal] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [JobPortal] SET ARITHABORT OFF 
GO

ALTER DATABASE [JobPortal] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [JobPortal] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [JobPortal] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [JobPortal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [JobPortal] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [JobPortal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [JobPortal] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [JobPortal] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [JobPortal] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [JobPortal] SET  DISABLE_BROKER 
GO

ALTER DATABASE [JobPortal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [JobPortal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [JobPortal] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [JobPortal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [JobPortal] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [JobPortal] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [JobPortal] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [JobPortal] SET RECOVERY FULL 
GO

ALTER DATABASE [JobPortal] SET  MULTI_USER 
GO

ALTER DATABASE [JobPortal] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [JobPortal] SET DB_CHAINING OFF 
GO

ALTER DATABASE [JobPortal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [JobPortal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [JobPortal] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [JobPortal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [JobPortal] SET QUERY_STORE = OFF
GO

ALTER DATABASE [JobPortal] SET  READ_WRITE 
GO


USE [JobPortal]
GO
/****** Object:  Table [dbo].[department]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[departmentId] [int] IDENTITY(1000,1) NOT NULL,
	[deptTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[code] [varchar](20) NULL,
	[title] [varchar](50) NULL,
	[postedDate] [datetime] NULL,
	[closingDate] [datetime] NULL,
	[description] [varchar](100) NULL,
	[locId] [int] NOT NULL,
	[deptId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[location]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location](
	[locationId] [int] IDENTITY(10000,1) NOT NULL,
	[locTitle] [varchar](20) NULL,
	[city] [varchar](20) NULL,
	[state] [varchar](20) NULL,
	[country] [varchar](20) NULL,
	[zip] [int] NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[locationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD FOREIGN KEY([deptId])
REFERENCES [dbo].[department] ([departmentId])
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD FOREIGN KEY([locId])
REFERENCES [dbo].[location] ([locationId])
GO
/****** Object:  StoredProcedure [dbo].[createdepart]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec createdepart 'dev'
-- =============================================
CREATE PROCEDURE [dbo].[createdepart]
@title varchar(50)
AS
BEGIN
	insert into department(deptTitle) values (@title) 	 
	select CAST(SCOPE_IDENTITY() AS INT) AS Id
END
GO
/****** Object:  StoredProcedure [dbo].[createJobs]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec createJobs 'h','h',10000,1000,'2021-08-30T18:43:31.877Z'
-- =============================================
CREATE PROCEDURE [dbo].[createJobs]
@title varchar(50),
@description varchar(100),
@locationId int,
@departmentId int,
@closingDate datetime
AS
BEGIN
	insert into job (code,title,description,locId,deptId,postedDate,closingDate) values ('JOB-01',@title, @description, @locationId, @departmentId,getdate(), @closingDate) 	
	select CAST(SCOPE_IDENTITY() AS INT) AS Id
END
GO
/****** Object:  StoredProcedure [dbo].[createlocation]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec createlocation 'dev','mapusa','goa','india',1020
-- =============================================
CREATE PROCEDURE [dbo].[createlocation]
@locTitle varchar(50),
@city varchar(50),
@state varchar(50),
@country varchar(50) ,
@zip int 
AS
BEGIN
	insert into location(locTitle,city,state,country,zip) values (@locTitle,@city,@state,@country,@zip)
	select CAST(SCOPE_IDENTITY() AS INT) AS Id
END
GO
/****** Object:  StoredProcedure [dbo].[getdepart]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec [getdepart] 1001
-- =============================================
CREATE PROCEDURE [dbo].[getdepart]
@id int = NULL
AS
BEGIN
	IF @ID IS NULL
	(
	
	SELECT * from department 
	)
	ELSE

	SELECT * from department where departmentId=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[getJobs]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec getJobs 100
-- =============================================
CREATE PROCEDURE [dbo].[getJobs]
@ID int = NULL

AS
BEGIN
	IF @ID IS NULL
	(
	
	SELECT * from Job 
	)
	ELSE

	SELECT * from Job where id=@ID
	
END
GO
/****** Object:  StoredProcedure [dbo].[getJobsDetails]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec getJobsDetails 100
-- =============================================
CREATE PROCEDURE [dbo].[getJobsDetails]
@ID int = NULL

AS
BEGIN
	
	

	IF (@ID IS NULL)
	(
	
	SELECT * from Job J
	inner join location L ON J.locId=L.locationId
	inner join department D ON J.deptId=D.departmentId
	
	)
	ELSE

	SELECT * from Job J
	inner join location L ON J.locId=L.locationId
	inner join department D ON J.deptId=D.departmentId
	where J.id=@ID

	
END
GO
/****** Object:  StoredProcedure [dbo].[getLocation]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec [getLocation] 10000
-- =============================================
CREATE PROCEDURE [dbo].[getLocation]
@id int = NULL
AS
BEGIN
	IF @ID IS NULL
	(
	
	SELECT * from location 
	)
	ELSE

	SELECT * from location where locationId=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[jobsList]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec jobsList @q='d',@pageNo =2,	@pageSize = 2,	@locationId =10000,	@departmentId = 1000
-- =============================================
CREATE PROCEDURE [dbo].[jobsList]
    @q	VARCHAR(100),
	@pageNo		INT =1,
	@pageSize	INT =10,
	@locationId INT =NULL,
	@departmentId	INT = NULL
AS
BEGIN	
		SELECT  COUNT(*) AS Total
		FROM Job
		WHERE Title like '%'+@q+'%'
			AND LocId = ISNULL(@locationId,LocId)
			AND DeptId = ISNULL(@departmentId,DeptId);

		SELECT 
			J.Id,
			J.Code,
			J.Title,
			L.locTitle AS location,
			D.deptTitle AS department,
			J.PostedDate,
			J.ClosingDate
		FROM Job J
		INNER JOIN [location] L
		ON L.locationId = J.locId
		INNER JOIN department D
		ON D.departmentId = J.deptId
		WHERE J.Title like '%'+@q+'%'
			AND J.locId = ISNULL(@locationId,J.locId)
			AND J.deptId = ISNULL(@departmentId,J.deptId)
		ORDER BY J.Id
		OFFSET (@pageNo-1)*@pageSize ROWS
		FETCH NEXT @pageSize ROWS ONLY;
		
	
END


GO
/****** Object:  StoredProcedure [dbo].[postJobsDetails]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec postJobsDetails 'b','b',10000,1000,'2021-08-30 18:43:31.877'
-- =============================================
CREATE PROCEDURE [dbo].[postJobsDetails]
@title varchar(50) = NULL,
@description varchar(50) = NULL,
@locatioId int = NULL,
@departmentId int = NULL,
@closingDate datetime = NULL


AS
BEGIN
	
	

	
	SELECT * from Job J
	inner join location L ON J.locId=L.locationId
	inner join department D ON J.deptId=D.departmentId
	where @title=j.title AND @description=j.description AND @locatioId=j.locId AND @departmentId=j.deptId AND @closingDate=j.closingDate 
	
		
END
GO
/****** Object:  StoredProcedure [dbo].[updatedepart]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec updatedepart 1001,'d'
-- =============================================
CREATE PROCEDURE [dbo].[updatedepart]
@id int,
@title varchar(50)
AS
BEGIN
	update department
	set deptTitle=@title
	where departmentId=@id
	
END



GO
/****** Object:  StoredProcedure [dbo].[updateJobs]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec updateJobs 101,'b','b',10000,1000,'2021-08-30T18:43:31.877Z'
-- =============================================
CREATE PROCEDURE [dbo].[updateJobs]
@ID int,
@title varchar(50),
@description varchar(100),
@locationId int,
@departmentId int,
@closingDate datetime
AS
BEGIN
	update job 
	set title=@title,
	description=@description,
	locId=@locationId,
	deptId=@departmentId,
	closingDate=@closingDate
	where id=@ID
	
END
GO
/****** Object:  StoredProcedure [dbo].[updateLocation]    Script Date: 02-12-2021 13:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Usage: exec updateLocation 10001,'d','mapusa','goa','India',1021
-- =============================================
CREATE PROCEDURE [dbo].[updateLocation]
@id int,
@locTitle varchar(50),
@city varchar(50),
@state varchar(50),
@country varchar(50) ,
@zip int 
AS
BEGIN
	update Location
	set locTitle=@locTitle,
	city=@city,
	state=@state,
	country=@country,
	zip=@zip
	where locationId=@id
	
END



GO


