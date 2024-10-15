
-- Automático de Saldo de Gols
DELIMITER //
CREATE TRIGGER AtualizarGols 
AFTER INSERT ON Partidas
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
END;
//
DELIMITER ;

-- Validação de Dados em Partidas
DELIMITER //
CREATE TRIGGER ValidarPartida
BEFORE INSERT ON Partidas
FOR EACH ROW
BEGIN
    IF NEW.resultado_a = NEW.resultado_b THEN
        SET NEW.empate = TRUE;
    ELSEIF NEW.vencedor_id IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Vencedor deve ser definido para partidas não empatadas.';
    END IF;
END;
//
DELIMITER ;

-- Criação de Calendário de Partidas
DELIMITER //
CREATE PROCEDURE GerarCalendario(IN torneio_id INT)
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
END;
//
DELIMITER ;

--  Registro Automático em Fases Eliminatórias

DELIMITER //
CREATE PROCEDURE RegistrarFaseEliminatoria(IN torneio_id INT, IN fase_atual INT, IN fase_proxima INT)
BEGIN
    INSERT INTO Fases (modalidade_id, nome, ordem, status)
    SELECT modalidade_id, 'Fase Eliminatória', fase_proxima, 'nao_iniciado'
    FROM Classificacao
    WHERE torneio_id = torneio_id
    ORDER BY pontos DESC
    LIMIT 8; -- Supondo que 8 equipes se classificam
END;
//
DELIMITER ;

-- Encerramento de Torneios
DELIMITER //

CREATE PROCEDURE EncerrarTorneio(IN torneio_id INT)
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
END;
//
DELIMITER ;

