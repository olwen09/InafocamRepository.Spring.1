-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: inafocamdb_dev
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20200709011048_initial','3.1.1'),('20200720162123_ComponentFileTypeTable','3.1.1'),('20200720170120_ResultsFromThePreviousPeriod','3.1.1'),('20200720171058_ResultsFromThePreviousPeriodCore','3.1.1'),('20200720173207_RemoveResultsFromThePreviousPeriodTable','3.1.1'),('20200720173318_ResultsFromThePreviousPeriodTableCorrection','3.1.1'),('20200720192647_ResultsFromThePreviousPeriodTableAddFileDesciptionColumn','3.1.1'),('20200720211355_AddStudentPracticeTypeTable','3.1.1'),('20200721142030_AddActionTypeTable','3.1.1'),('20200721164655_AddActivityTypeTable','3.1.1'),('20200721195002_AddScholarshipProgramTracingAgreementsWithPracticeCenterTable','3.1.1'),('20200721200847_ScholarshipProgramTracingAgreementsWithPracticeCenterTableCorrection','3.1.1'),('20200722144054_addAgreementWithInstitutionsRelatedToCurricularActivitiesTable','3.1.1'),('20200722164818_removeResultsFromThePreviousPeriodTable2','3.1.1'),('20200722164939_addResultsFromThePreviousPeriodTablecorrection2','3.1.1'),('20200723165208_tableScholarshipProgramTracingStudentSupportcorrection','3.1.1'),('20200727164511_addUniversityIdColumToTeacherTable','3.1.1'),('20200728161126_createDataBaseinafocamdb_dev','3.1.1'),('20200728192000_AddColunmUniversityIdAndperiodToSubjectMatterTable','3.1.1'),('20200729142827_RemoveColunmUniversityIdAndperiodToSubjectMatterTable','3.1.1'),('20200729153933_AddRelationShip_TracingStudyPlanDevelopmentAndScholarshipProgramUniversityToSubjectMatterTable','3.1.1'),('20200729164833_AddRelationShip_TracingStudyPlanDevelopmentToSubjectMatterTable','3.1.1'),('20200730021339_AddRelationShip_ScholarshipProgramTracingCourseAndScholarshipProgramTracingCourseFileTable','3.1.1'),('20200730165709_AddRelationShip_SubjectMatterAndTeacherTable','3.1.1'),('20200730210520_DrompForeingKeyUniversityFromTeachers','3.1.1'),('20200803152209_AddColumnMaleQuantityAndfemaleQuantityToTracingStudyPlanDevelopmentTable','3.1.1'),('20200803162236_AddColumnStudentReportFileToTracingStudyPlanDevelopmentTable','3.1.1'),('20200804181151_AddScholarshipProgramTracingStudentPracticeFileTable','3.1.1'),('20200807020229_addcolumnStudentPracticeTypeIdToScholarshipProgramTracingStudentPracticeFileTable','3.1.1'),('20200807134948_AddNationalityColumnToContactTable','3.1.1'),('20200807173641_AddUniverityPeriodColumnToTracingStudyPlanDevelopmentTable','3.1.1'),('20200810182421_AddontactCommunicationIdColumnToContact','3.1.1'),('20200811194326_addComponentFileTypeIdToResultsFromThePreviousPeriodTable','3.1.1'),('20200814184200_AddCommentTable','3.1.1'),('20200817125751_relationshipcorrection_CommentAndUsuario','3.1.1'),('20200817160205_AddReportTable','3.1.1'),('20200819211340_AddNormalizedDescriptionColumnToComment','3.1.1'),('20200820182718_AddStatusIdColumnToCommentTable','3.1.1'),('20200820220543_AddScholarshipProgramTracingAgreementDescriptionCorectionTable','3.1.1'),('20200821131326_ChangeScholarshipProgramTracingAgreementDescriptionIdColumnTypeToLong','3.1.1'),('20200821134404_AddScholarshipProgramTracingAgreementDescription1Column','3.1.1'),('20200821142429_AddScholarshipProgramUniversityAgreementColumns','3.1.1');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actiontype`
--

