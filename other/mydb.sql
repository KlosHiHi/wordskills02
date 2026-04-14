CREATE DATABASE  IF NOT EXISTS `mydb` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `mydb`;
-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.45

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
-- Table structure for table `formulation_items`
--

DROP TABLE IF EXISTS `formulation_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `formulation_items` (
  `formulation_id` int NOT NULL,
  `item_id` int NOT NULL,
  `quantity` tinyint DEFAULT NULL,
  PRIMARY KEY (`formulation_id`,`item_id`),
  KEY `fk_formulations_has_formulation_items_formulation_items1_idx` (`item_id`),
  KEY `fk_formulations_has_formulation_items_formulations1_idx` (`formulation_id`),
  CONSTRAINT `fk_formulations_has_formulation_items_formulation_items1` FOREIGN KEY (`item_id`) REFERENCES `items` (`id`),
  CONSTRAINT `fk_formulations_has_formulation_items_formulations1` FOREIGN KEY (`formulation_id`) REFERENCES `formulations` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formulation_items`
--

LOCK TABLES `formulation_items` WRITE;
/*!40000 ALTER TABLE `formulation_items` DISABLE KEYS */;
INSERT INTO `formulation_items` VALUES (1,1,50),(1,2,30),(1,3,20),(2,1,50),(2,2,60),(3,1,100);
/*!40000 ALTER TABLE `formulation_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formulations`
--

DROP TABLE IF EXISTS `formulations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `formulations` (
  `id` int NOT NULL AUTO_INCREMENT,
  `product_id` int NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `is_current` tinyint DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_formulations_product_idx` (`product_id`),
  CONSTRAINT `fk_formulations_product` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formulations`
--

LOCK TABLES `formulations` WRITE;
/*!40000 ALTER TABLE `formulations` DISABLE KEYS */;
INSERT INTO `formulations` VALUES (1,1,'f1','222',0),(2,1,'f2','qwe',1),(3,1,'f3','q',1),(4,2,'f4','q',1),(5,2,'f5','555',0),(6,3,'f6','q',0);
/*!40000 ALTER TABLE `formulations` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `formulations_AFTER_UPDATE` BEFORE UPDATE ON `formulations` FOR EACH ROW BEGIN
   -- Проверяем только если статус меняется на 'approved'
   IF NEW.status = 'approved' AND
      (SELECT IFNULL(SUM(quantity),0) FROM formulation_items WHERE formulation_id = NEW.id) > 100 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "Can not update that status";
   END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `formulations_AFTER_UPDATE_1` AFTER UPDATE ON `formulations` FOR EACH ROW BEGIN
   -- Если статус меняется на 'approved'
   IF NEW.status = 'approved' AND OLD.status != 'approved' THEN
      -- Меняем статус у всех рецептур с таким же product_id, кроме текущей
      UPDATE formulations 
      SET status = 'archieved', is_current=0
      WHERE product_id = NEW.product_id 
        AND id != NEW.id
        AND status != 'archieved'; -- опционально: обновляем только если статус не already not_approved
   END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `items` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES (1,'it1'),(2,'it2'),(3,'it3');
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'p1'),(2,'p2'),(3,'p3');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tech_card`
--

DROP TABLE IF EXISTS `tech_card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tech_card` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `product_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tech_card_product1_idx` (`product_id`),
  CONSTRAINT `fk_tech_card_product1` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tech_card`
--

LOCK TABLES `tech_card` WRITE;
/*!40000 ALTER TABLE `tech_card` DISABLE KEYS */;
INSERT INTO `tech_card` VALUES (1,'t1','approved',1),(2,'t2','approved',1),(3,'t3','not_approved',2);
/*!40000 ALTER TABLE `tech_card` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tech_card_BEFORE_UPDATE` BEFORE UPDATE ON `tech_card` FOR EACH ROW BEGIN
    DECLARE v_required_exists INT;
    -- Проверяем, есть ли уже обязательные шаги у этой tech_card
    SELECT COUNT(*) INTO v_required_exists
    FROM tech_card_steps
    WHERE tech_card_id = NEW.id AND is_required = 1;
     
    -- Запрещаем смену статуса на 'approved', если нет обязательных шагов
    IF NEW.status = 'approved' AND v_required_exists = 0 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Cannot approve tech_card: at least one required step is needed';
    END IF;  
    
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `tech_card_steps`
--

DROP TABLE IF EXISTS `tech_card_steps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tech_card_steps` (
  `id` int NOT NULL AUTO_INCREMENT,
  `tech_card_id` int NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `is_required` tinyint DEFAULT '0',
  `number` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tech_card_steps_tech_card1_idx` (`tech_card_id`),
  CONSTRAINT `fk_tech_card_steps_tech_card1` FOREIGN KEY (`tech_card_id`) REFERENCES `tech_card` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tech_card_steps`
--

LOCK TABLES `tech_card_steps` WRITE;
/*!40000 ALTER TABLE `tech_card_steps` DISABLE KEYS */;
INSERT INTO `tech_card_steps` VALUES (1,1,'s1',0,1),(2,1,'s2',1,2),(3,2,'s3',0,1),(4,2,'s4',1,2),(5,2,'s5',0,3),(6,3,'s6',0,1);
/*!40000 ALTER TABLE `tech_card_steps` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-13  9:03:25
