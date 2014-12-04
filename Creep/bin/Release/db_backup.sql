/*
SQLyog Community v12.02 (64 bit)
MySQL - 5.6.21-log : Database - user1
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `departments` */

DROP TABLE IF EXISTS `departments`;

CREATE TABLE `departments` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `manager_id` int(11) NOT NULL,
  `name` text NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

/*Table structure for table `reportitems` */

DROP TABLE IF EXISTS `reportitems`;

CREATE TABLE `reportitems` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `report_id` int(11) NOT NULL,
  `value` text COLLATE utf8_unicode_ci NOT NULL,
  `required` tinyint(1) DEFAULT '0',
  `title` text COLLATE utf8_unicode_ci NOT NULL,
  `type` varchar(80) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Text',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=104 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Table structure for table `reports` */

DROP TABLE IF EXISTS `reports`;

CREATE TABLE `reports` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `owner_id` int(11) NOT NULL,
  `recipient_id` int(11) NOT NULL,
  `title` text CHARACTER SET latin1 NOT NULL,
  `formatted_text` text CHARACTER SET latin1 NOT NULL,
  `checked` tinyint(4) DEFAULT '0',
  `done` tinyint(4) DEFAULT '0',
  `type_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `due_date` text COLLATE utf8_unicode_ci,
  `department_id` int(11) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Table structure for table `reports_backup` */

DROP TABLE IF EXISTS `reports_backup`;

CREATE TABLE `reports_backup` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `owner_id` int(11) NOT NULL,
  `recipient_id` int(11) NOT NULL,
  `title` text CHARACTER SET latin1 NOT NULL,
  `formatted_text` text CHARACTER SET latin1 NOT NULL,
  `checked` tinyint(4) DEFAULT '0',
  `done` tinyint(4) DEFAULT '0',
  `type_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `due_date` text COLLATE utf8_unicode_ci,
  `department_id` int(11) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Table structure for table `reporttypes` */

DROP TABLE IF EXISTS `reporttypes`;

CREATE TABLE `reporttypes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `type_name` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `email` text NOT NULL,
  `role` tinyint(4) NOT NULL,
  `password` text,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Table structure for table `usersdepartments` */

DROP TABLE IF EXISTS `usersdepartments`;

CREATE TABLE `usersdepartments` (
  `department_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/* Trigger structure for table `reports` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `BackupReports` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'admin'@'%' */ /*!50003 TRIGGER `BackupReports` BEFORE UPDATE ON `reports` FOR EACH ROW BEGIN  
    INSERT INTO `reports_backup` SET 
	`ID` = OLD.`ID`,
	`owner_id` = OLD.`owner_id`,
	`recipient_id` = OLD.`recipient_id`,
	`title` = OLD.`title`,
	`formatted_text` = OLD.`formatted_text`,
	`checked` = OLD.`checked`,
	`done` = OLD.`done`,
	`type_id` = OLD.`type_id`,
	`created_at` = OLD.`created_at`,
	`updated_at` = OLD.`updated_at`,
	`due_date` = OLD.`due_date`,
	`department_id` = OLD.`department_id`;
END */$$


DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
