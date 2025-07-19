-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         9.0.1 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para radio_demo
CREATE DATABASE IF NOT EXISTS `radio_demo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `radio_demo`;

-- Volcando estructura para procedimiento radio_demo.ActualizarContrasenia
DELIMITER //
CREATE PROCEDURE `ActualizarContrasenia`(
	IN `idVendedor` INT,
	IN `nuevaContrasenia` VARCHAR(200)
)
BEGIN

	UPDATE vendedor v
	SET
		v.CONTRASENIA_VENDEDOR = SHA2(nuevaContrasenia, 256)
	WHERE
		v.ID_VENDEDOR = idVendedor;
		
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.AgregarAnunciante
DELIMITER //
CREATE PROCEDURE `AgregarAnunciante`(
	IN nit INT,
	IN nombre VARCHAR(50),
	IN direccion VARCHAR(70),
	IN telefono VARCHAR(50),
	IN documento INT,
	IN nombre1 VARCHAR(50),
	IN nombre2 VARCHAR(50),
	IN apellido1 VARCHAR(50),
	IN apellido2 VARCHAR(50),
	IN fecha DATE,
	IN correo VARCHAR(70),
	IN idTipoDocumento INT,
	IN idGenero INT
)
BEGIN
	
	INSERT INTO persona (persona.DOCUMENTO_PERSONA, persona.NOMBRE1_PERSONA, persona.NOMBRE2_PERSONA, persona.APELLIDO1_PERSONA, persona.APELLIDO2_PERSONA, persona.FECHANACIMIENTO_PERSONA, persona.CORREO_PERSONA, persona.FK_ID_TIPODOCUMENTO, persona.FK_ID_GENERO)
	VALUES (documento, nombre1, nombre2, apellido1, apellido2, fecha, correo, idTipoDocumento, idGenero);
	
	INSERT INTO anunciante (anunciante.NIT_ANUNCIANTE, anunciante.NOMBRE_ANUNCIANTE, anunciante.DIRECCION_ANUNCIANTE, anunciante.TELEFONO_ANUNCIANTE, anunciante.FK_DOCUMENTO_PERSONA)
	VALUES (nit, nombre, direccion, telefono, documento);
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.AgregarContrato
DELIMITER //
CREATE PROCEDURE `AgregarContrato`(
	IN `nombre` VARCHAR(70),
	IN `fechaInicio` DATE,
	IN `fechaFin` DATE,
	IN `valor` INT,
	IN `idvendedor` INT,
	IN `idanunciante` INT,
	IN `numCunias` INT
)
BEGIN
	
	INSERT INTO contrato (contrato.NOMBRE_CONTRATO, contrato.FECHAINICIO_CONTRATO, contrato.FECHAFIN_CONTRATO, contrato.FECHACREACION_CONTRATO, contrato.VALORTOTAL_CONTRATO, contrato.FK_ID_VENDEDOR, contrato.FK_NIT_ANUNCIANTE, contrato.NUMEROCUNIAS_CONTRATO)
	VALUES (nombre, fechaInicio, fechaFin, NOW(), valor, idvendedor, idanunciante, numCunias);
	
	SELECT LAST_INSERT_ID();
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.AgregarCunia
DELIMITER //
CREATE PROCEDURE `AgregarCunia`(
	IN nombre VARCHAR(70),
	IN descripcion VARCHAR(500),
	IN idtarifa INT,
	IN idcontrato INT
)
BEGIN
	
	INSERT INTO cunia (cunia.NOMBRE_CUNIA, cunia.DESCRIPCION_CUNIA, cunia.FK_ID_TARIFA, cunia.FK_ID_CONTRATO)
	VALUES (nombre, descripcion, idtarifa, idcontrato);
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.AgregarPrograma
DELIMITER //
CREATE PROCEDURE `AgregarPrograma`(
	IN nombre VARCHAR(50)
)
BEGIN
	
	INSERT INTO programa (programa.NOMBRE_PROGRAMA)
	VALUES (nombre);
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.AgregarTarifa
DELIMITER //
CREATE PROCEDURE `AgregarTarifa`(
	IN valor1 INT,
	IN valor2 INT,
	IN rango1 INT,
	IN rango2 INT,
	IN idPrograma INT
)
BEGIN
	
	INSERT INTO tarifa (tarifa.VALORPUBLICADO_TARIFA, tarifa.VALORREAL_TARIFA, tarifa.RANGOINICIO_TARIFA, tarifa.RANGOFIN_TARIFA, tarifa.FK_ID_PROGRAMA)
	VALUES (valor1, valor2, rango1, rango2, idPrograma);
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.AgregarVendedor
DELIMITER //
CREATE PROCEDURE `AgregarVendedor`(
	IN username VARCHAR(50),
	IN idRol INT,
	IN documento INT,
	IN nombre1 VARCHAR(50),
	IN nombre2 VARCHAR(50),
	IN apellido1 VARCHAR(50),
	IN apellido2 VARCHAR(50),
	IN fecha DATE,
	IN correo VARCHAR(70),
	IN idTipoDocumento INT,
	IN idGenero INT
)
BEGIN
	
	INSERT INTO persona (persona.DOCUMENTO_PERSONA, persona.NOMBRE1_PERSONA, persona.NOMBRE2_PERSONA, persona.APELLIDO1_PERSONA, persona.APELLIDO2_PERSONA, persona.FECHANACIMIENTO_PERSONA, persona.CORREO_PERSONA, persona.FK_ID_TIPODOCUMENTO, persona.FK_ID_GENERO)
	VALUES (documento, nombre1, nombre2, apellido1, apellido2, fecha, correo, idTipoDocumento, idGenero);
	
	INSERT INTO vendedor (vendedor.USERNAME_VENDEDOR, vendedor.CONTRASENIA_VENDEDOR, vendedor.FK_DOCUMENTO_PERSONA, vendedor.FK_ID_ROL)
	VALUES (username, documento + '', documento, idRol);
	
END//
DELIMITER ;

-- Volcando estructura para tabla radio_demo.anunciante
CREATE TABLE IF NOT EXISTS `anunciante` (
  `NIT_ANUNCIANTE` int NOT NULL,
  `NOMBRE_ANUNCIANTE` varchar(50) NOT NULL,
  `DIRECCION_ANUNCIANTE` varchar(50) NOT NULL,
  `TELEFONO_ANUNCIANTE` varchar(50) NOT NULL,
  `FK_DOCUMENTO_PERSONA` int NOT NULL,
  PRIMARY KEY (`NIT_ANUNCIANTE`),
  KEY `FK_PERSONA_ANUNCIANTE` (`FK_DOCUMENTO_PERSONA`),
  CONSTRAINT `FK_PERSONA_ANUNCIANTE` FOREIGN KEY (`FK_DOCUMENTO_PERSONA`) REFERENCES `persona` (`DOCUMENTO_PERSONA`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.anunciante: ~2 rows (aproximadamente)
INSERT INTO `anunciante` (`NIT_ANUNCIANTE`, `NOMBRE_ANUNCIANTE`, `DIRECCION_ANUNCIANTE`, `TELEFONO_ANUNCIANTE`, `FK_DOCUMENTO_PERSONA`) VALUES
	(900001001, 'Alimentos San Jorge', 'Calle 10 #12-34', '3101234567', 10101010),
	(900001002, 'Publicidad Total', 'Cra 8 #45-67', '3129876543', 20202020),
	(900001003, 'Medios Express', 'Av. Siempre Viva #123', '3114567890', 30303030),
	(900001004, 'Comunicaciones Zeta', 'Calle 23 #4-56', '3131112222', 40404040),
	(900001005, 'Eventos y Más', 'Cra 18 #7-89', '3208889999', 50505050);

-- Volcando estructura para tabla radio_demo.auditoriaeliminartarifa
CREATE TABLE IF NOT EXISTS `auditoriaeliminartarifa` (
  `ID_AUDITORIAELIMINARTARIFA` int NOT NULL AUTO_INCREMENT,
  `TARIFA_AUDITORIAELIMINARTARIFA` int NOT NULL,
  `FECHA_AUDITORIAELIMINARTARIFA` datetime NOT NULL,
  PRIMARY KEY (`ID_AUDITORIAELIMINARTARIFA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.auditoriaeliminartarifa: ~2 rows (aproximadamente)

