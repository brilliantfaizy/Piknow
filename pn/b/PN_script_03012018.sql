USE [ph13849611651_piknow]
GO
/****** Object:  Table [dbo].[tbl_accountDetail]    Script Date: 3/1/2018 1:06:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_accountDetail](
	[AccountDetail_ID] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[accountNumber] [nvarchar](50) NOT NULL,
	[bankName] [nvarchar](50) NULL,
	[shabaNumber] [nvarchar](50) NULL,
	[accountHolder] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_accountDetail] PRIMARY KEY CLUSTERED 
(
	[AccountDetail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_admin]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_admin](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_admin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_adminBank]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_adminBank](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[amount] [varchar](20) NOT NULL,
	[userType] [varchar](10) NULL,
	[offerRide_ID] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[paymentStatus] [varchar](20) NULL,
	[transaction_ID] [int] NULL,
	[book_id] [int] NULL,
 CONSTRAINT [PK_tbl_adminBank] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_adminTransaction]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_adminTransaction](
	[transaction_ID] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[type] [varchar](20) NULL,
	[transaction_Title] [varchar](200) NOT NULL,
	[transaction_datetime] [datetime] NOT NULL,
	[receivedCommission] [varchar](50) NULL,
	[Debit] [varchar](50) NULL,
	[Credit] [varchar](50) NULL,
	[Balance] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_adminTransaction] PRIMARY KEY CLUSTERED 
(
	[transaction_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_autoCharges]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_autoCharges](
	[chargesID] [int] IDENTITY(1,1) NOT NULL,
	[from_city] [int] NOT NULL,
	[to_city] [int] NOT NULL,
	[charges] [varchar](10) NOT NULL,
	[type] [varchar](50) NULL,
	[VehicleTypeIsNormal] [bit] NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_autoCharges] PRIMARY KEY CLUSTERED 
(
	[chargesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_book]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[offerRide_ID] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[datetime] [datetime] NULL,
	[passengerCode] [nvarchar](10) NULL,
 CONSTRAINT [PK_tbl_book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_chat]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_chat](
	[chat_ID] [int] IDENTITY(1,1) NOT NULL,
	[offerRide_ID] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[userType] [varchar](50) NOT NULL,
	[createdAt] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_chat] PRIMARY KEY CLUSTERED 
(
	[chat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_chatDetails]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_chatDetails](
	[chatDetail_id] [int] IDENTITY(1,1) NOT NULL,
	[chat_ID] [int] NOT NULL,
	[message] [varchar](max) NOT NULL,
	[user_id] [int] NOT NULL,
	[createdAt] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_chatDetails] PRIMARY KEY CLUSTERED 
(
	[chatDetail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_cities]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_cities](
	[cityID] [int] IDENTITY(1,1) NOT NULL,
	[cityName] [varchar](50) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_cities] PRIMARY KEY CLUSTERED 
(
	[cityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_commissionFee]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_commissionFee](
	[FeeID] [int] IDENTITY(1,1) NOT NULL,
	[driversFee] [varchar](50) NOT NULL,
	[persianPassengerFee] [varchar](50) NOT NULL,
	[foreignPassengerFee] [varchar](50) NOT NULL,
	[minFastInBalance] [varchar](50) NOT NULL,
	[createdAt] [datetime] NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_commisionFee] PRIMARY KEY CLUSTERED 
(
	[FeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_company]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_company](
	[company_id] [int] IDENTITY(1,1) NOT NULL,
	[company_name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[phoneNumber] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[comeFrom] [varchar](50) NOT NULL,
	[ceoID_path] [varchar](max) NOT NULL,
	[permissions_path] [varchar](max) NOT NULL,
	[companyCertificate_path] [varchar](max) NOT NULL,
	[isConfirmed] [bit] NOT NULL,
	[createdAt] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_company] PRIMARY KEY CLUSTERED 
(
	[company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_companyDetail]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_companyDetail](
	[companyDetail_id] [int] IDENTITY(1,1) NOT NULL,
	[company_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_tbl_companyDetail] PRIMARY KEY CLUSTERED 
(
	[companyDetail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_complaint]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_complaint](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[offerRide_ID] [int] NOT NULL,
	[message] [varchar](max) NOT NULL,
	[datetime] [datetime] NULL,
 CONSTRAINT [PK_tbl_complaint] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_discountCode]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_discountCode](
	[discountID] [int] IDENTITY(1,1) NOT NULL,
	[discountFee] [varchar](50) NOT NULL,
	[discountCode] [varchar](50) NOT NULL,
	[availableNumber] [varchar](50) NOT NULL,
	[expireDate] [date] NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_discountCode] PRIMARY KEY CLUSTERED 
(
	[discountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_discountDetails]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_discountDetails](
	[discountDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[discountID] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_tbl_discountDetails] PRIMARY KEY CLUSTERED 
(
	[discountDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_fastRide]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_fastRide](
	[fastRide_ID] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[from_place] [varchar](200) NULL,
	[to_place] [varchar](200) NULL,
	[from_place_persian] [nvarchar](200) NULL,
	[to_place_persian] [nvarchar](200) NULL,
	[statusType] [varchar](50) NULL,
	[LatLong] [varchar](50) NULL,
	[createdAt] [datetime] NULL,
	[vehicleType] [varchar](20) NULL,
	[VehicleTypeIsNormal] [bit] NULL,
	[from_LatLong] [varchar](50) NOT NULL,
	[to_LatLong] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_fastRide] PRIMARY KEY CLUSTERED 
(
	[fastRide_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_fastRide_canceled]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_fastRide_canceled](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[fastRide_ID] [int] NOT NULL,
	[driver_id] [int] NOT NULL,
	[createdAt] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_fastRide_canceled] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_fastRideDetails]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_fastRideDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[fastRide_ID] [int] NOT NULL,
	[driver_id] [int] NOT NULL,
	[vehicle_id] [int] NOT NULL,
	[startAt] [datetime] NULL,
	[endAt] [datetime] NULL,
	[startLatLong] [varchar](50) NULL,
	[endLatLong] [varchar](50) NULL,
	[price] [varchar](20) NULL,
	[PayBy] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_fastRideDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_fastTrack]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_fastTrack](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[userType] [varchar](50) NULL,
	[InDatetime] [datetime] NULL,
	[OutDatetime] [datetime] NULL,
	[status] [varchar](50) NULL,
	[LatLong] [varchar](50) NULL,
	[vehicle_id] [int] NULL,
	[cityName] [nvarchar](50) NULL,
	[cityName_persian] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_fastTrack] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_fastTransDetails]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_fastTransDetails](
	[transDetail_ID] [int] IDENTITY(1,1) NOT NULL,
	[transaction_ID] [int] NOT NULL,
	[fastRide_ID] [int] NOT NULL,
	[userType] [varchar](20) NULL,
	[amount] [varchar](20) NULL,
	[KarenroDetect] [varchar](20) NULL,
	[total] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_fastTransDetails] PRIMARY KEY CLUSTERED 
(
	[transDetail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_fastUserRating]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_fastUserRating](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ratingCount] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[rate_user_id] [int] NOT NULL,
	[rateDatetime] [datetime] NULL,
	[fastRide_ID] [int] NULL,
 CONSTRAINT [PK_FastUserRating] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_general]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_general](
	[ID] [int] NOT NULL,
	[percentDetect] [varchar](10) NULL,
	[passengerDetect] [varchar](20) NULL,
	[fastTrackAmount] [varchar](20) NULL,
	[perKM] [varchar](20) NULL,
	[hostAddress] [varchar](200) NULL,
	[termConditionPath] [varchar](200) NULL,
	[aboutPath] [varchar](200) NULL,
	[privacyPolicyPath] [varchar](200) NULL,
 CONSTRAINT [PK__tbl_gene__3214EC27108B795B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_government]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_government](
	[government_id] [int] IDENTITY(1,1) NOT NULL,
	[government_code] [varchar](50) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_government] PRIMARY KEY CLUSTERED 
(
	[government_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_governmentDetail]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_governmentDetail](
	[govDetail_id] [int] IDENTITY(1,1) NOT NULL,
	[government_id] [int] NOT NULL,
	[company_id] [int] NOT NULL,
 CONSTRAINT [PK_tbl_governmentDetail] PRIMARY KEY CLUSTERED 
(
	[govDetail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_kmCharges]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_kmCharges](
	[chargesID] [int] IDENTITY(1,1) NOT NULL,
	[charges] [varchar](10) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[VehicleTypeIsNormal] [bit] NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_kmCharges] PRIMARY KEY CLUSTERED 
(
	[chargesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Notification]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Notification](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[notification_user_id] [int] NOT NULL,
	[message] [varchar](max) NOT NULL,
	[notificationDatetime] [datetime] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_tbl_Notification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_offerRide]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_offerRide](
	[offerRide_ID] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[vehicle_id] [int] NULL,
	[from_place] [text] NOT NULL,
	[to_place] [text] NOT NULL,
	[from_place_persian] [nvarchar](200) NULL,
	[to_place_persian] [nvarchar](200) NULL,
	[datetime] [datetime] NULL,
	[vehicle_type] [varchar](50) NULL,
	[no_seats] [int] NULL,
	[middleSeat] [bit] NOT NULL,
	[charter] [bit] NULL,
	[ride_comment] [nvarchar](max) NULL,
	[price] [varchar](10) NULL,
	[status] [bit] NULL,
	[statusType] [varchar](10) NULL,
	[Cigarette] [bit] NULL,
	[Music] [bit] NULL,
	[AC] [bit] NULL,
	[complaint] [bit] NULL,
	[createdAt] [datetime] NOT NULL,
	[from_latlong] [varchar](50) NULL,
	[to_latlong] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_offerRide] PRIMARY KEY CLUSTERED 
(
	[offerRide_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_profile]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_profile](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [varchar](50) NULL,
	[number] [varchar](50) NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[birthday] [varchar](50) NULL,
	[profile_pic] [varchar](255) NULL,
	[country] [varchar](50) NULL,
	[type] [varchar](50) NULL,
	[status] [varchar](20) NULL,
	[gender] [varchar](6) NULL,
	[approved] [bit] NULL,
	[deviceToken] [varchar](200) NULL,
	[createdAt] [datetime] NULL,
	[forgetPasswordToken] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_profile] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_transDetails]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_transDetails](
	[transDetail_ID] [int] IDENTITY(1,1) NOT NULL,
	[transaction_ID] [int] NOT NULL,
	[offerRide_ID] [int] NOT NULL,
	[userType] [varchar](20) NULL,
	[amount] [varchar](20) NULL,
	[KarenroDetect] [varchar](20) NULL,
	[total] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_transDetails] PRIMARY KEY CLUSTERED 
(
	[transDetail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_userComesFrom]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_userComesFrom](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[company_id] [int] NULL,
	[individual] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_userComesFrom] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_userRating]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_userRating](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ratingCount] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[rate_user_id] [int] NOT NULL,
	[rateDatetime] [datetime] NULL,
	[offerRide_ID] [int] NULL,
 CONSTRAINT [PK_tbl_userRating] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_vehicle]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_vehicle](
	[vehicle_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[brand] [varchar](50) NOT NULL,
	[model] [varchar](50) NOT NULL,
	[color] [varchar](50) NOT NULL,
	[plateNumber] [nvarchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[approved] [bit] NOT NULL,
	[carPhoto] [varchar](max) NOT NULL,
	[carLicense] [varchar](max) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_vehicle] PRIMARY KEY CLUSTERED 
(
	[vehicle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_vehicleBrands]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_vehicleBrands](
	[brand_id] [int] IDENTITY(1,1) NOT NULL,
	[brand] [varchar](50) NOT NULL,
	[model] [varchar](50) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_vehicleBrands] PRIMARY KEY CLUSTERED 
(
	[brand_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_vehicleColors]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_vehicleColors](
	[color_id] [int] IDENTITY(1,1) NOT NULL,
	[color] [varchar](50) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_vehicleColors] PRIMARY KEY CLUSTERED 
(
	[color_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_vehicleTypes]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_vehicleTypes](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NULL,
 CONSTRAINT [PK_tbl_vehicleTypes] PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_WalletTransaction]    Script Date: 3/1/2018 1:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_WalletTransaction](
	[transaction_ID] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[transaction_Title] [varchar](200) NOT NULL,
	[transaction_datetime] [datetime] NOT NULL,
	[Debit] [varchar](50) NULL,
	[Credit] [varchar](50) NULL,
	[Balance] [varchar](50) NULL,
	[rechargedBy] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_WalletTransaction] PRIMARY KEY CLUSTERED 
(
	[transaction_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tbl_general] ([ID], [percentDetect], [passengerDetect], [fastTrackAmount], [perKM], [hostAddress], [termConditionPath], [aboutPath], [privacyPolicyPath]) VALUES (1, NULL, NULL, NULL, NULL, N'184.168.47.17', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_offerRide] ON 

INSERT [dbo].[tbl_offerRide] ([offerRide_ID], [user_id], [vehicle_id], [from_place], [to_place], [from_place_persian], [to_place_persian], [datetime], [vehicle_type], [no_seats], [middleSeat], [charter], [ride_comment], [price], [status], [statusType], [Cigarette], [Music], [AC], [complaint], [createdAt], [from_latlong], [to_latlong]) VALUES (3, 7, 1, N'Khayaban-e-Iqbal, Karachi, Pakistan', N'Buffer Zone Fish Market, Karachi, Pakistan', NULL, NULL, CAST(0x0000A88901838AF0 AS DateTime), N'Economy', 1, 1, NULL, N'jasdbasdbka', N'250', 1, N'pending', NULL, NULL, NULL, 0, CAST(0x0000A88900BDCF09 AS DateTime), N'24.8244147,67.03513269999999', N'Buffer Zone Fish Market, Karachi, Pakistan')
INSERT [dbo].[tbl_offerRide] ([offerRide_ID], [user_id], [vehicle_id], [from_place], [to_place], [from_place_persian], [to_place_persian], [datetime], [vehicle_type], [no_seats], [middleSeat], [charter], [ride_comment], [price], [status], [statusType], [Cigarette], [Music], [AC], [complaint], [createdAt], [from_latlong], [to_latlong]) VALUES (4, 7, 1, N'Bufferzone, Karachi, Pakistan', N'Khayaban-e-Shaheen, Karachi, Pakistan', NULL, NULL, CAST(0x0000A889018A2270 AS DateTime), N'Economy', 1, 1, NULL, N'Amanda had', N'240', 1, N'pending', NULL, NULL, NULL, 0, CAST(0x0000A88900C49A6D AS DateTime), N'24.9593564,67.0673103', N'Khayaban-e-Shaheen, Karachi, Pakistan')
INSERT [dbo].[tbl_offerRide] ([offerRide_ID], [user_id], [vehicle_id], [from_place], [to_place], [from_place_persian], [to_place_persian], [datetime], [vehicle_type], [no_seats], [middleSeat], [charter], [ride_comment], [price], [status], [statusType], [Cigarette], [Music], [AC], [complaint], [createdAt], [from_latlong], [to_latlong]) VALUES (5, 7, 1, N'Bufferzone, Karachi, Pakistan', N'Khayaban-e-Iqbal, Karachi, Pakistan', NULL, NULL, CAST(0x0000A88A00023280 AS DateTime), N'Economy', 1, 1, NULL, N'dads', N'56', 1, N'pending', NULL, NULL, NULL, 0, CAST(0x0000A88900C813AB AS DateTime), N'24.9593564,67.0673103', N'24.8244147,67.03513269999999')
INSERT [dbo].[tbl_offerRide] ([offerRide_ID], [user_id], [vehicle_id], [from_place], [to_place], [from_place_persian], [to_place_persian], [datetime], [vehicle_type], [no_seats], [middleSeat], [charter], [ride_comment], [price], [status], [statusType], [Cigarette], [Music], [AC], [complaint], [createdAt], [from_latlong], [to_latlong]) VALUES (6, 1, 1, N'Shahfaisal, Karachi', N'Shahfaisal, Karachi', NULL, NULL, CAST(0x0000A88D01742970 AS DateTime), N'Economy', 4, 1, NULL, N'test', N'200', 1, N'pending', NULL, NULL, NULL, 0, CAST(0x0000A88D00AEBA44 AS DateTime), N'72.000,82.000', N'72.000,82.000')
INSERT [dbo].[tbl_offerRide] ([offerRide_ID], [user_id], [vehicle_id], [from_place], [to_place], [from_place_persian], [to_place_persian], [datetime], [vehicle_type], [no_seats], [middleSeat], [charter], [ride_comment], [price], [status], [statusType], [Cigarette], [Music], [AC], [complaint], [createdAt], [from_latlong], [to_latlong]) VALUES (7, 1, 1, N'Shahfaisal, Karachi', N'Shahfaisal, Karachi', NULL, NULL, CAST(0x0000A88D01742970 AS DateTime), N'Economy', 4, 1, NULL, N'test', N'200', 1, N'pending', NULL, NULL, NULL, 0, CAST(0x0000A88D00B08E3D AS DateTime), N'72.000,82.000', N'72.000,82.000')
SET IDENTITY_INSERT [dbo].[tbl_offerRide] OFF
SET IDENTITY_INSERT [dbo].[tbl_profile] ON 

INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (1, N'Zuhaib Ali Shah', N'+923162984629', N'mz.ashah@gmail.com', N'123456', NULL, N'b01f49ca-f751-49f8-957d-e05e898eaafa.png', N'Pakistan', N'1', N'1', NULL, 1, N'', CAST(0x0000A86F00180545 AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (2, N'Zuhaib Ali Shah', N'+923162984629', N'mz.ashahs@gmail.com', N'123456', NULL, N'02166005-4316-4221-9b03-1c87a59189ca.png', N'Pakistan', N'1', N'1', NULL, 1, N'abc', CAST(0x0000A86E00E20CF4 AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (3, N'Zuhaib Ali Shah', N'+923162984629', N'mz1.ashah@gmail.com', N'123456', NULL, N'c2b25b86-b318-4da9-b5d3-8bcd79256a7d.png', N'Pakistan', N'1', N'1', NULL, 1, N'abc', CAST(0x0000A87000BEDD0E AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (4, N'Zuhaib Ali Shah', N'+923162984629', N'mz2.ashah@gmail.com', N'123456', NULL, N'755f5986-cf46-44cc-a737-3806afeb0ad1.png', N'Pakistan', N'1', N'1', NULL, 1, N'abc', CAST(0x0000A87000BF659F AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (5, N'Zuhaib Ali Shah', N'+923162984629', N'mz3.ashah@gmail.com', N'123456', NULL, N'2f90ac53-1c12-4fe3-a186-c1a98a06f61b.png', N'Karachi', N'1', N'1', NULL, 1, N'abc', CAST(0x0000A87000BF7D84 AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (6, N'abc', N'+123123', N'abc@gmail.com', N'123123', NULL, N'd5ce3522-4b6f-4129-b097-98b183f5f4d0.png', N'karachi', N'1', N'1', NULL, 1, N'asdasd', CAST(0x0000A87000CA9ED4 AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (7, N'shahzaibqureshi', N'03363173039', N'shahzaibahmed2009@live.com', N'zxcasd123', N'1993', N'50a2329f-4bc1-4f34-a821-3c86279d9900.png', N'Karachi', N'1', N'1', N'Male', 1, N'asdasd', CAST(0x0000A87000CBBF56 AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (8, N'shahzaibqureshi', N'+123123123', N'shahzaib@gmail.com', N'zxcasd123', NULL, N'1420605d-b76e-47ab-842c-e0cf7e5761e9.png', N'Lahore', N'1', N'1', NULL, 1, N'asdasd', CAST(0x0000A87000CCB875 AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (9, N'shahZaib', N'+03363173039', N'shahzaibahmed20098@live.com', N'zxcasd123', NULL, N'f7be63f7-7f4a-45ae-9a55-bce059005e73.png', N'Karachi', N'1', N'1', NULL, 1, N'asdasd', CAST(0x0000A87000CFEE6F AS DateTime), NULL)
INSERT [dbo].[tbl_profile] ([user_id], [full_name], [number], [email], [password], [birthday], [profile_pic], [country], [type], [status], [gender], [approved], [deviceToken], [createdAt], [forgetPasswordToken]) VALUES (10, N'Zuhaib Ali Shah', N'+03162984629', N'mz.ashah1223as@gmail.com', N'123456', NULL, N'9696deee-ea38-4c3d-a569-9ca300f32c9e.png', N'Pakistan', N'1', N'1', NULL, 1, N'abc', CAST(0x0000A88D00B8DA11 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbl_profile] OFF
SET IDENTITY_INSERT [dbo].[tbl_vehicle] ON 

INSERT [dbo].[tbl_vehicle] ([vehicle_id], [user_id], [brand], [model], [color], [plateNumber], [type], [approved], [carPhoto], [carLicense], [createdAt], [updatedAt]) VALUES (1, 7, N'Suzuki', N'Mehran', N'Red', N'123123', N'Economy', 1, N'79c3eec2-e086-491c-bb95-7db3f5cfb516.png', N'6dbf8f65-02f6-4f71-a325-0ebeccf22f12.png', CAST(0x0000A87300E11ED8 AS DateTime), NULL)
INSERT [dbo].[tbl_vehicle] ([vehicle_id], [user_id], [brand], [model], [color], [plateNumber], [type], [approved], [carPhoto], [carLicense], [createdAt], [updatedAt]) VALUES (2, 7, N'Suzuki', N'Ravi', N'Black', N'Bugatti-999', N'Economy', 1, N'd86d09f3-0f57-45b8-94cd-24c3672fb2c9.png', N'0664884c-225b-4c98-a335-24c28d0965eb.png', CAST(0x0000A87A00A97ECE AS DateTime), NULL)
INSERT [dbo].[tbl_vehicle] ([vehicle_id], [user_id], [brand], [model], [color], [plateNumber], [type], [approved], [carPhoto], [carLicense], [createdAt], [updatedAt]) VALUES (3, 1, N'Suzuki', N'2018', N'Black', N'kfz-6188', N'Economy', 0, N'160052ab-ed19-4f9e-9d00-c85b01fa2644.png', N'7a82d99e-8cd6-4f60-8069-4a770e21059f.png', CAST(0x0000A88D00B1A8E8 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbl_vehicle] OFF
SET IDENTITY_INSERT [dbo].[tbl_vehicleBrands] ON 

INSERT [dbo].[tbl_vehicleBrands] ([brand_id], [brand], [model], [createdAt], [updatedAt]) VALUES (1, N'Suzuki', N'Mehran', CAST(0x0000A7C80131A684 AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleBrands] ([brand_id], [brand], [model], [createdAt], [updatedAt]) VALUES (2, N'Suzuki', N'Cultus', CAST(0x0000A7C80131B9DF AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleBrands] ([brand_id], [brand], [model], [createdAt], [updatedAt]) VALUES (3, N'Suzuki', N'Bolan', CAST(0x0000A7C80131E962 AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleBrands] ([brand_id], [brand], [model], [createdAt], [updatedAt]) VALUES (4, N'Suzuki', N'Ravi', CAST(0x0000A7C80132D2DE AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleBrands] ([brand_id], [brand], [model], [createdAt], [updatedAt]) VALUES (6, N'Suzuki', N'Swift', CAST(0x0000A7C80133333E AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleBrands] ([brand_id], [brand], [model], [createdAt], [updatedAt]) VALUES (7, N'Honda', N'Mehran', CAST(0x0000A7D000635A83 AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleBrands] ([brand_id], [brand], [model], [createdAt], [updatedAt]) VALUES (8, N'Honda', N'Cultus', CAST(0x0000A7D00063644C AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleBrands] ([brand_id], [brand], [model], [createdAt], [updatedAt]) VALUES (9, N'Honda', N'Swift', CAST(0x0000A7D000636AD7 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbl_vehicleBrands] OFF
SET IDENTITY_INSERT [dbo].[tbl_vehicleColors] ON 

INSERT [dbo].[tbl_vehicleColors] ([color_id], [color], [createdAt], [updatedAt]) VALUES (1, N'Red', CAST(0x0000A86000F59FAA AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleColors] ([color_id], [color], [createdAt], [updatedAt]) VALUES (2, N'Blue', CAST(0x0000A86000F59FAD AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleColors] ([color_id], [color], [createdAt], [updatedAt]) VALUES (3, N'White', CAST(0x0000A86000F59FAF AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleColors] ([color_id], [color], [createdAt], [updatedAt]) VALUES (4, N'Black', CAST(0x0000A86000F59FB1 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbl_vehicleColors] OFF
SET IDENTITY_INSERT [dbo].[tbl_vehicleTypes] ON 

INSERT [dbo].[tbl_vehicleTypes] ([type_id], [type], [createdAt], [updatedAt]) VALUES (1, N'Economy', CAST(0x0000A86000F2E7CE AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleTypes] ([type_id], [type], [createdAt], [updatedAt]) VALUES (2, N'Luxury', CAST(0x0000A86000F308BB AS DateTime), NULL)
INSERT [dbo].[tbl_vehicleTypes] ([type_id], [type], [createdAt], [updatedAt]) VALUES (3, N'Bike', CAST(0x0000A86000F379FD AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbl_vehicleTypes] OFF
ALTER TABLE [dbo].[tbl_offerRide] ADD  CONSTRAINT [DF__tbl_offer__Cigar__4D94879B]  DEFAULT ((1)) FOR [Cigarette]
GO
ALTER TABLE [dbo].[tbl_offerRide] ADD  CONSTRAINT [DF__tbl_offer__Music__4E88ABD4]  DEFAULT ((1)) FOR [Music]
GO
ALTER TABLE [dbo].[tbl_offerRide] ADD  CONSTRAINT [DF__tbl_offerRid__AC__4F7CD00D]  DEFAULT ((1)) FOR [AC]
GO
ALTER TABLE [dbo].[tbl_offerRide] ADD  CONSTRAINT [DF__tbl_offer__compl__5070F446]  DEFAULT ((0)) FOR [complaint]
GO
ALTER TABLE [dbo].[tbl_accountDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_accountDetail_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_accountDetail] CHECK CONSTRAINT [FK_tbl_accountDetail_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_adminTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tbl_adminTransaction_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_adminTransaction] CHECK CONSTRAINT [FK_tbl_adminTransaction_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_autoCharges]  WITH CHECK ADD  CONSTRAINT [FK_tbl_autoCharges_tbl_cities] FOREIGN KEY([from_city])
REFERENCES [dbo].[tbl_cities] ([cityID])
GO
ALTER TABLE [dbo].[tbl_autoCharges] CHECK CONSTRAINT [FK_tbl_autoCharges_tbl_cities]
GO
ALTER TABLE [dbo].[tbl_autoCharges]  WITH CHECK ADD  CONSTRAINT [FK_tbl_autoCharges_tbl_cities1] FOREIGN KEY([to_city])
REFERENCES [dbo].[tbl_cities] ([cityID])
GO
ALTER TABLE [dbo].[tbl_autoCharges] CHECK CONSTRAINT [FK_tbl_autoCharges_tbl_cities1]
GO
ALTER TABLE [dbo].[tbl_book]  WITH CHECK ADD  CONSTRAINT [FK_tbl_book_tbl_offerRide] FOREIGN KEY([offerRide_ID])
REFERENCES [dbo].[tbl_offerRide] ([offerRide_ID])
GO
ALTER TABLE [dbo].[tbl_book] CHECK CONSTRAINT [FK_tbl_book_tbl_offerRide]
GO
ALTER TABLE [dbo].[tbl_book]  WITH CHECK ADD  CONSTRAINT [FK_tbl_book_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_book] CHECK CONSTRAINT [FK_tbl_book_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_companyDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_companyDetail_tbl_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[tbl_company] ([company_id])
GO
ALTER TABLE [dbo].[tbl_companyDetail] CHECK CONSTRAINT [FK_tbl_companyDetail_tbl_company]
GO
ALTER TABLE [dbo].[tbl_companyDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_companyDetail_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_companyDetail] CHECK CONSTRAINT [FK_tbl_companyDetail_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_complaint]  WITH CHECK ADD  CONSTRAINT [FK_tbl_complaint_tbl_offerRide] FOREIGN KEY([offerRide_ID])
REFERENCES [dbo].[tbl_offerRide] ([offerRide_ID])
GO
ALTER TABLE [dbo].[tbl_complaint] CHECK CONSTRAINT [FK_tbl_complaint_tbl_offerRide]
GO
ALTER TABLE [dbo].[tbl_complaint]  WITH CHECK ADD  CONSTRAINT [FK_tbl_complaint_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_complaint] CHECK CONSTRAINT [FK_tbl_complaint_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_discountDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_discountDetails_tbl_discountCode] FOREIGN KEY([discountID])
REFERENCES [dbo].[tbl_discountCode] ([discountID])
GO
ALTER TABLE [dbo].[tbl_discountDetails] CHECK CONSTRAINT [FK_tbl_discountDetails_tbl_discountCode]
GO
ALTER TABLE [dbo].[tbl_discountDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_discountDetails_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_discountDetails] CHECK CONSTRAINT [FK_tbl_discountDetails_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_fastRide]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastRide_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_fastRide] CHECK CONSTRAINT [FK_tbl_fastRide_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_fastRide_canceled]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastRide_canceled_tbl_fastRide] FOREIGN KEY([fastRide_ID])
REFERENCES [dbo].[tbl_fastRide] ([fastRide_ID])
GO
ALTER TABLE [dbo].[tbl_fastRide_canceled] CHECK CONSTRAINT [FK_tbl_fastRide_canceled_tbl_fastRide]
GO
ALTER TABLE [dbo].[tbl_fastRide_canceled]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastRide_canceled_tbl_profile] FOREIGN KEY([driver_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_fastRide_canceled] CHECK CONSTRAINT [FK_tbl_fastRide_canceled_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_fastRideDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastRideDetails_tbl_fastRide] FOREIGN KEY([fastRide_ID])
REFERENCES [dbo].[tbl_fastRide] ([fastRide_ID])
GO
ALTER TABLE [dbo].[tbl_fastRideDetails] CHECK CONSTRAINT [FK_tbl_fastRideDetails_tbl_fastRide]
GO
ALTER TABLE [dbo].[tbl_fastRideDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastRideDetails_tbl_profile] FOREIGN KEY([driver_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_fastRideDetails] CHECK CONSTRAINT [FK_tbl_fastRideDetails_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_fastRideDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastRideDetails_tbl_vehicle] FOREIGN KEY([vehicle_id])
REFERENCES [dbo].[tbl_vehicle] ([vehicle_id])
GO
ALTER TABLE [dbo].[tbl_fastRideDetails] CHECK CONSTRAINT [FK_tbl_fastRideDetails_tbl_vehicle]
GO
ALTER TABLE [dbo].[tbl_fastTrack]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastTrack_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_fastTrack] CHECK CONSTRAINT [FK_tbl_fastTrack_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_fastTrack]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastTrack_tbl_vehicle] FOREIGN KEY([vehicle_id])
REFERENCES [dbo].[tbl_vehicle] ([vehicle_id])
GO
ALTER TABLE [dbo].[tbl_fastTrack] CHECK CONSTRAINT [FK_tbl_fastTrack_tbl_vehicle]
GO
ALTER TABLE [dbo].[tbl_fastTransDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastTransDetails_tbl_WalletTransaction] FOREIGN KEY([transaction_ID])
REFERENCES [dbo].[tbl_WalletTransaction] ([transaction_ID])
GO
ALTER TABLE [dbo].[tbl_fastTransDetails] CHECK CONSTRAINT [FK_tbl_fastTransDetails_tbl_WalletTransaction]
GO
ALTER TABLE [dbo].[tbl_fastUserRating]  WITH CHECK ADD  CONSTRAINT [FK_tbl_fastUserRating_tbl_fastRide] FOREIGN KEY([fastRide_ID])
REFERENCES [dbo].[tbl_fastRide] ([fastRide_ID])
GO
ALTER TABLE [dbo].[tbl_fastUserRating] CHECK CONSTRAINT [FK_tbl_fastUserRating_tbl_fastRide]
GO
ALTER TABLE [dbo].[tbl_governmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_governmentDetail_tbl_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[tbl_company] ([company_id])
GO
ALTER TABLE [dbo].[tbl_governmentDetail] CHECK CONSTRAINT [FK_tbl_governmentDetail_tbl_company]
GO
ALTER TABLE [dbo].[tbl_governmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_governmentDetail_tbl_government] FOREIGN KEY([government_id])
REFERENCES [dbo].[tbl_government] ([government_id])
GO
ALTER TABLE [dbo].[tbl_governmentDetail] CHECK CONSTRAINT [FK_tbl_governmentDetail_tbl_government]
GO
ALTER TABLE [dbo].[tbl_offerRide]  WITH CHECK ADD  CONSTRAINT [FK_tbl_offerRide_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_offerRide] CHECK CONSTRAINT [FK_tbl_offerRide_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_offerRide]  WITH CHECK ADD  CONSTRAINT [FK_tbl_offerRide_tbl_vehicle] FOREIGN KEY([vehicle_id])
REFERENCES [dbo].[tbl_vehicle] ([vehicle_id])
GO
ALTER TABLE [dbo].[tbl_offerRide] CHECK CONSTRAINT [FK_tbl_offerRide_tbl_vehicle]
GO
ALTER TABLE [dbo].[tbl_userComesFrom]  WITH CHECK ADD  CONSTRAINT [FK_tbl_userComesFrom_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_userComesFrom] CHECK CONSTRAINT [FK_tbl_userComesFrom_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_vehicle]  WITH CHECK ADD  CONSTRAINT [FK_tbl_vehicle_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_vehicle] CHECK CONSTRAINT [FK_tbl_vehicle_tbl_profile]
GO
ALTER TABLE [dbo].[tbl_WalletTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tbl_WalletTransaction_tbl_profile] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_profile] ([user_id])
GO
ALTER TABLE [dbo].[tbl_WalletTransaction] CHECK CONSTRAINT [FK_tbl_WalletTransaction_tbl_profile]
GO
