-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.4.14-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.16.0.7229
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para bdvideoclub
CREATE DATABASE IF NOT EXISTS `bdvideoclub` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `bdvideoclub`;

-- Volcando estructura para tabla bdvideoclub.alquiler
CREATE TABLE IF NOT EXISTS `alquiler` (
  `precio` int(11) NOT NULL,
  `pelicula_id` int(11) NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `monto` int(11) NOT NULL DEFAULT 0,
  `fecha_alquiler` varchar(50) NOT NULL,
  `fecha_vencimiento` varchar(50) NOT NULL,
  KEY `Codigo_peli` (`pelicula_id`) USING BTREE,
  KEY `Codigo_cliente` (`cliente_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla bdvideoclub.alquiler: ~0 rows (aproximadamente)

-- Volcando estructura para tabla bdvideoclub.clientes
CREATE TABLE IF NOT EXISTS `clientes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `deuda` tinyint(1) DEFAULT 0,
  `dni` int(11) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla bdvideoclub.clientes: ~1 rows (aproximadamente)
INSERT INTO `clientes` (`id`, `nombre`, `deuda`, `dni`) VALUES
	(2, 'Dylan', 1, 0);

-- Volcando estructura para tabla bdvideoclub.pelicula
CREATE TABLE IF NOT EXISTS `pelicula` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL DEFAULT '0',
  `precio` int(11) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla bdvideoclub.pelicula: ~0 rows (aproximadamente)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