-- Volcando estructura para procedimiento radio_demo.BuscarAnunciante
DELIMITER //
CREATE PROCEDURE `BuscarAnunciante`(
	IN nit INT
)
BEGIN

	SELECT anunciante.NIT_ANUNCIANTE, anunciante.NOMBRE_ANUNCIANTE, anunciante.DIRECCION_ANUNCIANTE, anunciante.TELEFONO_ANUNCIANTE,
	persona.DOCUMENTO_PERSONA, persona.NOMBRE1_PERSONA, persona.NOMBRE2_PERSONA, persona.APELLIDO1_PERSONA, persona.APELLIDO2_PERSONA, persona.FECHANACIMIENTO_PERSONA, persona.CORREO_PERSONA,
	tipodocumento.ID_TIPODOCUMENTO, tipodocumento.NOMBRE_TIPODOCUMENTO, tipodocumento.ESTADO_TIPODOCUMENTO,
	genero.ID_GENERO, genero.NOMBRE_GENERO, genero.ESTADO_GENERO
	FROM anunciante
	INNER JOIN persona ON anunciante.FK_DOCUMENTO_PERSONA = persona.DOCUMENTO_PERSONA
	INNER JOIN tipodocumento ON persona.FK_ID_TIPODOCUMENTO = tipodocumento.ID_TIPODOCUMENTO
	INNER JOIN genero ON persona.FK_ID_GENERO = genero.ID_GENERO
	WHERE anunciante.NIT_ANUNCIANTE = nit;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.BuscarContrato
DELIMITER //
CREATE PROCEDURE `BuscarContrato`(
	IN id INT
)
BEGIN
	
	SELECT *
	FROM vistabuscarcontrato
	WHERE vistabuscarcontrato.ID_CONTRATO = id;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.BuscarPermisos
DELIMITER //
CREATE PROCEDURE `BuscarPermisos`(
	IN id INT
)
BEGIN
	
	SELECT permiso.ID_PERMISO, permiso.NOMBRE_PERMISO
	FROM permiso
	INNER JOIN permisorol ON permisorol.FK_ID_PERMISO = permiso.ID_PERMISO
	WHERE permisorol.FK_ID_ROL = id;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.BuscarTarifa
DELIMITER //
CREATE PROCEDURE `BuscarTarifa`(
	IN id INT
)
BEGIN
	
	SELECT tarifa.ID_TARIFA, tarifa.VALORPUBLICADO_TARIFA, tarifa.VALORREAL_TARIFA, tarifa.RANGOINICIO_TARIFA, tarifa.RANGOFIN_TARIFA,
	programa.ID_PROGRAMA, programa.NOMBRE_PROGRAMA, programa.ESTADO_PROGRAMA
	FROM tarifa
	INNER JOIN programa ON tarifa.FK_ID_PROGRAMA = programa.ID_PROGRAMA
	WHERE tarifa.ID_TARIFA = id;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.BuscarVendedor
DELIMITER //
CREATE PROCEDURE `BuscarVendedor`(
	IN `id` INT
)
BEGIN
	
	SELECT vendedor.ID_VENDEDOR, vendedor.USERNAME_VENDEDOR, vendedor.CONTRASENIA_VENDEDOR, vendedor.ESTADO_VENDEDOR,
	persona.DOCUMENTO_PERSONA, persona.NOMBRE1_PERSONA, persona.NOMBRE2_PERSONA, persona.APELLIDO1_PERSONA, persona.APELLIDO2_PERSONA, persona.FECHANACIMIENTO_PERSONA, persona.CORREO_PERSONA,
	tipodocumento.ID_TIPODOCUMENTO, tipodocumento.NOMBRE_TIPODOCUMENTO, tipodocumento.ESTADO_TIPODOCUMENTO,
	genero.ID_GENERO, genero.NOMBRE_GENERO, genero.ESTADO_GENERO,
	rol.ID_ROL, rol.NOMBRE_ROL, rol.ESTADO_ROL
	FROM vendedor
	INNER JOIN persona ON vendedor.FK_DOCUMENTO_PERSONA = persona.DOCUMENTO_PERSONA
	INNER JOIN tipodocumento ON persona.FK_ID_TIPODOCUMENTO = tipodocumento.ID_TIPODOCUMENTO
	INNER JOIN genero ON persona.FK_ID_GENERO = genero.ID_GENERO
	INNER JOIN rol ON vendedor.FK_ID_ROL = rol.ID_ROL
	WHERE vendedor.ID_VENDEDOR = id
	AND vendedor.FK_ID_ROL != 1;
	
