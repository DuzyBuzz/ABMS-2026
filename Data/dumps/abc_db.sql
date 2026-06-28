CREATE DATABASE  IF NOT EXISTS `abc_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `abc_db`;
-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: abc_db
-- ------------------------------------------------------
-- Server version	8.0.44

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
-- Table structure for table `bite_case_category_basis`
--

DROP TABLE IF EXISTS `bite_case_category_basis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bite_case_category_basis` (
  `basis_id` int NOT NULL AUTO_INCREMENT,
  `bite_case_id` int NOT NULL,
  `exposure_category_id` int DEFAULT NULL,
  PRIMARY KEY (`basis_id`),
  KEY `fk_basis_case` (`bite_case_id`),
  CONSTRAINT `fk_basis_case` FOREIGN KEY (`bite_case_id`) REFERENCES `bite_cases` (`bite_case_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `bite_cases`
--

DROP TABLE IF EXISTS `bite_cases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bite_cases` (
  `bite_case_id` int NOT NULL AUTO_INCREMENT,
  `patient_id` int NOT NULL,
  `exposure_date` date DEFAULT NULL,
  `incident_place` text,
  `animal_type` varchar(100) DEFAULT NULL,
  `animal_classification` varchar(100) DEFAULT 'Unknown',
  `animal_status` varchar(100) DEFAULT 'Unknown',
  `is_wound_washed` tinyint DEFAULT NULL,
  `wound_type` varchar(100) DEFAULT '0',
  `wound_count` varchar(100) DEFAULT NULL,
  `wound_classification` varchar(100) DEFAULT NULL,
  `bite_locations` text,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `bite_chart_path` text,
  PRIMARY KEY (`bite_case_id`),
  KEY `fk_bitecase_patient` (`patient_id`),
  CONSTRAINT `fk_bitecase_patient` FOREIGN KEY (`patient_id`) REFERENCES `patients` (`patient_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `category_basis_master`
--

DROP TABLE IF EXISTS `category_basis_master`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category_basis_master` (
  `basis_id` int NOT NULL AUTO_INCREMENT,
  `exposure_category` varchar(10) DEFAULT NULL,
  `basis_description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`basis_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `chronic_illnesses`
--

DROP TABLE IF EXISTS `chronic_illnesses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chronic_illnesses` (
  `illness_id` int NOT NULL AUTO_INCREMENT,
  `bite_case_id` int NOT NULL,
  `illness_name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`illness_id`),
  KEY `fk_illness_case` (`bite_case_id`),
  CONSTRAINT `fk_illness_case` FOREIGN KEY (`bite_case_id`) REFERENCES `bite_cases` (`bite_case_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `doctor_orders`
--

DROP TABLE IF EXISTS `doctor_orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctor_orders` (
  `doctor_order_id` int NOT NULL AUTO_INCREMENT,
  `bite_case_id` int NOT NULL,
  `history_present_illness` text,
  `physical_examination` text,
  `diagnosis` text,
  `management` text,
  `other_management` text,
  `medication_antibiotic` varchar(255) DEFAULT NULL,
  `medication_nsaid` varchar(255) DEFAULT NULL,
  `medication_others` varchar(255) DEFAULT NULL,
  `is_pep` tinyint(1) DEFAULT '0',
  `is_prep` tinyint(1) DEFAULT '0',
  `is_erig` tinyint(1) DEFAULT '0',
  `is_hrig` tinyint(1) DEFAULT '0',
  `is_tetanus_diphtheria` tinyint(1) DEFAULT '0',
  `is_tetanus_toxoid` tinyint(1) DEFAULT '0',
  `is_anti_tetanus_serum` tinyint(1) DEFAULT '0',
  `doctor_name` varchar(200) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`doctor_order_id`),
  KEY `bite_case_id` (`bite_case_id`),
  CONSTRAINT `doctor_orders_ibfk_1` FOREIGN KEY (`bite_case_id`) REFERENCES `bite_cases` (`bite_case_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `inventory_items`
--

DROP TABLE IF EXISTS `inventory_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory_items` (
  `item_id` bigint NOT NULL AUTO_INCREMENT,
  `generic_name` varchar(255) NOT NULL,
  `brand_name` varchar(255) DEFAULT NULL,
  `category` varchar(50) NOT NULL,
  `strength` varchar(100) DEFAULT NULL,
  `dosage_form` varchar(50) DEFAULT NULL,
  `unit` varchar(50) NOT NULL,
  `quantity_on_hand` decimal(18,2) DEFAULT '0.00',
  `reorder_level` decimal(18,2) DEFAULT '0.00',
  `expiration_date` date DEFAULT NULL,
  `is_active` tinyint(1) DEFAULT '1',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `inventory_transactions`
--

DROP TABLE IF EXISTS `inventory_transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory_transactions` (
  `transaction_id` bigint NOT NULL AUTO_INCREMENT,
  `item_id` bigint NOT NULL,
  `transaction_type` enum('IN','OUT','ADJUSTMENT') NOT NULL,
  `quantity` decimal(18,2) NOT NULL,
  `remarks` text,
  `reference_no` varchar(100) DEFAULT NULL,
  `created_by` bigint DEFAULT NULL,
  `transaction_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `treatment_schedule_id` int DEFAULT NULL,
  `expiration_date` datetime DEFAULT NULL,
  PRIMARY KEY (`transaction_id`),
  KEY `item_id` (`item_id`),
  CONSTRAINT `inventory_transactions_ibfk_1` FOREIGN KEY (`item_id`) REFERENCES `inventory_items` (`item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `patient_symptoms`
--

DROP TABLE IF EXISTS `patient_symptoms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patient_symptoms` (
  `symptom_id` int NOT NULL AUTO_INCREMENT,
  `bite_case_id` int NOT NULL,
  `symptom_name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`symptom_id`),
  KEY `fk_symptom_case` (`bite_case_id`),
  CONSTRAINT `fk_symptom_case` FOREIGN KEY (`bite_case_id`) REFERENCES `bite_cases` (`bite_case_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patients` (
  `patient_id` int NOT NULL AUTO_INCREMENT,
  `registration_no` varchar(20) DEFAULT NULL,
  `last_name` varchar(100) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `middle_name` varchar(100) DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `age` int DEFAULT NULL,
  `sex` enum('Male','Female') DEFAULT NULL,
  `civil_status` varchar(50) DEFAULT NULL,
  `address` text,
  `contact_no` varchar(50) DEFAULT NULL,
  `weight` decimal(5,2) DEFAULT NULL,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `image` longblob,
  PRIMARY KEY (`patient_id`),
  UNIQUE KEY `registration_no` (`registration_no`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_patients_registration_no` BEFORE INSERT ON `patients` FOR EACH ROW BEGIN
    DECLARE next_id INT;

    SELECT AUTO_INCREMENT
    INTO next_id
    FROM information_schema.TABLES
    WHERE TABLE_SCHEMA = DATABASE()
      AND TABLE_NAME = 'patients';

    SET NEW.registration_no =
        CONCAT('SHOT-', LPAD(next_id, 5, '0'));
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `prophylaxis_history`
--

DROP TABLE IF EXISTS `prophylaxis_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prophylaxis_history` (
  `prophylaxis_history_id` int NOT NULL AUTO_INCREMENT,
  `bite_case_id` int NOT NULL,
  `date_given` date NOT NULL,
  `vaccine_brand` varchar(100) DEFAULT NULL,
  `route` enum('Intradermal','Intramuscular') DEFAULT NULL,
  `is_hrig_given` tinyint(1) DEFAULT '0',
  `is_booster` tinyint(1) DEFAULT '0',
  `pep_completed_date` date DEFAULT NULL,
  `consent_notes` text,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`prophylaxis_history_id`),
  KEY `bite_case_id` (`bite_case_id`),
  CONSTRAINT `prophylaxis_history_ibfk_1` FOREIGN KEY (`bite_case_id`) REFERENCES `bite_cases` (`bite_case_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `treatment_schedule`
--

DROP TABLE IF EXISTS `treatment_schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `treatment_schedule` (
  `treatment_schedule_id` int NOT NULL AUTO_INCREMENT,
  `bite_case_id` int NOT NULL,
  `schedule_day` enum('Day 0','Day 3','Day 7','Day 14','Day 28','Booster') DEFAULT NULL,
  `scheduled_date` date NOT NULL,
  `administered_date` date DEFAULT NULL,
  `biologic_type` enum('Rabies Vaccine','ERIG','HRIG','Tetanus Toxoid','Td','ATS') DEFAULT NULL,
  `item_id` int DEFAULT NULL,
  `quantity_used` decimal(10,2) DEFAULT '1.00',
  `status` enum('Scheduled','Completed','Missed','Cancelled') DEFAULT 'Scheduled',
  `administered_by` varchar(200) DEFAULT NULL,
  `remarks` text,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`treatment_schedule_id`),
  KEY `bite_case_id` (`bite_case_id`),
  CONSTRAINT `treatment_schedule_ibfk_1` FOREIGN KEY (`bite_case_id`) REFERENCES `bite_cases` (`bite_case_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) NOT NULL,
  `password` text NOT NULL,
  `full_name` varchar(200) DEFAULT NULL,
  `role` enum('Admin','Doctor','Nurse','Encoder') NOT NULL,
  `status` enum('Active','Inactive') DEFAULT 'Active',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `is_active` tinyint DEFAULT '1',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `v_bite_cases`
--

DROP TABLE IF EXISTS `v_bite_cases`;
/*!50001 DROP VIEW IF EXISTS `v_bite_cases`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_bite_cases` AS SELECT 
 1 AS `bite_case_id`,
 1 AS `patient_id`,
 1 AS `patient_name`,
 1 AS `exposure_date`,
 1 AS `incident_place`,
 1 AS `animal_type`,
 1 AS `animal_classification`,
 1 AS `animal_status`,
 1 AS `is_wound_washed`,
 1 AS `wound_type`,
 1 AS `wound_count`,
 1 AS `wound_classification`,
 1 AS `bite_locations`,
 1 AS `bite_chart_path`,
 1 AS `created_at`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_patients`
--

DROP TABLE IF EXISTS `v_patients`;
/*!50001 DROP VIEW IF EXISTS `v_patients`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_patients` AS SELECT 
 1 AS `patient_id`,
 1 AS `registration_no`,
 1 AS `last_name`,
 1 AS `first_name`,
 1 AS `middle_name`,
 1 AS `birth_date`,
 1 AS `age`,
 1 AS `sex`,
 1 AS `civil_status`,
 1 AS `address`,
 1 AS `contact_no`,
 1 AS `weight`,
 1 AS `created_at`,
 1 AS `image`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_transactions`
--

DROP TABLE IF EXISTS `v_transactions`;
/*!50001 DROP VIEW IF EXISTS `v_transactions`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_transactions` AS SELECT 
 1 AS `transaction_id`,
 1 AS `item_id`,
 1 AS `generic_name`,
 1 AS `brand_name`,
 1 AS `item_name`,
 1 AS `category`,
 1 AS `strength`,
 1 AS `dosage_form`,
 1 AS `unit`,
 1 AS `transaction_type`,
 1 AS `quantity`,
 1 AS `remarks`,
 1 AS `reference_no`,
 1 AS `created_by`,
 1 AS `transaction_date`,
 1 AS `treatment_schedule_id`,
 1 AS `expiration_date`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'abc_db'
--

--
-- Dumping routines for database 'abc_db'
--

--
-- Final view structure for view `v_bite_cases`
--

/*!50001 DROP VIEW IF EXISTS `v_bite_cases`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_bite_cases` AS select `bc`.`bite_case_id` AS `bite_case_id`,`bc`.`patient_id` AS `patient_id`,concat(`p`.`last_name`,', ',`p`.`first_name`,(case when ((`p`.`middle_name` is null) or (`p`.`middle_name` = '')) then '' else concat(' ',left(`p`.`middle_name`,1),'.') end)) AS `patient_name`,`bc`.`exposure_date` AS `exposure_date`,`bc`.`incident_place` AS `incident_place`,`bc`.`animal_type` AS `animal_type`,`bc`.`animal_classification` AS `animal_classification`,`bc`.`animal_status` AS `animal_status`,`bc`.`is_wound_washed` AS `is_wound_washed`,`bc`.`wound_type` AS `wound_type`,`bc`.`wound_count` AS `wound_count`,`bc`.`wound_classification` AS `wound_classification`,`bc`.`bite_locations` AS `bite_locations`,`bc`.`bite_chart_path` AS `bite_chart_path`,`bc`.`created_at` AS `created_at` from (`bite_cases` `bc` join `patients` `p` on((`bc`.`patient_id` = `p`.`patient_id`))) order by `bc`.`exposure_date` desc,`bc`.`bite_case_id` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_patients`
--

/*!50001 DROP VIEW IF EXISTS `v_patients`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_patients` AS select `patients`.`patient_id` AS `patient_id`,`patients`.`registration_no` AS `registration_no`,`patients`.`last_name` AS `last_name`,`patients`.`first_name` AS `first_name`,`patients`.`middle_name` AS `middle_name`,`patients`.`birth_date` AS `birth_date`,timestampdiff(YEAR,`patients`.`birth_date`,curdate()) AS `age`,`patients`.`sex` AS `sex`,`patients`.`civil_status` AS `civil_status`,`patients`.`address` AS `address`,`patients`.`contact_no` AS `contact_no`,`patients`.`weight` AS `weight`,`patients`.`created_at` AS `created_at`,`patients`.`image` AS `image` from `patients` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_transactions`
--

/*!50001 DROP VIEW IF EXISTS `v_transactions`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_transactions` AS select `it`.`transaction_id` AS `transaction_id`,`it`.`item_id` AS `item_id`,`ii`.`generic_name` AS `generic_name`,`ii`.`brand_name` AS `brand_name`,(case when ((`ii`.`brand_name` is null) or (`ii`.`brand_name` = '')) then `ii`.`generic_name` else concat(`ii`.`generic_name`,' (',`ii`.`brand_name`,')') end) AS `item_name`,`ii`.`category` AS `category`,`ii`.`strength` AS `strength`,`ii`.`dosage_form` AS `dosage_form`,`ii`.`unit` AS `unit`,`it`.`transaction_type` AS `transaction_type`,`it`.`quantity` AS `quantity`,`it`.`remarks` AS `remarks`,`it`.`reference_no` AS `reference_no`,`it`.`created_by` AS `created_by`,`it`.`transaction_date` AS `transaction_date`,`it`.`treatment_schedule_id` AS `treatment_schedule_id`,`it`.`expiration_date` AS `expiration_date` from (`inventory_transactions` `it` join `inventory_items` `ii` on((`it`.`item_id` = `ii`.`item_id`))) order by `it`.`transaction_date` desc,`it`.`transaction_id` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-27 14:02:52
