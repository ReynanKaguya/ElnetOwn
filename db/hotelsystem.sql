-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 27, 2025 at 10:17 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hotelsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('0436941a-3d0f-4fb8-8056-59de5098f050', 'Housekeeping', 'HOUSEKEEPING', NULL),
('1234ab55-ae76-4c2d-994f-603d72e3148d', 'FrontDesk', 'FRONTDESK', NULL),
('47c4d0fa-3678-401d-acf7-0e87774b7bf5', 'Admin', 'ADMIN', NULL),
('f10471d5-77d0-4f8d-b868-e57d4b5eddb5', 'Guest', 'GUEST', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('902081d4-769d-47e7-b977-739909a84e7a', '47c4d0fa-3678-401d-acf7-0e87774b7bf5');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `FullName` longtext NOT NULL,
  `Role` longtext NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `FullName`, `Role`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('902081d4-769d-47e7-b977-739909a84e7a', 'Admin', 'Admin', 'admin@hotel.com', 'ADMIN@HOTEL.COM', 'admin@hotel.com', 'ADMIN@HOTEL.COM', 1, 'AQAAAAIAAYagAAAAEEdCzeulF5lQA0BwgEP4uO+gGjSOTDha07/3nkQkY/2pW6dFXJLiqPTUpHIKpSF4nA==', 'U6XRFS5MNSHWOWHGKTOZ3X3CDRUGRGBJ', '5a59d46a-23c9-4ad4-9f69-3347089460df', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `bookings`
--

CREATE TABLE `bookings` (
  `Id` int(11) NOT NULL,
  `GuestName` longtext NOT NULL,
  `GuestEmail` longtext NOT NULL,
  `CheckinDate` datetime(6) NOT NULL,
  `CheckoutDate` datetime(6) NOT NULL,
  `Status` longtext NOT NULL,
  `RoomId` int(11) NOT NULL,
  `PaymentMethod` longtext NOT NULL,
  `IsCheckedIn` tinyint(1) NOT NULL DEFAULT 0,
  `IsCheckedOut` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bookings`
--

INSERT INTO `bookings` (`Id`, `GuestName`, `GuestEmail`, `CheckinDate`, `CheckoutDate`, `Status`, `RoomId`, `PaymentMethod`, `IsCheckedIn`, `IsCheckedOut`) VALUES
(1, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-28 00:00:00.000000', '2025-03-31 00:00:00.000000', 'Rejected', 2, 'PayPal', 0, 0),
(2, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-28 00:00:00.000000', '2025-03-31 00:00:00.000000', 'Rejected', 2, 'PayPal', 0, 0),
(3, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-28 00:00:00.000000', '2025-03-29 00:00:00.000000', 'Rejected', 2, 'PayPal', 0, 0),
(4, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-29 00:00:00.000000', 'Rejected', 2, 'PayPal', 0, 0),
(5, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Rejected', 2, 'PayPal', 0, 0),
(6, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Rejected', 2, 'PayPal', 0, 0),
(7, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Confirmed', 2, 'PayPal', 0, 0),
(8, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Confirmed', 2, 'PayPal', 0, 0),
(9, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Confirmed', 2, 'Credit Card', 0, 0),
(10, 'Reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Confirmed', 2, 'PayPal', 0, 0),
(11, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Checked-in', 2, 'PayPal', 1, 0),
(12, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Checked-in', 2, 'Bank Transfer', 1, 0),
(13, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Checked-in', 2, 'PayPal', 1, 0),
(14, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Checked-in', 2, 'PayPal', 1, 0),
(15, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Checked-in', 2, 'PayPal', 1, 0),
(16, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Pending', 1, 'PayPal', 0, 0),
(17, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Pending', 2, 'PayPal', 0, 0),
(18, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Pending', 2, 'PayPal', 0, 0),
(19, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-27 00:00:00.000000', '2025-03-28 00:00:00.000000', 'Pending', 2, 'Bank Transfer', 0, 0),
(20, 'reynan', 'cudilloreynan.crest@gmail.com', '2025-03-28 00:00:00.000000', '2025-03-30 00:00:00.000000', 'Pending', 2, 'Credit Card', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `feedbacks`
--

CREATE TABLE `feedbacks` (
  `Id` int(11) NOT NULL,
  `BookingId` int(11) NOT NULL,
  `GuestName` longtext NOT NULL,
  `Comments` longtext NOT NULL,
  `Rating` int(11) NOT NULL,
  `DateSubmitted` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `GuestEmail` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `feedbacks`
--

INSERT INTO `feedbacks` (`Id`, `BookingId`, `GuestName`, `Comments`, `Rating`, `DateSubmitted`, `GuestEmail`) VALUES
(1, 18, 'reynan', 'hahaha', 3, '2025-03-27 17:09:12.710628', 'cudilloreynan.crest@gmail.com'),
(2, 19, 'reynan', 'HAHAHA', 3, '2025-03-27 17:10:55.724753', 'cudilloreynan.crest@gmail.com'),
(3, 20, 'reynan', 'Waowww', 3, '2025-03-27 17:16:44.186395', 'cudilloreynan.crest@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `Id` int(11) NOT NULL,
  `RoomNumber` longtext NOT NULL,
  `RoomType` longtext NOT NULL,
  `PricePerNight` decimal(10,2) NOT NULL,
  `Status` longtext NOT NULL,
  `ImageUrl` longtext NOT NULL,
  `Name` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`Id`, `RoomNumber`, `RoomType`, `PricePerNight`, `Status`, `ImageUrl`, `Name`) VALUES
(1, '101', 'Deluxe', 2500.00, 'Vacant', '/img/room1.jpg', 'Room1'),
(2, '102', 'Suite', 3500.00, 'Vacant', '/img/room2.jpg', 'Room2');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20250327040757_InitialCreate', '8.0.13'),
('20250327041430_AddIdentityTables', '8.0.13'),
('20250327042223_AddRoomPricing', '8.0.13'),
('20250327043302_FixIdentityUser', '8.0.13'),
('20250327051153_SeedRooms', '8.0.13'),
('20250327051208_AddRoomImage', '8.0.13'),
('20250327051624_UpdateRoomImages', '8.0.13'),
('20250327053007_AddTotalPriceToBooking', '8.0.13'),
('20250327053020_AddPaymentMethodToBooking', '8.0.13'),
('20250327061624_FixRoomName', '8.0.13'),
('20250327072513_AddCheckInCheckOut', '8.0.13'),
('20250327075834_UpdateRoomImageUrls', '8.0.13'),
('20250327080443_AddCheckInCheckOutFlags', '8.0.13'),
('20250327083348_AddFeedbackModule', '8.0.13'),
('20250327090808_AddFeedbackDateSubmitted', '8.0.13');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Bookings_RoomId` (`RoomId`);

--
-- Indexes for table `feedbacks`
--
ALTER TABLE `feedbacks`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Feedbacks_BookingId` (`BookingId`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bookings`
--
ALTER TABLE `bookings`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `feedbacks`
--
ALTER TABLE `feedbacks`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `bookings`
--
ALTER TABLE `bookings`
  ADD CONSTRAINT `FK_Bookings_Rooms_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `rooms` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `feedbacks`
--
ALTER TABLE `feedbacks`
  ADD CONSTRAINT `FK_Feedbacks_Bookings_BookingId` FOREIGN KEY (`BookingId`) REFERENCES `bookings` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
