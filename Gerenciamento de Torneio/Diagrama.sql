-- MySQL Script generated by MySQL Workbench
-- Fri Nov  8 12:38:37 2024
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
SHOW WARNINGS;
-- -----------------------------------------------------
-- Schema management
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `management` ;

-- -----------------------------------------------------
-- Schema management
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `management` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
SHOW WARNINGS;
USE `management` ;

-- -----------------------------------------------------
-- Table `atletas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `atletas` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `atletas` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `data_nascimento` DATE NULL DEFAULT NULL,
  `equipe_id` INT NULL DEFAULT NULL,
  `modalidade_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 11
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `calendario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `calendario` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `calendario` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `evento` VARCHAR(100) NOT NULL,
  `descricao` TEXT NULL DEFAULT NULL,
  `data_inicio` DATETIME NOT NULL,
  `data_fim` DATETIME NOT NULL,
  `local` VARCHAR(100) NULL DEFAULT NULL,
  `modalidade_id` INT NULL DEFAULT NULL,
  `fase_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `classificacao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `classificacao` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `classificacao` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `torneio_id` INT NULL DEFAULT NULL,
  `fase_id` INT NULL DEFAULT NULL,
  `equipe_id` INT NULL DEFAULT NULL,
  `pontos` INT NULL DEFAULT '0',
  `vitorias` INT NULL DEFAULT '0',
  `empates` INT NULL DEFAULT '0',
  `derrotas` INT NULL DEFAULT '0',
  `gols_marcados` INT NULL DEFAULT '0',
  `gols_sofridos` INT NULL DEFAULT '0',
  `saldo_de_gols` INT GENERATED ALWAYS AS ((`gols_marcados` - `gols_sofridos`)) STORED,
  `ordem_classificacao` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `equipes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `equipes` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `equipes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `modalidade_id` INT NULL DEFAULT NULL,
  `cidade` VARCHAR(100) NULL DEFAULT NULL,
  `estado` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `estatisticas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `estatisticas` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `estatisticas` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `modalidade_id` INT NOT NULL,
  `equipe_id` INT NULL DEFAULT NULL,
  `atleta_id` INT NULL DEFAULT NULL,
  `gols` INT NULL DEFAULT '0',
  `assistencias` INT NULL DEFAULT '0',
  `cartoes_amarelos` INT NULL DEFAULT '0',
  `cartoes_vermelhos` INT NULL DEFAULT '0',
  `minutos_jogados` INT NULL DEFAULT '0',
  `outros_dados` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `fases`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `fases` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `fases` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `ordem` INT NOT NULL,
  `status` ENUM('nao_iniciado', 'em_andamento', 'concluido') NULL DEFAULT 'nao_iniciado',
  `modalidade_id` INT NULL DEFAULT NULL,
  `data_inicio` DATE NULL DEFAULT NULL,
  `data_fim` DATE NULL DEFAULT NULL,
  `quantidade_participantes` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `grupo_equipes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `grupo_equipes` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `grupo_equipes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `grupo_id` INT NULL DEFAULT NULL,
  `equipe_id` INT NULL DEFAULT NULL,
  `posicao` INT NULL DEFAULT '0',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `grupos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `grupos` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `grupos` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `modalidade_id` INT NULL DEFAULT NULL,
  `nome` VARCHAR(100) NULL DEFAULT NULL,
  `status` ENUM('em_andamento', 'finalizado') NULL DEFAULT 'em_andamento',
  `quantidade_equipas` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `modalidades`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `modalidades` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `modalidades` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `tipo` ENUM('individual', 'equipe') NOT NULL,
  `pontos_vitoria` INT NULL DEFAULT '3',
  `pontos_empate` INT NULL DEFAULT '1',
  `quantidade_jogadores_por_equipe` INT NULL DEFAULT '1',
  `quantidade_jogadores_reserva` INT NULL DEFAULT '0',
  `torneio_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `ocorrencias`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ocorrencias` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `ocorrencias` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `partida_id` INT NOT NULL,
  `equipe_id` INT NULL DEFAULT NULL,
  `atleta_id` INT NULL DEFAULT NULL,
  `tipo_ocorrencia` ENUM('falta', 'cartao_amarelo', 'cartao_vermelho', 'lesao', 'gol', 'assistencia') NOT NULL,
  `minuto_ocorrencia` INT NULL DEFAULT NULL,
  `descricao` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `partidas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `partidas` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `partidas` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `fase_id` INT NULL DEFAULT NULL,
  `modalidade_id` INT NULL DEFAULT NULL,
  `data_partida` DATE NULL DEFAULT NULL,
  `local` VARCHAR(100) NULL DEFAULT NULL,
  `equipe_a_id` INT NULL DEFAULT NULL,
  `equipe_b_id` INT NULL DEFAULT NULL,
  `resultado_a` INT NULL DEFAULT '0',
  `resultado_b` INT NULL DEFAULT '0',
  `vencedor_id` INT NULL DEFAULT NULL,
  `empate` TINYINT(1) NULL DEFAULT '0',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `resultados`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `resultados` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `resultados` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `partida_id` INT NULL DEFAULT NULL,
  `equipe_id` INT NULL DEFAULT NULL,
  `gols_pontos` INT NULL DEFAULT '0',
  `vitoria` TINYINT(1) NULL DEFAULT '0',
  `empate` TINYINT(1) NULL DEFAULT '0',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `torneios`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `torneios` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `torneios` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `tipo_fase` ENUM('grupos', 'eliminatorio', 'pontos_corridos') NOT NULL,
  `status` ENUM('planejado', 'em_andamento', 'finalizado') NOT NULL,
  `data_inicio` DATE NULL DEFAULT NULL,
  `data_fim` DATE NULL DEFAULT NULL,
  `configuracao_especial` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SHOW WARNINGS;
