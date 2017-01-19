-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: clipperreporting
-- ------------------------------------------------------
-- Server version	5.7.12-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `auditrecords`
--

DROP TABLE IF EXISTS `auditrecords`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `auditrecords` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EntityName` text,
  `Action` text,
  `PrimaryKeyValue` text,
  `PropertyName` text,
  `OldValue` text,
  `NewValue` text,
  `UserName` text,
  `DateChanged` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=472 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `devicesurvey`
--

DROP TABLE IF EXISTS `devicesurvey`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `devicesurvey` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Operator` text,
  `ReportingPeriod` text,
  `UserName` text,
  `Email` text,
  `IsExpectingNewVehicles` bit(1) NOT NULL DEFAULT b'0',
  `HasGillig` bit(1) NOT NULL DEFAULT b'0',
  `HasNewFlyer` bit(1) NOT NULL DEFAULT b'0',
  `HasElDorado` bit(1) NOT NULL DEFAULT b'0',
  `HasOther` bit(1) NOT NULL DEFAULT b'0',
  `OtherName` text,
  `GilligNewVehicles` int(11) DEFAULT NULL,
  `GilligNewModel` text,
  `GilligReplacementVehicles` int(11) DEFAULT NULL,
  `GilligReplacementManufacturingDate` text,
  `GilligReplacementDeliveryDate` text,
  `GilligExpansionVehicles` int(11) DEFAULT NULL,
  `GilligExpansionManufacturingDate` text,
  `GilligExpansionDeliveryDate` text,
  `NewFlyerNewVehicles` int(11) DEFAULT NULL,
  `NewFlyerNewModel` text,
  `NewFlyerReplacementVehicles` int(11) DEFAULT NULL,
  `NewFlyerReplacementManufacturingDate` text,
  `NewFlyerReplacementDeliveryDate` text,
  `NewFlyerExpansionVehicles` int(11) DEFAULT NULL,
  `NewFlyerExpansionManufacturingDate` text,
  `NewFlyerExpansionDeliveryDate` text,
  `ElDoradoNewVehicles` int(11) DEFAULT NULL,
  `ElDoradoNewModel` text,
  `ElDoradoReplacementVehicles` int(11) DEFAULT NULL,
  `ElDoradoReplacementManufacturingDate` text,
  `ElDoradoReplacementDeliveryDate` text,
  `ElDoradoExpansionVehicles` int(11) DEFAULT NULL,
  `ElDoradoExpansionManufacturingDate` text,
  `ElDoradoExpansionDeliveryDate` text,
  `OtherNewVehicles` int(11) DEFAULT NULL,
  `OtherNewModel` text,
  `OtherReplacementVehicles` int(11) DEFAULT NULL,
  `OtherReplacementManufacturingDate` text,
  `OtherReplacementDeliveryDate` text,
  `OtherExpansionVehicles` int(11) DEFAULT NULL,
  `OtherExpansionManufacturingDate` text,
  `OtherExpansionDeliveryDate` text,
  `ExistingVehicleDetails` text,
  `ReplacementVehicleDetails` text,
  `PreWireRequirements` text,
  `IncludedCosts` text,
  `RecordStatus` text,
  `DateCreated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LastUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Notes` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devicesurvey`
--

LOCK TABLES `devicesurvey` WRITE;
/*!40000 ALTER TABLE `devicesurvey` DISABLE KEYS */;
INSERT INTO `devicesurvey` VALUES (1,'Santa Rosa City Bus','2016','Anita Winkler',NULL,'','\0','','\0','\0','',0,NULL,0,NULL,NULL,0,NULL,NULL,4,'low-floor 40 foot buses',4,'4 are on line now;  other 4 not scheduled','4 in April or May this year; other tbd',0,NULL,NULL,0,NULL,0,NULL,NULL,0,'',NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,'yes and yes',NULL,'I don\'t know and I don\'t have time to check now.  If you really need this, let me know and I can get it in the next week or so.','See answer above.','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49','May be adding 4 New Flyer vehicles in 2017 (depending on funding)'),(2,'WestCAT','2016','Rob Thompson','rob@westcat.org','','','\0','\0','','MCI',2,'low floor',2,'2017',NULL,0,NULL,NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,0,NULL,0,NULL,NULL,0,'',NULL,3,'I am going to have to get back to you on this. We will need to have a separate conversation about this perhaps next week?',1,'2017',NULL,2,'immediately',NULL,'Yes',NULL,'No contract yet','see above','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49',NULL),(4,'Sonoma County Transit','2016','Bryan Albee','bkalbee@sctransit.com','','\0','\0','','','BRD',0,NULL,0,NULL,NULL,0,NULL,NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,4,'two 30-foot (EasyRider II), two 40-foot (Axess)',4,'Summer 2016','12/01/2016',0,'',NULL,2,'one 30-foot electric (BYD) + mini bus require HCR4',1,'Summer 2016',' BYD - 12/1/2016; Mini Bus  July 2016',0,NULL,NULL,'yes','BYD is new kind of a bus','El Dorado = No, BYD = No,but plan to add','El Dorado = No, BYD = No, but work started','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49',NULL),(5,'Petaluma Transit','2016','Joe Rye','jrye2ci.petaluma.ca.us','','','\0','\0','\0','',3,'low floor BRT front',3,'July 2016, build and delivery','late July 2016',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','','yes','','No','No','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49',NULL),(6,'Eastern Contra Costa Transit Authority','2016','Steve Ponte','sponte@eccta.org','','','\0','\0','','Proterra and BYD',20,'BRT',20,'10/01/2016','10/01/2016',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','',4,'Standard long range buses (40 foot)',4,'10/01/2017','11/01/2017',0,'','','Gillig 2013\'s','Proterra and BYD','It will','no, they have no idea of price','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49',NULL),(7,'County Connection','2016','J Scott Mitchell','mitchell@cccta.org','','','\0','\0','\0','',35,'Low Floor',35,'first quarter 2017','April-May 2017',0,NULL,NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,'Yes',NULL,'yes','yes','Planned','2016-12-27 21:46:08','2017-01-18 00:16:21',NULL),(8,'LAVTA','2016','David Massa','dmassa@lavta.org','','','\0','\0','\0','',20,'BRT Hybrid',20,'06/20/2016','08/01/2016',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','','Yes, 2011 Gillig Hybrid','','We tried but Clipper couldn\'t get their stuff together and get it to them in time','Nope','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49',NULL),(9,'Union City Transit','2016','Steve Adams','sadams@unioncity.org','','','\0','\0','\0','',4,'Low-floor, standard front cap',4,'03/07/2016','03/22/2016',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','','Yes, 10 of 20 buses will have similar configurations. Similar buses were built in 2012.','','Procurement Requirement is same as CCTA’s Consortium Procurement','No','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49',NULL),(10,'SolTrans','2016',NULL,'','','','\0','\0','\0','',0,NULL,0,'','',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','','','','Email exchange with Alan, he discussed the pre-wiring needs with BYD, put them in touch with Curtis, Cubic working on getting NDA, on Mar 28 followed up with strerrett asking the latest on NDA','','Planned','2016-12-27 21:46:08','2017-01-18 00:41:13',NULL),(11,'VTA','2016',NULL,'','','','\0','\0','\0','',44,NULL,0,'','',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','',0,'',0,'','',0,'','','','','','','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49',NULL),(12,'Marin Transit','2016','Anna Penoyar','anna.penoyar@gmail.com','','','\0','','','BYD',10,'low floor hybrid, BRT front',10,'Nov/Dec 2017','Dec-17',0,'','',0,'',0,'','',0,'','',3,'2- 29 ft XHFs, 1 cutaway - Class C Aerotech 240',1,'Jul-16','Jul-16',2,'Unsure','Mar-17',2,'30ft BYD electric vehicles',0,'','Mar-17',2,'Mar-17','','Yes','BYD buses will be new','Gillig purchase yes, others no','Gillig yes, others no','Planned','2016-12-27 21:46:08','2017-01-18 00:05:49',NULL),(13,'SamTrams','2016','Rosalie','','','','\0','','','ARBOC',50,'Low floor 40ft diesel BRT front',50,'Apr-17','Apr-17',0,'','',0,'',0,'','',0,'','',10,'paratransit minivans',10,'Jan-17','Jun-17',0,'','',9,'low floor, cutaways',9,'Jan-17','Jun-17',0,'','','Yes','','Yes','Yes','Planned','2016-12-27 21:46:08','2017-01-18 00:06:53',NULL),(16,'Central Contra Costa Transit Authority','2016','Anne Muzzini','muzzini@cccta.org','','','\0','\0','\0','',31,'low floor, BRT front',31,'Not sure when they are going on line - Scott Mitchell our Dir of Maint, 680-2090, would know','2017 some time - need to ask Scott',0,NULL,NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,0,NULL,0,NULL,NULL,0,NULL,NULL,'Same location as 33 buses put in service 3/2016',NULL,'Yes','Yes','Planned','2017-01-18 00:46:46','2017-01-18 00:46:46',NULL);
/*!40000 ALTER TABLE `devicesurvey` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expansiondetails`
--

