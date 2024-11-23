CREATE DATABASE  IF NOT EXISTS `management` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `management`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: management
-- ------------------------------------------------------
-- Server version	8.0.37

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
-- Table structure for table `estatisticas`
--

DROP TABLE IF EXISTS `estatisticas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estatisticas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `modalidade_id` int NOT NULL,
  `equipe_id` int DEFAULT NULL,
  `atleta_id` int DEFAULT NULL,
  `gols` int DEFAULT '0',
  `assistencias` int DEFAULT '0',
  `cartoes_amarelos` int DEFAULT '0',
  `cartoes_vermelhos` int DEFAULT '0',
  `minutos_jogados` int DEFAULT '0',
  `outros_dados` text,
  PRIMARY KEY (`id`),
  KEY `modalidade_id` (`modalidade_id`),
  KEY `equipe_id` (`equipe_id`),
  KEY `atleta_id` (`atleta_id`),
  CONSTRAINT `estatisticas_ibfk_1` FOREIGN KEY (`modalidade_id`) REFERENCES `modalidades` (`id`),
  CONSTRAINT `estatisticas_ibfk_2` FOREIGN KEY (`equipe_id`) REFERENCES `equipes` (`id`),
  CONSTRAINT `estatisticas_ibfk_3` FOREIGN KEY (`atleta_id`) REFERENCES `atletas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estatisticas`
--

LOCK TABLES `estatisticas` WRITE;
/*!40000 ALTER TABLE `estatisticas` DISABLE KEYS */;
INSERT INTO `estatisticas` VALUES (1,1,1,1,2,1,0,0,90,'Sem ocorrências'),(2,1,1,2,0,2,1,0,80,'Cartão amarelo recebido'),(3,1,2,3,3,1,0,0,90,'Hat-trick de Pedro no Futebol'),(4,2,3,4,10,5,0,0,40,'Jogo de Basquete para Ana'),(5,2,4,5,8,3,0,0,40,'Mariana brilhou no Basquete');
/*!40000 ALTER TABLE `estatisticas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-08 12:41:45
