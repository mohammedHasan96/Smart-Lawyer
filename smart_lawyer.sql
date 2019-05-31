-- phpMyAdmin SQL Dump
-- version 4.5.4.1deb2ubuntu2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Aug 30, 2018 at 04:43 PM
-- Server version: 5.7.23-0ubuntu0.16.04.1
-- PHP Version: 7.1.20-1+ubuntu16.04.1+deb.sury.org+1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `smart_lawyer`
--

-- --------------------------------------------------------

--
-- Table structure for table `appeals_slander`
--

CREATE TABLE `appeals_slander` (
  `ap_sl_id` int(11) NOT NULL,
  `ap_sl_type` int(11) NOT NULL COMMENT '0Appeals 1slander',
  `ap_sl_number` varchar(255) NOT NULL,
  `ap_sl_date` date NOT NULL,
  `ap_sl_notic` text NOT NULL,
  `ap_sl_issue_id_fk` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `codes_tb`
--

CREATE TABLE `codes_tb` (
  `c_id` bigint(20) NOT NULL,
  `c_master_id` int(11) NOT NULL,
  `c_name` varchar(255) NOT NULL,
  `c_desc` text NOT NULL,
  `c_is_allow_edit` int(1) NOT NULL DEFAULT '1' COMMENT '0:not allow 1.allow'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `codes_tb`
--

INSERT INTO `codes_tb` (`c_id`, `c_master_id`, `c_name`, `c_desc`, `c_is_allow_edit`) VALUES
(1, 0, 'court Type', 'نوع المحكمة', 1),
(2, 0, 'Court Location', 'مكان النحمة', 1),
(3, 1, 'بداية', '', 1),
(4, 1, 'صلح', '', 1),
(5, 2, 'ملف', '', 1),
(15, 2, 'Khanyounes', 'Abasan Kabera', 1),
(14, 2, 'Wosta', 'Der Ballah', 1),
(13, 2, 'Gaza', 'Remal', 1),
(16, 2, 'Rafah', 'Rafah', 1),
(19, 0, 'Persons Types', 'Persons Types', 1),
(20, 19, 'Lawyer', 'LlLLLLL', 1),
(21, 19, 'Coustomer', 'LlLLLLL', 1),
(22, 0, 'Communication', '', 1),
(23, 22, 'Phone Number', '', 1),
(24, 2, 'Gaza', 'Remal', 1),
(25, 0, 'notification type', '', 1),
(26, 25, 'محامي', '', 1),
(27, 25, 'عدلي', '', 1),
(28, 22, 'Mobile Number', '', 1),
(29, 22, 'Email Address', '', 1),
(30, 22, 'Fax Number', '', 1),
(31, 22, 'FaceBook Profile', 'Profile', 1),
(32, 0, 'User Type', 'User Type', 1),
(34, 32, 'Type 1', '1111111111111111', 1),
(35, 32, 'Type 2', '2222222222222', 1),
(36, 32, 'Type 3', '3333333333333', 1);

-- --------------------------------------------------------

--
-- Table structure for table `contract`
--

CREATE TABLE `contract` (
  `con_de_id_fk` bigint(11) NOT NULL,
  `con_subject` varchar(500) NOT NULL,
  `con _date` date NOT NULL,
  `co_financial_value` double NOT NULL,
  `co_currency_type_cfk` int(11) NOT NULL,
  `con_created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `con_created_by` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `con_updated_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `con_updated_by` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `contract_party`
--

CREATE TABLE `contract_party` (
  `con_pa_id` bigint(20) NOT NULL,
  `con_pa_contract _id_fk` bigint(20) NOT NULL,
  `con_pa_per_fk` bigint(20) NOT NULL,
  `con_pa_type` bigint(20) NOT NULL COMMENT 'نوع الطرف اول او ثاني'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `deal_tb`
--

CREATE TABLE `deal_tb` (
  `de_id` bigint(20) NOT NULL,
  `de_type` int(11) NOT NULL,
  `de_insert_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `de_insert_user` int(11) NOT NULL,
  `de_year` int(11) NOT NULL,
  `de_month` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `deal_tb`
--

INSERT INTO `deal_tb` (`de_id`, `de_type`, `de_insert_date`, `de_insert_user`, `de_year`, `de_month`) VALUES
(3, 4, '2018-08-29 10:30:02', 12, 2018, 8),
(2, 4, '2018-08-29 10:29:32', 12, 2018, 8),
(4, 4, '2018-08-29 11:29:08', 12, 2018, 8),
(5, 5, '2018-08-29 11:29:08', 12, 2018, 8),
(6, 4, '2018-08-29 11:32:39', 12, 2018, 8),
(7, 5, '2018-08-29 11:32:39', 12, 2018, 8),
(8, 4, '2018-08-29 11:36:58', 12, 2018, 8),
(9, 5, '2018-08-29 11:36:58', 12, 2018, 8),
(10, 4, '2018-08-29 11:41:22', 12, 2018, 8),
(11, 4, '2018-08-29 11:42:42', 12, 2018, 8),
(12, 5, '2018-08-29 11:42:42', 12, 2018, 8),
(13, 4, '2018-08-29 11:44:50', 12, 2018, 8),
(14, 5, '2018-08-29 11:44:50', 12, 2018, 8),
(15, 4, '2018-08-29 12:17:21', 12, 2018, 8),
(16, 5, '2018-08-29 12:17:21', 12, 2018, 8),
(17, 4, '2018-08-29 12:19:13', 12, 2018, 8),
(18, 5, '2018-08-29 12:19:13', 12, 2018, 8),
(19, 4, '2018-08-29 12:19:41', 12, 2018, 8),
(20, 5, '2018-08-29 12:19:41', 12, 2018, 8),
(21, 4, '2018-08-29 12:21:49', 12, 2018, 8),
(22, 5, '2018-08-29 12:21:49', 12, 2018, 8),
(23, 4, '2018-08-29 12:53:16', 12, 2018, 8),
(24, 4, '2018-08-29 12:54:09', 12, 2018, 8),
(25, 5, '2018-08-29 12:54:09', 12, 2018, 8),
(26, 4, '2018-08-29 12:55:44', 12, 2018, 8),
(27, 5, '2018-08-29 12:55:44', 12, 2018, 8),
(28, 4, '2018-08-29 12:59:57', 12, 2018, 8),
(29, 5, '2018-08-29 12:59:57', 12, 2018, 8),
(30, 4, '2018-08-29 13:27:30', 12, 2018, 8),
(31, 5, '2018-08-29 13:27:30', 12, 2018, 8),
(32, 4, '2018-08-29 13:50:03', 12, 2018, 8),
(33, 5, '2018-08-29 13:50:03', 12, 2018, 8),
(34, 4, '2018-08-29 18:31:31', 12, 2018, 8),
(35, 5, '2018-08-29 18:31:31', 12, 2018, 8),
(36, 4, '2018-08-29 18:33:41', 12, 2018, 8),
(37, 5, '2018-08-29 18:33:41', 12, 2018, 8),
(38, 4, '2018-08-29 18:34:13', 12, 2018, 8),
(39, 5, '2018-08-29 18:34:13', 12, 2018, 8),
(40, 4, '2018-08-29 18:46:28', 12, 2018, 8),
(41, 5, '2018-08-29 18:46:28', 12, 2018, 8),
(42, 4, '2018-08-29 18:46:51', 12, 2018, 8),
(43, 5, '2018-08-29 18:46:51', 12, 2018, 8),
(44, 4, '2018-08-29 18:46:56', 12, 2018, 8),
(45, 5, '2018-08-29 18:46:56', 12, 2018, 8),
(46, 4, '2018-08-29 18:54:32', 12, 2018, 8),
(47, 5, '2018-08-29 18:54:32', 12, 2018, 8),
(48, 1, '2018-08-29 22:54:46', 0, 2018, 8),
(49, 4, '2018-08-29 20:22:05', 12, 2018, 8),
(50, 5, '2018-08-29 20:22:05', 12, 2018, 8),
(51, 4, '2018-08-29 20:51:34', 12, 2018, 8),
(52, 5, '2018-08-29 20:51:34', 12, 2018, 8),
(53, 4, '2018-08-29 20:51:49', 12, 2018, 8),
(54, 5, '2018-08-29 20:51:49', 12, 2018, 8),
(55, 1, '2018-08-30 06:53:41', 0, 2018, 8);

-- --------------------------------------------------------

--
-- Table structure for table `debt`
--

CREATE TABLE `debt` (
  `de_debt_fk` int(11) NOT NULL,
  `debt_value` int(11) NOT NULL,
  `cep_court_place_cfk` int(11) NOT NULL,
  `guarantor_id_cfk` varchar(255) NOT NULL COMMENT 'from client table',
  `witnesse_first_id` int(11) NOT NULL COMMENT 'from witnesses table',
  `witnesse_seconde_id` int(11) NOT NULL COMMENT 'from witnesses table',
  `debt_notic_fk` int(11) NOT NULL,
  `debt_date` date NOT NULL,
  `de_debtor_fk` int(11) NOT NULL,
  `related_issue_id_fk` bigint(20) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `deb_date_to` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `deb_date_from` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_by` bigint(20) NOT NULL,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ceated_by` bigint(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `debt`
--

INSERT INTO `debt` (`de_debt_fk`, `debt_value`, `cep_court_place_cfk`, `guarantor_id_cfk`, `witnesse_first_id`, `witnesse_seconde_id`, `debt_notic_fk`, `debt_date`, `de_debtor_fk`, `related_issue_id_fk`, `created_at`, `deb_date_to`, `deb_date_from`, `updated_by`, `updated_at`, `ceated_by`) VALUES
(0, 100, 0, 'asdas', 49, 50, 0, '0001-01-01', 47, 0, '2018-08-14 10:55:07', '2018-08-14 10:55:07', '2018-08-14 10:55:07', 0, '2018-08-14 10:55:07', 1),
(0, 20, 0, 'dasdas', 53, 54, 0, '0001-01-01', 51, 0, '2018-08-14 10:56:57', '2018-08-14 10:56:57', '2018-08-14 10:56:57', 0, '2018-08-14 10:56:57', 1),
(0, 10200, 0, 'asadd', 65, 66, 0, '0001-01-01', 63, 0, '2018-08-14 11:24:12', '2018-08-05 00:00:00', '2018-05-05 00:00:00', 0, '2018-08-14 11:24:12', 1),
(0, 23123, 0, 'asdasd', 77, 78, 0, '0001-01-01', 75, 0, '2018-08-14 11:49:47', '2018-05-03 00:00:00', '2018-02-02 00:00:00', 0, '2018-08-14 11:49:47', 1),
(0, 111, 0, 'tawfeeq', 85, 86, 0, '0001-01-01', 83, 0, '2018-08-15 12:39:15', '2018-08-05 00:00:00', '2018-05-05 00:00:00', 0, '2018-08-15 12:39:15', 1);

-- --------------------------------------------------------

--
-- Table structure for table `fees`
--

CREATE TABLE `fees` (
  `fe_id` int(11) NOT NULL COMMENT 'fees_issue',
  `fe_value` varchar(255) NOT NULL,
  `fe_de_id_fk` int(11) NOT NULL COMMENT 'القضية او العقد او السند',
  `fe_file_id_fk` int(11) NOT NULL,
  `fe_currency_type_cfk` varchar(20) NOT NULL,
  `fe_notic_id_fk` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `files`
--

CREATE TABLE `files` (
  `fi_de_id` bigint(20) NOT NULL,
  `fi_name` varchar(254) NOT NULL,
  `fi_de_id_fk` bigint(20) NOT NULL,
  `fi_type_cfk` bigint(20) NOT NULL,
  `fl_note` text NOT NULL,
  `fi_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Dumping data for table `files`
--

INSERT INTO `files` (`fi_de_id`, `fi_name`, `fi_de_id_fk`, `fi_type_cfk`, `fl_note`, `fi_date`) VALUES
(31, '11358251_399971766855977_237914570_n.jpg', 5, 5, 'after edit', '2018-08-29 13:27:30'),
(33, 'pic.jpg', 5, 5, 'ملاحظاتك ي معلم', '2018-08-29 13:50:03'),
(35, 'FB_IMG_1467034600111.jpg', 34, 0, 'ملاحظاتك ي معلم', '2018-08-29 18:31:31'),
(37, 'best_saying.jpg', 36, 0, 'ملاحظاتك ي معلم', '2018-08-29 18:33:41'),
(39, 'pic.jpg', 38, 0, 'ملاحظاتك ي معلم6788', '2018-08-29 18:34:13'),
(41, '11358251_399971766855977_237914570_n.jpg', 40, 5, 'after edit', '2018-08-29 18:46:28'),
(43, '11358251_399971766855977_237914570_n.jpg', 42, 5, 'after edit', '2018-08-29 18:46:51'),
(45, '11358251_399971766855977_237914570_n.jpg', 44, 5, 'after edit', '2018-08-29 18:46:56'),
(47, '11358251_399971766855977_237914570_n.jpg', 46, 5, 'after edit', '2018-08-29 18:54:32'),
(50, 'FB_IMG_1520893658885.jpg', 49, 0, 'ملاحظاتك ي معلم', '2018-08-29 20:22:05'),
(52, 'IMG_20170925_233635_230.jpg', 51, 0, 'ملاحظاتك ي معلم', '2018-08-29 20:51:34'),
(54, 'FB_IMG_1520893658885.jpg', 53, 0, 'ملاحظاتك ي معلم', '2018-08-29 20:51:49'),
(100, 'file_one', 31, 2, 'sdfsdfsdf', '2018-08-29 13:30:49'),
(200, 'sdfsdfds', 35, 3, 'sdfdsf', '2018-08-29 13:31:05');

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE `groups` (
  `g_id` int(11) NOT NULL,
  `g_name` varchar(255) NOT NULL,
  `g_description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`g_id`, `g_name`, `g_description`) VALUES
(1, 'Group 38', 'Group Description 572863559198565806'),
(2, 'Group 84', 'Group Description 212308409827696801'),
(3, 'Group 32', 'Group Description 649873367939707110'),
(4, 'Group 50', 'Group Description 336216406617178732'),
(5, 'Group 58', 'Group Description 186366574792442756'),
(6, 'Group 81', 'Group Description 250099166994105081'),
(8, 'Group 59', 'Group Description 175988873028354403'),
(9, 'Group 22', 'Group Description 547283239519717218'),
(10, 'Group 44', 'Group Description 142949841407169579'),
(11, 'Group 21', 'Group Description 295008722387226918'),
(12, 'Group 44', 'Group Description 523077450537598474'),
(13, 'Group 41', 'Group Description 653969745224100032'),
(14, 'Group 95', 'Group Description 591785313006515943'),
(15, 'Group 89', 'Group Description 215310157639749577'),
(16, 'Group 55', 'Group Description 538843187547158356'),
(17, 'Group 38', 'Group Description 189146192072530383'),
(18, 'Group 32', 'Group Description 231904295885431084'),
(19, 'Group 54', 'Group Description 564246802910212868'),
(20, 'Group 21', 'Group Description 621600822817159450'),
(21, 'Group 21', 'Group Description 436537413135701170'),
(22, 'Group 99', 'Group Description 300349510100417753'),
(23, 'Group 51', 'Group Description 103723400516499972'),
(24, 'Group 21', 'Group Description 274077652587649904'),
(26, 'my new Group', 'sdcasdvasvdfvsdfbsdfbsfbmlcsdkjajvbajkvnakjvnjnvknvjsjdfkdsjkdsfsadfjghieiwut'),
(27, 'group naem', 'adadfsadfsd46644s6d1fs5da4fas4d6fsa4d6f5s65f3s2d1f5s4df6sa4df8'),
(28, 'hGroup', 'sdafagafbsdbafbad'),
(29, 'Group 49', 'Group Description 877796330283117850'),
(30, 'Group 93', 'Group Description 755049650005379842'),
(31, 'Group 24', 'Group Description 181738264807578352'),
(32, 'Group 77', 'Group Description 656391827941126727'),
(33, 'Group 28', 'Group Description 770478889888646730'),
(34, 'Group 46', 'Group Description 762256440810738346'),
(35, 'Group 30', 'Group Description 660886423733431324'),
(36, 'Group 93', 'Group Description 576370124991104101'),
(37, 'Group 54', 'Group Description 831190733570152425'),
(38, 'Group 69', 'Group Description 859755424193672560'),
(39, 'Group 76', 'Group Description 838127517228168616'),
(40, 'Group 92', 'Group Description 383539181189204992'),
(41, 'Group 91', 'Group Description 506662661176137772'),
(42, 'Group 25', 'Group Description 473486746073422300'),
(43, 'Group 79', 'Group Description 691761565057185904'),
(44, 'Group 89', 'Group Description 879129593857611039'),
(45, 'Group 48', 'Group Description 188519837333825684'),
(46, 'Group 20', 'Group Description 686895659889302913'),
(47, 'Group 92', 'Group Description 110161599032269664'),
(48, 'Group 98', 'Group Description 790028364200686321'),
(49, 'Group 80', 'Group Description 404164393749240468'),
(50, 'Group 61', 'Group Description 788816336956704975'),
(51, 'Group 41', 'Group Description 173387798767509323'),
(52, 'Group 39', 'Group Description 737589889552152737'),
(53, 'Group 46', 'Group Description 524535314854342773'),
(54, 'Group 39', 'Group Description 877043305203243772'),
(55, 'Group 28', 'Group Description 630588451861892721'),
(56, 'Group 64', 'Group Description 820949360592736438'),
(57, 'Group 97', 'Group Description 464810285815857433'),
(58, 'Group 31', 'Group Description 224075345471538583'),
(59, 'Group 95', 'Group Description 399270615711282973'),
(60, 'Group 86', 'Group Description 572195113966525718'),
(61, 'Group 55', 'Group Description 712588424257363439'),
(62, 'Group 28', 'Group Description 841956735673641046'),
(63, 'Group 80', 'Group Description 234282200791644184'),
(64, 'Group 98', 'Group Description 189761620820842670'),
(65, 'Group 67', 'Group Description 801574784029217393'),
(66, 'Group 53', 'Group Description 459712361087461225'),
(67, 'Group 64', 'Group Description 670463456508322244'),
(68, 'Group 68', 'Group Description 564723266995514740'),
(69, 'Group 71', 'Group Description 757921526804470399'),
(70, 'Group 87', 'Group Description 756200737178402432'),
(71, 'Group 43', 'Group Description 348370813934712551'),
(72, 'Group 22', 'Group Description 423916246897281702'),
(73, 'Group 62', 'Group Description 885002424516339668'),
(74, 'Group 67', 'Group Description 451753569390812035'),
(75, 'Group 78', 'Group Description 783788704476700158'),
(76, 'Group 32', 'Group Description 334533581925106194'),
(77, 'Group 88', 'Group Description 278831753358223211'),
(78, 'Group 60', 'Group Description 128643275031175312'),
(79, 'Group 44', 'Group Description 643793677517608699'),
(80, 'Group 44', 'Group Description 478804627588292754'),
(81, 'Group 77', 'Group Description 525114256780684315'),
(82, 'Group 63', 'Group Description 194634489406652807'),
(83, 'Group 77', 'Group Description 298870648462733038'),
(84, 'Group 66', 'Group Description 281054321315378043'),
(85, 'Group 38', 'Group Description 195825388609657308'),
(86, 'Group 42', 'Group Description 758902328205510554'),
(87, 'Group 74', 'Group Description 538290627728611628'),
(88, 'Group 72', 'Group Description 705311133648557626'),
(89, 'Group 54', 'Group Description 585012424111710328'),
(90, 'Group 87', 'Group Description 893329209795783443'),
(91, 'Group 94', 'Group Description 732365582361853877'),
(92, 'Group 72', 'Group Description 819025578772305152'),
(93, 'Group 71', 'Group Description 473131840777115542'),
(94, 'Group 64', 'Group Description 690512764768269613'),
(95, 'Group 78', 'Group Description 315173173709505090'),
(96, 'Group 52', 'Group Description 703285332343454604'),
(97, 'Group 50', 'Group Description 267863739694615925'),
(98, 'Group 79', 'Group Description 377159742121298907'),
(99, 'Group 64', 'Group Description 751587751923387100'),
(100, 'Group 73', 'Group Description 294450139671595552'),
(101, 'Group 92', 'Group Description 335104178872279491'),
(102, 'Group 62', 'Group Description 178975479019192410'),
(103, 'Group 95', 'Group Description 258114505489881067'),
(104, 'Group 46', 'Group Description 378415264343690014'),
(105, 'Group 37', 'Group Description 130589443846626649'),
(106, 'Group 89', 'Group Description 478546639263182005'),
(107, 'Group 87', 'Group Description 809491557340226826'),
(108, 'Group 28', 'Group Description 187502810899550604'),
(109, 'Group 59', 'Group Description 798019362564727080'),
(110, 'Group 74', 'Group Description 522239553475501164'),
(111, 'Group 38', 'Group Description 785933587881418417'),
(112, 'Group 41', 'Group Description 504961272721541661'),
(113, 'Group 76', 'Group Description 687233598824178777'),
(114, 'Group 43', 'Group Description 512450581019849146'),
(115, 'Group 45', 'Group Description 321129786571617263'),
(116, 'Group 45', 'Group Description 449749828043235465'),
(117, 'Group 83', 'Group Description 190733539390710341'),
(118, 'Group 62', 'Group Description 700697545260435403'),
(119, 'Group 48', 'Group Description 327729128126333938'),
(120, 'Group 35', 'Group Description 120176307997566065'),
(121, 'Group 39', 'Group Description 482475527629536849'),
(122, 'Group 84', 'Group Description 827034129987575517'),
(123, 'Group 99', 'Group Description 374340762846218795'),
(124, 'Group 52', 'Group Description 263926548093231812'),
(125, 'Group 33', 'Group Description 441056641764879203'),
(126, 'Group 20', 'Group Description 814384833427259331'),
(127, 'Group 71', 'Group Description 411672536740303768'),
(128, 'Group 83', 'Group Description 718353706610488667'),
(129, 'Group 57', 'Group Description 634537489766222105'),
(130, 'Group 45', 'Group Description 614574839197440587'),
(131, 'Group 96', 'Group Description 342800316987609316'),
(132, 'Group 75', 'Group Description 885263563164355733'),
(133, 'Group 31', 'Group Description 179023734390128297'),
(134, 'Group 52', 'Group Description 875237731417215676'),
(135, 'Group 96', 'Group Description 211638350976821917'),
(136, 'Group 74', 'Group Description 133970104039828404'),
(137, 'Group 94', 'Group Description 806909129770283045'),
(138, 'Group 99', 'Group Description 194057138079594706'),
(139, 'Group 90', 'Group Description 499721368880202158'),
(140, 'Group 46', 'Group Description 202774593910262322'),
(141, 'Group 53', 'Group Description 884790310051612042'),
(142, 'Group 85', 'Group Description 508944134832391168'),
(143, 'Group 50', 'Group Description 826168204814645667'),
(144, 'Group 91', 'Group Description 195889383291654466'),
(145, 'Group 38', 'Group Description 512613612117459746'),
(146, 'Group 20', 'Group Description 291517363405640635'),
(147, 'Group 37', 'Group Description 300094197191598864'),
(148, 'Group 92', 'Group Description 842649171886521596'),
(149, 'Group 71', 'Group Description 723831864740830014'),
(150, 'Group 33', 'Group Description 784486339859661874'),
(151, 'Group 62', 'Group Description 212667349231176623'),
(152, 'Group 28', 'Group Description 223115245933785434'),
(153, 'Group 72', 'Group Description 737752165533267568'),
(154, 'Group 81', 'Group Description 129232465611186290'),
(155, 'Group 72', 'Group Description 400043412547443603'),
(156, 'Group 55', 'Group Description 205470497078167228'),
(157, 'Group 91', 'Group Description 583884380756200875'),
(158, 'Group 29', 'Group Description 569718157284629776'),
(159, 'Group 30', 'Group Description 746585898784711199'),
(160, 'Group 78', 'Group Description 710327319209863729'),
(161, 'Group 40', 'Group Description 538665683879594043'),
(162, 'Group 22', 'Group Description 514929462874745740'),
(163, 'Group 73', 'Group Description 117977678690651367'),
(164, 'Group 55', 'Group Description 176607393548759109'),
(165, 'Group 60', 'Group Description 432290865106161484'),
(166, 'Group 50', 'Group Description 678115678036323891'),
(167, 'Group 70', 'Group Description 859130563914289707'),
(168, 'Group 92', 'Group Description 794786293285184662'),
(169, 'Group 84', 'Group Description 840830372062670601'),
(170, 'Group 23', 'Group Description 615514162704521071'),
(171, 'Group 50', 'Group Description 867182778042581993'),
(172, 'Group 61', 'Group Description 556456799568195696'),
(173, 'Group 36', 'Group Description 852879553947261617'),
(174, 'Group 27', 'Group Description 147386228469392299'),
(175, 'Group 49', 'Group Description 841242893708619167'),
(176, 'Group 89', 'Group Description 465838352996183586'),
(177, 'Group 60', 'Group Description 228540532230514586'),
(178, 'Group 28', 'Group Description 475487559660767472'),
(179, 'Group 75', 'Group Description 507822523699498619'),
(180, 'Group 31', 'Group Description 263074590239238847'),
(181, 'Group 41', 'Group Description 769788238189211012'),
(182, 'Group 26', 'Group Description 889663460955595176'),
(183, 'Group 95', 'Group Description 620834159710569475'),
(184, 'Group 91', 'Group Description 247947160059716052'),
(185, 'Group 69', 'Group Description 255086689017340196'),
(186, 'Group 87', 'Group Description 655195143576338964'),
(187, 'Group 95', 'Group Description 798718409891836032'),
(188, 'Group 82', 'Group Description 762561478487417668'),
(189, 'Group 99', 'Group Description 894550411265493726'),
(190, 'Group 98', 'Group Description 681412479692351143'),
(191, 'Group 79', 'Group Description 489811213590854620'),
(192, 'Group 52', 'Group Description 655134366518554393'),
(193, 'Group 93', 'Group Description 177577641695810923'),
(194, 'Group 26', 'Group Description 684686873378679958'),
(195, 'Group 69', 'Group Description 501028339897890886'),
(196, 'Group 58', 'Group Description 677958555120719665'),
(197, 'Group 36', 'Group Description 463881613172205496'),
(198, 'Group 39', 'Group Description 628496155863810404'),
(199, 'Group 79', 'Group Description 270279375451422523'),
(200, 'Group 79', 'Group Description 446307268412487038'),
(201, 'Group 84', 'Group Description 512777340112763729'),
(202, 'Group 80', 'Group Description 177959179987208114'),
(203, 'Group 50', 'Group Description 645285635714349196'),
(204, 'Group 23', 'Group Description 631097503486210902'),
(205, 'Group 69', 'Group Description 726652896032660465'),
(206, 'Group 54', 'Group Description 820133707033679866'),
(207, 'Group 88', 'Group Description 644699850040445283'),
(208, 'Group 94', 'Group Description 716802331525285102'),
(209, 'Group 72', 'Group Description 497494668007849337'),
(210, 'Group 28', 'Group Description 695410220636154626'),
(211, 'Group 23', 'Group Description 184425459428858746'),
(212, 'Group 92', 'Group Description 679972626636769741'),
(213, 'Group 37', 'Group Description 524488457380163095'),
(214, 'Group 30', 'Group Description 499714139867152567'),
(215, 'Group 65', 'Group Description 276443729495304648'),
(216, 'Group 35', 'Group Description 368674136288258384'),
(217, 'Group 22', 'Group Description 765207877663529989'),
(218, 'Group 31', 'Group Description 248867104995646905'),
(219, 'Group 31', 'Group Description 569740434586500435'),
(220, 'Group 91', 'Group Description 628838762934202448'),
(221, 'Group 98', 'Group Description 513432735463612182'),
(222, 'Group 36', 'Group Description 870921365963300902'),
(223, 'Group 52', 'Group Description 368912691030845685'),
(224, 'Group 69', 'Group Description 233248657176191505'),
(225, 'Group 36', 'Group Description 152874153551564796'),
(226, 'Group 97', 'Group Description 747237155638208960'),
(227, 'Group 69', 'Group Description 257014455675686676'),
(228, 'Group 75', 'Group Description 286089272890183545'),
(229, 'Group 85', 'Group Description 238085685945158897'),
(230, 'Group 47', 'Group Description 752309612221891660'),
(231, 'Group 90', 'Group Description 356865343572627280'),
(232, 'Group 83', 'Group Description 515093642077463738'),
(233, 'Group 43', 'Group Description 591358740290152673'),
(234, 'Group 24', 'Group Description 525419628481590784'),
(235, 'Group 47', 'Group Description 786844357557557873'),
(236, 'Group 58', 'Group Description 649080229166596118'),
(237, 'Group 82', 'Group Description 844659507641852246'),
(238, 'Group 76', 'Group Description 439963783707581854'),
(239, 'Group 39', 'Group Description 864384413763129618'),
(240, 'Group 24', 'Group Description 439408788700373353'),
(241, 'Group 98', 'Group Description 714901370369125788'),
(242, 'Group 91', 'Group Description 734370131569243506'),
(243, 'Group 93', 'Group Description 844402590488619181'),
(244, 'Group 61', 'Group Description 861242552847463178'),
(245, 'Group 41', 'Group Description 734989219204179920'),
(246, 'Group 69', 'Group Description 608156403828166890'),
(247, 'Group 54', 'Group Description 525953705829858438'),
(248, 'Group 48', 'Group Description 397060401906169350'),
(249, 'Group 47', 'Group Description 378825761736354162'),
(250, 'Group 28', 'Group Description 841308432914400605'),
(251, 'Group 47', 'Group Description 577675863324770048'),
(252, 'Group 48', 'Group Description 103285184138342061'),
(253, 'Group 59', 'Group Description 672937184512303827'),
(254, 'Group 82', 'Group Description 816800758467142835'),
(255, 'Group 72', 'Group Description 461054685844303213'),
(256, 'Group 30', 'Group Description 501101358582112562'),
(257, 'Group 97', 'Group Description 889566135184158240'),
(258, 'Group 43', 'Group Description 157438492007189900'),
(259, 'Group 75', 'Group Description 150291118890827240'),
(260, 'Group 32', 'Group Description 803027418650581774'),
(261, 'Group 37', 'Group Description 292144442581374107'),
(262, 'Group 21', 'Group Description 413740657856545992'),
(263, 'Group 48', 'Group Description 133171511539366561'),
(264, 'Group 86', 'Group Description 783110635371751679'),
(265, 'Group 94', 'Group Description 864266463583636263'),
(266, 'Group 23', 'Group Description 309407616137309308'),
(267, 'Group 75', 'Group Description 646797889063486477'),
(268, 'Group 34', 'Group Description 369135604421408496'),
(269, 'Group 31', 'Group Description 399130167137368697'),
(270, 'Group 33', 'Group Description 319568760784583260'),
(271, 'hggygy', '');

-- --------------------------------------------------------

--
-- Table structure for table `group_roles`
--

CREATE TABLE `group_roles` (
  `grolr_role_id_fk` int(11) NOT NULL,
  `grolr_g_id_fk` int(11) NOT NULL,
  `grole_view` tinyint(1) NOT NULL DEFAULT '0',
  `grole_add` tinyint(1) NOT NULL DEFAULT '0',
  `grole_edit` tinyint(1) NOT NULL DEFAULT '0',
  `grole_delete` tinyint(1) NOT NULL DEFAULT '0',
  `grole_print` tinyint(1) NOT NULL DEFAULT '0',
  `grole_export` tinyint(1) NOT NULL DEFAULT '0',
  `grole_other` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Dumping data for table `group_roles`
--

INSERT INTO `group_roles` (`grolr_role_id_fk`, `grolr_g_id_fk`, `grole_view`, `grole_add`, `grole_edit`, `grole_delete`, `grole_print`, `grole_export`, `grole_other`) VALUES
(1, 1, 1, 1, 1, 1, 1, 1, NULL),
(1, 2, 1, 1, 1, 1, 1, 1, NULL),
(1, 4, 1, 0, 0, 1, 1, 1, NULL),
(1, 6, 0, 0, 0, 0, 1, 1, NULL),
(1, 8, 1, 0, 1, 0, 0, 0, NULL),
(1, 10, 1, 0, 1, 0, 0, 0, NULL),
(1, 11, 0, 0, 0, 0, 1, 0, NULL),
(1, 14, 1, 1, 1, 1, 1, 0, NULL),
(1, 15, 0, 1, 1, 1, 0, 0, NULL),
(1, 23, 1, 1, 1, 1, 0, 0, NULL),
(1, 24, 0, 1, 1, 0, 0, 0, NULL),
(1, 26, 0, 1, 1, 0, 0, 0, NULL),
(1, 27, 0, 1, 1, 0, 1, 0, NULL),
(1, 28, 0, 1, 0, 0, 0, 0, NULL),
(1, 29, 0, 1, 1, 0, 1, 1, NULL),
(1, 33, 0, 1, 1, 0, 1, 0, NULL),
(1, 38, 1, 1, 1, 0, 1, 1, NULL),
(1, 39, 1, 0, 0, 1, 0, 1, NULL),
(1, 51, 0, 1, 0, 1, 0, 1, NULL),
(1, 54, 1, 0, 0, 0, 1, 0, NULL),
(1, 67, 1, 1, 1, 1, 1, 0, NULL),
(1, 70, 1, 1, 0, 0, 0, 1, NULL),
(1, 71, 1, 0, 1, 1, 1, 0, NULL),
(1, 73, 1, 0, 1, 0, 0, 1, NULL),
(1, 74, 0, 0, 1, 0, 1, 0, NULL),
(1, 76, 1, 1, 0, 1, 1, 0, NULL),
(1, 77, 0, 0, 1, 0, 0, 1, NULL),
(1, 78, 1, 1, 0, 0, 1, 1, NULL),
(1, 81, 1, 0, 1, 0, 1, 0, NULL),
(1, 82, 0, 0, 0, 0, 0, 0, NULL),
(1, 83, 1, 0, 1, 0, 1, 1, NULL),
(1, 84, 0, 1, 0, 0, 0, 0, NULL),
(1, 87, 0, 1, 1, 0, 1, 1, NULL),
(1, 89, 1, 1, 0, 0, 0, 0, NULL),
(1, 91, 1, 1, 0, 0, 1, 1, NULL),
(1, 92, 0, 1, 0, 1, 0, 1, NULL),
(1, 96, 1, 1, 1, 1, 1, 1, NULL),
(1, 98, 0, 0, 0, 1, 0, 0, NULL),
(1, 100, 0, 0, 0, 0, 0, 0, NULL),
(1, 103, 1, 1, 1, 0, 1, 0, NULL),
(1, 105, 0, 0, 1, 0, 1, 0, NULL),
(1, 106, 0, 1, 1, 0, 1, 1, NULL),
(1, 108, 0, 0, 1, 0, 0, 0, NULL),
(1, 109, 0, 0, 1, 0, 1, 1, NULL),
(1, 111, 0, 0, 0, 0, 1, 1, NULL),
(1, 114, 0, 1, 0, 0, 1, 0, NULL),
(1, 115, 0, 0, 1, 1, 1, 0, NULL),
(1, 116, 1, 0, 1, 0, 0, 0, NULL),
(1, 119, 1, 0, 1, 0, 0, 0, NULL),
(1, 121, 1, 0, 0, 1, 0, 1, NULL),
(1, 124, 1, 1, 1, 1, 0, 1, NULL),
(1, 127, 1, 0, 0, 1, 0, 1, NULL),
(1, 129, 1, 0, 0, 1, 0, 1, NULL),
(1, 131, 0, 0, 0, 0, 1, 0, NULL),
(1, 132, 0, 1, 1, 0, 0, 1, NULL),
(1, 134, 0, 1, 1, 0, 1, 0, NULL),
(1, 142, 1, 0, 0, 0, 0, 0, NULL),
(1, 144, 0, 1, 1, 0, 0, 0, NULL),
(1, 146, 0, 0, 1, 1, 0, 1, NULL),
(1, 150, 0, 0, 1, 0, 1, 0, NULL),
(1, 151, 0, 1, 1, 1, 0, 0, NULL),
(1, 154, 0, 0, 0, 0, 0, 1, NULL),
(1, 155, 1, 1, 0, 0, 0, 0, NULL),
(1, 158, 0, 1, 0, 0, 0, 1, NULL),
(1, 162, 1, 1, 1, 0, 1, 1, NULL),
(1, 163, 1, 0, 0, 0, 0, 1, NULL),
(1, 165, 0, 1, 0, 0, 0, 1, NULL),
(1, 172, 0, 1, 0, 1, 1, 0, NULL),
(1, 174, 0, 1, 1, 0, 1, 0, NULL),
(1, 177, 0, 1, 1, 1, 0, 0, NULL),
(1, 178, 0, 0, 1, 1, 1, 0, NULL),
(1, 185, 1, 1, 1, 1, 0, 1, NULL),
(1, 190, 1, 0, 0, 0, 0, 1, NULL),
(1, 193, 0, 0, 1, 0, 1, 1, NULL),
(1, 198, 0, 0, 0, 1, 0, 1, NULL),
(1, 204, 1, 0, 0, 0, 1, 1, NULL),
(1, 208, 0, 1, 1, 1, 0, 0, NULL),
(1, 212, 0, 0, 1, 0, 0, 0, NULL),
(1, 213, 1, 0, 1, 0, 1, 1, NULL),
(1, 217, 1, 1, 0, 0, 0, 1, NULL),
(1, 224, 0, 1, 0, 0, 0, 1, NULL),
(1, 229, 0, 0, 0, 0, 0, 0, NULL),
(1, 230, 1, 1, 0, 1, 1, 1, NULL),
(1, 235, 1, 1, 1, 1, 1, 1, NULL),
(1, 238, 1, 0, 0, 0, 0, 1, NULL),
(1, 242, 0, 1, 0, 0, 0, 1, NULL),
(1, 245, 1, 0, 1, 1, 0, 1, NULL),
(1, 248, 1, 0, 1, 1, 0, 1, NULL),
(1, 251, 0, 0, 1, 1, 0, 0, NULL),
(1, 252, 1, 1, 1, 1, 1, 0, NULL),
(1, 255, 1, 0, 1, 1, 1, 0, NULL),
(1, 256, 1, 0, 0, 0, 1, 1, NULL),
(1, 257, 1, 0, 1, 0, 0, 0, NULL),
(1, 258, 0, 1, 1, 1, 0, 0, NULL),
(1, 264, 0, 0, 1, 1, 0, 0, NULL),
(1, 266, 1, 0, 0, 1, 0, 0, NULL),
(1, 269, 0, 1, 1, 0, 1, 0, NULL),
(2, 6, 0, 0, 1, 0, 0, 1, NULL),
(2, 12, 0, 1, 0, 1, 1, 0, NULL),
(2, 16, 0, 0, 1, 0, 1, 0, NULL),
(2, 20, 1, 0, 1, 1, 0, 1, NULL),
(2, 23, 1, 1, 1, 1, 0, 0, NULL),
(2, 26, 0, 1, 1, 0, 0, 0, NULL),
(2, 27, 0, 1, 1, 0, 1, 0, NULL),
(2, 28, 0, 1, 0, 0, 0, 0, NULL),
(2, 31, 0, 0, 0, 1, 1, 0, NULL),
(2, 40, 1, 1, 0, 0, 1, 0, NULL),
(2, 55, 1, 0, 1, 0, 1, 1, NULL),
(2, 58, 1, 1, 1, 1, 1, 0, NULL),
(2, 63, 0, 1, 0, 1, 0, 0, NULL),
(2, 69, 1, 1, 0, 1, 0, 1, NULL),
(2, 72, 1, 1, 1, 0, 1, 1, NULL),
(2, 76, 1, 1, 0, 1, 1, 0, NULL),
(2, 83, 1, 0, 0, 1, 1, 1, NULL),
(2, 85, 1, 1, 0, 0, 0, 0, NULL),
(2, 89, 1, 1, 1, 1, 1, 0, NULL),
(2, 94, 1, 0, 1, 0, 0, 1, NULL),
(2, 96, 0, 0, 0, 0, 0, 0, NULL),
(2, 97, 1, 1, 0, 1, 1, 0, NULL),
(2, 98, 0, 0, 0, 1, 0, 1, NULL),
(2, 103, 0, 0, 1, 1, 1, 1, NULL),
(2, 104, 0, 1, 0, 1, 1, 1, NULL),
(2, 105, 1, 0, 1, 0, 1, 1, NULL),
(2, 112, 1, 0, 1, 1, 1, 0, NULL),
(2, 113, 1, 1, 0, 0, 1, 0, NULL),
(2, 116, 0, 0, 0, 0, 0, 1, NULL),
(2, 117, 1, 1, 1, 0, 1, 1, NULL),
(2, 120, 0, 0, 1, 1, 0, 0, NULL),
(2, 125, 0, 1, 0, 1, 1, 1, NULL),
(2, 129, 0, 0, 0, 1, 0, 1, NULL),
(2, 131, 1, 1, 0, 0, 1, 1, NULL),
(2, 136, 1, 1, 1, 1, 0, 0, NULL),
(2, 137, 0, 1, 0, 1, 0, 1, NULL),
(2, 138, 0, 1, 1, 0, 1, 0, NULL),
(2, 140, 0, 1, 0, 1, 0, 0, NULL),
(2, 143, 0, 0, 1, 1, 1, 1, NULL),
(2, 149, 1, 0, 0, 0, 1, 0, NULL),
(2, 154, 1, 1, 0, 1, 1, 1, NULL),
(2, 162, 0, 0, 0, 1, 0, 0, NULL),
(2, 163, 0, 0, 0, 0, 0, 0, NULL),
(2, 169, 1, 0, 1, 1, 0, 0, NULL),
(2, 174, 0, 1, 0, 0, 0, 1, NULL),
(2, 178, 1, 1, 0, 0, 1, 0, NULL),
(2, 188, 1, 0, 0, 0, 1, 1, NULL),
(2, 202, 1, 1, 1, 1, 0, 0, NULL),
(2, 209, 0, 0, 0, 0, 1, 1, NULL),
(2, 212, 1, 0, 0, 0, 1, 0, NULL),
(2, 213, 0, 0, 1, 1, 0, 1, NULL),
(2, 224, 1, 0, 1, 1, 1, 0, NULL),
(2, 228, 1, 0, 1, 1, 1, 0, NULL),
(2, 232, 0, 0, 0, 1, 1, 0, NULL),
(2, 235, 1, 0, 0, 0, 0, 0, NULL),
(2, 239, 1, 1, 0, 1, 1, 1, NULL),
(2, 240, 1, 0, 0, 1, 1, 1, NULL),
(2, 242, 0, 1, 0, 1, 1, 1, NULL),
(2, 248, 1, 0, 1, 0, 1, 0, NULL),
(2, 249, 1, 0, 0, 0, 1, 1, NULL),
(2, 251, 1, 0, 0, 0, 0, 1, NULL),
(2, 254, 1, 0, 1, 1, 1, 0, NULL),
(2, 261, 1, 1, 1, 0, 1, 0, NULL),
(2, 262, 1, 1, 0, 0, 0, 0, NULL),
(2, 265, 1, 0, 0, 0, 1, 0, NULL),
(2, 266, 1, 0, 1, 0, 1, 0, NULL),
(2, 267, 1, 1, 0, 0, 0, 0, NULL),
(2, 269, 0, 1, 0, 1, 0, 1, NULL),
(2, 271, 0, 1, 0, 0, 0, 0, NULL),
(3, 3, 1, 0, 0, 1, 0, 1, NULL),
(3, 4, 1, 0, 0, 1, 0, 0, NULL),
(3, 6, 0, 1, 1, 0, 0, 1, NULL),
(3, 8, 1, 1, 0, 0, 0, 0, NULL),
(3, 11, 1, 0, 0, 0, 1, 0, NULL),
(3, 14, 1, 1, 1, 1, 1, 1, NULL),
(3, 17, 1, 1, 0, 0, 0, 0, NULL),
(3, 18, 1, 0, 1, 1, 0, 0, NULL),
(3, 19, 1, 1, 0, 1, 0, 1, NULL),
(3, 26, 1, 1, 1, 1, 0, 0, NULL),
(3, 27, 0, 1, 1, 0, 1, 0, NULL),
(3, 28, 0, 1, 0, 0, 0, 0, NULL),
(3, 29, 0, 1, 1, 1, 0, 1, NULL),
(3, 36, 0, 0, 0, 0, 1, 0, NULL),
(3, 41, 1, 1, 1, 0, 0, 0, NULL),
(3, 43, 0, 1, 1, 1, 1, 0, NULL),
(3, 50, 0, 1, 1, 0, 1, 0, NULL),
(3, 61, 0, 0, 1, 1, 0, 0, NULL),
(3, 70, 1, 1, 0, 0, 0, 1, NULL),
(3, 74, 0, 1, 1, 1, 1, 0, NULL),
(3, 75, 1, 1, 0, 1, 1, 1, NULL),
(3, 81, 1, 1, 1, 0, 1, 0, NULL),
(3, 83, 1, 0, 1, 1, 0, 1, NULL),
(3, 84, 0, 0, 0, 0, 1, 1, NULL),
(3, 85, 0, 1, 0, 0, 0, 1, NULL),
(3, 91, 0, 1, 0, 1, 1, 1, NULL),
(3, 94, 1, 1, 0, 1, 0, 1, NULL),
(3, 99, 1, 0, 0, 0, 0, 0, NULL),
(3, 104, 1, 0, 0, 1, 0, 0, NULL),
(3, 106, 0, 0, 1, 0, 0, 1, NULL),
(3, 110, 1, 0, 0, 0, 0, 1, NULL),
(3, 112, 1, 1, 0, 0, 1, 0, NULL),
(3, 114, 0, 0, 1, 0, 0, 1, NULL),
(3, 118, 0, 1, 1, 0, 1, 1, NULL),
(3, 123, 1, 1, 1, 0, 0, 1, NULL),
(3, 124, 0, 1, 0, 0, 1, 1, NULL),
(3, 125, 0, 1, 0, 1, 1, 0, NULL),
(3, 132, 0, 1, 1, 0, 0, 0, NULL),
(3, 135, 0, 1, 1, 1, 0, 0, NULL),
(3, 137, 0, 0, 0, 0, 1, 0, NULL),
(3, 138, 0, 0, 1, 0, 0, 0, NULL),
(3, 140, 0, 0, 1, 1, 1, 0, NULL),
(3, 146, 0, 0, 0, 0, 1, 0, NULL),
(3, 152, 0, 0, 1, 0, 1, 0, NULL),
(3, 155, 1, 1, 0, 1, 0, 0, NULL),
(3, 159, 1, 0, 0, 1, 1, 1, NULL),
(3, 163, 0, 1, 0, 0, 1, 0, NULL),
(3, 166, 1, 0, 1, 0, 1, 0, NULL),
(3, 169, 0, 0, 1, 1, 1, 0, NULL),
(3, 171, 1, 0, 0, 1, 0, 1, NULL),
(3, 174, 1, 0, 0, 0, 1, 1, NULL),
(3, 178, 0, 1, 1, 1, 1, 0, NULL),
(3, 179, 0, 1, 1, 0, 1, 0, NULL),
(3, 183, 1, 0, 0, 0, 1, 1, NULL),
(3, 191, 1, 1, 0, 0, 0, 0, NULL),
(3, 194, 1, 1, 1, 1, 0, 1, NULL),
(3, 196, 1, 0, 0, 1, 1, 1, NULL),
(3, 200, 0, 1, 0, 0, 1, 1, NULL),
(3, 202, 1, 1, 1, 0, 0, 0, NULL),
(3, 207, 1, 1, 0, 0, 1, 0, NULL),
(3, 208, 1, 1, 1, 1, 0, 0, NULL),
(3, 210, 0, 0, 0, 0, 1, 1, NULL),
(3, 211, 0, 0, 0, 1, 1, 1, NULL),
(3, 212, 1, 0, 0, 0, 1, 1, NULL),
(3, 217, 0, 1, 1, 0, 0, 0, NULL),
(3, 218, 1, 0, 0, 0, 0, 0, NULL),
(3, 220, 0, 1, 1, 0, 1, 1, NULL),
(3, 221, 0, 1, 1, 0, 1, 1, NULL),
(3, 223, 1, 0, 0, 1, 1, 0, NULL),
(3, 224, 0, 1, 0, 1, 1, 1, NULL),
(3, 226, 0, 1, 1, 0, 0, 1, NULL),
(3, 230, 0, 1, 0, 1, 0, 1, NULL),
(3, 232, 1, 0, 0, 1, 0, 1, NULL),
(3, 235, 0, 0, 0, 0, 1, 1, NULL),
(3, 248, 0, 0, 1, 1, 0, 1, NULL),
(3, 249, 0, 1, 1, 0, 0, 1, NULL),
(3, 252, 1, 0, 1, 1, 0, 0, NULL),
(3, 256, 1, 0, 1, 0, 1, 1, NULL),
(3, 257, 0, 0, 0, 0, 0, 1, NULL),
(3, 258, 0, 1, 0, 1, 1, 0, NULL),
(3, 261, 1, 1, 1, 0, 0, 0, NULL),
(3, 269, 0, 1, 0, 0, 1, 1, NULL),
(3, 270, 0, 1, 0, 0, 1, 0, NULL),
(3, 271, 1, 0, 1, 1, 0, 0, NULL),
(4, 2, 0, 1, 0, 0, 1, 0, NULL),
(4, 4, 1, 1, 1, 0, 1, 1, NULL),
(4, 5, 1, 1, 0, 1, 0, 1, NULL),
(4, 6, 0, 1, 0, 0, 0, 1, NULL),
(4, 8, 0, 1, 0, 1, 1, 1, NULL),
(4, 17, 1, 0, 0, 0, 1, 0, NULL),
(4, 24, 0, 1, 1, 1, 0, 1, NULL),
(4, 26, 1, 0, 1, 1, 0, 0, NULL),
(4, 27, 1, 1, 1, 1, 1, 1, NULL),
(4, 28, 0, 1, 0, 0, 0, 0, NULL),
(4, 29, 1, 1, 1, 0, 0, 0, NULL),
(4, 36, 1, 0, 0, 1, 0, 1, NULL),
(4, 40, 1, 1, 1, 1, 1, 1, NULL),
(4, 41, 1, 0, 1, 1, 1, 0, NULL),
(4, 43, 0, 1, 0, 1, 0, 1, NULL),
(4, 46, 1, 1, 1, 1, 0, 1, NULL),
(4, 52, 1, 0, 0, 1, 1, 0, NULL),
(4, 53, 1, 0, 1, 1, 1, 1, NULL),
(4, 55, 0, 0, 1, 0, 1, 1, NULL),
(4, 57, 0, 0, 1, 1, 1, 1, NULL),
(4, 58, 1, 1, 1, 0, 0, 1, NULL),
(4, 61, 1, 1, 0, 0, 0, 1, NULL),
(4, 70, 1, 0, 0, 1, 0, 1, NULL),
(4, 71, 1, 1, 0, 1, 1, 1, NULL),
(4, 73, 1, 1, 1, 1, 1, 1, NULL),
(4, 76, 0, 0, 1, 1, 0, 1, NULL),
(4, 77, 1, 0, 1, 0, 1, 0, NULL),
(4, 78, 1, 1, 1, 0, 1, 1, NULL),
(4, 79, 0, 1, 1, 1, 0, 1, NULL),
(4, 81, 0, 1, 0, 1, 1, 0, NULL),
(4, 82, 0, 0, 0, 0, 1, 0, NULL),
(4, 83, 0, 0, 1, 0, 0, 0, NULL),
(4, 84, 0, 1, 0, 0, 1, 1, NULL),
(4, 89, 1, 1, 0, 0, 0, 1, NULL),
(4, 90, 0, 1, 0, 1, 1, 1, NULL),
(4, 91, 1, 0, 1, 1, 0, 1, NULL),
(4, 93, 0, 1, 1, 1, 1, 1, NULL),
(4, 94, 1, 1, 1, 0, 0, 1, NULL),
(4, 100, 0, 1, 1, 0, 1, 1, NULL),
(4, 106, 0, 0, 1, 0, 0, 0, NULL),
(4, 107, 0, 0, 0, 1, 1, 1, NULL),
(4, 111, 0, 0, 0, 0, 1, 0, NULL),
(4, 112, 1, 0, 0, 1, 1, 1, NULL),
(4, 114, 1, 1, 1, 0, 0, 0, NULL),
(4, 117, 0, 1, 0, 1, 1, 1, NULL),
(4, 119, 0, 1, 1, 0, 1, 0, NULL),
(4, 120, 1, 0, 1, 0, 0, 0, NULL),
(4, 125, 1, 1, 0, 0, 1, 1, NULL),
(4, 127, 1, 1, 1, 0, 0, 0, NULL),
(4, 131, 1, 0, 1, 1, 0, 0, NULL),
(4, 135, 1, 1, 1, 1, 1, 1, NULL),
(4, 136, 1, 0, 1, 0, 0, 1, NULL),
(4, 138, 1, 1, 1, 1, 0, 1, NULL),
(4, 141, 1, 0, 1, 1, 0, 0, NULL),
(4, 144, 1, 1, 0, 0, 1, 0, NULL),
(4, 145, 1, 0, 0, 1, 1, 1, NULL),
(4, 151, 0, 1, 0, 0, 1, 1, NULL),
(4, 169, 1, 1, 1, 0, 0, 0, NULL),
(4, 170, 1, 1, 1, 1, 0, 1, NULL),
(4, 171, 1, 0, 1, 1, 0, 0, NULL),
(4, 173, 0, 1, 0, 1, 0, 0, NULL),
(4, 174, 0, 0, 1, 0, 1, 1, NULL),
(4, 184, 1, 0, 0, 1, 0, 0, NULL),
(4, 186, 1, 1, 0, 1, 1, 0, NULL),
(4, 191, 0, 0, 1, 0, 0, 1, NULL),
(4, 196, 1, 1, 0, 1, 1, 1, NULL),
(4, 209, 1, 1, 1, 1, 0, 0, NULL),
(4, 210, 1, 0, 0, 1, 0, 0, NULL),
(4, 213, 0, 1, 0, 1, 0, 0, NULL),
(4, 217, 0, 1, 1, 0, 0, 1, NULL),
(4, 220, 1, 1, 1, 1, 0, 1, NULL),
(4, 224, 0, 1, 1, 1, 1, 0, NULL),
(4, 230, 1, 0, 0, 1, 0, 1, NULL),
(4, 235, 1, 1, 0, 0, 0, 0, NULL),
(4, 237, 1, 0, 0, 0, 0, 0, NULL),
(4, 239, 0, 0, 1, 0, 0, 1, NULL),
(4, 242, 0, 0, 0, 0, 0, 1, NULL),
(4, 245, 1, 1, 1, 0, 0, 0, NULL),
(4, 251, 1, 0, 1, 0, 1, 0, NULL),
(4, 255, 0, 1, 0, 1, 0, 0, NULL),
(4, 256, 0, 0, 1, 1, 0, 0, NULL),
(4, 262, 0, 1, 0, 0, 0, 1, NULL),
(4, 265, 1, 0, 1, 1, 0, 1, NULL),
(4, 267, 0, 1, 1, 1, 1, 0, NULL),
(4, 271, 0, 0, 1, 1, 0, 0, NULL),
(5, 5, 1, 1, 1, 0, 0, 0, NULL),
(5, 12, 1, 1, 1, 1, 1, 0, NULL),
(5, 14, 0, 0, 0, 1, 0, 1, NULL),
(5, 16, 0, 1, 0, 0, 0, 1, NULL),
(5, 24, 0, 0, 1, 0, 1, 0, NULL),
(5, 26, 0, 1, 0, 0, 0, 0, NULL),
(5, 46, 0, 1, 1, 0, 0, 0, NULL),
(5, 61, 0, 1, 1, 1, 1, 0, NULL),
(5, 68, 0, 1, 1, 1, 0, 1, NULL),
(5, 73, 0, 1, 1, 0, 1, 0, NULL),
(5, 76, 1, 0, 1, 0, 1, 0, NULL),
(5, 77, 1, 1, 1, 0, 1, 0, NULL),
(5, 81, 0, 0, 0, 0, 1, 1, NULL),
(5, 85, 1, 0, 1, 0, 1, 0, NULL),
(5, 86, 0, 0, 1, 1, 1, 1, NULL),
(5, 87, 0, 0, 0, 1, 0, 1, NULL),
(5, 88, 0, 1, 0, 1, 1, 0, NULL),
(5, 89, 1, 1, 0, 1, 0, 1, NULL),
(5, 92, 0, 0, 0, 0, 1, 1, NULL),
(5, 96, 1, 1, 0, 1, 1, 1, NULL),
(5, 98, 1, 1, 0, 1, 0, 0, NULL),
(5, 100, 1, 1, 1, 0, 1, 0, NULL),
(5, 108, 0, 0, 0, 0, 1, 0, NULL),
(5, 109, 0, 1, 1, 0, 1, 1, NULL),
(5, 110, 1, 0, 1, 0, 0, 1, NULL),
(5, 114, 0, 1, 1, 0, 1, 0, NULL),
(5, 116, 1, 0, 0, 1, 0, 1, NULL),
(5, 119, 1, 0, 1, 0, 1, 0, NULL),
(5, 120, 1, 0, 1, 0, 1, 1, NULL),
(5, 122, 1, 1, 1, 0, 0, 1, NULL),
(5, 127, 0, 0, 1, 0, 0, 1, NULL),
(5, 129, 0, 1, 1, 1, 0, 0, NULL),
(5, 131, 0, 0, 0, 1, 0, 0, NULL),
(5, 132, 1, 1, 1, 0, 1, 0, NULL),
(5, 134, 0, 0, 1, 1, 0, 1, NULL),
(5, 135, 0, 0, 1, 1, 1, 1, NULL),
(5, 136, 1, 0, 0, 0, 0, 1, NULL),
(5, 137, 1, 1, 0, 1, 0, 0, NULL),
(5, 142, 0, 0, 1, 1, 1, 1, NULL),
(5, 144, 0, 0, 1, 0, 0, 0, NULL),
(5, 158, 0, 1, 1, 1, 0, 0, NULL),
(5, 160, 1, 1, 1, 1, 1, 1, NULL),
(5, 163, 1, 1, 0, 0, 1, 0, NULL),
(5, 165, 0, 1, 1, 0, 0, 1, NULL),
(5, 175, 1, 1, 1, 0, 1, 1, NULL),
(5, 178, 1, 0, 0, 1, 1, 0, NULL),
(5, 179, 1, 0, 0, 0, 0, 1, NULL),
(5, 184, 1, 0, 0, 0, 0, 1, NULL),
(5, 189, 0, 1, 0, 1, 0, 0, NULL),
(5, 194, 1, 0, 0, 0, 0, 1, NULL),
(5, 198, 0, 0, 1, 1, 0, 1, NULL),
(5, 200, 0, 0, 1, 0, 1, 0, NULL),
(5, 201, 1, 1, 0, 1, 1, 1, NULL),
(5, 202, 0, 0, 1, 0, 0, 1, NULL),
(5, 207, 0, 1, 0, 1, 0, 0, NULL),
(5, 208, 1, 1, 1, 1, 0, 0, NULL),
(5, 210, 1, 1, 1, 0, 1, 1, NULL),
(5, 212, 1, 0, 1, 0, 1, 0, NULL),
(5, 221, 0, 1, 0, 0, 0, 0, NULL),
(5, 222, 1, 0, 0, 1, 0, 1, NULL),
(5, 227, 1, 1, 0, 0, 0, 1, NULL),
(5, 229, 1, 0, 0, 1, 0, 0, NULL),
(5, 233, 1, 0, 1, 1, 0, 0, NULL),
(5, 235, 1, 0, 0, 0, 1, 0, NULL),
(5, 236, 1, 1, 0, 0, 0, 0, NULL),
(5, 239, 0, 1, 0, 0, 1, 1, NULL),
(5, 242, 1, 1, 1, 1, 1, 0, NULL),
(5, 245, 0, 0, 0, 1, 1, 1, NULL),
(5, 247, 1, 1, 0, 0, 0, 0, NULL),
(5, 248, 0, 0, 1, 0, 0, 0, NULL),
(5, 255, 0, 0, 1, 1, 1, 0, NULL),
(5, 256, 1, 0, 0, 1, 0, 0, NULL),
(5, 258, 0, 1, 0, 0, 1, 0, NULL),
(5, 261, 1, 0, 1, 1, 0, 0, NULL),
(5, 262, 0, 0, 1, 1, 0, 0, NULL),
(5, 267, 0, 0, 1, 0, 0, 0, NULL),
(5, 268, 1, 0, 0, 0, 0, 0, NULL),
(5, 270, 0, 1, 1, 0, 0, 1, NULL),
(5, 271, 0, 0, 0, 1, 0, 0, NULL),
(6, 1, 0, 1, 1, 0, 0, 0, NULL),
(6, 6, 1, 1, 0, 0, 0, 0, NULL),
(6, 8, 1, 0, 1, 1, 0, 0, NULL),
(6, 14, 1, 0, 0, 1, 1, 1, NULL),
(6, 17, 0, 0, 0, 1, 1, 1, NULL),
(6, 22, 1, 1, 0, 0, 0, 0, NULL),
(6, 24, 0, 1, 1, 0, 0, 0, NULL),
(6, 35, 0, 0, 0, 0, 0, 0, NULL),
(6, 41, 0, 0, 0, 0, 1, 1, NULL),
(6, 46, 1, 1, 1, 1, 0, 0, NULL),
(6, 51, 1, 1, 0, 0, 0, 1, NULL),
(6, 52, 0, 0, 0, 0, 1, 0, NULL),
(6, 54, 0, 1, 1, 1, 0, 0, NULL),
(6, 55, 1, 0, 0, 1, 1, 1, NULL),
(6, 61, 0, 1, 0, 1, 1, 0, NULL),
(6, 69, 0, 0, 1, 1, 0, 0, NULL),
(6, 73, 1, 1, 0, 1, 0, 1, NULL),
(6, 74, 1, 0, 1, 1, 0, 0, NULL),
(6, 77, 1, 1, 0, 1, 1, 1, NULL),
(6, 82, 1, 1, 0, 1, 1, 1, NULL),
(6, 83, 0, 1, 1, 1, 0, 0, NULL),
(6, 85, 0, 0, 1, 0, 1, 0, NULL),
(6, 86, 1, 1, 1, 0, 1, 0, NULL),
(6, 87, 1, 0, 1, 1, 1, 0, NULL),
(6, 91, 1, 1, 0, 1, 1, 1, NULL),
(6, 93, 1, 0, 1, 0, 1, 1, NULL),
(6, 94, 0, 0, 1, 0, 1, 1, NULL),
(6, 98, 1, 0, 1, 0, 0, 1, NULL),
(6, 105, 0, 1, 1, 0, 1, 0, NULL),
(6, 106, 0, 1, 1, 1, 0, 0, NULL),
(6, 112, 1, 0, 0, 0, 1, 1, NULL),
(6, 113, 0, 1, 0, 1, 1, 1, NULL),
(6, 114, 1, 0, 1, 1, 0, 0, NULL),
(6, 120, 0, 0, 0, 1, 0, 0, NULL),
(6, 121, 0, 0, 1, 1, 0, 0, NULL),
(6, 123, 0, 0, 1, 0, 1, 0, NULL),
(6, 124, 0, 1, 1, 1, 1, 0, NULL),
(6, 125, 1, 0, 1, 0, 1, 0, NULL),
(6, 129, 1, 0, 0, 0, 0, 0, NULL),
(6, 132, 1, 0, 1, 1, 1, 0, NULL),
(6, 135, 1, 0, 1, 0, 1, 0, NULL),
(6, 137, 1, 1, 0, 0, 1, 0, NULL),
(6, 138, 1, 0, 0, 0, 1, 1, NULL),
(6, 142, 1, 1, 1, 1, 1, 1, NULL),
(6, 144, 1, 0, 0, 0, 1, 0, NULL),
(6, 147, 1, 0, 1, 1, 1, 0, NULL),
(6, 148, 0, 1, 0, 0, 1, 0, NULL),
(6, 150, 0, 0, 1, 0, 1, 0, NULL),
(6, 158, 0, 1, 0, 0, 1, 1, NULL),
(6, 159, 1, 0, 1, 0, 0, 0, NULL),
(6, 161, 1, 1, 0, 0, 0, 1, NULL),
(6, 165, 1, 0, 0, 0, 0, 1, NULL),
(6, 168, 1, 1, 1, 0, 0, 1, NULL),
(6, 171, 1, 0, 1, 0, 1, 0, NULL),
(6, 173, 1, 1, 0, 1, 0, 1, NULL),
(6, 178, 1, 0, 1, 0, 1, 0, NULL),
(6, 188, 0, 0, 1, 0, 0, 1, NULL),
(6, 191, 0, 0, 0, 1, 1, 0, NULL),
(6, 194, 1, 0, 0, 1, 0, 0, NULL),
(6, 195, 0, 0, 0, 0, 0, 0, NULL),
(6, 196, 0, 1, 1, 0, 1, 1, NULL),
(6, 198, 1, 1, 1, 0, 1, 0, NULL),
(6, 200, 1, 0, 0, 1, 0, 1, NULL),
(6, 204, 1, 1, 1, 1, 0, 0, NULL),
(6, 205, 1, 1, 0, 1, 1, 1, NULL),
(6, 207, 1, 0, 0, 0, 1, 0, NULL),
(6, 209, 1, 0, 0, 0, 1, 0, NULL),
(6, 210, 1, 1, 0, 0, 0, 1, NULL),
(6, 213, 0, 1, 1, 1, 0, 1, NULL),
(6, 221, 0, 0, 1, 1, 0, 0, NULL),
(6, 224, 0, 1, 1, 1, 1, 0, NULL),
(6, 225, 1, 1, 1, 0, 0, 1, NULL),
(6, 226, 0, 1, 1, 1, 0, 1, NULL),
(6, 230, 1, 1, 1, 0, 1, 0, NULL),
(6, 237, 0, 0, 0, 0, 1, 0, NULL),
(6, 242, 1, 1, 1, 1, 0, 0, NULL),
(6, 243, 0, 0, 0, 1, 0, 0, NULL),
(6, 246, 1, 1, 1, 1, 1, 0, NULL),
(6, 247, 0, 0, 0, 0, 0, 0, NULL),
(6, 249, 0, 1, 1, 0, 0, 1, NULL),
(6, 255, 1, 0, 1, 1, 0, 0, NULL),
(6, 257, 0, 1, 0, 1, 1, 1, NULL),
(6, 258, 1, 0, 1, 0, 0, 1, NULL),
(6, 261, 1, 1, 1, 0, 0, 1, NULL),
(6, 265, 0, 1, 1, 1, 1, 1, NULL),
(6, 267, 1, 1, 0, 1, 0, 1, NULL),
(6, 271, 1, 0, 0, 0, 0, 1, NULL),
(7, 2, 1, 0, 1, 1, 1, 1, NULL),
(7, 9, 0, 1, 1, 0, 0, 0, NULL),
(7, 14, 0, 0, 1, 1, 0, 0, NULL),
(7, 36, 0, 1, 0, 0, 1, 1, NULL),
(7, 40, 0, 0, 0, 1, 0, 1, NULL),
(7, 41, 0, 0, 0, 1, 0, 0, NULL),
(7, 42, 1, 1, 0, 1, 1, 0, NULL),
(7, 46, 0, 0, 1, 0, 1, 1, NULL),
(7, 48, 0, 1, 1, 1, 0, 1, NULL),
(7, 70, 1, 1, 0, 0, 0, 1, NULL),
(7, 71, 1, 1, 0, 1, 0, 1, NULL),
(7, 72, 0, 1, 0, 0, 0, 0, NULL),
(7, 73, 1, 0, 1, 0, 1, 1, NULL),
(7, 76, 0, 1, 1, 0, 1, 1, NULL),
(7, 81, 1, 0, 0, 1, 1, 0, NULL),
(7, 83, 0, 1, 0, 0, 1, 1, NULL),
(7, 86, 1, 0, 1, 1, 1, 0, NULL),
(7, 88, 1, 1, 0, 0, 1, 0, NULL),
(7, 91, 0, 0, 0, 0, 0, 0, NULL),
(7, 99, 0, 1, 1, 0, 1, 1, NULL),
(7, 105, 0, 1, 0, 1, 1, 1, NULL),
(7, 106, 0, 1, 0, 0, 0, 0, NULL),
(7, 107, 1, 0, 1, 1, 1, 1, NULL),
(7, 110, 1, 0, 0, 0, 0, 1, NULL),
(7, 113, 0, 0, 0, 0, 0, 1, NULL),
(7, 114, 0, 0, 0, 1, 1, 0, NULL),
(7, 115, 1, 0, 1, 0, 0, 0, NULL),
(7, 118, 0, 0, 0, 1, 1, 0, NULL),
(7, 119, 1, 0, 1, 1, 1, 1, NULL),
(7, 121, 1, 1, 0, 1, 0, 0, NULL),
(7, 126, 1, 0, 1, 1, 1, 0, NULL),
(7, 127, 0, 0, 1, 1, 0, 1, NULL),
(7, 129, 0, 1, 1, 0, 0, 0, NULL),
(7, 131, 0, 1, 0, 0, 0, 0, NULL),
(7, 134, 0, 1, 1, 1, 1, 1, NULL),
(7, 135, 1, 0, 0, 1, 0, 0, NULL),
(7, 137, 0, 0, 1, 0, 1, 1, NULL),
(7, 140, 1, 0, 0, 1, 0, 0, NULL),
(7, 141, 1, 0, 1, 1, 1, 1, NULL),
(7, 142, 0, 0, 1, 1, 0, 0, NULL),
(7, 146, 0, 0, 1, 0, 0, 1, NULL),
(7, 147, 1, 0, 0, 1, 0, 0, NULL),
(7, 148, 1, 1, 1, 1, 0, 1, NULL),
(7, 150, 0, 0, 1, 1, 0, 1, NULL),
(7, 155, 1, 1, 1, 1, 1, 0, NULL),
(7, 157, 1, 1, 0, 0, 0, 0, NULL),
(7, 158, 0, 1, 1, 1, 0, 0, NULL),
(7, 159, 0, 1, 0, 0, 1, 0, NULL),
(7, 162, 0, 1, 0, 1, 1, 1, NULL),
(7, 165, 1, 1, 1, 1, 0, 1, NULL),
(7, 166, 0, 1, 0, 0, 1, 1, NULL),
(7, 169, 1, 1, 0, 0, 0, 0, NULL),
(7, 170, 1, 0, 1, 1, 0, 0, NULL),
(7, 179, 1, 0, 1, 0, 0, 1, NULL),
(7, 182, 1, 0, 0, 0, 0, 1, NULL),
(7, 184, 0, 1, 0, 1, 0, 1, NULL),
(7, 191, 1, 1, 0, 0, 0, 0, NULL),
(7, 193, 0, 0, 1, 1, 0, 0, NULL),
(7, 196, 0, 1, 0, 0, 0, 0, NULL),
(7, 201, 1, 1, 0, 1, 0, 1, NULL),
(7, 203, 1, 0, 1, 0, 0, 0, NULL),
(7, 207, 1, 0, 0, 1, 1, 1, NULL),
(7, 208, 1, 0, 1, 0, 1, 1, NULL),
(7, 210, 1, 0, 0, 0, 0, 1, NULL),
(7, 219, 1, 0, 0, 0, 1, 1, NULL),
(7, 226, 1, 1, 0, 1, 1, 0, NULL),
(7, 230, 1, 1, 0, 0, 0, 1, NULL),
(7, 234, 0, 0, 0, 0, 1, 0, NULL),
(7, 236, 1, 1, 1, 1, 1, 1, NULL),
(7, 239, 0, 0, 1, 1, 1, 1, NULL),
(7, 241, 0, 1, 0, 0, 0, 0, NULL),
(7, 242, 0, 0, 1, 0, 0, 0, NULL),
(7, 245, 1, 1, 1, 1, 1, 1, NULL),
(7, 247, 1, 0, 0, 1, 1, 0, NULL),
(7, 252, 1, 1, 0, 0, 1, 1, NULL),
(7, 255, 1, 1, 0, 0, 1, 0, NULL),
(7, 256, 1, 0, 0, 1, 0, 1, NULL),
(7, 258, 0, 0, 1, 0, 0, 0, NULL),
(7, 268, 0, 1, 0, 0, 1, 1, NULL),
(7, 269, 1, 1, 1, 0, 1, 0, NULL),
(7, 270, 1, 1, 0, 0, 0, 1, NULL),
(8, 4, 0, 0, 0, 1, 0, 0, NULL),
(8, 5, 1, 0, 1, 1, 0, 0, NULL),
(8, 6, 0, 1, 0, 0, 1, 1, NULL),
(8, 8, 1, 0, 1, 1, 0, 1, NULL),
(8, 12, 1, 1, 1, 1, 0, 0, NULL),
(8, 15, 0, 1, 1, 0, 0, 1, NULL),
(8, 16, 0, 0, 0, 0, 0, 1, NULL),
(8, 21, 0, 0, 0, 0, 0, 1, NULL),
(8, 36, 1, 0, 1, 0, 0, 0, NULL),
(8, 38, 0, 1, 1, 1, 0, 1, NULL),
(8, 39, 1, 0, 0, 0, 0, 0, NULL),
(8, 41, 1, 1, 0, 0, 0, 0, NULL),
(8, 43, 0, 0, 0, 0, 1, 0, NULL),
(8, 46, 1, 0, 1, 0, 1, 1, NULL),
(8, 47, 1, 0, 0, 0, 1, 0, NULL),
(8, 51, 1, 1, 0, 1, 1, 0, NULL),
(8, 52, 1, 0, 1, 0, 0, 0, NULL),
(8, 54, 1, 1, 0, 1, 0, 0, NULL),
(8, 55, 1, 0, 1, 0, 0, 1, NULL),
(8, 56, 0, 0, 1, 1, 1, 1, NULL),
(8, 57, 1, 0, 0, 1, 1, 0, NULL),
(8, 72, 1, 0, 1, 1, 0, 1, NULL),
(8, 73, 0, 0, 0, 1, 0, 1, NULL),
(8, 77, 0, 0, 0, 1, 0, 0, NULL),
(8, 81, 1, 1, 1, 0, 0, 0, NULL),
(8, 82, 0, 1, 1, 1, 1, 0, NULL),
(8, 87, 1, 0, 0, 0, 1, 0, NULL),
(8, 89, 0, 1, 1, 0, 1, 1, NULL),
(8, 93, 1, 0, 1, 0, 1, 1, NULL),
(8, 98, 1, 1, 0, 0, 0, 1, NULL),
(8, 102, 1, 1, 0, 0, 0, 0, NULL),
(8, 103, 1, 1, 0, 1, 1, 0, NULL),
(8, 107, 1, 0, 1, 0, 1, 0, NULL),
(8, 109, 0, 1, 0, 1, 1, 0, NULL),
(8, 112, 0, 1, 0, 1, 1, 0, NULL),
(8, 119, 1, 1, 1, 0, 0, 1, NULL),
(8, 120, 1, 0, 1, 0, 1, 0, NULL),
(8, 122, 1, 0, 1, 0, 0, 0, NULL),
(8, 123, 1, 0, 0, 1, 0, 0, NULL),
(8, 124, 0, 0, 0, 0, 0, 0, NULL),
(8, 129, 1, 1, 0, 1, 0, 1, NULL),
(8, 138, 0, 1, 1, 1, 1, 1, NULL),
(8, 147, 1, 1, 0, 0, 1, 0, NULL),
(8, 150, 1, 1, 0, 0, 1, 1, NULL),
(8, 152, 1, 1, 0, 1, 1, 1, NULL),
(8, 153, 1, 0, 0, 1, 1, 0, NULL),
(8, 155, 1, 0, 1, 0, 1, 0, NULL),
(8, 158, 1, 0, 1, 1, 0, 0, NULL),
(8, 164, 0, 1, 1, 1, 0, 1, NULL),
(8, 166, 0, 0, 1, 0, 0, 0, NULL),
(8, 167, 0, 0, 1, 1, 0, 0, NULL),
(8, 169, 0, 0, 0, 1, 1, 0, NULL),
(8, 171, 0, 0, 0, 1, 1, 1, NULL),
(8, 178, 0, 0, 1, 0, 1, 1, NULL),
(8, 183, 1, 1, 0, 1, 1, 1, NULL),
(8, 184, 1, 0, 0, 1, 0, 0, NULL),
(8, 189, 1, 1, 0, 1, 1, 0, NULL),
(8, 190, 0, 1, 0, 1, 1, 1, NULL),
(8, 194, 1, 0, 1, 0, 1, 1, NULL),
(8, 195, 0, 0, 1, 1, 1, 0, NULL),
(8, 198, 1, 1, 1, 0, 0, 1, NULL),
(8, 202, 0, 1, 0, 1, 1, 0, NULL),
(8, 203, 1, 0, 1, 1, 1, 0, NULL),
(8, 204, 1, 0, 1, 0, 1, 0, NULL),
(8, 208, 1, 1, 0, 0, 0, 1, NULL),
(8, 216, 0, 0, 1, 0, 1, 0, NULL),
(8, 220, 1, 1, 1, 1, 1, 0, NULL),
(8, 221, 1, 1, 0, 0, 0, 1, NULL),
(8, 225, 1, 0, 1, 0, 0, 1, NULL),
(8, 228, 0, 1, 0, 0, 1, 1, NULL),
(8, 232, 0, 1, 0, 1, 0, 0, NULL),
(8, 233, 1, 1, 1, 1, 0, 1, NULL),
(8, 236, 0, 1, 1, 0, 1, 1, NULL),
(8, 240, 1, 1, 0, 1, 0, 0, NULL),
(8, 243, 1, 0, 0, 0, 1, 0, NULL),
(8, 248, 0, 1, 0, 0, 0, 1, NULL),
(8, 251, 1, 0, 1, 0, 1, 1, NULL),
(8, 252, 1, 1, 1, 0, 1, 0, NULL),
(8, 261, 0, 0, 1, 1, 0, 1, NULL),
(8, 262, 0, 1, 0, 0, 0, 0, NULL),
(9, 4, 1, 0, 0, 1, 1, 1, NULL),
(9, 5, 1, 0, 1, 1, 1, 1, NULL),
(9, 13, 0, 1, 0, 1, 0, 0, NULL),
(9, 16, 0, 0, 1, 1, 0, 0, NULL),
(9, 24, 0, 0, 0, 1, 0, 1, NULL),
(9, 35, 1, 0, 1, 1, 0, 0, NULL),
(9, 36, 0, 1, 0, 0, 1, 1, NULL),
(9, 45, 1, 1, 1, 0, 0, 1, NULL),
(9, 46, 1, 1, 1, 0, 1, 0, NULL),
(9, 48, 0, 1, 1, 0, 0, 0, NULL),
(9, 50, 1, 0, 1, 1, 1, 1, NULL),
(9, 51, 1, 1, 1, 1, 1, 1, NULL),
(9, 54, 1, 0, 0, 0, 0, 0, NULL),
(9, 58, 0, 0, 0, 0, 0, 0, NULL),
(9, 61, 1, 1, 1, 0, 0, 1, NULL),
(9, 70, 1, 1, 1, 1, 1, 1, NULL),
(9, 72, 0, 1, 0, 0, 1, 0, NULL),
(9, 76, 0, 1, 0, 0, 0, 1, NULL),
(9, 77, 0, 0, 1, 1, 1, 1, NULL),
(9, 84, 1, 1, 1, 1, 0, 1, NULL),
(9, 85, 1, 0, 0, 0, 0, 1, NULL),
(9, 88, 0, 1, 0, 0, 1, 0, NULL),
(9, 89, 0, 1, 0, 0, 0, 1, NULL),
(9, 91, 1, 1, 0, 0, 1, 0, NULL),
(9, 92, 1, 1, 1, 1, 1, 1, NULL),
(9, 94, 0, 0, 0, 1, 0, 0, NULL),
(9, 95, 0, 0, 1, 1, 1, 1, NULL),
(9, 96, 0, 0, 0, 0, 0, 1, NULL),
(9, 99, 1, 0, 0, 1, 1, 0, NULL),
(9, 100, 1, 0, 1, 0, 0, 0, NULL),
(9, 101, 1, 0, 1, 0, 0, 0, NULL),
(9, 102, 1, 0, 1, 0, 1, 1, NULL),
(9, 105, 0, 0, 1, 1, 0, 1, NULL),
(9, 107, 1, 1, 0, 0, 1, 1, NULL),
(9, 109, 0, 1, 1, 0, 1, 1, NULL),
(9, 112, 1, 0, 1, 0, 1, 0, NULL),
(9, 116, 1, 0, 0, 0, 1, 0, NULL),
(9, 119, 0, 1, 1, 1, 0, 1, NULL),
(9, 125, 1, 0, 0, 0, 1, 0, NULL),
(9, 127, 1, 0, 0, 1, 1, 1, NULL),
(9, 130, 1, 1, 0, 1, 1, 1, NULL),
(9, 134, 1, 1, 1, 1, 1, 1, NULL),
(9, 136, 1, 1, 0, 0, 0, 1, NULL),
(9, 137, 1, 1, 1, 0, 0, 0, NULL),
(9, 144, 1, 1, 1, 0, 0, 1, NULL),
(9, 147, 0, 1, 0, 1, 0, 1, NULL),
(9, 150, 1, 0, 0, 0, 1, 1, NULL),
(9, 151, 1, 1, 1, 0, 0, 0, NULL),
(9, 152, 1, 0, 1, 0, 0, 1, NULL),
(9, 155, 1, 1, 0, 0, 1, 0, NULL),
(9, 160, 1, 0, 1, 0, 1, 1, NULL),
(9, 165, 1, 1, 0, 1, 1, 0, NULL),
(9, 167, 1, 0, 0, 1, 1, 0, NULL),
(9, 168, 1, 0, 1, 0, 0, 1, NULL),
(9, 170, 0, 1, 1, 1, 0, 0, NULL),
(9, 171, 0, 1, 1, 0, 0, 1, NULL),
(9, 174, 0, 1, 1, 0, 1, 0, NULL),
(9, 179, 0, 1, 0, 0, 1, 0, NULL),
(9, 180, 0, 0, 1, 1, 0, 0, NULL),
(9, 182, 0, 0, 1, 1, 0, 0, NULL),
(9, 185, 0, 1, 1, 1, 1, 1, NULL),
(9, 186, 1, 0, 0, 0, 0, 1, NULL),
(9, 187, 1, 0, 0, 0, 0, 0, NULL),
(9, 188, 0, 1, 1, 1, 0, 1, NULL),
(9, 189, 1, 0, 0, 1, 0, 1, NULL),
(9, 200, 0, 0, 0, 1, 0, 0, NULL),
(9, 201, 1, 1, 1, 1, 0, 0, NULL),
(9, 208, 1, 1, 0, 1, 1, 0, NULL),
(9, 209, 1, 1, 0, 1, 1, 1, NULL),
(9, 217, 0, 1, 0, 0, 0, 1, NULL),
(9, 224, 0, 1, 0, 1, 1, 1, NULL),
(9, 225, 1, 0, 1, 0, 0, 0, NULL),
(9, 226, 1, 0, 1, 0, 1, 1, NULL),
(9, 228, 0, 1, 0, 1, 1, 0, NULL),
(9, 229, 0, 1, 0, 0, 1, 0, NULL),
(9, 230, 0, 1, 0, 1, 0, 1, NULL),
(9, 232, 0, 1, 0, 1, 0, 1, NULL),
(9, 234, 0, 0, 1, 0, 0, 1, NULL),
(9, 235, 0, 1, 0, 1, 0, 0, NULL),
(9, 240, 0, 0, 0, 0, 0, 0, NULL),
(9, 242, 1, 1, 1, 1, 0, 1, NULL),
(9, 252, 1, 1, 0, 1, 1, 1, NULL),
(9, 255, 0, 1, 0, 1, 1, 1, NULL),
(9, 256, 1, 1, 0, 1, 1, 1, NULL),
(9, 261, 0, 0, 0, 1, 0, 0, NULL),
(9, 262, 1, 1, 0, 0, 1, 0, NULL),
(9, 265, 1, 1, 0, 0, 0, 1, NULL),
(10, 5, 1, 0, 0, 1, 0, 0, NULL),
(10, 8, 0, 1, 0, 1, 1, 0, NULL),
(10, 16, 0, 1, 1, 0, 0, 0, NULL),
(10, 22, 1, 1, 1, 0, 0, 1, NULL),
(10, 36, 0, 1, 1, 1, 0, 0, NULL),
(10, 40, 1, 0, 1, 0, 1, 1, NULL),
(10, 41, 1, 1, 0, 0, 0, 1, NULL),
(10, 52, 0, 0, 1, 1, 0, 0, NULL),
(10, 55, 1, 1, 1, 1, 1, 0, NULL),
(10, 56, 1, 1, 0, 0, 1, 1, NULL),
(10, 58, 1, 0, 1, 0, 1, 0, NULL),
(10, 59, 0, 1, 0, 1, 1, 0, NULL),
(10, 60, 1, 0, 1, 0, 1, 0, NULL),
(10, 62, 0, 0, 0, 1, 1, 1, NULL),
(10, 69, 0, 1, 1, 0, 1, 1, NULL),
(10, 70, 1, 0, 1, 1, 1, 1, NULL),
(10, 72, 0, 1, 1, 1, 1, 1, NULL),
(10, 74, 0, 0, 1, 1, 0, 0, NULL),
(10, 82, 0, 1, 1, 0, 0, 1, NULL),
(10, 89, 0, 1, 1, 0, 0, 0, NULL),
(10, 91, 1, 1, 0, 0, 1, 1, NULL),
(10, 94, 1, 0, 0, 1, 1, 0, NULL),
(10, 96, 0, 1, 1, 1, 1, 0, NULL),
(10, 101, 0, 0, 1, 0, 0, 1, NULL),
(10, 102, 1, 0, 1, 0, 0, 1, NULL),
(10, 103, 1, 1, 0, 0, 0, 1, NULL),
(10, 104, 0, 0, 0, 0, 1, 1, NULL),
(10, 105, 0, 1, 0, 1, 1, 0, NULL),
(10, 106, 1, 1, 0, 0, 0, 0, NULL),
(10, 111, 1, 0, 0, 1, 0, 1, NULL),
(10, 112, 0, 1, 0, 0, 1, 1, NULL),
(10, 115, 0, 1, 1, 1, 1, 0, NULL),
(10, 118, 0, 1, 1, 0, 1, 1, NULL),
(10, 119, 0, 0, 0, 0, 0, 1, NULL),
(10, 120, 0, 1, 0, 1, 0, 1, NULL),
(10, 123, 0, 1, 1, 1, 0, 1, NULL),
(10, 124, 1, 0, 1, 1, 1, 0, NULL),
(10, 125, 0, 0, 0, 0, 1, 0, NULL),
(10, 131, 0, 1, 1, 0, 1, 1, NULL),
(10, 137, 1, 0, 0, 0, 0, 0, NULL),
(10, 142, 0, 1, 1, 0, 0, 0, NULL),
(10, 143, 1, 1, 0, 0, 0, 0, NULL),
(10, 147, 1, 1, 0, 0, 1, 1, NULL),
(10, 150, 0, 1, 1, 0, 0, 0, NULL),
(10, 154, 1, 0, 1, 1, 0, 1, NULL),
(10, 160, 1, 0, 0, 0, 1, 1, NULL),
(10, 166, 1, 0, 0, 1, 1, 1, NULL),
(10, 168, 0, 0, 1, 1, 1, 1, NULL),
(10, 171, 0, 1, 1, 1, 1, 1, NULL),
(10, 172, 0, 1, 0, 0, 0, 0, NULL),
(10, 176, 0, 0, 0, 0, 1, 0, NULL),
(10, 179, 1, 0, 1, 0, 1, 0, NULL),
(10, 181, 0, 0, 0, 1, 0, 1, NULL),
(10, 182, 1, 0, 1, 0, 0, 0, NULL),
(10, 183, 0, 1, 0, 1, 0, 0, NULL),
(10, 184, 1, 0, 0, 0, 1, 1, NULL),
(10, 188, 0, 1, 1, 1, 1, 1, NULL),
(10, 189, 1, 0, 1, 1, 1, 1, NULL),
(10, 190, 1, 0, 0, 0, 1, 1, NULL),
(10, 192, 0, 0, 1, 0, 0, 1, NULL),
(10, 193, 0, 0, 0, 0, 1, 0, NULL),
(10, 202, 0, 0, 1, 0, 0, 0, NULL),
(10, 207, 1, 1, 1, 0, 1, 1, NULL),
(10, 208, 1, 0, 0, 0, 0, 1, NULL),
(10, 213, 0, 1, 1, 1, 1, 0, NULL),
(10, 217, 1, 0, 0, 1, 1, 0, NULL),
(10, 234, 1, 1, 1, 1, 0, 1, NULL),
(10, 235, 0, 0, 1, 1, 0, 1, NULL),
(10, 237, 0, 1, 0, 1, 1, 1, NULL),
(10, 239, 0, 1, 1, 1, 0, 0, NULL),
(10, 252, 0, 0, 0, 1, 0, 0, NULL),
(10, 257, 0, 0, 0, 0, 0, 1, NULL),
(10, 262, 1, 1, 1, 1, 1, 1, NULL),
(10, 265, 1, 0, 1, 0, 1, 1, NULL),
(10, 266, 0, 0, 0, 0, 1, 1, NULL),
(10, 267, 1, 0, 1, 1, 1, 1, NULL),
(11, 4, 1, 1, 1, 1, 0, 1, NULL),
(11, 6, 0, 0, 1, 1, 1, 1, NULL),
(11, 15, 1, 0, 1, 1, 0, 0, NULL),
(11, 17, 0, 0, 0, 1, 0, 0, NULL),
(11, 24, 1, 0, 1, 0, 0, 1, NULL),
(11, 35, 0, 1, 1, 1, 1, 0, NULL),
(11, 36, 0, 1, 0, 0, 0, 0, NULL),
(11, 39, 0, 1, 1, 0, 1, 1, NULL),
(11, 54, 0, 1, 0, 0, 1, 1, NULL),
(11, 61, 1, 0, 1, 1, 0, 1, NULL),
(11, 72, 1, 1, 0, 1, 1, 0, NULL),
(11, 73, 0, 1, 1, 1, 0, 1, NULL),
(11, 74, 0, 0, 1, 1, 1, 0, NULL),
(11, 86, 0, 0, 1, 1, 1, 0, NULL),
(11, 89, 1, 1, 0, 1, 0, 0, NULL),
(11, 93, 0, 1, 0, 1, 0, 1, NULL),
(11, 94, 0, 0, 1, 0, 1, 0, NULL),
(11, 95, 1, 0, 1, 1, 0, 0, NULL),
(11, 104, 1, 0, 0, 1, 0, 1, NULL),
(11, 106, 1, 0, 0, 1, 1, 0, NULL),
(11, 109, 1, 0, 1, 0, 1, 0, NULL),
(11, 119, 0, 0, 0, 1, 1, 0, NULL),
(11, 120, 1, 1, 1, 0, 1, 1, NULL),
(11, 123, 1, 0, 0, 0, 1, 0, NULL),
(11, 124, 0, 0, 1, 0, 0, 1, NULL),
(11, 125, 1, 1, 1, 0, 0, 1, NULL),
(11, 127, 1, 0, 0, 1, 0, 1, NULL),
(11, 129, 1, 0, 0, 0, 0, 1, NULL),
(11, 143, 0, 0, 1, 1, 1, 0, NULL),
(11, 145, 1, 0, 1, 0, 0, 1, NULL),
(11, 146, 0, 1, 0, 0, 1, 0, NULL),
(11, 147, 0, 1, 0, 0, 1, 1, NULL),
(11, 148, 0, 1, 1, 0, 1, 1, NULL),
(11, 152, 1, 1, 1, 0, 1, 1, NULL),
(11, 153, 0, 1, 1, 1, 0, 1, NULL),
(11, 154, 1, 1, 1, 1, 0, 1, NULL),
(11, 155, 1, 0, 0, 1, 0, 0, NULL),
(11, 157, 1, 0, 1, 0, 1, 1, NULL),
(11, 159, 1, 1, 1, 1, 0, 1, NULL),
(11, 163, 1, 0, 0, 0, 0, 0, NULL),
(11, 169, 1, 1, 1, 0, 0, 0, NULL),
(11, 170, 0, 1, 1, 1, 0, 1, NULL),
(11, 171, 1, 0, 0, 0, 0, 0, NULL),
(11, 172, 1, 0, 1, 0, 1, 1, NULL),
(11, 173, 1, 0, 1, 1, 0, 1, NULL),
(11, 174, 0, 0, 1, 1, 0, 0, NULL),
(11, 180, 1, 1, 0, 0, 1, 0, NULL),
(11, 184, 0, 0, 1, 1, 1, 1, NULL),
(11, 186, 1, 0, 0, 1, 1, 0, NULL),
(11, 188, 0, 1, 1, 1, 0, 1, NULL),
(11, 190, 0, 0, 0, 1, 0, 0, NULL),
(11, 194, 1, 1, 0, 1, 0, 0, NULL),
(11, 195, 0, 1, 1, 1, 1, 0, NULL),
(11, 196, 0, 0, 0, 1, 0, 0, NULL),
(11, 201, 1, 0, 0, 1, 1, 1, NULL),
(11, 204, 0, 1, 1, 1, 0, 0, NULL),
(11, 208, 1, 0, 1, 1, 0, 0, NULL),
(11, 209, 1, 0, 1, 1, 1, 1, NULL),
(11, 210, 1, 1, 0, 1, 1, 1, NULL),
(11, 215, 0, 0, 0, 1, 0, 0, NULL),
(11, 218, 0, 0, 1, 1, 0, 0, NULL),
(11, 220, 0, 1, 1, 0, 1, 1, NULL),
(11, 224, 0, 1, 0, 0, 0, 0, NULL),
(11, 233, 0, 0, 1, 1, 1, 0, NULL),
(11, 235, 0, 0, 1, 0, 1, 1, NULL),
(11, 239, 0, 0, 0, 0, 0, 0, NULL),
(11, 240, 0, 1, 0, 1, 0, 1, NULL),
(11, 246, 0, 0, 0, 0, 0, 1, NULL),
(11, 248, 1, 1, 1, 0, 1, 1, NULL),
(11, 251, 1, 1, 0, 1, 1, 0, NULL),
(11, 252, 1, 0, 1, 1, 0, 0, NULL),
(11, 256, 1, 0, 0, 0, 1, 1, NULL),
(11, 257, 1, 1, 0, 0, 1, 1, NULL),
(11, 264, 1, 1, 1, 1, 0, 1, NULL),
(11, 265, 0, 0, 1, 1, 1, 0, NULL),
(12, 4, 0, 0, 0, 0, 0, 1, NULL),
(12, 5, 0, 0, 0, 1, 0, 1, NULL),
(12, 11, 0, 1, 0, 0, 1, 1, NULL),
(12, 21, 0, 0, 0, 0, 0, 0, NULL),
(12, 24, 0, 1, 0, 1, 1, 1, NULL),
(12, 36, 0, 0, 1, 0, 1, 1, NULL),
(12, 41, 0, 1, 1, 1, 1, 1, NULL),
(12, 47, 0, 0, 0, 1, 1, 1, NULL),
(12, 55, 1, 1, 0, 0, 0, 1, NULL),
(12, 56, 1, 0, 1, 1, 1, 1, NULL),
(12, 60, 0, 0, 0, 0, 1, 1, NULL),
(12, 69, 0, 0, 0, 0, 0, 1, NULL),
(12, 71, 1, 1, 1, 0, 0, 0, NULL),
(12, 73, 0, 1, 1, 0, 0, 0, NULL),
(12, 77, 1, 0, 0, 1, 1, 0, NULL),
(12, 78, 1, 1, 1, 0, 1, 1, NULL),
(12, 81, 0, 0, 0, 0, 0, 1, NULL),
(12, 87, 0, 1, 1, 0, 1, 0, NULL),
(12, 93, 0, 0, 1, 0, 0, 0, NULL),
(12, 94, 1, 1, 0, 0, 0, 1, NULL),
(12, 98, 0, 1, 0, 0, 1, 1, NULL),
(12, 105, 1, 1, 0, 1, 1, 0, NULL),
(12, 111, 1, 1, 0, 0, 0, 1, NULL),
(12, 119, 1, 1, 0, 1, 1, 0, NULL),
(12, 122, 1, 0, 0, 1, 0, 1, NULL),
(12, 123, 1, 1, 1, 0, 1, 0, NULL),
(12, 124, 1, 0, 0, 1, 1, 0, NULL),
(12, 131, 0, 0, 0, 1, 0, 1, NULL),
(12, 132, 0, 0, 0, 0, 0, 1, NULL),
(12, 135, 1, 1, 0, 1, 1, 1, NULL),
(12, 137, 0, 0, 0, 0, 1, 1, NULL),
(12, 144, 1, 1, 0, 1, 1, 1, NULL),
(12, 148, 0, 1, 1, 0, 0, 1, NULL),
(12, 152, 0, 0, 1, 1, 0, 1, NULL),
(12, 156, 1, 1, 0, 0, 0, 0, NULL),
(12, 159, 1, 0, 1, 0, 1, 0, NULL),
(12, 161, 1, 1, 1, 1, 1, 1, NULL),
(12, 162, 0, 1, 0, 1, 1, 1, NULL),
(12, 164, 0, 1, 1, 0, 1, 0, NULL),
(12, 168, 1, 0, 0, 0, 1, 1, NULL),
(12, 170, 0, 0, 0, 0, 1, 0, NULL),
(12, 172, 1, 1, 1, 0, 0, 1, NULL),
(12, 178, 1, 1, 0, 0, 1, 0, NULL),
(12, 179, 1, 1, 0, 1, 0, 1, NULL),
(12, 184, 1, 0, 0, 0, 1, 0, NULL),
(12, 185, 1, 1, 0, 0, 0, 1, NULL),
(12, 190, 0, 1, 0, 0, 0, 0, NULL),
(12, 191, 0, 0, 1, 1, 1, 0, NULL),
(12, 195, 0, 1, 0, 1, 1, 1, NULL),
(12, 198, 1, 1, 0, 0, 1, 1, NULL),
(12, 206, 0, 1, 0, 0, 1, 1, NULL),
(12, 208, 1, 0, 1, 1, 1, 0, NULL),
(12, 210, 0, 1, 1, 0, 0, 0, NULL),
(12, 213, 0, 0, 0, 0, 1, 1, NULL),
(12, 215, 0, 0, 1, 1, 0, 0, NULL),
(12, 217, 0, 0, 0, 1, 1, 1, NULL),
(12, 218, 0, 1, 0, 0, 1, 1, NULL),
(12, 219, 0, 1, 0, 1, 1, 1, NULL),
(12, 221, 1, 0, 0, 1, 0, 0, NULL),
(12, 222, 0, 0, 0, 1, 0, 0, NULL),
(12, 224, 0, 1, 0, 1, 0, 1, NULL),
(12, 226, 0, 1, 1, 1, 1, 0, NULL),
(12, 228, 1, 0, 1, 0, 1, 1, NULL),
(12, 232, 1, 0, 0, 1, 1, 1, NULL),
(12, 245, 1, 0, 1, 1, 0, 1, NULL),
(12, 247, 0, 1, 0, 0, 0, 0, NULL),
(12, 253, 1, 1, 0, 1, 0, 1, NULL),
(12, 256, 1, 0, 1, 1, 0, 0, NULL),
(12, 257, 1, 1, 1, 1, 1, 0, NULL),
(12, 258, 0, 0, 0, 1, 0, 0, NULL),
(12, 261, 1, 1, 1, 1, 0, 0, NULL),
(12, 264, 0, 1, 0, 1, 1, 0, NULL),
(13, 12, 1, 1, 0, 1, 0, 0, NULL),
(13, 24, 1, 1, 0, 1, 0, 1, NULL),
(13, 29, 0, 1, 1, 0, 0, 1, NULL),
(13, 33, 1, 0, 1, 0, 1, 0, NULL),
(13, 35, 0, 1, 1, 0, 1, 1, NULL),
(13, 39, 1, 1, 1, 0, 0, 0, NULL),
(13, 41, 1, 0, 1, 1, 1, 1, NULL),
(13, 45, 0, 0, 0, 1, 0, 1, NULL),
(13, 46, 1, 0, 1, 1, 1, 1, NULL),
(13, 51, 0, 0, 1, 0, 1, 1, NULL),
(13, 52, 1, 1, 1, 1, 0, 0, NULL),
(13, 54, 1, 1, 1, 1, 0, 1, NULL),
(13, 61, 1, 1, 0, 1, 1, 1, NULL),
(13, 63, 1, 1, 0, 0, 0, 1, NULL),
(13, 65, 0, 0, 1, 0, 1, 0, NULL),
(13, 69, 0, 0, 0, 1, 1, 1, NULL),
(13, 70, 0, 0, 0, 1, 0, 1, NULL),
(13, 71, 0, 1, 0, 0, 0, 1, NULL),
(13, 81, 1, 1, 1, 1, 1, 0, NULL),
(13, 88, 1, 0, 1, 1, 1, 1, NULL),
(13, 91, 1, 1, 0, 1, 0, 0, NULL),
(13, 92, 0, 1, 0, 1, 0, 1, NULL),
(13, 93, 0, 1, 0, 0, 1, 0, NULL),
(13, 95, 1, 0, 0, 0, 1, 0, NULL),
(13, 98, 1, 1, 0, 0, 0, 1, NULL),
(13, 99, 0, 1, 1, 0, 0, 0, NULL),
(13, 100, 1, 0, 0, 0, 0, 0, NULL),
(13, 103, 1, 1, 1, 1, 0, 0, NULL),
(13, 104, 1, 1, 1, 1, 1, 0, NULL),
(13, 106, 1, 1, 1, 0, 1, 0, NULL),
(13, 110, 0, 1, 0, 0, 1, 1, NULL),
(13, 114, 0, 1, 1, 1, 1, 0, NULL),
(13, 116, 1, 1, 1, 1, 1, 1, NULL),
(13, 119, 0, 0, 0, 1, 1, 0, NULL),
(13, 121, 0, 1, 0, 1, 1, 0, NULL),
(13, 124, 1, 1, 0, 0, 0, 0, NULL),
(13, 125, 0, 1, 1, 1, 0, 0, NULL),
(13, 127, 0, 0, 1, 0, 1, 1, NULL),
(13, 129, 1, 0, 1, 0, 1, 0, NULL),
(13, 131, 1, 0, 0, 0, 0, 0, NULL),
(13, 134, 1, 1, 1, 0, 1, 1, NULL),
(13, 135, 0, 1, 1, 0, 0, 1, NULL),
(13, 138, 0, 0, 1, 1, 1, 0, NULL),
(13, 140, 0, 0, 1, 1, 1, 1, NULL),
(13, 141, 0, 0, 1, 0, 1, 0, NULL),
(13, 142, 1, 0, 1, 1, 1, 1, NULL),
(13, 146, 1, 0, 0, 1, 1, 1, NULL),
(13, 148, 1, 0, 1, 1, 0, 0, NULL),
(13, 150, 1, 0, 0, 1, 0, 1, NULL),
(13, 152, 0, 0, 0, 1, 0, 0, NULL),
(13, 155, 1, 1, 1, 1, 1, 1, NULL),
(13, 157, 0, 0, 1, 0, 1, 1, NULL),
(13, 159, 1, 0, 0, 0, 0, 1, NULL),
(13, 163, 0, 0, 1, 1, 1, 1, NULL),
(13, 164, 1, 1, 1, 1, 1, 0, NULL),
(13, 166, 1, 0, 1, 1, 0, 0, NULL),
(13, 167, 0, 0, 1, 0, 1, 0, NULL),
(13, 177, 1, 0, 0, 0, 1, 0, NULL),
(13, 178, 1, 1, 0, 0, 0, 0, NULL),
(13, 184, 1, 1, 0, 1, 1, 1, NULL),
(13, 185, 1, 0, 1, 0, 1, 0, NULL),
(13, 190, 0, 0, 1, 0, 0, 1, NULL),
(13, 201, 1, 1, 1, 0, 1, 0, NULL),
(13, 204, 0, 1, 0, 1, 1, 1, NULL),
(13, 205, 0, 1, 0, 0, 1, 1, NULL),
(13, 207, 0, 0, 1, 0, 1, 0, NULL),
(13, 210, 0, 1, 1, 0, 1, 0, NULL),
(13, 213, 0, 1, 0, 0, 1, 1, NULL),
(13, 216, 1, 0, 0, 0, 1, 1, NULL),
(13, 217, 1, 0, 0, 1, 1, 1, NULL),
(13, 218, 1, 1, 1, 1, 1, 1, NULL),
(13, 220, 1, 1, 0, 0, 1, 0, NULL),
(13, 224, 0, 1, 0, 0, 1, 1, NULL),
(13, 230, 1, 0, 0, 0, 1, 0, NULL),
(13, 236, 1, 1, 0, 1, 0, 1, NULL),
(13, 239, 1, 0, 0, 0, 1, 1, NULL),
(13, 240, 0, 0, 1, 0, 0, 1, NULL),
(13, 242, 0, 1, 0, 0, 0, 1, NULL),
(13, 245, 1, 0, 1, 1, 0, 0, NULL),
(13, 247, 0, 1, 0, 1, 0, 0, NULL),
(13, 248, 0, 1, 1, 0, 0, 1, NULL),
(13, 251, 1, 0, 0, 0, 0, 1, NULL),
(13, 255, 1, 0, 1, 0, 1, 0, NULL),
(13, 257, 0, 0, 0, 0, 0, 0, NULL),
(13, 258, 0, 1, 1, 0, 0, 0, NULL),
(13, 262, 1, 0, 1, 0, 0, 0, NULL),
(13, 267, 1, 0, 0, 1, 0, 0, NULL),
(13, 269, 0, 1, 0, 1, 1, 1, NULL),
(14, 5, 1, 1, 1, 0, 0, 1, NULL),
(14, 8, 0, 0, 1, 0, 1, 0, NULL),
(14, 12, 0, 0, 1, 0, 0, 1, NULL),
(14, 17, 1, 1, 1, 1, 0, 0, NULL),
(14, 29, 1, 1, 1, 1, 1, 1, NULL),
(14, 32, 0, 1, 0, 1, 1, 0, NULL),
(14, 33, 1, 0, 0, 1, 0, 1, NULL),
(14, 34, 0, 1, 1, 1, 1, 0, NULL),
(14, 36, 1, 0, 1, 0, 1, 1, NULL),
(14, 41, 0, 0, 1, 1, 1, 0, NULL),
(14, 43, 0, 1, 1, 0, 0, 0, NULL),
(14, 46, 0, 1, 0, 1, 1, 0, NULL),
(14, 51, 1, 0, 1, 0, 0, 1, NULL),
(14, 52, 0, 0, 0, 0, 1, 0, NULL),
(14, 54, 0, 0, 1, 1, 0, 0, NULL),
(14, 60, 1, 0, 1, 1, 1, 0, NULL),
(14, 71, 1, 1, 1, 0, 1, 0, NULL),
(14, 72, 0, 1, 1, 1, 1, 0, NULL),
(14, 76, 0, 0, 0, 0, 0, 1, NULL),
(14, 81, 0, 0, 1, 1, 1, 1, NULL),
(14, 83, 1, 1, 1, 1, 1, 1, NULL),
(14, 87, 1, 0, 1, 1, 1, 1, NULL),
(14, 93, 0, 1, 0, 1, 1, 1, NULL),
(14, 94, 0, 0, 0, 0, 1, 0, NULL),
(14, 96, 0, 1, 0, 0, 1, 1, NULL),
(14, 99, 1, 1, 1, 0, 1, 0, NULL),
(14, 101, 0, 0, 1, 0, 0, 0, NULL),
(14, 105, 0, 1, 1, 1, 0, 1, NULL),
(14, 106, 1, 0, 0, 0, 1, 0, NULL),
(14, 109, 1, 0, 0, 0, 0, 0, NULL),
(14, 110, 0, 0, 0, 0, 0, 0, NULL),
(14, 111, 0, 1, 1, 1, 0, 0, NULL),
(14, 114, 0, 0, 0, 0, 0, 1, NULL),
(14, 115, 1, 1, 0, 1, 0, 1, NULL),
(14, 120, 0, 0, 0, 1, 1, 1, NULL),
(14, 124, 1, 1, 1, 0, 1, 1, NULL),
(14, 125, 0, 1, 1, 1, 1, 0, NULL),
(14, 127, 0, 0, 0, 0, 1, 1, NULL),
(14, 129, 0, 1, 1, 0, 0, 1, NULL),
(14, 131, 1, 0, 1, 0, 1, 1, NULL),
(14, 132, 0, 0, 0, 1, 0, 1, NULL),
(14, 135, 0, 1, 0, 1, 1, 0, NULL),
(14, 137, 1, 0, 0, 1, 1, 1, NULL),
(14, 141, 1, 1, 0, 0, 0, 0, NULL),
(14, 142, 1, 1, 0, 0, 1, 0, NULL),
(14, 144, 1, 0, 0, 1, 1, 0, NULL),
(14, 148, 0, 1, 1, 0, 0, 0, NULL),
(14, 151, 0, 0, 0, 1, 0, 0, NULL),
(14, 153, 0, 0, 0, 1, 0, 1, NULL),
(14, 155, 1, 0, 1, 0, 1, 0, NULL),
(14, 156, 1, 0, 1, 1, 0, 0, NULL),
(14, 158, 1, 1, 1, 1, 0, 1, NULL),
(14, 159, 1, 0, 0, 1, 0, 1, NULL),
(14, 160, 0, 1, 0, 0, 0, 0, NULL),
(14, 164, 0, 0, 0, 1, 1, 0, NULL),
(14, 170, 1, 0, 0, 1, 1, 0, NULL),
(14, 171, 0, 0, 1, 0, 0, 0, NULL),
(14, 174, 1, 0, 1, 1, 0, 1, NULL),
(14, 178, 0, 0, 1, 1, 0, 1, NULL),
(14, 188, 0, 0, 0, 1, 1, 1, NULL),
(14, 189, 0, 1, 1, 0, 0, 0, NULL),
(14, 194, 0, 0, 0, 1, 0, 0, NULL),
(14, 196, 1, 1, 1, 0, 1, 1, NULL),
(14, 200, 1, 0, 1, 1, 0, 0, NULL),
(14, 201, 0, 1, 1, 0, 1, 1, NULL),
(14, 204, 1, 0, 1, 0, 0, 1, NULL),
(14, 213, 1, 0, 0, 0, 1, 1, NULL),
(14, 221, 1, 0, 1, 1, 0, 1, NULL),
(14, 226, 0, 0, 0, 1, 0, 0, NULL),
(14, 228, 0, 1, 1, 1, 0, 1, NULL),
(14, 234, 1, 0, 0, 1, 0, 0, NULL),
(14, 252, 0, 1, 0, 1, 0, 1, NULL),
(14, 255, 0, 1, 1, 1, 1, 0, NULL),
(14, 261, 0, 0, 1, 1, 1, 0, NULL),
(14, 262, 1, 0, 1, 0, 1, 1, NULL),
(14, 269, 1, 0, 1, 1, 0, 1, NULL),
(15, 4, 1, 0, 0, 0, 1, 1, NULL),
(15, 8, 0, 0, 1, 1, 1, 0, NULL),
(15, 24, 1, 1, 1, 1, 1, 1, NULL),
(15, 30, 0, 0, 0, 1, 0, 1, NULL),
(15, 34, 0, 0, 0, 0, 0, 1, NULL),
(15, 35, 1, 0, 0, 0, 1, 0, NULL),
(15, 36, 1, 0, 1, 1, 1, 1, NULL),
(15, 51, 1, 1, 0, 1, 1, 1, NULL),
(15, 55, 0, 0, 1, 1, 1, 1, NULL),
(15, 59, 1, 0, 1, 1, 0, 1, NULL),
(15, 60, 1, 0, 0, 0, 1, 0, NULL),
(15, 61, 0, 0, 1, 1, 1, 1, NULL),
(15, 72, 0, 1, 1, 1, 1, 1, NULL),
(15, 73, 0, 1, 0, 1, 1, 0, NULL),
(15, 76, 1, 1, 1, 0, 0, 1, NULL),
(15, 77, 1, 1, 0, 1, 1, 0, NULL),
(15, 81, 0, 0, 1, 1, 0, 0, NULL),
(15, 82, 0, 0, 1, 1, 0, 0, NULL),
(15, 83, 1, 1, 1, 1, 1, 0, NULL),
(15, 85, 1, 1, 1, 0, 0, 0, NULL),
(15, 86, 0, 1, 0, 1, 0, 1, NULL),
(15, 87, 0, 0, 0, 1, 1, 0, NULL),
(15, 88, 1, 0, 1, 0, 0, 1, NULL),
(15, 91, 1, 1, 0, 0, 1, 0, NULL),
(15, 92, 0, 0, 1, 1, 1, 0, NULL),
(15, 93, 1, 0, 0, 0, 1, 0, NULL),
(15, 94, 0, 0, 1, 0, 1, 0, NULL),
(15, 96, 0, 1, 0, 1, 1, 1, NULL),
(15, 99, 0, 0, 1, 0, 0, 1, NULL),
(15, 103, 0, 0, 0, 0, 0, 0, NULL),
(15, 106, 0, 1, 0, 1, 1, 1, NULL),
(15, 111, 0, 0, 0, 0, 0, 0, NULL),
(15, 116, 1, 0, 0, 1, 1, 0, NULL),
(15, 119, 0, 1, 0, 0, 0, 0, NULL),
(15, 123, 1, 1, 1, 0, 1, 0, NULL),
(15, 124, 1, 0, 1, 1, 0, 1, NULL),
(15, 125, 1, 0, 0, 0, 1, 1, NULL),
(15, 127, 0, 1, 0, 1, 1, 0, NULL),
(15, 133, 1, 1, 0, 1, 1, 1, NULL),
(15, 135, 1, 0, 1, 1, 0, 1, NULL),
(15, 136, 1, 1, 1, 0, 0, 0, NULL),
(15, 144, 0, 1, 1, 1, 1, 1, NULL),
(15, 152, 1, 0, 0, 0, 1, 0, NULL),
(15, 154, 0, 0, 0, 1, 1, 1, NULL),
(15, 155, 0, 0, 0, 1, 0, 1, NULL),
(15, 159, 0, 0, 0, 0, 1, 0, NULL),
(15, 160, 0, 0, 1, 1, 1, 1, NULL),
(15, 163, 0, 0, 0, 0, 1, 1, NULL),
(15, 168, 0, 1, 1, 0, 0, 1, NULL),
(15, 169, 1, 1, 0, 0, 1, 1, NULL),
(15, 171, 1, 1, 1, 1, 0, 1, NULL),
(15, 172, 0, 1, 1, 1, 1, 0, NULL),
(15, 174, 0, 0, 1, 1, 1, 0, NULL),
(15, 179, 0, 0, 0, 1, 1, 0, NULL),
(15, 182, 0, 1, 1, 0, 0, 0, NULL),
(15, 183, 1, 1, 0, 0, 0, 0, NULL),
(15, 190, 0, 0, 1, 1, 0, 1, NULL),
(15, 191, 1, 0, 1, 0, 1, 0, NULL),
(15, 196, 0, 1, 0, 1, 1, 0, NULL),
(15, 200, 1, 0, 1, 0, 0, 1, NULL),
(15, 201, 1, 1, 1, 1, 1, 1, NULL),
(15, 204, 1, 0, 1, 0, 1, 0, NULL),
(15, 206, 1, 0, 0, 0, 1, 0, NULL),
(15, 207, 1, 1, 0, 1, 1, 1, NULL),
(15, 209, 1, 0, 1, 0, 1, 1, NULL),
(15, 210, 0, 1, 0, 1, 1, 1, NULL),
(15, 213, 0, 1, 1, 0, 0, 0, NULL),
(15, 216, 1, 1, 0, 1, 0, 1, NULL),
(15, 217, 1, 1, 0, 1, 1, 1, NULL),
(15, 218, 0, 1, 1, 1, 0, 0, NULL),
(15, 221, 0, 1, 0, 1, 1, 1, NULL),
(15, 227, 0, 0, 0, 1, 1, 0, NULL),
(15, 230, 0, 1, 1, 1, 1, 1, NULL),
(15, 243, 1, 1, 1, 0, 1, 1, NULL),
(15, 245, 1, 0, 1, 0, 0, 1, NULL),
(15, 246, 1, 0, 1, 0, 1, 0, NULL),
(15, 249, 1, 0, 0, 0, 0, 1, NULL),
(15, 255, 1, 0, 1, 1, 0, 1, NULL),
(15, 256, 1, 0, 0, 1, 1, 1, NULL),
(15, 257, 1, 1, 1, 1, 1, 0, NULL),
(15, 261, 1, 0, 0, 1, 1, 1, NULL),
(15, 262, 1, 1, 0, 1, 1, 1, NULL),
(15, 264, 0, 0, 0, 1, 1, 0, NULL),
(15, 267, 1, 1, 1, 1, 0, 0, NULL),
(16, 6, 0, 1, 0, 0, 0, 0, NULL),
(16, 10, 0, 0, 0, 1, 0, 0, NULL),
(16, 12, 0, 0, 0, 0, 0, 0, NULL),
(16, 19, 0, 0, 0, 1, 1, 1, NULL),
(16, 22, 1, 1, 0, 1, 1, 0, NULL),
(16, 41, 0, 0, 0, 1, 1, 0, NULL),
(16, 45, 0, 1, 1, 0, 1, 0, NULL),
(16, 57, 1, 0, 0, 1, 1, 1, NULL),
(16, 59, 0, 1, 0, 0, 0, 0, NULL),
(16, 63, 0, 0, 1, 1, 0, 1, NULL),
(16, 69, 0, 1, 1, 0, 1, 1, NULL),
(16, 71, 0, 1, 1, 1, 1, 1, NULL),
(16, 72, 1, 0, 1, 0, 1, 1, NULL),
(16, 73, 1, 0, 1, 0, 0, 1, NULL),
(16, 76, 0, 1, 0, 1, 1, 0, NULL),
(16, 82, 0, 0, 0, 0, 0, 0, NULL),
(16, 83, 0, 0, 0, 0, 0, 0, NULL),
(16, 84, 0, 1, 1, 0, 0, 1, NULL),
(16, 85, 1, 1, 0, 1, 0, 0, NULL),
(16, 86, 1, 1, 1, 1, 0, 0, NULL),
(16, 89, 0, 0, 0, 0, 1, 1, NULL),
(16, 91, 0, 1, 1, 1, 1, 0, NULL),
(16, 92, 1, 1, 1, 1, 0, 0, NULL),
(16, 98, 0, 1, 0, 1, 0, 1, NULL),
(16, 105, 1, 1, 1, 1, 1, 0, NULL),
(16, 123, 1, 1, 0, 0, 0, 1, NULL),
(16, 131, 1, 1, 1, 0, 1, 1, NULL),
(16, 134, 1, 1, 0, 0, 1, 0, NULL),
(16, 135, 1, 0, 1, 0, 1, 0, NULL),
(16, 142, 0, 0, 1, 1, 0, 1, NULL),
(16, 143, 0, 1, 1, 1, 1, 1, NULL),
(16, 148, 0, 1, 1, 0, 1, 0, NULL),
(16, 150, 0, 0, 0, 1, 1, 1, NULL),
(16, 152, 0, 1, 1, 1, 0, 1, NULL),
(16, 155, 0, 1, 0, 0, 1, 1, NULL),
(16, 162, 0, 0, 1, 1, 0, 1, NULL),
(16, 165, 1, 0, 1, 1, 0, 0, NULL),
(16, 168, 1, 1, 0, 0, 1, 1, NULL),
(16, 174, 1, 1, 1, 1, 1, 1, NULL),
(16, 180, 0, 0, 0, 1, 1, 1, NULL),
(16, 181, 0, 1, 1, 0, 0, 0, NULL),
(16, 182, 0, 1, 1, 1, 1, 1, NULL),
(16, 183, 1, 1, 0, 1, 0, 1, NULL),
(16, 188, 1, 1, 1, 0, 0, 1, NULL),
(16, 190, 0, 1, 0, 1, 1, 1, NULL),
(16, 191, 1, 0, 1, 1, 1, 1, NULL),
(16, 192, 0, 0, 1, 1, 0, 1, NULL),
(16, 194, 0, 1, 1, 0, 1, 0, NULL),
(16, 201, 0, 0, 0, 1, 0, 0, NULL),
(16, 204, 1, 0, 1, 1, 0, 1, NULL),
(16, 206, 0, 0, 1, 0, 1, 0, NULL),
(16, 207, 0, 0, 0, 1, 1, 1, NULL),
(16, 208, 0, 0, 0, 1, 1, 0, NULL),
(16, 209, 0, 1, 1, 1, 0, 1, NULL),
(16, 213, 1, 0, 0, 1, 0, 1, NULL),
(16, 217, 1, 0, 1, 1, 0, 1, NULL),
(16, 221, 1, 1, 0, 0, 0, 0, NULL),
(16, 225, 1, 0, 0, 1, 1, 0, NULL),
(16, 230, 0, 0, 0, 1, 0, 0, NULL),
(16, 234, 0, 1, 0, 0, 0, 0, NULL),
(16, 235, 0, 0, 1, 0, 0, 0, NULL),
(16, 239, 0, 0, 0, 1, 1, 0, NULL),
(16, 243, 0, 0, 0, 1, 0, 0, NULL),
(16, 252, 0, 0, 1, 1, 0, 1, NULL),
(16, 256, 0, 0, 1, 0, 1, 1, NULL),
(16, 257, 0, 0, 1, 0, 0, 1, NULL),
(16, 258, 1, 1, 0, 0, 0, 0, NULL),
(16, 261, 0, 1, 0, 1, 0, 0, NULL),
(17, 4, 1, 0, 0, 1, 0, 0, NULL),
(17, 5, 1, 0, 1, 0, 0, 1, NULL),
(17, 6, 1, 1, 0, 1, 1, 1, NULL),
(17, 8, 1, 0, 1, 0, 0, 0, NULL),
(17, 12, 0, 1, 0, 1, 0, 1, NULL),
(17, 14, 1, 0, 1, 0, 0, 0, NULL),
(17, 15, 1, 0, 1, 0, 1, 0, NULL),
(17, 16, 1, 1, 0, 0, 1, 0, NULL),
(17, 22, 0, 0, 0, 1, 1, 1, NULL),
(17, 24, 1, 1, 1, 0, 1, 0, NULL),
(17, 34, 1, 0, 1, 0, 1, 1, NULL),
(17, 39, 0, 0, 1, 1, 0, 0, NULL),
(17, 52, 0, 0, 0, 1, 1, 0, NULL),
(17, 53, 1, 0, 0, 1, 1, 0, NULL),
(17, 55, 0, 0, 0, 0, 1, 0, NULL),
(17, 58, 0, 0, 0, 1, 0, 0, NULL),
(17, 60, 1, 1, 1, 1, 0, 0, NULL),
(17, 73, 0, 0, 0, 0, 0, 0, NULL),
(17, 76, 1, 0, 1, 1, 1, 0, NULL),
(17, 77, 0, 0, 0, 0, 0, 1, NULL),
(17, 81, 1, 0, 0, 0, 1, 1, NULL),
(17, 82, 0, 0, 1, 0, 0, 0, NULL),
(17, 83, 0, 1, 0, 1, 0, 1, NULL),
(17, 84, 1, 0, 0, 1, 0, 0, NULL),
(17, 87, 0, 1, 0, 1, 0, 1, NULL),
(17, 93, 1, 1, 1, 1, 1, 0, NULL),
(17, 94, 0, 1, 0, 0, 1, 0, NULL),
(17, 96, 0, 0, 0, 0, 0, 1, NULL),
(17, 98, 0, 1, 0, 0, 1, 1, NULL),
(17, 111, 1, 0, 1, 0, 1, 0, NULL),
(17, 112, 0, 1, 1, 0, 1, 0, NULL),
(17, 120, 1, 0, 0, 1, 1, 1, NULL),
(17, 123, 1, 1, 1, 1, 0, 1, NULL),
(17, 127, 0, 1, 1, 1, 1, 0, NULL),
(17, 131, 1, 0, 0, 0, 1, 0, NULL),
(17, 132, 0, 0, 1, 0, 1, 0, NULL),
(17, 134, 0, 1, 0, 0, 0, 0, NULL),
(17, 135, 1, 0, 0, 1, 1, 0, NULL),
(17, 137, 1, 1, 0, 0, 0, 1, NULL),
(17, 140, 0, 0, 1, 1, 1, 0, NULL),
(17, 141, 0, 0, 1, 0, 0, 1, NULL),
(17, 143, 0, 0, 1, 1, 1, 0, NULL),
(17, 144, 1, 0, 1, 0, 1, 1, NULL),
(17, 152, 1, 1, 1, 0, 0, 1, NULL),
(17, 153, 0, 0, 1, 0, 1, 0, NULL),
(17, 154, 1, 0, 0, 1, 0, 0, NULL),
(17, 156, 1, 0, 0, 1, 0, 0, NULL),
(17, 158, 0, 0, 1, 0, 1, 0, NULL),
(17, 159, 0, 1, 1, 1, 1, 0, NULL),
(17, 160, 1, 0, 0, 1, 0, 1, NULL),
(17, 161, 0, 0, 0, 1, 1, 1, NULL),
(17, 163, 0, 1, 1, 1, 0, 0, NULL),
(17, 164, 1, 1, 1, 0, 1, 1, NULL),
(17, 169, 1, 1, 1, 0, 1, 0, NULL),
(17, 171, 1, 0, 0, 0, 0, 0, NULL),
(17, 174, 0, 0, 1, 1, 0, 0, NULL),
(17, 182, 0, 1, 0, 0, 1, 1, NULL),
(17, 184, 1, 0, 0, 1, 0, 1, NULL),
(17, 188, 0, 1, 1, 0, 0, 0, NULL),
(17, 194, 0, 0, 1, 0, 1, 0, NULL),
(17, 196, 1, 0, 1, 0, 1, 1, NULL),
(17, 198, 1, 0, 1, 0, 0, 0, NULL),
(17, 200, 0, 1, 0, 1, 0, 1, NULL),
(17, 201, 1, 0, 0, 1, 1, 1, NULL),
(17, 202, 1, 0, 0, 1, 0, 0, NULL),
(17, 204, 0, 1, 1, 1, 1, 1, NULL),
(17, 209, 1, 1, 0, 0, 1, 1, NULL),
(17, 210, 0, 1, 1, 1, 1, 0, NULL),
(17, 216, 1, 0, 1, 0, 1, 1, NULL),
(17, 217, 0, 1, 1, 1, 1, 1, NULL),
(17, 218, 1, 0, 0, 1, 0, 0, NULL),
(17, 219, 0, 1, 1, 0, 0, 0, NULL),
(17, 220, 0, 1, 0, 1, 1, 1, NULL),
(17, 224, 0, 1, 0, 0, 0, 0, NULL),
(17, 227, 0, 0, 0, 1, 0, 0, NULL),
(17, 234, 1, 0, 1, 0, 1, 0, NULL),
(17, 238, 0, 1, 0, 0, 0, 1, NULL),
(17, 241, 0, 0, 0, 0, 0, 1, NULL),
(17, 242, 1, 0, 0, 1, 0, 1, NULL),
(17, 245, 0, 0, 1, 1, 0, 1, NULL),
(17, 246, 0, 1, 1, 1, 0, 0, NULL),
(17, 248, 0, 0, 0, 1, 1, 0, NULL),
(17, 251, 1, 1, 1, 1, 1, 1, NULL),
(17, 252, 0, 1, 1, 0, 0, 1, NULL),
(17, 253, 0, 1, 1, 0, 1, 1, NULL),
(17, 255, 0, 0, 1, 1, 1, 1, NULL),
(17, 262, 1, 0, 1, 0, 1, 1, NULL),
(17, 266, 1, 0, 1, 1, 1, 0, NULL),
(17, 269, 1, 1, 1, 0, 1, 1, NULL),
(18, 4, 0, 1, 1, 0, 0, 1, NULL),
(18, 5, 0, 1, 0, 0, 1, 1, NULL),
(18, 12, 0, 1, 1, 1, 0, 0, NULL),
(18, 16, 0, 1, 1, 1, 0, 1, NULL),
(18, 24, 1, 0, 1, 1, 1, 0, NULL),
(18, 30, 1, 1, 0, 1, 0, 1, NULL),
(18, 36, 0, 1, 0, 0, 0, 1, NULL),
(18, 38, 1, 0, 1, 1, 1, 1, NULL),
(18, 39, 1, 0, 0, 0, 1, 0, NULL),
(18, 41, 1, 1, 0, 1, 1, 1, NULL),
(18, 43, 1, 1, 0, 1, 1, 1, NULL),
(18, 50, 1, 0, 1, 1, 0, 0, NULL),
(18, 52, 0, 1, 1, 0, 0, 0, NULL),
(18, 53, 0, 0, 1, 1, 0, 0, NULL),
(18, 55, 0, 1, 0, 1, 1, 1, NULL),
(18, 61, 0, 0, 0, 0, 1, 1, NULL),
(18, 64, 1, 1, 0, 0, 0, 1, NULL),
(18, 71, 1, 0, 0, 0, 1, 1, NULL),
(18, 72, 1, 1, 1, 0, 1, 1, NULL),
(18, 74, 1, 0, 1, 0, 1, 0, NULL),
(18, 80, 0, 1, 0, 1, 0, 1, NULL),
(18, 83, 0, 1, 0, 0, 0, 1, NULL),
(18, 87, 1, 1, 0, 0, 0, 0, NULL),
(18, 91, 0, 1, 0, 1, 0, 0, NULL),
(18, 96, 0, 0, 0, 0, 1, 0, NULL),
(18, 98, 0, 1, 1, 0, 1, 1, NULL),
(18, 101, 1, 0, 0, 0, 0, 0, NULL),
(18, 103, 1, 0, 1, 0, 1, 0, NULL),
(18, 104, 1, 1, 0, 1, 1, 1, NULL),
(18, 105, 0, 1, 1, 1, 0, 0, NULL),
(18, 106, 0, 0, 1, 1, 1, 1, NULL),
(18, 111, 1, 0, 0, 0, 0, 0, NULL),
(18, 114, 1, 0, 1, 0, 1, 1, NULL),
(18, 124, 0, 1, 0, 1, 0, 1, NULL),
(18, 125, 1, 1, 1, 0, 1, 0, NULL),
(18, 127, 0, 0, 0, 1, 0, 0, NULL),
(18, 129, 1, 1, 1, 1, 1, 1, NULL),
(18, 132, 0, 0, 0, 0, 1, 0, NULL),
(18, 136, 1, 1, 1, 0, 1, 0, NULL),
(18, 138, 1, 0, 0, 0, 0, 1, NULL),
(18, 143, 1, 0, 0, 1, 1, 0, NULL),
(18, 144, 0, 0, 0, 1, 0, 0, NULL),
(18, 150, 0, 1, 1, 1, 1, 1, NULL),
(18, 152, 0, 0, 1, 0, 0, 0, NULL),
(18, 155, 0, 0, 0, 0, 0, 0, NULL),
(18, 158, 0, 1, 0, 0, 0, 0, NULL),
(18, 164, 0, 0, 0, 1, 0, 1, NULL),
(18, 168, 0, 0, 1, 0, 0, 0, NULL),
(18, 169, 0, 1, 1, 1, 1, 1, NULL),
(18, 171, 1, 0, 0, 1, 1, 0, NULL),
(18, 174, 0, 0, 0, 0, 0, 0, NULL),
(18, 178, 1, 1, 0, 1, 0, 1, NULL),
(18, 182, 0, 1, 0, 1, 1, 0, NULL),
(18, 186, 0, 0, 0, 1, 1, 0, NULL),
(18, 188, 1, 1, 1, 0, 0, 0, NULL),
(18, 193, 1, 0, 0, 0, 0, 0, NULL),
(18, 194, 1, 0, 0, 0, 1, 1, NULL),
(18, 196, 1, 1, 0, 1, 1, 1, NULL),
(18, 198, 1, 1, 0, 0, 1, 1, NULL),
(18, 201, 1, 0, 0, 1, 0, 1, NULL),
(18, 204, 0, 1, 1, 0, 1, 0, NULL),
(18, 205, 1, 1, 0, 1, 0, 1, NULL),
(18, 211, 0, 1, 0, 0, 0, 1, NULL),
(18, 212, 0, 0, 1, 0, 0, 0, NULL),
(18, 215, 1, 1, 0, 1, 0, 1, NULL),
(18, 224, 0, 1, 1, 0, 1, 1, NULL),
(18, 229, 0, 0, 1, 0, 0, 1, NULL),
(18, 235, 0, 0, 0, 0, 0, 1, NULL),
(18, 239, 0, 1, 0, 1, 1, 0, NULL),
(18, 243, 1, 1, 0, 1, 0, 0, NULL),
(18, 244, 1, 0, 0, 0, 1, 0, NULL),
(18, 245, 0, 0, 0, 1, 0, 1, NULL),
(18, 246, 0, 1, 1, 0, 1, 0, NULL),
(18, 248, 0, 1, 1, 0, 1, 1, NULL),
(18, 251, 0, 1, 0, 0, 1, 0, NULL),
(18, 252, 0, 1, 1, 0, 1, 0, NULL),
(18, 257, 0, 0, 1, 0, 1, 0, NULL),
(18, 258, 1, 0, 0, 0, 0, 0, NULL),
(18, 261, 1, 1, 0, 1, 0, 0, NULL),
(18, 262, 0, 1, 1, 1, 0, 0, NULL),
(18, 264, 0, 1, 0, 1, 1, 0, NULL),
(18, 269, 0, 0, 0, 0, 0, 1, NULL),
(18, 270, 1, 0, 1, 0, 1, 0, NULL),
(19, 1, 1, 0, 0, 0, 0, 0, NULL),
(20, 1, 0, 1, 1, 0, 0, 0, NULL),
(20, 2, 1, 0, 1, 1, 0, 1, NULL),
(25, 1, 1, 1, 1, 1, 0, 1, NULL),
(25, 2, 0, 0, 0, 0, 0, 1, NULL),
(25, 3, 0, 0, 0, 0, 0, 1, NULL),
(25, 4, 1, 1, 1, 1, 0, 1, NULL),
(25, 18, 1, 0, 0, 1, 0, 0, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `issue`
--

CREATE TABLE `issue` (
  `issue_de_id_fk` bigint(11) NOT NULL COMMENT 'from deal table',
  `issue_type_court_cfk` bigint(20) NOT NULL COMMENT 'نوع المحكمة (بداية، صلح، ......)',
  `issue_address_court_cfk` bigint(20) NOT NULL,
  `issue_type_cfk` bigint(255) NOT NULL COMMENT 'طلب  اوحقوقية',
  `issue_number_of_court` varchar(20) NOT NULL,
  `issue_number_court_opposite` varchar(20) NOT NULL COMMENT 'رقم القضية المقابلة',
  `issue_status` int(1) NOT NULL COMMENT '0loss 1 win 2 going',
  `issue_start_date` date NOT NULL,
  `issue_end_date` date NOT NULL,
  `issue_subject_lawsuit` text NOT NULL COMMENT 'موضوع الدعوى',
  `issue_number_relation_issue` bigint(20) NOT NULL COMMENT 'رقم قضية ذات علاقة',
  `issue_type_relation_issue_cfk` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `issue_oreder_number` varchar(255) NOT NULL,
  `issue_notic_lose_win` varchar(255) NOT NULL,
  `created_by` int(11) DEFAULT NULL,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_by` int(11) DEFAULT NULL,
  `issue_address` int(11) NOT NULL,
  `issue_name` varchar(255) CHARACTER SET utf8mb4 DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `issue`
--

INSERT INTO `issue` (`issue_de_id_fk`, `issue_type_court_cfk`, `issue_address_court_cfk`, `issue_type_cfk`, `issue_number_of_court`, `issue_number_court_opposite`, `issue_status`, `issue_start_date`, `issue_end_date`, `issue_subject_lawsuit`, `issue_number_relation_issue`, `issue_type_relation_issue_cfk`, `created_at`, `issue_oreder_number`, `issue_notic_lose_win`, `created_by`, `updated_at`, `updated_by`, `issue_address`, `issue_name`) VALUES
(1, 3, 10, 1, '2015/27', '2014/23', 1, '2018-07-17', '2018-07-31', '', 0, 0, '2018-08-14 07:55:50', '', '', NULL, '2018-08-14 07:55:26', NULL, 5, NULL),
(2, 1, 10, 1, '2', '20/2014', 1, '2018-08-17', '2018-08-28', 'asfdmpofsofmampsdfaodopmfa', 1, 1, '2018-08-14 07:55:55', '1', '2', NULL, '2018-08-14 07:55:26', NULL, 10, NULL),
(3, 2, 1, 1, '2', '20/2014', 1, '2018-08-15', '2018-08-11', 'asdddddddddddddddddddddddddddddddd', 1, 1, '2018-08-14 07:55:58', '', '', NULL, '2018-08-14 07:55:26', NULL, 3, NULL),
(5, 1, 3, 2, '12014/2013', '1', 1, '2018-08-21', '2018-08-09', 'amr issue ', 14, 1, '2018-08-27 17:27:38', 'number', 'lose issue', 2, '2018-08-27 17:27:38', 1, 1, 'first amr issue');

-- --------------------------------------------------------

--
-- Table structure for table `issue_session`
--

CREATE TABLE `issue_session` (
  `se_de_id` bigint(20) NOT NULL,
  `se_issue_id_fk` bigint(20) NOT NULL,
  `se_notic` text NOT NULL,
  `issue_se_number_se` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `se_next_action` varchar(255) NOT NULL,
  `issue_date_next_se` varchar(255) NOT NULL,
  `se_name` varchar(255) NOT NULL,
  `is_transaction` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Dumping data for table `issue_session`
--

INSERT INTO `issue_session` (`se_de_id`, `se_issue_id_fk`, `se_notic`, `issue_se_number_se`, `created_at`, `se_next_action`, `issue_date_next_se`, `se_name`, `is_transaction`) VALUES
(32, 5, 'ملاحظاتك ي معلم', 111, '2018-08-29 13:50:03', 'الاجراء القادم', '50-30-1990', 'جلسة جديدة', 0),
(34, 5, 'ملاحظاتك ي معلم', 111, '2018-08-29 18:31:31', 'الاجراء القادم', '50-30-1990', 'جلسة جديدة', 0),
(36, 5, 'ملاحظاتك ي معلم', 111, '2018-08-29 18:33:41', 'الاجراء القادم', '50-30-1990', 'جلسة جديدة', 0),
(38, 5, 'ملاحظاتك ي معلم6788', 111688, '2018-08-29 18:34:13', 'الاجراء القادم45', '50-30-1990', 'جلسة جديدة788', 0),
(40, 5, 'after edit', 1, '2018-08-29 18:46:28', 'nothiong', 'nothiong', 'last', 0),
(42, 5, 'after edit', 1, '2018-08-29 18:46:51', 'nothiong', 'nothiong', 'last', 0),
(44, 5, 'after edit', 1, '2018-08-29 18:46:56', 'nothiong', 'nothiong', 'last', 1),
(46, 5, 'after edit', 1, '2018-08-29 18:54:32', 'nothiong', 'nothiong', 'last', 1),
(49, 5, 'ملاحظاتك ي معلم', 111, '2018-08-29 20:22:05', 'الاجراء القادم', '50-30-1990', 'جلسة جديدة', 0),
(51, 5, 'ملاحظاتك ي معلم', 111, '2018-08-29 20:51:34', 'الاجراء القادم', '50-30-1990', 'جلسة جديدة', 0),
(53, 5, 'ملاحظاتك ي معلم', 111, '2018-08-29 20:51:49', 'الاجراء القادم', '50-30-1990', 'جلسة جديدة', 0);

-- --------------------------------------------------------

--
-- Table structure for table `issue_transaction`
--

CREATE TABLE `issue_transaction` (
  `tr_id` bigint(20) NOT NULL,
  `tr_issue_id_fk` bigint(20) NOT NULL,
  `tr_address_court_cfk` int(255) NOT NULL,
  `tr_court_type_cfk` int(255) DEFAULT NULL,
  `tr_date_conversion` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `tr_se_issue_id_fk` bigint(20) NOT NULL,
  `issue_tr_new_id` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `issue_transaction`
--

INSERT INTO `issue_transaction` (`tr_id`, `tr_issue_id_fk`, `tr_address_court_cfk`, `tr_court_type_cfk`, `tr_date_conversion`, `tr_se_issue_id_fk`, `issue_tr_new_id`) VALUES
(2, 5, 1, NULL, '2018-08-29 18:54:32', 46, '4/2014');

-- --------------------------------------------------------

--
-- Table structure for table `notics`
--

CREATE TABLE `notics` (
  `notics_id` bigint(11) NOT NULL,
  `notic_de_id_fk` int(11) NOT NULL,
  `notic_de_content` text NOT NULL,
  `notic` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notification`
--

CREATE TABLE `notification` (
  `not_id` bigint(11) NOT NULL,
  `not_type` int(11) NOT NULL COMMENT '(عدلي / محامي)',
  `not_number_in_court` varchar(20) NOT NULL,
  `not_court_place` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `not_counter_notification` varchar(255) NOT NULL,
  `not_Lawyer_id` bigint(11) NOT NULL,
  `not_subject` text NOT NULL,
  `not_date` datetime NOT NULL,
  `not_issue_id` bigint(20) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL,
  `create_by` bigint(11) DEFAULT NULL,
  `updated_by` bigint(10) NOT NULL,
  `deal_note_id_fk` bigint(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `notification`
--

INSERT INTO `notification` (`not_id`, `not_type`, `not_number_in_court`, `not_court_place`, `not_counter_notification`, `not_Lawyer_id`, `not_subject`, `not_date`, `not_issue_id`, `created_at`, `updated_at`, `create_by`, `updated_by`, `deal_note_id_fk`) VALUES
(30, 0, '34/34', '34', '34/34', 29, '34', '0001-01-01 00:00:00', 34, '2018-08-28 13:40:41', '0001-01-01 00:00:00', 0, 0, 0),
(29, 0, '45345/435345', '456', '456/456', 0, '456', '0001-01-01 00:00:00', 546, '2018-08-28 13:36:44', '0001-01-01 00:00:00', 0, 0, 0),
(31, 0, '345/345', '345', '43/345', 0, '35', '0001-01-01 00:00:00', 435, '2018-08-28 14:43:26', '0001-01-01 00:00:00', 0, 0, 0),
(32, 0, '33/33', '3', '3/3', 0, '3', '2001-01-01 00:00:00', 3, '2018-08-29 22:54:47', '0001-01-01 00:00:00', 0, 0, 0),
(33, 0, '33/33', '33', '3/3', 0, '3', '2001-01-01 00:00:00', 3, '2018-08-30 06:53:42', '0001-01-01 00:00:00', 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `notifier`
--

CREATE TABLE `notifier` (
  `notr_id` bigint(11) NOT NULL,
  `notr_not` varchar(11) NOT NULL,
  `notr_p_type` int(1) NOT NULL DEFAULT '0' COMMENT '1:notifier , 2:notify_to',
  `Not_de_id_fk` bigint(11) NOT NULL DEFAULT '0',
  `notr_p_id_fk` bigint(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `notifier`
--

INSERT INTO `notifier` (`notr_id`, `notr_not`, `notr_p_type`, `Not_de_id_fk`, `notr_p_id_fk`) VALUES
(20, 'e', 0, 26, 36);

-- --------------------------------------------------------

--
-- Table structure for table `owners`
--

CREATE TABLE `owners` (
  `ow_id` int(11) NOT NULL,
  `ow_per_fk` bigint(255) NOT NULL,
  `ow_start_date` date NOT NULL,
  `ow_end_date` int(11) NOT NULL,
  `ow_property_id_fk` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `persons`
--

CREATE TABLE `persons` (
  `pe_id` bigint(20) NOT NULL,
  `pe_name` varchar(255) NOT NULL,
  `pe_type` int(11) NOT NULL,
  `pe_address` varchar(100) NOT NULL,
  `pe_identity` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `persons`
--

INSERT INTO `persons` (`pe_id`, `pe_name`, `pe_type`, `pe_address`, `pe_identity`) VALUES
(1, 'mahmoud', 1, '1', 15689449),
(2, 'Zoher', 20, '', 35145646),
(3, 'Hosam', 21, '', 579797987),
(4, 'Eiad', 21, '', 54640),
(5, '333', 0, '55 55', 123),
(6, 'wer', 0, 'rr rr', 34234),
(7, 'Ahmed', 0, '23 23', 123),
(8, 'mohmed', 0, 'ee eee', 123456),
(12, 'amr', 1, 'gaza', 15689449),
(13, 'ali', 0, 'd d', 77),
(14, 'ahmed', 0, 'e e', 78),
(15, 'aa', 0, 'ee e', 334),
(16, 'rr', 0, '3 3', 3333),
(17, 'vv', 0, 'r rr', 345),
(18, 'aa', 0, '3 3', 34),
(19, 'cc', 0, '34 34', 34),
(20, 'Mohammed Ahmed', 35, '', 12654654),
(21, 'Mohammed Ahmed', 36, '', 12654654),
(37, 'test test', 34, '', 987654321),
(23, 'ahmed', 0, 'dd dd', 79879),
(24, 'amaml', 0, 'rr r', 56345),
(25, 'ahmed', 0, 'd d', 798),
(26, 'ali', 0, 'd d', 897987),
(27, 'noor', 0, 'asf asdf', 987987),
(28, 'nehad', 0, 'rw ret', 43252),
(29, 'kalele', 0, 'r r', 23452),
(30, 'ahmed', 0, 'dsf df', 7987987),
(31, 'noori', 0, 'af sdf', 9887987),
(32, 'kaled', 0, 'adf adf', 123),
(33, 'ali', 0, 'df df', 123),
(34, 'noori', 0, 'asdf df', 123456),
(35, 'ali', 0, 'd d', 78987),
(36, 'ali', 0, 'e e', 78997),
(38, '44444', 20, '', 321);

-- --------------------------------------------------------

--
-- Table structure for table `persons_address`
--

CREATE TABLE `persons_address` (
  `pe_ad_id` int(11) NOT NULL,
  `pe_ad_city` varchar(255) NOT NULL,
  `pe_ad_street_name` varchar(255) NOT NULL,
  `pe_ad_per_id_fk` bigint(11) NOT NULL,
  `ad_type` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `persons_address`
--

INSERT INTO `persons_address` (`pe_ad_id`, `pe_ad_city`, `pe_ad_street_name`, `pe_ad_per_id_fk`, `ad_type`) VALUES
(57, 'ccv', 'ccv', 357, 1),
(56, 'vv', 'vv', 357, 0),
(54, '12sssss', '12sssssss', 355, 0),
(55, '12zzzzzzzzz', '12zzzzzz', 355, 1),
(53, '', '', 351, 1),
(52, '', '', 351, 0),
(51, '10220gg', '1020gg', 345, 1),
(50, 'gg', 'gg', 345, 0),
(49, 'xa', 'xa', 343, 1),
(48, 'ax', 'ax', 343, 0),
(47, '55', '55', 341, 1),
(44, 'vvvvvvvvvvv', 'vvvvvvvvv', 340, 0),
(45, 'vvxxxxxxxxx', 'xxxxxxxx', 340, 1),
(46, '55', '55', 341, 0),
(58, 'bb', 'bb', 357, 0),
(59, 'vv', 'vv', 357, 1),
(60, 'Gaza', 'Remal', 2, 0),
(65, 'Gaza', 'Naser', 3, 0),
(64, 'Khan yunis', 'Abasan', 4, 0),
(67, 'test', 'test', 37, 0),
(68, '25252', '511181', 38, 0);

-- --------------------------------------------------------

--
-- Table structure for table `persons_communication`
--

CREATE TABLE `persons_communication` (
  `co_id` bigint(11) NOT NULL,
  `co_name_cfk` varchar(255) NOT NULL,
  `co_value` varchar(255) NOT NULL,
  `co_pe_id_fk` bigint(20) NOT NULL,
  `co_is_main` tinyint(1) NOT NULL DEFAULT '0' COMMENT '0communication 1communication alternatev'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `persons_communication`
--

INSERT INTO `persons_communication` (`co_id`, `co_name_cfk`, `co_value`, `co_pe_id_fk`, `co_is_main`) VALUES
(74, 'Phone Number', 'dsf', 30, 0),
(73, 'Mobile Number', 'wt', 29, 0),
(71, 'Phone Number', 'wrt', 29, 1),
(72, 'FaceBook Profile', 'wert', 29, 0),
(70, 'Mobile Number', 'wert', 28, 0),
(69, 'Phone Number', 'wrt', 28, 0),
(68, 'Mobile Number', 'asdf', 27, 0),
(67, 'Phone Number', 'dsaf', 27, 1),
(66, 'Mobile Number', 'd', 26, 0),
(65, 'Phone Number', 'd', 26, 0),
(64, 'Mobile Number', 'd', 25, 1),
(63, 'Phone Number', 'dd', 25, 0),
(62, '1', '0597400254', 12, 0),
(61, 'FaceBook Profile', 'wert', 24, 0),
(60, 'Fax Number', 'ert', 24, 1),
(59, 'Mobile Number', 'rtr', 24, 0),
(58, 'Phone Number', 'rrtrt', 24, 0),
(57, 'FaceBook Profile', 'ee', 23, 1),
(56, 'Mobile Number', '44', 23, 0),
(55, 'Phone Number', '44', 23, 0),
(87, 'Phone Number', '858828', 38, 0),
(86, 'Mobile Number', '8888888', 37, 0),
(85, 'Phone Number', '555555', 37, 0),
(75, 'Mobile Number', 'asdf', 30, 0),
(76, 'FaceBook Profile', 'asd', 30, 1),
(77, 'Mobile Number', 'sdf', 31, 0),
(78, 'FaceBook Profile', 'saf', 31, 1),
(79, 'Phone Number', '433', 33, 1),
(80, 'Mobile Number', '345', 34, 0),
(81, 'Phone Number', 'd', 35, 0),
(82, 'Mobile Number', 'd', 35, 0),
(83, 'Phone Number', 'e', 36, 0),
(84, 'Mobile Number', 'ew', 36, 0);

-- --------------------------------------------------------

--
-- Table structure for table `persons_issue`
--

CREATE TABLE `persons_issue` (
  `pe_issue_pe_id` int(11) NOT NULL,
  `cd_issue_issue_id` int(11) NOT NULL,
  `pe_issue_relation_cfk` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `persons_issue`
--

INSERT INTO `persons_issue` (`pe_issue_pe_id`, `cd_issue_issue_id`, `pe_issue_relation_cfk`) VALUES
(1, 1, 1),
(2, 2, 1),
(1, 3, 1),
(12, 5, 1);

-- --------------------------------------------------------

--
-- Table structure for table `property`
--

CREATE TABLE `property` (
  `pr_id` int(11) NOT NULL,
  `pr_type_cfk` int(11) NOT NULL COMMENT 'نوع المعاملة',
  `pr_notic` text NOT NULL,
  `pr_co_id_fk` bigint(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `role_id` int(11) NOT NULL,
  `role_name` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`role_id`, `role_name`, `description`) VALUES
(1, 'Users', 'Description Role 1'),
(2, 'Rols', 'Description Role 2'),
(3, 'Cases', 'Description Role 3'),
(4, 'Contracts', 'Description Role 4'),
(5, 'Role 5', 'Description Role 5'),
(6, 'Role 6', 'Description Role 6'),
(7, 'Role 7', 'Description Role 7'),
(8, 'Role 8', 'Description Role 8'),
(9, 'Role 9', 'Description Role 9'),
(10, 'Role 10', 'Description Role 10'),
(11, 'Role 11', 'Description Role 11'),
(12, 'Role 12', 'Description Role 12'),
(13, 'Role 13', 'Description Role 13'),
(14, 'Role 14', 'Description Role 14'),
(15, 'Role 15', 'Description Role 15'),
(16, 'Role 16', 'Description Role 16'),
(17, 'Role 17', 'Description Role 17'),
(18, 'Role 18', 'Description Role 18'),
(19, 'Role 19', 'Description Role 19'),
(20, 'Role 20', 'Description Role 20');

-- --------------------------------------------------------

--
-- Table structure for table `session_file`
--

CREATE TABLE `session_file` (
  `session_fie_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `crated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `session_id` int(11) NOT NULL,
  `se_fi_notic` text NOT NULL,
  `se_fi_doc_type` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `session_file`
--

INSERT INTO `session_file` (`session_fie_id`, `name`, `crated_at`, `session_id`, `se_fi_notic`, `se_fi_doc_type`) VALUES
(1, 'testmysql.php', '2018-08-19 09:33:15', 3, 'saddddddddddddddddd', '2'),
(2, 'aaa.jpg', '2018-08-19 12:16:07', 6, 'Notes Here', '0'),
(3, 'IMG_20180219_142818_643.jpg', '2018-08-26 10:48:55', 7, 'Notes Here', '0'),
(4, 'aaa.jpg', '2018-08-27 12:34:05', 8, 'Notes Here', '0'),
(5, 'IMG_20180225_120918_558.jpg', '2018-08-27 12:42:32', 9, 'Notes Here', '0'),
(6, 'aaaa2.jpg', '2018-08-27 17:23:20', 25, 'mahmoud', '1'),
(7, 'aaaa2.jpg', '2018-08-27 17:35:25', 26, 'mahmoud', '1'),
(8, 'IMG_20180219_142818_643.jpg', '2018-08-27 17:43:40', 27, 'Notes Here', '0'),
(9, 'tumblr_nmbzcoPw021qg9z8no1_500.jpg', '2018-08-28 07:45:04', 28, 'Notes Here', '0');

-- --------------------------------------------------------

--
-- Table structure for table `users_tb`
--

CREATE TABLE `users_tb` (
  `u_p_id_fk` bigint(20) NOT NULL,
  `u_email` varchar(255) NOT NULL,
  `u_password` varchar(255) NOT NULL,
  `u_user_name` varchar(255) NOT NULL,
  `u_is_active` tinyint(11) NOT NULL DEFAULT '0' COMMENT '1 is active, 0 is not',
  `u_has_login` tinyint(11) NOT NULL DEFAULT '0' COMMENT '1 has login, 0 has  not',
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_by` bigint(11) DEFAULT NULL,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_by` bigint(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users_tb`
--

INSERT INTO `users_tb` (`u_p_id_fk`, `u_email`, `u_password`, `u_user_name`, `u_is_active`, `u_has_login`, `created_at`, `created_by`, `updated_at`, `updated_by`) VALUES
(1, 'mahmoud@hotmail.com', '$2y$10$5PZFpvZ6bL5T17SOf5wjCOrEUZvywi7p8NPSatz8iLXusYb1EVjz.', 'mahmoud', 0, 0, '2018-07-31 06:54:35', NULL, '2018-07-31 06:53:37', 1),
(2, 'aa@aa.com', '$2y$10$05oyikO0RVphp1GA.n6WP.nnI7kgSU0vj1V8PIqmcSGpcbJWLhroq', 'aliali', 0, 0, '2018-08-07 11:29:07', NULL, '2018-08-07 11:29:07', NULL),
(3, 'Emial@example.com', '?d~?^g?U7R!+9d', 'MohammedAhmed', 1, 0, '2018-08-10 18:35:47', NULL, '2018-08-10 18:35:47', 0),
(4, 'Mosab@example.com', 'e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a', 'Mosab', 1, 0, '2018-08-12 06:49:42', NULL, '2018-08-12 06:49:42', 0),
(5, 'Emial@example.com', 'e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a', 'MohammedAhmed', 1, 0, '2018-08-12 20:27:21', NULL, '2018-08-12 20:27:21', 0),
(12, 'amr@hotmail.com', '$2y$10$7toFTnvJzoMVqgzWYVqjXORZDshYF.0pL.I1DL64wbvn1aV2vFQO.', 'amr', 0, 0, '2018-08-27 17:21:28', NULL, '2018-08-27 17:21:28', NULL),
(37, 'test@example.com', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08', 'test', 1, 0, '2018-08-28 12:09:47', 0, '2018-08-28 12:09:47', 0);

-- --------------------------------------------------------

--
-- Table structure for table `user_group`
--

CREATE TABLE `user_group` (
  `user_id` int(11) NOT NULL,
  `group_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user_group`
--

INSERT INTO `user_group` (`user_id`, `group_id`) VALUES
(37, 9),
(37, 8),
(37, 11);

-- --------------------------------------------------------

--
-- Table structure for table `value_of_lawsuit`
--

CREATE TABLE `value_of_lawsuit` (
  `vow_id` int(11) NOT NULL,
  `vow_value_lawsuit` double NOT NULL,
  `vow_currency` bigint(20) NOT NULL,
  `vow_issue_id_fk` bigint(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `witnessees`
--

CREATE TABLE `witnessees` (
  `Wit_id` bigint(11) NOT NULL,
  `Wi_type` int(11) NOT NULL COMMENT 'شاهد اول او شاهد ثاني',
  `de_id_fk` int(11) NOT NULL,
  `wi_per_fk` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `witnessees`
--

INSERT INTO `witnessees` (`Wit_id`, `Wi_type`, `de_id_fk`, `wi_per_fk`) VALUES
(1, 0, 0, 10),
(2, 0, 0, 11),
(3, 0, 0, 14),
(4, 0, 0, 15),
(5, 0, 0, 18),
(6, 0, 0, 19),
(7, 0, 0, 22),
(8, 0, 0, 23),
(9, 0, 0, 26),
(10, 0, 0, 27),
(11, 0, 0, 30),
(12, 0, 0, 31),
(13, 0, 0, 34),
(14, 0, 0, 35),
(15, 0, 0, 38),
(16, 0, 0, 39),
(17, 0, 0, 45),
(18, 0, 0, 46),
(19, 0, 0, 49),
(20, 0, 0, 50),
(21, 0, 0, 53),
(22, 0, 0, 54),
(23, 0, 0, 57),
(24, 0, 0, 58),
(25, 0, 0, 61),
(26, 0, 0, 62),
(27, 0, 0, 65),
(28, 0, 0, 66),
(29, 0, 0, 69),
(30, 0, 0, 70),
(31, 0, 0, 73),
(32, 0, 0, 74),
(33, 0, 0, 77),
(34, 0, 0, 78),
(35, 0, 0, 85),
(36, 0, 0, 86),
(37, 0, 0, 89),
(38, 0, 0, 90);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appeals_slander`
--
ALTER TABLE `appeals_slander`
  ADD PRIMARY KEY (`ap_sl_id`);

--
-- Indexes for table `codes_tb`
--
ALTER TABLE `codes_tb`
  ADD PRIMARY KEY (`c_id`);

--
-- Indexes for table `contract`
--
ALTER TABLE `contract`
  ADD PRIMARY KEY (`con_de_id_fk`);

--
-- Indexes for table `contract_party`
--
ALTER TABLE `contract_party`
  ADD PRIMARY KEY (`con_pa_id`);

--
-- Indexes for table `deal_tb`
--
ALTER TABLE `deal_tb`
  ADD PRIMARY KEY (`de_id`);

--
-- Indexes for table `fees`
--
ALTER TABLE `fees`
  ADD PRIMARY KEY (`fe_id`);

--
-- Indexes for table `files`
--
ALTER TABLE `files`
  ADD PRIMARY KEY (`fi_de_id`);

--
-- Indexes for table `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`g_id`);

--
-- Indexes for table `group_roles`
--
ALTER TABLE `group_roles`
  ADD PRIMARY KEY (`grolr_role_id_fk`,`grolr_g_id_fk`);

--
-- Indexes for table `issue`
--
ALTER TABLE `issue`
  ADD UNIQUE KEY `is_de_id_fk` (`issue_de_id_fk`);

--
-- Indexes for table `issue_transaction`
--
ALTER TABLE `issue_transaction`
  ADD PRIMARY KEY (`tr_id`);

--
-- Indexes for table `notics`
--
ALTER TABLE `notics`
  ADD PRIMARY KEY (`notics_id`);

--
-- Indexes for table `notification`
--
ALTER TABLE `notification`
  ADD PRIMARY KEY (`not_id`);

--
-- Indexes for table `notifier`
--
ALTER TABLE `notifier`
  ADD PRIMARY KEY (`notr_id`,`notr_not`);

--
-- Indexes for table `owners`
--
ALTER TABLE `owners`
  ADD PRIMARY KEY (`ow_id`);

--
-- Indexes for table `persons`
--
ALTER TABLE `persons`
  ADD PRIMARY KEY (`pe_id`);

--
-- Indexes for table `persons_address`
--
ALTER TABLE `persons_address`
  ADD PRIMARY KEY (`pe_ad_id`);

--
-- Indexes for table `persons_communication`
--
ALTER TABLE `persons_communication`
  ADD PRIMARY KEY (`co_id`);

--
-- Indexes for table `persons_issue`
--
ALTER TABLE `persons_issue`
  ADD PRIMARY KEY (`pe_issue_pe_id`,`cd_issue_issue_id`);

--
-- Indexes for table `property`
--
ALTER TABLE `property`
  ADD PRIMARY KEY (`pr_id`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`role_id`);

--
-- Indexes for table `session_file`
--
ALTER TABLE `session_file`
  ADD PRIMARY KEY (`session_fie_id`);

--
-- Indexes for table `users_tb`
--
ALTER TABLE `users_tb`
  ADD PRIMARY KEY (`u_p_id_fk`);

--
-- Indexes for table `value_of_lawsuit`
--
ALTER TABLE `value_of_lawsuit`
  ADD PRIMARY KEY (`vow_id`);

--
-- Indexes for table `witnessees`
--
ALTER TABLE `witnessees`
  ADD PRIMARY KEY (`Wit_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appeals_slander`
--
ALTER TABLE `appeals_slander`
  MODIFY `ap_sl_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `codes_tb`
--
ALTER TABLE `codes_tb`
  MODIFY `c_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;
--
-- AUTO_INCREMENT for table `contract_party`
--
ALTER TABLE `contract_party`
  MODIFY `con_pa_id` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `deal_tb`
--
ALTER TABLE `deal_tb`
  MODIFY `de_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;
--
-- AUTO_INCREMENT for table `fees`
--
ALTER TABLE `fees`
  MODIFY `fe_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'fees_issue', AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `groups`
--
ALTER TABLE `groups`
  MODIFY `g_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=273;
--
-- AUTO_INCREMENT for table `issue_transaction`
--
ALTER TABLE `issue_transaction`
  MODIFY `tr_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `notics`
--
ALTER TABLE `notics`
  MODIFY `notics_id` bigint(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `notification`
--
ALTER TABLE `notification`
  MODIFY `not_id` bigint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
--
-- AUTO_INCREMENT for table `notifier`
--
ALTER TABLE `notifier`
  MODIFY `notr_id` bigint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT for table `owners`
--
ALTER TABLE `owners`
  MODIFY `ow_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `persons`
--
ALTER TABLE `persons`
  MODIFY `pe_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;
--
-- AUTO_INCREMENT for table `persons_address`
--
ALTER TABLE `persons_address`
  MODIFY `pe_ad_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;
--
-- AUTO_INCREMENT for table `persons_communication`
--
ALTER TABLE `persons_communication`
  MODIFY `co_id` bigint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=88;
--
-- AUTO_INCREMENT for table `property`
--
ALTER TABLE `property`
  MODIFY `pr_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `role_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT for table `session_file`
--
ALTER TABLE `session_file`
  MODIFY `session_fie_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `users_tb`
--
ALTER TABLE `users_tb`
  MODIFY `u_p_id_fk` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;
--
-- AUTO_INCREMENT for table `value_of_lawsuit`
--
ALTER TABLE `value_of_lawsuit`
  MODIFY `vow_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `witnessees`
--
ALTER TABLE `witnessees`
  MODIFY `Wit_id` bigint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
