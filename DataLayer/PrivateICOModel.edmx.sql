
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/04/2018 10:58:32
-- Generated from EDMX file: E:\Live Projects\Purcell Compliance\EmployeeSales\PrivateICOWeb\DataLayer\PrivateICOModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_121296_purcelldb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CandidateData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CandidateData];
GO
IF OBJECT_ID(N'[dbo].[ComplianceUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComplianceUser];
GO
IF OBJECT_ID(N'[dbo].[DailySalesRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DailySalesRecord];
GO
IF OBJECT_ID(N'[dbo].[Lead]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lead];
GO
IF OBJECT_ID(N'[dbo].[MasterICODetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MasterICODetail];
GO
IF OBJECT_ID(N'[dbo].[Sale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sale];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO
IF OBJECT_ID(N'[dbo].[UserData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserData];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [TransactionID] int  NOT NULL,
    [UserID] int  NULL,
    [TransactionCurrency] nvarchar(50)  NULL,
    [Cryptoamount] nvarchar(50)  NULL,
    [NoOfCoins] nvarchar(50)  NULL,
    [TransactionTime] nvarchar(50)  NULL
);
GO

-- Creating table 'UserDatas'
CREATE TABLE [dbo].[UserDatas] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(250)  NULL,
    [LastName] nvarchar(250)  NULL,
    [EmailAddress] nvarchar(1000)  NULL,
    [PhoneNo] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [NoOfCoins] nvarchar(50)  NULL,
    [CreationTime] nvarchar(50)  NULL,
    [UserType] nvarchar(50)  NULL,
    [ReferrerEmail] nvarchar(500)  NULL
);
GO

-- Creating table 'DailySalesRecords'
CREATE TABLE [dbo].[DailySalesRecords] (
    [DailySalesRecordID] int  NOT NULL,
    [DaySales] nvarchar(50)  NULL,
    [Refunds] nvarchar(50)  NULL,
    [NetSales] nvarchar(50)  NULL,
    [MonthlySales] nvarchar(50)  NULL,
    [Tier1] nvarchar(50)  NULL,
    [Tier2] nvarchar(50)  NULL,
    [Tier3] nvarchar(50)  NULL,
    [Tier4] nvarchar(50)  NULL,
    [DateTime] nvarchar(50)  NULL,
    [UserID] int  NULL,
    [Bonus] nvarchar(50)  NULL,
    [MonthlyDrawsTaken] nvarchar(50)  NULL,
    [QBTotalPay] nvarchar(50)  NULL,
    [CashBonus] nvarchar(50)  NULL,
    [MonthlyOfficeRent] nvarchar(50)  NULL,
    [ActualPayoutTotal] nvarchar(50)  NULL
);
GO

-- Creating table 'ComplianceUsers'
CREATE TABLE [dbo].[ComplianceUsers] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(500)  NULL,
    [Email] nvarchar(max)  NULL,
    [Password] nvarchar(50)  NULL,
    [IsContractor] bit  NULL,
    [UserType] nvarchar(50)  NULL,
    [IsActive] bit  NULL,
    [CreationTime] nvarchar(150)  NULL
);
GO

-- Creating table 'Leads'
CREATE TABLE [dbo].[Leads] (
    [LeadID] int IDENTITY(1,1) NOT NULL,
    [DOTNo] nvarchar(50)  NULL,
    [BusinessName] nvarchar(max)  NULL,
    [ComplianceAgent] nvarchar(max)  NULL,
    [Date] nvarchar(50)  NULL,
    [ContactName] nvarchar(500)  NULL,
    [PhoneNoForContact] nvarchar(50)  NULL,
    [Email] nvarchar(500)  NULL,
    [TimeLine] nvarchar(50)  NULL,
    [ServiceDiscussed] nvarchar(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [SalesPersonID] int  NULL
);
GO

-- Creating table 'CandidateDatas'
CREATE TABLE [dbo].[CandidateDatas] (
    [CanadidateID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(150)  NULL,
    [MiddleName] nvarchar(150)  NULL,
    [LastName] nvarchar(150)  NULL,
    [StreetAddress] nvarchar(max)  NULL,
    [Apartment] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [ZipCode] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(500)  NULL,
    [DateAvailable] nvarchar(50)  NULL,
    [SocialSecurityNo] nvarchar(50)  NULL,
    [DesiredIncome] nvarchar(50)  NULL,
    [PositionAppliedFor] nvarchar(150)  NULL,
    [UsCitiZen] bit  NULL,
    [AuthorizedForWork] bit  NULL,
    [WorkedHere] bit  NULL,
    [IfYesWhen] nvarchar(max)  NULL,
    [Convicted] bit  NULL,
    [IfYesExplain] nvarchar(max)  NULL,
    [HighSchool] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [SchoolFrom1] nvarchar(50)  NULL,
    [SchoolTo1] nvarchar(50)  NULL,
    [DidYouGraduated1] bit  NULL,
    [Diploma] nvarchar(max)  NULL,
    [College] nvarchar(max)  NULL,
    [SchoolAddress] nvarchar(max)  NULL,
    [SchoolFrom2] nvarchar(50)  NULL,
    [SchoolTo2] nvarchar(50)  NULL,
    [DidYouGraduated2] bit  NULL,
    [Deegre1] nvarchar(max)  NULL,
    [Other] nvarchar(max)  NULL,
    [DeegreAddress] nvarchar(max)  NULL,
    [SchoolFrom3] nvarchar(50)  NULL,
    [SchoolTo3] nvarchar(50)  NULL,
    [DidYouGraduated3] bit  NULL,
    [Deegre2] nvarchar(max)  NULL,
    [RefFullName1] nvarchar(500)  NULL,
    [RefRelationShip1] nvarchar(500)  NULL,
    [RefCompany1] nvarchar(max)  NULL,
    [RefPhone1] nvarchar(50)  NULL,
    [RefAddress1] nvarchar(max)  NULL,
    [RefFullName2] nvarchar(max)  NULL,
    [RefRelationShip2] nvarchar(500)  NULL,
    [RefCompany2] nvarchar(max)  NULL,
    [RefPhone2] nvarchar(50)  NULL,
    [RefAddress2] nvarchar(max)  NULL,
    [RefFullName3] nvarchar(max)  NULL,
    [RefRelationShip3] nvarchar(500)  NULL,
    [RefCompany3] nvarchar(max)  NULL,
    [RefPhone3] nvarchar(50)  NULL,
    [RefAddress3] nvarchar(max)  NULL,
    [CompanyName1] nvarchar(500)  NULL,
    [CompanyPhone1] nvarchar(50)  NULL,
    [CompanyAddress1] nvarchar(max)  NULL,
    [CompanySupervisor1] nvarchar(500)  NULL,
    [JobTitle1] nvarchar(500)  NULL,
    [StartingSalary1] nvarchar(150)  NULL,
    [EndingSalary1] nvarchar(150)  NULL,
    [Responsibilities1] nvarchar(max)  NULL,
    [CompanyFrom1] nvarchar(50)  NULL,
    [CompanyTo1] nvarchar(50)  NULL,
    [ReasonForLeaving1] nvarchar(max)  NULL,
    [CanContactSV1] bit  NULL,
    [CompanyName2] nvarchar(500)  NULL,
    [CompanyPhone2] nvarchar(50)  NULL,
    [CompanyAddress2] nvarchar(max)  NULL,
    [CompanySupervisor2] nvarchar(max)  NULL,
    [JobTitle2] nvarchar(500)  NULL,
    [StartingSalary2] nvarchar(150)  NULL,
    [EndingSalary2] nvarchar(150)  NULL,
    [Responsibilities2] nvarchar(max)  NULL,
    [CompanyFrom2] nvarchar(50)  NULL,
    [CompanyTo2] nvarchar(50)  NULL,
    [ReasonForLeaving2] nvarchar(max)  NULL,
    [CanContactSV2] bit  NULL,
    [CompanyName3] nvarchar(500)  NULL,
    [CompanyPhone3] nvarchar(50)  NULL,
    [CompanyAddress3] nvarchar(max)  NULL,
    [CompanySupervisor3] nvarchar(max)  NULL,
    [JobTitle3] nvarchar(500)  NULL,
    [StartingSalary3] nvarchar(50)  NULL,
    [EndingSalary3] nvarchar(50)  NULL,
    [Responsibilities3] nvarchar(max)  NULL,
    [CompanyFrom3] nvarchar(50)  NULL,
    [CompanyTo3] nvarchar(50)  NULL,
    [ReasonForLeaving3] nvarchar(max)  NULL,
    [CanContactSV3] bit  NULL,
    [MilitaryBranch] nvarchar(500)  NULL,
    [MilitaryFrom] nvarchar(50)  NULL,
    [MilitaryTo] nvarchar(50)  NULL,
    [RankAtDischarge] nvarchar(500)  NULL,
    [TypeOFDischarge] nvarchar(500)  NULL,
    [Explanation] nvarchar(max)  NULL,
    [SignatureName] nvarchar(500)  NULL,
    [Date] nvarchar(50)  NULL,
    [ResumeDetails] nvarchar(max)  NULL
);
GO

-- Creating table 'MasterICODetails'
CREATE TABLE [dbo].[MasterICODetails] (
    [ICOid] int IDENTITY(1,1) NOT NULL,
    [MaxCoin] nvarchar(50)  NULL,
    [AvailableCoins] nvarchar(50)  NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [SaleID] int IDENTITY(1,1) NOT NULL,
    [DailySaleAmount] nvarchar(50)  NULL,
    [Refunds] nvarchar(50)  NULL,
    [NetSales] nvarchar(50)  NULL,
    [MonthlySales] nvarchar(50)  NULL,
    [CashBonus] nvarchar(50)  NULL,
    [DrawTakenInMonth] nvarchar(50)  NULL,
    [DailyBonus] nvarchar(50)  NULL,
    [MonthlyOfficeRent] nvarchar(50)  NULL,
    [QBTotalPay] nvarchar(50)  NULL,
    [SalesPersonID] int  NULL,
    [EntryDate] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TransactionID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([TransactionID] ASC);
GO

-- Creating primary key on [UserID] in table 'UserDatas'
ALTER TABLE [dbo].[UserDatas]
ADD CONSTRAINT [PK_UserDatas]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [DailySalesRecordID] in table 'DailySalesRecords'
ALTER TABLE [dbo].[DailySalesRecords]
ADD CONSTRAINT [PK_DailySalesRecords]
    PRIMARY KEY CLUSTERED ([DailySalesRecordID] ASC);
GO

-- Creating primary key on [UserID] in table 'ComplianceUsers'
ALTER TABLE [dbo].[ComplianceUsers]
ADD CONSTRAINT [PK_ComplianceUsers]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [LeadID] in table 'Leads'
ALTER TABLE [dbo].[Leads]
ADD CONSTRAINT [PK_Leads]
    PRIMARY KEY CLUSTERED ([LeadID] ASC);
GO

-- Creating primary key on [CanadidateID] in table 'CandidateDatas'
ALTER TABLE [dbo].[CandidateDatas]
ADD CONSTRAINT [PK_CandidateDatas]
    PRIMARY KEY CLUSTERED ([CanadidateID] ASC);
GO

-- Creating primary key on [ICOid] in table 'MasterICODetails'
ALTER TABLE [dbo].[MasterICODetails]
ADD CONSTRAINT [PK_MasterICODetails]
    PRIMARY KEY CLUSTERED ([ICOid] ASC);
GO

-- Creating primary key on [SaleID] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([SaleID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------