CREATE UNIQUE INDEX `nome` ON `torneios` (`nome` ASC, `data_inicio` ASC) VISIBLE;

SHOW WARNINGS;
USE `management` ;

-- -----------------------------------------------------
-- procedure EncerrarTorneio
-- -----------------------------------------------------

USE `management`;
DROP procedure IF EXISTS `EncerrarTorneio`;
SHOW WARNINGS;

DELIMITER $$
USE `management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `EncerrarTorneio`(IN torneio_id INT)
BEGIN
    UPDATE Torneios 
    SET status = 'finalizado', data_fim = NOW()
    WHERE id = torneio_id;

    -- Determina o campeão
    SELECT equipe_id INTO @campeao_id 
    FROM Classificacao 
    WHERE torneio_id = torneio_id
    ORDER BY pontos DESC, saldo_de_gols DESC
    LIMIT 1;

    -- Registra o campeão
    INSERT INTO Campeoes (torneio_id, equipe_id)
    VALUES (torneio_id, @campeao_id);
END$$

DELIMITER ;
SHOW WARNINGS;

-- -----------------------------------------------------
-- procedure GerarCalendario
-- -----------------------------------------------------

USE `management`;
DROP procedure IF EXISTS `GerarCalendario`;
SHOW WARNINGS;

DELIMITER $$
USE `management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GerarCalendario`(IN torneio_id INT)
BEGIN
    DECLARE equipe1 INT;
    DECLARE equipe2 INT;
    
    DECLARE cur CURSOR FOR 
    SELECT e1.id, e2.id 
    FROM Equipes e1, Equipes e2 
    WHERE e1.modalidade_id = e2.modalidade_id 
    AND e1.id != e2.id
    AND e1.modalidade_id = torneio_id;

    OPEN cur;

    read_loop: LOOP
        FETCH cur INTO equipe1, equipe2;

        -- Inserir partida no calendário
        INSERT INTO Partidas (fase_id, modalidade_id, equipe_a_id, equipe_b_id, data_partida, local)
        VALUES (1, torneio_id, equipe1, equipe2, NOW(), 'Local Padrão');
    END LOOP;

    CLOSE cur;
END$$

DELIMITER ;
SHOW WARNINGS;

-- -----------------------------------------------------
-- procedure RegistrarFaseEliminatoria
-- -----------------------------------------------------

USE `management`;
DROP procedure IF EXISTS `RegistrarFaseEliminatoria`;
SHOW WARNINGS;

DELIMITER $$
USE `management`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `RegistrarFaseEliminatoria`(IN torneio_id INT, IN fase_atual INT, IN fase_proxima INT)
BEGIN
    INSERT INTO Fases (modalidade_id, nome, ordem, status)
    SELECT modalidade_id, 'Fase Eliminatória', fase_proxima, 'nao_iniciado'
    FROM Classificacao
    WHERE torneio_id = torneio_id
    ORDER BY pontos DESC
    LIMIT 8; -- Supondo que 8 equipes se classificam
END$$

DELIMITER ;
SHOW WARNINGS;
USE `management`;

DELIMITER $$

USE `management`$$
DROP TRIGGER IF EXISTS `AtualizarGols` $$
SHOW WARNINGS$$
USE `management`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `management`.`AtualizarGols`
AFTER INSERT ON `management`.`partidas`
FOR EACH ROW
BEGIN
    UPDATE Classificacao 
    SET gols_marcados = gols_marcados + NEW.resultado_a, 
        gols_sofridos = gols_sofridos + NEW.resultado_b
    WHERE equipe_id = NEW.equipe_a_id;

    UPDATE Classificacao 
    SET gols_marcados = gols_marcados + NEW.resultado_b, 
        gols_sofridos = gols_sofridos + NEW.resultado_a
    WHERE equipe_id = NEW.equipe_b_id;
END$$

SHOW WARNINGS$$

USE `management`$$
DROP TRIGGER IF EXISTS `ValidarPartida` $$
SHOW WARNINGS$$
USE `management`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `management`.`ValidarPartida`
BEFORE INSERT ON `management`.`partidas`
FOR EACH ROW
BEGIN
    IF NEW.resultado_a = NEW.resultado_b THEN
        SET NEW.empate = TRUE;
    ELSEIF NEW.vencedor_id IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Vencedor deve ser definido para partidas não empatadas.';
    END IF;
END$$

SHOW WARNINGS$$

USE `management`$$
DROP TRIGGER IF EXISTS `AtualizarClassificacao` $$
SHOW WARNINGS$$
USE `management`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `management`.`AtualizarClassificacao`
AFTER INSERT ON `management`.`resultados`
FOR EACH ROW
BEGIN
    IF NEW.vitoria = TRUE THEN
        UPDATE Classificacao SET 
            pontos = pontos + 3, 
            vitorias = vitorias + 1 
        WHERE equipe_id = NEW.equipe_id;
    ELSEIF NEW.empate = TRUE THEN
        UPDATE Classificacao SET 
            pontos = pontos + 1, 
            empates = empates + 1 
        WHERE equipe_id = NEW.equipe_id;
    ELSE
        UPDATE Classificacao SET 
            derrotas = derrotas + 1 
        WHERE equipe_id = NEW.equipe_id;
    END IF;
END$$

SHOW WARNINGS$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