DROP TABLE IF EXISTS `ActionType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ActionType` (
  `ActionTypeId` bigint(20) NOT NULL AUTO_INCREMENT,
  `ActionTypeName` text,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `StatusId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`ActionTypeId`),
  KEY `IX_ActionType_StatusId` (`StatusId`),
  CONSTRAINT `FK_ActionType_status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ActionType`
--

LOCK TABLES `ActionType` WRITE;
/*!40000 ALTER TABLE `ActionType` DISABLE KEYS */;
INSERT INTO `ActionType` VALUES (1,'Distribución de los estudiantes por los centros',NULL,NULL,1),(2,'Asignación de  supervisores',NULL,NULL,1),(3,'Establecimiento de días y horas de práctica',NULL,NULL,1),(4,'Plan de seguimiento a las prácticas',NULL,NULL,1),(5,'Coordinación con los docentes de aula',NULL,NULL,1);
/*!40000 ALTER TABLE `ActionType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `activitytype`
--

DROP TABLE IF EXISTS `ActivityType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ActivityType` (
  `ActivityTypeId` bigint(20) NOT NULL AUTO_INCREMENT,
  `ActivityTypeName` text,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `StatusId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`ActivityTypeId`),
  KEY `IX_ActivityType_StatusId` (`StatusId`),
  CONSTRAINT `FK_ActivityType_status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ActivityType`
--

LOCK TABLES `ActivityType` WRITE;
/*!40000 ALTER TABLE `ActivityType` DISABLE KEYS */;
INSERT INTO `ActivityType` VALUES (1,'Coordina con el centro de práctica',NULL,NULL,1),(2,'Distribuye a los estudiantes por los centros',NULL,NULL,1),(3,'Coordina la práctica con los docentes de aula',NULL,NULL,1),(4,'Lleva el control de asistencia de los estudiantes',NULL,NULL,1),(5,'Gestiona aspectos logísticos (transporte, viáticos, etc.',NULL,NULL,1),(6,'Evalúa la práctica',NULL,NULL,1),(7,'Sistematiza el desarrollo de las prácticas',NULL,NULL,1);
/*!40000 ALTER TABLE `ActivityType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `address` (
  `address_id` bigint NOT NULL AUTO_INCREMENT,
  `address_type_id` bigint DEFAULT NULL,
  `country_id` bigint DEFAULT NULL,
  `province_id` bigint DEFAULT NULL,
  `city_id` bigint DEFAULT NULL,
  `address1` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `address2` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `home_number` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`address_id`) USING BTREE,
  KEY `FK_address_address_type` (`address_type_id`) USING BTREE,
  KEY `FK_address_city` (`city_id`) USING BTREE,
  KEY `FK_address_status` (`status_id`) USING BTREE,
  KEY `FK_address_user` (`creation_user_id`) USING BTREE,
  KEY `FK_address_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_address_province` (`province_id`) USING BTREE,
  KEY `IX_address_country_id` (`country_id`),
  CONSTRAINT `FK_address_address_type` FOREIGN KEY (`address_type_id`) REFERENCES `address_type` (`address_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_address_city` FOREIGN KEY (`city_id`) REFERENCES `city` (`city_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_address_country_country_id` FOREIGN KEY (`country_id`) REFERENCES `country` (`country_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_address_province` FOREIGN KEY (`province_id`) REFERENCES `province` (`province_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_address_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_address_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_address_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `address_type`
--

DROP TABLE IF EXISTS `address_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `address_type` (
  `address_type_id` bigint NOT NULL AUTO_INCREMENT,
  `address_type_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`address_type_id`) USING BTREE,
  KEY `FK_address_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_address_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address_type`
--

LOCK TABLES `address_type` WRITE;
/*!40000 ALTER TABLE `address_type` DISABLE KEYS */;
INSERT INTO `address_type` VALUES (1,'Residencial','2019-02-28 20:17:20',NULL,1);
/*!40000 ALTER TABLE `address_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agent`
--

DROP TABLE IF EXISTS `agent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agent` (
  `agent_id` bigint NOT NULL AUTO_INCREMENT,
  `agent_type_id` bigint NOT NULL DEFAULT '0',
  `user_id` bigint NOT NULL DEFAULT '0',
  `contact_id` bigint NOT NULL DEFAULT '0',
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`agent_id`) USING BTREE,
  KEY `FK_cordinator_user` (`creation_user_id`) USING BTREE,
  KEY `FK_cordinator_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_cordinator_status` (`status_id`) USING BTREE,
  KEY `FK_agent_agent_type` (`agent_type_id`) USING BTREE,
  KEY `FK_agent_user` (`user_id`) USING BTREE,
  CONSTRAINT `FK_agent_agent_type` FOREIGN KEY (`agent_type_id`) REFERENCES `agent_type` (`agent_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_agent_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_cordinator_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_cordinator_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_cordinator_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agent`
--

LOCK TABLES `agent` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `agent_type`
--

DROP TABLE IF EXISTS `agent_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agent_type` (
  `agent_type_id` bigint NOT NULL AUTO_INCREMENT,
  `agent_type_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`agent_type_id`) USING BTREE,
  KEY `FK_agent_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_agent_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agent_type`
--

LOCK TABLES `agent_type` WRITE;
/*!40000 ALTER TABLE `agent_type` DISABLE KEYS */;
INSERT INTO `agent_type` VALUES (1,'Cordinador','2019-03-26 10:19:21','2019-03-29 19:29:00',1),(2,'Tecnico','2019-03-26 10:19:29',NULL,1),(3,'Coordinador Responsable','2019-05-19 14:08:46',NULL,1),(4,'Ingeniero ','2020-07-09 10:49:54','2020-07-09 14:15:29',2);
/*!40000 ALTER TABLE `agent_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agreement_type`
--

DROP TABLE IF EXISTS `agreement_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agreement_type` (
  `agreement_type_id` bigint NOT NULL AUTO_INCREMENT,
  `agreement_type_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `agreement_panel_class` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY (`agreement_type_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agreement_type`
--

LOCK TABLES `agreement_type` WRITE;
/*!40000 ALTER TABLE `agreement_type` DISABLE KEYS */;
INSERT INTO `agreement_type` VALUES (1,'Pactado','panel-primary'),(2,'Convenido','panel-success');
/*!40000 ALTER TABLE `agreement_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agreementsinstitutionrelatedcocurricularactivities`
--

DROP TABLE IF EXISTS `agreementsinstitutionrelatedcocurricularactivities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agreementsinstitutionrelatedcocurricularactivities` (
  `AgreementsInstitutionRelatedCoCurricularActivitiesId` int NOT NULL AUTO_INCREMENT,
  `Institution` text,
  `ActivityDescription` text,
  `Date` datetime DEFAULT NULL,
  `Duration` text,
  `NumberOfParticipatingStudents` int DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `TracingId` int DEFAULT NULL,
  `StatusId` int DEFAULT NULL,
  `StatusId1` bigint DEFAULT NULL,
  `TracingScholarshipProgramTracingId` bigint DEFAULT NULL,
  PRIMARY KEY (`AgreementsInstitutionRelatedCoCurricularActivitiesId`),
  KEY `IX_AgreementsInstitutionRelatedCoCurricularActivities_StatusId1` (`StatusId1`),
  KEY `IX_AgreementsInstitutionRelatedCoCurricularActivities_TracingSc~` (`TracingScholarshipProgramTracingId`),
  CONSTRAINT `FK_AgreementsInstitutionRelatedCoCurricularActivities_scholarsh~` FOREIGN KEY (`TracingScholarshipProgramTracingId`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_AgreementsInstitutionRelatedCoCurricularActivities_status_St~` FOREIGN KEY (`StatusId1`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agreementsinstitutionrelatedcocurricularactivities`
--

LOCK TABLES `agreementsinstitutionrelatedcocurricularactivities` WRITE;
/*!40000 ALTER TABLE `agreementsinstitutionrelatedcocurricularactivities` DISABLE KEYS */;
/*!40000 ALTER TABLE `agreementsinstitutionrelatedcocurricularactivities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AgreementWithInstitutionsRelatedToCurricularActivities`
--

DROP TABLE IF EXISTS `AgreementWithInstitutionsRelatedToCurricularActivities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `AgreementWithInstitutionsRelatedToCurricularActivities` (
  `AgreementWithInstitutionsRelatedToCurricularActivitiesId` int NOT NULL AUTO_INCREMENT,
  `Institution` text,
  `ActivityDescription` text,
  `Date` datetime DEFAULT NULL,
  `Duration` text,
  `NumberOfParticipatingStudents` int DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `TracingId` int DEFAULT NULL,
  `StatusId` int DEFAULT NULL,
  `StatusId1` bigint DEFAULT NULL,
  `TracingScholarshipProgramTracingId` bigint DEFAULT NULL,
  PRIMARY KEY (`AgreementWithInstitutionsRelatedToCurricularActivitiesId`),
  KEY `IX_AgreementWithInstitutionsRelatedToCurricularActivities_Statu~` (`StatusId1`),
  KEY `IX_AgreementWithInstitutionsRelatedToCurricularActivities_Traci~` (`TracingScholarshipProgramTracingId`),
  CONSTRAINT `FK_AgreementWithInstitutionsRelatedToCurricularActivities_schol~` FOREIGN KEY (`TracingScholarshipProgramTracingId`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_AgreementWithInstitutionsRelatedToCurricularActivities_statu~` FOREIGN KEY (`StatusId1`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AgreementWithInstitutionsRelatedToCurricularActivities`
--

LOCK TABLES `AgreementWithInstitutionsRelatedToCurricularActivities` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `AspNetRoleClaims`
--

DROP TABLE IF EXISTS `AspNetRoleClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `AspNetRoleClaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(250) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetRoleClaims_role_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetRoleClaims`
--

LOCK TABLES `AspNetRoleClaims` WRITE;
/*!40000 ALTER TABLE `AspNetRoleClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoleClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserClaims`
--

DROP TABLE IF EXISTS `AspNetUserClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `AspNetUserClaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetUserClaims_usuario_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_usuario_UserId` FOREIGN KEY (`UserId`) REFERENCES `usuarios` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserClaims`
--

LOCK TABLES `AspNetUserClaims` WRITE;
/*!40000 ALTER TABLE `AspNetUserClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(250) NOT NULL,
  `ProviderKey` varchar(250) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(250) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `FK_AspNetUserLogins_usuario_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_usuario_UserId` FOREIGN KEY (`UserId`) REFERENCES `usuarios` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserRoles`
--

DROP TABLE IF EXISTS `AspNetUserRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(250) NOT NULL,
  `RoleId` varchar(250) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `FK_AspNetUserRoles_role_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`),
  CONSTRAINT `FK_AspNetUserRoles_usuario_UserId` FOREIGN KEY (`UserId`) REFERENCES `usuarios` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserRoles`
--

LOCK TABLES `AspNetUserRoles` WRITE;
/*!40000 ALTER TABLE `AspNetUserRoles` DISABLE KEYS */;
INSERT INTO `AspNetUserRoles` VALUES ('7062a917-b7ad-4918-9d3b-753c49670ade','72556015-cb72-4b89-a0ac-b902fbc4fd51'),('d460a177-dc06-43ac-a862-d82c35cc718c','72556015-cb72-4b89-a0ac-b902fbc4fd51'),('436668eb-ae2d-4153-a9f7-9e600357980b','7b9b75fc-efe9-4a41-84d5-add4ee1a6bd6'),('7062a917-b7ad-4918-9d3b-753c49670ade','817fe320-e3f5-4509-8d7a-a2e8ed8773af'),('d460a177-dc06-43ac-a862-d82c35cc718c','817fe320-e3f5-4509-8d7a-a2e8ed8773af'),('f82e26ab-ab78-4f06-a34e-2a964e886a59','817fe320-e3f5-4509-8d7a-a2e8ed8773af'),('52950434-522b-46a2-8712-54d9195ef981','b4c12dc2-14f1-4171-af8d-87aca893c366'),('7062a917-b7ad-4918-9d3b-753c49670ade','b4c12dc2-14f1-4171-af8d-87aca893c366'),('d460a177-dc06-43ac-a862-d82c35cc718c','b4c12dc2-14f1-4171-af8d-87aca893c366');
/*!40000 ALTER TABLE `AspNetUserRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(250) NOT NULL,
  `LoginProvider` varchar(250) NOT NULL,
  `Name` varchar(250) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_usuario_UserId` FOREIGN KEY (`UserId`) REFERENCES `usuarios` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `city` (
  `city_id` bigint NOT NULL AUTO_INCREMENT,
  `country_id` bigint DEFAULT NULL,
  `province_id` bigint DEFAULT NULL,
  `city_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `city_short_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`city_id`) USING BTREE,
  KEY `FK_city_country` (`country_id`) USING BTREE,
  KEY `FK_city_status` (`status_id`) USING BTREE,
  KEY `FK_city_province` (`province_id`) USING BTREE,
  CONSTRAINT `FK_city_country` FOREIGN KEY (`country_id`) REFERENCES `country` (`country_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_city_province` FOREIGN KEY (`province_id`) REFERENCES `province` (`province_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_city_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=154 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,65,1,'SANTO DOMINGO DE GUZMÁN',NULL,'2019-02-28 13:31:44',NULL,1),(2,65,2,'AZUA',NULL,'2019-02-28 13:31:44',NULL,1),(3,65,2,'LAS CHARCAS',NULL,'2019-02-28 13:31:44',NULL,1),(4,65,2,'LAS YAYAS DE VIAJAMA',NULL,'2019-02-28 13:31:44',NULL,1),(5,65,2,'PADRE LAS CASAS',NULL,'2019-02-28 13:31:44',NULL,1),(6,65,2,'PERALTA',NULL,'2019-02-28 13:31:44',NULL,1),(7,65,2,'SABANA YEGUA',NULL,'2019-02-28 13:31:44',NULL,1),(8,65,2,'PUEBLO VIEJO',NULL,'2019-02-28 13:31:44',NULL,1),(9,65,2,'TÁBARA ARRIBA',NULL,'2019-02-28 13:31:44',NULL,1),(10,65,2,'GUAYABAL',NULL,'2019-02-28 13:31:44',NULL,1),(11,65,2,'ESTEBANÍA',NULL,'2019-02-28 13:31:44',NULL,1),(12,65,3,'NEIBA',NULL,'2019-02-28 13:31:44',NULL,1),(13,65,3,'GALVÁN',NULL,'2019-02-28 13:31:44',NULL,1),(14,65,3,'TAMAYO',NULL,'2019-02-28 13:31:44',NULL,1),(15,65,3,'VILLA JARAGUA',NULL,'2019-02-28 13:31:44',NULL,1),(16,65,3,'LOS RÍOS',NULL,'2019-02-28 13:31:44',NULL,1),(17,65,4,'BARAHONA',NULL,'2019-02-28 13:31:44',NULL,1),(18,65,4,'CABRAL',NULL,'2019-02-28 13:31:44',NULL,1),(19,65,4,'ENRIQUILLO',NULL,'2019-02-28 13:31:44',NULL,1),(20,65,4,'PARAÍSO',NULL,'2019-02-28 13:31:44',NULL,1),(21,65,4,'VICENTE NOBLE',NULL,'2019-02-28 13:31:44',NULL,1),(22,65,4,'EL PEÑÓN',NULL,'2019-02-28 13:31:44',NULL,1),(23,65,4,'LA CIÉNAGA',NULL,'2019-02-28 13:31:44',NULL,1),(24,65,4,'FUNDACIÓN',NULL,'2019-02-28 13:31:44',NULL,1),(25,65,4,'LAS SALINAS',NULL,'2019-02-28 13:31:44',NULL,1),(26,65,4,'POLO',NULL,'2019-02-28 13:31:44',NULL,1),(27,65,4,'JAQUIMEYES',NULL,'2019-02-28 13:31:44',NULL,1),(28,65,5,'DAJABÓN',NULL,'2019-02-28 13:31:44',NULL,1),(29,65,5,'LOMA DE CABRERA',NULL,'2019-02-28 13:31:44',NULL,1),(30,65,5,'PARTIDO',NULL,'2019-02-28 13:31:44',NULL,1),(31,65,5,'RESTAURACIÓN',NULL,'2019-02-28 13:31:44',NULL,1),(32,65,5,'EL PINO',NULL,'2019-02-28 13:31:44',NULL,1),(33,65,6,'SAN FRANCISCO DE MACORÍS',NULL,'2019-02-28 13:31:44',NULL,1),(34,65,6,'ARENOSO',NULL,'2019-02-28 13:31:44',NULL,1),(35,65,6,'CASTILLO',NULL,'2019-02-28 13:31:44',NULL,1),(36,65,6,'PIMENTEL',NULL,'2019-02-28 13:31:44',NULL,1),(37,65,6,'VILLA RIVA',NULL,'2019-02-28 13:31:44',NULL,1),(38,65,6,'LAS GUÁRANAS',NULL,'2019-02-28 13:31:44',NULL,1),(39,65,6,'EUGENIO MARÍA DE HOSTOS',NULL,'2019-02-28 13:31:44',NULL,1),(40,65,7,'COMENDADOR',NULL,'2019-02-28 13:31:44',NULL,1),(41,65,7,'BÁNICA',NULL,'2019-02-28 13:31:44',NULL,1),(42,65,7,'EL LLANO',NULL,'2019-02-28 13:31:44',NULL,1),(43,65,7,'HONDO VALLE',NULL,'2019-02-28 13:31:44',NULL,1),(44,65,7,'PEDRO SANTANA',NULL,'2019-02-28 13:31:44',NULL,1),(45,65,7,'JUAN SANTIAGO',NULL,'2019-02-28 13:31:44',NULL,1),(46,65,8,'EL SEIBO',NULL,'2019-02-28 13:31:44',NULL,1),(47,65,8,'MICHES',NULL,'2019-02-28 13:31:44',NULL,1),(48,65,9,'MOCA',NULL,'2019-02-28 13:31:44',NULL,1),(49,65,9,'CAYETANO GERMOSÈN',NULL,'2019-02-28 13:31:44',NULL,1),(50,65,9,'GASPAR HERNÁNDEZ',NULL,'2019-02-28 13:31:44',NULL,1),(51,65,9,'JAMAO AL NORTE',NULL,'2019-02-28 13:31:44',NULL,1),(52,65,10,'JIMANÍ',NULL,'2019-02-28 13:31:44',NULL,1),(53,65,10,'DUVERGÉ',NULL,'2019-02-28 13:31:44',NULL,1),(54,65,10,'LA DESCUBIERTA',NULL,'2019-02-28 13:31:44',NULL,1),(55,65,10,'POSTRER RÍO',NULL,'2019-02-28 13:31:44',NULL,1),(56,65,10,'CRISTÓBAL',NULL,'2019-02-28 13:31:44',NULL,1),(57,65,10,'MELLA',NULL,'2019-02-28 13:31:44',NULL,1),(58,65,11,'HIGÜEY',NULL,'2019-02-28 13:31:44',NULL,1),(59,65,11,'SAN RAFAEL DEL YUMA',NULL,'2019-02-28 13:31:44',NULL,1),(60,65,12,'LA ROMANA',NULL,'2019-02-28 13:31:44',NULL,1),(61,65,12,'GUAYMATE',NULL,'2019-02-28 13:31:44',NULL,1),(62,65,12,'VILLA HERMOSA',NULL,'2019-02-28 13:31:44',NULL,1),(63,65,13,'LA VEGA',NULL,'2019-02-28 13:31:44',NULL,1),(64,65,13,'CONSTANZA',NULL,'2019-02-28 13:31:44',NULL,1),(65,65,13,'JARABACOA',NULL,'2019-02-28 13:31:44',NULL,1),(66,65,13,'JIMA ABAJO',NULL,'2019-02-28 13:31:44',NULL,1),(67,65,14,'NAGUA',NULL,'2019-02-28 13:31:44',NULL,1),(68,65,14,'CABRERA',NULL,'2019-02-28 13:31:44',NULL,1),(69,65,14,'EL FACTOR',NULL,'2019-02-28 13:31:44',NULL,1),(70,65,14,'RÍO SAN JUAN',NULL,'2019-02-28 13:31:44',NULL,1),(71,65,15,'MONTE CRISTI',NULL,'2019-02-28 13:31:44',NULL,1),(72,65,15,'CASTAÑUELAS',NULL,'2019-02-28 13:31:44',NULL,1),(73,65,15,'GUAYUBÍN',NULL,'2019-02-28 13:31:44',NULL,1),(74,65,15,'LAS MATAS DE SANTA CRUZ',NULL,'2019-02-28 13:31:44',NULL,1),(75,65,15,'PEPILLO SALCEDO (MANZANILLO)',NULL,'2019-02-28 13:31:44',NULL,1),(76,65,15,'VILLA VÁSQUEZ',NULL,'2019-02-28 13:31:44',NULL,1),(77,65,16,'PEDERNALES',NULL,'2019-02-28 13:31:44',NULL,1),(78,65,16,'OVIEDO',NULL,'2019-02-28 13:31:44',NULL,1),(79,65,17,'BANÍ',NULL,'2019-02-28 13:31:44',NULL,1),(80,65,17,'NIZAO',NULL,'2019-02-28 13:31:44',NULL,1),(81,65,18,'PUERTO PLATA',NULL,'2019-02-28 13:31:44',NULL,1),(82,65,18,'ALTAMIRA',NULL,'2019-02-28 13:31:44',NULL,1),(83,65,18,'GUANANICO',NULL,'2019-02-28 13:31:44',NULL,1),(84,65,18,'IMBERT',NULL,'2019-02-28 13:31:44',NULL,1),(85,65,18,'LOS HIDALGOS',NULL,'2019-02-28 13:31:44',NULL,1),(86,65,18,'LUPERÓN',NULL,'2019-02-28 13:31:44',NULL,1),(87,65,18,'SOSÚA',NULL,'2019-02-28 13:31:44',NULL,1),(88,65,18,'VILLA ISABELA',NULL,'2019-02-28 13:31:44',NULL,1),(89,65,18,'VILLA MONTELLANO',NULL,'2019-02-28 13:31:44',NULL,1),(90,65,19,'SALCEDO',NULL,'2019-02-28 13:31:44',NULL,1),(91,65,19,'TENARES',NULL,'2019-02-28 13:31:44',NULL,1),(92,65,19,'VILLA TAPIA',NULL,'2019-02-28 13:31:44',NULL,1),(93,65,20,'SAMANÁ',NULL,'2019-02-28 13:31:44',NULL,1),(94,65,20,'SÁNCHEZ',NULL,'2019-02-28 13:31:44',NULL,1),(95,65,20,'LAS TERRENAS',NULL,'2019-02-28 13:31:44',NULL,1),(96,65,21,'SAN CRISTÓBAL',NULL,'2019-02-28 13:31:44',NULL,1),(97,65,21,'SABANA GRANDE DE PALENQUE',NULL,'2019-02-28 13:31:44',NULL,1),(98,65,21,'BAJOS DE HAINA',NULL,'2019-02-28 13:31:44',NULL,1),(99,65,21,'CAMBITA GARABITOS',NULL,'2019-02-28 13:31:44',NULL,1),(100,65,21,'VILLA ALTAGRACIA',NULL,'2019-02-28 13:31:44',NULL,1),(101,65,21,'YAGUATE',NULL,'2019-02-28 13:31:44',NULL,1),(102,65,21,'SAN GREGORIO DE NIGUA',NULL,'2019-02-28 13:31:44',NULL,1),(103,65,21,'LOS CACAOS',NULL,'2019-02-28 13:31:44',NULL,1),(104,65,22,'BOHECHÍO',NULL,'2019-02-28 13:31:44',NULL,1),(105,65,22,'EL CERCADO',NULL,'2019-02-28 13:31:44',NULL,1),(106,65,22,'JUAN DE HERRERA',NULL,'2019-02-28 13:31:44',NULL,1),(107,65,22,'LAS MATAS DE FARFÁN',NULL,'2019-02-28 13:31:44',NULL,1),(108,65,22,'VALLEJUELO',NULL,'2019-02-28 13:31:44',NULL,1),(109,65,23,'SAN PEDRO DE MACORÍS',NULL,'2019-02-28 13:31:44',NULL,1),(110,65,23,'LOS LLANOS',NULL,'2019-02-28 13:31:44',NULL,1),(111,65,23,'RAMÓN SANTANA',NULL,'2019-02-28 13:31:44',NULL,1),(112,65,23,'CONSUELO',NULL,'2019-02-28 13:31:44',NULL,1),(113,65,23,'QUISQUEYA',NULL,'2019-02-28 13:31:44',NULL,1),(114,65,23,'GUAYACANES',NULL,'2019-02-28 13:31:44',NULL,1),(115,65,24,'COTUÍ',NULL,'2019-02-28 13:31:44',NULL,1),(116,65,24,'CEVICOS',NULL,'2019-02-28 13:31:44',NULL,1),(117,65,24,'FANTINO',NULL,'2019-02-28 13:31:44',NULL,1),(118,65,24,'LA MATA',NULL,'2019-02-28 13:31:44',NULL,1),(119,65,25,'SANTIAGO',NULL,'2019-02-28 13:31:44',NULL,1),(120,65,25,'BISONÓ',NULL,'2019-02-28 13:31:44',NULL,1),(121,65,25,'JÁNICO',NULL,'2019-02-28 13:31:44',NULL,1),(122,65,25,'LICEY AL MEDIO',NULL,'2019-02-28 13:31:44',NULL,1),(123,65,25,'SAN JOSÉ DE LAS MATAS',NULL,'2019-02-28 13:31:44',NULL,1),(124,65,25,'TAMBORIL',NULL,'2019-02-28 13:31:44',NULL,1),(125,65,25,'VILLA GONZÁLEZ',NULL,'2019-02-28 13:31:44',NULL,1),(126,65,25,'PUÑAL',NULL,'2019-02-28 13:31:44',NULL,1),(127,65,26,'SAN IGNACIO DE SABANETA',NULL,'2019-02-28 13:31:44',NULL,1),(128,65,26,'VILLA LOS ALMÁCIGOS',NULL,'2019-02-28 13:31:44',NULL,1),(129,65,26,'MONCIÓN',NULL,'2019-02-28 13:31:44',NULL,1),(130,65,27,'MAO',NULL,'2019-02-28 13:31:44',NULL,1),(131,65,27,'ESPERANZA',NULL,'2019-02-28 13:31:44',NULL,1),(132,65,27,'LAGUNA SALADA',NULL,'2019-02-28 13:31:44',NULL,1),(133,65,28,'BONAO',NULL,'2019-02-28 13:31:44',NULL,1),(134,65,28,'MAIMÓN',NULL,'2019-02-28 13:31:44',NULL,1),(135,65,28,'PIEDRA BLANCA',NULL,'2019-02-28 13:31:44',NULL,1),(136,65,29,'MONTE PLATA',NULL,'2019-02-28 13:31:44',NULL,1),(137,65,29,'BAYAGUANA',NULL,'2019-02-28 13:31:44',NULL,1),(138,65,29,'SABANA GRANDE DE BOYÁ',NULL,'2019-02-28 13:31:44',NULL,1),(139,65,29,'YAMASÁ',NULL,'2019-02-28 13:31:44',NULL,1),(140,65,29,'PERALVILLO',NULL,'2019-02-28 13:31:44',NULL,1),(141,65,30,'HATO MAYOR',NULL,'2019-02-28 13:31:44',NULL,1),(142,65,30,'SABANA DE LA MAR',NULL,'2019-02-28 13:31:44',NULL,1),(143,65,30,'EL VALLE',NULL,'2019-02-28 13:31:44',NULL,1),(144,65,31,'SAN JOSÉ DE OCOA',NULL,'2019-02-28 13:31:44',NULL,1),(145,65,31,'SABANA LARGA',NULL,'2019-02-28 13:31:44',NULL,1),(146,65,31,'RANCHO ARRIBA',NULL,'2019-02-28 13:31:44',NULL,1),(147,65,32,'SANTO DOMINGO ESTE',NULL,'2019-02-28 13:31:44',NULL,1),(148,65,32,'SANTO DOMINGO OESTE',NULL,'2019-02-28 13:31:44',NULL,1),(149,65,32,'SANTO DOMINGO NORTE',NULL,'2019-02-28 13:31:44',NULL,1),(150,65,32,'BOCA CHICA',NULL,'2019-02-28 13:31:44',NULL,1),(151,65,32,'SAN ANTONIO DE GUERRA',NULL,'2019-02-28 13:31:44',NULL,1),(152,65,32,'LOS ALCARRIZOS',NULL,'2019-02-28 13:31:44',NULL,1),(153,65,32,'PEDRO BRAND',NULL,'2019-02-28 13:31:44',NULL,1);
/*!40000 ALTER TABLE `city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comment`
--

DROP TABLE IF EXISTS `comment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comment` (
  `CommentId` bigint NOT NULL AUTO_INCREMENT,
  `Comments` text,
  `Description` text NOT NULL,
  `NormalizedDescription` varchar(100) DEFAULT NULL,
  `CommentScreen` text NOT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `ScholarshipProgramTracingId` bigint DEFAULT NULL,
  `CreationDate` datetime NOT NULL,
  `UpgradeDate` datetime NOT NULL,
  `StatusId` bigint NOT NULL DEFAULT '0',
  PRIMARY KEY (`CommentId`),
  KEY `IX_Comment_ScholarshipProgramTracingId` (`ScholarshipProgramTracingId`),
  KEY `IX_Comment_CreatorUserId` (`CreatorUserId`),
  KEY `IX_Comment_StatusId` (`StatusId`),
  CONSTRAINT `FK_Comment_scholarship_program_tracing_ScholarshipProgramTracin~` FOREIGN KEY (`ScholarshipProgramTracingId`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Comment_status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`status_id`),
  CONSTRAINT `FK_Comment_Usuarios_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `usuarios` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comment`
--

LOCK TABLES `comment` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `communication`
--

DROP TABLE IF EXISTS `communication`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `communication` (
  `communication_id` bigint NOT NULL AUTO_INCREMENT,
  `communication_phone_number1` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `communication_phone_number2` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `communication_email` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `communication_website` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`communication_id`) USING BTREE,
  KEY `FK_communication_user` (`creation_user_id`) USING BTREE,
  KEY `FK_communication_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_communication_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_communication_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_communication_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_communication_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `communication`
--

LOCK TABLES `communication` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `company_id` bigint NOT NULL AUTO_INCREMENT,
  `contact_id` bigint DEFAULT NULL,
  `address_id` bigint DEFAULT NULL,
  `communication_id` bigint DEFAULT NULL,
  `company_type_id` bigint DEFAULT NULL,
  `manager_id` bigint DEFAULT NULL,
  `owner_id` bigint DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`company_id`) USING BTREE,
  KEY `FK_company_address` (`address_id`) USING BTREE,
  KEY `FK_company_communication` (`communication_id`) USING BTREE,
  KEY `FK_company_company_type` (`company_type_id`) USING BTREE,
  KEY `FK_company_user` (`manager_id`) USING BTREE,
  KEY `FK_company_user_2` (`owner_id`) USING BTREE,
  KEY `FK_company_status` (`status_id`) USING BTREE,
  KEY `FK_company_user_3` (`creation_user_id`) USING BTREE,
  KEY `FK_company_user_4` (`upgrade_user_id`) USING BTREE,
  KEY `FK_company_contact` (`contact_id`) USING BTREE,
  CONSTRAINT `FK_company_address` FOREIGN KEY (`address_id`) REFERENCES `address` (`address_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_company_communication` FOREIGN KEY (`communication_id`) REFERENCES `communication` (`communication_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_company_company_type` FOREIGN KEY (`company_type_id`) REFERENCES `company_type` (`company_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_company_contact` FOREIGN KEY (`contact_id`) REFERENCES `contact` (`contact_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_company_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_company_user` FOREIGN KEY (`manager_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_company_user_2` FOREIGN KEY (`owner_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_company_user_3` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_company_user_4` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company_type`
--

DROP TABLE IF EXISTS `company_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company_type` (
  `company_type_id` bigint NOT NULL AUTO_INCREMENT,
  `company_type_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`company_type_id`) USING BTREE,
  KEY `FK_company_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_company_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company_type`
--

LOCK TABLES `company_type` WRITE;
/*!40000 ALTER TABLE `company_type` DISABLE KEYS */;
INSERT INTO `company_type` VALUES (1,'Sociedad Comercial',NULL,NULL,NULL);
/*!40000 ALTER TABLE `company_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `component_file_type`
--

DROP TABLE IF EXISTS `component_file_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `component_file_type` (
  `ComponentFileTypeId` bigint NOT NULL AUTO_INCREMENT,
  `ComponentFileTypeName` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`ComponentFileTypeId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `component_file_type`
--

LOCK TABLES `component_file_type` WRITE;
/*!40000 ALTER TABLE `component_file_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `component_file_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ComponentFileTypes`
--

DROP TABLE IF EXISTS `ComponentFileTypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ComponentFileTypes` (
  `ComponentFileTypeId` int NOT NULL AUTO_INCREMENT,
  `ComponentFileTypeName` text,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  PRIMARY KEY (`ComponentFileTypeId`),
  KEY `FK_ComponentFileTypes_status_StatusId` (`StatusId`),
  CONSTRAINT `FK_ComponentFileTypes_status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ComponentFileTypes`
--

LOCK TABLES `ComponentFileTypes` WRITE;
/*!40000 ALTER TABLE `ComponentFileTypes` DISABLE KEYS */;
INSERT INTO `ComponentFileTypes` VALUES (1,'Estudiantes que realizaron su práctica','2020-07-20 12:28:36',NULL,NULL),(2,'Estudiantes que promovieron su práctica','2020-07-20 12:31:51',NULL,NULL),(3,'Centros que recibieron practicantes','2020-07-20 12:32:33',NULL,NULL),(4,'Supervisores de prácticas','2020-07-20 12:33:17',NULL,NULL),(5,'Capacitaciones al personal de práctica','2020-07-20 12:33:50',NULL,NULL),(6,'Docentes de aulas que recibieron practicantes','2020-07-20 12:34:25',NULL,NULL),(7,'Convenios nuevos  firmados','2020-07-20 12:34:51',NULL,NULL),(8,'Convenios actualizados','2020-07-20 12:35:18',NULL,NULL),(9,'Divulgación de resultados','2020-07-20 12:35:44',NULL,NULL);
/*!40000 ALTER TABLE `ComponentFileTypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contact` (
  `contact_id` bigint NOT NULL AUTO_INCREMENT,
  `document_type_id` bigint DEFAULT NULL,
  `contact_document_number` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `contact_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `contact_lastname` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `contact_gender` enum('female','male','none') CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `contact_type_id` bigint DEFAULT NULL,
  `contact_comment` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `contact_born_date` date DEFAULT NULL,
  `contact_born_place` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `contact_nationality_id` bigint DEFAULT NULL,
  `contact_marital_status_id` bigint DEFAULT NULL,
  `contact_job_information_id` bigint DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  `Nationality` varchar(50) DEFAULT NULL,
  `ContactCommunicationId1` bigint DEFAULT NULL,
  `ContactCommunicationId` bigint DEFAULT NULL,
  PRIMARY KEY (`contact_id`) USING BTREE,
  UNIQUE KEY `contact_document_number` (`contact_document_number`) USING BTREE,
  KEY `FK_contact_document_type` (`document_type_id`) USING BTREE,
  KEY `FK_contact_user` (`creation_user_id`) USING BTREE,
  KEY `FK_contact_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_contact_status` (`status_id`) USING BTREE,
  KEY `FK_contact_contact_type` (`contact_type_id`) USING BTREE,
  KEY `IX_contact_ContactCommunicationId` (`ContactCommunicationId1`),
  CONSTRAINT `FK_contact_contact_communication_ContactCommunicationId` FOREIGN KEY (`ContactCommunicationId1`) REFERENCES `contact_communication` (`contact_communication_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_contact_contact_type` FOREIGN KEY (`contact_type_id`) REFERENCES `contact_type` (`contact_type_id`) ON DELETE SET NULL ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_document_type` FOREIGN KEY (`document_type_id`) REFERENCES `document_type` (`document_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact`
--

LOCK TABLES `contact` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `contact_address`
--

DROP TABLE IF EXISTS `contact_address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contact_address` (
  `contact_address_id` bigint NOT NULL AUTO_INCREMENT,
  `contact_id` bigint DEFAULT NULL,
  `address_id` bigint DEFAULT NULL,
  `contact_address_comment` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`contact_address_id`) USING BTREE,
  KEY `FK_contact_address_contact` (`contact_id`) USING BTREE,
  KEY `FK_contact_address_address` (`address_id`) USING BTREE,
  KEY `FK_contact_address_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_contact_address_address` FOREIGN KEY (`address_id`) REFERENCES `address` (`address_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_address_contact` FOREIGN KEY (`contact_id`) REFERENCES `contact` (`contact_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_address_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact_address`
--

LOCK TABLES `contact_address` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `contact_communication`
--

DROP TABLE IF EXISTS `contact_communication`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contact_communication` (
  `contact_communication_id` bigint NOT NULL AUTO_INCREMENT,
  `contact_id` bigint DEFAULT NULL,
  `communication_id` bigint DEFAULT NULL,
  `contact_communication_comment` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`contact_communication_id`) USING BTREE,
  KEY `FK_contact_communication_contact` (`contact_id`) USING BTREE,
  KEY `FK_contact_communication_communication` (`communication_id`) USING BTREE,
  KEY `FK_contact_communication_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_contact_communication_communication` FOREIGN KEY (`communication_id`) REFERENCES `communication` (`communication_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_communication_contact` FOREIGN KEY (`contact_id`) REFERENCES `contact` (`contact_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_communication_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact_communication`
--

LOCK TABLES `contact_communication` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `contact_type`
--

DROP TABLE IF EXISTS `contact_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contact_type` (
  `contact_type_id` bigint NOT NULL AUTO_INCREMENT,
  `contact_type_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `document_type_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`contact_type_id`) USING BTREE,
  KEY `FK_contact_type_document_type` (`document_type_id`) USING BTREE,
  KEY `FK_contact_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_contact_type_document_type` FOREIGN KEY (`document_type_id`) REFERENCES `document_type` (`document_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_contact_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact_type`
--

LOCK TABLES `contact_type` WRITE;
/*!40000 ALTER TABLE `contact_type` DISABLE KEYS */;
INSERT INTO `contact_type` VALUES (1,'Personal Física',1,'2019-02-28 18:30:56',NULL,1),(2,'Empresa',2,'2019-02-28 18:30:58',NULL,1),(3,'Extranjero',3,'2019-02-28 18:31:05',NULL,1),(4,'Otros',4,'2019-03-17 13:45:51',NULL,1);
/*!40000 ALTER TABLE `contact_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `country` (
  `country_id` bigint NOT NULL AUTO_INCREMENT,
  `country_short_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `country_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`country_id`) USING BTREE,
  KEY `FK_country_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_country_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=241 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'AF','Afganistán','2020-08-10 10:39:23',NULL,1),(2,'AX','Islas Gland','2020-08-10 10:39:23',NULL,1),(3,'AL','Albania','2020-08-10 10:39:23',NULL,1),(4,'DE','Alemania','2020-08-10 10:39:23',NULL,1),(5,'AD','Andorra','2020-08-10 10:39:24',NULL,1),(6,'AO','Angola','2020-08-10 10:39:24',NULL,1),(7,'AI','Anguilla','2020-08-10 10:39:24',NULL,1),(8,'AQ','Antártida','2020-08-10 10:39:24',NULL,1),(9,'AG','Antigua y Barbuda','2020-08-10 10:39:24',NULL,1),(10,'AN','Antillas Holandesas','2020-08-10 10:39:24',NULL,1),(11,'SA','Arabia Saudí','2020-08-10 10:39:24',NULL,1),(12,'DZ','Argelia','2020-08-10 10:39:24',NULL,1),(13,'AR','Argentina','2020-08-10 10:39:24',NULL,1),(14,'AM','Armenia','2020-08-10 10:39:24',NULL,1),(15,'AW','Aruba','2020-08-10 10:39:24',NULL,1),(16,'AU','Australia','2020-08-10 10:39:24',NULL,1),(17,'AT','Austria','2020-08-10 10:39:24',NULL,1),(18,'AZ','Azerbaiyán','2020-08-10 10:39:24',NULL,1),(19,'BS','Bahamas','2020-08-10 10:39:24',NULL,1),(20,'BH','Bahréin','2020-08-10 10:39:24',NULL,1),(21,'BD','Bangladesh','2020-08-10 10:39:24',NULL,1),(22,'BB','Barbados','2020-08-10 10:39:24',NULL,1),(23,'BY','Bielorrusia','2020-08-10 10:39:24',NULL,1),(24,'BE','Bélgica','2020-08-10 10:39:24',NULL,1),(25,'BZ','Belice','2020-08-10 10:39:24',NULL,1),(26,'BJ','Benin','2020-08-10 10:39:24',NULL,1),(27,'BM','Bermudas','2020-08-10 10:39:24',NULL,1),(28,'BT','Bhután','2020-08-10 10:39:24',NULL,1),(29,'BO','Bolivia','2020-08-10 10:39:24',NULL,1),(30,'BA','Bosnia y Herzegovina','2020-08-10 10:39:24',NULL,1),(31,'BW','Botsuana','2020-08-10 10:39:24',NULL,1),(32,'BV','Isla Bouvet','2020-08-10 10:39:24',NULL,1),(33,'BR','Brasil','2020-08-10 10:39:24',NULL,1),(34,'BN','Brunéi','2020-08-10 10:39:24',NULL,1),(35,'BG','Bulgaria','2020-08-10 10:39:24',NULL,1),(36,'BF','Burkina Faso','2020-08-10 10:39:24',NULL,1),(37,'BI','Burundi','2020-08-10 10:39:24',NULL,1),(38,'CV','Cabo Verde','2020-08-10 10:39:24',NULL,1),(39,'KY','Islas Caimán','2020-08-10 10:39:24',NULL,1),(40,'KH','Camboya','2020-08-10 10:39:24',NULL,1),(41,'CM','Camerún','2020-08-10 10:39:24',NULL,1),(42,'CA','Canadá','2020-08-10 10:39:24',NULL,1),(43,'CF','República Centroafricana','2020-08-10 10:39:24',NULL,1),(44,'TD','Chad','2020-08-10 10:39:24',NULL,1),(45,'CZ','República Checa','2020-08-10 10:39:24',NULL,1),(46,'CL','Chile','2020-08-10 10:39:24',NULL,1),(47,'CN','China','2020-08-10 10:39:24',NULL,1),(48,'CY','Chipre','2020-08-10 10:39:24',NULL,1),(49,'CX','Isla de Navidad','2020-08-10 10:39:24',NULL,1),(50,'VA','Ciudad del Vaticano','2020-08-10 10:39:24',NULL,1),(51,'CC','Islas Cocos','2020-08-10 10:39:24',NULL,1),(52,'CO','Colombia','2020-08-10 10:39:24',NULL,1),(53,'KM','Comoras','2020-08-10 10:39:24',NULL,1),(54,'CD','República Democrática del Congo','2020-08-10 10:39:24',NULL,1),(55,'CG','Congo','2020-08-10 10:39:24',NULL,1),(56,'CK','Islas Cook','2020-08-10 10:39:24',NULL,1),(57,'KP','Corea del Norte','2020-08-10 10:39:24',NULL,1),(58,'KR','Corea del Sur','2020-08-10 10:39:24',NULL,1),(59,'CI','Costa de Marfil','2020-08-10 10:39:24',NULL,1),(60,'CR','Costa Rica','2020-08-10 10:39:24',NULL,1),(61,'HR','Croacia','2020-08-10 10:39:24',NULL,1),(62,'CU','Cuba','2020-08-10 10:39:24',NULL,1),(63,'DK','Dinamarca','2020-08-10 10:39:24',NULL,1),(64,'DM','Dominica','2020-08-10 10:39:24',NULL,1),(65,'DO','República Dominicana','2020-08-10 10:39:24',NULL,1),(66,'EC','Ecuador','2020-08-10 10:39:24',NULL,1),(67,'EG','Egipto','2020-08-10 10:39:24',NULL,1),(68,'SV','El Salvador','2020-08-10 10:39:24',NULL,1),(69,'AE','Emiratos Árabes Unidos','2020-08-10 10:39:24',NULL,1),(70,'ER','Eritrea','2020-08-10 10:39:24',NULL,1),(71,'SK','Eslovaquia','2020-08-10 10:39:24',NULL,1),(72,'SI','Eslovenia','2020-08-10 10:39:24',NULL,1),(73,'ES','España','2020-08-10 10:39:24',NULL,1),(74,'UM','Islas ultramarinas de Estados Unidos','2020-08-10 10:39:24',NULL,1),(75,'US','Estados Unidos','2020-08-10 10:39:24',NULL,1),(76,'EE','Estonia','2020-08-10 10:39:24',NULL,1),(77,'ET','Etiopía','2020-08-10 10:39:24',NULL,1),(78,'FO','Islas Feroe','2020-08-10 10:39:24',NULL,1),(79,'PH','Filipinas','2020-08-10 10:39:24',NULL,1),(80,'FI','Finlandia','2020-08-10 10:39:24',NULL,1),(81,'FJ','Fiyi','2020-08-10 10:39:24',NULL,1),(82,'FR','Francia','2020-08-10 10:39:24',NULL,1),(83,'GA','Gabón','2020-08-10 10:39:24',NULL,1),(84,'GM','Gambia','2020-08-10 10:39:24',NULL,1),(85,'GE','Georgia','2020-08-10 10:39:24',NULL,1),(86,'GS','Islas Georgias del Sur y Sandwich del Sur','2020-08-10 10:39:24',NULL,1),(87,'GH','Ghana','2020-08-10 10:39:24',NULL,1),(88,'GI','Gibraltar','2020-08-10 10:39:24',NULL,1),(89,'GD','Granada','2020-08-10 10:39:24',NULL,1),(90,'GR','Grecia','2020-08-10 10:39:24',NULL,1),(91,'GL','Groenlandia','2020-08-10 10:39:24',NULL,1),(92,'GP','Guadalupe','2020-08-10 10:39:24',NULL,1),(93,'GU','Guam','2020-08-10 10:39:24',NULL,1),(94,'GT','Guatemala','2020-08-10 10:39:24',NULL,1),(95,'GF','Guayana Francesa','2020-08-10 10:39:24',NULL,1),(96,'GN','Guinea','2020-08-10 10:39:24',NULL,1),(97,'GQ','Guinea Ecuatorial','2020-08-10 10:39:24',NULL,1),(98,'GW','Guinea-Bissau','2020-08-10 10:39:24',NULL,1),(99,'GY','Guyana','2020-08-10 10:39:24',NULL,1),(100,'HT','Haití','2020-08-10 10:39:24',NULL,1),(101,'HM','Islas Heard y McDonald','2020-08-10 10:39:24',NULL,1),(102,'HN','Honduras','2020-08-10 10:39:24',NULL,1),(103,'HK','Hong Kong','2020-08-10 10:39:24',NULL,1),(104,'HU','Hungría','2020-08-10 10:39:24',NULL,1),(105,'IN','India','2020-08-10 10:39:24',NULL,1),(106,'ID','Indonesia','2020-08-10 10:39:24',NULL,1),(107,'IR','Irán','2020-08-10 10:39:24',NULL,1),(108,'IQ','Iraq','2020-08-10 10:39:24',NULL,1),(109,'IE','Irlanda','2020-08-10 10:39:24',NULL,1),(110,'IS','Islandia','2020-08-10 10:39:24',NULL,1),(111,'IL','Israel','2020-08-10 10:39:24',NULL,1),(112,'IT','Italia','2020-08-10 10:39:24',NULL,1),(113,'JM','Jamaica','2020-08-10 10:39:24',NULL,1),(114,'JP','Japón','2020-08-10 10:39:24',NULL,1),(115,'JO','Jordania','2020-08-10 10:39:24',NULL,1),(116,'KZ','Kazajstán','2020-08-10 10:39:24',NULL,1),(117,'KE','Kenia','2020-08-10 10:39:24',NULL,1),(118,'KG','Kirguistán','2020-08-10 10:39:24',NULL,1),(119,'KI','Kiribati','2020-08-10 10:39:24',NULL,1),(120,'KW','Kuwait','2020-08-10 10:39:24',NULL,1),(121,'LA','Laos','2020-08-10 10:39:24',NULL,1),(122,'LS','Lesotho','2020-08-10 10:39:24',NULL,1),(123,'LV','Letonia','2020-08-10 10:39:24',NULL,1),(124,'LB','Líbano','2020-08-10 10:39:24',NULL,1),(125,'LR','Liberia','2020-08-10 10:39:24',NULL,1),(126,'LY','Libia','2020-08-10 10:39:24',NULL,1),(127,'LI','Liechtenstein','2020-08-10 10:39:24',NULL,1),(128,'LT','Lituania','2020-08-10 10:39:24',NULL,1),(129,'LU','Luxemburgo','2020-08-10 10:39:24',NULL,1),(130,'MO','Macao','2020-08-10 10:39:24',NULL,1),(131,'MK','ARY Macedonia','2020-08-10 10:39:24',NULL,1),(132,'MG','Madagascar','2020-08-10 10:39:24',NULL,1),(133,'MY','Malasia','2020-08-10 10:39:24',NULL,1),(134,'MW','Malawi','2020-08-10 10:39:24',NULL,1),(135,'MV','Maldivas','2020-08-10 10:39:24',NULL,1),(136,'ML','Malí','2020-08-10 10:39:24',NULL,1),(137,'MT','Malta','2020-08-10 10:39:24',NULL,1),(138,'FK','Islas Malvinas','2020-08-10 10:39:24',NULL,1),(139,'MP','Islas Marianas del Norte','2020-08-10 10:39:24',NULL,1),(140,'MA','Marruecos','2020-08-10 10:39:24',NULL,1),(141,'MH','Islas Marshall','2020-08-10 10:39:24',NULL,1),(142,'MQ','Martinica','2020-08-10 10:39:24',NULL,1),(143,'MU','Mauricio','2020-08-10 10:39:24',NULL,1),(144,'MR','Mauritania','2020-08-10 10:39:24',NULL,1),(145,'YT','Mayotte','2020-08-10 10:39:24',NULL,1),(146,'MX','México','2020-08-10 10:39:24',NULL,1),(147,'FM','Micronesia','2020-08-10 10:39:24',NULL,1),(148,'MD','Moldavia','2020-08-10 10:39:24',NULL,1),(149,'MC','Mónaco','2020-08-10 10:39:24',NULL,1),(150,'MN','Mongolia','2020-08-10 10:39:24',NULL,1),(151,'MS','Montserrat','2020-08-10 10:39:24',NULL,1),(152,'MZ','Mozambique','2020-08-10 10:39:24',NULL,1),(153,'MM','Myanmar','2020-08-10 10:39:24',NULL,1),(154,'NA','Namibia','2020-08-10 10:39:24',NULL,1),(155,'NR','Nauru','2020-08-10 10:39:24',NULL,1),(156,'NP','Nepal','2020-08-10 10:39:24',NULL,1),(157,'NI','Nicaragua','2020-08-10 10:39:24',NULL,1),(158,'NE','Níger','2020-08-10 10:39:24',NULL,1),(159,'NG','Nigeria','2020-08-10 10:39:24',NULL,1),(160,'NU','Niue','2020-08-10 10:39:24',NULL,1),(161,'NF','Isla Norfolk','2020-08-10 10:39:24',NULL,1),(162,'NO','Noruega','2020-08-10 10:39:24',NULL,1),(163,'NC','Nueva Caledonia','2020-08-10 10:39:24',NULL,1),(164,'NZ','Nueva Zelanda','2020-08-10 10:39:24',NULL,1),(165,'OM','Omán','2020-08-10 10:39:24',NULL,1),(166,'NL','Países Bajos','2020-08-10 10:39:24',NULL,1),(167,'PK','Pakistán','2020-08-10 10:39:24',NULL,1),(168,'PW','Palau','2020-08-10 10:39:24',NULL,1),(169,'PS','Palestina','2020-08-10 10:39:24',NULL,1),(170,'PA','Panamá','2020-08-10 10:39:24',NULL,1),(171,'PG','Papúa Nueva Guinea','2020-08-10 10:39:24',NULL,1),(172,'PY','Paraguay','2020-08-10 10:39:24',NULL,1),(173,'PE','Perú','2020-08-10 10:39:24',NULL,1),(174,'PN','Islas Pitcairn','2020-08-10 10:39:24',NULL,1),(175,'PF','Polinesia Francesa','2020-08-10 10:39:24',NULL,1),(176,'PL','Polonia','2020-08-10 10:39:24',NULL,1),(177,'PT','Portugal','2020-08-10 10:39:24',NULL,1),(178,'PR','Puerto Rico','2020-08-10 10:39:24',NULL,1),(179,'QA','Qatar','2020-08-10 10:39:24',NULL,1),(180,'GB','Reino Unido','2020-08-10 10:39:24',NULL,1),(181,'RE','Reunión','2020-08-10 10:39:24',NULL,1),(182,'RW','Ruanda','2020-08-10 10:39:24',NULL,1),(183,'RO','Rumania','2020-08-10 10:39:24',NULL,1),(184,'RU','Rusia','2020-08-10 10:39:24',NULL,1),(185,'EH','Sahara Occidental','2020-08-10 10:39:24',NULL,1),(186,'SB','Islas Salomón','2020-08-10 10:39:24',NULL,1),(187,'WS','Samoa','2020-08-10 10:39:24',NULL,1),(188,'AS','Samoa Americana','2020-08-10 10:39:24',NULL,1),(189,'KN','San Cristóbal y Nevis','2020-08-10 10:39:24',NULL,1),(190,'SM','San Marino','2020-08-10 10:39:24',NULL,1),(191,'PM','San Pedro y Miquelón','2020-08-10 10:39:24',NULL,1),(192,'VC','San Vicente y las Granadinas','2020-08-10 10:39:24',NULL,1),(193,'SH','Santa Helena','2020-08-10 10:39:24',NULL,1),(194,'LC','Santa Lucía','2020-08-10 10:39:24',NULL,1),(195,'ST','Santo Tomé y Príncipe','2020-08-10 10:39:24',NULL,1),(196,'SN','Senegal','2020-08-10 10:39:24',NULL,1),(197,'CS','Serbia y Montenegro','2020-08-10 10:39:24',NULL,1),(198,'SC','Seychelles','2020-08-10 10:39:24',NULL,1),(199,'SL','Sierra Leona','2020-08-10 10:39:24',NULL,1),(200,'SG','Singapur','2020-08-10 10:39:24',NULL,1),(201,'SY','Siria','2020-08-10 10:39:24',NULL,1),(202,'SO','Somalia','2020-08-10 10:39:24',NULL,1),(203,'LK','Sri Lanka','2020-08-10 10:39:24',NULL,1),(204,'SZ','Suazilandia','2020-08-10 10:39:24',NULL,1),(205,'ZA','Sudáfrica','2020-08-10 10:39:24',NULL,1),(206,'SD','Sudán','2020-08-10 10:39:24',NULL,1),(207,'SE','Suecia','2020-08-10 10:39:24',NULL,1),(208,'CH','Suiza','2020-08-10 10:39:24',NULL,1),(209,'SR','Surinam','2020-08-10 10:39:24',NULL,1),(210,'SJ','Svalbard y Jan Mayen','2020-08-10 10:39:24',NULL,1),(211,'TH','Tailandia','2020-08-10 10:39:24',NULL,1),(212,'TW','Taiwán','2020-08-10 10:39:24',NULL,1),(213,'TZ','Tanzania','2020-08-10 10:39:24',NULL,1),(214,'TJ','Tayikistán','2020-08-10 10:39:24',NULL,1),(215,'IO','Territorio Británico del Océano Índico','2020-08-10 10:39:24',NULL,1),(216,'TF','Territorios Australes Franceses','2020-08-10 10:39:24',NULL,1),(217,'TL','Timor Oriental','2020-08-10 10:39:24',NULL,1),(218,'TG','Togo','2020-08-10 10:39:24',NULL,1),(219,'TK','Tokelau','2020-08-10 10:39:24',NULL,1),(220,'TO','Tonga','2020-08-10 10:39:24',NULL,1),(221,'TT','Trinidad y Tobago','2020-08-10 10:39:24',NULL,1),(222,'TN','Túnez','2020-08-10 10:39:24',NULL,1),(223,'TC','Islas Turcas y Caicos','2020-08-10 10:39:24',NULL,1),(224,'TM','Turkmenistán','2020-08-10 10:39:24',NULL,1),(225,'TR','Turquía','2020-08-10 10:39:24',NULL,1),(226,'TV','Tuvalu','2020-08-10 10:39:24',NULL,1),(227,'UA','Ucrania','2020-08-10 10:39:24',NULL,1),(228,'UG','Uganda','2020-08-10 10:39:24',NULL,1),(229,'UY','Uruguay','2020-08-10 10:39:24',NULL,1),(230,'UZ','Uzbekistán','2020-08-10 10:39:24',NULL,1),(231,'VU','Vanuatu','2020-08-10 10:39:24',NULL,1),(232,'VE','Venezuela','2020-08-10 10:39:24',NULL,1),(233,'VN','Vietnam','2020-08-10 10:39:24',NULL,1),(234,'VG','Islas Vírgenes Británicas','2020-08-10 10:39:24',NULL,1),(235,'VI','Islas Vírgenes de los Estados Unidos','2020-08-10 10:39:24',NULL,1),(236,'WF','Wallis y Futuna','2020-08-10 10:39:24',NULL,1),(237,'YE','Yemen','2020-08-10 10:39:24',NULL,1),(238,'DJ','Yibuti','2020-08-10 10:39:25',NULL,1),(239,'ZM','Zambia','2020-08-10 10:39:25',NULL,1),(240,'ZW','Zimbabue','2020-08-10 10:39:25',NULL,1);
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document_type`
--

DROP TABLE IF EXISTS `document_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `document_type` (
  `document_type_id` bigint NOT NULL AUTO_INCREMENT,
  `document_type_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `document_type_pattern` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`document_type_id`) USING BTREE,
  KEY `FK_document_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_document_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `document_type`
--

LOCK TABLES `document_type` WRITE;
/*!40000 ALTER TABLE `document_type` DISABLE KEYS */;
INSERT INTO `document_type` VALUES (1,'Cédula','###-#######-#',NULL,NULL,1),(2,'Rnc','#-###-####-#',NULL,NULL,1),(3,'Pasaporte',NULL,NULL,NULL,1),(4,'Otros',NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `document_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `education_type`
--

DROP TABLE IF EXISTS `education_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `education_type` (
  `education_type_id` bigint NOT NULL AUTO_INCREMENT,
  `education_type_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`education_type_id`) USING BTREE,
  KEY `FK_education_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_education_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `education_type`
--

LOCK TABLES `education_type` WRITE;
/*!40000 ALTER TABLE `education_type` DISABLE KEYS */;
INSERT INTO `education_type` VALUES (1,'Licenciatura o Equivalente','2019-04-15 09:52:43',NULL,1),(2,'Especialidad','2019-04-15 09:52:56',NULL,1),(3,'Maestria','2019-04-15 09:53:07',NULL,1),(4,'Doctorado','2019-04-15 09:53:14',NULL,1);
/*!40000 ALTER TABLE `education_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `file`
--

DROP TABLE IF EXISTS `file`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `file` (
  `file_id` bigint NOT NULL AUTO_INCREMENT,
  `file_type_id` bigint DEFAULT NULL,
  `file_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `file_full_path` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `file_path` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `file_application_type` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`file_id`) USING BTREE,
  KEY `FK_file_file_type` (`file_type_id`) USING BTREE,
  KEY `FK_file_user` (`creation_user_id`) USING BTREE,
  KEY `FK_file_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_file_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_file_file_type` FOREIGN KEY (`file_type_id`) REFERENCES `file_type` (`file_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_file_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_file_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_file_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=211 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `file`
--

LOCK TABLES `file` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `file_type`
--

DROP TABLE IF EXISTS `file_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `file_type` (
  `file_type_id` bigint NOT NULL AUTO_INCREMENT,
  `file_type_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`file_type_id`) USING BTREE,
  KEY `FK_file_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_file_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `file_type`
--

LOCK TABLES `file_type` WRITE;
/*!40000 ALTER TABLE `file_type` DISABLE KEYS */;
INSERT INTO `file_type` VALUES (1,'Foto 2x2',NULL,NULL,1),(2,'Cedula',NULL,NULL,1),(3,'Acta de nacimiento',NULL,NULL,1),(4,'Record de nota',NULL,NULL,1),(5,'Certificacion de pruebas nacionales',NULL,NULL,1),(6,'Certificacion PAA',NULL,NULL,1),(7,'Cedula lado trasero',NULL,NULL,1),(8,'Record de nota lado trasero',NULL,NULL,1),(9,'Certificación Centro Educativo',NULL,NULL,1),(10,'Documentos de Maestros',NULL,NULL,1),(11,'Documentos de Aspectos Contractuales',NULL,NULL,1),(12,'Documentos de Cursos Extracurriculares',NULL,NULL,1),(13,'Reporte de calificación de asignaturas',NULL,NULL,1),(14,'Archivos del Sistema de Calidad',NULL,NULL,1);
/*!40000 ALTER TABLE `file_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marital_status`
--

DROP TABLE IF EXISTS `marital_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `marital_status` (
  `marital_status_id` bigint NOT NULL AUTO_INCREMENT,
  `marital_status_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`marital_status_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marital_status`
--

LOCK TABLES `marital_status` WRITE;
/*!40000 ALTER TABLE `marital_status` DISABLE KEYS */;
/*!40000 ALTER TABLE `marital_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu` (
  `menu_id` bigint NOT NULL AUTO_INCREMENT,
  `menu_parent_id` bigint DEFAULT NULL,
  `menu_type_id` bigint DEFAULT NULL,
  `menu_caption` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `menu_link` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `menu_icon` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `menu_position` int DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`menu_id`) USING BTREE,
  KEY `FK_menu_status` (`status_id`) USING BTREE,
  KEY `FK_menu_menu` (`menu_parent_id`) USING BTREE,
  KEY `FK_menu_menu_type` (`menu_type_id`) USING BTREE,
  CONSTRAINT `FK_menu_menu` FOREIGN KEY (`menu_parent_id`) REFERENCES `menu` (`menu_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_menu_menu_type` FOREIGN KEY (`menu_type_id`) REFERENCES `menu_type` (`menu_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_menu_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,NULL,1,'modules',NULL,'modules.jpg',2,NULL,NULL,1),(3,NULL,1,'configuration',NULL,'setting.jpg',3,NULL,NULL,1),(7,NULL,1,'help','menu/help','help.png',4,NULL,NULL,1),(12,NULL,1,'maintenance',NULL,'maintenance.png',5,NULL,NULL,1),(18,NULL,1,'home','home','home.png',1,'2019-03-10 00:28:58','2019-03-16 23:10:38',1),(25,NULL,1,'exit','login/do_logout','',6,'2019-03-16 23:09:02',NULL,1),(26,12,2,'menu','menu','menu.png',0,'2019-03-27 16:42:38',NULL,1),(27,1,1,'academic','','academic.png',1,'2019-03-27 20:01:02','2019-03-27 20:02:01',1),(28,27,2,'tracing_schedule','scholarship_program_tracing','tracing.png',5,'2019-03-28 13:37:44','2019-05-20 17:31:22',1),(29,31,2,'agent','agent','agent.png',3,'2019-03-28 14:58:48','2019-05-20 17:33:01',1),(30,31,2,'agent_types','agent_type','agent_type.png',3,'2019-03-29 19:11:57','2019-05-08 01:09:25',1),(31,27,1,'maintenance','','maintenance.png',10,'2019-05-08 00:56:25','2019-05-08 01:11:50',1),(32,27,2,'university','university','university.png',2,'2019-05-08 01:01:44','2019-05-20 17:30:02',1),(33,27,2,'scholarship_program','scholarship_program','scholarship_program.png',1,'2019-05-08 01:03:13','2019-05-20 17:29:46',1),(34,27,2,'scholarship_program_agreement','scholarship_program_agreement','scholarship_program_agreement.png',3,'2019-05-08 01:03:45','2019-05-08 01:06:27',1),(35,31,2,'subject_matter','subject_matter','subject_matter.png',2,'2019-05-08 01:08:03','2019-05-20 17:32:35',1),(36,31,2,'teachers','teacher','teacher.png',1,'2019-05-08 01:10:48','2019-05-20 17:32:16',1),(37,3,1,'security','','security.png',0,'2019-05-19 18:42:10',NULL,1),(38,37,2,'users','user/grid','user.png',0,'2019-05-19 18:43:15',NULL,1),(39,27,2,'scholarship_announcement','scholarship_announcement/grid','scholarship_announcement.png',6,'2019-05-20 00:25:29','2019-05-20 00:26:05',1);
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_type`
--

DROP TABLE IF EXISTS `menu_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_type` (
  `menu_type_id` bigint NOT NULL AUTO_INCREMENT,
  `menu_type_name` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`menu_type_id`) USING BTREE,
  KEY `FK_menu_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_menu_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_type`
--

LOCK TABLES `menu_type` WRITE;
/*!40000 ALTER TABLE `menu_type` DISABLE KEYS */;
INSERT INTO `menu_type` VALUES (1,'Menu',NULL,NULL,1),(2,'Item',NULL,NULL,1);
/*!40000 ALTER TABLE `menu_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `migrations`
--

DROP TABLE IF EXISTS `migrations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `migrations` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `migration` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `migrations`
--

LOCK TABLES `migrations` WRITE;
/*!40000 ALTER TABLE `migrations` DISABLE KEYS */;
/*!40000 ALTER TABLE `migrations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nationality`
--

DROP TABLE IF EXISTS `nationality`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nationality` (
  `nationality_id` bigint NOT NULL AUTO_INCREMENT,
  `nationality_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`nationality_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nationality`
--

LOCK TABLES `nationality` WRITE;
/*!40000 ALTER TABLE `nationality` DISABLE KEYS */;
/*!40000 ALTER TABLE `nationality` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `object`
--

DROP TABLE IF EXISTS `object`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `object` (
  `object_id` bigint NOT NULL AUTO_INCREMENT,
  `object_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`object_id`) USING BTREE,
  KEY `FK_object_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_object_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `object`
--

LOCK TABLES `object` WRITE;
/*!40000 ALTER TABLE `object` DISABLE KEYS */;
/*!40000 ALTER TABLE `object` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `object_mapping`
--

DROP TABLE IF EXISTS `object_mapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `object_mapping` (
  `object_mapping_id` bigint NOT NULL AUTO_INCREMENT,
  `object_id` bigint DEFAULT NULL,
  `object_mapping_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` bigint DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`object_mapping_id`) USING BTREE,
  KEY `FK_object_mapping_object` (`object_id`) USING BTREE,
  KEY `FK_object_mapping_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_object_mapping_object` FOREIGN KEY (`object_id`) REFERENCES `object` (`object_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_object_mapping_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `object_mapping`
--

LOCK TABLES `object_mapping` WRITE;
/*!40000 ALTER TABLE `object_mapping` DISABLE KEYS */;
/*!40000 ALTER TABLE `object_mapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `office`
--

DROP TABLE IF EXISTS `office`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `office` (
  `office_id` bigint NOT NULL AUTO_INCREMENT,
  `company_id` bigint DEFAULT NULL,
  `office_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `address_id` bigint DEFAULT NULL,
  `communication_id` bigint DEFAULT NULL,
  `manager_id` bigint DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`office_id`) USING BTREE,
  KEY `FK_office_company` (`company_id`) USING BTREE,
  KEY `FK_office_address` (`address_id`) USING BTREE,
  KEY `FK_office_communication` (`communication_id`) USING BTREE,
  KEY `FK_office_user` (`manager_id`) USING BTREE,
  KEY `FK_office_status` (`status_id`) USING BTREE,
  KEY `FK_office_user_2` (`creation_user_id`) USING BTREE,
  KEY `FK_office_user_3` (`upgrade_user_id`) USING BTREE,
  CONSTRAINT `FK_office_address` FOREIGN KEY (`address_id`) REFERENCES `address` (`address_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_office_communication` FOREIGN KEY (`communication_id`) REFERENCES `communication` (`communication_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_office_company` FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_office_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_office_user` FOREIGN KEY (`manager_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_office_user_2` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_office_user_3` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `office`
--

LOCK TABLES `office` WRITE;
/*!40000 ALTER TABLE `office` DISABLE KEYS */;
INSERT INTO `office` VALUES (1,1,'Oficina Príncipal',1,1,1,1,NULL,'2018-09-05 17:42:31',NULL,1);
/*!40000 ALTER TABLE `office` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `province`
--

DROP TABLE IF EXISTS `province`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `province` (
  `province_id` bigint NOT NULL AUTO_INCREMENT,
  `country_id` bigint DEFAULT NULL,
  `province_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`province_id`) USING BTREE,
  KEY `FK_province_country` (`country_id`) USING BTREE,
  KEY `FK_province_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_province_country` FOREIGN KEY (`country_id`) REFERENCES `country` (`country_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_province_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `province`
--

LOCK TABLES `province` WRITE;
/*!40000 ALTER TABLE `province` DISABLE KEYS */;
INSERT INTO `province` VALUES (1,65,'DISTRITO  NACIONAL','2019-02-28 13:29:25',NULL,1),(2,65,'AZUA','2019-02-28 13:29:25',NULL,1),(3,65,'BAORUCO','2019-02-28 13:29:25',NULL,1),(4,65,'BARAHONA','2019-02-28 13:29:25',NULL,1),(5,65,'DAJABÓN','2019-02-28 13:29:25',NULL,1),(6,65,'DUARTE','2019-02-28 13:29:25',NULL,1),(7,65,'ELÍAS PIÑA','2019-02-28 13:29:25',NULL,1),(8,65,'EL SEIBO','2019-02-28 13:29:25',NULL,1),(9,65,'ESPAILLAT','2019-02-28 13:29:25',NULL,1),(10,65,'INDEPENDENCIA','2019-02-28 13:29:25',NULL,1),(11,65,'LA ALTAGRACIA','2019-02-28 13:29:25',NULL,1),(12,65,'LA ROMANA','2019-02-28 13:29:25',NULL,1),(13,65,'LA VEGA','2019-02-28 13:29:25',NULL,1),(14,65,'MARÍA TRINIDAD SÁNCHEZ','2019-02-28 13:29:25',NULL,1),(15,65,'MONTE CRISTI','2019-02-28 13:29:25',NULL,1),(16,65,'PEDERNALES','2019-02-28 13:29:25',NULL,1),(17,65,'PERAVIA','2019-02-28 13:29:25',NULL,1),(18,65,'PUERTO PLATA','2019-02-28 13:29:25',NULL,1),(19,65,'HERMANAS MIRABAL','2019-02-28 13:29:25',NULL,1),(20,65,'SAMANÁ','2019-02-28 13:29:25',NULL,1),(21,65,'SAN CRISTÓBAL','2019-02-28 13:29:25',NULL,1),(22,65,'SAN JUAN','2019-02-28 13:29:25',NULL,1),(23,65,'SAN PEDRO DE MACORÍS','2019-02-28 13:29:25',NULL,1),(24,65,'SÁNCHEZ RAMÍREZ','2019-02-28 13:29:25',NULL,1),(25,65,'SANTIAGO','2019-02-28 13:29:25',NULL,1),(26,65,'SANTIAGO RODRÍGUEZ','2019-02-28 13:29:25',NULL,1),(27,65,'VALVERDE','2019-02-28 13:29:25',NULL,1),(28,65,'MONSEÑOR NOUEL','2019-02-28 13:29:25',NULL,1),(29,65,'MONTE PLATA','2019-02-28 13:29:25',NULL,1),(30,65,'HATO MAYOR','2019-02-28 13:29:25',NULL,1),(31,65,'SAN JOSÉ DE OCOA','2019-02-28 13:29:25',NULL,1),(32,65,'SANTO DOMINGO','2019-02-28 13:29:25',NULL,1);
/*!40000 ALTER TABLE `province` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report`
--

DROP TABLE IF EXISTS `report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `report` (
  `ReportId` int NOT NULL AUTO_INCREMENT,
  `Comment` text,
  `CreationDate` datetime NOT NULL,
  `UpgradeDate` datetime NOT NULL,
  `CreatorUserId` varchar(767) DEFAULT NULL,
  `TracingId` bigint NOT NULL,
  `FileId` bigint NOT NULL,
  `StatusId` bigint NOT NULL DEFAULT '0',
  PRIMARY KEY (`ReportId`),
  KEY `IX_Report_CreatorUserId` (`CreatorUserId`),
  KEY `IX_Report_FileId` (`FileId`),
  KEY `IX_Report_TracingId` (`TracingId`),
  KEY `IX_Report_StatusId` (`StatusId`),
  CONSTRAINT `FK_Report_file_FileId` FOREIGN KEY (`FileId`) REFERENCES `file` (`file_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Report_scholarship_program_tracing_TracingId` FOREIGN KEY (`TracingId`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Report_Usuarios_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `usuarios` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report`
--

LOCK TABLES `report` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `ResultsFromThePreviousPeriod`
--

DROP TABLE IF EXISTS `ResultsFromThePreviousPeriod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ResultsFromThePreviousPeriod` (
  `PreviousPeriodId` bigint NOT NULL AUTO_INCREMENT,
  `Quantity` int DEFAULT NULL,
  `Observations` text,
  `FileDescription` text,
  `TracingId` bigint DEFAULT NULL,
  `ComponentFileTypeId` int NOT NULL,
  `StatusId` bigint DEFAULT NULL,
  `FileId` bigint DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  PRIMARY KEY (`PreviousPeriodId`),
  KEY `IX_ResultsFromThePreviousPeriod_FileId` (`FileId`),
  KEY `IX_ResultsFromThePreviousPeriod_StatusId` (`StatusId`),
  KEY `IX_ResultsFromThePreviousPeriod_TracingId` (`TracingId`),
  KEY `IX_ResultsFromThePreviousPeriod_ComponentFileTypeId` (`ComponentFileTypeId`),
  CONSTRAINT `FK_ResultsFromThePreviousPeriod_ComponentFileTypes_ComponentFil~` FOREIGN KEY (`ComponentFileTypeId`) REFERENCES `ComponentFileTypes` (`ComponentFileTypeId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ResultsFromThePreviousPeriod_file_FileId` FOREIGN KEY (`FileId`) REFERENCES `file` (`file_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ResultsFromThePreviousPeriod_scholarship_program_tracing_Tra~` FOREIGN KEY (`TracingId`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ResultsFromThePreviousPeriod_status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ResultsFromThePreviousPeriod`
--

LOCK TABLES `ResultsFromThePreviousPeriod` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `Roles`
--

DROP TABLE IF EXISTS `Roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Roles` (
  `Id` varchar(767) NOT NULL,
  `Name` text,
  `NormalizedName` text,
  `ConcurrencyStamp` text,
  `Descripcion` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Roles`
--

LOCK TABLES `Roles` WRITE;
/*!40000 ALTER TABLE `Roles` DISABLE KEYS */;
INSERT INTO `Roles` VALUES ('72556015-cb72-4b89-a0ac-b902fbc4fd51','USUARIO EJECUTIVO UNIVERSITARIO','USUARIO EJECUTIVO UNIVERSITARIO','6dbca2c0-633e-4d82-9cc1-16e447ce7cb3','Encargados del area de consulta'),('7b9b75fc-efe9-4a41-84d5-add4ee1a6bd6','USUARIO EJECUTIVO INAFOCAM','USUARIO EJECUTIVO INAFOCAM','d54d5f93-0b08-45eb-944e-a4d6d396544c','Encargados del area de consulta inafocam'),('817fe320-e3f5-4509-8d7a-a2e8ed8773af','ADMINISTRADOR INAFOCAM','ADMINISTRADOR INAFOCAM','c1b610b2-0b40-40da-9dc1-eacaf4147df4','Este Usuario Crea los Acuerdos Contractuales, Informacion Relacionada con la Universidad'),('b4c12dc2-14f1-4171-af8d-87aca893c366','GESTIÓN UNIVERSITARIA','GESTIÓN UNIVERSITARIA','2615c0bf-a6dd-461e-a011-7ad8ccf4327f','Este usuario completa la informacion en funcion a los acuerdos contractuales ya creados');
/*!40000 ALTER TABLE `Roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedule` (
  `schedule_id` bigint NOT NULL AUTO_INCREMENT,
  `schedule_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `updating_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `updating_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`schedule_id`) USING BTREE,
  KEY `FK_schedule_user` (`creation_user_id`) USING BTREE,
  KEY `FK_schedule_user_2` (`updating_user_id`) USING BTREE,
  KEY `FK_schedule_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_schedule_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_schedule_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_schedule_user_2` FOREIGN KEY (`updating_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule_day`
--

DROP TABLE IF EXISTS `schedule_day`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedule_day` (
  `schedule_day_id` bigint NOT NULL AUTO_INCREMENT,
  `schedule_id` bigint DEFAULT NULL,
  `schedule_day` enum('SUNDAY','MONDAY') CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `schedule_start_time` time DEFAULT NULL,
  `schedule_end_time` time DEFAULT NULL,
  PRIMARY KEY (`schedule_day_id`) USING BTREE,
  KEY `FK_schedule_days_schedule` (`schedule_id`) USING BTREE,
  CONSTRAINT `FK_schedule_days_schedule` FOREIGN KEY (`schedule_id`) REFERENCES `schedule` (`schedule_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule_day`
--

LOCK TABLES `schedule_day` WRITE;
/*!40000 ALTER TABLE `schedule_day` DISABLE KEYS */;
/*!40000 ALTER TABLE `schedule_day` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_level`
--

DROP TABLE IF EXISTS `scholarship_level`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_level` (
  `scholarship_level_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_level_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_level_id`) USING BTREE,
  KEY `FK_scholarship_level_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_level_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_level`
--

LOCK TABLES `scholarship_level` WRITE;
/*!40000 ALTER TABLE `scholarship_level` DISABLE KEYS */;
INSERT INTO `scholarship_level` VALUES (1,'Inicial',NULL,NULL,1),(2,'Posgrado',NULL,NULL,1),(3,'Formación Continua',NULL,NULL,1);
/*!40000 ALTER TABLE `scholarship_level` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program`
--

DROP TABLE IF EXISTS `scholarship_program`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program` (
  `scholarship_program_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_program_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `scholarship_level_id` bigint DEFAULT NULL,
  ` creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_program_id`) USING BTREE,
  KEY `FK_scholarship_program_scholarship_level` (`scholarship_level_id`) USING BTREE,
  KEY `FK_scholarship_program_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_scholarship_level` FOREIGN KEY (`scholarship_level_id`) REFERENCES `scholarship_level` (`scholarship_level_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program`
--

LOCK TABLES `scholarship_program` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing`
--

DROP TABLE IF EXISTS `scholarship_program_tracing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing` (
  `scholarship_program_tracing_id` bigint NOT NULL AUTO_INCREMENT,
  `university_id` bigint DEFAULT NULL,
  `scholarship_program_university_id` bigint DEFAULT NULL,
  `coordinator_id` bigint DEFAULT NULL,
  `technical_id` bigint DEFAULT NULL,
  `start_date` datetime DEFAULT NULL,
  `end_date` datetime DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_program_tracing_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_scholarship_program_university` (`scholarship_program_university_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_user` (`creation_user_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_status` (`status_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_agent` (`coordinator_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_agent_2` (`technical_id`) USING BTREE,
  KEY `FK_scholarship_program_tracing_university` (`university_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_tracing_university` FOREIGN KEY (`university_id`) REFERENCES `university` (`university_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracking_agent` FOREIGN KEY (`coordinator_id`) REFERENCES `agent` (`agent_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracking_agent_2` FOREIGN KEY (`technical_id`) REFERENCES `agent` (`agent_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracking_scholarship_program_university` FOREIGN KEY (`scholarship_program_university_id`) REFERENCES `scholarship_program_university` (`scholarship_program_university_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracking_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracking_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracking_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing`
--

LOCK TABLES `scholarship_program_tracing` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_agreement`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_agreement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_agreement` (
  `scholarship_program_tracing_agreement_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_program_tracing_id` bigint DEFAULT NULL,
  `scholarship_program_university_agreement_id` bigint DEFAULT NULL,
  `scholarship_program_tracing_agreement_description` varchar(512) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `scholarship_program_tracing_agreement_description2` varchar(512) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `scholarship_program_tracing_agreement_description3` varchar(512) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `commented_user_id` varchar(767) NOT NULL,
  `creation_user_id` varchar(767) NOT NULL,
  `upgrade_user_id` varchar(767) NOT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_program_tracing_agreement_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_agreement_user` (`creation_user_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_agreement_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_agreement_status` (`status_id`) USING BTREE,
  KEY `FK_tracking` (`scholarship_program_tracing_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_agreement_user_3` (`commented_user_id`) USING BTREE,
  KEY `FK_scholarship_program_tracing_agreement` (`scholarship_program_university_agreement_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_tracing_agreement` FOREIGN KEY (`scholarship_program_university_agreement_id`) REFERENCES `scholarship_program_university_agreement` (`scholarship_program_university_agreement_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracking_agreement_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_tracking` FOREIGN KEY (`scholarship_program_tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_agreement`
--

LOCK TABLES `scholarship_program_tracing_agreement` WRITE;
/*!40000 ALTER TABLE `scholarship_program_tracing_agreement` DISABLE KEYS */;
/*!40000 ALTER TABLE `scholarship_program_tracing_agreement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_agreement_file`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_agreement_file`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_agreement_file` (
  `scholarship_program_tracing_agreement_file_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_program_tracing_agreement_id` bigint NOT NULL DEFAULT '0',
  `agreement_file_description` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL DEFAULT '0',
  `file_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_program_tracing_agreement_file_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_agreement_file_file` (`file_id`) USING BTREE,
  KEY `FK_scholarship_program_tracking_agreement_file_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_tracking_agreement_file_file` FOREIGN KEY (`file_id`) REFERENCES `file` (`file_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracking_agreement_file_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_agreement_file`
--

LOCK TABLES `scholarship_program_tracing_agreement_file` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_course`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_course` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `tracing_id` bigint DEFAULT NULL,
  `course_name` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `hours_taken` int DEFAULT NULL,
  `course_start_date` date DEFAULT NULL,
  `course_end_date` date DEFAULT NULL,
  `students_quantity` int DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `FK_scholarship_program_tracing_plan_scholarship_program_tracing` (`tracing_id`) USING BTREE,
  KEY `FK_scholarship_program_tracing_plan_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_tracing_plan_scholarship_program_tracing` FOREIGN KEY (`tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracing_plan_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_course`
--

LOCK TABLES `scholarship_program_tracing_course` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_course_file`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_course_file`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_course_file` (
  `course_file_id` bigint NOT NULL AUTO_INCREMENT,
  `tracing_id` bigint DEFAULT NULL,
  `file_type_id` bigint DEFAULT NULL,
  `file_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  `ScholarshipProgramTracingCourseId` bigint DEFAULT NULL,
  PRIMARY KEY (`course_file_id`) USING BTREE,
  KEY `FK__tracing_plan` (`tracing_id`) USING BTREE,
  KEY `FK__tracing_plan_file` (`file_id`) USING BTREE,
  KEY `FK_tracing_plan_status` (`status_id`) USING BTREE,
  KEY `FK_file_type` (`file_type_id`) USING BTREE,
  KEY `IX_scholarship_program_tracing_course_file_ScholarshipProgramTr~` (`ScholarshipProgramTracingCourseId`),
  CONSTRAINT `FK__tracing_plan` FOREIGN KEY (`tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK__tracing_plan_file` FOREIGN KEY (`file_id`) REFERENCES `file` (`file_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_file_type` FOREIGN KEY (`file_type_id`) REFERENCES `scholarship_program_tracing_course_file_type` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracing_course_file_scholarship_program_~` FOREIGN KEY (`ScholarshipProgramTracingCourseId`) REFERENCES `scholarship_program_tracing_course` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_tracing_plan_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_course_file`
--

LOCK TABLES `scholarship_program_tracing_course_file` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_course_file_type`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_course_file_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_course_file_type` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `file_type_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_course_file_type`
--

LOCK TABLES `scholarship_program_tracing_course_file_type` WRITE;
/*!40000 ALTER TABLE `scholarship_program_tracing_course_file_type` DISABLE KEYS */;
INSERT INTO `scholarship_program_tracing_course_file_type` VALUES (1,'Pensum','2019-05-09 02:03:49',NULL,1),(2,'Horario de clases','2019-05-09 02:04:00',NULL,1),(3,'Informes de cursos extracurriculares','2019-05-09 02:04:09',NULL,1),(8,'Listado de estudiantes',NULL,NULL,1);
/*!40000 ALTER TABLE `scholarship_program_tracing_course_file_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_practice`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_practice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_practice` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `tracing_id` bigint DEFAULT NULL,
  `activity` bigint NOT NULL,
  `coordinator` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `superviser` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `teacher` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `periodicity` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `upgrade_date` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `FK_practice_tracing` (`tracing_id`) USING BTREE,
  KEY `FK_practice_status` (`status_id`) USING BTREE,
  KEY `IX_scholarship_program_tracing_practice_activity` (`activity`),
  CONSTRAINT `FK_practice_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_practice_tracing` FOREIGN KEY (`tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracing_practice_ActivityType_activity` FOREIGN KEY (`activity`) REFERENCES `activitytype` (`ActivityTypeId`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_practice`
--

LOCK TABLES `scholarship_program_tracing_practice` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_practice_planning`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_practice_planning`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_practice_planning` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `tracing_id` bigint DEFAULT NULL,
  `action` bigint NOT NULL,
  `started` bit(1) DEFAULT NULL,
  `finished` bit(1) DEFAULT NULL,
  `comment` varchar(512) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `FK_planning_tracing` (`tracing_id`) USING BTREE,
  KEY `FK_planning_status` (`status_id`) USING BTREE,
  KEY `IX_scholarship_program_tracing_practice_planning_action` (`action`),
  CONSTRAINT `FK_planning_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_planning_tracing` FOREIGN KEY (`tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracing_practice_planning_ActionType_act~` FOREIGN KEY (`action`) REFERENCES `actiontype` (`ActionTypeId`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_practice_planning`
--

LOCK TABLES `scholarship_program_tracing_practice_planning` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_quality_system`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_quality_system`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_quality_system` (
  `quality_file_id` bigint NOT NULL AUTO_INCREMENT,
  `tracing_id` bigint DEFAULT NULL,
  `file_type_id` bigint DEFAULT NULL,
  `file_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`quality_file_id`) USING BTREE,
  KEY `FK_program_tracing` (`tracing_id`) USING BTREE,
  KEY `FK_status_quality` (`status_id`) USING BTREE,
  KEY `FK_file_quality` (`file_id`) USING BTREE,
  CONSTRAINT `FK_file_quality` FOREIGN KEY (`file_id`) REFERENCES `file` (`file_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_program_tracing` FOREIGN KEY (`tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_status_quality` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_quality_system`
--

LOCK TABLES `scholarship_program_tracing_quality_system` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_quality_system_file_type`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_quality_system_file_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_quality_system_file_type` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `file_type_name` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_quality_system_file_type`
--

LOCK TABLES `scholarship_program_tracing_quality_system_file_type` WRITE;
/*!40000 ALTER TABLE `scholarship_program_tracing_quality_system_file_type` DISABLE KEYS */;
INSERT INTO `scholarship_program_tracing_quality_system_file_type` VALUES (1,'Fragmento del documento institucional que posea la política de calidad','2019-05-22 16:28:46',NULL,1),(2,'Estructura que se encarga de coordinar las acciones que operativizan la política de calidad declarada','2019-05-22 16:28:56',NULL,1),(3,'Documentación de los procesos claves para el éxito del programa','2019-05-22 16:29:04',NULL,1),(4,'Plan de evaluaciones de los procesos claves indentificados','2019-05-22 16:29:13',NULL,1),(5,'Evidencia de ciclos de mejora fruto de evaluaciones en los procesos claves','2019-05-22 16:29:21',NULL,1);
/*!40000 ALTER TABLE `scholarship_program_tracing_quality_system_file_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_student_practice`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_student_practice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_student_practice` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `tracing_id` bigint DEFAULT NULL,
  `practice_type` int NOT NULL,
  `students_quantity` int DEFAULT NULL,
  `practice_center_quantity` int DEFAULT NULL,
  `supervisor_quantity` int DEFAULT NULL,
  `teacher_quantity` int DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `FK_student_practice_tracing` (`tracing_id`) USING BTREE,
  KEY `FK_scholarship_program_tracing_student_practice_status` (`status_id`) USING BTREE,
  KEY `IX_scholarship_program_tracing_student_practice_practice_type` (`practice_type`),
  CONSTRAINT `FK_scholarship_program_tracing_student_practice_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_tracing_student_practice_StudentPractice~` FOREIGN KEY (`practice_type`) REFERENCES `StudentPracticeType` (`StudentPracticeTypeId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_student_practice_tracing` FOREIGN KEY (`tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_student_practice`
--

LOCK TABLES `scholarship_program_tracing_student_practice` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_tracing_student_support`
--

DROP TABLE IF EXISTS `scholarship_program_tracing_student_support`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_tracing_student_support` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `tracing_id` bigint NOT NULL DEFAULT '0',
  `indicator_id` bigint DEFAULT NULL,
  `question_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  `ComoLoHacenProcedimiento` text,
  `CuandoSeHacePeriodicidad` text,
  `Cuálesutilizan` text,
  `QuienEsElResponsable` text,
  `answer` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `FK_student_support_tracing` (`tracing_id`) USING BTREE,
  KEY `FK_scholarship_program_tracing_student_support_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_tracing_student_support_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_student_support_tracing` FOREIGN KEY (`tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_tracing_student_support`
--

LOCK TABLES `scholarship_program_tracing_student_support` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_university`
--

DROP TABLE IF EXISTS `scholarship_program_university`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_university` (
  `scholarship_program_university_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_level_id` bigint DEFAULT NULL,
  `scholarship_program_id` bigint DEFAULT NULL,
  `university_id` bigint DEFAULT NULL,
  `scat_program_id` bigint DEFAULT NULL,
  `scat_program_code` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `active_students` int DEFAULT NULL,
  `contract_number` varchar(16) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `coordinator_id` bigint DEFAULT NULL,
  `technical_id` bigint DEFAULT NULL,
  `announcement_start_date` date DEFAULT NULL,
  `announcement_end_date` date DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_program_university_id`) USING BTREE,
  KEY `FK_scholarship_program_university_scholarship_program` (`scholarship_program_id`) USING BTREE,
  KEY `FK_scholarship_program_university_university` (`university_id`) USING BTREE,
  KEY `FK_scholarship_program_university_status` (`status_id`) USING BTREE,
  KEY `FK_scholarship_program_university_agent` (`coordinator_id`) USING BTREE,
  KEY `FK_scholarship_program_university_agent_2` (`technical_id`) USING BTREE,
  KEY `FK_scholarship_program_university_scholarship_level` (`scholarship_level_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_university_agent` FOREIGN KEY (`coordinator_id`) REFERENCES `agent` (`agent_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_agent_2` FOREIGN KEY (`technical_id`) REFERENCES `agent` (`agent_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_scholarship_level` FOREIGN KEY (`scholarship_level_id`) REFERENCES `scholarship_level` (`scholarship_level_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_scholarship_program` FOREIGN KEY (`scholarship_program_id`) REFERENCES `scholarship_program` (`scholarship_program_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_university` FOREIGN KEY (`university_id`) REFERENCES `university` (`university_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_university`
--

LOCK TABLES `scholarship_program_university` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_university_agent`
--

DROP TABLE IF EXISTS `scholarship_program_university_agent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_university_agent` (
  `scholarship_program_university_cordinator_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_program_university_id` bigint DEFAULT NULL,
  `agent_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_program_university_cordinator_id`) USING BTREE,
  KEY `FK_program_university` (`scholarship_program_university_id`) USING BTREE,
  KEY `FK_status` (`status_id`) USING BTREE,
  KEY `FK_scholarship_contact` (`agent_id`) USING BTREE,
  CONSTRAINT `FK_program_university` FOREIGN KEY (`scholarship_program_university_id`) REFERENCES `scholarship_program_university` (`scholarship_program_university_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_contact` FOREIGN KEY (`agent_id`) REFERENCES `agent` (`agent_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_university_agent`
--

LOCK TABLES `scholarship_program_university_agent` WRITE;
/*!40000 ALTER TABLE `scholarship_program_university_agent` DISABLE KEYS */;
/*!40000 ALTER TABLE `scholarship_program_university_agent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_university_agreement`
--

DROP TABLE IF EXISTS `scholarship_program_university_agreement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_university_agreement` (
  `scholarship_program_university_agreement_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_program_university_id` bigint DEFAULT NULL,
  `scholarship_program_university_agreement` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `agreement_type_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  `DescripcionDelAvance` text,
  `DescripcionQueEvidencieElCumplimiento` text,
  `Observaciones` text,
  PRIMARY KEY (`scholarship_program_university_agreement_id`) USING BTREE,
  KEY `FK_scholarship_program_university` (`scholarship_program_university_id`) USING BTREE,
  KEY `FK_scholarship_program_university_agreement_user` (`creation_user_id`) USING BTREE,
  KEY `FK_scholarship_program_university_agreement_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_scholarship_program_university_agreement_status` (`status_id`) USING BTREE,
  KEY `FK_scholarship_program_university_agreement_agreement_type` (`agreement_type_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_university` FOREIGN KEY (`scholarship_program_university_id`) REFERENCES `scholarship_program_university` (`scholarship_program_university_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_agreement_agreement_type` FOREIGN KEY (`agreement_type_id`) REFERENCES `agreement_type` (`agreement_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_agreement_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_agreement_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_agreement_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_university_agreement`
--

LOCK TABLES `scholarship_program_university_agreement` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_university_subject_matter`
--

DROP TABLE IF EXISTS `scholarship_program_university_subject_matter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_university_subject_matter` (
  `scholarship_program_university_subject_matter_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_program_university_id` bigint NOT NULL DEFAULT '0',
  `subject_matter_id` bigint DEFAULT NULL,
  `teacher_id` bigint DEFAULT NULL,
  `predicted_teacher_id` bigint DEFAULT NULL,
  `subject_matter_credits` int DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_program_university_subject_matter_id`) USING BTREE,
  KEY `FK_scholarship_program_university_subject_matter_subject_matter` (`subject_matter_id`) USING BTREE,
  KEY `FK_scholarship_program_university_subject_matter_teacher` (`teacher_id`) USING BTREE,
  KEY `FK_scholarship_program_university_subject_matter_teacher_2` (`predicted_teacher_id`) USING BTREE,
  KEY `FK_scholarship_program_university_subject_matter_status` (`status_id`) USING BTREE,
  KEY `FK_spusm_scholarship_program_university` (`scholarship_program_university_id`) USING BTREE,
  CONSTRAINT `FK_scholarship_program_university_subject_matter_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_subject_matter_subject_matter` FOREIGN KEY (`subject_matter_id`) REFERENCES `subject_matter` (`subject_matter_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_subject_matter_teacher` FOREIGN KEY (`teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_scholarship_program_university_subject_matter_teacher_2` FOREIGN KEY (`predicted_teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_spusm_scholarship_program_university` FOREIGN KEY (`scholarship_program_university_id`) REFERENCES `scholarship_program_university` (`scholarship_program_university_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_university_subject_matter`
--

LOCK TABLES `scholarship_program_university_subject_matter` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `scholarship_program_university_teacher_hiring`
--

DROP TABLE IF EXISTS `scholarship_program_university_teacher_hiring`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarship_program_university_teacher_hiring` (
  `scholarship_program_university_teacher_hiring_id` bigint NOT NULL AUTO_INCREMENT,
  `teacher_hiring_type_id` bigint DEFAULT NULL,
  `teacher_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`scholarship_program_university_teacher_hiring_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarship_program_university_teacher_hiring`
--

LOCK TABLES `scholarship_program_university_teacher_hiring` WRITE;
/*!40000 ALTER TABLE `scholarship_program_university_teacher_hiring` DISABLE KEYS */;
/*!40000 ALTER TABLE `scholarship_program_university_teacher_hiring` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scholarshipprogramtracingagreementdescription`
--

DROP TABLE IF EXISTS `scholarshipprogramtracingagreementdescription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scholarshipprogramtracingagreementdescription` (
  `ScholarshipProgramTracingAgreementDescriptionId` bigint NOT NULL,
  `ScholarshipProgramTracingId` bigint DEFAULT NULL,
  `ScholarshipProgramUniversityAgreementId` bigint DEFAULT NULL,
  `ScholarshipProgramTracingAgreementDescription2` text,
  `ScholarshipProgramTracingAgreementDescription3` text,
  `CommentedUserId` varchar(60) DEFAULT NULL,
  `CreationUserId` varchar(60) DEFAULT NULL,
  `UpgradeUserId` varchar(60) DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `ScholarshipProgramTracingAgreementDescription1` text,
  PRIMARY KEY (`ScholarshipProgramTracingAgreementDescriptionId`),
  KEY `IX_ScholarshipProgramTracingAgreementDescription_CommentedUserId` (`CommentedUserId`),
  KEY `IX_ScholarshipProgramTracingAgreementDescription_CreationUserId` (`CreationUserId`),
  KEY `IX_ScholarshipProgramTracingAgreementDescription_ScholarshipPro~` (`ScholarshipProgramTracingId`),
  KEY `IX_ScholarshipProgramTracingAgreementDescription_ScholarshipPr~1` (`ScholarshipProgramUniversityAgreementId`),
  KEY `IX_ScholarshipProgramTracingAgreementDescription_StatusId` (`StatusId`),
  KEY `IX_ScholarshipProgramTracingAgreementDescription_UpgradeUserId` (`UpgradeUserId`),
  CONSTRAINT `FK_ScholarshipProgramTracingAgreementDescription_scholarship_pr~` FOREIGN KEY (`ScholarshipProgramTracingId`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ScholarshipProgramTracingAgreementDescription_scholarship_p~1` FOREIGN KEY (`ScholarshipProgramUniversityAgreementId`) REFERENCES `scholarship_program_university_agreement` (`scholarship_program_university_agreement_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ScholarshipProgramTracingAgreementDescription_status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ScholarshipProgramTracingAgreementDescription_Usuarios_Comme~` FOREIGN KEY (`CommentedUserId`) REFERENCES `usuarios` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ScholarshipProgramTracingAgreementDescription_Usuarios_Creat~` FOREIGN KEY (`CreationUserId`) REFERENCES `usuarios` (`Id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ScholarshipProgramTracingAgreementDescription_Usuarios_Upgra~` FOREIGN KEY (`UpgradeUserId`) REFERENCES `usuarios` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scholarshipprogramtracingagreementdescription`
--

LOCK TABLES `scholarshipprogramtracingagreementdescription` WRITE;
/*!40000 ALTER TABLE `scholarshipprogramtracingagreementdescription` DISABLE KEYS */;
/*!40000 ALTER TABLE `scholarshipprogramtracingagreementdescription` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ScholarshipProgramTracingAgreementsWithPracticeCenter`
--

DROP TABLE IF EXISTS `ScholarshipProgramTracingAgreementsWithPracticeCenter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ScholarshipProgramTracingAgreementsWithPracticeCenter` (
  `AgreementsWithPracticeCenterId` int NOT NULL AUTO_INCREMENT,
  `ActivityDescription` text,
  `Date` datetime DEFAULT NULL,
  `Duration` text,
  `NumberOfParticipatingStudents` int DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `TracingId` int NOT NULL,
  `TracingScholarshipProgramTracingId` bigint DEFAULT NULL,
  `Institution` text,
  `StatusId` int DEFAULT NULL,
  `StatusId1` bigint DEFAULT NULL,
  PRIMARY KEY (`AgreementsWithPracticeCenterId`),
  KEY `IX_ScholarshipProgramTracingAgreementsWithPracticeCenter_Tracin~` (`TracingScholarshipProgramTracingId`),
  KEY `IX_ScholarshipProgramTracingAgreementsWithPracticeCenter_Status~` (`StatusId1`),
  CONSTRAINT `FK_ScholarshipProgramTracingAgreementsWithPracticeCenter_schola~` FOREIGN KEY (`TracingScholarshipProgramTracingId`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ScholarshipProgramTracingAgreementsWithPracticeCenter_status~` FOREIGN KEY (`StatusId1`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ScholarshipProgramTracingAgreementsWithPracticeCenter`
--

LOCK TABLES `ScholarshipProgramTracingAgreementsWithPracticeCenter` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `ScholarshipProgramTracingStudentPracticeFile`
--

DROP TABLE IF EXISTS `ScholarshipProgramTracingStudentPracticeFile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ScholarshipProgramTracingStudentPracticeFile` (
  `ScholarshipProgramTracingStudentPracticeFileId` bigint NOT NULL AUTO_INCREMENT,
  `ScholarshipProgramTracingStudentPracticeId` bigint DEFAULT NULL,
  `FileDescription` text,
  `FileId` bigint DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `StudentPracticeTypeId` bigint DEFAULT NULL,
  PRIMARY KEY (`ScholarshipProgramTracingStudentPracticeFileId`),
  KEY `IX_ScholarshipProgramTracingStudentPracticeFile_FileId` (`FileId`),
  KEY `IX_ScholarshipProgramTracingStudentPracticeFile_ScholarshipProg~` (`ScholarshipProgramTracingStudentPracticeId`),
  KEY `IX_ScholarshipProgramTracingStudentPracticeFile_StatusId` (`StatusId`),
  CONSTRAINT `FK_ScholarshipProgramTracingStudentPracticeFile_file_FileId` FOREIGN KEY (`FileId`) REFERENCES `file` (`file_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ScholarshipProgramTracingStudentPracticeFile_scholarship_pro~` FOREIGN KEY (`ScholarshipProgramTracingStudentPracticeId`) REFERENCES `scholarship_program_tracing_student_practice` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_ScholarshipProgramTracingStudentPracticeFile_status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ScholarshipProgramTracingStudentPracticeFile`
--

LOCK TABLES `ScholarshipProgramTracingStudentPracticeFile` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `spu_taught_subject`
--

DROP TABLE IF EXISTS `spu_taught_subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spu_taught_subject` (
  `spu_taught_subject_id` bigint DEFAULT NULL,
  `subject_matter_id` bigint DEFAULT NULL,
  `Columna 3` bigint DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spu_taught_subject`
--

LOCK TABLES `spu_taught_subject` WRITE;
/*!40000 ALTER TABLE `spu_taught_subject` DISABLE KEYS */;
/*!40000 ALTER TABLE `spu_taught_subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `status_id` bigint NOT NULL AUTO_INCREMENT,
  `status_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `table_id` bigint DEFAULT NULL,
  `table_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`status_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (1,'Activo',NULL,'all'),(2,'Inactivo',NULL,'all'),(3,'En Proceso',NULL,NULL),(4,'Cancelado',NULL,NULL),(5,'Aprobado',NULL,NULL),(6,'No Aprobado',NULL,NULL),(7,'Desertado',NULL,NULL),(8,'Abierto',NULL,NULL),(9,'Cerrado',NULL,NULL),(10,'Seleccionado',NULL,NULL),(11,'Descartado',NULL,NULL),(12,'Pendiente Validar PAA',NULL,NULL),(13,'Imcompleto',NULL,NULL),(14,'Descargado al SCAT',NULL,NULL),(15,'Programado',NULL,'scholarship_tracing'),(16,'Realizado',NULL,'scholarship_tracing'),(17,'Pendiente',NULL,'scholarship_tracing'),(18,'Reprogramado',NULL,'scholarship_tracing'),(19,'Completado',NULL,NULL),(20,'Anulado',NULL,NULL),(21,'Eliminado',NULL,NULL);
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StudentPracticeType`
--

DROP TABLE IF EXISTS `StudentPracticeType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `StudentPracticeType` (
  `StudentPracticeTypeId` int NOT NULL AUTO_INCREMENT,
  `StudentPracticeTypeTypeName` text,
  `CreationDate` datetime DEFAULT NULL,
  `UpgradeDate` datetime DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  PRIMARY KEY (`StudentPracticeTypeId`),
  KEY `IX_StudentPracticeType_StatusId` (`StatusId`),
  CONSTRAINT `FK_StudentPracticeType_status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StudentPracticeType`
--

LOCK TABLES `StudentPracticeType` WRITE;
/*!40000 ALTER TABLE `StudentPracticeType` DISABLE KEYS */;
INSERT INTO `StudentPracticeType` VALUES (1,'Práctica I',NULL,NULL,1),(2,'Práctica II',NULL,NULL,1),(3,'Práctica III',NULL,NULL,1),(4,'Práctica IV',NULL,NULL,1),(5,'Práctica V',NULL,NULL,1),(6,'Práctica VI',NULL,NULL,1);
/*!40000 ALTER TABLE `StudentPracticeType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `study_plan_management`
--

DROP TABLE IF EXISTS `study_plan_management`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `study_plan_management` (
  `study_plan_management_id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_program_university_id` bigint DEFAULT NULL,
  `study_plan_management_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`study_plan_management_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `study_plan_management`
--

LOCK TABLES `study_plan_management` WRITE;
/*!40000 ALTER TABLE `study_plan_management` DISABLE KEYS */;
/*!40000 ALTER TABLE `study_plan_management` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject_matter`
--

DROP TABLE IF EXISTS `subject_matter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subject_matter` (
  `subject_matter_id` bigint NOT NULL AUTO_INCREMENT,
  `subject_matter_code` varchar(32) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL DEFAULT '0',
  `subject_matter_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  `period` text,
  `ScholarshipProgramUniversityId` bigint DEFAULT NULL,
  `TracingStudyPlanDevelopmentId` bigint DEFAULT NULL,
  `Creditos` bigint DEFAULT NULL,
  `AssignedTeacherId` bigint DEFAULT NULL,
  `TeacherId` bigint DEFAULT NULL,
  PRIMARY KEY (`subject_matter_id`) USING BTREE,
  UNIQUE KEY `IX_subject_matter_TracingStudyPlanDevelopmentId` (`TracingStudyPlanDevelopmentId`),
  KEY `FK_subject_matter_user` (`creation_user_id`) USING BTREE,
  KEY `FK_subject_matter_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_subject_matter_status` (`status_id`) USING BTREE,
  KEY `IX_subject_matter_ScholarshipProgramUniversityId` (`ScholarshipProgramUniversityId`),
  KEY `IX_subject_matter_AssignedTeacherId` (`AssignedTeacherId`),
  KEY `IX_subject_matter_TeacherId` (`TeacherId`),
  CONSTRAINT `FK_subject_matter_scholarship_program_university_ScholarshipPro~` FOREIGN KEY (`ScholarshipProgramUniversityId`) REFERENCES `scholarship_program_university` (`scholarship_program_university_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_subject_matter_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_subject_matter_teacher_AssignedTeacherId` FOREIGN KEY (`AssignedTeacherId`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_subject_matter_teacher_TeacherId` FOREIGN KEY (`TeacherId`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_subject_matter_tracing_study_plan_development_TracingStudyPl~` FOREIGN KEY (`TracingStudyPlanDevelopmentId`) REFERENCES `tracing_study_plan_development` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_subject_matter_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_subject_matter_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject_matter`
--

LOCK TABLES `subject_matter` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher` (
  `teacher_id` bigint NOT NULL AUTO_INCREMENT,
  `contact_id` bigint DEFAULT NULL,
  `higher_teacher_education_id` bigint DEFAULT NULL,
  `teacher_hiring_type_id` bigint DEFAULT NULL,
  `teacher_category` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `teacher_job_start_date` date DEFAULT NULL,
  `teacher_is_pac` bit(1) DEFAULT NULL,
  `teacher_has_admin_functions` bit(1) DEFAULT NULL,
  `teacher_work_for_other_institutions` bit(1) DEFAULT NULL,
  `teacher_match_higher_title` bit(1) DEFAULT NULL,
  `teacher_research_process` int DEFAULT NULL,
  `teacher_research_published` int DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  `UniversityId` bigint DEFAULT NULL,
  PRIMARY KEY (`teacher_id`) USING BTREE,
  KEY `FK_teacher_contact` (`contact_id`) USING BTREE,
  KEY `FK_teacher_status` (`status_id`) USING BTREE,
  KEY `FK_teacher_teacher_hiring_type` (`teacher_hiring_type_id`) USING BTREE,
  CONSTRAINT `FK_teacher_contact` FOREIGN KEY (`contact_id`) REFERENCES `contact` (`contact_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_teacher_hiring_type` FOREIGN KEY (`teacher_hiring_type_id`) REFERENCES `teacher_hiring_type` (`teacher_hiring_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `teacher_education`
--

DROP TABLE IF EXISTS `teacher_education`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher_education` (
  `teacher_education_id` bigint NOT NULL AUTO_INCREMENT,
  `teacher_id` bigint NOT NULL DEFAULT '0',
  `teacher_education_title` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `education_type_id` bigint DEFAULT NULL,
  `teacher_education_finish_date` date DEFAULT NULL,
  `teacher_education_institution` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`teacher_education_id`) USING BTREE,
  KEY `FK_teacher_education_education_type` (`education_type_id`) USING BTREE,
  KEY `FK_teacher_education_status` (`status_id`) USING BTREE,
  KEY `FK_teacher_education_teacher` (`teacher_id`) USING BTREE,
  CONSTRAINT `FK_teacher_education_education_type` FOREIGN KEY (`education_type_id`) REFERENCES `education_type` (`education_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_education_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_education_teacher` FOREIGN KEY (`teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher_education`
--

LOCK TABLES `teacher_education` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `teacher_file`
--

DROP TABLE IF EXISTS `teacher_file`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher_file` (
  `teacher_file_id` bigint NOT NULL AUTO_INCREMENT,
  `teacher_id` bigint NOT NULL DEFAULT '0',
  `teacher_research_id` bigint DEFAULT NULL,
  `file_id` bigint DEFAULT NULL,
  `teacher_file_type_id` bigint DEFAULT NULL,
  `teacher_file_comment` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`teacher_file_id`) USING BTREE,
  KEY `FK_teacher_file_file` (`file_id`) USING BTREE,
  KEY `FK_teacher_file_teacher_file_type` (`teacher_file_type_id`) USING BTREE,
  KEY `FK_teacher_file_status` (`status_id`) USING BTREE,
  KEY `FK_teacher_file_teacher` (`teacher_id`) USING BTREE,
  KEY `FK_teacher_file_teacher_research` (`teacher_research_id`) USING BTREE,
  CONSTRAINT `FK_teacher_file_file` FOREIGN KEY (`file_id`) REFERENCES `file` (`file_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_file_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_file_teacher` FOREIGN KEY (`teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_file_teacher_file_type` FOREIGN KEY (`teacher_file_type_id`) REFERENCES `teacher_file_type` (`teacher_file_type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_file_teacher_research` FOREIGN KEY (`teacher_research_id`) REFERENCES `teacher_research` (`teacher_research_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher_file`
--

LOCK TABLES `teacher_file` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `teacher_file_type`
--

DROP TABLE IF EXISTS `teacher_file_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher_file_type` (
  `teacher_file_type_id` bigint NOT NULL AUTO_INCREMENT,
  `teacher_file_type_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`teacher_file_type_id`) USING BTREE,
  KEY `FK_teacher_file_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_teacher_file_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher_file_type`
--

LOCK TABLES `teacher_file_type` WRITE;
/*!40000 ALTER TABLE `teacher_file_type` DISABLE KEYS */;
INSERT INTO `teacher_file_type` VALUES (1,'Copia de cédula o pasaporte a color','2019-04-15 09:52:08',NULL,1),(2,'Certificado de título de licenciatura o equivalente','2019-04-15 09:52:08',NULL,1),(3,'Certificado de títulos de especialidad','2019-04-15 09:52:08',NULL,1),(4,'Certificado de título de Doctorado','2019-05-21 15:07:49',NULL,1),(5,'Curriculum','2019-05-21 15:08:16',NULL,1);
/*!40000 ALTER TABLE `teacher_file_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher_hiring_type`
--

DROP TABLE IF EXISTS `teacher_hiring_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher_hiring_type` (
  `teacher_hiring_type_id` bigint NOT NULL AUTO_INCREMENT,
  `teacher_hiring_type_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`teacher_hiring_type_id`) USING BTREE,
  KEY `FK_teacher_hiring_type_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_teacher_hiring_type_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher_hiring_type`
--

LOCK TABLES `teacher_hiring_type` WRITE;
/*!40000 ALTER TABLE `teacher_hiring_type` DISABLE KEYS */;
INSERT INTO `teacher_hiring_type` VALUES (1,'Por horas o Por Asignatura','2019-04-15 09:51:34',NULL,1),(2,'Tiempo completo','2019-04-15 09:51:43',NULL,1),(3,'Tiempo Parcial','2019-04-15 09:51:50',NULL,1),(4,'Exclusivo','2019-04-15 09:51:50',NULL,1);
/*!40000 ALTER TABLE `teacher_hiring_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher_research`
--

DROP TABLE IF EXISTS `teacher_research`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `teacher_research` (
  `teacher_research_id` bigint NOT NULL,
  `teacher_id` bigint NOT NULL,
  `teacher_research_name` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `teacher_research_quantity` int DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`teacher_research_id`) USING BTREE,
  KEY `FK_teacher_research_status` (`status_id`) USING BTREE,
  KEY `FK_teacher_research_teacher` (`teacher_id`) USING BTREE,
  CONSTRAINT `FK_teacher_research_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_research_teacher` FOREIGN KEY (`teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher_research`
--

LOCK TABLES `teacher_research` WRITE;
/*!40000 ALTER TABLE `teacher_research` DISABLE KEYS */;
/*!40000 ALTER TABLE `teacher_research` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tracing_study_plan_development`
--

DROP TABLE IF EXISTS `tracing_study_plan_development`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tracing_study_plan_development` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `scholarship_program_tracing_id` bigint DEFAULT NULL,
  `subject_matter_id` bigint DEFAULT NULL,
  `teacher_id` bigint DEFAULT NULL,
  `assigned_teacher_id` bigint DEFAULT NULL,
  `higher_title_support_matter_id` bigint DEFAULT NULL,
  `score_average_students` double DEFAULT NULL,
  `approved_students_quantity` int DEFAULT NULL,
  `reproved_students_quantity` int DEFAULT NULL,
  `deserted_students_quantity` int DEFAULT NULL,
  `higher_title_match_assigned_matter` bit(1) DEFAULT NULL,
  `subject_matter_score_report_file_id` bigint DEFAULT NULL,
  `subject_matter_time_start` time DEFAULT NULL,
  `subject_matter_time_end` time DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  `Creditos` bigint DEFAULT NULL,
  `MaleQuantity` int DEFAULT NULL,
  `femaleQuantity` int DEFAULT NULL,
  `StudentReportFileId` bigint DEFAULT NULL,
  `UniverityPeriod` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `FK_tracing` (`scholarship_program_tracing_id`) USING BTREE,
  KEY `FK_teacher_subject_matter` (`subject_matter_id`) USING BTREE,
  KEY `FK_teacher_teacher` (`teacher_id`) USING BTREE,
  KEY `FK_teacher_teacher_2` (`assigned_teacher_id`) USING BTREE,
  KEY `FK_teacher_education` (`higher_title_support_matter_id`) USING BTREE,
  KEY `FK_teacher_status_status` (`status_id`) USING BTREE,
  KEY `IX_tracing_study_plan_development_StudentReportFileId` (`StudentReportFileId`),
  CONSTRAINT `FK_teacher_education` FOREIGN KEY (`higher_title_support_matter_id`) REFERENCES `teacher_education` (`teacher_education_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_status_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_teacher` FOREIGN KEY (`teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_teacher_teacher_2` FOREIGN KEY (`assigned_teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_tracing` FOREIGN KEY (`scholarship_program_tracing_id`) REFERENCES `scholarship_program_tracing` (`scholarship_program_tracing_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_tracing_study_plan_development_file_StudentReportFileId` FOREIGN KEY (`StudentReportFileId`) REFERENCES `file` (`file_id`) ON DELETE RESTRICT,
  CONSTRAINT `FK_tracing_study_plan_development_subject_matter_subject_matter~` FOREIGN KEY (`subject_matter_id`) REFERENCES `subject_matter` (`subject_matter_id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tracing_study_plan_development`
--

LOCK TABLES `tracing_study_plan_development` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `university`
--

DROP TABLE IF EXISTS `university`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `university` (
  `university_id` bigint NOT NULL AUTO_INCREMENT,
  `university_name` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `university_acronym` varchar(64) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `university_campus` varchar(128) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `address_id` bigint DEFAULT NULL,
  `communication_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`university_id`) USING BTREE,
  KEY `FK_university_status` (`status_id`) USING BTREE,
  KEY `FK_university_address` (`address_id`) USING BTREE,
  KEY `FK_university_communication` (`communication_id`) USING BTREE,
  CONSTRAINT `FK_university_address` FOREIGN KEY (`address_id`) REFERENCES `address` (`address_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_university_communication` FOREIGN KEY (`communication_id`) REFERENCES `communication` (`communication_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_university_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `university`
--

LOCK TABLES `university` WRITE;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` bigint NOT NULL AUTO_INCREMENT,
  `company_id` bigint DEFAULT NULL,
  `office_id` bigint DEFAULT NULL,
  `contact_id` bigint DEFAULT NULL,
  `user_login` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `user_password` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `user_role_id` bigint DEFAULT NULL,
  `user_expire_password` bit(1) DEFAULT NULL,
  `user_date_expire_password` datetime DEFAULT NULL,
  `user_schedule_id` bigint DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`user_id`) USING BTREE,
  KEY `FK_user_office` (`office_id`) USING BTREE,
  KEY `FK_user_user_role` (`user_role_id`) USING BTREE,
  KEY `FK_user_schedule` (`user_schedule_id`) USING BTREE,
  KEY `FK_user_status` (`status_id`) USING BTREE,
  KEY `FK_user_user` (`creation_user_id`) USING BTREE,
  KEY `FK_user_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_user_company` (`company_id`) USING BTREE,
  KEY `FK_user_contact` (`contact_id`) USING BTREE,
  CONSTRAINT `FK_user_company` FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_contact` FOREIGN KEY (`contact_id`) REFERENCES `contact` (`contact_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_office` FOREIGN KEY (`office_id`) REFERENCES `office` (`office_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_schedule` FOREIGN KEY (`user_schedule_id`) REFERENCES `schedule` (`schedule_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_user_role` FOREIGN KEY (`user_role_id`) REFERENCES `user_role` (`user_role_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,1,1,NULL,'yenfry','herrera',1,_binary '',NULL,NULL,NULL,NULL,'2018-09-05 17:43:01','2019-08-01 01:44:46',1),(5,1,1,NULL,'intec','intec',2,NULL,NULL,NULL,NULL,NULL,'2019-08-01 02:24:43',NULL,1),(6,1,1,NULL,'inafocam','inafocam',1,NULL,NULL,NULL,NULL,NULL,'2019-08-01 02:25:03',NULL,1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_map_role`
--

DROP TABLE IF EXISTS `user_map_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_map_role` (
  `user_map_role_id` bigint NOT NULL AUTO_INCREMENT,
  `user_id` bigint DEFAULT NULL,
  `user_role_id` bigint DEFAULT NULL,
  PRIMARY KEY (`user_map_role_id`) USING BTREE,
  KEY `FK_user_roles_user` (`user_id`) USING BTREE,
  KEY `FK_user_roles_user_role` (`user_role_id`) USING BTREE,
  CONSTRAINT `FK_user_roles_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_roles_user_role` FOREIGN KEY (`user_role_id`) REFERENCES `user_role` (`user_role_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_map_role`
--

LOCK TABLES `user_map_role` WRITE;
/*!40000 ALTER TABLE `user_map_role` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_map_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_role`
--

DROP TABLE IF EXISTS `user_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_role` (
  `user_role_id` bigint NOT NULL AUTO_INCREMENT,
  `office_id` bigint NOT NULL DEFAULT '0',
  `user_role_name` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `user_role_description` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `creation_user_id` bigint DEFAULT NULL,
  `upgrade_user_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`user_role_id`) USING BTREE,
  KEY `FK_user_role_office` (`office_id`) USING BTREE,
  KEY `FK_user_role_user` (`creation_user_id`) USING BTREE,
  KEY `FK_user_role_user_2` (`upgrade_user_id`) USING BTREE,
  KEY `FK_user_role_status` (`status_id`) USING BTREE,
  CONSTRAINT `FK_user_role_office` FOREIGN KEY (`office_id`) REFERENCES `office` (`office_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_role_status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_role_user` FOREIGN KEY (`creation_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_role_user_2` FOREIGN KEY (`upgrade_user_id`) REFERENCES `user` (`user_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_role`
--

LOCK TABLES `user_role` WRITE;
/*!40000 ALTER TABLE `user_role` DISABLE KEYS */;
INSERT INTO `user_role` VALUES (1,1,'Inafocam Management',NULL,1,NULL,'2019-05-19 13:12:19',NULL,1),(2,1,'University Management',NULL,1,NULL,'2019-05-19 13:12:35',NULL,1);
/*!40000 ALTER TABLE `user_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_role_permission`
--

DROP TABLE IF EXISTS `user_role_permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_role_permission` (
  `user_role_permission_id` bigint NOT NULL AUTO_INCREMENT,
  `user_role_id` bigint DEFAULT NULL,
  `object_id` bigint DEFAULT NULL,
  `user_role_permission_name` enum('INSERT','UPDATE','DELETE','QUERY','ALL') CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `user_role_permission_value` enum('GRANTED','DENIED','GRANTED INDIRECTLY') CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`user_role_permission_id`) USING BTREE,
  KEY `FK_user_role_permission_user_role` (`user_role_id`) USING BTREE,
  KEY `FK_user_role_permission_table` (`object_id`) USING BTREE,
  CONSTRAINT `FK_user_role_permission_table` FOREIGN KEY (`object_id`) REFERENCES `object` (`object_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_user_role_permission_user_role` FOREIGN KEY (`user_role_id`) REFERENCES `user_role` (`user_role_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_role_permission`
--

LOCK TABLES `user_role_permission` WRITE;
/*!40000 ALTER TABLE `user_role_permission` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_role_permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_university`
--

DROP TABLE IF EXISTS `user_university`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_university` (
  `user_university_id` bigint NOT NULL AUTO_INCREMENT,
  `usuario_id` varchar(767) DEFAULT NULL,
  `university_id` bigint DEFAULT NULL,
  `creation_date` datetime DEFAULT NULL,
  `upgrade_date` datetime DEFAULT NULL,
  `user_creation_id` varchar(767) DEFAULT NULL,
  `user_upgrade_id` varchar(767) DEFAULT NULL,
  `status_id` bigint DEFAULT NULL,
  PRIMARY KEY (`user_university_id`) USING BTREE,
  KEY `FK__usuarios` (`usuario_id`) USING BTREE,
  KEY `FK__university` (`university_id`) USING BTREE,
  KEY `FK__status` (`status_id`) USING BTREE,
  CONSTRAINT `FK__status` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK__university` FOREIGN KEY (`university_id`) REFERENCES `university` (`university_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_university`
--

LOCK TABLES `user_university` WRITE;
/*!40000 ALTER TABLE `user_university` DISABLE KEYS */;
INSERT INTO `user_university` VALUES (1,'52950434-522b-46a2-8712-54d9195ef981',1,'2019-08-01 00:43:32','2019-08-01 00:46:27',NULL,NULL,2),(2,'52950434-522b-46a2-8712-54d9195ef981',1,'2019-08-01 01:43:38',NULL,NULL,NULL,2),(3,'52950434-522b-46a2-8712-54d9195ef981',1,'2019-08-01 01:43:49',NULL,NULL,NULL,2),(4,'52950434-522b-46a2-8712-54d9195ef981',1,'2019-08-01 02:24:43',NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `user_university` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `Id` varchar(767) NOT NULL,
  `UserName` text,
  `NormalizedUserName` text,
  `Email` text,
  `NormalizedEmail` text,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  `Nombre` text,
  `Apellido` text,
  `Imagen` text,
  `Role` text,
  `Estado` bit(1) NOT NULL,
  `UniversityId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_UniversityId` (`UniversityId`),
  CONSTRAINT `fk_UniversityId` FOREIGN KEY (`UniversityId`) REFERENCES `university` (`university_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES ('436668eb-ae2d-4153-a9f7-9e600357980b','victor','VICTOR','victor@gmail.com','VICTOR@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAED9AFY2LZraF0WmLgixr7RMB/FecCUfgRjyAhQeUXFZu48X2R7xZ+KD3NT2DUUxklw==','6DX37MXPV6BC647LIPGOPHLAQ7MM6MYS','3e0b2409-ca87-4684-90e9-7deb390c8d09',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Victor','De la Rosa',NULL,'USUARIO EJECUTIVO INAFOCAM',_binary '',NULL),('4f8cf50a-9a99-4e8c-acb2-6c63c47bd05d','olwendiaz','OLWENDIAZ','OlwenDiaz@gmail.com','OLWENDIAZ@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAECAf1XrC138zXjjN0Al6bMhi32hA2sFA1Hs/zXznkuTa6ihVdxMdsNL4BbscOITacQ==','6NRHJMTVO33RM2QBFGP3L2FF3AZSOVJY','80d5155c-3e71-48f8-8117-b44fa0c26553',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'Olwen','Henriquez',NULL,NULL,_binary '',NULL),('52950434-522b-46a2-8712-54d9195ef981','test3','TEST3','test3@gmail.com','TEST3@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEERAskH9TasotatmhZzfGIrn7g3+45OfskHKC54a7RyD5mWEaNuWTWm4Z4TMpQZPLg==','R5QXNJ7M7QHFNPO4R3KEM7XTEKU3BYAV','0b9e0bd2-a1b0-4600-abc5-92e0bdd65f63',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'test3','test3','52950434-522b-46a2-8712-54d9195ef981-620b28d4-aef5-41b1-97b0-96cf9df02ae8.png','GESTIÓN UNIVERSITARIA',_binary '',1),('7062a917-b7ad-4918-9d3b-753c49670ade','prueba','PRUEBA','prueba@hotmail.com','PRUEBA@HOTMAIL.COM',_binary '','AQAAAAEAACcQAAAAECbZqdy4ixHThs8X6Qf9C/spHCKrw+UR/XKeipdVo9FPVT8IgIou4JPKtv3px9PLJg==','CZVFERFUS76YOWOUMUZFBTLWFCJMPMS7','c7efc70b-f43f-48c8-a800-5f4644ed0240',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'prueba','test1','7062a917-b7ad-4918-9d3b-753c49670ade-2426297f-fdb7-44b1-af66-90660e79f17b.png','ADMINISTRADOR INAFOCAM',_binary '',NULL),('7f1dc35d-b6e5-44ba-9186-d6a294168d7a','test5','TEST5','test5@hotmail.com','TEST5@HOTMAIL.COM',_binary '','AQAAAAEAACcQAAAAEGNizZifDhMf33dPBvWAxnrrvtScQW0hSRcKE25lWnl6uP9UDLhdKOW+Xd0KqL4BIg==','PZZOQT56AXCWTHTGGCYRZDHHZH6Z7EVI','75c26018-8bef-4bd7-ae79-2e639b13087f',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'test5','test5',NULL,NULL,_binary '\0',NULL),('d460a177-dc06-43ac-a862-d82c35cc718c','prueba2','PRUEBA2','prueba2@hotmail.com','PRUEBA2@HOTMAIL.COM',_binary '','AQAAAAEAACcQAAAAEGs04IcFhAomfoef3NdLnMqjaenIalbn5Z5zGDG+IAAZvtO9/eluLPNJ9alB0jsRdA==','6Y3LX33QLLR36T5TVOGFPXAW3TH52AFZ','d1fd64e6-1ed7-47e8-b1c1-db3765853026',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'prueba2','prueba2',NULL,'ADMINISTRADOR INAFOCAM',_binary '',4),('f82e26ab-ab78-4f06-a34e-2a964e886a59','prueba3','PRUEBA3','prueba3@hotmail.com','PRUEBA3@HOTMAIL.COM',_binary '','AQAAAAEAACcQAAAAEBDUrbQfE5ZUM8BFWvT/rr4DdTL/tAuQnB/AUUd1uzyTOiBt574HxHPd86SfDpffVQ==','WEQGKPELNUXIHKRZBEN7YI7UXZ5ISRN5','b9bbce95-3ee7-491d-91c0-86c0eb7bef9d',NULL,_binary '\0',_binary '\0',NULL,_binary '',0,'prueba3','prueba3',NULL,'ADMINISTRADOR INAFOCAM',_binary '\0',NULL);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-08-21 15:44:12