END//
DELIMITER ;

-- Volcando estructura para tabla radio_demo.contrato
CREATE TABLE IF NOT EXISTS `contrato` (
  `ID_CONTRATO` int NOT NULL AUTO_INCREMENT,
  `NOMBRE_CONTRATO` varchar(70) NOT NULL,
  `FECHAINICIO_CONTRATO` date NOT NULL,
  `FECHAFIN_CONTRATO` date NOT NULL,
  `FECHACREACION_CONTRATO` datetime NOT NULL,
  `VALORTOTAL_CONTRATO` int NOT NULL,
  `NUMEROCUNIAS_CONTRATO` int NOT NULL DEFAULT '0',
  `PDF_CONTRATO` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
  `FK_ID_VENDEDOR` int NOT NULL,
  `FK_NIT_ANUNCIANTE` int NOT NULL,
  PRIMARY KEY (`ID_CONTRATO`),
  KEY `FK_VENDEDOR_CONTRATO` (`FK_ID_VENDEDOR`),
  KEY `FK_ANUNCIANTE_CONTRATO` (`FK_NIT_ANUNCIANTE`),
  CONSTRAINT `FK_ANUNCIANTE_CONTRATO` FOREIGN KEY (`FK_NIT_ANUNCIANTE`) REFERENCES `anunciante` (`NIT_ANUNCIANTE`) ON UPDATE CASCADE,
  CONSTRAINT `FK_VENDEDOR_CONTRATO` FOREIGN KEY (`FK_ID_VENDEDOR`) REFERENCES `vendedor` (`ID_VENDEDOR`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.contrato: ~1 rows (aproximadamente)
INSERT INTO `contrato` (`ID_CONTRATO`, `NOMBRE_CONTRATO`, `FECHAINICIO_CONTRATO`, `FECHAFIN_CONTRATO`, `FECHACREACION_CONTRATO`, `VALORTOTAL_CONTRATO`, `NUMEROCUNIAS_CONTRATO`, `PDF_CONTRATO`, `FK_ID_VENDEDOR`, `FK_NIT_ANUNCIANTE`) VALUES
	(1, 'Contrato Radio Uno', '2025-07-01', '2025-12-31', '2025-07-18 22:04:02', 15600000, 3, '687b0b227f14f4e5110d2101', 1, 900001001),
	(2, 'Contrato Publicidad Express', '2025-06-15', '2025-08-15', '2025-05-19 22:05:23', 9900000, 2, '687b0b747f14f4e5110d2102', 1, 900001002),
	(3, 'Contrato Temporada Verano', '2025-07-10', '2025-09-10', '2025-06-18 22:06:31', 11700000, 2, '687b0bb77f14f4e5110d2103', 1, 900001003),
	(4, 'Contrato Navidad', '2025-11-01', '2025-12-31', '2025-08-08 22:07:14', 10500000, 2, '687b0be27f14f4e5110d2104', 1, 900001004),
	(5, 'Contrato Promoción 2025', '2025-05-01', '2025-10-01', '2025-04-18 22:07:42', 3000000, 1, '687b0bfe7f14f4e5110d2105', 1, 900001005);

-- Volcando estructura para tabla radio_demo.cunia
CREATE TABLE IF NOT EXISTS `cunia` (
  `ID_CUNIA` int NOT NULL AUTO_INCREMENT,
  `NOMBRE_CUNIA` varchar(70) NOT NULL,
  `DESCRIPCION_CUNIA` varchar(500) NOT NULL,
  `ESTADO_CUNIA` tinyint NOT NULL DEFAULT '1',
  `FK_ID_TARIFA` int NOT NULL,
  `FK_ID_CONTRATO` int NOT NULL,
  PRIMARY KEY (`ID_CUNIA`),
  KEY `FK_TARIFA_CUNIA` (`FK_ID_TARIFA`),
  KEY `FK_CONTRATO_CUNIA` (`FK_ID_CONTRATO`),
  CONSTRAINT `FK_CONTRATO_CUNIA` FOREIGN KEY (`FK_ID_CONTRATO`) REFERENCES `contrato` (`ID_CONTRATO`) ON UPDATE CASCADE,
  CONSTRAINT `FK_TARIFA_CUNIA` FOREIGN KEY (`FK_ID_TARIFA`) REFERENCES `tarifa` (`ID_TARIFA`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.cunia: ~0 rows (aproximadamente)
INSERT INTO `cunia` (`ID_CUNIA`, `NOMBRE_CUNIA`, `DESCRIPCION_CUNIA`, `ESTADO_CUNIA`, `FK_ID_TARIFA`, `FK_ID_CONTRATO`) VALUES
	(1, 'Cuña A1', 'Publicidad de café premium en Radio Uno.', 1, 1, 1),
	(2, 'Cuña A2', 'Promoción del mes para nuevos clientes.', 1, 2, 1),
	(3, 'Cuña A3', 'Cuña institucional para posicionamiento.', 1, 3, 1),
	(4, 'Cuña B1', 'Anuncio de heladería local.', 1, 6, 2),
	(5, 'Cuña B2', 'Descuento 2x1 en productos seleccionados.', 1, 7, 2),
	(6, 'Cuña C1', 'Campaña verano segura - protección solar.', 1, 9, 3),
	(7, 'Cuña C2', 'Ropa ligera en descuento.', 1, 10, 3),
	(8, 'Contrato Navidad', 'Descuentos de temporada navideña.', 1, 4, 4),
	(9, 'Cuña D2', 'Regalos para toda la familia.', 1, 5, 4),
	(10, 'Cuña E1', 'Nuevo servicio de entrega rápida.', 1, 8, 5);

-- Volcando estructura para procedimiento radio_demo.EditarAnunciante
DELIMITER //
CREATE PROCEDURE `EditarAnunciante`(
	IN nit INT,
	IN nombre VARCHAR(50),
	IN direccion VARCHAR(50),
	IN telefono VARCHAR(50),
	IN nombre1 VARCHAR(50),
	IN nombre2 VARCHAR(50),
	IN apellido1 VARCHAR(50),
	IN apellido2 VARCHAR(50),
	IN correo VARCHAR(70)
)
BEGIN
	
	UPDATE anunciante, persona
	SET anunciante.NOMBRE_ANUNCIANTE = nombre, anunciante.DIRECCION_ANUNCIANTE = direccion, anunciante.TELEFONO_ANUNCIANTE = telefono,
	persona.NOMBRE1_PERSONA = nombre1, persona.NOMBRE2_PERSONA = nombre2, persona.APELLIDO1_PERSONA = apellido1, persona.APELLIDO2_PERSONA = apellido2, persona.CORREO_PERSONA = correo
	WHERE anunciante.NIT_ANUNCIANTE = nit
	AND persona.DOCUMENTO_PERSONA = anunciante.FK_DOCUMENTO_PERSONA;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.EditarPerfil
DELIMITER //
CREATE PROCEDURE `EditarPerfil`(
	IN `id` INT,
	IN `username` VARCHAR(50),
	IN `nombre1` VARCHAR(50),
	IN `nombre2` VARCHAR(50),
	IN `apellido1` VARCHAR(50),
	IN `apellido2` VARCHAR(50),
	IN `correo` VARCHAR(100)
)
BEGIN
	
	UPDATE vendedor, persona
	SET vendedor.USERNAME_VENDEDOR = username,
	persona.NOMBRE1_PERSONA = nombre1, persona.NOMBRE2_PERSONA = nombre2, persona.APELLIDO1_PERSONA = apellido1, persona.APELLIDO2_PERSONA = apellido2, persona.CORREO_PERSONA = correo
	WHERE vendedor.ID_VENDEDOR = id
	AND persona.DOCUMENTO_PERSONA = vendedor.FK_DOCUMENTO_PERSONA;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.EditarPrograma
DELIMITER //
CREATE PROCEDURE `EditarPrograma`(
	IN id INT,
	IN nombre VARCHAR(50),
	IN estado TINYINT
)
BEGIN
	
	UPDATE programa
	SET programa.NOMBRE_PROGRAMA = nombre, programa.ESTADO_PROGRAMA = estado
	WHERE programa.ID_PROGRAMA = id;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.EditarTarifa
DELIMITER //
CREATE PROCEDURE `EditarTarifa`(
	IN id INT,
	IN valor1 INT,
	IN valor2 INT,
	IN rango1 INT,
	IN rango2 INT,
	IN idPrograma INT
)
BEGIN
	
	UPDATE tarifa
	SET tarifa.VALORPUBLICADO_TARIFA = valor1, tarifa.VALORREAL_TARIFA = valor2, tarifa.RANGOINICIO_TARIFA = rango1, tarifa.RANGOFIN_TARIFA = rango2, tarifa.FK_ID_PROGRAMA = idPrograma
	WHERE tarifa.ID_TARIFA = id;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.EditarVendedor
DELIMITER //
CREATE PROCEDURE `EditarVendedor`(
	IN id INT,
	IN username VARCHAR(50),
	IN estado TINYINT,
	IN idRol INT,
	IN nombre1 VARCHAR(50),
	IN nombre2 VARCHAR(50),
	IN apellido1 VARCHAR(50),
	IN apellido2 VARCHAR(50),
	IN correo VARCHAR(70)
)
BEGIN
	
	UPDATE vendedor, persona
	SET vendedor.USERNAME_VENDEDOR = username, vendedor.ESTADO_VENDEDOR = estado, vendedor.FK_ID_ROL = idRol,
	persona.NOMBRE1_PERSONA = nombre1, persona.NOMBRE2_PERSONA = nombre2, persona.APELLIDO1_PERSONA = apellido1, persona.APELLIDO2_PERSONA = apellido2, persona.CORREO_PERSONA = correo
	WHERE vendedor.ID_VENDEDOR = id
	AND persona.DOCUMENTO_PERSONA = vendedor.FK_DOCUMENTO_PERSONA;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.EliminarTarifa
DELIMITER //
CREATE PROCEDURE `EliminarTarifa`(
	IN id INT
)
BEGIN
	
	UPDATE tarifa
	SET tarifa.ESTADO_TARIFA = 0
	WHERE tarifa.ID_TARIFA = id;
	
END//
DELIMITER ;

-- Volcando estructura para tabla radio_demo.genero
CREATE TABLE IF NOT EXISTS `genero` (
  `ID_GENERO` int NOT NULL AUTO_INCREMENT,
  `NOMBRE_GENERO` varchar(50) NOT NULL,
  `ESTADO_GENERO` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID_GENERO`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.genero: ~3 rows (aproximadamente)
INSERT INTO `genero` (`ID_GENERO`, `NOMBRE_GENERO`, `ESTADO_GENERO`) VALUES
	(1, 'Masculino', 1),
	(2, 'Femenino', 1),
	(3, 'Otro', 1);

-- Volcando estructura para procedimiento radio_demo.GuardarPdf
DELIMITER //
CREATE PROCEDURE `GuardarPdf`(
	IN id INT,
	IN pdf VARCHAR(200)
)
BEGIN
	
	UPDATE contrato
	SET contrato.PDF_CONTRATO = pdf
	WHERE contrato.ID_CONTRATO = id;
	
END//
DELIMITER ;

-- Volcando estructura para tabla radio_demo.permiso
CREATE TABLE IF NOT EXISTS `permiso` (
  `ID_PERMISO` int NOT NULL AUTO_INCREMENT,
  `NOMBRE_PERMISO` varchar(50) NOT NULL,
  PRIMARY KEY (`ID_PERMISO`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.permiso: ~17 rows (aproximadamente)
INSERT INTO `permiso` (`ID_PERMISO`, `NOMBRE_PERMISO`) VALUES
	(1, 'Consultar Contrato'),
	(2, 'Consultar Programa'),
	(3, 'Consultar Tarifa'),
	(4, 'Consultar Vendedor'),
	(5, 'Consultar Anunciante'),
	(6, 'Editar Contrato'),
	(7, 'Editar Programa'),
	(8, 'Editar Tarifa'),
	(9, 'Editar Vendedor'),
	(10, 'Editar Anunciante'),
	(11, 'Agregar Contrato'),
	(12, 'Agregar Programa'),
	(13, 'Agregar Tarifa'),
	(14, 'Agregar Vendedor'),
	(15, 'Agregar Anunciante'),
	(16, 'Eliminar Tarifa'),
	(17, 'Editar Perfil');

-- Volcando estructura para tabla radio_demo.permisorol
CREATE TABLE IF NOT EXISTS `permisorol` (
  `ID_PERMISOROL` int NOT NULL AUTO_INCREMENT,
  `FK_ID_ROL` int NOT NULL,
  `FK_ID_PERMISO` int NOT NULL,
  PRIMARY KEY (`ID_PERMISOROL`),
  KEY `FK_ROL_PERMISOROL` (`FK_ID_ROL`),
  KEY `FK_PERMISO_PERMISOROL` (`FK_ID_PERMISO`),
  CONSTRAINT `FK_PERMISO_PERMISOROL` FOREIGN KEY (`FK_ID_PERMISO`) REFERENCES `permiso` (`ID_PERMISO`) ON UPDATE CASCADE,
  CONSTRAINT `FK_ROL_PERMISOROL` FOREIGN KEY (`FK_ID_ROL`) REFERENCES `rol` (`ID_ROL`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.permisorol: ~19 rows (aproximadamente)
INSERT INTO `permisorol` (`ID_PERMISOROL`, `FK_ID_ROL`, `FK_ID_PERMISO`) VALUES
	(1, 1, 1),
	(2, 1, 2),
	(3, 1, 3),
	(4, 1, 4),
	(5, 1, 5),
	(6, 2, 1),
	(7, 2, 5),
	(8, 1, 15),
	(9, 1, 11),
	(10, 1, 12),
	(11, 1, 13),
	(12, 1, 14),
	(13, 1, 10),
	(14, 1, 6),
	(15, 1, 7),
	(16, 1, 8),
	(17, 1, 9),
	(18, 1, 16),
	(19, 1, 17),
	(20, 2, 11),
	(21, 2, 15),
	(22, 2, 10),
	(23, 3, 11),
	(24, 3, 5),
	(25, 3, 1),
	(26, 3, 2),
	(27, 3, 3),
	(28, 3, 4),
	(29, 2, 17);

-- Volcando estructura para tabla radio_demo.persona
CREATE TABLE IF NOT EXISTS `persona` (
  `DOCUMENTO_PERSONA` int NOT NULL,
  `NOMBRE1_PERSONA` varchar(50) NOT NULL,
  `NOMBRE2_PERSONA` varchar(50) DEFAULT NULL,
  `APELLIDO1_PERSONA` varchar(50) NOT NULL,
  `APELLIDO2_PERSONA` varchar(50) DEFAULT NULL,
  `FECHANACIMIENTO_PERSONA` date NOT NULL,
  `CORREO_PERSONA` varchar(100) NOT NULL,
  `FK_ID_TIPODOCUMENTO` int NOT NULL,
  `FK_ID_GENERO` int NOT NULL,
  PRIMARY KEY (`DOCUMENTO_PERSONA`),
  KEY `FK_TIPODOCUMENTO_PERSONA` (`FK_ID_TIPODOCUMENTO`),
  KEY `FK_GENERO_PERSONA` (`FK_ID_GENERO`),
  CONSTRAINT `FK_GENERO_PERSONA` FOREIGN KEY (`FK_ID_GENERO`) REFERENCES `genero` (`ID_GENERO`) ON UPDATE CASCADE,
  CONSTRAINT `FK_TIPODOCUMENTO_PERSONA` FOREIGN KEY (`FK_ID_TIPODOCUMENTO`) REFERENCES `tipodocumento` (`ID_TIPODOCUMENTO`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.persona: ~8 rows (aproximadamente)
INSERT INTO `persona` (`DOCUMENTO_PERSONA`, `NOMBRE1_PERSONA`, `NOMBRE2_PERSONA`, `APELLIDO1_PERSONA`, `APELLIDO2_PERSONA`, `FECHANACIMIENTO_PERSONA`, `CORREO_PERSONA`, `FK_ID_TIPODOCUMENTO`, `FK_ID_GENERO`) VALUES
	(123, 'Jhoan', 'Sebastián', 'Sierra', 'Perdomo', '2002-03-24', 'admin@radiodemo.com', 1, 1),
	(10101010, 'Carlos', 'Andrés', 'García', 'López', '1990-05-15', 'carlos.garcia@example.com', 1, 1),
	(12345678, 'Sebastián', NULL, 'Sierra', NULL, '2002-03-24', 'invitado@radiodemo.com', 1, 1),
	(15151515, 'Johana', NULL, 'Sanchez', NULL, '2008-05-04', 'empleado@radiodemo.com', 3, 2),
	(20202020, 'Laura', NULL, 'Martínez', 'Ruiz', '1988-08-22', 'laura.martinez@example.com', 2, 2),
	(30303030, 'Miguel', 'Ángel', 'Torres', NULL, '1995-12-03', 'miguel.torres@example.com', 1, 1),
	(40404040, 'Sofía', NULL, 'Ramírez', 'Gómez', '1992-03-10', 'sofia.ramirez@example.com', 1, 2),
	(50505050, 'Julián', 'Esteban', 'Vargas', 'Mora', '1985-07-29', 'julian.vargas@example.com', 2, 1);

-- Volcando estructura para tabla radio_demo.programa
CREATE TABLE IF NOT EXISTS `programa` (
  `ID_PROGRAMA` int NOT NULL AUTO_INCREMENT,
  `NOMBRE_PROGRAMA` varchar(100) NOT NULL,
  `ESTADO_PROGRAMA` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID_PROGRAMA`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.programa: ~3 rows (aproximadamente)
INSERT INTO `programa` (`ID_PROGRAMA`, `NOMBRE_PROGRAMA`, `ESTADO_PROGRAMA`) VALUES
	(1, 'Mañanas Informativas', 1),
	(2, 'Radio Noticias', 1),
	(3, 'Música y Café', 1),
	(4, 'Tarde Deportiva', 0),
	(5, 'Noche de Rock', 1);

-- Volcando estructura para procedimiento radio_demo.RecopilarAnunciantes
DELIMITER //
CREATE PROCEDURE `RecopilarAnunciantes`()
BEGIN

	SELECT anunciante.NIT_ANUNCIANTE, anunciante.NOMBRE_ANUNCIANTE, anunciante.DIRECCION_ANUNCIANTE, anunciante.TELEFONO_ANUNCIANTE,
	persona.DOCUMENTO_PERSONA, persona.NOMBRE1_PERSONA, persona.NOMBRE2_PERSONA, persona.APELLIDO1_PERSONA, persona.APELLIDO2_PERSONA, persona.FECHANACIMIENTO_PERSONA, persona.CORREO_PERSONA,
	tipodocumento.ID_TIPODOCUMENTO, tipodocumento.NOMBRE_TIPODOCUMENTO, tipodocumento.ESTADO_TIPODOCUMENTO,
	genero.ID_GENERO, genero.NOMBRE_GENERO, genero.ESTADO_GENERO
	FROM anunciante
	INNER JOIN persona ON anunciante.FK_DOCUMENTO_PERSONA = persona.DOCUMENTO_PERSONA
	INNER JOIN tipodocumento ON persona.FK_ID_TIPODOCUMENTO = tipodocumento.ID_TIPODOCUMENTO
	INNER JOIN genero ON persona.FK_ID_GENERO = genero.ID_GENERO
	ORDER BY anunciante.NIT_ANUNCIANTE ASC;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.RecopilarContratos
DELIMITER //
CREATE PROCEDURE `RecopilarContratos`()
BEGIN
	
	SELECT *
	FROM vistabuscarcontrato
	ORDER BY vistabuscarcontrato.FECHACREACION_CONTRATO DESC;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.RecopilarCunias
DELIMITER //
CREATE PROCEDURE `RecopilarCunias`(
	IN idContrato INT
)
BEGIN
	
	SELECT cunia.ID_CUNIA, cunia.NOMBRE_CUNIA, cunia.DESCRIPCION_CUNIA, cunia.ESTADO_CUNIA,
	tarifa.ID_TARIFA, tarifa.VALORPUBLICADO_TARIFA, tarifa.VALORREAL_TARIFA, tarifa.RANGOINICIO_TARIFA, tarifa.RANGOFIN_TARIFA,
	programa.ID_PROGRAMA, programa.NOMBRE_PROGRAMA, programa.ESTADO_PROGRAMA
	FROM cunia
	INNER JOIN tarifa ON cunia.FK_ID_TARIFA = tarifa.ID_TARIFA
	INNER JOIN programa ON tarifa.FK_ID_PROGRAMA = programa.ID_PROGRAMA
	WHERE cunia.FK_ID_CONTRATO = idContrato;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.RecopilarGeneros
DELIMITER //
CREATE PROCEDURE `RecopilarGeneros`()
BEGIN
	
	SELECT genero.ID_GENERO, genero.NOMBRE_GENERO, genero.ESTADO_GENERO
	FROM genero
	ORDER BY genero.NOMBRE_GENERO ASC;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.RecopilarProgramas
DELIMITER //
CREATE PROCEDURE `RecopilarProgramas`()
BEGIN

	SELECT programa.ID_PROGRAMA, programa.NOMBRE_PROGRAMA, programa.ESTADO_PROGRAMA
	FROM programa
	ORDER BY programa.NOMBRE_PROGRAMA ASC;

END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.RecopilarRoles
DELIMITER //
CREATE PROCEDURE `RecopilarRoles`()
BEGIN
	
	SELECT rol.ID_ROL, rol.NOMBRE_ROL, rol.ESTADO_ROL
	FROM rol
	WHERE rol.ESTADO_ROL = 1
	ORDER BY rol.NOMBRE_ROL ASC;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.RecopilarTarifas
DELIMITER //
CREATE PROCEDURE `RecopilarTarifas`()
BEGIN
	
	SELECT tarifa.ID_TARIFA, tarifa.VALORPUBLICADO_TARIFA, tarifa.VALORREAL_TARIFA, tarifa.RANGOINICIO_TARIFA, tarifa.RANGOFIN_TARIFA,
	programa.ID_PROGRAMA, programa.NOMBRE_PROGRAMA, programa.ESTADO_PROGRAMA
	FROM tarifa
	INNER JOIN programa ON tarifa.FK_ID_PROGRAMA = programa.ID_PROGRAMA
	WHERE tarifa.ESTADO_TARIFA = 1
	ORDER BY programa.NOMBRE_PROGRAMA ASC;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.RecopilarTipoDocumentos
DELIMITER //
CREATE PROCEDURE `RecopilarTipoDocumentos`()
BEGIN
	
	SELECT tipodocumento.ID_TIPODOCUMENTO, tipodocumento.NOMBRE_TIPODOCUMENTO, tipodocumento.ESTADO_TIPODOCUMENTO
	FROM tipodocumento
	ORDER BY tipodocumento.NOMBRE_TIPODOCUMENTO ASC;
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.RecopilarVendedores
DELIMITER //
CREATE PROCEDURE `RecopilarVendedores`()
BEGIN

	SELECT vendedor.ID_VENDEDOR, vendedor.USERNAME_VENDEDOR, vendedor.CONTRASENIA_VENDEDOR, vendedor.ESTADO_VENDEDOR,
	persona.DOCUMENTO_PERSONA, persona.NOMBRE1_PERSONA, persona.NOMBRE2_PERSONA, persona.APELLIDO1_PERSONA, persona.APELLIDO2_PERSONA, persona.FECHANACIMIENTO_PERSONA, persona.CORREO_PERSONA,
	tipodocumento.ID_TIPODOCUMENTO, tipodocumento.NOMBRE_TIPODOCUMENTO, tipodocumento.ESTADO_TIPODOCUMENTO,
	genero.ID_GENERO, genero.NOMBRE_GENERO, genero.ESTADO_GENERO,
	rol.ID_ROL, rol.NOMBRE_ROL, rol.ESTADO_ROL
	FROM vendedor
	INNER JOIN persona ON vendedor.FK_DOCUMENTO_PERSONA = persona.DOCUMENTO_PERSONA
	INNER JOIN tipodocumento ON persona.FK_ID_TIPODOCUMENTO = tipodocumento.ID_TIPODOCUMENTO
	INNER JOIN genero ON persona.FK_ID_GENERO = genero.ID_GENERO
	INNER JOIN rol ON vendedor.FK_ID_ROL = rol.ID_ROL
	WHERE vendedor.FK_ID_ROL != 1
	ORDER BY vendedor.FK_DOCUMENTO_PERSONA ASC;
	
END//
DELIMITER ;

-- Volcando estructura para tabla radio_demo.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `ID_ROL` int NOT NULL AUTO_INCREMENT,
  `NOMBRE_ROL` varchar(50) NOT NULL,
  `ESTADO_ROL` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID_ROL`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.rol: ~2 rows (aproximadamente)
INSERT INTO `rol` (`ID_ROL`, `NOMBRE_ROL`, `ESTADO_ROL`) VALUES
	(1, 'Administrador', 1),
	(2, 'Empleado', 1),
	(3, 'Invitado', 1);

-- Volcando estructura para tabla radio_demo.tarifa
CREATE TABLE IF NOT EXISTS `tarifa` (
  `ID_TARIFA` int NOT NULL AUTO_INCREMENT,
  `VALORPUBLICADO_TARIFA` int NOT NULL,
  `VALORREAL_TARIFA` int NOT NULL,
  `RANGOINICIO_TARIFA` int NOT NULL,
  `RANGOFIN_TARIFA` int NOT NULL,
  `ESTADO_TARIFA` tinyint NOT NULL DEFAULT '1',
  `FK_ID_PROGRAMA` int NOT NULL,
  PRIMARY KEY (`ID_TARIFA`),
  KEY `FK_PROGRAMA_TARIFA` (`FK_ID_PROGRAMA`),
  CONSTRAINT `FK_PROGRAMA_TARIFA` FOREIGN KEY (`FK_ID_PROGRAMA`) REFERENCES `programa` (`ID_PROGRAMA`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.tarifa: ~8 rows (aproximadamente)
INSERT INTO `tarifa` (`ID_TARIFA`, `VALORPUBLICADO_TARIFA`, `VALORREAL_TARIFA`, `RANGOINICIO_TARIFA`, `RANGOFIN_TARIFA`, `ESTADO_TARIFA`, `FK_ID_PROGRAMA`) VALUES
	(1, 150000, 130000, 10, 20, 1, 1),
	(2, 200000, 180000, 21, 30, 1, 1),
	(3, 250000, 210000, 31, 40, 1, 1),
	(4, 180000, 150000, 10, 20, 1, 2),
	(5, 230000, 200000, 21, 30, 1, 2),
	(6, 170000, 140000, 10, 15, 1, 3),
	(7, 210000, 190000, 16, 25, 1, 3),
	(8, 120000, 100000, 10, 20, 1, 4),
	(9, 190000, 170000, 21, 30, 1, 5),
	(10, 240000, 220000, 31, 40, 1, 5);

-- Volcando estructura para tabla radio_demo.tipodocumento
CREATE TABLE IF NOT EXISTS `tipodocumento` (
  `ID_TIPODOCUMENTO` int NOT NULL AUTO_INCREMENT,
  `NOMBRE_TIPODOCUMENTO` varchar(50) NOT NULL,
  `ESTADO_TIPODOCUMENTO` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID_TIPODOCUMENTO`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.tipodocumento: ~3 rows (aproximadamente)
INSERT INTO `tipodocumento` (`ID_TIPODOCUMENTO`, `NOMBRE_TIPODOCUMENTO`, `ESTADO_TIPODOCUMENTO`) VALUES
	(1, 'Cédula', 1),
	(2, 'Pasaporte', 1),
	(3, 'Tarjeta de Identidad', 1);

-- Volcando estructura para procedimiento radio_demo.ValidarContrasenia
DELIMITER //
CREATE PROCEDURE `ValidarContrasenia`(
	IN `idVendedor` INT,
	IN `contrasenia` VARCHAR(500)
)
BEGIN

	SELECT
		COUNT(1)
	FROM
		vendedor v
	WHERE
		v.ID_VENDEDOR = idVendedor
		AND v.CONTRASENIA_VENDEDOR = SHA2(contrasenia, 256);
	
END//
DELIMITER ;

-- Volcando estructura para procedimiento radio_demo.ValidarVendedor
DELIMITER //
CREATE PROCEDURE `ValidarVendedor`(
	IN `username` VARCHAR(50),
	IN `contrasenia` VARCHAR(50)
)
BEGIN
	
	SELECT vendedor.ID_VENDEDOR, vendedor.USERNAME_VENDEDOR, vendedor.CONTRASENIA_VENDEDOR, vendedor.ESTADO_VENDEDOR,
	persona.DOCUMENTO_PERSONA, persona.NOMBRE1_PERSONA, persona.NOMBRE2_PERSONA, persona.APELLIDO1_PERSONA, persona.APELLIDO2_PERSONA, persona.FECHANACIMIENTO_PERSONA, persona.CORREO_PERSONA, persona.FK_ID_TIPODOCUMENTO, persona.FK_ID_GENERO,
	rol.ID_ROL, rol.NOMBRE_ROL, rol.ESTADO_ROL
	FROM vendedor
	INNER JOIN persona ON vendedor.FK_DOCUMENTO_PERSONA = persona.DOCUMENTO_PERSONA
	INNER JOIN rol ON vendedor.FK_ID_ROL = rol.ID_ROL
	WHERE vendedor.USERNAME_VENDEDOR = username
	AND vendedor.CONTRASENIA_VENDEDOR = SHA2(contrasenia, 256);
	
END//
DELIMITER ;

-- Volcando estructura para tabla radio_demo.vendedor
CREATE TABLE IF NOT EXISTS `vendedor` (
  `ID_VENDEDOR` int NOT NULL AUTO_INCREMENT,
  `USERNAME_VENDEDOR` varchar(50) NOT NULL,
  `CONTRASENIA_VENDEDOR` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ESTADO_VENDEDOR` tinyint NOT NULL DEFAULT '1',
  `FK_DOCUMENTO_PERSONA` int NOT NULL,
  `FK_ID_ROL` int NOT NULL,
  PRIMARY KEY (`ID_VENDEDOR`),
  KEY `FK_PERSONA_VENDEDOR` (`FK_DOCUMENTO_PERSONA`),
  KEY `FK_ROL_VENDEDOR` (`FK_ID_ROL`),
  CONSTRAINT `FK_PERSONA_VENDEDOR` FOREIGN KEY (`FK_DOCUMENTO_PERSONA`) REFERENCES `persona` (`DOCUMENTO_PERSONA`) ON UPDATE CASCADE,
  CONSTRAINT `FK_ROL_VENDEDOR` FOREIGN KEY (`FK_ID_ROL`) REFERENCES `rol` (`ID_ROL`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla radio_demo.vendedor: ~3 rows (aproximadamente)
INSERT INTO `vendedor` (`ID_VENDEDOR`, `USERNAME_VENDEDOR`, `CONTRASENIA_VENDEDOR`, `ESTADO_VENDEDOR`, `FK_DOCUMENTO_PERSONA`, `FK_ID_ROL`) VALUES
	(1, 'admin', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 1, 123, 1),
	(2, 'empleado', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 1, 15151515, 2),
	(3, 'invitado', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 1, 12345678, 3);

-- Volcando estructura para vista radio_demo.vistabuscarcontrato
-- Creando tabla temporal para superar errores de dependencia de VIEW
CREATE TABLE `vistabuscarcontrato` (
	`ID_CONTRATO` INT NOT NULL,
	`NOMBRE_CONTRATO` VARCHAR(1) NOT NULL COLLATE 'utf8mb4_0900_ai_ci',
	`FECHAINICIO_CONTRATO` DATE NOT NULL,
	`FECHAFIN_CONTRATO` DATE NOT NULL,
	`FECHACREACION_CONTRATO` DATETIME NOT NULL,
	`VALORTOTAL_CONTRATO` INT NOT NULL,
	`NUMEROCUNIAS_CONTRATO` INT NOT NULL,
	`PDF_CONTRATO` VARCHAR(1) NULL COLLATE 'utf8mb4_0900_ai_ci',
	`DOCUMENTO_VENDEDOR` INT NOT NULL,
	`NOMBRE_VENDEDOR` VARCHAR(1) NOT NULL COLLATE 'utf8mb4_0900_ai_ci',
	`DOCUMENTO_ANUNCIANTE` INT NOT NULL,
	`NOMBRE_ANUNCIANTE` VARCHAR(1) NOT NULL COLLATE 'utf8mb4_0900_ai_ci'
) ENGINE=MyISAM;

-- Volcando estructura para disparador radio_demo.AuditoriaTarifa
SET @OLDTMP_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
DELIMITER //
CREATE TRIGGER `AuditoriaTarifa` AFTER UPDATE ON `tarifa` FOR EACH ROW BEGIN
	
	IF NEW.ESTADO_TARIFA = 0 THEN
      INSERT INTO auditoriaeliminartarifa (TARIFA_AUDITORIAELIMINARTARIFA, FECHA_AUDITORIAELIMINARTARIFA)
      VALUES (NEW.ID_TARIFA, NOW());
   	END IF;
   
END//
DELIMITER ;
SET SQL_MODE=@OLDTMP_SQL_MODE;

-- Eliminando tabla temporal y crear estructura final de VIEW
DROP TABLE IF EXISTS `vistabuscarcontrato`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `vistabuscarcontrato` AS select `contrato`.`ID_CONTRATO` AS `ID_CONTRATO`,`contrato`.`NOMBRE_CONTRATO` AS `NOMBRE_CONTRATO`,`contrato`.`FECHAINICIO_CONTRATO` AS `FECHAINICIO_CONTRATO`,`contrato`.`FECHAFIN_CONTRATO` AS `FECHAFIN_CONTRATO`,`contrato`.`FECHACREACION_CONTRATO` AS `FECHACREACION_CONTRATO`,`contrato`.`VALORTOTAL_CONTRATO` AS `VALORTOTAL_CONTRATO`,`contrato`.`NUMEROCUNIAS_CONTRATO` AS `NUMEROCUNIAS_CONTRATO`,`contrato`.`PDF_CONTRATO` AS `PDF_CONTRATO`,`personavendedor`.`DOCUMENTO_PERSONA` AS `DOCUMENTO_VENDEDOR`,concat(`personavendedor`.`NOMBRE1_PERSONA`,' ',`personavendedor`.`APELLIDO1_PERSONA`) AS `NOMBRE_VENDEDOR`,`personaanunciante`.`DOCUMENTO_PERSONA` AS `DOCUMENTO_ANUNCIANTE`,concat(`personaanunciante`.`NOMBRE1_PERSONA`,' ',`personaanunciante`.`APELLIDO1_PERSONA`) AS `NOMBRE_ANUNCIANTE` from ((((`contrato` join `vendedor` on((`contrato`.`FK_ID_VENDEDOR` = `vendedor`.`ID_VENDEDOR`))) join `persona` `personavendedor` on((`vendedor`.`FK_DOCUMENTO_PERSONA` = `personavendedor`.`DOCUMENTO_PERSONA`))) join `anunciante` on((`contrato`.`FK_NIT_ANUNCIANTE` = `anunciante`.`NIT_ANUNCIANTE`))) join `persona` `personaanunciante` on((`anunciante`.`FK_DOCUMENTO_PERSONA` = `personaanunciante`.`DOCUMENTO_PERSONA`)));

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
