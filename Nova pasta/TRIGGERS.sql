-- Trigger para Atualizar a Classificação Após Registro de Resultado

CREATE TRIGGER TRG_UPDATE_CLASSIFICACAO 
ON PARTIDA
AFTER INSERT, UPDATE
AS
BEGIN
    -- Declaração de variáveis
    DECLARE @equipa1_id INT, @equipa2_id INT, @resultado VARCHAR(50), @modalidade_id INT, @grupo_por_equipas1 INT, @grupo_por_equipas2 INT;

    -- Recuperar valores da partida
    SELECT 
        @equipa1_id = EQUIPA1_ID, 
        @equipa2_id = EQUIPA2_ID, 
        @resultado = RESULTADO,
        @modalidade_id = MODALIDADE_ID
    FROM 
        INSERTED
    INNER JOIN FASE ON FASE.ID = INSERTED.FASE_ID;

    -- Obter ID de grupo por equipa
    SELECT @grupo_por_equipas1 = ID FROM GRUPO_POR_EQUIPA WHERE EQUIPA_ID = @equipa1_id;
    SELECT @grupo_por_equipas2 = ID FROM GRUPO_POR_EQUIPA WHERE EQUIPA_ID = @equipa2_id;

    -- Atualizar classificação de acordo com o resultado
    IF @resultado = 'E' -- Empate
    BEGIN
        UPDATE CLASSIFICACAO
        SET PONTOS = PONTOS + 1, EMPATES = EMPATES + 1
        WHERE GRUPO_POR_EQUIPA_ID IN (@grupo_por_equipas1, @grupo_por_equipas2);
    END
    ELSE IF @resultado = 'V1' -- Vitória da equipe 1
    BEGIN
        UPDATE CLASSIFICACAO
        SET PONTOS = PONTOS + 3, VITORIAS = VITORIAS + 1
        WHERE GRUPO_POR_EQUIPA_ID = @grupo_por_equipas1;

        UPDATE CLASSIFICACAO
        SET DERROTAS = DERROTAS + 1
        WHERE GRUPO_POR_EQUIPA_ID = @grupo_por_equipas2;
    END
    ELSE IF @resultado = 'V2' -- Vitória da equipe 2
    BEGIN
        UPDATE CLASSIFICACAO
        SET PONTOS = PONTOS + 3, VITORIAS = VITORIAS + 1
        WHERE GRUPO_POR_EQUIPA_ID = @grupo_por_equipas2;

        UPDATE CLASSIFICACAO
        SET DERROTAS = DERROTAS + 1
        WHERE GRUPO_POR_EQUIPA_ID = @grupo_por_equipas1;
    END
END;

-- Trigger para Validar Datas de Torneios

CREATE TRIGGER TRG_VALIDATE_TORNEIO_DATES 
ON TORNEIO
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @data_inicio DATETIME, @data_fim DATETIME;

    -- Recuperar valores das novas inserções
    SELECT @data_inicio = DATA_INICIO, @data_fim = DATA_FIM FROM INSERTED;

    -- Validar datas
    IF @data_inicio >= @data_fim
    BEGIN
        RAISERROR('A data de início deve ser anterior à data de fim.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        -- Inserir os valores caso estejam corretos
        INSERT INTO TORNEIO (DESCRICAO, STATUS, DATA_INICIO, DATA_FIM)
        SELECT DESCRICAO, STATUS, DATA_INICIO, DATA_FIM FROM INSERTED;
    END
END;


-- Trigger para Validar Datas de Torneios


CREATE TRIGGER TRG_GENERATE_CALENDARIO 
ON PARTIDA
AFTER INSERT
AS
BEGIN
    INSERT INTO CALENDARIO (PARTIDA_ID, DATA_HORA, DESCRICAO)
    SELECT 
        ID AS PARTIDA_ID, 
        DATA_HORA, 
        CONCAT('Jogo entre ', 
               (SELECT NOME FROM EQUIPA WHERE ID = EQUIPA1_ID), 
               ' e ', 
               (SELECT NOME FROM EQUIPA WHERE ID = EQUIPA2_ID))
    FROM INSERTED;
END;






