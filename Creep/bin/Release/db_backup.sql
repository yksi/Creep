/*
SQLyog Community v12.02 (64 bit)
MySQL - 5.6.21-log : Database - user1
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`user1` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `user1`;

/*Table structure for table `departments` */

DROP TABLE IF EXISTS `departments`;

CREATE TABLE `departments` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `manager_id` int(11) NOT NULL,
  `name` text NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

/*Data for the table `departments` */

insert  into `departments`(`ID`,`manager_id`,`name`) values (14,2,'Management'),(15,1,'Administration'),(16,5,'SUPPORT');

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
) ENGINE=InnoDB AUTO_INCREMENT=94 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `reportitems` */

insert  into `reportitems`(`ID`,`report_id`,`value`,`required`,`title`,`type`) values (87,62,'I am fine',1,'Describe your position','Formatted text'),(88,62,'true',0,'Are you glad to be a worker?','Checkbox'),(89,63,'Here describe how did you cleaned My PC ',1,'Description','Formatted text'),(90,63,'',0,'Is Success','Checkbox'),(91,64,'Bug fixed',1,'Sumary','Formatted text'),(92,64,'true',0,'Need costs','Checkbox'),(93,64,'In total no',0,'Renew contracts','Formatted text');

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
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `reports` */

insert  into `reports`(`ID`,`owner_id`,`recipient_id`,`title`,`formatted_text`,`checked`,`done`,`type_id`,`created_at`,`updated_at`,`due_date`,`department_id`) values (62,1,2,'Position','Descriptiom Long Long Long Long Long Long Long \r\nLong Long Long Long Long Long Long Long Long \r\nLong Long Long Long Long Long Long Long Long  ',1,1,5,'2014-12-02 08:15:15','2014-12-02 08:28:25','2014-12-02',0),(63,1,5,'Clean PC','Please clean my pc.\r\nVery load',1,0,4,'2014-12-02 12:13:00','2014-12-02 12:25:49','2014-12-02',0),(64,1,4,'Fix Bags with JS','Please make report about bagfixing',1,1,1,'2014-12-02 12:15:59','2014-12-02 12:21:19','2014-12-02',0);

/*Table structure for table `reporttypes` */

DROP TABLE IF EXISTS `reporttypes`;

CREATE TABLE `reporttypes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `type_name` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `reporttypes` */

insert  into `reporttypes`(`ID`,`type_name`) values (1,'Sell report'),(2,'Debet report'),(3,'HR report\r\n'),(4,'Work everyday report'),(5,'Company report');

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `users` */

insert  into `users`(`ID`,`name`,`email`,`role`,`password`,`created_at`,`updated_at`) values (2,'user','user@creep-enterprice.com',1,'ee11cbb19052e40b07aac0ca060c23ee','2014-11-18 19:54:50','2014-11-18 19:54:50'),(4,'Vitaliy Krushelnytskiy','embox@ukr.net',1,'ee11cbb19052e40b07aac0ca060c23ee','2014-12-02 02:32:50','2014-12-02 02:32:50'),(5,'Gear Dude','g@g.d',1,'f5bb0c8de146c67b44babbf4e6584cc0','2014-12-02 09:55:44','2014-12-02 09:55:44');

/*Table structure for table `usersdepartments` */

DROP TABLE IF EXISTS `usersdepartments`;

CREATE TABLE `usersdepartments` (
  `department_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `usersdepartments` */

insert  into `usersdepartments`(`department_id`,`user_id`) values (14,1),(14,4),(14,2),(21,4),(21,2),(15,4),(15,5);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