DROP TABLE IF EXISTS `expansiondetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `expansiondetails` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `AdditionalVehicleCount` int(11) NOT NULL,
  `Agency` text NOT NULL,
  `CalendarYear` text,
  `DeliveryDate` datetime(6) NOT NULL,
  `HaveExistingVehicles` bit(1) NOT NULL,
  `ExistingVehicleDetails` text,
  `IncludedCosts` text,
  `Manufacturer` text,
  `ManufacturingDate` datetime(6) NOT NULL,
  `OtherManufacturer` text,
  `PreWireRequirements` text,
  `ReplacementVehicleDetails` text,
  `VehicleCount` int(11) NOT NULL,
  `UserName` text,
  `RecordStatus` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expansiondetails`
--

LOCK TABLES `expansiondetails` WRITE;
/*!40000 ALTER TABLE `expansiondetails` DISABLE KEYS */;
INSERT INTO `expansiondetails` VALUES (1,1,'AC Transit','Jan - Dec 2016','2017-01-20 17:48:00.000000','','somewhere','something else','Gillig','2016-12-21 17:49:00.000000',NULL,'something',NULL,2,NULL,'Planned');
/*!40000 ALTER TABLE `expansiondetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operators`
--

DROP TABLE IF EXISTS `operators`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operators` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operators`
--

LOCK TABLES `operators` WRITE;
/*!40000 ALTER TABLE `operators` DISABLE KEYS */;
INSERT INTO `operators` VALUES (1,'AC Transit'),(2,'County Connection'),(3,'Central Contra Costa Transit Authority'),(4,'Eastern Contra Costa Transit Authority'),(5,'FAST'),(6,'GGT'),(7,'LAVTA'),(8,'Marin Transit'),(9,'NVTA'),(10,'Petaluma Transit'),(11,'SamTrams'),(12,'SFMTA'),(13,'Santa Rosa City Bus'),(14,'SolTrans'),(15,'Sonoma County Transit'),(16,'Union City Transit'),(17,'Vacaville City Coach'),(18,'VTA'),(19,'WestCAT');
/*!40000 ALTER TABLE `operators` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reportingperiods`
--

DROP TABLE IF EXISTS `reportingperiods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reportingperiods` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reportingperiods`
--

LOCK TABLES `reportingperiods` WRITE;
/*!40000 ALTER TABLE `reportingperiods` DISABLE KEYS */;
INSERT INTO `reportingperiods` VALUES (1,'2016'),(2,'2016 Q1'),(3,'2016 Q2'),(4,'2016 Q3'),(5,'2016 Q4'),(6,'2017'),(7,'2017 Q1'),(8,'2017 Q2'),(9,'2017 Q3'),(10,'2017 Q4'),(11,'2018'),(12,'2018 Q1'),(13,'2018 Q2'),(14,'2018 Q3'),(15,'2018 Q4'),(16,'2019'),(17,'2019 Q1'),(18,'2019 Q2'),(19,'2019 Q3'),(20,'2019 Q4'),(21,'2020'),(22,'2020 Q1'),(23,'2020 Q2'),(24,'2020 Q3'),(25,'2020 Q4');
/*!40000 ALTER TABLE `reportingperiods` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-01-18 13:55:12
